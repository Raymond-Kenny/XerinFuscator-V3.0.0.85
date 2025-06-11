#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XF;
using XVM.DynCipher;
using XVM.DynCipher.AST;
using XVM.DynCipher.Generation;

namespace XVM.Core.RTProtections.Constants
{
	public class DynamicMode
	{
		private class ylc : CILCodeGen
		{
			private readonly Local KlL;

			private readonly Local alH;

			public ylc(Local local_0, Local local_1, MethodDef methodDef_0, IList<Instruction> ilist_0)
				: base(methodDef_0, ilist_0)
			{
				KlL = local_0;
				alH = local_1;
			}

			protected override Local Var(Variable variable_0)
			{
				if (!(variable_0.Name == "{BUFFER}"))
				{
					if (variable_0.Name == "{KEY}")
					{
						return alH;
					}
					return base.Var(variable_0);
				}
				return KlL;
			}
		}

		[CompilerGenerated]
		private sealed class olC
		{
			public uint Olo;

			public uint lll;

			internal Instruction[] Yl5(Instruction[] instruction_0)
			{
				List<Instruction> list = new List<Instruction>();
				list.AddRange(instruction_0);
				list.Add(Instruction.Create(OpCodes.Ldc_I4, (int)MathsUtils.modInv(Olo)));
				list.Add(Instruction.Create(OpCodes.Mul));
				list.Add(Instruction.Create(OpCodes.Ldc_I4, (int)lll));
				list.Add(Instruction.Create(OpCodes.Xor));
				return list.ToArray();
			}
		}

		private Action<uint[], uint[]> F1S;

		public IEnumerable<Instruction> EmitDecrypt(MethodDef methodDef_0, CEContext cecontext_0, Local local_0, Local local_1)
		{
			cecontext_0.DynCipher.GenerateCipherPair(cecontext_0.Random, out var statementBlock_, out var statementBlock_2);
			List<Instruction> list = new List<Instruction>();
			ylc ylc = new ylc(local_0, local_1, methodDef_0, list);
			ylc.method_1(statementBlock_2);
			ylc.Commit(methodDef_0.Body);
			DMCodeGen dMCodeGen = new DMCodeGen(typeof(void), new Tuple<string, Type>[2]
			{
				Tuple.Create("{BUFFER}", typeof(uint[])),
				Tuple.Create("{KEY}", typeof(uint[]))
			});
			dMCodeGen.method_1(statementBlock_);
			F1S = dMCodeGen.Compile<Action<uint[], uint[]>>();
			return list;
		}

		public uint[] Encrypt(uint[] uint_0, int int_0, uint[] uint_1)
		{
			uint[] array = new uint[uint_1.Length];
			Buffer.BlockCopy(uint_0, int_0 * 4, array, 0, uint_1.Length * 4);
			F1S(array, uint_1);
			return array;
		}

		public object CreateDecoder(MethodDef methodDef_0, CEContext cecontext_0)
		{
			uint Olo = cecontext_0.Random.method_3() | 1;
			uint lll = cecontext_0.Random.method_3();
			XjJ.OOR(methodDef_0, delegate(Instruction[] instruction_0)
			{
				List<Instruction> list = new List<Instruction>();
				list.AddRange(instruction_0);
				list.Add(Instruction.Create(OpCodes.Ldc_I4, (int)MathsUtils.modInv(Olo)));
				list.Add(Instruction.Create(OpCodes.Mul));
				list.Add(Instruction.Create(OpCodes.Ldc_I4, (int)lll));
				list.Add(Instruction.Create(OpCodes.Xor));
				return list.ToArray();
			});
			return Tuple.Create(Olo, lll);
		}

		public uint Encode(object object_0, CEContext cecontext_0, uint uint_0)
		{
			Tuple<uint, uint> tuple = (Tuple<uint, uint>)object_0;
			uint num = (uint_0 ^ tuple.Item2) * tuple.Item1;
			Debug.Assert(((num * MathsUtils.modInv(tuple.Item1)) ^ tuple.Item2) == uint_0);
			return num;
		}
	}
}
