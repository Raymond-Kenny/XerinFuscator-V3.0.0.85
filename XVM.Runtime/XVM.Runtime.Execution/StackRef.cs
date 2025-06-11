using System;
using XVM.Runtime.XVM.Runtime.Execution.Internal;

namespace XVM.Runtime.XVM.Runtime.Execution
{
	internal class StackRef : IReference
	{
		public uint StackPos { get; set; }

		public StackRef(uint pos)
		{
			StackPos = pos;
		}

		public VMSlot GetValue(VMContext ctx, PointerType type)
		{
			VMSlot result = ctx.Stack[StackPos];
			switch (type)
			{
			case PointerType.BYTE:
				result.U8 = result.U1;
				break;
			case PointerType.WORD:
				result.U8 = result.U2;
				break;
			case PointerType.DWORD:
				result.U8 = result.U4;
				break;
			default:
				if (result.O is IValueTypeBox)
				{
					result.O = ((IValueTypeBox)result.O).Clone();
				}
				break;
			}
			return result;
		}

		public void SetValue(VMContext ctx, VMSlot slot, PointerType type)
		{
			switch (type)
			{
			case PointerType.BYTE:
				slot.U8 = slot.U1;
				break;
			case PointerType.WORD:
				slot.U8 = slot.U2;
				break;
			case PointerType.DWORD:
				slot.U8 = slot.U4;
				break;
			}
			ctx.Stack[StackPos] = slot;
		}

		public IReference Add(uint value)
		{
			return new StackRef(StackPos + value);
		}

		public IReference Add(ulong value)
		{
			return new StackRef(StackPos + (uint)(int)value);
		}

		public void ToTypedReference(VMContext ctx, TypedRefPtr typedRef, Type type)
		{
			ctx.Stack.ToTypedReference(StackPos, typedRef, type);
		}
	}
}
