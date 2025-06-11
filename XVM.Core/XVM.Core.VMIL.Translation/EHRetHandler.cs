using XVM.Core.AST.IL;
using XVM.Core.AST.IR;
using XVM.Core.VMIR;

namespace XVM.Core.VMIL.Translation
{
	public class EHRetHandler : GInterface1
	{
		public IROpCode IRCode => IROpCode.__EHRET;

		public void Translate(IRInstruction irinstruction_0, ILTranslator iltranslator_0)
		{
			if (irinstruction_0.Operand1 != null)
			{
				iltranslator_0.PushOperand(irinstruction_0.Operand1);
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.POP, ILRegister.R0));
			}
			iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.RET));
		}
	}
}
