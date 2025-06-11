using XVM.Core.AST.IL;
using XVM.Core.VM;

namespace XVM.Core.VMIL.Transforms
{
	public class SaveInfoTransform : ITransform
	{
		private VMMethodInfo aAa;

		public void Initialize(ILTransformer iltransformer_0)
		{
			aAa = iltransformer_0.VM.Data.LookupInfo(iltransformer_0.Method);
			aAa.RootScope = iltransformer_0.RootScope;
			iltransformer_0.VM.Data.SetInfo(iltransformer_0.Method, aAa);
		}

		public void Transform(ILTransformer iltransformer_0)
		{
			iltransformer_0.VAI().VisitInstrs(fAS, iltransformer_0);
		}

		private void fAS(ILInstrList ilinstrList_0, ILInstruction ilinstruction_0, ref int int_0, ILTransformer iltransformer_0)
		{
			if (ilinstruction_0.Operand is ILRegister)
			{
				VMRegisters register = ((ILRegister)ilinstruction_0.Operand).Register;
				if (register.IsGPR())
				{
					aAa.UsedRegister.Add(register);
				}
			}
		}
	}
}
