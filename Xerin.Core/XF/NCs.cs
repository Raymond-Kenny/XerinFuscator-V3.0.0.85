using System.Runtime.CompilerServices;
using Confuser.DynCipher.AST;
using XCore.Generator;

namespace XF
{
	internal class NCs : sCv
	{
		[CompilerGenerated]
		private int seU;

		[CompilerGenerated]
		private bool DeY;

		public NCs()
			: base(1)
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public int rCE()
		{
			return seU;
		}

		[SpecialName]
		[CompilerGenerated]
		private void aCg(int int_0)
		{
			seU = int_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public bool nCB()
		{
			return DeY;
		}

		[SpecialName]
		[CompilerGenerated]
		private void jCz(bool bool_0)
		{
			DeY = bool_0;
		}

		public override void nDV(RandomGenerator randomGenerator_0)
		{
			aCg(randomGenerator_0.NextInt32(1, 32));
			jCz(randomGenerator_0.NextInt32() % 2 == 0);
		}

		public override void ODW(BFr bfr_0)
		{
			Expression expression = bfr_0.LFc(uC4()[0]);
			VariableExpression variableExpression_;
			using (bfr_0.jFy(out variableExpression_))
			{
				if (!nCB())
				{
					bfr_0.EFq(new AssignmentStatement
					{
						Value = expression << 32 - rCE(),
						Target = variableExpression_
					}).EFq(new AssignmentStatement
					{
						Value = ((expression >> rCE()) | variableExpression_),
						Target = expression
					});
				}
				else
				{
					bfr_0.EFq(new AssignmentStatement
					{
						Value = expression >> 32 - rCE(),
						Target = variableExpression_
					}).EFq(new AssignmentStatement
					{
						Value = ((expression << rCE()) | variableExpression_),
						Target = expression
					});
				}
			}
		}

		public override void fDG(BFr bfr_0)
		{
			Expression expression = bfr_0.LFc(uC4()[0]);
			VariableExpression variableExpression_;
			using (bfr_0.jFy(out variableExpression_))
			{
				if (nCB())
				{
					bfr_0.EFq(new AssignmentStatement
					{
						Value = expression << 32 - rCE(),
						Target = variableExpression_
					}).EFq(new AssignmentStatement
					{
						Value = ((expression >> rCE()) | variableExpression_),
						Target = expression
					});
				}
				else
				{
					bfr_0.EFq(new AssignmentStatement
					{
						Value = expression >> 32 - rCE(),
						Target = variableExpression_
					}).EFq(new AssignmentStatement
					{
						Value = ((expression << rCE()) | variableExpression_),
						Target = expression
					});
				}
			}
		}
	}
}
