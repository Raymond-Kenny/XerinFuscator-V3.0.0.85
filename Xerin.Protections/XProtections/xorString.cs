using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Context;
using XCore.Utils;
using XRuntime;

namespace XProtections
{
	public class xorString
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class lml
		{
			public static readonly lml Tmi;

			public static Func<TypeDef, bool> ymZ;

			public static Func<MethodDef, bool> imF;

			static lml()
			{
				Tmi = new lml();
			}

			internal bool dmI(TypeDef typeDef_0)
			{
				return typeDef_0.HasMethods && !typeDef_0.IsGlobalModuleType && typeDef_0.Namespace != "Costura";
			}

			internal bool JmT(MethodDef methodDef_0)
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
							string szPlainText = item2.Body.Instructions[num].Operand.ToString();
							item2.Body.Instructions[num].Operand = szPlainText.Xor();
						}
					}
					DnlibUtils.Optimize(item2);
				}
			}
		}
	}
}
