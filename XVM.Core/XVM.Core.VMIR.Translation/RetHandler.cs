#define DEBUG
using System.Diagnostics;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;
using XVM.Core.VM;

namespace XVM.Core.VMIR.Translation
{
	public class RetHandler : GInterface0
	{
		public Code ILCode => Code.Ret;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			if (ilastexpression_0.Arguments.Length == 1)
			{
				IIROperand iIROperand = irtranslator_0.Qqg(ilastexpression_0.Arguments[0]);
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.MOV)
				{
					Operand1 = new IRRegister(VMRegisters.R0, iIROperand.Type),
					Operand2 = iIROperand
				});
			}
			else
			{
				Debug.Assert(ilastexpression_0.Arguments.Length == 0);
			}
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.RET));
			return null;
		}
	}
}
