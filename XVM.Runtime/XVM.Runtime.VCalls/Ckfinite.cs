using System;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.VCalls
{
	internal class Ckfinite : IVCall
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.VCALL_CKFINITE;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u--];
			byte u2 = ctx.Registers[ctx.Data.Constants.REG_FL].U1;
			if ((u2 & ctx.Data.Constants.FL_UNSIGNED) != 0)
			{
				float r = vMSlot.R4;
				if (float.IsNaN(r) || float.IsInfinity(r))
				{
					throw new ArithmeticException();
				}
			}
			else
			{
				double r2 = vMSlot.R8;
				if (double.IsNaN(r2) || double.IsInfinity(r2))
				{
					throw new ArithmeticException();
				}
			}
			ctx.Stack.SetTopPosition(u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			state = ExecutionState.Next;
		}
	}
}
