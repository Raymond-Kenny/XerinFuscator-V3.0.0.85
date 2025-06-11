using System;
using System.Linq;
using System.Runtime.CompilerServices;
using XVM.Core.Services;

namespace XVM.Core.VM
{
	public class RegisterDescriptor
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class eC9
		{
			public static readonly eC9 uCI;

			public static Func<int, byte> QCq;

			static eC9()
			{
				uCI = new eC9();
			}

			internal byte PCG(int int_0)
			{
				return (byte)int_0;
			}
		}

		private readonly byte[] BqA = (from int_0 in Enumerable.Range(0, 13)
			select (byte)int_0).ToArray();

		public byte this[VMRegisters vmregisters_0] => BqA[(int)vmregisters_0];

		internal RegisterDescriptor(RandomGenerator randomGenerator_0)
		{
			randomGenerator_0.Shuffle(BqA);
		}
	}
}
