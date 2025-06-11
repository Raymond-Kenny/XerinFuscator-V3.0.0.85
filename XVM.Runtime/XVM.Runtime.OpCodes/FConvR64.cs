using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class FConvR64 : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_FCONV_R64;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot value = ctx.Stack[u];
			byte u2 = ctx.Registers[ctx.Data.Constants.REG_FL].U1;
			if ((u2 & ctx.Data.Constants.FL_UNSIGNED) != 0)
			{
				value.R8 = value.U8;
			}
			else
			{
				value.R8 = (long)value.U8;
			}
			ctx.Registers[ctx.Data.Constants.REG_FL].U1 = (byte)(u2 & ~ctx.Data.Constants.FL_UNSIGNED);
			ctx.Stack[u] = value;
			state = ExecutionState.Next;
		}
	}
}
