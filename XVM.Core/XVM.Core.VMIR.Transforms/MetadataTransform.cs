using System;
using dnlib.DotNet;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Transforms
{
	public class MetadataTransform : ITransform
	{
		public void Initialize(IRTransformer irtransformer_0)
		{
		}

		public void Transform(IRTransformer irtransformer_0)
		{
			irtransformer_0.SqF().VisitInstrs(GMH, irtransformer_0);
		}

		private void GMH(IRInstrList irinstrList_0, IRInstruction irinstruction_0, ref int int_0, IRTransformer irtransformer_0)
		{
			irinstruction_0.Operand1 = uMC(irinstruction_0.Operand1, irtransformer_0);
			irinstruction_0.Operand2 = uMC(irinstruction_0.Operand2, irtransformer_0);
		}

		private IIROperand uMC(IIROperand iiroperand_0, IRTransformer irtransformer_0)
		{
			if (iiroperand_0 is IRMetaTarget)
			{
				IRMetaTarget iRMetaTarget = (IRMetaTarget)iiroperand_0;
				if (!iRMetaTarget.LateResolve)
				{
					if (!(iRMetaTarget.MetadataItem is IMemberRef))
					{
						throw new NotSupportedException();
					}
					return IRConstant.FromI4((int)irtransformer_0.VM.Data.GetId((IMemberRef)iRMetaTarget.MetadataItem));
				}
			}
			return iiroperand_0;
		}
	}
}
