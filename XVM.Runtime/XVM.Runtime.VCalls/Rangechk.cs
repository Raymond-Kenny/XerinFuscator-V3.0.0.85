using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.VCalls
{
	internal class Rangechk : IVCall
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.VCALL_RANGECHK;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot value = ctx.Stack[u--];
			VMSlot vMSlot = ctx.Stack[u--];
			VMSlot vMSlot2 = ctx.Stack[u];
			value.U8 = (long)value.U8 > (long)vMSlot.U8 || (long)value.U8 < (long)vMSlot2.U8 ? 1u : 0u;
			ctx.Stack[u] = value;
			ctx.Stack.SetTopPosition(u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			state = ExecutionState.Next;
		}
	}
}
