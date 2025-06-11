using System.Runtime.CompilerServices;
using XVM.Core.RT;

namespace XVM.Core.AST.IR
{
	public class IRDataTarget : IIROperand
	{
		[CompilerGenerated]
		private BinaryChunk ztx;

		[CompilerGenerated]
		private string nts;

		public BinaryChunk Target
		{
			[CompilerGenerated]
			get
			{
				return ztx;
			}
			[CompilerGenerated]
			set
			{
				ztx = value;
			}
		}

		public string Name
		{
			[CompilerGenerated]
			get
			{
				return nts;
			}
			[CompilerGenerated]
			set
			{
				nts = value;
			}
		}

		public ASTType Type => ASTType.Ptr;

		public IRDataTarget(BinaryChunk binaryChunk_0)
		{
			Target = binaryChunk_0;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
