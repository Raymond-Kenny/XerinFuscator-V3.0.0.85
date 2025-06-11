using System.Runtime.CompilerServices;

namespace Confuser.DynCipher.AST
{
	public class LiteralExpression : Expression
	{
		[CompilerGenerated]
		private uint jen;

		public uint Value
		{
			[CompilerGenerated]
			get
			{
				return jen;
			}
			[CompilerGenerated]
			set
			{
				jen = value;
			}
		}

		public static implicit operator LiteralExpression(uint uint_0)
		{
			return new LiteralExpression
			{
				Value = uint_0
			};
		}

		public override string ToString()
		{
			return Value.ToString("x8") + "h";
		}
	}
}
