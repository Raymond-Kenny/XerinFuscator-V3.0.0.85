using System.Runtime.CompilerServices;
using XVM.Core.CFG;

namespace XVM.Core.AST.IR
{
	public class IRJumpTable : IIROperand
	{
		[CompilerGenerated]
		private IBasicBlock[] Hc4;

		public IBasicBlock[] Targets
		{
			[CompilerGenerated]
			get
			{
				return Hc4;
			}
			[CompilerGenerated]
			set
			{
				Hc4 = value;
			}
		}

		public ASTType Type => ASTType.Ptr;

		public IRJumpTable(IBasicBlock[] ibasicBlock_0)
		{
			Targets = ibasicBlock_0;
		}

		public override string ToString()
		{
			return $"[..{Targets.Length}..]";
		}
	}
}
