using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class LdftnHandler : GInterface0
	{
		public Code ILCode => Code.Ldftn;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			IRVariable iRVariable = irtranslator_0.Context.AllocateVRegister(ilastexpression_0.Type.Value);
			int lDFTN = irtranslator_0.VM.Runtime.VMCall.LDFTN;
			int id = (int)irtranslator_0.VM.Data.GetId((IMethod)ilastexpression_0.Operand);
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.PUSH, IRConstant.FromI4(0)));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.VCALL, IRConstant.FromI4(lDFTN), IRConstant.FromI4(id)));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.POP, iRVariable));
			return iRVariable;
		}
	}
}
