using System;
using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class Try : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_TRY;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			byte u2 = ctx.Stack[u--].U1;
			EHFrame item = new EHFrame
			{
				EHType = u2
			};
			if (u2 == ctx.Data.Constants.EH_CATCH)
			{
				item.CatchType = (Type)ctx.Instance.Data.LookupReference(ctx.Stack[u--].U4);
			}
			else if (u2 == ctx.Data.Constants.EH_FILTER)
			{
				item.FilterAddr = ctx.Stack[u--].U8;
			}
			item.HandlerAddr = ctx.Stack[u--].U8;
			ctx.Stack.SetTopPosition(u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			item.BP = ctx.Registers[ctx.Data.Constants.REG_BP];
			item.SP = ctx.Registers[ctx.Data.Constants.REG_SP];
			ctx.EHStack.Add(item);
			state = ExecutionState.Next;
		}
	}
}
