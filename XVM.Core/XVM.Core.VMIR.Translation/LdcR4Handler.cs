using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class LdcR4Handler : GInterface0
	{
		public Code ILCode => Code.Ldc_R4;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			return IRConstant.FromR4((float)ilastexpression_0.Operand);
		}
	}
}
