using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class FConvR64R32 : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_FCONV_R64_R32;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot value = ctx.Stack[u];
			value.R4 = (float)value.R8;
			ctx.Stack[u] = value;
			state = ExecutionState.Next;
		}
	}
}
