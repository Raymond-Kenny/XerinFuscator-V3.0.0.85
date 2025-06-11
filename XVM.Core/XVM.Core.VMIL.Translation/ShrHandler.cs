using System;
using XVM.Core.AST;
using XVM.Core.AST.IL;
using XVM.Core.AST.IR;
using XVM.Core.VMIR;

namespace XVM.Core.VMIL.Translation
{
	public class ShrHandler : GInterface1
	{
		public IROpCode IRCode => IROpCode.SHR;

		public void Translate(IRInstruction irinstruction_0, ILTranslator iltranslator_0)
		{
			iltranslator_0.PushOperand(irinstruction_0.Operand1);
			iltranslator_0.PushOperand(irinstruction_0.Operand2);
			switch (TypeInference.InferShiftOp(irinstruction_0.Operand1.Type, irinstruction_0.Operand2.Type))
			{
			case ASTType.I4:
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.SHR_DWORD));
				break;
			default:
				throw new NotSupportedException();
			case ASTType.I8:
			case ASTType.Ptr:
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.SHR_QWORD));
				break;
			}
			iltranslator_0.PopOperand(irinstruction_0.Operand1);
		}
	}
}
