#define DEBUG
using System;
using System.Diagnostics;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class ConvRUnHandler : GInterface0
	{
		public Code ILCode => Code.Conv_R_Un;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 1);
			IIROperand iIROperand = irtranslator_0.Qqg(ilastexpression_0.Arguments[0]);
			ASTType type = iIROperand.Type;
			IRVariable iRVariable = irtranslator_0.Context.AllocateVRegister(ASTType.R8);
			switch (type)
			{
			case ASTType.I4:
			{
				IRVariable iRVariable2 = irtranslator_0.Context.AllocateVRegister(ASTType.I8);
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.SX, iRVariable2, iIROperand));
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__SETF)
				{
					Operand1 = IRConstant.FromI4(1 << irtranslator_0.Arch.Flags.UNSIGNED)
				});
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.FCONV, iRVariable, iRVariable2));
				break;
			}
			default:
				throw new NotSupportedException();
			case ASTType.I8:
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__SETF)
				{
					Operand1 = IRConstant.FromI4(1 << irtranslator_0.Arch.Flags.UNSIGNED)
				});
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.FCONV, iRVariable, iIROperand));
				break;
			}
			return iRVariable;
		}
	}
}
