#define DEBUG
using System;
using System.Diagnostics;
using XVM.Core.AST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Transforms
{
	public class ConstantTypePromotionTransform : ITransform
	{
		public void Initialize(IRTransformer irtransformer_0)
		{
		}

		public void Transform(IRTransformer irtransformer_0)
		{
			irtransformer_0.SqF().VisitInstrs(Xqz, irtransformer_0);
		}

		private void Xqz(IRInstrList irinstrList_0, IRInstruction irinstruction_0, ref int int_0, IRTransformer irtransformer_0)
		{
			switch (irinstruction_0.OpCode)
			{
			case IROpCode.MOV:
			case IROpCode.NOR:
			case IROpCode.CMP:
			case IROpCode.ADD:
			case IROpCode.MUL:
			case IROpCode.DIV:
			case IROpCode.REM:
			case IROpCode.__AND:
			case IROpCode.__OR:
			case IROpCode.__XOR:
			case IROpCode.__GETF:
				Debug.Assert(irinstruction_0.Operand1 != null && irinstruction_0.Operand2 != null);
				if (irinstruction_0.Operand1 is IRConstant)
				{
					irinstruction_0.Operand1 = mM4((IRConstant)irinstruction_0.Operand1, irinstruction_0.Operand2.Type);
				}
				if (irinstruction_0.Operand2 is IRConstant)
				{
					irinstruction_0.Operand2 = mM4((IRConstant)irinstruction_0.Operand2, irinstruction_0.Operand1.Type);
				}
				break;
			}
		}

		private static IIROperand mM4(IIROperand iiroperand_0, ASTType asttype_0)
		{
			switch (asttype_0)
			{
			default:
				return iiroperand_0;
			case ASTType.I8:
				return VMe(iiroperand_0);
			case ASTType.R4:
				return qMu(iiroperand_0);
			case ASTType.R8:
				return MM9(iiroperand_0);
			}
		}

		private static IIROperand VMe(object object_0)
		{
			if (((ASTExpression)object_0).Type.Value == ASTType.I4)
			{
				((ASTExpression)object_0).Type = ASTType.I8;
				((ASTConstant)object_0).Value = (long)(int)((ASTConstant)object_0).Value;
			}
			else if (((ASTExpression)object_0).Type.Value != ASTType.I8)
			{
				throw new InvalidProgramException();
			}
			return (IIROperand)object_0;
		}

		private static IIROperand qMu(object object_0)
		{
			if (((ASTExpression)object_0).Type.Value == ASTType.I4)
			{
				((ASTExpression)object_0).Type = ASTType.R4;
				((ASTConstant)object_0).Value = (float)(int)((ASTConstant)object_0).Value;
			}
			else if (((ASTExpression)object_0).Type.Value != ASTType.R4)
			{
				throw new InvalidProgramException();
			}
			return (IIROperand)object_0;
		}

		private static IIROperand MM9(object object_0)
		{
			if (((ASTExpression)object_0).Type.Value == ASTType.I4)
			{
				((ASTExpression)object_0).Type = ASTType.R8;
				((ASTConstant)object_0).Value = (double)(int)((ASTConstant)object_0).Value;
			}
			else if (((ASTExpression)object_0).Type.Value == ASTType.I8)
			{
				((ASTExpression)object_0).Type = ASTType.R8;
				((ASTConstant)object_0).Value = (double)(long)((ASTConstant)object_0).Value;
			}
			else if (((ASTExpression)object_0).Type.Value == ASTType.R4)
			{
				((ASTExpression)object_0).Type = ASTType.R8;
				((ASTConstant)object_0).Value = (double)(float)((ASTConstant)object_0).Value;
			}
			else if (((ASTExpression)object_0).Type.Value != ASTType.R8)
			{
				throw new InvalidProgramException();
			}
			return (IIROperand)object_0;
		}
	}
}
