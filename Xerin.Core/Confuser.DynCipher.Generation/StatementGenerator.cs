using System;
using System.Collections.Generic;
using System.Linq;
using Confuser.DynCipher.AST;
using XCore.Generator;

namespace Confuser.DynCipher.Generation
{
	public class StatementGenerator
	{
		private static LoopStatement BFl(LoopStatement loopStatement_0, Expression expression_0, Dictionary<AssignmentStatement, ValueTuple<Expression, Expression>> dictionary_0)
		{
			LoopStatement loopStatement = new LoopStatement
			{
				Begin = loopStatement_0.Begin,
				Limit = loopStatement_0.Limit
			};
			foreach (KeyValuePair<AssignmentStatement, ValueTuple<Expression, Expression>> item in dictionary_0.Reverse())
			{
				loopStatement.Statements.Add(new AssignmentStatement
				{
					Target = expression_0,
					Value = item.Value.Item2
				});
			}
			return loopStatement;
		}

		public static void GeneratePair(RandomGenerator randomGenerator_0, Expression expression_0, Expression expression_1, int int_0, out LoopStatement loopStatement_0, out LoopStatement loopStatement_1)
		{
			loopStatement_0 = new LoopStatement
			{
				Begin = 1,
				Limit = int_0
			};
			Dictionary<AssignmentStatement, ValueTuple<Expression, Expression>> dictionary = new Dictionary<AssignmentStatement, ValueTuple<Expression, Expression>>();
			for (int i = 0; i < int_0; i++)
			{
				Expression expression_2;
				Expression expression_3;
				ExpressionGenerator.GeneratePair(randomGenerator_0, expression_0, expression_1, int_0, out expression_2, out expression_3);
				AssignmentStatement assignmentStatement = new AssignmentStatement
				{
					Target = expression_0,
					Value = expression_2
				};
				dictionary.Add(assignmentStatement, new ValueTuple<Expression, Expression>(expression_2, expression_3));
				loopStatement_0.Statements.Add(assignmentStatement);
			}
			loopStatement_1 = BFl(loopStatement_0, expression_1, dictionary);
		}
	}
}
