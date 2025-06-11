using System.Runtime.CompilerServices;

namespace XVM.Core.AST.IR
{
	public class IRPointer : IIROperand
	{
		[CompilerGenerated]
		private IRRegister rc9;

		[CompilerGenerated]
		private int NcG;

		[CompilerGenerated]
		private IRVariable CcI;

		[CompilerGenerated]
		private ASTType Tcq;

		public IRRegister Register
		{
			[CompilerGenerated]
			get
			{
				return rc9;
			}
			[CompilerGenerated]
			set
			{
				rc9 = value;
			}
		}

		public int Offset
		{
			[CompilerGenerated]
			get
			{
				return NcG;
			}
			[CompilerGenerated]
			set
			{
				NcG = value;
			}
		}

		public IRVariable SourceVariable
		{
			[CompilerGenerated]
			get
			{
				return CcI;
			}
			[CompilerGenerated]
			set
			{
				CcI = value;
			}
		}

		public ASTType Type
		{
			[CompilerGenerated]
			get
			{
				return Tcq;
			}
			[CompilerGenerated]
			set
			{
				Tcq = value;
			}
		}

		public override string ToString()
		{
			string arg = Type.ToString();
			string arg2 = "";
			if (Offset > 0)
			{
				arg2 = $" + {Offset:x}h";
			}
			else if (Offset < 0)
			{
				arg2 = $" - {-Offset:x}h";
			}
			return $"{arg}:[{Register}{arg2}]";
		}
	}
}
