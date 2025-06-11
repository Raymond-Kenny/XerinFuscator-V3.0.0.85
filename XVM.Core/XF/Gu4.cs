using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using XVM.Core.Services;
using XVM.DynCipher.AST;

namespace XF
{
	internal class Gu4
	{
		private struct mk1 : IDisposable
		{
			private readonly Gu4 ykj;

			private readonly Variable ekO;

			public mk1(Gu4 gu4_0, Variable variable_0)
			{
				ykj = gu4_0;
				ekO = variable_0;
			}

			public void Dispose()
			{
				ykj.Vuw.Add(ekO);
			}
		}

		private readonly Variable[] KuA;

		private readonly Variable euR = new Variable("{KEY}");

		private readonly RandomGenerator ru0;

		private readonly List<Variable> Vuw = new List<Variable>();

		private int WuW;

		[CompilerGenerated]
		private StatementBlock uuE;

		public Gu4(RandomGenerator randomGenerator_0, int int_0)
		{
			ru0 = randomGenerator_0;
			Uuq(new StatementBlock());
			KuA = new Variable[int_0];
			for (int i = 0; i < int_0; i++)
			{
				KuA[i] = new Variable("v" + i)
				{
					Tag = i
				};
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public StatementBlock WuI()
		{
			return uuE;
		}

		[SpecialName]
		[CompilerGenerated]
		private void Uuq(StatementBlock statementBlock_0)
		{
			uuE = statementBlock_0;
		}

		public Expression Eue(int int_0)
		{
			return new VariableExpression
			{
				Variable = KuA[int_0]
			};
		}

		public Expression Yuu(int int_0)
		{
			return new ArrayIndexExpression
			{
				Array = new VariableExpression
				{
					Variable = euR
				},
				Index = int_0
			};
		}

		public Gu4 gu9(Statement statement_0)
		{
			WuI().Statements.Add(statement_0);
			return this;
		}

		public IDisposable YuG(out VariableExpression variableExpression_0)
		{
			Variable variable;
			if (Vuw.Count != 0)
			{
				variable = Vuw[ru0.method_1(Vuw.Count)];
				Vuw.Remove(variable);
			}
			else
			{
				variable = new Variable("t" + WuW++);
			}
			variableExpression_0 = new VariableExpression
			{
				Variable = variable
			};
			return new mk1(this, variable);
		}
	}
}
