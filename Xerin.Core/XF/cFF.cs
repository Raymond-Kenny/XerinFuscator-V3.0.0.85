using Confuser.DynCipher.AST;

namespace XF
{
	internal class cFF
	{
		private static Expression YFC(object object_0)
		{
			if (object_0 is BinOpExpression)
			{
				BinOpExpression binOpExpression = (BinOpExpression)object_0;
				BinOpExpression binOpExpression2 = binOpExpression.Right as BinOpExpression;
				if (binOpExpression2 != null && binOpExpression2.Operation == binOpExpression.Operation && (binOpExpression.Operation == BinOps.Add || binOpExpression.Operation == BinOps.Mul || binOpExpression.Operation == BinOps.Or || binOpExpression.Operation == BinOps.And || binOpExpression.Operation == BinOps.Xor))
				{
					binOpExpression.Left = new BinOpExpression
					{
						Left = binOpExpression.Left,
						Operation = binOpExpression.Operation,
						Right = binOpExpression2.Left
					};
					binOpExpression.Right = binOpExpression2.Right;
				}
				binOpExpression.Left = YFC(binOpExpression.Left);
				binOpExpression.Right = YFC(binOpExpression.Right);
				if (binOpExpression.Right is LiteralExpression && ((LiteralExpression)binOpExpression.Right).Value == 0 && binOpExpression.Operation == BinOps.Add)
				{
					return binOpExpression.Left;
				}
			}
			else if (object_0 is ArrayIndexExpression)
			{
				((ArrayIndexExpression)object_0).Array = YFC(((ArrayIndexExpression)object_0).Array);
			}
			else if (object_0 is UnaryOpExpression)
			{
				((UnaryOpExpression)object_0).Value = YFC(((UnaryOpExpression)object_0).Value);
			}
			return (Expression)object_0;
		}

		private static void XFe(AssignmentStatement assignmentStatement_0)
		{
			if (assignmentStatement_0 is AssignmentStatement)
			{
				AssignmentStatement assignmentStatement = assignmentStatement_0;
				assignmentStatement.Target = YFC(assignmentStatement.Target);
				assignmentStatement.Value = YFC(assignmentStatement.Value);
			}
		}

		public static void uFJ(StatementBlock statementBlock_0)
		{
			foreach (Statement statement in statementBlock_0.Statements)
			{
				XFe((AssignmentStatement)statement);
			}
		}
	}
}
