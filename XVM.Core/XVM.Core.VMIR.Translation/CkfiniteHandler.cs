#define DEBUG
using System.Diagnostics;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class CkfiniteHandler : GInterface0
	{
		public Code ILCode => Code.Ckfinite;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 1);
			IIROperand iIROperand = irtranslator_0.Qqg(ilastexpression_0.Arguments[0]);
			int cKFINITE = irtranslator_0.VM.Runtime.VMCall.CKFINITE;
			if (iIROperand.Type == ASTType.R4)
			{
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__SETF)
				{
					Operand1 = IRConstant.FromI4(1 << irtranslator_0.Arch.Flags.UNSIGNED)
				});
			}
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.VCALL, IRConstant.FromI4(cKFINITE), iIROperand));
			return iIROperand;
		}
	}
}
