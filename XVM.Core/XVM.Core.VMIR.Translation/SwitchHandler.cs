#define DEBUG
using System.Diagnostics;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;
using XVM.Core.CFG;

namespace XVM.Core.VMIR.Translation
{
	public class SwitchHandler : GInterface0
	{
		public Code ILCode => Code.Switch;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 1);
			IIROperand operand = irtranslator_0.Qqg(ilastexpression_0.Arguments[0]);
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.SWT)
			{
				Operand1 = new IRJumpTable((IBasicBlock[])ilastexpression_0.Operand),
				Operand2 = operand
			});
			return null;
		}
	}
}
