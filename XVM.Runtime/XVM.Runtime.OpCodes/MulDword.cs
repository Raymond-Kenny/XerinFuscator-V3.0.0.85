using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class MulDword : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_MUL_DWORD;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u - 1];
			VMSlot vMSlot2 = ctx.Stack[u];
			u--;
			ctx.Stack.SetTopPosition(u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			byte u2 = ctx.Registers[ctx.Data.Constants.REG_FL].U1;
			VMSlot value = default(VMSlot);
			ulong num = vMSlot.U4 * vMSlot2.U4;
			value.U4 = (uint)num;
			ctx.Stack[u] = value;
			byte mask = (byte)(ctx.Data.Constants.FL_ZERO | ctx.Data.Constants.FL_SIGN | ctx.Data.Constants.FL_UNSIGNED);
			byte b = (byte)(ctx.Data.Constants.FL_CARRY | ctx.Data.Constants.FL_OVERFLOW);
			byte b2 = 0;
			if ((u2 & ctx.Data.Constants.FL_UNSIGNED) != 0)
			{
				if ((num & 0xFFFFFFFFu) != 0)
				{
					b2 = b;
				}
			}
			else
			{
				num = (ulong)(int)(vMSlot.U4 * vMSlot2.U4);
				if (num >> 63 != value.U4 >> 31)
				{
					b2 = b;
				}
			}
			u2 = (byte)(u2 & ~b | b2);
			Utils.UpdateFL(ctx, vMSlot.U4, vMSlot2.U4, value.U4, value.U4, ref u2, mask);
			ctx.Registers[ctx.Data.Constants.REG_FL].U1 = u2;
			state = ExecutionState.Next;
		}
	}
}
