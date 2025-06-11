using System.Collections.Generic;
using XVM.Core.AST.IL;
using XVM.Core.VM;

namespace XVM.Core.VMIL.Transforms
{
	public class FixMethodRefTransform : IPostTransform
	{
		private HashSet<VMRegisters> SAZ;

		public void Initialize(ILPostTransformer ilpostTransformer_0)
		{
			SAZ = ilpostTransformer_0.Runtime.Descriptor.Data.LookupInfo(ilpostTransformer_0.Method).UsedRegister;
		}

		public void Transform(ILPostTransformer ilpostTransformer_0)
		{
			ilpostTransformer_0.fM6().VisitInstrs(HAl, ilpostTransformer_0);
		}

		private void HAl(ILInstrList ilinstrList_0, ILInstruction ilinstruction_0, ref int int_0, ILPostTransformer ilpostTransformer_0)
		{
			if (ilinstruction_0.Operand is ILRelReference iLRelReference && iLRelReference.Target is ILMethodTarget iLMethodTarget)
			{
				iLMethodTarget.Resolve(ilpostTransformer_0.Runtime);
			}
		}
	}
}
