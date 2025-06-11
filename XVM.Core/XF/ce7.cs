using XVM.DynCipher.AST;

namespace XF
{
	internal class ce7
	{
		private static Expression KeD(object object_0)
		{
			if (object_0 is BinOpExpression)
			{
				BinOpExpression binOpExpression = (BinOpExpression)object_0;
				if (binOpExpression.Right is BinOpExpression binOpExpression2 && binOpExpression2.Operation == binOpExpression.Operation && (binOpExpression.Operation == BinOps.Add || binOpExpression.Operation == BinOps.Mul || binOpExpression.Operation == BinOps.Or || binOpExpression.Operation == BinOps.And || binOpExpression.Operation == BinOps.Xor))
				{
					binOpExpression.Left = new BinOpExpression
					{
						Left = binOpExpression.Left,
						Operation = binOpExpression.Operation,
						Right = binOpExpression2.Left
					};
					binOpExpression.Right = binOpExpression2.Right;
				}
				binOpExpression.Left = KeD(binOpExpression.Left);
				binOpExpression.Right = KeD(binOpExpression.Right);
				if (binOpExpression.Right is LiteralExpression && ((LiteralExpression)binOpExpression.Right).Value == 0 && binOpExpression.Operation == BinOps.Add)
				{
					return binOpExpression.Left;
				}
			}
			else if (object_0 is ArrayIndexExpression)
			{
				((ArrayIndexExpression)object_0).Array = KeD(((ArrayIndexExpression)object_0).Array);
			}
			else if (object_0 is UnaryOpExpression)
			{
				((UnaryOpExpression)object_0).Value = KeD(((UnaryOpExpression)object_0).Value);
			}
			return (Expression)object_0;
		}

		private static void rey(AssignmentStatement assignmentStatement_0)
		{
			if (assignmentStatement_0 is AssignmentStatement)
			{
				AssignmentStatement assignmentStatement = assignmentStatement_0;
				assignmentStatement.Target = KeD(assignmentStatement.Target);
				assignmentStatement.Value = KeD(assignmentStatement.Value);
			}
		}

		public static void ceY(StatementBlock statementBlock_0)
		{
			foreach (Statement statement in statementBlock_0.Statements)
			{
				rey((AssignmentStatement)statement);
			}
		}
	}
}
