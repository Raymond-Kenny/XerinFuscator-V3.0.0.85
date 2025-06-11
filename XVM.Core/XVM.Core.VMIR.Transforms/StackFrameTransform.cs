using XVM.Core.AST.IR;
using XVM.Core.VMIR.RegAlloc;

namespace XVM.Core.VMIR.Transforms
{
	public class StackFrameTransform : ITransform
	{
		private RegisterAllocator nMo;

		private bool zMl;

		private bool vMZ;

		public void Initialize(IRTransformer irtransformer_0)
		{
			nMo = (RegisterAllocator)irtransformer_0.yqS()[RegisterAllocationTransform.RegAllocatorKey];
		}

		public void Transform(IRTransformer irtransformer_0)
		{
			irtransformer_0.SqF().VisitInstrs(dM5, irtransformer_0);
		}

		private void dM5(IRInstrList irinstrList_0, IRInstruction irinstruction_0, ref int int_0, IRTransformer irtransformer_0)
		{
			if (irinstruction_0.OpCode == IROpCode.__ENTRY && !zMl)
			{
				irinstrList_0.Replace(int_0, new IRInstruction[4]
				{
					irinstruction_0,
					new IRInstruction(IROpCode.PUSH, IRRegister.BP),
					new IRInstruction(IROpCode.MOV, IRRegister.BP, IRRegister.SP),
					new IRInstruction(IROpCode.ADD, IRRegister.SP, IRConstant.FromI4(nMo.LocalSize))
				});
				zMl = true;
			}
			else if (irinstruction_0.OpCode == IROpCode.__EXIT && !vMZ)
			{
				irinstrList_0.Replace(int_0, new IRInstruction[3]
				{
					new IRInstruction(IROpCode.MOV, IRRegister.SP, IRRegister.BP),
					new IRInstruction(IROpCode.POP, IRRegister.BP),
					irinstruction_0
				});
				vMZ = true;
			}
		}
	}
}
