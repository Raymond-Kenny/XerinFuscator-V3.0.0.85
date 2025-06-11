using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace XVM.Runtime.XVM.Runtime.Execution.Internal
{
	internal static class DirectCall
	{
		public delegate object TypedInvocation(VMContext ctx, IReference[] refs, Type[] types);

		private static Hashtable directProxies;

		private static Hashtable typedProxies;

		private static Hashtable constrainedProxies;

		private static MethodInfo refToTypedRef;

		private static MethodInfo castTypedRef;

		private static ConstructorInfo newTypedRef;

		static DirectCall()
		{
			directProxies = new Hashtable();
			typedProxies = new Hashtable();
			constrainedProxies = new Hashtable();
			MethodInfo[] methods = typeof(IReference).GetMethods();
			foreach (MethodInfo methodInfo in methods)
			{
				ParameterInfo[] parameters = methodInfo.GetParameters();
				foreach (ParameterInfo parameterInfo in parameters)
				{
					if ((object)parameterInfo.ParameterType == typeof(TypedRefPtr))
					{
						refToTypedRef = methodInfo;
						break;
					}
				}
				if ((object)refToTypedRef != null)
				{
					break;
				}
			}
			MethodInfo[] methods2 = typeof(TypedReferenceHelpers).GetMethods();
			foreach (MethodInfo methodInfo2 in methods2)
			{
				if ((object)methodInfo2.GetParameters()[0].ParameterType == typeof(TypedRefPtr))
				{
					castTypedRef = methodInfo2;
					break;
				}
			}
			ConstructorInfo[] constructors = typeof(TypedRef).GetConstructors();
			foreach (ConstructorInfo constructorInfo in constructors)
			{
				ParameterInfo[] parameters2 = constructorInfo.GetParameters();
				foreach (ParameterInfo parameterInfo2 in parameters2)
				{
					if ((object)parameterInfo2.ParameterType == typeof(TypedReference))
					{
						newTypedRef = constructorInfo;
						break;
					}
				}
				if ((object)newTypedRef != null)
				{
					break;
				}
			}
		}

		public static MethodBase GetDirectInvocationProxy(MethodBase method)
		{
			MethodBase methodBase = (MethodBase)directProxies[method];
			if ((object)methodBase != null)
			{
				return methodBase;
			}
			lock (directProxies)
			{
				methodBase = (MethodBase)directProxies[method];
				if ((object)methodBase != null)
				{
					return methodBase;
				}
				ParameterInfo[] parameters = method.GetParameters();
				Type[] array = new Type[parameters.Length + (!method.IsStatic ? 1 : 0)];
				for (int i = 0; i < array.Length; i++)
				{
					if (method.IsStatic)
					{
						array[i] = parameters[i].ParameterType;
					}
					else if (i == 0)
					{
						array[0] = method.DeclaringType;
					}
					else
					{
						array[i] = parameters[i - 1].ParameterType;
					}
				}
				Type returnType = method is MethodInfo ? ((MethodInfo)method).ReturnType : typeof(void);
				DynamicMethod dynamicMethod = new DynamicMethod("", returnType, array, typeof(DirectCall).Module, true);
				ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
				for (int j = 0; j < array.Length; j++)
				{
					if (!method.IsStatic && j == 0 && array[0].IsValueType)
					{
						iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarga, j);
					}
					else
					{
						iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarg, j);
					}
				}
				if (method is MethodInfo)
				{
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Call, (MethodInfo)method);
				}
				else
				{
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Call, (ConstructorInfo)method);
				}
				iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ret);
				directProxies[method] = dynamicMethod;
				return dynamicMethod;
			}
		}

		public static TypedInvocation GetTypedInvocationProxy(MethodBase method, OpCode opCode, Type constrainType)
		{
			object key;
			Hashtable hashtable;
			if ((object)constrainType == null)
			{
				key = new KeyValuePair<MethodBase, OpCode>(method, opCode);
				hashtable = typedProxies;
			}
			else
			{
				key = new KeyValuePair<MethodBase, Type>(method, constrainType);
				hashtable = constrainedProxies;
			}
			TypedInvocation typedInvocation = (TypedInvocation)hashtable[key];
			if (typedInvocation != null)
			{
				return typedInvocation;
			}
			lock (typedProxies)
			{
				typedInvocation = (TypedInvocation)hashtable[key];
				if (typedInvocation != null)
				{
					return typedInvocation;
				}
				ParameterInfo[] parameters = method.GetParameters();
				Type[] array;
				if (opCode != System.Reflection.Emit.OpCodes.Newobj)
				{
					array = new Type[parameters.Length + (!method.IsStatic ? 1 : 0) + 1];
					for (int i = 0; i < array.Length - 1; i++)
					{
						if (method.IsStatic)
						{
							array[i] = parameters[i].ParameterType;
						}
						else if (i == 0)
						{
							if ((object)constrainType != null)
							{
								array[0] = constrainType.MakeByRefType();
							}
							else if (method.DeclaringType.IsValueType)
							{
								array[0] = method.DeclaringType.MakeByRefType();
							}
							else
							{
								array[0] = method.DeclaringType;
							}
						}
						else
						{
							array[i] = parameters[i - 1].ParameterType;
						}
					}
				}
				else
				{
					array = new Type[parameters.Length + 1];
					for (int j = 0; j < array.Length - 1; j++)
					{
						array[j] = parameters[j].ParameterType;
					}
				}
				Type type = method is MethodInfo ? ((MethodInfo)method).ReturnType : typeof(void);
				if (opCode == System.Reflection.Emit.OpCodes.Newobj)
				{
					type = method.DeclaringType;
				}
				DynamicMethod dynamicMethod = new DynamicMethod("", typeof(object), new Type[3]
				{
					typeof(VMContext),
					typeof(IReference[]),
					typeof(Type[])
				}, typeof(DirectCall).Module, true);
				ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
				for (int k = 0; k < array.Length - 1; k++)
				{
					Type type2 = array[k];
					bool isByRef = type2.IsByRef;
					if (isByRef)
					{
						type2 = type2.GetElementType();
					}
					LocalBuilder local = iLGenerator.DeclareLocal(typeof(TypedReference));
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarg_1);
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldc_I4, k);
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldelem_Ref);
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarg_0);
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldloca, local);
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarg_2);
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldc_I4, k);
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldelem_Ref);
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Callvirt, refToTypedRef);
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldloca, local);
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarg_2);
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldc_I4, k);
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldelem_Ref);
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Call, castTypedRef);
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldloc, local);
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Refanyval, type2);
					if (!isByRef)
					{
						iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldobj, type2);
					}
				}
				if ((object)constrainType != null)
				{
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Constrained, constrainType);
				}
				if (method is MethodInfo)
				{
					iLGenerator.Emit(opCode, (MethodInfo)method);
				}
				else
				{
					iLGenerator.Emit(opCode, (ConstructorInfo)method);
				}
				if (type.IsByRef)
				{
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Mkrefany, type.GetElementType());
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Newobj, newTypedRef);
				}
				else if ((object)type == typeof(void))
				{
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldnull);
				}
				else if (type.IsValueType)
				{
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Box, type);
				}
				iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ret);
				return (TypedInvocation)(hashtable[key] = (TypedInvocation)dynamicMethod.CreateDelegate(typeof(TypedInvocation)));
			}
		}
	}
}
