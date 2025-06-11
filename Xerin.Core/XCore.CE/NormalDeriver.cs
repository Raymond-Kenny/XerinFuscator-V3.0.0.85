using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XCore.CE
{
	public class NormalDeriver : IKeyDeriver
	{
		public void Init()
		{
		}

		public uint[] DeriveKey(uint[] uint_0, uint[] uint_1)
		{
			uint[] array = new uint[16];
			for (int i = 0; i < 16; i++)
			{
				switch (i % 3)
				{
				case 0:
					array[i] = uint_0[i] ^ uint_1[i];
					break;
				case 1:
					array[i] = uint_0[i] * uint_1[i];
					break;
				case 2:
					array[i] = uint_0[i] + uint_1[i];
					break;
				}
			}
			return array;
		}

		public IEnumerable<Instruction> EmitDerivation(MethodDef methodDef_0, Local local_0, Local local_1)
		{
			for (int i = 0; i < 16; i++)
			{
				yield return Instruction.Create(OpCodes.Ldloc, local_0);
				yield return Instruction.Create(OpCodes.Ldc_I4, i);
				yield return Instruction.Create(OpCodes.Ldloc, local_0);
				yield return Instruction.Create(OpCodes.Ldc_I4, i);
				yield return Instruction.Create(OpCodes.Ldelem_U4);
				yield return Instruction.Create(OpCodes.Ldloc, local_1);
				yield return Instruction.Create(OpCodes.Ldc_I4, i);
				yield return Instruction.Create(OpCodes.Ldelem_U4);
				switch (i % 3)
				{
				case 0:
					yield return Instruction.Create(OpCodes.Xor);
					break;
				case 1:
					yield return Instruction.Create(OpCodes.Mul);
					break;
				case 2:
					yield return Instruction.Create(OpCodes.Add);
					break;
				}
				yield return Instruction.Create(OpCodes.Stelem_I4);
			}
		}
	}
}
