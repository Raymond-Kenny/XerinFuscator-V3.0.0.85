using System;
using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class LindPtr : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_LIND_PTR;

		public unsafe void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u];
			VMSlot value;
			if (vMSlot.O is IReference)
			{
				value = ((IReference)vMSlot.O).GetValue(ctx, IntPtr.Size == 8 ? PointerType.QWORD : PointerType.DWORD);
			}
			else if (IntPtr.Size == 8)
			{
				ulong* ptr = (ulong*)vMSlot.U8;
				value = new VMSlot
				{
					U8 = *ptr
				};
			}
			else
			{
				uint* ptr2 = (uint*)vMSlot.U8;
				value = new VMSlot
				{
					U4 = *ptr2
				};
			}
			ctx.Stack[u] = value;
			state = ExecutionState.Next;
		}
	}
}
