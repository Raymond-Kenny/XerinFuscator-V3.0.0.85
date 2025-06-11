using System;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.VCalls
{
	internal class Ckoverflow : IVCall
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.VCALL_CKOVERFLOW;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			if (ctx.Stack[u--].U4 != 0)
			{
				throw new OverflowException();
			}
			ctx.Stack.SetTopPosition(u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			state = ExecutionState.Next;
		}
	}
}
