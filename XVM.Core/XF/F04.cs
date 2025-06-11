namespace XF
{
	internal struct F04
	{
		private static readonly uint[] J0M;

		private uint m0A;

		static F04()
		{
			J0M = new uint[512];
			for (int num = 8; num >= 0; num--)
			{
				uint num2 = (uint)(1 << 9 - num - 1);
				uint num3 = (uint)(1 << 9 - num);
				for (uint num4 = num2; num4 < num3; num4++)
				{
					J0M[num4] = (uint)(num << 6) + (num3 - num4 << 6 >> 9 - num - 1);
				}
			}
		}

		public void j0e()
		{
			m0A = 1024u;
		}

		public void G0u(uint uint_0)
		{
			if (uint_0 == 0)
			{
				m0A += 2048 - m0A >> 5;
			}
			else
			{
				m0A -= m0A >> 5;
			}
		}

		public void B09(rRT rRT_0, uint uint_0)
		{
			uint num = (rRT_0.fRY >> 11) * m0A;
			if (uint_0 != 0)
			{
				rRT_0.wRy += num;
				rRT_0.fRY -= num;
				m0A -= m0A >> 5;
			}
			else
			{
				rRT_0.fRY = num;
				m0A += 2048 - m0A >> 5;
			}
			if (rRT_0.fRY < 16777216)
			{
				rRT_0.fRY <<= 8;
				rRT_0.IRd();
			}
		}

		public uint y0G(uint uint_0)
		{
			return J0M[(((m0A - uint_0) ^ (int)(0 - uint_0)) & 0x7FFL) >> 2];
		}

		public uint a0I()
		{
			return J0M[m0A >> 2];
		}

		public uint B0q()
		{
			return J0M[2048 - m0A >> 2];
		}
	}
}
