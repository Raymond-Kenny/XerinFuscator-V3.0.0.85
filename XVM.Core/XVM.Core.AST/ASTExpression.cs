using System.Runtime.CompilerServices;

namespace XVM.Core.AST
{
	public abstract class ASTExpression : ASTNode
	{
		[CompilerGenerated]
		private ASTType? Jtv;

		public ASTType? Type
		{
			[CompilerGenerated]
			get
			{
				return Jtv;
			}
			[CompilerGenerated]
			set
			{
				Jtv = value;
			}
		}
	}
}
