namespace XF
{
	internal struct u0H
	{
		private readonly b0R[] d0l;

		private readonly int k0Z;

		public u0H(int int_0)
		{
			k0Z = int_0;
			d0l = new b0R[1 << int_0];
		}

		public void T0C()
		{
			for (uint num = 1u; num < 1 << k0Z; num++)
			{
				d0l[num].K0w();
			}
		}

		public uint n0m(RRr rrr_0)
		{
			uint num = 1u;
			for (int num2 = k0Z; num2 > 0; num2--)
			{
				num = (num << 1) + d0l[num].Y0W(rrr_0);
			}
			return num - (uint)(1 << k0Z);
		}

		public uint G05(RRr rrr_0)
		{
			uint num = 1u;
			uint num2 = 0u;
			for (int i = 0; i < k0Z; i++)
			{
				uint num3 = d0l[num].Y0W(rrr_0);
				num <<= 1;
				num += num3;
				num2 |= num3 << i;
			}
			return num2;
		}

		public static uint q0o(b0R[] b0R_0, uint uint_0, RRr rrr_0, int int_0)
		{
			uint num = 1u;
			uint num2 = 0u;
			for (int i = 0; i < int_0; i++)
			{
				uint num3 = b0R_0[uint_0 + num].Y0W(rrr_0);
				num <<= 1;
				num += num3;
				num2 |= num3 << i;
			}
			return num2;
		}
	}
}
