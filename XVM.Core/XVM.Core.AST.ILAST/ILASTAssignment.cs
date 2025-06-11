using System.Runtime.CompilerServices;

namespace XVM.Core.AST.ILAST
{
	public class ILASTAssignment : ASTNode, IILASTStatement
	{
		[CompilerGenerated]
		private ILASTVariable lca;

		[CompilerGenerated]
		private ILASTExpression tcU;

		public ILASTVariable Variable
		{
			[CompilerGenerated]
			get
			{
				return lca;
			}
			[CompilerGenerated]
			set
			{
				lca = value;
			}
		}

		public ILASTExpression Value
		{
			[CompilerGenerated]
			get
			{
				return tcU;
			}
			[CompilerGenerated]
			set
			{
				tcU = value;
			}
		}

		public override string ToString()
		{
			return $"{Variable} = {Value}";
		}
	}
}
