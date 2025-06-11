using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class LdcI4Handler : GInterface0
	{
		public Code ILCode => Code.Ldc_I4;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			return IRConstant.FromI4((int)ilastexpression_0.Operand);
		}
	}
}
