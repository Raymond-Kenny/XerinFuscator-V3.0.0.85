using System;
using System.Runtime.CompilerServices;

namespace Confuser.DynCipher.AST
{
	public class BinOpExpression : Expression
	{
		[CompilerGenerated]
		private Expression zex;

		[CompilerGenerated]
		private Expression Yej;

		[CompilerGenerated]
		private BinOps IeK;

		public Expression Left
		{
			[CompilerGenerated]
			get
			{
				return zex;
			}
			[CompilerGenerated]
			set
			{
				zex = value;
			}
		}

		public Expression Right
		{
			[CompilerGenerated]
			get
			{
				return Yej;
			}
			[CompilerGenerated]
			set
			{
				Yej = value;
			}
		}

		public BinOps Operation
		{
			[CompilerGenerated]
			get
			{
				return IeK;
			}
			[CompilerGenerated]
			set
			{
				IeK = value;
			}
		}

		public override string ToString()
		{
			string arg;
			switch (Operation)
			{
			default:
				throw new Exception();
			case BinOps.Add:
				arg = "+";
				break;
			case BinOps.Sub:
				arg = "-";
				break;
			case BinOps.Div:
				arg = "/";
				break;
			case BinOps.Mul:
				arg = "*";
				break;
			case BinOps.Or:
				arg = "|";
				break;
			case BinOps.And:
				arg = "&";
				break;
			case BinOps.Xor:
				arg = "^";
				break;
			case BinOps.Lsh:
				arg = "<<";
				break;
			case BinOps.Rsh:
				arg = ">>";
				break;
			}
			return $"({Left} {arg} {Right})";
		}
	}
}
