using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Utils;

namespace XProtections.Strings
{
	public class replaceObfuscator
	{
		public enum Mode
		{
			Simple,
			Homoglyph
		}

		[Serializable]
		[CompilerGenerated]
		private sealed class fms
		{
			public static readonly fms mmB;

			public static Func<TypeDef, bool> smp;

			static fms()
			{
				mmB = new fms();
			}

			internal bool pmY(TypeDef typeDef_0)
			{
				return typeDef_0.Methods.Count != 0;
			}
		}

		private ModuleDefMD Qxw;

		private readonly Mode LxR;

		private readonly Random txm;

		public replaceObfuscator(ModuleDefMD moduleDefMD_0, Mode mode_0 = Mode.Homoglyph)
		{
			Qxw = moduleDefMD_0;
			LxR = mode_0;
			txm = new Random(Guid.NewGuid().GetHashCode());
		}

		public void Execute()
		{
			Importer importer = new Importer(Qxw);
			foreach (TypeDef item in from typeDef_0 in Qxw.GetTypes()
				where typeDef_0.Methods.Count != 0
				select typeDef_0)
			{
				if (item.IsGlobalModuleType || item.Namespace == "Costura")
				{
					continue;
				}
				foreach (MethodDef method in item.Methods)
				{
					if (method.Body == null || !method.HasBody || !method.Body.HasInstructions)
					{
						continue;
					}
					DnlibUtils.Simplify(method);
					IList<Instruction> instructions = method.Body.Instructions;
					for (int num = 0; num < instructions.Count; num++)
					{
						if (instructions[num].OpCode != OpCodes.Ldstr || (string)instructions[num].Operand == string.Empty)
						{
							continue;
						}
						instructions[num].Operand = ax2((string)instructions[num].Operand);
						List<Instruction> list = new List<Instruction>();
						IMethod operand = importer.Import(typeof(string).GetMethod("Replace", new Type[2]
						{
							typeof(string),
							typeof(string)
						}) ?? throw new InvalidDataException());
						if (LxR != Mode.Homoglyph)
						{
							list.Add(new Instruction(OpCodes.Ldstr, "\u2029"));
							list.Add(new Instruction(OpCodes.Ldstr, ""));
							list.Add(new Instruction(OpCodes.Call, operand));
						}
						else
						{
							string[] source = new string[5] { "а", "е", "і", "о", "с" };
							string[] array = source.OrderBy((string string_0) => txm.Next()).ToArray();
							for (int num2 = 0; num2 < array.Length; num2++)
							{
								list.Add(new Instruction(OpCodes.Ldstr, array[num2]));
								list.Add(new Instruction(OpCodes.Ldstr, ""));
								if (num2 == 0)
								{
									list.Add(new Instruction(OpCodes.Call, operand));
								}
								else
								{
									list.Add(new Instruction(OpCodes.Callvirt, operand));
								}
							}
						}
						foreach (Instruction item2 in list)
						{
							instructions.Insert(num + 1, item2);
							num++;
						}
					}
					DnlibUtils.Optimize(method);
				}
			}
		}

		public void ExecuteFor(MethodDef methodDef_0)
		{
			Importer importer = new Importer(Qxw);
			TypeDef[] array = Qxw.GetTypes().ToArray();
			foreach (TypeDef typeDef in array)
			{
				if (typeDef.IsGlobalModuleType || typeDef.Namespace == "Costura")
				{
					continue;
				}
				MethodDef[] array2 = typeDef.Methods.ToArray();
				foreach (MethodDef methodDef in array2)
				{
					if (methodDef != methodDef_0 || methodDef_0.Body == null || !methodDef_0.HasBody || !methodDef_0.Body.HasInstructions)
					{
						continue;
					}
					DnlibUtils.Simplify(methodDef_0);
					IList<Instruction> instructions = methodDef_0.Body.Instructions;
					for (int k = 0; k < instructions.Count; k++)
					{
						if (instructions[k].OpCode != OpCodes.Ldstr || (string)instructions[k].Operand == string.Empty)
						{
							continue;
						}
						instructions[k].Operand = ax2((string)instructions[k].Operand);
						List<Instruction> list = new List<Instruction>();
						IMethod operand = importer.Import(typeof(string).GetMethod("Replace", new Type[2]
						{
							typeof(string),
							typeof(string)
						}) ?? throw new InvalidDataException());
						if (LxR != Mode.Homoglyph)
						{
							list.Add(new Instruction(OpCodes.Ldstr, "\u2029"));
							list.Add(new Instruction(OpCodes.Ldstr, ""));
							list.Add(new Instruction(OpCodes.Call, operand));
						}
						else
						{
							string[] source = new string[5] { "а", "е", "і", "о", "с" };
							string[] array3 = source.OrderBy((string string_0) => txm.Next()).ToArray();
							for (int num = 0; num < array3.Length; num++)
							{
								list.Add(new Instruction(OpCodes.Ldstr, array3[num]));
								list.Add(new Instruction(OpCodes.Ldstr, ""));
								if (num == 0)
								{
									list.Add(new Instruction(OpCodes.Call, operand));
								}
								else
								{
									list.Add(new Instruction(OpCodes.Callvirt, operand));
								}
							}
						}
						foreach (Instruction item in list)
						{
							instructions.Insert(k + 1, item);
							k++;
						}
					}
					DnlibUtils.Optimize(methodDef_0);
				}
			}
		}

		private string ax2(string string_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in string_0)
			{
				if (txm.Next(0, 1) == 0)
				{
					stringBuilder.Append((LxR == Mode.Homoglyph) ? new string(Lx8(c), 1) : new string('\u2029', 1));
					stringBuilder.Append(c);
				}
				else
				{
					stringBuilder.Append(c);
					stringBuilder.Append((LxR == Mode.Homoglyph) ? new string(Lx8(c), 1) : new string('\u2029', 1));
				}
			}
			return stringBuilder.ToString();
		}

		private char Lx8(char char_0)
		{
			char[] array = new char[5] { 'а', 'е', 'і', 'о', 'с' };
			switch (char_0)
			{
			case 'e':
				return array[1];
			case 'a':
				return array[0];
			default:
				return array[txm.Next(array.Length)];
			case 'o':
				return array[3];
			case 'i':
				return array[2];
			}
		}

		[CompilerGenerated]
		private int Axx(string string_0)
		{
			return txm.Next();
		}

		[CompilerGenerated]
		private int fx9(string string_0)
		{
			return txm.Next();
		}
	}
}
