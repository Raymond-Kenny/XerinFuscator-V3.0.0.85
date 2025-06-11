#define DEBUG
using System.Diagnostics;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class StsfldHandler : GInterface0
	{
		public Code ILCode => Code.Stsfld;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 1);
			IIROperand iiroperand_ = irtranslator_0.Qqg(ilastexpression_0.Arguments[0]);
			int id = (int)irtranslator_0.VM.Data.GetId((IField)ilastexpression_0.Operand);
			int sTFLD = irtranslator_0.VM.Runtime.VMCall.STFLD;
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.PUSH, IRConstant.Null()));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.PUSH, iiroperand_));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.VCALL, IRConstant.FromI4(sTFLD), IRConstant.FromI4(id)));
			return null;
		}
	}
}
