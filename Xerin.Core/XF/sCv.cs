using System.Runtime.CompilerServices;
using XCore.Generator;

namespace XF
{
	internal abstract class sCv
	{
		[CompilerGenerated]
		private int BCr;

		[CompilerGenerated]
		private int[] NCc;

		public sCv(int int_0)
		{
			RCj(int_0);
			tCn(new int[int_0]);
		}

		[SpecialName]
		[CompilerGenerated]
		public int fCx()
		{
			return BCr;
		}

		[SpecialName]
		[CompilerGenerated]
		private void RCj(int int_0)
		{
			BCr = int_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public int[] uC4()
		{
			return NCc;
		}

		[SpecialName]
		[CompilerGenerated]
		private void tCn(int[] int_0)
		{
			NCc = int_0;
		}

		public abstract void nDV(RandomGenerator randomGenerator_0);

		public abstract void ODW(BFr bfr_0);

		public abstract void fDG(BFr bfr_0);
	}
}
