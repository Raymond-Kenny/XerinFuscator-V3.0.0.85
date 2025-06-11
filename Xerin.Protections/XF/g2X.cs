using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using dnlib.DotNet.Emit;

namespace XF
{
	internal class g2X
	{
		private static Dictionary<System.Reflection.Emit.OpCode, dnlib.DotNet.Emit.OpCode> L2o;

		private static dnlib.DotNet.Emit.OpCode x2n;

		public static dnlib.DotNet.Emit.OpCode z2y(System.Reflection.Emit.OpCode opCode_0)
		{
			if (!L2o.TryGetValue(opCode_0, out x2n))
			{
				return dnlib.DotNet.Emit.OpCodes.Nop;
			}
			return x2n;
		}

		public static void i2g()
		{
			Dictionary<short, dnlib.DotNet.Emit.OpCode> dictionary = new Dictionary<short, dnlib.DotNet.Emit.OpCode>(256);
			FieldInfo[] fields = typeof(dnlib.DotNet.Emit.OpCodes).GetFields(BindingFlags.Static | BindingFlags.Public);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (!(fieldInfo.FieldType != typeof(dnlib.DotNet.Emit.OpCode)))
				{
					dnlib.DotNet.Emit.OpCode opCode = (dnlib.DotNet.Emit.OpCode)fieldInfo.GetValue(null);
					dictionary[opCode.Value] = opCode;
				}
			}
			FieldInfo[] fields2 = typeof(System.Reflection.Emit.OpCodes).GetFields(BindingFlags.Static | BindingFlags.Public);
			foreach (FieldInfo fieldInfo2 in fields2)
			{
				if (!(fieldInfo2.FieldType != typeof(System.Reflection.Emit.OpCode)))
				{
					System.Reflection.Emit.OpCode key = (System.Reflection.Emit.OpCode)fieldInfo2.GetValue(null);
					if (dictionary.TryGetValue(key.Value, out x2n))
					{
						L2o[key] = x2n;
					}
				}
			}
		}

		static g2X()
		{
			L2o = new Dictionary<System.Reflection.Emit.OpCode, dnlib.DotNet.Emit.OpCode>();
		}
	}
}
