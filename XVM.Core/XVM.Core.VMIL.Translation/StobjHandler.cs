using dnlib.DotNet;
using XVM.Core.AST;
using XVM.Core.AST.IL;
using XVM.Core.AST.IR;
using XVM.Core.VMIR;

namespace XVM.Core.VMIL.Translation
{
	public class StobjHandler : GInterface1
	{
		public IROpCode IRCode => IROpCode.__STOBJ;

		public void Translate(IRInstruction irinstruction_0, ILTranslator iltranslator_0)
		{
			iltranslator_0.PushOperand(irinstruction_0.Operand2);
			iltranslator_0.PushOperand(irinstruction_0.Operand1);
			TypeSig typeSig_ = ((PointerInfo)irinstruction_0.Annotation).PointerType.ToTypeSig();
			iltranslator_0.wAE().Add(new ILInstruction(TranslationHelpers.GetSIND(irinstruction_0.Operand2.Type, typeSig_)));
		}
	}
}
