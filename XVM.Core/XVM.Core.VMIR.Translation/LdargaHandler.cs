using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class LdargaHandler : GInterface0
	{
		public Code ILCode => Code.Ldarga;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			IRVariable iiroperand_ = irtranslator_0.Context.ResolveParameter((Parameter)ilastexpression_0.Operand);
			IRVariable iRVariable = irtranslator_0.Context.AllocateVRegister(ASTType.ByRef);
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__LEA, iRVariable, iiroperand_));
			return iRVariable;
		}
	}
}
