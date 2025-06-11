using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class CmpR32 : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_CMP_R32;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u - 1];
			VMSlot vMSlot2 = ctx.Stack[u];
			u -= 2;
			ctx.Stack.SetTopPosition(u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			float num = vMSlot.R4 - vMSlot2.R4;
			byte b = (byte)(ctx.Data.Constants.FL_ZERO | ctx.Data.Constants.FL_SIGN | ctx.Data.Constants.FL_OVERFLOW | ctx.Data.Constants.FL_CARRY);
			byte b2 = (byte)(ctx.Registers[ctx.Data.Constants.REG_FL].U1 & ~b);
			if (num == 0f)
			{
				b2 |= ctx.Data.Constants.FL_ZERO;
			}
			else if (num < 0f)
			{
				b2 |= ctx.Data.Constants.FL_SIGN;
			}
			ctx.Registers[ctx.Data.Constants.REG_FL].U1 = b2;
			state = ExecutionState.Next;
		}
	}
}
