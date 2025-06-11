#define DEBUG
using System.Diagnostics;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class InitobjHandler : GInterface0
	{
		public Code ILCode => Code.Initobj;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 1);
			IIROperand iiroperand_ = irtranslator_0.Qqg(ilastexpression_0.Arguments[0]);
			int id = (int)irtranslator_0.VM.Data.GetId((ITypeDefOrRef)ilastexpression_0.Operand);
			int iNITOBJ = irtranslator_0.VM.Runtime.VMCall.INITOBJ;
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.PUSH, iiroperand_));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.VCALL, IRConstant.FromI4(iNITOBJ), IRConstant.FromI4(id)));
			return null;
		}
	}
}
