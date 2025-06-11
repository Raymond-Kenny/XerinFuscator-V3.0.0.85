using System;
using System.Runtime.CompilerServices;

namespace XVM.DynCipher.AST
{
	public class UnaryOpExpression : Expression
	{
		[CompilerGenerated]
		private Expression mGw;

		[CompilerGenerated]
		private UnaryOps YGW;

		public Expression Value
		{
			[CompilerGenerated]
			get
			{
				return mGw;
			}
			[CompilerGenerated]
			set
			{
				mGw = value;
			}
		}

		public UnaryOps Operation
		{
			[CompilerGenerated]
			get
			{
				return YGW;
			}
			[CompilerGenerated]
			set
			{
				YGW = value;
			}
		}

		public override string ToString()
		{
			string text;
			switch (Operation)
			{
			default:
				throw new Exception();
			case UnaryOps.Negate:
				text = "-";
				break;
			case UnaryOps.Not:
				text = "~";
				break;
			}
			return text + Value;
		}
	}
}
