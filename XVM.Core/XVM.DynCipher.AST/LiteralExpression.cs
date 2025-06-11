using System.Runtime.CompilerServices;

namespace XVM.DynCipher.AST
{
	public class LiteralExpression : Expression
	{
		[CompilerGenerated]
		private uint MGI;

		public uint Value
		{
			[CompilerGenerated]
			get
			{
				return MGI;
			}
			[CompilerGenerated]
			set
			{
				MGI = value;
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
