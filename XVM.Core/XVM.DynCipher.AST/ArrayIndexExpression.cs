using System.Runtime.CompilerServices;

namespace XVM.DynCipher.AST
{
	public class ArrayIndexExpression : Expression
	{
		[CompilerGenerated]
		private Expression F9J;

		[CompilerGenerated]
		private int g98;

		public Expression Array
		{
			[CompilerGenerated]
			get
			{
				return F9J;
			}
			[CompilerGenerated]
			set
			{
				F9J = value;
			}
		}

		public int Index
		{
			[CompilerGenerated]
			get
			{
				return g98;
			}
			[CompilerGenerated]
			set
			{
				g98 = value;
			}
		}

		public override string ToString()
		{
			return $"{Array}[{Index}]";
		}
	}
}
