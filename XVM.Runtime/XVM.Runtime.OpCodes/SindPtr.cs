using System;
using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class SindPtr : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_SIND_PTR;

		public unsafe void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u--];
			VMSlot slot = ctx.Stack[u--];
			ctx.Stack.SetTopPosition(u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			if (vMSlot.O is IReference)
			{
				((IReference)vMSlot.O).SetValue(ctx, slot, IntPtr.Size == 8 ? PointerType.QWORD : PointerType.DWORD);
			}
			else if (IntPtr.Size == 8)
			{
				ulong* ptr = (ulong*)vMSlot.U8;
				*ptr = slot.U8;
			}
			else
			{
				uint* ptr2 = (uint*)vMSlot.U8;
				*ptr2 = slot.U4;
			}
			state = ExecutionState.Next;
		}
	}
}
