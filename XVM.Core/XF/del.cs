using XVM.DynCipher.AST;

namespace XF
{
	internal class del
	{
		private static Expression OeZ(object object_0, Variable variable_0)
		{
			if (!(object_0 is VariableExpression))
			{
				if (!(object_0 is ArrayIndexExpression))
				{
					if (object_0 is BinOpExpression)
					{
						((BinOpExpression)object_0).Left = OeZ(((BinOpExpression)object_0).Left, variable_0);
						((BinOpExpression)object_0).Right = OeZ(((BinOpExpression)object_0).Right, variable_0);
					}
					else if (object_0 is UnaryOpExpression)
					{
						((UnaryOpExpression)object_0).Value = OeZ(((UnaryOpExpression)object_0).Value, variable_0);
					}
				}
				else
				{
					((ArrayIndexExpression)object_0).Array = OeZ(((ArrayIndexExpression)object_0).Array, variable_0);
				}
				return (Expression)object_0;
			}
			if (((VariableExpression)object_0).Variable.Name[0] != 'v')
			{
				return (Expression)object_0;
			}
			ArrayIndexExpression arrayIndexExpression = new ArrayIndexExpression();
			arrayIndexExpression.Array = new VariableExpression
			{
				Variable = variable_0
			};
			arrayIndexExpression.Index = (int)(object_0 as VariableExpression).Variable.Tag;
			return arrayIndexExpression;
		}

		private static Statement QeT(object object_0, Variable variable_0)
		{
			if (object_0 is AssignmentStatement)
			{
				((AssignmentStatement)object_0).Value = OeZ(((AssignmentStatement)object_0).Value, variable_0);
				((AssignmentStatement)object_0).Target = OeZ(((AssignmentStatement)object_0).Target, variable_0);
			}
			return (Statement)object_0;
		}

		public static void QeS(StatementBlock statementBlock_0)
		{
			Variable variable_ = new Variable("{BUFFER}");
			for (int i = 0; i < statementBlock_0.Statements.Count; i++)
			{
				statementBlock_0.Statements[i] = QeT(statementBlock_0.Statements[i], variable_);
			}
		}
	}
}
