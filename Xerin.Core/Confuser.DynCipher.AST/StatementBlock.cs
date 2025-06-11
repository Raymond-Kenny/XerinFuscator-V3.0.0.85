using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Confuser.DynCipher.AST
{
	public class StatementBlock : Statement
	{
		[CompilerGenerated]
		private IList<Statement> ieq;

		public IList<Statement> Statements
		{
			[CompilerGenerated]
			get
			{
				return ieq;
			}
			[CompilerGenerated]
			private set
			{
				ieq = value;
			}
		}

		public StatementBlock()
		{
			Statements = new List<Statement>();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("{");
			foreach (Statement statement in Statements)
			{
				stringBuilder.AppendLine(statement.ToString());
			}
			stringBuilder.AppendLine("}");
			return stringBuilder.ToString();
		}
	}
}
