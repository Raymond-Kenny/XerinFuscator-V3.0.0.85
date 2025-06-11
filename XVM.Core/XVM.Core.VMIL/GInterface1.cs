using XVM.Core.AST.IR;
using XVM.Core.VMIR;

namespace XVM.Core.VMIL
{
	public interface GInterface1
	{
		IROpCode IRCode { get; }

		void Translate(IRInstruction irinstruction_0, ILTranslator iltranslator_0);
	}
}
