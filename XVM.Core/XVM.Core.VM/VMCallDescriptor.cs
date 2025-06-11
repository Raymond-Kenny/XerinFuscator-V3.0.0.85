using System.Linq;
using XVM.Core.Services;

namespace XVM.Core.VM
{
	public class VMCallDescriptor
	{
		private readonly int[] Dq2 = Enumerable.Range(0, 256).ToArray();

		public int this[VMCalls vmcalls_0] => Dq2[(int)vmcalls_0];

		public int EXIT => Dq2[0];

		public int BREAK => Dq2[1];

		public int ECALL => Dq2[2];

		public int CAST => Dq2[3];

		public int CKFINITE => Dq2[4];

		public int CKOVERFLOW => Dq2[5];

		public int RANGECHK => Dq2[6];

		public int INITOBJ => Dq2[7];

		public int LDFLD => Dq2[8];

		public int LDFTN => Dq2[9];

		public int TOKEN => Dq2[10];

		public int THROW => Dq2[11];

		public int SIZEOF => Dq2[12];

		public int STFLD => Dq2[13];

		public int BOX => Dq2[14];

		public int UNBOX => Dq2[15];

		public int LOCALLOC => Dq2[16];

		internal VMCallDescriptor(RandomGenerator randomGenerator_0)
		{
			randomGenerator_0.Shuffle(Dq2);
		}
	}
}
