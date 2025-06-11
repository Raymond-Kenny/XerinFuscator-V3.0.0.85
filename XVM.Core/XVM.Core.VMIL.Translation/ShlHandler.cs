using System;
using XVM.Core.AST;
using XVM.Core.AST.IL;
using XVM.Core.AST.IR;
using XVM.Core.VMIR;

namespace XVM.Core.VMIL.Translation
{
	public class ShlHandler : GInterface1
	{
		public IROpCode IRCode => IROpCode.SHL;

		public void Translate(IRInstruction irinstruction_0, ILTranslator iltranslator_0)
		{
			iltranslator_0.PushOperand(irinstruction_0.Operand1);
			iltranslator_0.PushOperand(irinstruction_0.Operand2);
			switch (TypeInference.InferShiftOp(irinstruction_0.Operand1.Type, irinstruction_0.Operand2.Type))
			{
			default:
				throw new NotSupportedException();
			case ASTType.I8:
			case ASTType.Ptr:
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.SHL_QWORD));
				break;
			case ASTType.I4:
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.SHL_DWORD));
				break;
			}
			iltranslator_0.PopOperand(irinstruction_0.Operand1);
		}
	}
}
