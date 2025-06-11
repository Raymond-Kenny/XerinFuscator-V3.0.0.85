using XVM.Core.AST.IR;
using XVM.Core.VMIR;

namespace XVM.Core.VMIL.Translation
{
	public class PopHandler : GInterface1
	{
		public IROpCode IRCode => IROpCode.POP;

		public void Translate(IRInstruction irinstruction_0, ILTranslator iltranslator_0)
		{
			iltranslator_0.PopOperand(irinstruction_0.Operand1);
		}
	}
}
