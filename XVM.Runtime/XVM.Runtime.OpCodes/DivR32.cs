using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class DivR32 : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_DIV_R32;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u - 1];
			VMSlot vMSlot2 = ctx.Stack[u];
			u--;
			ctx.Stack.SetTopPosition(u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			VMSlot value = new VMSlot
			{
				R4 = vMSlot.R4 / vMSlot2.R4
			};
			ctx.Stack[u] = value;
			byte b = (byte)(ctx.Data.Constants.FL_ZERO | ctx.Data.Constants.FL_SIGN);
			byte b2 = (byte)(ctx.Registers[ctx.Data.Constants.REG_FL].U1 & ~b);
			if (value.R4 == 0f)
			{
				b2 |= ctx.Data.Constants.FL_ZERO;
			}
			else if (value.R4 < 0f)
			{
				b2 |= ctx.Data.Constants.FL_SIGN;
			}
			ctx.Registers[ctx.Data.Constants.REG_FL].U1 = b2;
			state = ExecutionState.Next;
		}
	}
}
