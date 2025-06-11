#define DEBUG
using System;
using System.Diagnostics;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.VCalls
{
	internal class Box : IVCall
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.VCALL_BOX;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u--];
			VMSlot value = ctx.Stack[u];
			Type type = (Type)ctx.Instance.Data.LookupReference(vMSlot.U4);
			if (Type.GetTypeCode(type) == TypeCode.String && value.O == null)
			{
				value.O = ctx.Instance.Data.LookupString(value.U4);
			}
			else
			{
				Debug.Assert(type.IsValueType);
				value.O = value.ToObject(type);
			}
			ctx.Stack[u] = value;
			ctx.Stack.SetTopPosition(u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			state = ExecutionState.Next;
		}
	}
}
