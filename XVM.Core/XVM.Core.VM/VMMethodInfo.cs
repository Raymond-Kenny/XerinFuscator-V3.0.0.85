using System.Collections.Generic;
using XVM.Core.CFG;

namespace XVM.Core.VM
{
	public class VMMethodInfo
	{
		public readonly Dictionary<IBasicBlock, VMBlockKey> BlockKeys;

		public readonly HashSet<VMRegisters> UsedRegister;

		public byte EntryKey;

		public byte ExitKey;

		public ScopeBlock RootScope;

		public VMMethodInfo()
		{
			BlockKeys = new Dictionary<IBasicBlock, VMBlockKey>();
			UsedRegister = new HashSet<VMRegisters>();
		}
	}
}
