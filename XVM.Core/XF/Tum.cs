#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using XVM.Core.Services;
using XVM.DynCipher;
using XVM.DynCipher.AST;

namespace XF
{
	internal class Tum
	{
		private enum jkH
		{

		}

		private static Expression ou5(RandomGenerator randomGenerator_0, Expression expression_0, int int_0, int int_1)
		{
			if (int_0 != int_1 && (int_0 <= int_1 / 3 || randomGenerator_0.method_1(100) <= 85))
			{
				switch ((jkH)randomGenerator_0.method_1(6))
				{
				default:
					throw new NIS();
				case (jkH)0:
					return ou5(randomGenerator_0, expression_0, int_0 + 1, int_1) + ou5(randomGenerator_0, (LiteralExpression)randomGenerator_0.method_3(), int_0 + 1, int_1);
				case (jkH)1:
					return ou5(randomGenerator_0, expression_0, int_0 + 1, int_1) - ou5(randomGenerator_0, (LiteralExpression)randomGenerator_0.method_3(), int_0 + 1, int_1);
				case (jkH)2:
					return ou5(randomGenerator_0, expression_0, int_0 + 1, int_1) * (LiteralExpression)(randomGenerator_0.method_3() | 1);
				case (jkH)3:
					return ou5(randomGenerator_0, expression_0, int_0 + 1, int_1) ^ ou5(randomGenerator_0, (LiteralExpression)randomGenerator_0.method_3(), int_0 + 1, int_1);
				case (jkH)4:
					return ~ou5(randomGenerator_0, expression_0, int_0 + 1, int_1);
				case (jkH)5:
					return -ou5(randomGenerator_0, expression_0, int_0 + 1, int_1);
				}
			}
			return expression_0;
		}

		private static void zuo(RandomGenerator randomGenerator_0, object object_0)
		{
			if (object_0 is BinOpExpression)
			{
				BinOpExpression binOpExpression = (BinOpExpression)object_0;
				if (randomGenerator_0.NextBoolean())
				{
					Expression left = binOpExpression.Left;
					binOpExpression.Left = binOpExpression.Right;
					binOpExpression.Right = left;
				}
				zuo(randomGenerator_0, binOpExpression.Left);
				zuo(randomGenerator_0, binOpExpression.Right);
			}
			else if (object_0 is UnaryOpExpression)
			{
				zuo(randomGenerator_0, ((UnaryOpExpression)object_0).Value);
			}
			else if (!(object_0 is LiteralExpression) && !(object_0 is VariableExpression))
			{
				throw new NIS();
			}
		}

		private static bool Aul(object object_0, Dictionary<Expression, bool> dictionary_0)
		{
			if (!dictionary_0.TryGetValue((Expression)object_0, out var value))
			{
				if (object_0 is VariableExpression)
				{
					value = true;
				}
				else if (object_0 is LiteralExpression)
				{
					value = false;
				}
				else if (object_0 is BinOpExpression)
				{
					BinOpExpression binOpExpression = (BinOpExpression)object_0;
					value = Aul(binOpExpression.Left, dictionary_0) || Aul(binOpExpression.Right, dictionary_0);
				}
				else
				{
					if (!(object_0 is UnaryOpExpression))
					{
						throw new NIS();
					}
					value = Aul(((UnaryOpExpression)object_0).Value, dictionary_0);
				}
				dictionary_0[(Expression)object_0] = value;
			}
			return value;
		}

		private static Expression UuZ(object object_0, Expression expression_0, Dictionary<Expression, bool> dictionary_0)
		{
			Expression expression = expression_0;
			while (!(object_0 is VariableExpression))
			{
				Debug.Assert(dictionary_0[(Expression)object_0]);
				if (object_0 is UnaryOpExpression)
				{
					UnaryOpExpression unaryOpExpression = (UnaryOpExpression)object_0;
					expression = new UnaryOpExpression
					{
						Operation = unaryOpExpression.Operation,
						Value = expression
					};
					object_0 = unaryOpExpression.Value;
				}
				else if (object_0 is BinOpExpression)
				{
					BinOpExpression binOpExpression = (BinOpExpression)object_0;
					bool flag;
					Expression expression2 = ((flag = dictionary_0[binOpExpression.Left]) ? binOpExpression.Left : binOpExpression.Right);
					Expression expression3 = (flag ? binOpExpression.Right : binOpExpression.Left);
					if (binOpExpression.Operation == BinOps.Add)
					{
						expression = new BinOpExpression
						{
							Operation = BinOps.Sub,
							Left = expression,
							Right = expression3
						};
					}
					else if (binOpExpression.Operation == BinOps.Sub)
					{
						expression = ((!flag) ? new BinOpExpression
						{
							Operation = BinOps.Sub,
							Left = expression3,
							Right = expression
						} : new BinOpExpression
						{
							Operation = BinOps.Add,
							Left = expression,
							Right = expression3
						});
					}
					else if (binOpExpression.Operation == BinOps.Mul)
					{
						Debug.Assert(expression3 is LiteralExpression);
						uint value = ((LiteralExpression)expression3).Value;
						value = MathsUtils.modInv(value);
						expression = new BinOpExpression
						{
							Operation = BinOps.Mul,
							Left = expression,
							Right = (LiteralExpression)value
						};
					}
					else if (binOpExpression.Operation == BinOps.Xor)
					{
						expression = new BinOpExpression
						{
							Operation = BinOps.Xor,
							Left = expression,
							Right = expression3
						};
					}
					object_0 = expression2;
				}
			}
			return expression;
		}

		public static void vuT(RandomGenerator randomGenerator_0, Expression expression_0, Expression expression_1, int int_0, out Expression expression_2, out Expression expression_3)
		{
			expression_2 = ou5(randomGenerator_0, expression_0, 0, int_0);
			zuo(randomGenerator_0, expression_2);
			Dictionary<Expression, bool> dictionary_ = new Dictionary<Expression, bool>();
			Aul(expression_2, dictionary_);
			expression_3 = UuZ(expression_2, expression_1, dictionary_);
		}
	}
}
