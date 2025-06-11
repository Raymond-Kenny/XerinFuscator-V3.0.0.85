#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.RT;
using XVM.DynCipher;
using XVM.DynCipher.AST;
using XVM.DynCipher.Generation;

namespace XVM.Core.JIT
{
	public class JITDynamicDeriver
	{
		private class RlU : CILCodeGen
		{
			private readonly Local xlh;

			private readonly Local alP;

			public RlU(Local local_0, Local local_1, MethodDef methodDef_0, IList<Instruction> ilist_0)
				: base(methodDef_0, ilist_0)
			{
				xlh = local_0;
				alP = local_1;
			}

			protected override Local Var(Variable variable_0)
			{
				if (variable_0.Name == "{BUFFER}")
				{
					return xlh;
				}
				if (variable_0.Name == "{KEY}")
				{
					return alP;
				}
				return base.Var(variable_0);
			}
		}

		public int Seed = 0;

		private VMRuntime Q1p;

		private Action<uint[], uint[]> s1r;

		public IEnumerable<Instruction> EmitDecrypt(MethodDef methodDef_0, VMRuntime vmruntime_0, Local local_0, Local local_1)
		{
			Seed = BitConverter.ToInt32(Encoding.Default.GetBytes(vmruntime_0.f2C().nKP.Name), 0);
			new DynCipherService().GenerateCipherPair(vmruntime_0.Descriptor.iqK(), out var statementBlock_, out var statementBlock_2);
			List<Instruction> list = new List<Instruction>();
			RlU rlU = new RlU(local_0, local_1, methodDef_0, list);
			rlU.method_1(statementBlock_2);
			rlU.Commit(methodDef_0.Body);
			DMCodeGen dMCodeGen = new DMCodeGen(typeof(void), new Tuple<string, Type>[2]
			{
				Tuple.Create("{BUFFER}", typeof(uint[])),
				Tuple.Create("{KEY}", typeof(uint[]))
			});
			dMCodeGen.method_1(statementBlock_);
			Q1p = vmruntime_0;
			s1r = dMCodeGen.Compile<Action<uint[], uint[]>>();
			return list;
		}

		public byte[] Encrypt(byte[] byte_0)
		{
			byte[] array = Q1p.CompressionService.LZMA_Compress(byte_0);
			uint num = (uint)(array.Length + 3) / 4u;
			num = (num + 15) & 0xFFFFFFF0u;
			uint[] array2 = new uint[num];
			Buffer.BlockCopy(array, 0, array2, 0, array.Length);
			Debug.Assert(num % 16 == 0);
			uint num2 = (uint)Seed;
			uint[] array3 = new uint[16];
			for (int i = 0; i < 16; i++)
			{
				num2 ^= num2 >> 13;
				num2 ^= num2 << 25;
				num2 = (array3[i] = num2 ^ (num2 >> 27));
			}
			byte[] array4 = new byte[array2.Length * 4];
			int j;
			for (j = 0; j < array2.Length; j += 16)
			{
				uint[] src = Encrypt(array2, j, array3);
				for (int k = 0; k < 16; k++)
				{
					array3[k] ^= array2[j + k];
				}
				Buffer.BlockCopy(src, 0, array4, j * 4, 64);
			}
			Debug.Assert(j == array2.Length);
			return array4;
		}

		public uint[] Encrypt(uint[] uint_0, int int_0, uint[] uint_1)
		{
			uint[] array = new uint[uint_1.Length];
			Buffer.BlockCopy(uint_0, int_0 * 4, array, 0, uint_1.Length * 4);
			s1r(array, uint_1);
			return array;
		}
	}
}
