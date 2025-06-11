using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class PushRObject : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_PUSHR_OBJECT;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			ctx.Stack.SetTopPosition(++u);
			byte b = ctx.ReadByte();
			VMSlot value = ctx.Registers[b];
			ctx.Stack[u] = value;
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			state = ExecutionState.Next;
		}
	}
}
