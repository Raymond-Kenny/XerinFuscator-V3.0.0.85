using System;
using System.Reflection;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.VCalls
{
	internal class Ldfld : IVCall
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.VCALL_LDFLD;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u--];
			VMSlot vMSlot2 = ctx.Stack[u];
			bool flag = (vMSlot.U4 & 0x80000000u) != 0;
			FieldInfo fieldInfo = (FieldInfo)ctx.Instance.Data.LookupReference(vMSlot.U4 & 0x7FFFFFFF);
			if (!fieldInfo.IsStatic && vMSlot2.O == null)
			{
				throw new NullReferenceException();
			}
			if (flag)
			{
				ctx.Stack[u] = new VMSlot
				{
					O = new FieldRef(vMSlot2.O, fieldInfo)
				};
			}
			else
			{
				object obj = !fieldInfo.DeclaringType.IsValueType || !(vMSlot2.O is IReference) ? vMSlot2.ToObject(fieldInfo.DeclaringType) : ((IReference)vMSlot2.O).GetValue(ctx, PointerType.OBJECT).ToObject(fieldInfo.DeclaringType);
				ctx.Stack[u] = VMSlot.FromObject(fieldInfo.GetValue(obj), fieldInfo.FieldType);
			}
			ctx.Stack.SetTopPosition(u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			state = ExecutionState.Next;
		}
	}
}
