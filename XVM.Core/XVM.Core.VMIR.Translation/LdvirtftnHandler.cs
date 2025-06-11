#define DEBUG
using System.Diagnostics;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class LdvirtftnHandler : GInterface0
	{
		public Code ILCode => Code.Ldvirtftn;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 1);
			IRVariable iRVariable = irtranslator_0.Context.AllocateVRegister(ilastexpression_0.Type.Value);
			IIROperand iiroperand_ = irtranslator_0.Qqg(ilastexpression_0.Arguments[0]);
			IMethod imemberRef_ = (IMethod)ilastexpression_0.Operand;
			int id = (int)irtranslator_0.VM.Data.GetId(imemberRef_);
			int lDFTN = irtranslator_0.VM.Runtime.VMCall.LDFTN;
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.PUSH, iiroperand_));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.VCALL, IRConstant.FromI4(lDFTN), IRConstant.FromI4(id)));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.POP, iRVariable));
			return iRVariable;
		}
	}
}
