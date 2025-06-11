#define DEBUG
using System.Diagnostics;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class CastclassHandler : GInterface0
	{
		public Code ILCode => Code.Castclass;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 1);
			IIROperand iiroperand_ = irtranslator_0.Qqg(ilastexpression_0.Arguments[0]);
			IRVariable iRVariable = irtranslator_0.Context.AllocateVRegister(ilastexpression_0.Type.Value);
			int int_ = (int)irtranslator_0.VM.Data.GetId((ITypeDefOrRef)ilastexpression_0.Operand) | int.MinValue;
			int cAST = irtranslator_0.VM.Runtime.VMCall.CAST;
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.PUSH, iiroperand_));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.VCALL, IRConstant.FromI4(cAST), IRConstant.FromI4(int_)));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.POP, iRVariable));
			return iRVariable;
		}
	}
}
