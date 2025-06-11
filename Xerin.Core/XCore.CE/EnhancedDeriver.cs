using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XCore.CE
{
	public class EnhancedDeriver : IKeyDeriver
	{
		private uint[] zQy;

		public void Init()
		{
			zQy = new uint[16];
			for (int i = 0; i < 16; i++)
			{
				zQy[i] = (uint)(Environment.TickCount ^ (i * 32749));
			}
		}

		public uint[] DeriveKey(uint[] uint_0, uint[] uint_1)
		{
			uint[] array = new uint[16];
			for (int i = 0; i < 16; i++)
			{
				switch (i % 4)
				{
				case 0:
					array[i] = uint_0[i] ^ uint_1[i] ^ zQy[i];
					break;
				case 1:
					array[i] = uint_0[i] * uint_1[i] + zQy[i];
					break;
				case 2:
					array[i] = (uint_0[i] + uint_1[i]) * zQy[i];
					break;
				case 3:
					array[i] = BQq(uint_0[i] ^ uint_1[i], (byte)(i + zQy[i] % 32));
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
				switch (i % 4)
				{
				case 0:
					yield return Instruction.Create(OpCodes.Xor);
					yield return Instruction.Create(OpCodes.Ldc_I4, (int)zQy[i]);
					yield return Instruction.Create(OpCodes.Xor);
					break;
				case 1:
					yield return Instruction.Create(OpCodes.Mul);
					yield return Instruction.Create(OpCodes.Ldc_I4, (int)zQy[i]);
					yield return Instruction.Create(OpCodes.Add);
					break;
				case 2:
					yield return Instruction.Create(OpCodes.Add);
					yield return Instruction.Create(OpCodes.Ldc_I4, (int)zQy[i]);
					yield return Instruction.Create(OpCodes.Mul);
					break;
				case 3:
					yield return Instruction.Create(OpCodes.Xor);
					yield return Instruction.Create(OpCodes.Ldc_I4, (int)(i + zQy[i] % 32));
					yield return Instruction.Create(OpCodes.Ldc_I4, 32);
					yield return Instruction.Create(OpCodes.Sub);
					yield return Instruction.Create(OpCodes.Ldc_I4_M1);
					yield return Instruction.Create(OpCodes.Xor);
					yield return Instruction.Create(OpCodes.Shr_Un);
					break;
				}
				yield return Instruction.Create(OpCodes.Stelem_I4);
			}
		}

		private static uint BQq(uint uint_0, byte byte_0)
		{
			return (uint_0 << (int)byte_0) | (uint_0 >> 32 - byte_0);
		}
	}
}
