using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class CmpQword : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_CMP_QWORD;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u - 1];
			VMSlot vMSlot2 = ctx.Stack[u];
			u -= 2;
			ctx.Stack.SetTopPosition(u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			ulong num = vMSlot.U8 - vMSlot2.U8;
			byte mask = (byte)(ctx.Data.Constants.FL_ZERO | ctx.Data.Constants.FL_SIGN | ctx.Data.Constants.FL_OVERFLOW | ctx.Data.Constants.FL_CARRY);
			byte fl = ctx.Registers[ctx.Data.Constants.REG_FL].U1;
			Utils.UpdateFL(ctx, num, vMSlot2.U8, vMSlot.U8, num, ref fl, mask);
			ctx.Registers[ctx.Data.Constants.REG_FL].U1 = fl;
			state = ExecutionState.Next;
		}
	}
}
