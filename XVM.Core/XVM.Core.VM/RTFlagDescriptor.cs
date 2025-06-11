using System;
using System.Linq;
using System.Runtime.CompilerServices;
using XVM.Core.Services;

namespace XVM.Core.VM
{
	public class RTFlagDescriptor
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class hCM
		{
			public static readonly hCM kC0;

			public static Func<int, byte> PCw;

			public static Func<int, byte> eCW;

			static hCM()
			{
				kC0 = new hCM();
			}

			internal byte yCA(int int_0)
			{
				return (byte)int_0;
			}

			internal byte WCR(int int_0)
			{
				return (byte)int_0;
			}
		}

		private readonly byte[] vqR = (from int_0 in Enumerable.Range(0, 4)
			select (byte)int_0).ToArray();

		private readonly byte[] Rq0 = (from int_0 in Enumerable.Range(1, 7)
			select (byte)int_0).ToArray();

		public byte INSTANCE => Rq0[0];

		public byte EH_CATCH => vqR[0];

		public byte EH_FILTER => vqR[1];

		public byte EH_FAULT => vqR[2];

		public byte EH_FINALLY => vqR[3];

		internal RTFlagDescriptor(RandomGenerator randomGenerator_0)
		{
			randomGenerator_0.Shuffle(Rq0);
			randomGenerator_0.Shuffle(vqR);
		}
	}
}
