using System.Runtime.CompilerServices;
using Confuser.DynCipher.AST;
using XCore.Generator;

namespace XF
{
	internal class aCR : sCv
	{
		[CompilerGenerated]
		private rC0 OC1;

		public aCR()
			: base(2)
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public rC0 MCo()
		{
			return OC1;
		}

		[SpecialName]
		[CompilerGenerated]
		private void WCD(rC0 rC0_0)
		{
			OC1 = rC0_0;
		}

		public override void nDV(RandomGenerator randomGenerator_0)
		{
			WCD((rC0)randomGenerator_0.NextInt32(3));
		}

		public override void ODW(BFr bfr_0)
		{
			Expression expression = bfr_0.LFc(uC4()[0]);
			Expression expression2 = bfr_0.LFc(uC4()[1]);
			switch (MCo())
			{
			case (rC0)0:
				bfr_0.EFq(new AssignmentStatement
				{
					Value = expression + expression2,
					Target = expression
				});
				break;
			case (rC0)1:
				bfr_0.EFq(new AssignmentStatement
				{
					Value = (expression ^ expression2),
					Target = expression
				});
				break;
			case (rC0)2:
				bfr_0.EFq(new AssignmentStatement
				{
					Value = ~(expression ^ expression2),
					Target = expression
				});
				break;
			}
		}

		public override void fDG(BFr bfr_0)
		{
			Expression expression = bfr_0.LFc(uC4()[0]);
			Expression expression2 = bfr_0.LFc(uC4()[1]);
			switch (MCo())
			{
			case (rC0)0:
				bfr_0.EFq(new AssignmentStatement
				{
					Value = expression - expression2,
					Target = expression
				});
				break;
			case (rC0)1:
				bfr_0.EFq(new AssignmentStatement
				{
					Value = (expression ^ expression2),
					Target = expression
				});
				break;
			case (rC0)2:
				bfr_0.EFq(new AssignmentStatement
				{
					Value = (expression ^ ~expression2),
					Target = expression
				});
				break;
			}
		}
	}
}
