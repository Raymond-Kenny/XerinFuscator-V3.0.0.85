using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XF
{
	internal static class Cx7
	{
		public static void Txh<Wx5>(this IList<Wx5> ilist_0, IList<Wx5> ilist_1)
		{
			for (int i = 0; i < ilist_1.Count; i++)
			{
				ilist_0.Add(ilist_1[i]);
			}
		}

		public static void KxN(this Instruction instruction_0, IList<Instruction> ilist_0, MethodDef methodDef_0)
		{
			if (methodDef_0.HasBody)
			{
				instruction_0.OpCode = ilist_0[0].OpCode;
				instruction_0.Operand = ilist_0[0].Operand;
				int num = methodDef_0.Body.Instructions.IndexOf(instruction_0) + 1;
				for (int i = 1; i < ilist_0.Count; i++)
				{
					methodDef_0.Body.Instructions.Insert(num++, ilist_0[i]);
				}
			}
		}
	}
}
