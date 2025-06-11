using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class Jmp : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_JMP;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u];
			ctx.Stack.SetTopPosition(--u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			ctx.Registers[ctx.Data.Constants.REG_IP].U8 = vMSlot.U8;
			state = ExecutionState.Next;
		}
	}
}
