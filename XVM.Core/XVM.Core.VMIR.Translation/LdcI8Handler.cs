using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class LdcI8Handler : GInterface0
	{
		public Code ILCode => Code.Ldc_I8;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			return IRConstant.FromI8((long)ilastexpression_0.Operand);
		}
	}
}
