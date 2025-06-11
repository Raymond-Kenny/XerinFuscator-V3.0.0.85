using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;
using XVM.Core.CFG;

namespace XVM.Core.VMIR.Translation
{
	public class LeaveHandler : GInterface0
	{
		public Code ILCode => Code.Leave;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__LEAVE)
			{
				Operand1 = new IRBlockTarget((IBasicBlock)ilastexpression_0.Operand)
			});
			irtranslator_0.gqp().Flags |= BlockFlags.flag_1;
			return null;
		}
	}
}
