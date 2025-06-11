using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class CmpDword : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_CMP_DWORD;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u - 1];
			VMSlot vMSlot2 = ctx.Stack[u];
			u -= 2;
			ctx.Stack.SetTopPosition(u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			uint num = vMSlot.U4 - vMSlot2.U4;
			byte mask = (byte)(ctx.Data.Constants.FL_ZERO | ctx.Data.Constants.FL_SIGN | ctx.Data.Constants.FL_OVERFLOW | ctx.Data.Constants.FL_CARRY);
			byte fl = ctx.Registers[ctx.Data.Constants.REG_FL].U1;
			Utils.UpdateFL(ctx, num, vMSlot2.U4, vMSlot.U4, num, ref fl, mask);
			ctx.Registers[ctx.Data.Constants.REG_FL].U1 = fl;
			state = ExecutionState.Next;
		}
	}
}
