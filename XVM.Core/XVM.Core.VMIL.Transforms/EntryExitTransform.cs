using XVM.Core.AST.IL;

namespace XVM.Core.VMIL.Transforms
{
	public class EntryExitTransform : ITransform
	{
		public void Initialize(ILTransformer iltransformer_0)
		{
		}

		public void Transform(ILTransformer iltransformer_0)
		{
			iltransformer_0.VAI().VisitInstrs(uAo, iltransformer_0);
		}

		private void uAo(ILInstrList ilinstrList_0, ILInstruction ilinstruction_0, ref int int_0, ILTransformer iltransformer_0)
		{
			if (ilinstruction_0.OpCode != ILOpCode.__ENTRY)
			{
				if (ilinstruction_0.OpCode == ILOpCode.__EXIT)
				{
					ilinstrList_0[int_0] = new ILInstruction(ILOpCode.RET, null, ilinstruction_0);
				}
			}
			else
			{
				ilinstrList_0.RemoveAt(int_0);
				int_0--;
			}
		}
	}
}
