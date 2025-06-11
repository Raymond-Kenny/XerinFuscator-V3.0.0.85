using System;
using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class Leave : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_LEAVE;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint num = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			ulong u = ctx.Stack[num--].U8;
			int index = ctx.EHStack.Count - 1;
			EHFrame eHFrame = ctx.EHStack[index];
			if (eHFrame.HandlerAddr != u)
			{
				throw new InvalidProgramException();
			}
			ctx.EHStack.RemoveAt(index);
			if (eHFrame.EHType == ctx.Data.Constants.EH_FINALLY)
			{
				ctx.Stack[++num] = ctx.Registers[ctx.Data.Constants.REG_IP];
				ctx.Registers[ctx.Data.Constants.REG_K1].U1 = 0;
				ctx.Registers[ctx.Data.Constants.REG_IP].U8 = eHFrame.HandlerAddr;
			}
			ctx.Stack.SetTopPosition(num);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = num;
			state = ExecutionState.Next;
		}
	}
}
