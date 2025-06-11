using XVM.Core.AST.IL;
using XVM.Core.AST.IR;
using XVM.Core.VMIR;

namespace XVM.Core.VMIL.Translation
{
	public class LeaveHandler : GInterface1
	{
		public IROpCode IRCode => IROpCode.LEAVE;

		public void Translate(IRInstruction irinstruction_0, ILTranslator iltranslator_0)
		{
			iltranslator_0.PushOperand(irinstruction_0.Operand1);
			iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.LEAVE)
			{
				Annotation = irinstruction_0.Annotation
			});
		}
	}
}
