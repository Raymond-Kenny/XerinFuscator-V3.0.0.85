using System.Runtime.CompilerServices;

namespace XVM.DynCipher.AST
{
	public class Variable
	{
		[CompilerGenerated]
		private string jGE;

		[CompilerGenerated]
		private object pGN;

		public string Name
		{
			[CompilerGenerated]
			get
			{
				return jGE;
			}
			[CompilerGenerated]
			set
			{
				jGE = value;
			}
		}

		public object Tag
		{
			[CompilerGenerated]
			get
			{
				return pGN;
			}
			[CompilerGenerated]
			set
			{
				pGN = value;
			}
		}

		public Variable(string string_0)
		{
			Name = string_0;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
