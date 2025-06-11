using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class FConvR32R64 : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_FCONV_R32_R64;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot value = ctx.Stack[u];
			value.R8 = value.R4;
			ctx.Stack[u] = value;
			state = ExecutionState.Next;
		}
	}
}
