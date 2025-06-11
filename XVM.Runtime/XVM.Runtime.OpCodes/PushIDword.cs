using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class PushIDword : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_PUSHI_DWORD;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			ctx.Stack.SetTopPosition(++u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			ulong num = ctx.ReadByte();
			num |= (ulong)ctx.ReadByte() << 8;
			num |= (ulong)ctx.ReadByte() << 16;
			num |= (ulong)ctx.ReadByte() << 24;
			ulong num2 = (num & 0x80000000u) != 0L ? 18446744069414584320uL : 0;
			ctx.Stack[u] = new VMSlot
			{
				U8 = num2 | num
			};
			state = ExecutionState.Next;
		}
	}
}
