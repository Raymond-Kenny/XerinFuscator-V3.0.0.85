using System;

namespace XVM.Core.CFG
{
	[Flags]
	public enum BlockFlags
	{
		Normal = 0,
		flag_1 = 1,
		ExitEHReturn = 2
	}
}
