using System.Runtime.CompilerServices;
using System.Text;

namespace XVM.Core.AST.ILAST
{
	public class ILASTPhi : ASTNode, IILASTStatement
	{
		[CompilerGenerated]
		private ILASTVariable FcB;

		[CompilerGenerated]
		private ILASTVariable[] bc7;

		public ILASTVariable Variable
		{
			[CompilerGenerated]
			get
			{
				return FcB;
			}
			[CompilerGenerated]
			set
			{
				FcB = value;
			}
		}

		public ILASTVariable[] SourceVariables
		{
			[CompilerGenerated]
			get
			{
				return bc7;
			}
			[CompilerGenerated]
			set
			{
				bc7 = value;
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("{0} = [", Variable);
			for (int i = 0; i < SourceVariables.Length; i++)
			{
				if (i != 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(SourceVariables[i]);
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}
	}
}
