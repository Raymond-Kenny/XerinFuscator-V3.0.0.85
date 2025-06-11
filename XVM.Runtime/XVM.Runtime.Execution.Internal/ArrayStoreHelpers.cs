using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;

namespace XVM.Runtime.XVM.Runtime.Execution.Internal
{
	internal class ArrayStoreHelpers
	{
		private delegate void _SetValue(Array array, int index, object value);

		private static Hashtable storeHelpers = new Hashtable();

		public static void SetValue(Array array, int index, object value, Type valueType, Type elemType)
		{
			Debug.Assert(value == null || (object)value.GetType() == valueType);
			KeyValuePair<Type, Type> keyValuePair = new KeyValuePair<Type, Type>(valueType, elemType);
			object obj = storeHelpers[keyValuePair];
			if (obj == null)
			{
				lock (storeHelpers)
				{
					obj = storeHelpers[keyValuePair];
					if (obj == null)
					{
						obj = BuildStoreHelper(valueType, elemType);
						storeHelpers[keyValuePair] = obj;
					}
				}
			}
			((_SetValue)obj)(array, index, value);
		}

		private static _SetValue BuildStoreHelper(Type valueType, Type elemType)
		{
			Type[] parameterTypes = new Type[3]
			{
				typeof(Array),
				typeof(int),
				typeof(object)
			};
			DynamicMethod dynamicMethod = new DynamicMethod("", typeof(void), parameterTypes, typeof(ArrayStoreHelpers).Module, true);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarg_0);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarg_1);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarg_2);
			if (elemType.IsValueType)
			{
				iLGenerator.Emit(System.Reflection.Emit.OpCodes.Unbox_Any, valueType);
			}
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Stelem, elemType);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ret);
			return (_SetValue)dynamicMethod.CreateDelegate(typeof(_SetValue));
		}
	}
}
