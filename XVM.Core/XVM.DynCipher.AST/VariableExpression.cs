using System.Runtime.CompilerServices;

namespace XVM.DynCipher.AST
{
	public class VariableExpression : Expression
	{
		[CompilerGenerated]
		private Variable IG2;

		public Variable Variable
		{
			[CompilerGenerated]
			get
			{
				return IG2;
			}
			[CompilerGenerated]
			set
			{
				IG2 = value;
			}
		}

		public override string ToString()
		{
			return Variable.Name;
		}
	}
}
