using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Context;
using XCore.Utils;

namespace XProtections
{
	public class b64String
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class Sm0
		{
			public static readonly Sm0 cm6;

			public static Func<TypeDef, bool> omq;

			public static Func<MethodDef, bool> AmA;

			static Sm0()
			{
				cm6 = new Sm0();
			}

			internal bool RmQ(TypeDef typeDef_0)
			{
				return typeDef_0.HasMethods && !typeDef_0.IsGlobalModuleType && typeDef_0.Namespace != "Costura";
			}

			internal bool Qmr(MethodDef methodDef_0)
			{
				return methodDef_0.HasBody && methodDef_0.Body.HasInstructions;
			}
		}

		public static void Execute(XContext xcontext_0)
		{
			foreach (TypeDef item in from typeDef_0 in xcontext_0.Module.GetTypes()
				where typeDef_0.HasMethods && !typeDef_0.IsGlobalModuleType && typeDef_0.Namespace != "Costura"
				select typeDef_0)
			{
				foreach (MethodDef item2 in item.Methods.Where((MethodDef methodDef_0) => methodDef_0.HasBody && methodDef_0.Body.HasInstructions))
				{
					DnlibUtils.Simplify(item2);
					IList<Instruction> instructions = item2.Body.Instructions;
					for (int num = 0; num < instructions.Count; num++)
					{
						if (instructions[num].OpCode == OpCodes.Ldstr)
						{
							string text = item2.Body.Instructions[num].Operand.ToString();
							item2.Body.Instructions[num].Operand = text.e_e();
						}
					}
					DnlibUtils.Optimize(item2);
				}
			}
		}
	}
}
