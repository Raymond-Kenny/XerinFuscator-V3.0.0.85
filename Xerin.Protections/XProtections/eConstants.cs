using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Compression;
using XCore.Context;
using XCore.Decompression;
using XCore.Generator;
using XCore.Injection;
using XCore.Mutation;
using XCore.Protections;
using XCore.Utils;
using XProtections.Strings;
using XRuntime;

namespace XProtections
{
	public class eConstants : Protection
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class TRz
		{
			public static readonly TRz Gmw;

			public static Func<Instruction, bool> PmR;

			public static Func<Instruction, bool> Wmm;

			public static Func<TypeDef, bool> YmL;

			public static Func<FieldDef, bool> Fm7;

			public static Func<MethodDef, bool> Xmh;

			static TRz()
			{
				Gmw = new TRz();
			}

			internal bool Amc(Instruction instruction_0)
			{
				return instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("decompress");
			}

			internal bool Dm2(Instruction instruction_0)
			{
				return instruction_0.OpCode == OpCodes.Ldstr;
			}

			internal bool em8(TypeDef typeDef_0)
			{
				return typeDef_0.HasMethods && !typeDef_0.IsGlobalModuleType && typeDef_0.Namespace != "Costura";
			}

			internal bool Mmx(FieldDef fieldDef_0)
			{
				return fieldDef_0.IsStatic && fieldDef_0.FieldType.FullName == "System.String" && fieldDef_0.IsLiteral && fieldDef_0.HasConstant;
			}

			internal bool vm9(MethodDef methodDef_0)
			{
				return methodDef_0.HasBody && methodDef_0.Body.HasInstructions;
			}
		}

		private static Random X8W;

		private static readonly List<string> i8H;

		private static string D8d;

		private static MethodDef j83;

		private static MethodDef i8M;

		private static MethodDef K8e;

		private static FieldDef l8C;

		private static FieldDef g8J;

		private static newInjector k8z;

		public static string[] ToIgnore;

		public override string name => "Strings Encoding";

		public override int number => 7;

		private static byte[] S8t(List<string> list_0)
		{
			string s = string.Join(Environment.NewLine, list_0);
			return Encoding.UTF8.GetBytes(s);
		}

		private static void v8f(ModuleDefMD moduleDefMD_0)
		{
			k8z = new newInjector(moduleDefMD_0, typeof(StringsRuntime));
			j83 = k8z.FindMember("Read") as MethodDef;
			i8M = k8z.FindMember("Extract") as MethodDef;
			foreach (Instruction item in i8M.Body.Instructions.Where((Instruction instruction_0) => instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("decompress")))
			{
				item.Operand = XCore.Decompression.QuickLZ.QLZDecompression;
			}
			foreach (Instruction item2 in i8M.Body.Instructions.Where((Instruction instruction_0) => instruction_0.OpCode == OpCodes.Ldstr))
			{
				if (item2.Operand.ToString() == "CallMeInx")
				{
					item2.Operand = D8d;
				}
			}
			K8e = k8z.FindMember("Call") as MethodDef;
			l8C = k8z.FindMember("stringsList") as FieldDef;
			g8J = k8z.FindMember("field") as FieldDef;
			new XMutationHelper("XMutationClass");
			MethodDef[] array = new MethodDef[3] { j83, i8M, K8e };
			k8z.injectMethods(string.Empty, GGeneration.GenerateGuidStartingWithLetter(), moduleDefMD_0, array);
			new replaceObfuscator(moduleDefMD_0, replaceObfuscator.Mode.Simple).ExecuteFor(K8e);
			new replaceObfuscator(moduleDefMD_0, replaceObfuscator.Mode.Simple).ExecuteFor(i8M);
		}

		public static string Encrypt(string string_0, string string_1)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(string_0);
			byte[] bytes2 = Encoding.UTF8.GetBytes(string_1);
			for (int i = 0; i < bytes.Length; i++)
			{
				bytes[i] ^= bytes2[i % bytes2.Length];
			}
			return Convert.ToBase64String(bytes);
		}

		public override void Execute(XContext xcontext_0)
		{
			b64String.Execute(xcontext_0);
			reverseString.Execute(xcontext_0);
			xorString.Execute(xcontext_0);
			reverseString.Execute(xcontext_0);
			D8d = Utils.MethodsRenamig();
			v8f(xcontext_0.Module);
			HashSet<string> hashSet = new HashSet<string>();
			foreach (TypeDef item3 in from typeDef_0 in xcontext_0.Module.GetTypes()
				where typeDef_0.HasMethods && !typeDef_0.IsGlobalModuleType && typeDef_0.Namespace != "Costura"
				select typeDef_0)
			{
				string string_ = GGeneration.GenerateGuidStartingWithLetter();
				foreach (FieldDef item4 in item3.Fields.Where((FieldDef fieldDef_0) => fieldDef_0.IsStatic && fieldDef_0.FieldType.FullName == "System.String" && fieldDef_0.IsLiteral && fieldDef_0.HasConstant))
				{
					item4.Constant.Value = Encrypt(item4.Constant.Value.ToString(), string_);
				}
				foreach (MethodDef item5 in item3.Methods.Where((MethodDef methodDef_0) => methodDef_0.HasBody && methodDef_0.Body.HasInstructions))
				{
					if (item5.MethodHasL2FAttribute() || ToIgnore.Contains(item5.Name.ToString()))
					{
						continue;
					}
					DnlibUtils.Simplify(item5);
					IList<Instruction> instructions = item5.Body.Instructions;
					for (int num = 0; num < instructions.Count; num++)
					{
						if (instructions[num].OpCode == OpCodes.Ldstr)
						{
							string text = instructions[num].Operand.ToString();
							if (!hashSet.Contains(text))
							{
								string text2 = GGeneration.GenerateGuidStartingWithLetter();
								string item = Encrypt(text, text2);
								hashSet.Add(item);
								i8H.Add(item);
								item5.Body.Instructions[num].OpCode = OpCodes.Ldsfld;
								item5.Body.Instructions[num].Operand = l8C;
								item5.Body.Instructions.Insert(num + 1, new Instruction(OpCodes.Ldsfld, g8J));
								item5.Body.Instructions.Insert(num + 2, new Instruction(OpCodes.Ldstr, text2.e_e()));
								item5.Body.Instructions.Insert(num + 3, new Instruction(OpCodes.Ldc_I4, i8H.LastIndexOf(item)));
								IMethod operand = xcontext_0.Module.Import(typeof(DateTime).GetMethod("FromBinary", new Type[1] { typeof(long) }));
								item5.Body.Instructions.Insert(num + 4, new Instruction(OpCodes.Ldc_I4, X8W.Next()));
								item5.Body.Instructions.Insert(num + 5, new Instruction(OpCodes.Conv_I8));
								item5.Body.Instructions.Insert(num + 6, new Instruction(OpCodes.Call, operand));
								item5.Body.Instructions.Insert(num + 7, new Instruction(OpCodes.Ldc_I4_1));
								item5.Body.Instructions.Insert(num + 8, new Instruction(OpCodes.Call, K8e));
								num += 8;
							}
						}
					}
					DnlibUtils.Optimize(item5);
				}
			}
			byte[] data = XCore.Compression.QuickLZ.CompressBytes(S8t(i8H));
			EmbeddedResource item2 = new EmbeddedResource(D8d, data);
			xcontext_0.Module.Resources.Add(item2);
			MethodDef methodDef = xcontext_0.Module.GlobalType.FindOrCreateStaticConstructor();
			methodDef.Body.Instructions.Insert(methodDef.Body.Instructions.Count - 1, OpCodes.Ldstr.ToInstruction(D8d));
			methodDef.Body.Instructions.Insert(methodDef.Body.Instructions.Count - 1, OpCodes.Call.ToInstruction(i8M));
			i8H.Clear();
			k8z.Rename();
		}

		static eConstants()
		{
			X8W = new Random();
			i8H = new List<string>();
			D8d = "";
			j83 = null;
			i8M = null;
			K8e = null;
			l8C = null;
			g8J = null;
			k8z = null;
			ToIgnore = new string[3] { "Call", "Extract", "DecompressBytes" };
		}
	}
}
