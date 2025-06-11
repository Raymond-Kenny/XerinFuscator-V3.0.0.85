using System.Linq;
using XVM.DynCipher.AST;

namespace XF
{
	internal class gea
	{
		private static bool jeU(AssignmentStatement assignmentStatement_0, StatementBlock statementBlock_0)
		{
			if (assignmentStatement_0 is AssignmentStatement)
			{
				AssignmentStatement assignmentStatement = assignmentStatement_0;
				if (assignmentStatement.Value is BinOpExpression)
				{
					BinOpExpression binOpExpression = (BinOpExpression)assignmentStatement.Value;
					if ((binOpExpression.Left is BinOpExpression || binOpExpression.Right is BinOpExpression) && binOpExpression.Left != assignmentStatement.Target)
					{
						statementBlock_0.Statements.Add(new AssignmentStatement
						{
							Target = assignmentStatement.Target,
							Value = binOpExpression.Left
						});
						statementBlock_0.Statements.Add(new AssignmentStatement
						{
							Target = assignmentStatement.Target,
							Value = new BinOpExpression
							{
								Left = assignmentStatement.Target,
								Operation = binOpExpression.Operation,
								Right = binOpExpression.Right
							}
						});
						return true;
					}
				}
			}
			statementBlock_0.Statements.Add(assignmentStatement_0);
			return false;
		}

		public static void ieh(StatementBlock statementBlock_0)
		{
			bool flag;
			do
			{
				flag = false;
				Statement[] array = statementBlock_0.Statements.ToArray();
				statementBlock_0.Statements.Clear();
				Statement[] array2 = array;
				foreach (Statement assignmentStatement_ in array2)
				{
					flag |= jeU((AssignmentStatement)assignmentStatement_, statementBlock_0);
				}
			}
			while (flag);
		}
	}
}
