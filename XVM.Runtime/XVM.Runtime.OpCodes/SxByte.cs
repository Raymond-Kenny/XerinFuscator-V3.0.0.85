using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class SxByte : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_SX_BYTE;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot value = ctx.Stack[u];
			if ((value.U1 & 0x80) != 0)
			{
				value.U4 = (uint)(value.U1 | -256);
			}
			ctx.Stack[u] = value;
			state = ExecutionState.Next;
		}
	}
}
