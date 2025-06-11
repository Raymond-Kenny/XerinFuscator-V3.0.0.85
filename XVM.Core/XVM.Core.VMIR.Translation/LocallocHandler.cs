#define DEBUG
using System.Diagnostics;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class LocallocHandler : GInterface0
	{
		public Code ILCode => Code.Localloc;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 1);
			IIROperand iiroperand_ = irtranslator_0.Qqg(ilastexpression_0.Arguments[0]);
			IRVariable iRVariable = irtranslator_0.Context.AllocateVRegister(ilastexpression_0.Type.Value);
			int lOCALLOC = irtranslator_0.VM.Runtime.VMCall.LOCALLOC;
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.VCALL, IRConstant.FromI4(lOCALLOC), iiroperand_));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.POP, iRVariable));
			return iRVariable;
		}
	}
}
