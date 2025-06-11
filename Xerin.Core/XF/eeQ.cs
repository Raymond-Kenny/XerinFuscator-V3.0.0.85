using System.Runtime.CompilerServices;
using Confuser.DynCipher;
using Confuser.DynCipher.AST;
using XCore.Generator;

namespace XF
{
	internal class eeQ : sCv
	{
		[CompilerGenerated]
		private uint Ue0;

		[CompilerGenerated]
		private uint CeR;

		public eeQ()
			: base(2)
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public uint XeC()
		{
			return Ue0;
		}

		[SpecialName]
		[CompilerGenerated]
		private void uee(uint uint_0)
		{
			Ue0 = uint_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public uint Yet()
		{
			return CeR;
		}

		[SpecialName]
		[CompilerGenerated]
		private void ie7(uint uint_0)
		{
			CeR = uint_0;
		}

		public override void nDV(RandomGenerator randomGenerator_0)
		{
			if (randomGenerator_0.NextInt32(3) != 0)
			{
				uee(randomGenerator_0.NextUInt32());
			}
			else
			{
				uee(uint.MaxValue);
			}
			ie7(randomGenerator_0.NextUInt32() | 1);
		}

		private void ueF(BFr bfr_0)
		{
			Expression expression = bfr_0.LFc(uC4()[0]);
			Expression expression2 = bfr_0.LFc(uC4()[1]);
			VariableExpression variableExpression_;
			if (XeC() != uint.MaxValue)
			{
				LiteralExpression literalExpression = XeC();
				LiteralExpression literalExpression2 = ~XeC();
				using (bfr_0.jFy(out variableExpression_))
				{
					bfr_0.EFq(new AssignmentStatement
					{
						Value = (expression & literalExpression) * (LiteralExpression)Yet(),
						Target = variableExpression_
					}).EFq(new AssignmentStatement
					{
						Value = ((expression & literalExpression2) | (expression2 & literalExpression)),
						Target = expression
					}).EFq(new AssignmentStatement
					{
						Value = ((expression2 & literalExpression2) | (variableExpression_ * (LiteralExpression)MathsUtils.modInv(Yet()))),
						Target = expression2
					});
					return;
				}
			}
			using (bfr_0.jFy(out variableExpression_))
			{
				bfr_0.EFq(new AssignmentStatement
				{
					Value = expression * (LiteralExpression)Yet(),
					Target = variableExpression_
				}).EFq(new AssignmentStatement
				{
					Value = expression2,
					Target = expression
				}).EFq(new AssignmentStatement
				{
					Value = variableExpression_ * (LiteralExpression)MathsUtils.modInv(Yet()),
					Target = expression2
				});
			}
		}

		public override void ODW(BFr bfr_0)
		{
			ueF(bfr_0);
		}

		public override void fDG(BFr bfr_0)
		{
			ueF(bfr_0);
		}
	}
}
