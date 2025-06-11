using System;
using XVM.Runtime.XVM.Runtime.Execution.Internal;

namespace XVM.Runtime.XVM.Runtime.Execution
{
	public class TypedRef : IReference
	{
		private struct PseudoTypedRef
		{
			public IntPtr Type;

			public IntPtr Value;
		}

		private TypedRefPtr? _ptr;

		private PseudoTypedRef _typedRef;

		public TypedRef(TypedRefPtr ptr)
		{
			_ptr = ptr;
		}

		public unsafe TypedRef(TypedReference typedRef)
		{
			_ptr = null;
			_typedRef = *(PseudoTypedRef*)&typedRef;
		}

		public unsafe VMSlot GetValue(VMContext ctx, PointerType type)
		{
			TypedReference typedReference = default(TypedReference);
			if (_ptr.HasValue)
			{
				typedReference = *(TypedReference*)(void*)_ptr.Value;
			}
			else
			{
				*(PseudoTypedRef*)&typedReference = _typedRef;
			}
			return VMSlot.FromObject(TypedReference.ToObject(typedReference), __reftype(typedReference));
		}

		public unsafe void SetValue(VMContext ctx, VMSlot slot, PointerType type)
		{
			TypedReference typedReference = default(TypedReference);
			if (_ptr.HasValue)
			{
				typedReference = *(TypedReference*)(void*)_ptr.Value;
			}
			else
			{
				*(PseudoTypedRef*)&typedReference = _typedRef;
			}
			Type typeFromHandle = __reftype(typedReference);
			object value = slot.ToObject(typeFromHandle);
			TypedReferenceHelpers.SetTypedRef(value, &typedReference);
		}

		public IReference Add(uint value)
		{
			return this;
		}

		public IReference Add(ulong value)
		{
			return this;
		}

		public unsafe void ToTypedReference(VMContext ctx, TypedRefPtr typedRef, Type type)
		{
			if (_ptr.HasValue)
			{
				*(TypedReference*)(void*)typedRef = *(TypedReference*)(void*)_ptr.Value;
			}
			else
			{
				*(PseudoTypedRef*)(void*)typedRef = _typedRef;
			}
		}
	}
}
