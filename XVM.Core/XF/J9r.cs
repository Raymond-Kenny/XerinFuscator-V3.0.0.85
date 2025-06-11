using System.Runtime.CompilerServices;
using XVM.Core.Services;
using XVM.DynCipher;
using XVM.DynCipher.AST;

namespace XF
{
	internal class J9r : A94
	{
		[CompilerGenerated]
		private uint n9f;

		[CompilerGenerated]
		private uint p9i;

		public J9r()
			: base(2)
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public uint z9X()
		{
			return n9f;
		}

		[SpecialName]
		[CompilerGenerated]
		private void O9n(uint uint_0)
		{
			n9f = uint_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public uint k9x()
		{
			return p9i;
		}

		[SpecialName]
		[CompilerGenerated]
		private void W9s(uint uint_0)
		{
			p9i = uint_0;
		}

		public override void Initialize(RandomGenerator randomGenerator_0)
		{
			if (randomGenerator_0.method_1(3) == 0)
			{
				O9n(uint.MaxValue);
			}
			else
			{
				O9n(randomGenerator_0.method_3());
			}
			W9s(randomGenerator_0.method_3() | 1);
		}

		private void o93(Gu4 gu4_0)
		{
			Expression expression = gu4_0.Eue(P9G()[0]);
			Expression expression2 = gu4_0.Eue(P9G()[1]);
			VariableExpression variableExpression_;
			if (z9X() == uint.MaxValue)
			{
				using (gu4_0.YuG(out variableExpression_))
				{
					gu4_0.gu9(new AssignmentStatement
					{
						Value = expression * (LiteralExpression)k9x(),
						Target = variableExpression_
					}).gu9(new AssignmentStatement
					{
						Value = expression2,
						Target = expression
					}).gu9(new AssignmentStatement
					{
						Value = variableExpression_ * (LiteralExpression)MathsUtils.modInv(k9x()),
						Target = expression2
					});
					return;
				}
			}
			LiteralExpression literalExpression = z9X();
			LiteralExpression literalExpression2 = ~z9X();
			using (gu4_0.YuG(out variableExpression_))
			{
				gu4_0.gu9(new AssignmentStatement
				{
					Value = (expression & literalExpression) * (LiteralExpression)k9x(),
					Target = variableExpression_
				}).gu9(new AssignmentStatement
				{
					Value = ((expression & literalExpression2) | (expression2 & literalExpression)),
					Target = expression
				}).gu9(new AssignmentStatement
				{
					Value = ((expression2 & literalExpression2) | (variableExpression_ * (LiteralExpression)MathsUtils.modInv(k9x()))),
					Target = expression2
				});
			}
		}

		public override void dUo(Gu4 gu4_0)
		{
			o93(gu4_0);
		}

		public override void DUl(Gu4 gu4_0)
		{
			o93(gu4_0);
		}
	}
}
