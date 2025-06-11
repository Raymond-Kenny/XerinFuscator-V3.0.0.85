#define DEBUG
using System;
using System.Diagnostics;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class ConvI8Handler : GInterface0
	{
		public Code ILCode => Code.Conv_I8;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 1);
			IIROperand iIROperand = irtranslator_0.Qqg(ilastexpression_0.Arguments[0]);
			ASTType type = iIROperand.Type;
			if (type == ASTType.I8)
			{
				return iIROperand;
			}
			IRVariable iRVariable = irtranslator_0.Context.AllocateVRegister(ASTType.I8);
			switch (type)
			{
			case ASTType.I4:
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.SX, iRVariable, iIROperand));
				break;
			case ASTType.R4:
			case ASTType.R8:
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.ICONV, iRVariable, iIROperand));
				break;
			default:
				throw new NotSupportedException();
			case ASTType.Ptr:
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.MOV, iRVariable, iIROperand));
				break;
			}
			return iRVariable;
		}
	}
}
