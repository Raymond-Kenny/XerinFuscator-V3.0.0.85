using System;
using XVM.Runtime.XVM.Runtime.Execution.Internal;

namespace XVM.Runtime.XVM.Runtime.Execution
{
	internal class PointerRef : IReference
	{
		private unsafe void* ptr;

		public unsafe PointerRef(void* ptr)
		{
			this.ptr = ptr;
		}

		public VMSlot GetValue(VMContext ctx, PointerType type)
		{
			throw new NotSupportedException();
		}

		public void SetValue(VMContext ctx, VMSlot slot, PointerType type)
		{
			throw new NotSupportedException();
		}

		public IReference Add(uint value)
		{
			throw new NotSupportedException();
		}

		public IReference Add(ulong value)
		{
			throw new NotSupportedException();
		}

		public unsafe void ToTypedReference(VMContext ctx, TypedRefPtr typedRef, Type type)
		{
			TypedReferenceHelpers.MakeTypedRef(ptr, typedRef, type);
		}
	}
}
