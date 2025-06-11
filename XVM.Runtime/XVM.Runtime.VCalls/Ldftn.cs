using System;
using System.Collections.Generic;
using System.Reflection;
using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.VCalls
{
	internal class Ldftn : IVCall
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.VCALL_LDFTN;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u--];
			VMSlot vMSlot2 = ctx.Stack[u];
			if (vMSlot2.O != null)
			{
				MethodInfo methodInfo = (MethodInfo)ctx.Instance.Data.LookupReference(vMSlot.U4);
				Type type = vMSlot2.O.GetType();
				List<Type> list = new List<Type>();
				do
				{
					list.Add(type);
					type = type.BaseType;
				}
				while ((object)type != null && (object)type != methodInfo.DeclaringType);
				list.Reverse();
				MethodInfo methodInfo2 = methodInfo;
				foreach (Type item in list)
				{
					MethodInfo[] methods = item.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					foreach (MethodInfo methodInfo3 in methods)
					{
						if ((object)methodInfo3.GetBaseDefinition() == methodInfo2)
						{
							methodInfo2 = methodInfo3;
							break;
						}
					}
				}
				ctx.Stack[u] = new VMSlot
				{
					U8 = (ulong)(long)methodInfo2.MethodHandle.GetFunctionPointer()
				};
			}
			else
			{
				MethodBase methodBase = (MethodBase)ctx.Instance.Data.LookupReference(vMSlot.U4);
				ctx.Stack[u] = new VMSlot
				{
					U8 = (ulong)(long)methodBase.MethodHandle.GetFunctionPointer()
				};
			}
			ctx.Stack.SetTopPosition(u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			state = ExecutionState.Next;
		}
	}
}
