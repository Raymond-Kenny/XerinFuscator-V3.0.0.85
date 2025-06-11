using System.Runtime.CompilerServices;

namespace XVM.DynCipher.AST
{
	public class AssignmentStatement : Statement
	{
		[CompilerGenerated]
		private Expression k9z;

		[CompilerGenerated]
		private Expression SG4;

		public Expression Target
		{
			[CompilerGenerated]
			get
			{
				return k9z;
			}
			[CompilerGenerated]
			set
			{
				k9z = value;
			}
		}

		public Expression Value
		{
			[CompilerGenerated]
			get
			{
				return SG4;
			}
			[CompilerGenerated]
			set
			{
				SG4 = value;
			}
		}

		public override string ToString()
		{
			return $"{Target} = {Value};";
		}
	}
}
