using System;
using XVM.Runtime.XVM.Runtime.Execution;
using XVM.Runtime.XVM.Runtime.Execution.Internal;

namespace XVM.Runtime.XVM.Runtime.VCalls
{
	internal class Sizeof : IVCall
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.VCALL_SIZEOF;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			uint u2 = ctx.Registers[ctx.Data.Constants.REG_BP].U4;
			Type type = (Type)ctx.Instance.Data.LookupReference(ctx.Stack[u].U4);
			ctx.Stack[u] = new VMSlot
			{
				U4 = (uint)SizeOfHelper.SizeOf(type)
			};
			state = ExecutionState.Next;
		}
	}
}
