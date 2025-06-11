using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class LindByte : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_LIND_BYTE;

		public unsafe void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u];
			VMSlot value;
			if (vMSlot.O is IReference)
			{
				value = ((IReference)vMSlot.O).GetValue(ctx, PointerType.BYTE);
			}
			else
			{
				byte* ptr = (byte*)vMSlot.U8;
				value = new VMSlot
				{
					U1 = *ptr
				};
			}
			ctx.Stack[u] = value;
			state = ExecutionState.Next;
		}
	}
}
