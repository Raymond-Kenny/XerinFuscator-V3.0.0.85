using System.Collections.Generic;
using System.Linq;
using XVM.Core.Helpers.System.Runtime.CompilerServices;
using XVM.Core.Services;
using XVM.DynCipher.AST;

namespace XF
{
	internal class IuS
	{
		private static LoopStatement Jua(LoopStatement loopStatement_0, Expression expression_0, [TupleElementNames(new string[] { "encode", "inverse" })] Dictionary<AssignmentStatement, (Expression, Expression)> assignments)
		{
			LoopStatement loopStatement = new LoopStatement
			{
				Begin = loopStatement_0.Begin,
				Limit = loopStatement_0.Limit
			};
			foreach (KeyValuePair<AssignmentStatement, (Expression, Expression)> item in assignments.Reverse())
			{
				loopStatement.Statements.Add(new AssignmentStatement
				{
					Target = expression_0,
					Value = item.Value.Item2
				});
			}
			return loopStatement;
		}

		public static void XuU(RandomGenerator randomGenerator_0, Expression expression_0, Expression expression_1, int int_0, out LoopStatement loopStatement_0, out LoopStatement loopStatement_1)
		{
			loopStatement_0 = new LoopStatement
			{
				Begin = 0,
				Limit = int_0
			};
			Dictionary<AssignmentStatement, (Expression, Expression)> dictionary = new Dictionary<AssignmentStatement, (Expression, Expression)>();
			for (int i = 0; i < int_0; i++)
			{
				Tum.vuT(randomGenerator_0, expression_0, expression_1, int_0, out var expression_2, out var expression_3);
				AssignmentStatement assignmentStatement = new AssignmentStatement
				{
					Target = expression_0,
					Value = expression_2
				};
				dictionary.Add(assignmentStatement, (expression_2, expression_3));
				loopStatement_0.Statements.Add(assignmentStatement);
			}
			loopStatement_1 = Jua(loopStatement_0, expression_1, dictionary);
		}
	}
}
