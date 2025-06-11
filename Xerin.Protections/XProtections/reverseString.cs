using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Context;
using XCore.Utils;

namespace XProtections
{
	public class reverseString
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class AmD
		{
			public static readonly AmD amu;

			public static Func<TypeDef, bool> kmV;

			public static Func<MethodDef, bool> wm4;

			static AmD()
			{
				amu = new AmD();
			}

			internal bool bmv(TypeDef typeDef_0)
			{
				return typeDef_0.HasMethods && !typeDef_0.IsGlobalModuleType && typeDef_0.Namespace != "Costura";
			}

			internal bool PmO(MethodDef methodDef_0)
			{
				return methodDef_0.HasBody && methodDef_0.Body.HasInstructions;
			}
		}

		public static string ReverseString(string string_0)
		{
			if (!string.IsNullOrEmpty(string_0))
			{
				TextElementEnumerator textElementEnumerator = StringInfo.GetTextElementEnumerator(string_0);
				List<string> list = new List<string>();
				while (textElementEnumerator.MoveNext())
				{
					list.Add(textElementEnumerator.GetTextElement());
				}
				list.Reverse();
				return string.Concat(list);
			}
			return string_0;
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
							string operand = ReverseString(item2.Body.Instructions[num].Operand.ToString());
							item2.Body.Instructions[num].Operand = operand;
						}
					}
					DnlibUtils.Optimize(item2);
				}
			}
		}
	}
}
