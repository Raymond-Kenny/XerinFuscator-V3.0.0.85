using System.Runtime.CompilerServices;

namespace Confuser.DynCipher.AST
{
	public abstract class Statement
	{
		[CompilerGenerated]
		private object Eec;

		public object Tag
		{
			[CompilerGenerated]
			get
			{
				return Eec;
			}
			[CompilerGenerated]
			set
			{
				Eec = value;
			}
		}

		public abstract override string ToString();
	}
}
