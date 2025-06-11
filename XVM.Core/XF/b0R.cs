namespace XF
{
	internal struct b0R
	{
		private uint G0E;

		public void x00(int int_0, uint uint_0)
		{
			if (uint_0 == 0)
			{
				G0E += 2048 - G0E >> int_0;
			}
			else
			{
				G0E -= G0E >> int_0;
			}
		}

		public void K0w()
		{
			G0E = 1024u;
		}

		public uint Y0W(RRr rrr_0)
		{
			uint num = (rrr_0.IR8 >> 11) * G0E;
			if (rrr_0.ORJ < num)
			{
				rrr_0.IR8 = num;
				G0E += 2048 - G0E >> 5;
				if (rrr_0.IR8 < 16777216)
				{
					rrr_0.ORJ = (rrr_0.ORJ << 8) | (byte)rrr_0.HRz.ReadByte();
					rrr_0.IR8 <<= 8;
				}
				return 0u;
			}
			rrr_0.IR8 -= num;
			rrr_0.ORJ -= num;
			G0E -= G0E >> 5;
			if (rrr_0.IR8 < 16777216)
			{
				rrr_0.ORJ = (rrr_0.ORJ << 8) | (byte)rrr_0.HRz.ReadByte();
				rrr_0.IR8 <<= 8;
			}
			return 1u;
		}
	}
}
