using XVM.Core.VMIR.RegAlloc;

namespace XVM.Core.VMIR.Transforms
{
	public class RegisterAllocationTransform : ITransform
	{
		public static readonly object RegAllocatorKey;

		private RegisterAllocator pMm;

		public void Initialize(IRTransformer irtransformer_0)
		{
			pMm = new RegisterAllocator(irtransformer_0);
			pMm.Initialize();
			irtransformer_0.yqS()[RegAllocatorKey] = pMm;
		}

		public void Transform(IRTransformer irtransformer_0)
		{
			pMm.Allocate(irtransformer_0.pqU());
		}

		static RegisterAllocationTransform()
		{
			RegAllocatorKey = new object();
		}
	}
}
