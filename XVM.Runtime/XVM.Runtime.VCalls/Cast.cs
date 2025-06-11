using System;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.VCalls
{
	internal class Cast : IVCall
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.VCALL_CAST;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u--];
			VMSlot value = ctx.Stack[u];
			bool flag = (vMSlot.U4 & 0x80000000u) != 0;
			Type type = (Type)ctx.Instance.Data.LookupReference(vMSlot.U4 & 0x7FFFFFFF);
			if (Type.GetTypeCode(type) == TypeCode.String && value.O == null)
			{
				value.O = ctx.Instance.Data.LookupString(value.U4);
			}
			else if (value.O == null)
			{
				value.O = null;
			}
			else if (!type.IsInstanceOfType(value.O))
			{
				value.O = null;
				if (flag)
				{
					throw new InvalidCastException();
				}
			}
			ctx.Stack[u] = value;
			ctx.Stack.SetTopPosition(u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			state = ExecutionState.Next;
		}
	}
}
