using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class LdstrHandler : GInterface0
	{
		public Code ILCode => Code.Ldstr;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			return IRConstant.FromString((string)ilastexpression_0.Operand);
		}
	}
}
