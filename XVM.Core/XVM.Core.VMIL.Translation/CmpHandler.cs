using XVM.Core.AST;
using XVM.Core.AST.IL;
using XVM.Core.AST.IR;
using XVM.Core.VMIR;

namespace XVM.Core.VMIL.Translation
{
	public class CmpHandler : GInterface1
	{
		public IROpCode IRCode => IROpCode.CMP;

		public void Translate(IRInstruction irinstruction_0, ILTranslator iltranslator_0)
		{
			iltranslator_0.PushOperand(irinstruction_0.Operand1);
			iltranslator_0.PushOperand(irinstruction_0.Operand2);
			if (irinstruction_0.Operand1.Type == ASTType.O || irinstruction_0.Operand2.Type == ASTType.O)
			{
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.CMP));
			}
			else if (irinstruction_0.Operand1.Type == ASTType.I8 || irinstruction_0.Operand2.Type == ASTType.I8 || irinstruction_0.Operand1.Type == ASTType.Ptr || irinstruction_0.Operand2.Type == ASTType.Ptr)
			{
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.CMP_QWORD));
			}
			else if (irinstruction_0.Operand1.Type == ASTType.R8 || irinstruction_0.Operand2.Type == ASTType.R8)
			{
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.CMP_R64));
			}
			else if (irinstruction_0.Operand1.Type == ASTType.R4 || irinstruction_0.Operand2.Type == ASTType.R4)
			{
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.CMP_R32));
			}
			else
			{
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.CMP_DWORD));
			}
		}
	}
}
