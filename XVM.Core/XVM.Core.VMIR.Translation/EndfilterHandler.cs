#define DEBUG
using System.Diagnostics;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;
using XVM.Core.CFG;

namespace XVM.Core.VMIR.Translation
{
	public class EndfilterHandler : GInterface0
	{
		public Code ILCode => Code.Endfilter;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 1);
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__EHRET, irtranslator_0.Qqg(ilastexpression_0.Arguments[0])));
			irtranslator_0.gqp().Flags |= BlockFlags.ExitEHReturn;
			return null;
		}
	}
}
