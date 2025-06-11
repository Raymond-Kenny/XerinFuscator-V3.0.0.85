using System;
using System.Collections.Generic;
using Confuser.DynCipher;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Generator;

namespace XF
{
	internal class Be : EH
	{
		private readonly Dictionary<MethodDef, Tuple<int, int>> iJ = new Dictionary<MethodDef, Tuple<int, int>>();

		public Instruction[] sP0(MethodDef methodDef_0, x29 x29_0, Instruction[] instruction_0)
		{
			Tuple<int, int> tuple = iC(x29_0.d2r, methodDef_0);
			List<Instruction> list = new List<Instruction>();
			if (x29_0.d2r.NextBoolean())
			{
				list.Add(Instruction.Create(OpCodes.Ldc_I4, tuple.Item1));
				list.AddRange(instruction_0);
			}
			else
			{
				list.AddRange(instruction_0);
				list.Add(Instruction.Create(OpCodes.Ldc_I4, tuple.Item1));
			}
			list.Add(Instruction.Create(OpCodes.Mul));
			return list.ToArray();
		}

		public int xPQ(MethodDef methodDef_0, x29 x29_0, int int_0)
		{
			Tuple<int, int> tuple = iC(x29_0.d2r, methodDef_0);
			if (tuple.Item2 == 0)
			{
				throw new InvalidOperationException("Invalid encoding key generated.");
			}
			return int_0 * tuple.Item2;
		}

		private Tuple<int, int> iC(RandomGenerator randomGenerator_0, MethodDef methodDef_0)
		{
			if (!iJ.TryGetValue(methodDef_0, out var value))
			{
				int num = randomGenerator_0.NextInt32() | 1;
				value = (iJ[methodDef_0] = Tuple.Create(num, (int)MathsUtils.modInv((uint)num)));
			}
			return value;
		}
	}
}
