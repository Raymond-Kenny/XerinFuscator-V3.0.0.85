#define DEBUG
using System.Diagnostics;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class CgtUnHandler : GInterface0
	{
		public Code ILCode => Code.Cgt_Un;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 2);
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.CMP)
			{
				Operand1 = irtranslator_0.Qqg(ilastexpression_0.Arguments[0]),
				Operand2 = irtranslator_0.Qqg(ilastexpression_0.Arguments[1])
			});
			IRVariable iRVariable = irtranslator_0.Context.AllocateVRegister(ASTType.I4);
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__GETF)
			{
				Operand1 = iRVariable,
				Operand2 = IRConstant.FromI4((1 << irtranslator_0.Arch.Flags.CARRY) | (1 << irtranslator_0.Arch.Flags.ZERO))
			});
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__OR)
			{
				Operand1 = iRVariable,
				Operand2 = iRVariable
			});
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__GETF)
			{
				Operand1 = iRVariable,
				Operand2 = IRConstant.FromI4(1 << irtranslator_0.Arch.Flags.ZERO)
			});
			return iRVariable;
		}
	}
}
