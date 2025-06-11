using System.Runtime.CompilerServices;
using XVM.Core.CFG;

namespace XVM.Core.AST.IR
{
	public class IRBlockTarget : IIROperand
	{
		[CompilerGenerated]
		private IBasicBlock Dt6;

		public IBasicBlock Target
		{
			[CompilerGenerated]
			get
			{
				return Dt6;
			}
			[CompilerGenerated]
			set
			{
				Dt6 = value;
			}
		}

		public ASTType Type => ASTType.Ptr;

		public IRBlockTarget(IBasicBlock ibasicBlock_0)
		{
			Target = ibasicBlock_0;
		}

		public override string ToString()
		{
			return $"Block_{Target.Id:x2}";
		}
	}
}
