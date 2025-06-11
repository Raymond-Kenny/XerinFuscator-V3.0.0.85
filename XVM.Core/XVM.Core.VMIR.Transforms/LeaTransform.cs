#define DEBUG
using System.Diagnostics;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Transforms
{
	public class LeaTransform : ITransform
	{
		public void Initialize(IRTransformer irtransformer_0)
		{
		}

		public void Transform(IRTransformer irtransformer_0)
		{
			irtransformer_0.SqF().VisitInstrs(WMc, irtransformer_0);
		}

		private void WMc(IRInstrList irinstrList_0, IRInstruction irinstruction_0, ref int int_0, IRTransformer irtransformer_0)
		{
			if (irinstruction_0.OpCode == IROpCode.__LEA)
			{
				IRPointer iRPointer = (IRPointer)irinstruction_0.Operand2;
				IIROperand operand = irinstruction_0.Operand1;
				Debug.Assert(iRPointer.Register == IRRegister.BP);
				irinstrList_0.Replace(int_0, new IRInstruction[2]
				{
					new IRInstruction(IROpCode.MOV, operand, IRRegister.BP, irinstruction_0),
					new IRInstruction(IROpCode.ADD, operand, IRConstant.FromI4(iRPointer.Offset), irinstruction_0)
				});
			}
		}
	}
}
