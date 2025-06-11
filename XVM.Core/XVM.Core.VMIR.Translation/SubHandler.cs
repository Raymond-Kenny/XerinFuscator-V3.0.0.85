#define DEBUG
using System.Diagnostics;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class SubHandler : GInterface0
	{
		public Code ILCode => Code.Sub;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 2);
			IRVariable iRVariable = irtranslator_0.Context.AllocateVRegister(ilastexpression_0.Type.Value);
			if (ilastexpression_0.Type.HasValue && (ilastexpression_0.Type.Value == ASTType.R4 || ilastexpression_0.Type.Value == ASTType.R8))
			{
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.MOV)
				{
					Operand1 = iRVariable,
					Operand2 = irtranslator_0.Qqg(ilastexpression_0.Arguments[0])
				});
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.SUB)
				{
					Operand1 = iRVariable,
					Operand2 = irtranslator_0.Qqg(ilastexpression_0.Arguments[1])
				});
			}
			else
			{
				IRVariable iRVariable2 = irtranslator_0.Context.AllocateVRegister(ilastexpression_0.Type.Value);
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.MOV)
				{
					Operand1 = iRVariable,
					Operand2 = irtranslator_0.Qqg(ilastexpression_0.Arguments[0])
				});
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.MOV)
				{
					Operand1 = iRVariable2,
					Operand2 = irtranslator_0.Qqg(ilastexpression_0.Arguments[1])
				});
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__NOT)
				{
					Operand1 = iRVariable2
				});
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.ADD)
				{
					Operand1 = iRVariable,
					Operand2 = iRVariable2
				});
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.ADD)
				{
					Operand1 = iRVariable,
					Operand2 = IRConstant.FromI4(1)
				});
			}
			return iRVariable;
		}
	}
}
