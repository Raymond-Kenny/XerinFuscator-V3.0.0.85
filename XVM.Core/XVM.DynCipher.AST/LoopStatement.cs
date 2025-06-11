using System.Runtime.CompilerServices;
using System.Text;

namespace XVM.DynCipher.AST
{
	public class LoopStatement : StatementBlock
	{
		[CompilerGenerated]
		private int VGq;

		[CompilerGenerated]
		private int fGM;

		public int Begin
		{
			[CompilerGenerated]
			get
			{
				return VGq;
			}
			[CompilerGenerated]
			set
			{
				VGq = value;
			}
		}

		public int Limit
		{
			[CompilerGenerated]
			get
			{
				return fGM;
			}
			[CompilerGenerated]
			set
			{
				fGM = value;
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
