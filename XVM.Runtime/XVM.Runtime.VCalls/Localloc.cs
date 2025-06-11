using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.VCalls
{
	internal class Localloc : IVCall
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.VCALL_LOCALLOC;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			uint u2 = ctx.Registers[ctx.Data.Constants.REG_BP].U4;
			uint u3 = ctx.Stack[u].U4;
			ctx.Stack[u] = new VMSlot
			{
				U8 = (ulong)(long)ctx.Stack.Localloc(u2, u3)
			};
			state = ExecutionState.Next;
		}
	}
}
