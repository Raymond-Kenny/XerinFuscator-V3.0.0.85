#define DEBUG
using System;
using System.Diagnostics;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class ConvI2Handler : GInterface0
	{
		public Code ILCode => Code.Conv_I2;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 1);
			IIROperand iIROperand = irtranslator_0.Qqg(ilastexpression_0.Arguments[0]);
			ASTType type = iIROperand.Type;
			IRVariable iRVariable = irtranslator_0.Context.AllocateVRegister(ASTType.I4);
			IRVariable iRVariable2 = irtranslator_0.Context.AllocateVRegister(ASTType.I4);
			iRVariable.RawType = irtranslator_0.Context.Method.Module.CorLibTypes.Int16;
			switch (type)
			{
			case ASTType.R4:
			case ASTType.R8:
			{
				IRVariable iRVariable3 = irtranslator_0.Context.AllocateVRegister(ASTType.I8);
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.ICONV, iRVariable3, iIROperand));
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.MOV, iRVariable, iRVariable3));
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.SX, iRVariable2, iRVariable));
				break;
			}
			default:
				throw new NotSupportedException();
			case ASTType.I4:
			case ASTType.I8:
			case ASTType.Ptr:
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.MOV, iRVariable, iIROperand));
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.SX, iRVariable2, iRVariable));
				break;
			}
			return iRVariable2;
		}
	}
}
