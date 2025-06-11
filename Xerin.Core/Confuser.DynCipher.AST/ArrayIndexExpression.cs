using System.Runtime.CompilerServices;

namespace Confuser.DynCipher.AST
{
	public class ArrayIndexExpression : Expression
	{
		[CompilerGenerated]
		private Expression aeo;

		[CompilerGenerated]
		private int eeD;

		public Expression Array
		{
			[CompilerGenerated]
			get
			{
				return aeo;
			}
			[CompilerGenerated]
			set
			{
				aeo = value;
			}
		}

		public int Index
		{
			[CompilerGenerated]
			get
			{
				return eeD;
			}
			[CompilerGenerated]
			set
			{
				eeD = value;
			}
		}

		public override string ToString()
		{
			return $"{Array}[{Index}]";
		}
	}
}
