using System.Runtime.CompilerServices;
using XVM.Core.Services;

namespace XVM.Core.VM
{
	public class RuntimeDescriptor
	{
		[CompilerGenerated]
		private readonly VMCallDescriptor wqw;

		[CompilerGenerated]
		private readonly GClass2 jqW;

		[CompilerGenerated]
		private readonly RTFlagDescriptor MqE;

		public VMCallDescriptor VMCall
		{
			[CompilerGenerated]
			get
			{
				return wqw;
			}
		}

		public GClass2 VCallOps
		{
			[CompilerGenerated]
			get
			{
				return jqW;
			}
		}

		public RTFlagDescriptor RTFlags
		{
			[CompilerGenerated]
			get
			{
				return MqE;
			}
		}

		internal RuntimeDescriptor(RandomGenerator randomGenerator_0)
		{
			wqw = new VMCallDescriptor(randomGenerator_0);
			jqW = new GClass2(randomGenerator_0);
			MqE = new RTFlagDescriptor(randomGenerator_0);
		}
	}
}
