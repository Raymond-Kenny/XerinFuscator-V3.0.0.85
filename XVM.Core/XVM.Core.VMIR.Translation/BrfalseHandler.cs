#define DEBUG
using System.Diagnostics;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;
using XVM.Core.CFG;

namespace XVM.Core.VMIR.Translation
{
	public class BrfalseHandler : GInterface0
	{
		public Code ILCode => Code.Brfalse;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 1);
			IIROperand iiroperand_ = irtranslator_0.Qqg(ilastexpression_0.Arguments[0]);
			TranslationHelpers.EmitCompareEq(irtranslator_0, ilastexpression_0.Arguments[0].Type.Value, iiroperand_, IRConstant.FromI4(0));
			IRVariable iRVariable = irtranslator_0.Context.AllocateVRegister(ASTType.I4);
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__GETF)
			{
				Operand1 = iRVariable,
				Operand2 = IRConstant.FromI4(1 << irtranslator_0.Arch.Flags.ZERO)
			});
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.JNZ)
			{
				Operand1 = new IRBlockTarget((IBasicBlock)ilastexpression_0.Operand),
				Operand2 = iRVariable
			});
			return null;
		}
	}
}
