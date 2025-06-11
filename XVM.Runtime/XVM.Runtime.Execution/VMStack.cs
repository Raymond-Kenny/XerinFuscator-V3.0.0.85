using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using XVM.Runtime.XVM.Runtime.Execution.Internal;

namespace XVM.Runtime.XVM.Runtime.Execution
{
	internal class VMStack
	{
		private class LocallocNode
		{
			public uint GuardPos;

			public IntPtr Memory;

			public LocallocNode Next;

			~LocallocNode()
			{
				if (Memory != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(Memory);
					Memory = IntPtr.Zero;
				}
			}

			public LocallocNode Free()
			{
				if (Memory != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(Memory);
					Memory = IntPtr.Zero;
				}
				return Next;
			}
		}

		private const int SectionSize = 6;

		private const int IndexMask = 63;

		private List<VMSlot[]> sections = new List<VMSlot[]>();

		private uint topPos;

		private LocallocNode localPool;

		public VMSlot this[uint pos]
		{
			get
			{
				if (pos > topPos)
				{
					return VMSlot.Null;
				}
				uint index = pos >> 6;
				return sections[(int)index][pos & 0x3F];
			}
			set
			{
				if (pos <= topPos)
				{
					uint index = pos >> 6;
					sections[(int)index][pos & 0x3F] = value;
				}
			}
		}

		public void SetTopPosition(uint topPos)
		{
			if (topPos > int.MaxValue)
			{
				throw new StackOverflowException();
			}
			uint num = topPos >> 6;
			if (num >= sections.Count)
			{
				do
				{
					sections.Add(new VMSlot[64]);
				}
				while (num >= sections.Count);
			}
			else if (num < sections.Count - 2)
			{
				do
				{
					sections.RemoveAt(sections.Count - 1);
				}
				while (num < sections.Count - 2);
			}
			uint num2 = (topPos & 0x3F) + 1;
			VMSlot[] array = sections[(int)num];
			while (num2 < array.Length && array[num2].O != null)
			{
				array[num2++] = VMSlot.Null;
			}
			if (num2 == array.Length && num + 1 < sections.Count)
			{
				num2 = 0u;
				array = sections[(int)(num + 1)];
				while (num2 < array.Length && array[num2].O != null)
				{
					array[num2++] = VMSlot.Null;
				}
			}
			this.topPos = topPos;
			CheckFreeLocalloc();
		}

		private void CheckFreeLocalloc()
		{
			while (localPool != null && localPool.GuardPos > topPos)
			{
				localPool = localPool.Free();
			}
		}

		public IntPtr Localloc(uint guardPos, uint size)
		{
			LocallocNode locallocNode = new LocallocNode
			{
				GuardPos = guardPos,
				Memory = Marshal.AllocHGlobal((int)size)
			};
			LocallocNode next = localPool;
			while (next != null && next.Next != null && next.Next.GuardPos >= guardPos)
			{
				next = next.Next;
			}
			if (next == null)
			{
				localPool = locallocNode;
			}
			else
			{
				locallocNode.Next = next.Next;
				next.Next = locallocNode;
			}
			return locallocNode.Memory;
		}

		public void FreeAllLocalloc()
		{
			for (LocallocNode locallocNode = localPool; locallocNode != null; locallocNode = locallocNode.Free())
			{
			}
			localPool = null;
		}

		~VMStack()
		{
			FreeAllLocalloc();
		}

		public void ToTypedReference(uint pos, TypedRefPtr typedRef, Type type)
		{
			if (pos > topPos)
			{
				throw new ExecutionEngineException();
			}
			VMSlot[] array = sections[(int)(pos >> 6)];
			uint num = pos & 0x3F;
			if (type.IsEnum)
			{
				type = Enum.GetUnderlyingType(type);
			}
			if (type.IsPrimitive || type.IsPointer)
			{
				array[num].ToTypedReferencePrimitive(typedRef);
				TypedReferenceHelpers.CastTypedRef(typedRef, type);
			}
			else
			{
				array[num].ToTypedReferenceObject(typedRef, type);
			}
		}
	}
}
