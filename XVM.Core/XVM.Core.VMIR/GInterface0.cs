using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR
{
	public interface GInterface0
	{
		Code ILCode { get; }

		IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0);
	}
}
