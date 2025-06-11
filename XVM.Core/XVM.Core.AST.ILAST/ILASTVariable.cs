using System.Runtime.CompilerServices;

namespace XVM.Core.AST.ILAST
{
	public class ILASTVariable : ASTVariable, IILASTNode
	{
		[CompilerGenerated]
		private ILASTVariableType acp;

		[CompilerGenerated]
		private object Rcr;

		ASTType? IILASTNode.Type => base.Type;

		public ILASTVariableType VariableType
		{
			[CompilerGenerated]
			get
			{
				return acp;
			}
			[CompilerGenerated]
			set
			{
				acp = value;
			}
		}

		public object Annotation
		{
			[CompilerGenerated]
			get
			{
				return Rcr;
			}
			[CompilerGenerated]
			set
			{
				Rcr = value;
			}
		}
	}
}
