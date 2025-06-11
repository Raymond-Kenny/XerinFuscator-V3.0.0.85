using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class BreakHandler : GInterface0
	{
		public Code ILCode => Code.Break;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			int bREAK = irtranslator_0.VM.Runtime.VMCall.BREAK;
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.VCALL, IRConstant.FromI4(bREAK)));
			return null;
		}
	}
}
