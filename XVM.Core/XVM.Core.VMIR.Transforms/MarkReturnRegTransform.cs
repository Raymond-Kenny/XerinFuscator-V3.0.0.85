using XVM.Core.AST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Transforms
{
	public class MarkReturnRegTransform : ITransform
	{
		public void Initialize(IRTransformer irtransformer_0)
		{
		}

		public void Transform(IRTransformer irtransformer_0)
		{
			irtransformer_0.SqF().VisitInstrs(gMk, irtransformer_0);
		}

		private void gMk(IRInstrList irinstrList_0, IRInstruction irinstruction_0, ref int int_0, IRTransformer irtransformer_0)
		{
			if (irinstruction_0.Annotation is InstrCallInfo instrCallInfo && instrCallInfo.ReturnValue != null)
			{
				if (irinstruction_0.Operand1 is IRRegister && ((IRRegister)irinstruction_0.Operand1).SourceVariable == instrCallInfo.ReturnValue)
				{
					instrCallInfo.ReturnRegister = (IRRegister)irinstruction_0.Operand1;
				}
				else if (irinstruction_0.Operand1 is IRPointer && ((IRPointer)irinstruction_0.Operand1).SourceVariable == instrCallInfo.ReturnValue)
				{
					instrCallInfo.ReturnSlot = (IRPointer)irinstruction_0.Operand1;
				}
			}
		}
	}
}
