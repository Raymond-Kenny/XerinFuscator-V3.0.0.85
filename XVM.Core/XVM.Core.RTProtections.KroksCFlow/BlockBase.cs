using System.Runtime.CompilerServices;
using dnlib.DotNet.Emit;

namespace XVM.Core.RTProtections.KroksCFlow
{
	public abstract class BlockBase
	{
		[CompilerGenerated]
		private ScopeBlock VKx;

		[CompilerGenerated]
		private BlockType XKs;

		public ScopeBlock Parent
		{
			[CompilerGenerated]
			get
			{
				return VKx;
			}
			[CompilerGenerated]
			private set
			{
				VKx = value;
			}
		}

		public BlockType Type
		{
			[CompilerGenerated]
			get
			{
				return XKs;
			}
			[CompilerGenerated]
			private set
			{
				XKs = value;
			}
		}

		public BlockBase(BlockType blockType_0)
		{
			Type = blockType_0;
		}

		public abstract void ToBody(CilBody cilBody_0);
	}
}
