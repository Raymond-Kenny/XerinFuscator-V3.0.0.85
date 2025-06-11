using System;
using System.Collections;
using System.Reflection.Emit;

namespace XVM.Runtime.XVM.Runtime.Execution.Internal
{
	internal class SizeOfHelper
	{
		private static Hashtable sizes = new Hashtable();

		public static int SizeOf(Type type)
		{
			object obj = sizes[type];
			if (obj == null)
			{
				lock (sizes)
				{
					obj = sizes[type];
					if (obj == null)
					{
						obj = GetSize(type);
						sizes[type] = obj;
					}
				}
			}
			return (int)obj;
		}

		private static int GetSize(Type type)
		{
			DynamicMethod dynamicMethod = new DynamicMethod("", typeof(int), Type.EmptyTypes, typeof(SizeOfHelper).Module, true);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Sizeof, type);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ret);
			return (int)dynamicMethod.Invoke(null, null);
		}
	}
}
