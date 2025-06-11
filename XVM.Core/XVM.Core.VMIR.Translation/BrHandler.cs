using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;
using XVM.Core.CFG;

namespace XVM.Core.VMIR.Translation
{
	public class BrHandler : GInterface0
	{
		public Code ILCode => Code.Br;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.JMP)
			{
				Operand1 = new IRBlockTarget((IBasicBlock)ilastexpression_0.Operand)
			});
			return null;
		}
	}
}
