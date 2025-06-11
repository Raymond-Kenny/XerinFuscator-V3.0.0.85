using System.Runtime.CompilerServices;

namespace Confuser.DynCipher.AST
{
	public abstract class Expression
	{
		[CompilerGenerated]
		private object Ee4;

		public object Tag
		{
			[CompilerGenerated]
			get
			{
				return Ee4;
			}
			[CompilerGenerated]
			set
			{
				Ee4 = value;
			}
		}

		public abstract override string ToString();

		public static BinOpExpression operator +(Expression expression_0, Expression expression_1)
		{
			return new BinOpExpression
			{
				Left = expression_0,
				Right = expression_1,
				Operation = BinOps.Add
			};
		}

		public static BinOpExpression operator -(Expression expression_0, Expression expression_1)
		{
			return new BinOpExpression
			{
				Left = expression_0,
				Right = expression_1,
				Operation = BinOps.Sub
			};
		}

		public static BinOpExpression operator *(Expression expression_0, Expression expression_1)
		{
			return new BinOpExpression
			{
				Left = expression_0,
				Right = expression_1,
				Operation = BinOps.Mul
			};
		}

		public static BinOpExpression operator >>(Expression expression_0, int int_0)
		{
			return new BinOpExpression
			{
				Left = expression_0,
				Right = (LiteralExpression)(uint)int_0,
				Operation = BinOps.Rsh
			};
		}

		public static BinOpExpression operator <<(Expression expression_0, int int_0)
		{
			return new BinOpExpression
			{
				Left = expression_0,
				Right = (LiteralExpression)(uint)int_0,
				Operation = BinOps.Lsh
			};
		}

		public static BinOpExpression operator |(Expression expression_0, Expression expression_1)
		{
			return new BinOpExpression
			{
				Left = expression_0,
				Right = expression_1,
				Operation = BinOps.Or
			};
		}

		public static BinOpExpression operator &(Expression expression_0, Expression expression_1)
		{
			return new BinOpExpression
			{
				Left = expression_0,
				Right = expression_1,
				Operation = BinOps.And
			};
		}

		public static BinOpExpression operator ^(Expression expression_0, Expression expression_1)
		{
			return new BinOpExpression
			{
				Left = expression_0,
				Right = expression_1,
				Operation = BinOps.Xor
			};
		}

		public static UnaryOpExpression operator ~(Expression expression_0)
		{
			return new UnaryOpExpression
			{
				Value = expression_0,
				Operation = UnaryOps.Not
			};
		}

		public static UnaryOpExpression operator -(Expression expression_0)
		{
			return new UnaryOpExpression
			{
				Value = expression_0,
				Operation = UnaryOps.Negate
			};
		}
	}
}
