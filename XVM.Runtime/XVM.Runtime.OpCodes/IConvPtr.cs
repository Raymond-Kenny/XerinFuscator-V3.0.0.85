using System;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class IConvPtr : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_ICONV_PTR;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot value = ctx.Stack[u];
			byte b = (byte)(ctx.Registers[ctx.Data.Constants.REG_FL].U1 & ~ctx.Data.Constants.FL_OVERFLOW);
			if (IntPtr.Size != 8 && value.U8 >> 32 != 0)
			{
				b |= ctx.Data.Constants.FL_OVERFLOW;
			}
			ctx.Registers[ctx.Data.Constants.REG_FL].U1 = b;
			ctx.Stack[u] = value;
			state = ExecutionState.Next;
		}
	}
}
