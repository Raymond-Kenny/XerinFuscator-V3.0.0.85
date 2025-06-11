using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Transforms
{
	public class GetSetFlagTransform : ITransform
	{
		public void Initialize(IRTransformer irtransformer_0)
		{
		}

		public void Transform(IRTransformer irtransformer_0)
		{
			irtransformer_0.SqF().VisitInstrs(RM0, irtransformer_0);
		}

		private void RM0(IRInstrList irinstrList_0, IRInstruction irinstruction_0, ref int int_0, IRTransformer irtransformer_0)
		{
			if (irinstruction_0.OpCode == IROpCode.__GETF)
			{
				irinstrList_0.Replace(int_0, new IRInstruction[2]
				{
					new IRInstruction(IROpCode.MOV, irinstruction_0.Operand1, IRRegister.FL, irinstruction_0),
					new IRInstruction(IROpCode.__AND, irinstruction_0.Operand1, irinstruction_0.Operand2, irinstruction_0)
				});
			}
			else if (irinstruction_0.OpCode == IROpCode.__SETF)
			{
				irinstrList_0.Replace(int_0, new IRInstruction[1]
				{
					new IRInstruction(IROpCode.__OR, IRRegister.FL, irinstruction_0.Operand1, irinstruction_0)
				});
			}
		}
	}
}
