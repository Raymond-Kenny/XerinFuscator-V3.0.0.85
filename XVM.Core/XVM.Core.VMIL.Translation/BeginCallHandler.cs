using XVM.Core.AST.IL;
using XVM.Core.AST.IR;
using XVM.Core.VMIR;

namespace XVM.Core.VMIL.Translation
{
	public class BeginCallHandler : GInterface1
	{
		public IROpCode IRCode => IROpCode.__BEGINCALL;

		public void Translate(IRInstruction irinstruction_0, ILTranslator iltranslator_0)
		{
			iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.__BEGINCALL)
			{
				Annotation = irinstruction_0.Annotation
			});
		}
	}
}
