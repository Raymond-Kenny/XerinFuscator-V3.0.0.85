using System;
using System.Runtime.CompilerServices;

namespace XVM.Core.RT
{
	public class OffsetComputeEventArgs : EventArgs
	{
		[CompilerGenerated]
		private uint SNL;

		public uint Offset
		{
			[CompilerGenerated]
			get
			{
				return SNL;
			}
			[CompilerGenerated]
			private set
			{
				SNL = value;
			}
		}

		internal OffsetComputeEventArgs(uint uint_0)
		{
			Offset = uint_0;
		}
	}
}
