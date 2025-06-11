using System;
using System.Collections.Generic;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.DynCipher;
using XVM.DynCipher.AST;
using XVM.DynCipher.Generation;

namespace XVM.Core.RT
{
	public class ILVDynamicDeriver
	{
		private class NoC : CILCodeGen
		{
			private readonly Local Com;

			private readonly Local xo5;

			public NoC(Local local_0, Local local_1, MethodDef methodDef_0, IList<Instruction> ilist_0)
				: base(methodDef_0, ilist_0)
			{
				Com = local_0;
				xo5 = local_1;
			}

			protected override Local Var(Variable variable_0)
			{
				if (variable_0.Name == "{BUFFER}")
				{
					return Com;
				}
				if (!(variable_0.Name == "{KEY}"))
				{
					return base.Var(variable_0);
				}
				return xo5;
			}
		}

		public int Seed = 0;

		private StatementBlock iNT;

		private VMRuntime lNS;

		private Action<uint[], uint[]> fNa;

		public void Initialize(VMRuntime vmruntime_0)
		{
			Seed = BitConverter.ToInt32(Encoding.Default.GetBytes(vmruntime_0.f2C().NKv.Name), 0);
			new DynCipherService().GenerateCipherPair(vmruntime_0.Descriptor.iqK(), out iNT, out var _);
			DMCodeGen dMCodeGen = new DMCodeGen(typeof(void), new Tuple<string, Type>[2]
			{
				Tuple.Create("{BUFFER}", typeof(uint[])),
				Tuple.Create("{KEY}", typeof(uint[]))
			});
			dMCodeGen.method_1(iNT);
			lNS = vmruntime_0;
			fNa = dMCodeGen.Compile<Action<uint[], uint[]>>();
		}

		public byte[] Encrypt(byte[] byte_0, int int_0)
		{
			byte_0 = (byte[])byte_0.Clone();
			ulong num = (uint)Seed;
			uint[] array = new uint[16];
			uint[] array2 = new uint[16];
			for (int i = 0; i < 16; i++)
			{
				num = num * num % 339722377L;
				array2[i] = (uint)num;
				array[i] = (uint)(num * num % 1145919227L);
			}
			uint[] array3 = new uint[array2.Length];
			Buffer.BlockCopy(array, int_0 * 4, array3, 0, array2.Length * 4);
			fNa(array3, array2);
			for (int j = 0; j < 16; j++)
			{
				num ^= num >> 13;
				num ^= num << 25;
				num ^= num >> 27;
				array2[j] = 0u;
				array[j] = 0u;
				switch (j % 3)
				{
				case 0:
					array3[j] ^= (uint)(int)num;
					break;
				case 1:
					array3[j] *= (uint)(int)num;
					break;
				case 2:
					array3[j] += (uint)(int)num;
					break;
				}
			}
			for (int k = 0; k < byte_0.Length; k++)
			{
				byte_0[k] ^= (byte)num;
				if ((k & 0xFF) == 0)
				{
					num = num * num % 9067703L;
				}
			}
			byte_0 = lNS.CompressionService.LZMA_Compress(byte_0);
			Array.Resize(ref byte_0, (byte_0.Length + 3) & -4);
			byte[] array4 = new byte[byte_0.Length];
			int num2 = 0;
			for (int l = 0; l < byte_0.Length; l += 4)
			{
				uint num3 = (uint)(byte_0[l] | (byte_0[l + 1] << 8) | (byte_0[l + 2] << 16) | (byte_0[l + 3] << 24));
				uint num4 = num3 ^ array3[num2 & 0xF];
				array3[num2 & 0xF] = (array3[num2 & 0xF] ^ num3) + 1037772825;
				array4[l] = (byte)num4;
				array4[l + 1] = (byte)(num4 >> 8);
				array4[l + 2] = (byte)(num4 >> 16);
				array4[l + 3] = (byte)(num4 >> 24);
				num2++;
			}
			return array4;
		}

		public IEnumerable<Instruction> EmitDecrypt(MethodDef methodDef_0, Local local_0, Local local_1)
		{
			List<Instruction> list = new List<Instruction>();
			NoC noC = new NoC(local_0, local_1, methodDef_0, list);
			noC.method_1(iNT);
			noC.Commit(methodDef_0.Body);
			return list;
		}
	}
}
