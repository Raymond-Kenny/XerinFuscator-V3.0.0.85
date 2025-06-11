using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.VCalls
{
	internal class Throw : IVCall
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.VCALL_THROW;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			uint u2 = ctx.Stack[u--].U4;
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			if (u2 == 1)
			{
				state = ExecutionState.Rethrow;
			}
			else
			{
				state = ExecutionState.Throw;
			}
		}
	}
}
