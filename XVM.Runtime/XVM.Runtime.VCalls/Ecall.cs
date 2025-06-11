using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Execution;
using XVM.Runtime.XVM.Runtime.Execution.Internal;

namespace XVM.Runtime.XVM.Runtime.VCalls
{
	internal class Ecall : IVCall
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.VCALL_ECALL;

		private static object PopObject(VMContext ctx, Type type, ref uint sp)
		{
			VMSlot vMSlot = ctx.Stack[sp--];
			if (Type.GetTypeCode(type) == TypeCode.String && vMSlot.O == null)
			{
				return ctx.Instance.Data.LookupString(vMSlot.U4);
			}
			return vMSlot.ToObject(type);
		}

		private unsafe static IReference PopRef(VMContext ctx, Type type, ref uint sp)
		{
			VMSlot value = ctx.Stack[sp];
			if (type.IsByRef)
			{
				sp--;
				type = type.GetElementType();
				if (value.O is Pointer)
				{
					void* ptr = Pointer.Unbox(value.O);
					return new PointerRef(ptr);
				}
				if (value.O is IReference)
				{
					return (IReference)value.O;
				}
				return new PointerRef((void*)value.U8);
			}
			if (Type.GetTypeCode(type) == TypeCode.String && value.O == null)
			{
				value.O = ctx.Instance.Data.LookupString(value.U4);
				ctx.Stack[sp] = value;
			}
			return new StackRef(sp--);
		}

		private static bool NeedTypedInvoke(VMContext ctx, uint sp, MethodBase method, bool isNewObj)
		{
			if (!isNewObj && !method.IsStatic && method.DeclaringType.IsValueType)
			{
				return true;
			}
			ParameterInfo[] parameters = method.GetParameters();
			foreach (ParameterInfo parameterInfo in parameters)
			{
				if (parameterInfo.ParameterType.IsByRef)
				{
					return true;
				}
			}
			if (method is MethodInfo && ((MethodInfo)method).ReturnType.IsByRef)
			{
				return true;
			}
			return false;
		}

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint sp = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[sp--];
			uint id = vMSlot.U4 & 0x3FFFFFFF;
			byte b = (byte)(vMSlot.U4 >> 30);
			MethodBase methodBase = (MethodBase)ctx.Instance.Data.LookupReference(id);
			bool flag = b == ctx.Data.Constants.ECALL_CALLVIRT_CONSTRAINED;
			if (!flag)
			{
				flag = NeedTypedInvoke(ctx, sp, methodBase, b == ctx.Data.Constants.ECALL_NEWOBJ);
			}
			if (flag)
			{
				InvokeTyped(ctx, methodBase, b, ref sp, out state);
			}
			else
			{
				InvokeNormal(ctx, methodBase, b, ref sp, out state);
			}
		}

		private void InvokeNormal(VMContext ctx, MethodBase targetMethod, byte opCode, ref uint sp, out ExecutionState state)
		{
			uint sp2 = sp;
			ParameterInfo[] parameters = targetMethod.GetParameters();
			object obj = null;
			object[] array = new object[parameters.Length];
			if (opCode == ctx.Data.Constants.ECALL_CALL && targetMethod.IsVirtual)
			{
				int num = !targetMethod.IsStatic ? 1 : 0;
				array = new object[parameters.Length + num];
				for (int num2 = parameters.Length - 1; num2 >= 0; num2--)
				{
					array[num2 + num] = PopObject(ctx, parameters[num2].ParameterType, ref sp);
				}
				if (!targetMethod.IsStatic)
				{
					array[0] = PopObject(ctx, targetMethod.DeclaringType, ref sp);
				}
				targetMethod = DirectCall.GetDirectInvocationProxy(targetMethod);
			}
			else
			{
				array = new object[parameters.Length];
				for (int num3 = parameters.Length - 1; num3 >= 0; num3--)
				{
					array[num3] = PopObject(ctx, parameters[num3].ParameterType, ref sp);
				}
				if (!targetMethod.IsStatic && opCode != ctx.Data.Constants.ECALL_NEWOBJ)
				{
					obj = PopObject(ctx, targetMethod.DeclaringType, ref sp);
					if (obj != null && !targetMethod.DeclaringType.IsInstanceOfType(obj))
					{
						InvokeTyped(ctx, targetMethod, opCode, ref sp2, out state);
						return;
					}
				}
			}
			object obj2;
			if (opCode == ctx.Data.Constants.ECALL_NEWOBJ)
			{
				try
				{
					obj2 = ((ConstructorInfo)targetMethod).Invoke(array);
				}
				catch (TargetInvocationException ex)
				{
					throw ex;
				}
			}
			else
			{
				if (!targetMethod.IsStatic && obj == null)
				{
					throw new NullReferenceException();
				}
				Type type;
				if (obj != null && (type = obj.GetType()).IsArray && targetMethod.Name == "SetValue")
				{
					ArrayStoreHelpers.SetValue(valueType: array[0] != null ? array[0].GetType() : type.GetElementType(), array: (Array)obj, index: (int)array[1], value: array[0], elemType: type.GetElementType());
					obj2 = null;
				}
				else
				{
					try
					{
						obj2 = targetMethod.Invoke(obj, array);
					}
					catch (TargetInvocationException ex2)
					{
						VMDispatcher.DoThrow(ctx, ex2.InnerException);
						throw;
					}
				}
			}
			if (targetMethod is MethodInfo && (object)((MethodInfo)targetMethod).ReturnType != typeof(void))
			{
				ctx.Stack[++sp] = VMSlot.FromObject(obj2, ((MethodInfo)targetMethod).ReturnType);
			}
			else if (opCode == ctx.Data.Constants.ECALL_NEWOBJ)
			{
				ctx.Stack[++sp] = VMSlot.FromObject(obj2, targetMethod.DeclaringType);
			}
			ctx.Stack.SetTopPosition(sp);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = sp;
			state = ExecutionState.Next;
		}

		private void InvokeTyped(VMContext ctx, MethodBase targetMethod, byte opCode, ref uint sp, out ExecutionState state)
		{
			ParameterInfo[] parameters = targetMethod.GetParameters();
			int num = parameters.Length;
			if (!targetMethod.IsStatic && opCode != ctx.Data.Constants.ECALL_NEWOBJ)
			{
				num++;
			}
			Type type = null;
			if (opCode == ctx.Data.Constants.ECALL_CALLVIRT_CONSTRAINED)
			{
				type = (Type)ctx.Instance.Data.LookupReference(ctx.Stack[sp--].U4);
			}
			int num2 = !targetMethod.IsStatic && opCode != ctx.Data.Constants.ECALL_NEWOBJ ? 1 : 0;
			IReference[] array = new IReference[num];
			Type[] array2 = new Type[num];
			for (int num3 = num - 1; num3 >= 0; num3--)
			{
				Type type2;
				if (!targetMethod.IsStatic && opCode != ctx.Data.Constants.ECALL_NEWOBJ)
				{
					if (num3 == 0)
					{
						if (!targetMethod.IsStatic)
						{
							VMSlot vMSlot = ctx.Stack[sp];
							if (vMSlot.O is ValueType && !targetMethod.DeclaringType.IsValueType)
							{
								Debug.Assert(targetMethod.DeclaringType.IsInterface);
								Debug.Assert(opCode == ctx.Data.Constants.ECALL_CALLVIRT);
								type = vMSlot.O.GetType();
							}
						}
						type2 = (object)type != null ? type.MakeByRefType() : !targetMethod.DeclaringType.IsValueType ? targetMethod.DeclaringType : targetMethod.DeclaringType.MakeByRefType();
					}
					else
					{
						type2 = parameters[num3 - 1].ParameterType;
					}
				}
				else
				{
					type2 = parameters[num3].ParameterType;
				}
				array[num3] = PopRef(ctx, type2, ref sp);
				if (type2.IsByRef)
				{
					type2 = type2.GetElementType();
				}
				array2[num3] = type2;
			}
			OpCode opCode2;
			Type type3;
			if (opCode == ctx.Data.Constants.ECALL_CALL)
			{
				opCode2 = System.Reflection.Emit.OpCodes.Call;
				type3 = targetMethod is MethodInfo ? ((MethodInfo)targetMethod).ReturnType : typeof(void);
			}
			else if (opCode == ctx.Data.Constants.ECALL_CALLVIRT || opCode == ctx.Data.Constants.ECALL_CALLVIRT_CONSTRAINED)
			{
				opCode2 = System.Reflection.Emit.OpCodes.Callvirt;
				type3 = targetMethod is MethodInfo ? ((MethodInfo)targetMethod).ReturnType : typeof(void);
			}
			else
			{
				if (opCode != ctx.Data.Constants.ECALL_NEWOBJ)
				{
					throw new InvalidProgramException();
				}
				opCode2 = System.Reflection.Emit.OpCodes.Newobj;
				type3 = targetMethod.DeclaringType;
			}
			DirectCall.TypedInvocation typedInvocationProxy = DirectCall.GetTypedInvocationProxy(targetMethod, opCode2, type);
			object obj = typedInvocationProxy(ctx, array, array2);
			if ((object)type3 != typeof(void))
			{
				ctx.Stack[++sp] = VMSlot.FromObject(obj, type3);
			}
			else if (opCode == ctx.Data.Constants.ECALL_NEWOBJ)
			{
				ctx.Stack[++sp] = VMSlot.FromObject(obj, type3);
			}
			ctx.Stack.SetTopPosition(sp);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = sp;
			state = ExecutionState.Next;
		}
	}
}
