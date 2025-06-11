namespace XVM.Runtime.XVM.Runtime.Execution
{
	public struct TypedRefPtr
	{
		public unsafe void* ptr;

		public unsafe static implicit operator TypedRefPtr(void* ptr)
		{
			return new TypedRefPtr
			{
				ptr = ptr
			};
		}

		public unsafe static implicit operator void*(TypedRefPtr ptr)
		{
			return ptr.ptr;
		}
	}
}
