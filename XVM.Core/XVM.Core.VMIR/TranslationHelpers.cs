#define DEBUG
using System.Diagnostics;
using XVM.Core.AST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR
{
	public static class TranslationHelpers
	{
		public static void EmitCompareEq(IRTranslator irtranslator_0, ASTType asttype_0, IIROperand iiroperand_0, IIROperand iiroperand_1)
		{
			if (asttype_0 == ASTType.O || asttype_0 == ASTType.ByRef || asttype_0 == ASTType.R4 || asttype_0 == ASTType.R8)
			{
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.CMP, iiroperand_0, iiroperand_1));
				return;
			}
			Debug.Assert(asttype_0 == ASTType.I4 || asttype_0 == ASTType.I8 || asttype_0 == ASTType.Ptr);
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.CMP, iiroperand_0, iiroperand_1));
		}
	}
}
