using System;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class CalliHandler : GInterface0
	{
		public Code ILCode => Code.Calli;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			throw new NotSupportedException();
		}
	}
}
