using System.Runtime.CompilerServices;

namespace XVM.Core.AST
{
	public class ASTVariable
	{
		[CompilerGenerated]
		private ASTType htd;

		[CompilerGenerated]
		private string qtB;

		public ASTType Type
		{
			[CompilerGenerated]
			get
			{
				return htd;
			}
			[CompilerGenerated]
			set
			{
				htd = value;
			}
		}

		public string Name
		{
			[CompilerGenerated]
			get
			{
				return qtB;
			}
			[CompilerGenerated]
			set
			{
				qtB = value;
			}
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
