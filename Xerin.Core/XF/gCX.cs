using System.Runtime.CompilerServices;
using Confuser.DynCipher;
using Confuser.DynCipher.AST;
using XCore.Generator;

namespace XF
{
	internal class gCX : sCv
	{
		[CompilerGenerated]
		private uint yCO;

		[CompilerGenerated]
		private uint PCI;

		[CompilerGenerated]
		private rC0 DC2;

		public gCX()
			: base(1)
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public uint xCm()
		{
			return yCO;
		}

		[SpecialName]
		[CompilerGenerated]
		private void ACA(uint uint_0)
		{
			yCO = uint_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public uint xCP()
		{
			return PCI;
		}

		[SpecialName]
		[CompilerGenerated]
		private void ICf(uint uint_0)
		{
			PCI = uint_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public rC0 FCi()
		{
			return DC2;
		}

		[SpecialName]
		[CompilerGenerated]
		private void SCS(rC0 rC0_0)
		{
			DC2 = rC0_0;
		}

		public override void nDV(RandomGenerator randomGenerator_0)
		{
			SCS((rC0)randomGenerator_0.NextInt32(4));
			switch (FCi())
			{
			case (rC0)1:
				ACA(randomGenerator_0.NextUInt32() | 1);
				ICf(MathsUtils.modInv(xCm()));
				break;
			case (rC0)0:
			case (rC0)2:
			{
				uint uint_;
				ICf(uint_ = randomGenerator_0.NextUInt32());
				ACA(uint_);
				break;
			}
			case (rC0)3:
				ACA(randomGenerator_0.NextUInt32());
				ICf(~xCm());
				break;
			}
		}

		public override void ODW(BFr bfr_0)
		{
			Expression expression = bfr_0.LFc(uC4()[0]);
			switch (FCi())
			{
			case (rC0)0:
				bfr_0.EFq(new AssignmentStatement
				{
					Value = expression + (LiteralExpression)xCm(),
					Target = expression
				});
				break;
			case (rC0)1:
				bfr_0.EFq(new AssignmentStatement
				{
					Value = expression * (LiteralExpression)xCm(),
					Target = expression
				});
				break;
			case (rC0)2:
				bfr_0.EFq(new AssignmentStatement
				{
					Value = (expression ^ (LiteralExpression)xCm()),
					Target = expression
				});
				break;
			case (rC0)3:
				bfr_0.EFq(new AssignmentStatement
				{
					Value = ~(expression ^ (LiteralExpression)xCm()),
					Target = expression
				});
				break;
			}
		}

		public override void fDG(BFr bfr_0)
		{
			Expression expression = bfr_0.LFc(uC4()[0]);
			switch (FCi())
			{
			case (rC0)0:
				bfr_0.EFq(new AssignmentStatement
				{
					Value = expression - (LiteralExpression)xCP(),
					Target = expression
				});
				break;
			case (rC0)1:
				bfr_0.EFq(new AssignmentStatement
				{
					Value = expression * (LiteralExpression)xCP(),
					Target = expression
				});
				break;
			case (rC0)2:
				bfr_0.EFq(new AssignmentStatement
				{
					Value = (expression ^ (LiteralExpression)xCP()),
					Target = expression
				});
				break;
			case (rC0)3:
				bfr_0.EFq(new AssignmentStatement
				{
					Value = (expression ^ (LiteralExpression)xCP()),
					Target = expression
				});
				break;
			}
		}
	}
}
