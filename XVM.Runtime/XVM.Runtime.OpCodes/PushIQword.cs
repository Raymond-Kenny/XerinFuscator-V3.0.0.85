using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class PushIQword : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_PUSHI_QWORD;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			ctx.Stack.SetTopPosition(++u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			ulong num = ctx.ReadByte();
			num |= (ulong)ctx.ReadByte() << 8;
			num |= (ulong)ctx.ReadByte() << 16;
			num |= (ulong)ctx.ReadByte() << 24;
			num |= (ulong)ctx.ReadByte() << 32;
			num |= (ulong)ctx.ReadByte() << 40;
			num |= (ulong)ctx.ReadByte() << 48;
			num |= (ulong)ctx.ReadByte() << 56;
			ctx.Stack[u] = new VMSlot
			{
				U8 = num
			};
			state = ExecutionState.Next;
		}
	}
}
