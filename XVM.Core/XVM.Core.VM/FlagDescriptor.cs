using System.Linq;
using XVM.Core.Services;

namespace XVM.Core.VM
{
	public class FlagDescriptor
	{
		private readonly int[] fq4 = Enumerable.Range(0, 5).ToArray();

		public int this[VMFlags vmflags_0] => fq4[(int)vmflags_0];

		public int OVERFLOW => fq4[0];

		public int CARRY => fq4[1];

		public int ZERO => fq4[2];

		public int SIGN => fq4[3];

		public int UNSIGNED => fq4[4];

		public int BEHAV1 => fq4[5];

		public int BEHAV2 => fq4[6];

		public int BEHAV3 => fq4[7];

		internal FlagDescriptor(RandomGenerator randomGenerator_0)
		{
			randomGenerator_0.Shuffle(fq4);
		}
	}
}
