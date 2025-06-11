using System.Runtime.CompilerServices;
using XVM.Core.CFG;

namespace XVM.Core.AST.IL
{
	public class ILBlockTarget : IILOperand, IHasOffset
	{
		[CompilerGenerated]
		private IBasicBlock Dcm;

		public IBasicBlock Target
		{
			[CompilerGenerated]
			get
			{
				return Dcm;
			}
			[CompilerGenerated]
			set
			{
				Dcm = value;
			}
		}

		public uint Offset => ((ILBlock)Target).Content[0].Offset;

		public ILBlockTarget(IBasicBlock ibasicBlock_0)
		{
			Target = ibasicBlock_0;
		}

		public override string ToString()
		{
			return $"Block_{Target.Id:x2}";
		}
	}
}
