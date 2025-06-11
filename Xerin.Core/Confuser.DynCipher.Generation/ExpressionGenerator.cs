#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Confuser.DynCipher.AST;
using XCore.Generator;

namespace Confuser.DynCipher.Generation
{
	public class ExpressionGenerator
	{
		private enum x6z
		{

		}

		private static Expression FFf(RandomGenerator randomGenerator_0, Expression expression_0, int int_0, int int_1)
		{
			if (int_0 == int_1 || (int_0 > int_1 / 3 && randomGenerator_0.NextInt32(100) > 85))
			{
				return expression_0;
			}
			switch ((x6z)randomGenerator_0.NextInt32(6))
			{
			default:
				throw new Exception();
			case (x6z)0:
				return FFf(randomGenerator_0, expression_0, int_0 + 1, int_1) + FFf(randomGenerator_0, (LiteralExpression)randomGenerator_0.NextUInt32(), int_0 + 1, int_1);
			case (x6z)1:
				return FFf(randomGenerator_0, expression_0, int_0 + 1, int_1) - FFf(randomGenerator_0, (LiteralExpression)randomGenerator_0.NextUInt32(), int_0 + 1, int_1);
			case (x6z)2:
				return FFf(randomGenerator_0, expression_0, int_0 + 1, int_1) * (LiteralExpression)(randomGenerator_0.NextUInt32() | 1);
			case (x6z)3:
				return FFf(randomGenerator_0, expression_0, int_0 + 1, int_1) ^ FFf(randomGenerator_0, (LiteralExpression)randomGenerator_0.NextUInt32(), int_0 + 1, int_1);
			case (x6z)4:
				return ~FFf(randomGenerator_0, expression_0, int_0 + 1, int_1);
			case (x6z)5:
				return -FFf(randomGenerator_0, expression_0, int_0 + 1, int_1);
			}
		}

		private static void NFT(RandomGenerator randomGenerator_0, object object_0)
		{
			if (!(object_0 is BinOpExpression))
			{
				if (object_0 is UnaryOpExpression)
				{
					NFT(randomGenerator_0, ((UnaryOpExpression)object_0).Value);
				}
				else if (!(object_0 is LiteralExpression) && !(object_0 is VariableExpression))
				{
					throw new Exception();
				}
				return;
			}
			BinOpExpression binOpExpression = (BinOpExpression)object_0;
			if (randomGenerator_0.NextBoolean())
			{
				Expression left = binOpExpression.Left;
				binOpExpression.Left = binOpExpression.Right;
				binOpExpression.Right = left;
			}
			NFT(randomGenerator_0, binOpExpression.Left);
			NFT(randomGenerator_0, binOpExpression.Right);
		}

		private static bool RFi(object object_0, Dictionary<Expression, bool> dictionary_0)
		{
			bool value;
			if (!dictionary_0.TryGetValue((Expression)object_0, out value))
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
					value = RFi(binOpExpression.Left, dictionary_0) || RFi(binOpExpression.Right, dictionary_0);
				}
				else
				{
					if (!(object_0 is UnaryOpExpression))
					{
						throw new Exception();
					}
					value = RFi(((UnaryOpExpression)object_0).Value, dictionary_0);
				}
				dictionary_0[(Expression)object_0] = value;
			}
			return value;
		}

		private static Expression yFS(object object_0, Expression expression_0, Dictionary<Expression, bool> dictionary_0)
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

		public static void GeneratePair(RandomGenerator randomGenerator_0, Expression expression_0, Expression expression_1, int int_0, out Expression expression_2, out Expression expression_3)
		{
			expression_2 = FFf(randomGenerator_0, expression_0, 0, int_0);
			NFT(randomGenerator_0, expression_2);
			Dictionary<Expression, bool> dictionary_ = new Dictionary<Expression, bool>();
			RFi(expression_2, dictionary_);
			expression_3 = yFS(expression_2, expression_1, dictionary_);
		}
	}
}
