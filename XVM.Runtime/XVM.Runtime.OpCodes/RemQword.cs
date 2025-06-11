using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class RemQword : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_REM_QWORD;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u - 1];
			VMSlot vMSlot2 = ctx.Stack[u];
			u--;
			ctx.Stack.SetTopPosition(u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			byte fl = ctx.Registers[ctx.Data.Constants.REG_FL].U1;
			VMSlot value = default(VMSlot);
			if ((fl & ctx.Data.Constants.FL_UNSIGNED) != 0)
			{
				value.U8 = vMSlot.U8 % vMSlot2.U8;
			}
			else
			{
				value.U8 = (ulong)((long)vMSlot.U8 % (long)vMSlot2.U8);
			}
			ctx.Stack[u] = value;
			byte mask = (byte)(ctx.Data.Constants.FL_ZERO | ctx.Data.Constants.FL_SIGN | ctx.Data.Constants.FL_UNSIGNED);
			Utils.UpdateFL(ctx, vMSlot.U8, vMSlot2.U8, value.U8, value.U8, ref fl, mask);
			ctx.Registers[ctx.Data.Constants.REG_FL].U1 = fl;
			state = ExecutionState.Next;
		}
	}
}
