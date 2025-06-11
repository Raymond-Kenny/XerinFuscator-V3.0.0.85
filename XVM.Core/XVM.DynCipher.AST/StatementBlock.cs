using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace XVM.DynCipher.AST
{
	public class StatementBlock : Statement
	{
		[CompilerGenerated]
		private IList<Statement> GG0;

		public IList<Statement> Statements
		{
			[CompilerGenerated]
			get
			{
				return GG0;
			}
			[CompilerGenerated]
			private set
			{
				GG0 = value;
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
