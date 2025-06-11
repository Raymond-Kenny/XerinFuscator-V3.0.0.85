using System.Runtime.CompilerServices;

namespace Confuser.DynCipher.AST
{
	public class VariableExpression : Expression
	{
		[CompilerGenerated]
		private Variable Ge3;

		public Variable Variable
		{
			[CompilerGenerated]
			get
			{
				return Ge3;
			}
			[CompilerGenerated]
			set
			{
				Ge3 = value;
			}
		}

		public override string ToString()
		{
			return Variable.Name;
		}
	}
}
