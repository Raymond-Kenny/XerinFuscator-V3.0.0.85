using System.Runtime.CompilerServices;

namespace XVM.DynCipher.AST
{
	public abstract class Statement
	{
		[CompilerGenerated]
		private object vGA;

		public object Tag
		{
			[CompilerGenerated]
			get
			{
				return vGA;
			}
			[CompilerGenerated]
			set
			{
				vGA = value;
			}
		}

		public abstract override string ToString();
	}
}
