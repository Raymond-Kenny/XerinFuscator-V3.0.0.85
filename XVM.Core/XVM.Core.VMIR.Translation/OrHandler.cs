#define DEBUG
using System.Diagnostics;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class OrHandler : GInterface0
	{
		public Code ILCode => Code.Or;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 2);
			IRVariable iRVariable = irtranslator_0.Context.AllocateVRegister(ilastexpression_0.Type.Value);
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.MOV)
			{
				Operand1 = iRVariable,
				Operand2 = irtranslator_0.Qqg(ilastexpression_0.Arguments[0])
			});
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__OR)
			{
				Operand1 = iRVariable,
				Operand2 = irtranslator_0.Qqg(ilastexpression_0.Arguments[1])
			});
			return iRVariable;
		}
	}
}
