using XVM.Core.Services;

namespace XVM.Core.VM
{
	public class GClass2
	{
		private readonly uint[] uqN = new uint[4] { 0u, 1u, 2u, 3u };

		public uint ECALL_CALL => uqN[0];

		public uint ECALL_CALLVIRT => uqN[1];

		public uint ECALL_NEWOBJ => uqN[2];

		public uint ECALL_CALLVIRT_CONSTRAINED => uqN[3];

		internal GClass2(RandomGenerator randomGenerator_0)
		{
			randomGenerator_0.Shuffle(uqN);
		}
	}
}
