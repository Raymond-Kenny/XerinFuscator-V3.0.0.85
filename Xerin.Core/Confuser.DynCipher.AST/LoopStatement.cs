using System.Runtime.CompilerServices;
using System.Text;

namespace Confuser.DynCipher.AST
{
	public class LoopStatement : StatementBlock
	{
		[CompilerGenerated]
		private int oeh;

		[CompilerGenerated]
		private int Her;

		public int Begin
		{
			[CompilerGenerated]
			get
			{
				return oeh;
			}
			[CompilerGenerated]
			set
			{
				oeh = value;
			}
		}

		public int Limit
		{
			[CompilerGenerated]
			get
			{
				return Her;
			}
			[CompilerGenerated]
			set
			{
				Her = value;
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("for (int i = {0}; i < {1}; i++)", Begin, Limit);
			stringBuilder.AppendLine();
			stringBuilder.Append(base.ToString());
			return stringBuilder.ToString();
		}
	}
}
