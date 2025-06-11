using System.Runtime.CompilerServices;
using XVM.Core.CFG;
using XVM.Core.RT;

namespace XVM.Core.AST.IL
{
	public class ILJumpTable : IILOperand, IHasOffset
	{
		[CompilerGenerated]
		private JumpTableChunk mck;

		[CompilerGenerated]
		private ILInstruction rcH;

		[CompilerGenerated]
		private IBasicBlock[] WcC;

		public JumpTableChunk Chunk
		{
			[CompilerGenerated]
			get
			{
				return mck;
			}
			[CompilerGenerated]
			private set
			{
				mck = value;
			}
		}

		public ILInstruction RelativeBase
		{
			[CompilerGenerated]
			get
			{
				return rcH;
			}
			[CompilerGenerated]
			set
			{
				rcH = value;
			}
		}

		public IBasicBlock[] Targets
		{
			[CompilerGenerated]
			get
			{
				return WcC;
			}
			[CompilerGenerated]
			set
			{
				WcC = value;
			}
		}

		public uint Offset => Chunk.Offset;

		public ILJumpTable(IBasicBlock[] ibasicBlock_0)
		{
			Targets = ibasicBlock_0;
			Chunk = new JumpTableChunk(this);
		}

		public override string ToString()
		{
			return $"[..{Targets.Length}..]";
		}
	}
}
