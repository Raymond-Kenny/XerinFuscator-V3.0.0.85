using System;
using System.Reflection;
using XVM.Runtime.XVM.Runtime.Execution.Internal;

namespace XVM.Runtime.XVM.Runtime.Execution
{
	internal class FieldRef : IReference
	{
		private object instance;

		private FieldInfo field;

		public FieldRef(object instance, FieldInfo field)
		{
			this.instance = instance;
			this.field = field;
		}

		public VMSlot GetValue(VMContext ctx, PointerType type)
		{
			object obj = instance;
			if (field.DeclaringType.IsValueType && instance is IReference)
			{
				obj = ((IReference)instance).GetValue(ctx, PointerType.OBJECT).ToObject(field.DeclaringType);
			}
			return VMSlot.FromObject(field.GetValue(obj), field.FieldType);
		}

		public unsafe void SetValue(VMContext ctx, VMSlot slot, PointerType type)
		{
			if (field.DeclaringType.IsValueType && instance is IReference)
			{
				TypedReference obj = default(TypedReference);
				((IReference)instance).ToTypedReference(ctx, &obj, field.DeclaringType);
				field.SetValueDirect(obj, slot.ToObject(field.FieldType));
			}
			else
			{
				field.SetValue(instance, slot.ToObject(field.FieldType));
			}
		}

		public IReference Add(uint value)
		{
			return this;
		}

		public IReference Add(ulong value)
		{
			return this;
		}

		public void ToTypedReference(VMContext ctx, TypedRefPtr typedRef, Type type)
		{
			TypedReferenceHelpers.GetFieldAddr(ctx, instance, field, typedRef);
		}
	}
}
