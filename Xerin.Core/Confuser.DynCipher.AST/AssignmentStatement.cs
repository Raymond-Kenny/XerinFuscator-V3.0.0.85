using System.Runtime.CompilerServices;

namespace Confuser.DynCipher.AST
{
	public class AssignmentStatement : Statement
	{
		[CompilerGenerated]
		private Expression je1;

		[CompilerGenerated]
		private Expression Yev;

		public Expression Target
		{
			[CompilerGenerated]
			get
			{
				return je1;
			}
			[CompilerGenerated]
			set
			{
				je1 = value;
			}
		}

		public Expression Value
		{
			[CompilerGenerated]
			get
			{
				return Yev;
			}
			[CompilerGenerated]
			set
			{
				Yev = value;
			}
		}

		public override string ToString()
		{
			return $"{Target} = {Value};";
		}
	}
}
