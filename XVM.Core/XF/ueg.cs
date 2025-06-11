using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using XVM.Core.Services;
using XVM.DynCipher.AST;

namespace XF
{
	internal class ueg
	{
		private class dLk
		{
			public Dictionary<Statement, Variable[]> CLH;

			public object ELC;

			public Dictionary<Statement, Variable[]> DLm;
		}

		[Serializable]
		[CompilerGenerated]
		private sealed class rL5
		{
			public static readonly rL5 gLa;

			public static Func<Statement, Statement> jLU;

			public static Func<Statement, Variable[]> lLh;

			public static Func<Statement, Statement> LLP;

			public static Func<Statement, Variable[]> LLF;

			static rL5()
			{
				gLa = new rL5();
			}

			internal Statement mLo(Statement statement_0)
			{
				return statement_0;
			}

			internal Variable[] HLZ(Statement statement_0)
			{
				return qeb(statement_0).ToArray();
			}

			internal Statement rLT(Statement statement_0)
			{
				return statement_0;
			}

			internal Variable[] ULS(Statement statement_0)
			{
				return Ier(statement_0).ToArray();
			}
		}

		private static IEnumerable<Variable> SeV(Expression expression_0)
		{
			if (!(expression_0 is VariableExpression))
			{
				if (!(expression_0 is ArrayIndexExpression))
				{
					if (expression_0 is BinOpExpression)
					{
						foreach (Variable item in SeV(((BinOpExpression)expression_0).Left).Concat(SeV(((BinOpExpression)expression_0).Right)))
						{
							yield return item;
						}
					}
					else
					{
						if (!(expression_0 is UnaryOpExpression))
						{
							yield break;
						}
						foreach (Variable item2 in SeV(((UnaryOpExpression)expression_0).Value))
						{
							yield return item2;
						}
					}
					yield break;
				}
				foreach (Variable item3 in SeV(((ArrayIndexExpression)expression_0).Array))
				{
					yield return item3;
				}
			}
			else
			{
				yield return ((VariableExpression)expression_0).Variable;
			}
		}

		private static IEnumerable<Variable> qeb(Statement statement_0)
		{
			if (!(statement_0 is AssignmentStatement))
			{
				yield break;
			}
			foreach (Variable item in SeV(((AssignmentStatement)statement_0).Value))
			{
				yield return item;
			}
		}

		private static IEnumerable<Variable> Jep(Expression expression_0)
		{
			if (expression_0 is VariableExpression)
			{
				yield return ((VariableExpression)expression_0).Variable;
			}
		}

		private static IEnumerable<Variable> Ier(Statement statement_0)
		{
			if (!(statement_0 is AssignmentStatement))
			{
				yield break;
			}
			foreach (Variable item in Jep(((AssignmentStatement)statement_0).Target))
			{
				yield return item;
			}
		}

		private static int se3(Dictionary<Statement, Variable[]> dictionary_0, object object_0, StatementBlock statementBlock_0, int int_0)
		{
			Variable[] second = ((dLk)(object)dictionary_0).DLm[(Statement)object_0];
			Variable[] second2 = ((dLk)(object)dictionary_0).CLH[(Statement)object_0];
			int num = int_0 - 1;
			while (num >= 0)
			{
				if (((dLk)(object)dictionary_0).DLm[statementBlock_0.Statements[num]].Intersect(second2).Count() <= 0 && ((dLk)(object)dictionary_0).CLH[statementBlock_0.Statements[num]].Intersect(second).Count() <= 0)
				{
					num--;
					continue;
				}
				return num;
			}
			return 0;
		}

		private static int FeX(Dictionary<Statement, Variable[]> dictionary_0, object object_0, StatementBlock statementBlock_0, int int_0)
		{
			Variable[] second = ((dLk)(object)dictionary_0).DLm[(Statement)object_0];
			Variable[] second2 = ((dLk)(object)dictionary_0).CLH[(Statement)object_0];
			for (int i = int_0 + 1; i < statementBlock_0.Statements.Count; i++)
			{
				if (((dLk)(object)dictionary_0).DLm[statementBlock_0.Statements[i]].Intersect(second2).Count() > 0 || ((dLk)(object)dictionary_0).CLH[statementBlock_0.Statements[i]].Intersect(second).Count() > 0)
				{
					return i;
				}
			}
			return statementBlock_0.Statements.Count - 1;
		}

		public static void Wen(StatementBlock statementBlock_0, RandomGenerator randomGenerator_0)
		{
			dLk dLk = new dLk
			{
				ELC = statementBlock_0.Statements.ToArray(),
				DLm = statementBlock_0.Statements.ToDictionary((Statement statement_0) => statement_0, (Statement statement_0) => qeb(statement_0).ToArray()),
				CLH = statementBlock_0.Statements.ToDictionary((Statement statement_0) => statement_0, (Statement statement_0) => Ier(statement_0).ToArray())
			};
			for (int num = 0; num < 20; num++)
			{
				Statement[] eLC = (Statement[])dLk.ELC;
				foreach (Statement statement in eLC)
				{
					int num3 = statementBlock_0.Statements.IndexOf(statement);
					qeb(statement).Concat(Ier(statement)).ToArray();
					int num4 = se3((Dictionary<Statement, Variable[]>)(object)dLk, statement, statementBlock_0, num3);
					int num5 = FeX((Dictionary<Statement, Variable[]>)(object)dLk, statement, statementBlock_0, num3);
					int num6 = num4 + randomGenerator_0.method_2(1, num5 - num4);
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
