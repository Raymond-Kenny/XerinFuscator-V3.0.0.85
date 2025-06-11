using System;
using System.Runtime.Serialization;
using XVM.Runtime.XVM.Runtime.Execution;
using XVM.Runtime.XVM.Runtime.Execution.Internal;

namespace XVM.Runtime.XVM.Runtime.VCalls
{
	internal class Initobj : IVCall
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.VCALL_INITOBJ;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u--];
			VMSlot vMSlot2 = ctx.Stack[u--];
			Type type = (Type)ctx.Instance.Data.LookupReference(vMSlot.U4);
			if (vMSlot2.O is IReference)
			{
				IReference reference = (IReference)vMSlot2.O;
				VMSlot slot = default(VMSlot);
				if (type.IsValueType)
				{
					object vt = null;
					if ((object)Nullable.GetUnderlyingType(type) == null)
					{
						vt = FormatterServices.GetUninitializedObject(type);
					}
					slot.O = ValueTypeBox.Box(vt, type);
				}
				else
				{
					slot.O = null;
				}
				reference.SetValue(ctx, slot, PointerType.OBJECT);
				ctx.Stack.SetTopPosition(u);
				ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
				state = ExecutionState.Next;
				return;
			}
			throw new NotSupportedException();
		}
	}
}
