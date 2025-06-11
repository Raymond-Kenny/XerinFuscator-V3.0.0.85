#define DEBUG
using System.Diagnostics;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class PopHandler : GInterface0
	{
		public Code ILCode => Code.Pop;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 1);
			irtranslator_0.Qqg(ilastexpression_0.Arguments[0]);
			return null;
		}
	}
}
