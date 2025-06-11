using System;
using System.Linq;
using System.Runtime.CompilerServices;
using XVM.Core.Services;
using XVM.Core.VMIL;

namespace XVM.Core.VM
{
	public class OpCodeDescriptor
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class PHz
		{
			public static readonly PHz fCe;

			public static Func<int, byte> BCu;

			static PHz()
			{
				fCe = new PHz();
			}

			internal byte sC4(int int_0)
			{
				return (byte)int_0;
			}
		}

		private readonly byte[] AqM = (from int_0 in Enumerable.Range(0, 256)
			select (byte)int_0).ToArray();

		public byte this[ILOpCode ilopCode_0] => AqM[(int)ilopCode_0];

		internal OpCodeDescriptor(RandomGenerator randomGenerator_0)
		{
			randomGenerator_0.Shuffle(AqM);
		}
	}
}
