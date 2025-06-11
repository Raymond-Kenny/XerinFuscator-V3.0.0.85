using System;
using System.Runtime.CompilerServices;

namespace Confuser.DynCipher.AST
{
	public class UnaryOpExpression : Expression
	{
		[CompilerGenerated]
		private Expression uey;

		[CompilerGenerated]
		private UnaryOps Feb;

		public Expression Value
		{
			[CompilerGenerated]
			get
			{
				return uey;
			}
			[CompilerGenerated]
			set
			{
				uey = value;
			}
		}

		public UnaryOps Operation
		{
			[CompilerGenerated]
			get
			{
				return Feb;
			}
			[CompilerGenerated]
			set
			{
				Feb = value;
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
