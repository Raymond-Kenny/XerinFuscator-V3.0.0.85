using System;

namespace XProtections.ControlFlow
{
	[Flags]
	public enum ControlFlowBlockType
	{
		Normal = 0,
		Entry = 1,
		Exit = 2
	}
}
