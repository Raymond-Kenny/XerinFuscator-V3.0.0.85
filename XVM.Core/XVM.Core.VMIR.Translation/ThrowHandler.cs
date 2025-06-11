#define DEBUG
using System.Diagnostics;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class ThrowHandler : GInterface0
	{
		public Code ILCode => Code.Throw;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 1);
			int tHROW = irtranslator_0.VM.Runtime.VMCall.THROW;
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.PUSH, irtranslator_0.Qqg(ilastexpression_0.Arguments[0])));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.VCALL)
			{
				Operand1 = IRConstant.FromI4(tHROW),
				Operand2 = IRConstant.FromI4(0)
			});
			return null;
		}
	}
}
