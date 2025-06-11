using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using dnlib.DotNet.Emit;

namespace XF
{
	internal class a24
	{
		private static Dictionary<dnlib.DotNet.Emit.OpCode, System.Reflection.Emit.OpCode> e2B;

		private static System.Reflection.Emit.OpCode k2p;

		public static System.Reflection.Emit.OpCode k2s(object object_0)
		{
			if (e2B.TryGetValue((dnlib.DotNet.Emit.OpCode)object_0, out k2p))
			{
				return k2p;
			}
			return System.Reflection.Emit.OpCodes.Nop;
		}

		public static void P2Y()
		{
			Dictionary<short, System.Reflection.Emit.OpCode> dictionary = new Dictionary<short, System.Reflection.Emit.OpCode>(256);
			FieldInfo[] fields = typeof(System.Reflection.Emit.OpCodes).GetFields(BindingFlags.Static | BindingFlags.Public);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (!(fieldInfo.FieldType != typeof(System.Reflection.Emit.OpCode)))
				{
					System.Reflection.Emit.OpCode value = (System.Reflection.Emit.OpCode)fieldInfo.GetValue(null);
					dictionary[value.Value] = value;
				}
			}
			FieldInfo[] fields2 = typeof(dnlib.DotNet.Emit.OpCodes).GetFields(BindingFlags.Static | BindingFlags.Public);
			foreach (FieldInfo fieldInfo2 in fields2)
			{
				if (!(fieldInfo2.FieldType != typeof(dnlib.DotNet.Emit.OpCode)))
				{
					dnlib.DotNet.Emit.OpCode opCode = (dnlib.DotNet.Emit.OpCode)fieldInfo2.GetValue(null);
					if (dictionary.TryGetValue(opCode.Value, out k2p))
					{
						e2B[opCode] = k2p;
					}
				}
			}
		}

		static a24()
		{
			e2B = new Dictionary<dnlib.DotNet.Emit.OpCode, System.Reflection.Emit.OpCode>();
		}
	}
}
