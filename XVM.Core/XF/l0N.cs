namespace XF
{
	internal struct l0N
	{
		private readonly F04[] S0L;

		private readonly int p0k;

		public l0N(int int_0)
		{
			p0k = int_0;
			S0L = new F04[1 << int_0];
		}

		public void t02()
		{
			for (uint num = 1u; num < 1 << p0k; num++)
			{
				S0L[num].j0e();
			}
		}

		public void K0K(rRT rRT_0, uint uint_0)
		{
			uint num = 1u;
			int num2 = p0k;
			while (num2 > 0)
			{
				num2--;
				uint num3 = (uint_0 >> num2) & 1;
				S0L[num].B09(rRT_0, num3);
				num = (num << 1) | num3;
			}
		}

		public void U01(rRT rRT_0, uint uint_0)
		{
			uint num = 1u;
			for (uint num2 = 0u; num2 < p0k; num2++)
			{
				uint num3 = uint_0 & 1;
				S0L[num].B09(rRT_0, num3);
				num = (num << 1) | num3;
				uint_0 >>= 1;
			}
		}

		public uint t0j(uint uint_0)
		{
			uint num = 0u;
			uint num2 = 1u;
			int num3 = p0k;
			while (num3 > 0)
			{
				num3--;
				uint num4 = (uint_0 >> num3) & 1;
				num += S0L[num2].y0G(num4);
				num2 = (num2 << 1) + num4;
			}
			return num;
		}

		public uint y0O(uint uint_0)
		{
			uint num = 0u;
			uint num2 = 1u;
			for (int num3 = p0k; num3 > 0; num3--)
			{
				uint num4 = uint_0 & 1;
				uint_0 >>= 1;
				num += S0L[num2].y0G(num4);
				num2 = (num2 << 1) | num4;
			}
			return num;
		}

		public static uint T0t(F04[] f04_0, uint uint_0, int int_0, uint uint_1)
		{
			uint num = 0u;
			uint num2 = 1u;
			for (int num3 = int_0; num3 > 0; num3--)
			{
				uint num4 = uint_1 & 1;
				uint_1 >>= 1;
				num += f04_0[uint_0 + num2].y0G(num4);
				num2 = (num2 << 1) | num4;
			}
			return num;
		}

		public static void a0c(F04[] f04_0, uint uint_0, rRT rRT_0, int int_0, uint uint_1)
		{
			uint num = 1u;
			for (int i = 0; i < int_0; i++)
			{
				uint num2 = uint_1 & 1;
				f04_0[uint_0 + num].B09(rRT_0, num2);
				num = (num << 1) | num2;
				uint_1 >>= 1;
			}
		}
	}
}
