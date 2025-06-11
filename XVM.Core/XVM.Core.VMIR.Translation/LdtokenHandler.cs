using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class LdtokenHandler : GInterface0
	{
		public Code ILCode => Code.Ldtoken;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			IRVariable iRVariable = irtranslator_0.Context.AllocateVRegister(ilastexpression_0.Type.Value);
			int id = (int)irtranslator_0.VM.Data.GetId((IMemberRef)ilastexpression_0.Operand);
			int tOKEN = irtranslator_0.VM.Runtime.VMCall.TOKEN;
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.VCALL, IRConstant.FromI4(tOKEN), IRConstant.FromI4(id)));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.POP, iRVariable));
			return iRVariable;
		}
	}
}
