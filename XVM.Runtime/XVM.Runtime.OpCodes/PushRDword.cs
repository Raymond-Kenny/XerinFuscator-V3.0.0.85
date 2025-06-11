using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class PushRDword : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_PUSHR_DWORD;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			ctx.Stack.SetTopPosition(++u);
			byte b = ctx.ReadByte();
			VMSlot vMSlot = ctx.Registers[b];
			if (b == ctx.Data.Constants.REG_SP || b == ctx.Data.Constants.REG_BP)
			{
				ctx.Stack[u] = new VMSlot
				{
					O = new StackRef(vMSlot.U4)
				};
			}
			else
			{
				ctx.Stack[u] = new VMSlot
				{
					U4 = vMSlot.U4
				};
			}
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			state = ExecutionState.Next;
		}
	}
}
