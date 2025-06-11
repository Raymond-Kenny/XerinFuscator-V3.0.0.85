using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class ShlQword : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_SHL_QWORD;

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
				U8 = vMSlot.U8 << (int)vMSlot2.U4
			};
			ctx.Stack[u] = value;
			byte mask = (byte)(ctx.Data.Constants.FL_ZERO | ctx.Data.Constants.FL_SIGN);
			byte fl = ctx.Registers[ctx.Data.Constants.REG_FL].U1;
			Utils.UpdateFL(ctx, vMSlot.U8, vMSlot2.U8, value.U8, value.U8, ref fl, mask);
			ctx.Registers[ctx.Data.Constants.REG_FL].U1 = fl;
			state = ExecutionState.Next;
		}
	}
}
