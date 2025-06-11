using System.Runtime.CompilerServices;
using XVM.Core.Services;

namespace XF
{
	internal abstract class A94
	{
		[CompilerGenerated]
		private int g9M;

		[CompilerGenerated]
		private int[] x9A;

		public A94(int int_0)
		{
			n9u(int_0);
			o9I(new int[int_0]);
		}

		[SpecialName]
		[CompilerGenerated]
		public int B9e()
		{
			return g9M;
		}

		[SpecialName]
		[CompilerGenerated]
		private void n9u(int int_0)
		{
			g9M = int_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public int[] P9G()
		{
			return x9A;
		}

		[SpecialName]
		[CompilerGenerated]
		private void o9I(int[] int_0)
		{
			x9A = int_0;
		}

		public abstract void Initialize(RandomGenerator randomGenerator_0);

		public abstract void dUo(Gu4 gu4_0);

		public abstract void DUl(Gu4 gu4_0);
	}
}
