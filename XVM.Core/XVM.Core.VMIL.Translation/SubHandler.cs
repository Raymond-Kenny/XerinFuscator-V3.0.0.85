using System;
using XVM.Core.AST;
using XVM.Core.AST.IL;
using XVM.Core.AST.IR;
using XVM.Core.VMIR;

namespace XVM.Core.VMIL.Translation
{
	public class SubHandler : GInterface1
	{
		public IROpCode IRCode => IROpCode.SUB;

		public void Translate(IRInstruction irinstruction_0, ILTranslator iltranslator_0)
		{
			iltranslator_0.PushOperand(irinstruction_0.Operand1);
			iltranslator_0.PushOperand(irinstruction_0.Operand2);
			switch (TypeInference.InferBinaryOp(irinstruction_0.Operand1.Type, irinstruction_0.Operand2.Type))
			{
			default:
				throw new NotSupportedException();
			case ASTType.R8:
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.SUB_R64));
				break;
			case ASTType.R4:
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.SUB_R32));
				break;
			}
			iltranslator_0.PopOperand(irinstruction_0.Operand1);
		}
	}
}
