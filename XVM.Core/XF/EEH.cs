using System.IO;

namespace XF
{
	internal class EEH
	{
		private readonly byte[] FEa;

		private readonly uint dEU;

		private uint SEP;

		private uint lEv;

		private ulong vEd;

		private Stream GEB;

		private bool AE7;

		public EEH(uint uint_0)
		{
			FEa = new byte[uint_0];
			dEU = uint_0;
		}

		public void IEC(Stream stream_0)
		{
			GEB = stream_0;
			vEd = 0uL;
			SEP = 0u;
			lEv = 0u;
			AE7 = false;
		}

		public bool kEm()
		{
			if (!AE7)
			{
				vEd += lEv;
				int num = GEB.Read(FEa, 0, (int)dEU);
				lEv = 0u;
				SEP = (uint)num;
				AE7 = num == 0;
				return !AE7;
			}
			return false;
		}

		public void uE5()
		{
			GEB = null;
		}

		public bool wEl(byte byte_0)
		{
			if (lEv >= SEP && !kEm())
			{
				return false;
			}
			byte_0 = FEa[lEv++];
			return true;
		}

		public byte UEZ()
		{
			if (lEv >= SEP && !kEm())
			{
				return byte.MaxValue;
			}
			return FEa[lEv++];
		}

		public ulong AES()
		{
			return vEd + lEv;
		}
	}
}
