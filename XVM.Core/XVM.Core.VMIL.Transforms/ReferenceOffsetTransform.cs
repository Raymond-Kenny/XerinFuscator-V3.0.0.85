using XVM.Core.AST.IL;

namespace XVM.Core.VMIL.Transforms
{
	public class ReferenceOffsetTransform : ITransform
	{
		public void Initialize(ILTransformer iltransformer_0)
		{
		}

		public void Transform(ILTransformer iltransformer_0)
		{
			iltransformer_0.VAI().VisitInstrs(YAT, iltransformer_0);
		}

		private void YAT(ILInstrList ilinstrList_0, ILInstruction ilinstruction_0, ref int int_0, ILTransformer iltransformer_0)
		{
			if (ilinstruction_0.OpCode == ILOpCode.PUSHI_DWORD && ilinstruction_0.Operand is IHasOffset)
			{
				ILInstruction iLInstruction = new ILInstruction(ILOpCode.PUSHR_QWORD, ILRegister.IP, ilinstruction_0);
				ilinstruction_0.OpCode = ILOpCode.PUSHI_DWORD;
				ilinstruction_0.Operand = new ILRelReference((IHasOffset)ilinstruction_0.Operand, iLInstruction);
				ilinstrList_0.Replace(int_0, new ILInstruction[3]
				{
					iLInstruction,
					ilinstruction_0,
					new ILInstruction(ILOpCode.ADD_QWORD, null, ilinstruction_0)
				});
			}
		}
	}
}
