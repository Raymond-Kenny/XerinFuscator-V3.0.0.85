using System.Runtime.CompilerServices;

namespace Confuser.DynCipher.AST
{
	public class Variable
	{
		[CompilerGenerated]
		private string Kek;

		[CompilerGenerated]
		private object veu;

		public string Name
		{
			[CompilerGenerated]
			get
			{
				return Kek;
			}
			[CompilerGenerated]
			set
			{
				Kek = value;
			}
		}

		public object Tag
		{
			[CompilerGenerated]
			get
			{
				return veu;
			}
			[CompilerGenerated]
			set
			{
				veu = value;
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
