using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Confuser.DynCipher.AST;
using XCore.Generator;

namespace XF
{
	internal class BFr
	{
		private struct D6I : IDisposable
		{
			private readonly BFr a62;

			private readonly Variable t6s;

			public D6I(BFr bfr_0, Variable variable_0)
			{
				a62 = bfr_0;
				t6s = variable_0;
			}

			public void Dispose()
			{
				a62.hFM.Add(t6s);
			}
		}

		private readonly Variable[] SF3;

		private readonly Variable tF5 = new Variable("{KEY}");

		private readonly RandomGenerator bFH;

		private readonly List<Variable> hFM = new List<Variable>();

		private int RFL;

		[CompilerGenerated]
		private StatementBlock DFV;

		public BFr(RandomGenerator randomGenerator_0, int int_0)
		{
			bFH = randomGenerator_0;
			XFk(new StatementBlock());
			SF3 = new Variable[int_0];
			for (int i = 0; i < int_0; i++)
			{
				SF3[i] = new Variable("v" + i)
				{
					Tag = i
				};
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public StatementBlock qFb()
		{
			return DFV;
		}

		[SpecialName]
		[CompilerGenerated]
		private void XFk(StatementBlock statementBlock_0)
		{
			DFV = statementBlock_0;
		}

		public Expression LFc(int int_0)
		{
			return new VariableExpression
			{
				Variable = SF3[int_0]
			};
		}

		public Expression RFw(int int_0)
		{
			return new ArrayIndexExpression
			{
				Array = new VariableExpression
				{
					Variable = tF5
				},
				Index = int_0
			};
		}

		public BFr EFq(Statement statement_0)
		{
			qFb().Statements.Add(statement_0);
			return this;
		}

		public IDisposable jFy(out VariableExpression variableExpression_0)
		{
			Variable variable;
			if (hFM.Count == 0)
			{
				variable = new Variable("t" + RFL++);
			}
			else
			{
				variable = hFM[bFH.NextInt32(hFM.Count)];
				hFM.Remove(variable);
			}
			variableExpression_0 = new VariableExpression
			{
				Variable = variable
			};
			return new D6I(this, variable);
		}
	}
}
