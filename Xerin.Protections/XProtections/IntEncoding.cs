using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Context;
using XCore.Generator;
using XCore.Protections;
using XCore.Utils;

namespace XProtections
{
	public class IntEncoding : Protection
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class Kw1
		{
			public static readonly Kw1 owE;

			public static Func<TypeDef, bool> twf;

			public static Func<MethodDef, bool> QwW;

			static Kw1()
			{
				owE = new Kw1();
			}

			internal bool XwS(TypeDef typeDef_0)
			{
				return typeDef_0.IsClass;
			}

			internal bool Pwb(MethodDef methodDef_0)
			{
				return methodDef_0.HasBody;
			}
		}

		private Random v2S = new Random();

		private readonly List<int> o2b = new List<int>();

		public override int number => 2;

		public override string name => "Ints encoding";

		private static MethodDef y2G(ModuleDef moduleDef_0)
		{
			return new MethodDefUser(GGeneration.GenerateGuidStartingWithLetter(), MethodSig.CreateStatic(moduleDef_0.CorLibTypes.Int32, moduleDef_0.CorLibTypes.Int32), MethodImplAttributes.AggressiveInlining, MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig)
			{
				Body = new CilBody()
			};
		}

		internal int z2j()
		{
			int num;
			do
			{
				num = v2S.Next();
			}
			while (o2b.Contains(num));
			o2b.Add(num);
			return num;
		}

		private void z21(Dictionary<int, int> dictionary_0, MethodDef methodDef_0)
		{
			CilBody cilBody = (methodDef_0.Body = methodDef_0.Body ?? new CilBody());
			DnlibUtils.Simplify(methodDef_0);
			foreach (KeyValuePair<int, int> item in dictionary_0)
			{
				int key = item.Key;
				int value = item.Value;
				cilBody.Instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
				cilBody.Instructions.Add(Instruction.Create(OpCodes.Ldc_I4, value));
				cilBody.Instructions.Add(Instruction.Create(OpCodes.Ceq));
				Instruction instruction = Instruction.Create(OpCodes.Nop);
				cilBody.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction));
				int num = z2j();
				cilBody.Instructions.Add(Instruction.Create(OpCodes.Ldc_I4, num));
				cilBody.Instructions.Add(Instruction.Create(OpCodes.Ldc_I4, key ^ num));
				cilBody.Instructions.Add(Instruction.Create(OpCodes.Xor));
				cilBody.Instructions.Add(Instruction.Create(OpCodes.Ret));
				cilBody.Instructions.Add(instruction);
			}
			cilBody.Instructions.Add(Instruction.Create(OpCodes.Ldc_I4_0));
			cilBody.Instructions.Add(Instruction.Create(OpCodes.Ret));
			DnlibUtils.Optimize(methodDef_0);
		}

		public override void Execute(XContext xcontext_0)
		{
			foreach (TypeDef item in xcontext_0.Module.Types.Where((TypeDef typeDef_0) => typeDef_0.IsClass))
			{
				Dictionary<int, int> dictionary = new Dictionary<int, int>();
				MethodDef methodDef = y2G(xcontext_0.Module);
				methodDef.excludeMethod(xcontext_0.Module);
				foreach (MethodDef item2 in item.Methods.Where((MethodDef methodDef_0) => methodDef_0.HasBody))
				{
					DnlibUtils.Simplify(item2);
					if (item2.MethodHasL2FAttribute())
					{
						continue;
					}
					int num = item2.Body.Instructions.Count;
					for (int num2 = num - 1; num2 >= 0; num2--)
					{
						if (DnlibUtils.CanObfuscate(item2.Body.Instructions, num2) && item2.Body.Instructions[num2].OpCode == OpCodes.Ldc_I4)
						{
							int key = (int)item2.Body.Instructions[num2].Operand;
							if (!dictionary.TryGetValue(key, out var value))
							{
								value = z2j();
								dictionary.Add(key, value);
							}
							item2.Body.Instructions[num2].Operand = value;
							item2.Body.Instructions.Insert(num2 + 1, Instruction.Create(OpCodes.Call, methodDef));
							num++;
						}
					}
					DnlibUtils.Optimize(item2);
				}
				if (dictionary.Count != 0)
				{
					z21(dictionary, methodDef);
					MethodDef methodDef2 = xcontext_0.Module.GlobalType.FindOrCreateStaticConstructor();
					methodDef2.DeclaringType.Methods.Add(methodDef);
				}
			}
		}
	}
}
