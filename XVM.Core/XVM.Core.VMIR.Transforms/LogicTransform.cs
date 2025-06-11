using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Transforms
{
	public class LogicTransform : ITransform
	{
		public void Initialize(IRTransformer irtransformer_0)
		{
		}

		public void Transform(IRTransformer irtransformer_0)
		{
			irtransformer_0.SqF().VisitInstrs(gML, irtransformer_0);
		}

		private void gML(IRInstrList irinstrList_0, IRInstruction irinstruction_0, ref int int_0, IRTransformer irtransformer_0)
		{
			if (irinstruction_0.OpCode != IROpCode.__NOT)
			{
				if (irinstruction_0.OpCode == IROpCode.__AND)
				{
					IRVariable iRVariable = irtransformer_0.Context.AllocateVRegister(irinstruction_0.Operand2.Type);
					irinstrList_0.Replace(int_0, new IRInstruction[4]
					{
						new IRInstruction(IROpCode.MOV, iRVariable, irinstruction_0.Operand2, irinstruction_0),
						new IRInstruction(IROpCode.NOR, irinstruction_0.Operand1, irinstruction_0.Operand1, irinstruction_0),
						new IRInstruction(IROpCode.NOR, iRVariable, iRVariable, irinstruction_0),
						new IRInstruction(IROpCode.NOR, irinstruction_0.Operand1, iRVariable, irinstruction_0)
					});
				}
				else if (irinstruction_0.OpCode == IROpCode.__OR)
				{
					irinstrList_0.Replace(int_0, new IRInstruction[2]
					{
						new IRInstruction(IROpCode.NOR, irinstruction_0.Operand1, irinstruction_0.Operand2, irinstruction_0),
						new IRInstruction(IROpCode.NOR, irinstruction_0.Operand1, irinstruction_0.Operand1, irinstruction_0)
					});
				}
				else if (irinstruction_0.OpCode == IROpCode.__XOR)
				{
					IRVariable iRVariable2 = irtransformer_0.Context.AllocateVRegister(irinstruction_0.Operand2.Type);
					IRVariable iRVariable3 = irtransformer_0.Context.AllocateVRegister(irinstruction_0.Operand2.Type);
					irinstrList_0.Replace(int_0, new IRInstruction[7]
					{
						new IRInstruction(IROpCode.MOV, iRVariable2, irinstruction_0.Operand1, irinstruction_0),
						new IRInstruction(IROpCode.NOR, iRVariable2, irinstruction_0.Operand2, irinstruction_0),
						new IRInstruction(IROpCode.MOV, iRVariable3, irinstruction_0.Operand2, irinstruction_0),
						new IRInstruction(IROpCode.NOR, irinstruction_0.Operand1, irinstruction_0.Operand1, irinstruction_0),
						new IRInstruction(IROpCode.NOR, iRVariable3, iRVariable3, irinstruction_0),
						new IRInstruction(IROpCode.NOR, irinstruction_0.Operand1, iRVariable3, irinstruction_0),
						new IRInstruction(IROpCode.NOR, irinstruction_0.Operand1, iRVariable2, irinstruction_0)
					});
				}
			}
			else
			{
				irinstrList_0.Replace(int_0, new IRInstruction[1]
				{
					new IRInstruction(IROpCode.NOR, irinstruction_0.Operand1, irinstruction_0.Operand1, irinstruction_0)
				});
			}
		}
	}
}
