using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class Call : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_CALL;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u];
			ctx.Stack[u] = ctx.Registers[ctx.Data.Constants.REG_IP];
			ctx.Registers[ctx.Data.Constants.REG_IP].U8 = vMSlot.U8;
			state = ExecutionState.Next;
		}
	}
}
