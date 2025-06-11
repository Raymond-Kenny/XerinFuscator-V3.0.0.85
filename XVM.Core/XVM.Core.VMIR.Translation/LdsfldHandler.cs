using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class LdsfldHandler : GInterface0
	{
		public Code ILCode => Code.Ldsfld;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			IRVariable iRVariable = irtranslator_0.Context.AllocateVRegister(ilastexpression_0.Type.Value);
			int id = (int)irtranslator_0.VM.Data.GetId((IField)ilastexpression_0.Operand);
			int lDFLD = irtranslator_0.VM.Runtime.VMCall.LDFLD;
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.PUSH, IRConstant.Null()));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.VCALL, IRConstant.FromI4(lDFLD), IRConstant.FromI4(id)));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.POP, iRVariable));
			return iRVariable;
		}
	}
}
