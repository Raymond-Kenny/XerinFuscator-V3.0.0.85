using System;
using System.Reflection;
using XVM.Runtime.XVM.Runtime.Execution;
using XVM.Runtime.XVM.Runtime.Execution.Internal;

namespace XVM.Runtime.XVM.Runtime.VCalls
{
	internal class Stfld : IVCall
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.VCALL_STFLD;

		public unsafe void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u--];
			VMSlot vMSlot2 = ctx.Stack[u--];
			VMSlot vMSlot3 = ctx.Stack[u--];
			FieldInfo fieldInfo = (FieldInfo)ctx.Instance.Data.LookupReference(vMSlot.U4);
			if (!fieldInfo.IsStatic && vMSlot3.O == null)
			{
				throw new NullReferenceException();
			}
			object value = Type.GetTypeCode(fieldInfo.FieldType) != TypeCode.String || vMSlot2.O != null ? vMSlot2.ToObject(fieldInfo.FieldType) : ctx.Instance.Data.LookupString(vMSlot2.U4);
			if (fieldInfo.DeclaringType.IsValueType && vMSlot3.O is IReference)
			{
				TypedReference obj = default(TypedReference);
				((IReference)vMSlot3.O).ToTypedReference(ctx, &obj, fieldInfo.DeclaringType);
				TypedReferenceHelpers.CastTypedRef(&obj, fieldInfo.DeclaringType);
				fieldInfo.SetValueDirect(obj, value);
			}
			else
			{
				fieldInfo.SetValue(vMSlot3.ToObject(fieldInfo.DeclaringType), value);
			}
			ctx.Stack.SetTopPosition(u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			state = ExecutionState.Next;
		}
	}
}
