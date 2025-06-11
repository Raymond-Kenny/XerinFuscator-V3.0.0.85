using System.Runtime.CompilerServices;
using XVM.Core.Services;

namespace XVM.Core.VM
{
	public class ArchDescriptor
	{
		[CompilerGenerated]
		private readonly OpCodeDescriptor AIr;

		[CompilerGenerated]
		private readonly FlagDescriptor DI3;

		[CompilerGenerated]
		private readonly RegisterDescriptor aIX;

		public OpCodeDescriptor OpCodes
		{
			[CompilerGenerated]
			get
			{
				return AIr;
			}
		}

		public FlagDescriptor Flags
		{
			[CompilerGenerated]
			get
			{
				return DI3;
			}
		}

		public RegisterDescriptor Registers
		{
			[CompilerGenerated]
			get
			{
				return aIX;
			}
		}

		internal ArchDescriptor(RandomGenerator randomGenerator_0)
		{
			AIr = new OpCodeDescriptor(randomGenerator_0);
			DI3 = new FlagDescriptor(randomGenerator_0);
			aIX = new RegisterDescriptor(randomGenerator_0);
		}
	}
}
