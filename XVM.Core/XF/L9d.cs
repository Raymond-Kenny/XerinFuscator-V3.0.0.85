using System.Runtime.CompilerServices;
using XVM.Core.Services;
using XVM.DynCipher.AST;

namespace XF
{
	internal class L9d : A94
	{
		[CompilerGenerated]
		private int x9V;

		[CompilerGenerated]
		private bool p9b;

		public L9d()
			: base(1)
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public int B9B()
		{
			return x9V;
		}

		[SpecialName]
		[CompilerGenerated]
		private void R97(int int_0)
		{
			x9V = int_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public bool p9y()
		{
			return p9b;
		}

		[SpecialName]
		[CompilerGenerated]
		private void h9Y(bool bool_0)
		{
			p9b = bool_0;
		}

		public override void Initialize(RandomGenerator randomGenerator_0)
		{
			R97(randomGenerator_0.method_2(1, 32));
			h9Y(randomGenerator_0.method_0() % 2 == 0);
		}

		public override void dUo(Gu4 gu4_0)
		{
			Expression expression = gu4_0.Eue(P9G()[0]);
			VariableExpression variableExpression_;
			using (gu4_0.YuG(out variableExpression_))
			{
				if (!p9y())
				{
					gu4_0.gu9(new AssignmentStatement
					{
						Value = expression << 32 - B9B(),
						Target = variableExpression_
					}).gu9(new AssignmentStatement
					{
						Value = ((expression >> B9B()) | variableExpression_),
						Target = expression
					});
				}
				else
				{
					gu4_0.gu9(new AssignmentStatement
					{
						Value = expression >> 32 - B9B(),
						Target = variableExpression_
					}).gu9(new AssignmentStatement
					{
						Value = ((expression << B9B()) | variableExpression_),
						Target = expression
					});
				}
			}
		}

		public override void DUl(Gu4 gu4_0)
		{
			Expression expression = gu4_0.Eue(P9G()[0]);
			VariableExpression variableExpression_;
			using (gu4_0.YuG(out variableExpression_))
			{
				if (!p9y())
				{
					gu4_0.gu9(new AssignmentStatement
					{
						Value = expression >> 32 - B9B(),
						Target = variableExpression_
					}).gu9(new AssignmentStatement
					{
						Value = ((expression << B9B()) | variableExpression_),
						Target = expression
					});
				}
				else
				{
					gu4_0.gu9(new AssignmentStatement
					{
						Value = expression << 32 - B9B(),
						Target = variableExpression_
					}).gu9(new AssignmentStatement
					{
						Value = ((expression >> B9B()) | variableExpression_),
						Target = expression
					});
				}
			}
		}
	}
}
