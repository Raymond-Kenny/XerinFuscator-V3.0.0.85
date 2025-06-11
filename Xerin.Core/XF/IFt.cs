using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Confuser.DynCipher.AST;
using XCore.Generator;

namespace XF
{
	internal class IFt
	{
		private class L6U
		{
			public Dictionary<Statement, Variable[]> J6Y;

			public object r6Q;

			public Dictionary<Statement, Variable[]> k6F;
		}

		[Serializable]
		[CompilerGenerated]
		private sealed class R6C
		{
			public static readonly R6C y66;

			public static Func<Statement, Statement> O60;

			public static Func<Statement, Variable[]> W6R;

			public static Func<Statement, Statement> e6o;

			public static Func<Statement, Variable[]> F6D;

			static R6C()
			{
				y66 = new R6C();
			}

			internal Statement o6e(Statement statement_0)
			{
				return statement_0;
			}

			internal Variable[] U6J(Statement statement_0)
			{
				return LF6(statement_0).ToArray();
			}

			internal Statement T6t(Statement statement_0)
			{
				return statement_0;
			}

			internal Variable[] s67(Statement statement_0)
			{
				return aFR(statement_0).ToArray();
			}
		}

		private static IEnumerable<Variable> iF7(Expression expression_0)
		{
			if (!(expression_0 is VariableExpression))
			{
				if (expression_0 is ArrayIndexExpression)
				{
					foreach (Variable item in iF7(((ArrayIndexExpression)expression_0).Array))
					{
						yield return item;
					}
					yield break;
				}
				if (!(expression_0 is BinOpExpression))
				{
					if (!(expression_0 is UnaryOpExpression))
					{
						yield break;
					}
					foreach (Variable item2 in iF7(((UnaryOpExpression)expression_0).Value))
					{
						yield return item2;
					}
					yield break;
				}
				foreach (Variable item3 in iF7(((BinOpExpression)expression_0).Left).Concat(iF7(((BinOpExpression)expression_0).Right)))
				{
					yield return item3;
				}
			}
			else
			{
				yield return ((VariableExpression)expression_0).Variable;
			}
		}

		private static IEnumerable<Variable> LF6(Statement statement_0)
		{
			if (!(statement_0 is AssignmentStatement))
			{
				yield break;
			}
			foreach (Variable item in iF7(((AssignmentStatement)statement_0).Value))
			{
				yield return item;
			}
		}

		private static IEnumerable<Variable> SF0(Expression expression_0)
		{
			if (expression_0 is VariableExpression)
			{
				yield return ((VariableExpression)expression_0).Variable;
			}
		}

		private static IEnumerable<Variable> aFR(Statement statement_0)
		{
			if (!(statement_0 is AssignmentStatement))
			{
				yield break;
			}
			foreach (Variable item in SF0(((AssignmentStatement)statement_0).Target))
			{
				yield return item;
			}
		}

		private static int xFo(Dictionary<Statement, Variable[]> dictionary_0, object object_0, StatementBlock statementBlock_0, int int_0)
		{
			Variable[] second = ((L6U)(object)dictionary_0).k6F[(Statement)object_0];
			Variable[] second2 = ((L6U)(object)dictionary_0).J6Y[(Statement)object_0];
			int num = int_0 - 1;
			while (true)
			{
				if (num >= 0)
				{
					if (((L6U)(object)dictionary_0).k6F[statementBlock_0.Statements[num]].Intersect(second2).Count() > 0 || ((L6U)(object)dictionary_0).J6Y[statementBlock_0.Statements[num]].Intersect(second).Count() > 0)
					{
						break;
					}
					num--;
					continue;
				}
				return 0;
			}
			return num;
		}

		private static int TFD(Dictionary<Statement, Variable[]> dictionary_0, object object_0, StatementBlock statementBlock_0, int int_0)
		{
			Variable[] second = ((L6U)(object)dictionary_0).k6F[(Statement)object_0];
			Variable[] second2 = ((L6U)(object)dictionary_0).J6Y[(Statement)object_0];
			int num = int_0 + 1;
			while (true)
			{
				if (num < statementBlock_0.Statements.Count)
				{
					if (((L6U)(object)dictionary_0).k6F[statementBlock_0.Statements[num]].Intersect(second2).Count() > 0 || ((L6U)(object)dictionary_0).J6Y[statementBlock_0.Statements[num]].Intersect(second).Count() > 0)
					{
						break;
					}
					num++;
					continue;
				}
				return statementBlock_0.Statements.Count - 1;
			}
			return num;
		}

		public static void QFd(StatementBlock statementBlock_0, RandomGenerator randomGenerator_0)
		{
			L6U l6U = new L6U
			{
				r6Q = statementBlock_0.Statements.ToArray(),
				k6F = statementBlock_0.Statements.ToDictionary((Statement statement_0) => statement_0, (Statement statement_0) => LF6(statement_0).ToArray()),
				J6Y = statementBlock_0.Statements.ToDictionary((Statement statement_0) => statement_0, (Statement statement_0) => aFR(statement_0).ToArray())
			};
			for (int num = 0; num < 20; num++)
			{
				Statement[] r6Q = (Statement[])l6U.r6Q;
				foreach (Statement statement in r6Q)
				{
					int num3 = statementBlock_0.Statements.IndexOf(statement);
					LF6(statement).Concat(aFR(statement)).ToArray();
					int num4 = xFo((Dictionary<Statement, Variable[]>)(object)l6U, statement, statementBlock_0, num3);
					int num5 = TFD((Dictionary<Statement, Variable[]>)(object)l6U, statement, statementBlock_0, num3);
					int num6 = num4 + randomGenerator_0.NextInt32(1, num5 - num4);
					if (num6 > num3)
					{
						num6--;
					}
					statementBlock_0.Statements.RemoveAt(num3);
					statementBlock_0.Statements.Insert(num6, statement);
				}
			}
		}
	}
}
