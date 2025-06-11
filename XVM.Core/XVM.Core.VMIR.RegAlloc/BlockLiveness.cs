using System.Collections.Generic;
using System.Runtime.CompilerServices;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.RegAlloc
{
	public class BlockLiveness
	{
		[CompilerGenerated]
		private readonly HashSet<IRVariable> rMa;

		[CompilerGenerated]
		private readonly HashSet<IRVariable> hMU;

		public HashSet<IRVariable> InLive
		{
			[CompilerGenerated]
			get
			{
				return rMa;
			}
		}

		public HashSet<IRVariable> OutLive
		{
			[CompilerGenerated]
			get
			{
				return hMU;
			}
		}

		private BlockLiveness(HashSet<IRVariable> hashSet_0, HashSet<IRVariable> hashSet_1)
		{
			rMa = hashSet_0;
			hMU = hashSet_1;
		}

		internal static BlockLiveness WMT()
		{
			return new BlockLiveness(new HashSet<IRVariable>(), new HashSet<IRVariable>());
		}

		internal BlockLiveness mMS()
		{
			return new BlockLiveness(new HashSet<IRVariable>(InLive), new HashSet<IRVariable>(OutLive));
		}
	}
}
