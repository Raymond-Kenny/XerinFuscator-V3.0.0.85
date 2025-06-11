using System.Runtime.CompilerServices;
using XVM.Core.Services;
using XVM.DynCipher.AST;

namespace XF
{
	internal class ru3 : A94
	{
		[CompilerGenerated]
		private int xus;

		public ru3(int int_0)
			: base(0)
		{
			Tu6(int_0);
		}

		[SpecialName]
		[CompilerGenerated]
		public int Oun()
		{
			return xus;
		}

		[SpecialName]
		[CompilerGenerated]
		private void Tu6(int int_0)
		{
			xus = int_0;
		}

		public override void Initialize(RandomGenerator randomGenerator_0)
		{
		}

		private void ruX(Gu4 gu4_0)
		{
			Expression expression = gu4_0.Eue(Oun());
			gu4_0.gu9(new AssignmentStatement
			{
				Value = (expression ^ gu4_0.Yuu(Oun())),
				Target = expression
			});
		}

		public override void dUo(Gu4 gu4_0)
		{
			ruX(gu4_0);
		}

		public override void DUl(Gu4 gu4_0)
		{
			ruX(gu4_0);
		}
	}
}
