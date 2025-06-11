using System;
using System.Runtime.CompilerServices;

namespace XVM.DynCipher.AST
{
	public class BinOpExpression : Expression
	{
		[CompilerGenerated]
		private Expression SGe;

		[CompilerGenerated]
		private Expression zGu;

		[CompilerGenerated]
		private BinOps GG9;

		public Expression Left
		{
			[CompilerGenerated]
			get
			{
				return SGe;
			}
			[CompilerGenerated]
			set
			{
				SGe = value;
			}
		}

		public Expression Right
		{
			[CompilerGenerated]
			get
			{
				return zGu;
			}
			[CompilerGenerated]
			set
			{
				zGu = value;
			}
		}

		public BinOps Operation
		{
			[CompilerGenerated]
			get
			{
				return GG9;
			}
			[CompilerGenerated]
			set
			{
				GG9 = value;
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
