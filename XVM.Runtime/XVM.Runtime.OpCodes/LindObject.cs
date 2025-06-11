using System;
using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class LindObject : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_LIND_OBJECT;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u];
			if (vMSlot.O is IReference)
			{
				VMSlot value = ((IReference)vMSlot.O).GetValue(ctx, PointerType.OBJECT);
				ctx.Stack[u] = value;
				state = ExecutionState.Next;
				return;
			}
			throw new ExecutionEngineException();
		}
	}
}
