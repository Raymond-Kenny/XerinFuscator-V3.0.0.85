using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class AddDword : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_ADD_DWORD;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u - 1];
			VMSlot vMSlot2 = ctx.Stack[u];
			u--;
			ctx.Stack.SetTopPosition(u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			VMSlot value = default(VMSlot);
			if (vMSlot.O is IReference)
			{
				value.O = ((IReference)vMSlot.O).Add(vMSlot2.U4);
			}
			else if (vMSlot2.O is IReference)
			{
				value.O = ((IReference)vMSlot2.O).Add(vMSlot.U4);
			}
			else
			{
				value.U4 = vMSlot2.U4 + vMSlot.U4;
			}
			ctx.Stack[u] = value;
			byte mask = (byte)(ctx.Data.Constants.FL_ZERO | ctx.Data.Constants.FL_SIGN | ctx.Data.Constants.FL_OVERFLOW | ctx.Data.Constants.FL_CARRY);
			byte fl = ctx.Registers[ctx.Data.Constants.REG_FL].U1;
			Utils.UpdateFL(ctx, vMSlot.U4, vMSlot2.U4, value.U4, value.U4, ref fl, mask);
			ctx.Registers[ctx.Data.Constants.REG_FL].U1 = fl;
			state = ExecutionState.Next;
		}
	}
}
