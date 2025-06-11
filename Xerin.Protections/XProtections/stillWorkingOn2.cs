using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Context;
using XCore.Generator;
using XCore.Utils;

namespace XProtections
{
	public static class stillWorkingOn2
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class gm5
		{
			public static readonly gm5 NmU;

			public static Func<TypeDef, bool> Bmk;

			public static Func<MethodDef, bool> Tma;

			static gm5()
			{
				NmU = new gm5();
			}

			internal bool UmN(TypeDef typeDef_0)
			{
				return typeDef_0.HasMethods && typeDef_0.Name != "Costura";
			}

			internal bool PmP(MethodDef methodDef_0)
			{
				return methodDef_0.HasBody;
			}
		}

		private static string jxc(Tuple<string, int> tuple_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int item = tuple_0.Item2;
			string item2 = tuple_0.Item1;
			foreach (char c in item2)
			{
				stringBuilder.Append((char)(c ^ item));
			}
			return stringBuilder.ToString();
		}

		public static void EncodeFor(XContext xcontext_0, MethodDef[] methodDef_0)
		{
			RandomGenerator randomGenerator = new RandomGenerator(GGeneration.GenerateGuidStartingWithLetter(), GGeneration.GenerateGuidStartingWithLetter());
			foreach (TypeDef item in from typeDef_0 in xcontext_0.Module.GetTypes()
				where typeDef_0.HasMethods && typeDef_0.Name != "Costura"
				select typeDef_0)
			{
				foreach (MethodDef item2 in item.Methods.Where((MethodDef methodDef2) => methodDef2.HasBody))
				{
					foreach (MethodDef methodDef in methodDef_0)
					{
						if (item2 != methodDef)
						{
							continue;
						}
						DnlibUtils.Simplify(methodDef);
						IList<Instruction> instructions = item2.Body.Instructions;
						for (int num2 = 0; num2 < instructions.Count; num2++)
						{
							if (item2.Body.Instructions[num2].OpCode == OpCodes.Ldstr)
							{
								int num3 = randomGenerator.NextInt32();
								string operand = jxc(new Tuple<string, int>(instructions[num2].Operand.ToString(), num3));
								item2.Body.Instructions[num2].OpCode = OpCodes.Ldstr;
								item2.Body.Instructions[num2].Operand = operand;
								item2.Body.Instructions.Insert(num2 + 1, new Instruction(OpCodes.Ldc_I4, num3));
								item2.Body.Instructions.Insert(num2 + 2, new Instruction(OpCodes.Call, SelfString.XorCipher));
								num2 += 2;
							}
						}
						DnlibUtils.Optimize(methodDef);
					}
				}
			}
		}
	}
}
