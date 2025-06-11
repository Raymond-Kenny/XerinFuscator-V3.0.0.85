using System.Collections.Generic;
using System.Linq;
using Confuser.DynCipher.AST;

namespace XF
{
	internal class JQz
	{
		private static uint lFN(uint uint_0)
		{
			uint_0 -= (uint_0 >> 1) & 0x55555555;
			uint_0 = (uint_0 & 0x33333333) + ((uint_0 >> 2) & 0x33333333);
			return ((uint_0 + (uint_0 >> 4)) & 0xF0F0F0F) * 16843009 >> 24;
		}

		private static Expression OFU(object object_0)
		{
			if (object_0 is BinOpExpression)
			{
				BinOpExpression binOpExpression = (BinOpExpression)object_0;
				if (binOpExpression.Operation == BinOps.Mul && binOpExpression.Right is LiteralExpression)
				{
					uint num = ((LiteralExpression)binOpExpression.Right).Value;
					switch (num)
					{
					case 1u:
						return binOpExpression.Left;
					case 0u:
						return (LiteralExpression)0u;
					}
					uint num2 = lFN(num);
					if (num2 <= 2)
					{
						List<Expression> list = new List<Expression>();
						int num3 = 0;
						while (num != 0)
						{
							if ((num & 1) != 0)
							{
								if (num3 == 0)
								{
									list.Add(binOpExpression.Left);
								}
								else
								{
									list.Add(binOpExpression.Left << num3);
								}
							}
							num >>= 1;
							num3++;
						}
						BinOpExpression binOpExpression2 = list.OfType<BinOpExpression>().First();
						foreach (Expression item in list.Except(new BinOpExpression[1] { binOpExpression2 }))
						{
							binOpExpression2 += item;
						}
						return binOpExpression2;
					}
				}
				else
				{
					binOpExpression.Left = OFU(binOpExpression.Left);
					binOpExpression.Right = OFU(binOpExpression.Right);
				}
			}
			else if (object_0 is ArrayIndexExpression)
			{
				((ArrayIndexExpression)object_0).Array = OFU(((ArrayIndexExpression)object_0).Array);
			}
			else if (object_0 is UnaryOpExpression)
			{
				((UnaryOpExpression)object_0).Value = OFU(((UnaryOpExpression)object_0).Value);
			}
			return (Expression)object_0;
		}

		private static void tFY(AssignmentStatement assignmentStatement_0)
		{
			if (assignmentStatement_0 is AssignmentStatement)
			{
				AssignmentStatement assignmentStatement = assignmentStatement_0;
				assignmentStatement.Target = OFU(assignmentStatement.Target);
				assignmentStatement.Value = OFU(assignmentStatement.Value);
			}
		}

		public static void DFQ(StatementBlock statementBlock_0)
		{
			foreach (Statement statement in statementBlock_0.Statements)
			{
				tFY((AssignmentStatement)statement);
			}
		}
	}
}
