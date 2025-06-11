using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class NopHandler : GInterface0
	{
		public Code ILCode => Code.Nop;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.NOP));
			return null;
		}
	}
}
