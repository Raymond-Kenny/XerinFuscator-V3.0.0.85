using System.Runtime.CompilerServices;

namespace XVM.Core.AST
{
	public class InstrAnnotation
	{
		[CompilerGenerated]
		private string ttD;

		public static readonly InstrAnnotation JUMP;

		public string Name
		{
			[CompilerGenerated]
			get
			{
				return ttD;
			}
			[CompilerGenerated]
			private set
			{
				ttD = value;
			}
		}

		public InstrAnnotation(string string_0)
		{
			Name = string_0;
		}

		public override string ToString()
		{
			return Name;
		}

		static InstrAnnotation()
		{
			JUMP = new InstrAnnotation("JUMP");
		}
	}
}
