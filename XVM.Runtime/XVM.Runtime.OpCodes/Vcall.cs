using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Data;
using XVM.Runtime.XVM.Runtime.Execution;
using XVM.Runtime.XVM.Runtime.VCalls;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class Vcall : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_VCALL;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u];
			ctx.Stack.SetTopPosition(--u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			IVCall iVCall = VCallMap.Lookup(vMSlot.U1);
			iVCall.Run(ctx, out state);
		}
	}
}
