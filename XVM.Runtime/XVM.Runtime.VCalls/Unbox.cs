using System;
using XVM.Runtime.XVM.Runtime.Execution;
using XVM.Runtime.XVM.Runtime.Execution.Internal;

namespace XVM.Runtime.XVM.Runtime.VCalls
{
	internal class Unbox : IVCall
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.VCALL_UNBOX;

		public unsafe void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u--];
			VMSlot vMSlot2 = ctx.Stack[u];
			bool flag = (vMSlot.U4 & 0x80000000u) != 0;
			Type type = (Type)ctx.Instance.Data.LookupReference(vMSlot.U4 & 0x7FFFFFFF);
			if (flag)
			{
				TypedReference typedRef = default(TypedReference);
				TypedReferenceHelpers.UnboxTypedRef(vMSlot2.O, &typedRef);
				TypedRef typedRef2 = new TypedRef(typedRef);
				vMSlot2 = VMSlot.FromObject(vMSlot2.O, type);
				ctx.Stack[u] = vMSlot2;
			}
			else
			{
				if ((object)type == typeof(object) && vMSlot2.O != null)
				{
					type = vMSlot2.O.GetType();
				}
				vMSlot2 = VMSlot.FromObject(vMSlot2.O, type);
				ctx.Stack[u] = vMSlot2;
			}
			ctx.Stack.SetTopPosition(u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			state = ExecutionState.Next;
		}
	}
}
