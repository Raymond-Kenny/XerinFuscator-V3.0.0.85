using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class Pop : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_POP;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u];
			ctx.Stack.SetTopPosition(--u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			byte b = ctx.ReadByte();
			if ((b == ctx.Data.Constants.REG_SP || b == ctx.Data.Constants.REG_BP) && vMSlot.O is StackRef)
			{
				ctx.Registers[b] = new VMSlot
				{
					U4 = ((StackRef)vMSlot.O).StackPos
				};
			}
			else
			{
				ctx.Registers[b] = vMSlot;
			}
			state = ExecutionState.Next;
		}
	}
}
