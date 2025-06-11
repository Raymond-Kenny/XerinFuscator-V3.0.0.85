using System;
using System.IO;

namespace XF
{
	internal class L0a : v0X, k0S, p0T
	{
		private bool a0d = true;

		private uint m0B = 255u;

		private uint T07;

		private uint h0D;

		private uint[] k0y;

		private uint l0Y;

		private uint K0g;

		private uint P0V;

		private uint[] C0b;

		private uint f0p = 66560u;

		private uint o0r = 4u;

		private uint b03;

		public void PUF(Stream stream_0)
		{
			V0s(stream_0);
		}

		public void pUB()
		{
			G0Q();
		}

		public void Init()
		{
			j0f();
			for (uint num = 0u; num < K0g; num++)
			{
				k0y[num] = 0u;
			}
			T07 = 0u;
			Fwe(-1);
		}

		public byte MU7(int int_0)
		{
			return z08(int_0);
		}

		public uint UUD(int int_0, uint uint_0, uint uint_1)
		{
			return e0z(int_0, uint_0, uint_1);
		}

		public uint jUy()
		{
			return Kw4();
		}

		public void PUY(uint uint_0, uint uint_1, uint uint_2, uint uint_3)
		{
			if (uint_0 > 2147483391)
			{
				throw new Exception();
			}
			m0B = 16 + (uint_2 >> 1);
			uint uint_4 = (uint_0 + uint_1 + uint_2 + uint_3) / 2 + 256;
			j0x(uint_0 + uint_1, uint_2 + uint_3, uint_4);
			P0V = uint_2;
			uint num = uint_0 + 1;
			if (h0D != num)
			{
				C0b = new uint[(h0D = num) * 2];
			}
			uint num2 = 65536u;
			if (a0d)
			{
				num2 = uint_0 - 1;
				num2 |= num2 >> 1;
				num2 |= num2 >> 2;
				num2 |= num2 >> 4;
				num2 |= num2 >> 8;
				num2 >>= 1;
				num2 |= 0xFFFF;
				if (num2 > 16777216)
				{
					num2 >>= 1;
				}
				l0Y = num2;
				num2++;
				num2 += f0p;
			}
			if (num2 != K0g)
			{
				k0y = new uint[K0g = num2];
			}
		}

		public uint zUg(uint[] uint_0)
		{
			uint num;
			if (RwA + P0V > kwW)
			{
				num = kwW - RwA;
				if (num < o0r)
				{
					X0h();
					return 0u;
				}
			}
			else
			{
				num = P0V;
			}
			uint num2 = 0u;
			uint num3 = ((RwA > h0D) ? (RwA - h0D) : 0u);
			uint num4 = swG + RwA;
			uint num5 = 1u;
			uint num6 = 0u;
			uint num7 = 0u;
			uint num9;
			if (a0d)
			{
				uint num8 = pE2.zEL[Cw9[num4]] ^ Cw9[num4 + 1];
				num6 = num8 & 0x3FF;
				num8 ^= (uint)(Cw9[num4 + 2] << 8);
				num7 = num8 & 0xFFFF;
				num9 = (num8 ^ (pE2.zEL[Cw9[num4 + 3]] << 5)) & l0Y;
			}
			else
			{
				num9 = (uint)(Cw9[num4] ^ (Cw9[num4 + 1] << 8));
			}
			uint num10 = k0y[f0p + num9];
			if (a0d)
			{
				uint num11 = k0y[num6];
				uint num12 = k0y[1024 + num7];
				k0y[num6] = RwA;
				k0y[1024 + num7] = RwA;
				if (num11 > num3 && Cw9[swG + num11] == Cw9[num4])
				{
					uint num13 = num2++;
					num5 = 2u;
					uint_0[num13] = 2u;
					uint_0[num2++] = RwA - num11 - 1;
				}
				if (num12 > num3 && Cw9[swG + num12] == Cw9[num4])
				{
					if (num12 == num11)
					{
						num2 -= 2;
					}
					uint num14 = num2++;
					num5 = 3u;
					uint_0[num14] = 3u;
					uint_0[num2++] = RwA - num12 - 1;
					num11 = num12;
				}
				if (num2 != 0 && num11 == num10)
				{
					num2 -= 2;
					num5 = 1u;
				}
			}
			k0y[f0p + num9] = RwA;
			uint num15 = (T07 << 1) + 1;
			uint num16 = T07 << 1;
			uint val2;
			uint val = (val2 = b03);
			if (b03 != 0 && num10 > num3 && Cw9[swG + num10 + b03] != Cw9[num4 + b03])
			{
				num5 = (uint_0[num2++] = b03);
				uint_0[num2++] = RwA - num10 - 1;
			}
			uint num17 = m0B;
			while (true)
			{
				if (num10 > num3 && num17-- != 0)
				{
					uint num18 = RwA - num10;
					uint num19 = ((num18 > T07) ? (T07 - num18 + h0D) : (T07 - num18)) << 1;
					uint num20 = swG + num10;
					uint num21 = Math.Min(val, val2);
					if (Cw9[num20 + num21] == Cw9[num4 + num21])
					{
						while (++num21 != num && Cw9[num20 + num21] == Cw9[num4 + num21])
						{
						}
						if (num5 < num21)
						{
							num5 = (uint_0[num2++] = num21);
							uint_0[num2++] = num18 - 1;
							if (num21 == num)
							{
								C0b[num16] = C0b[num19];
								C0b[num15] = C0b[num19 + 1];
								break;
							}
						}
					}
					if (Cw9[num20 + num21] < Cw9[num4 + num21])
					{
						C0b[num16] = num10;
						num16 = num19 + 1;
						num10 = C0b[num16];
						val2 = num21;
					}
					else
					{
						C0b[num15] = num10;
						num15 = num19;
						num10 = C0b[num15];
						val = num21;
					}
					continue;
				}
				uint[] c0b = C0b;
				uint num22 = num15;
				C0b[num16] = 0u;
				c0b[num22] = 0u;
				break;
			}
			X0h();
			return num2;
		}

		public void nUV(uint uint_0)
		{
			do
			{
				uint num;
				if (RwA + P0V > kwW)
				{
					num = kwW - RwA;
					if (num < o0r)
					{
						X0h();
						continue;
					}
				}
				else
				{
					num = P0V;
				}
				uint num2 = ((RwA > h0D) ? (RwA - h0D) : 0u);
				uint num3 = swG + RwA;
				uint num7;
				if (a0d)
				{
					uint num4 = pE2.zEL[Cw9[num3]] ^ Cw9[num3 + 1];
					uint num5 = num4 & 0x3FF;
					k0y[num5] = RwA;
					num4 ^= (uint)(Cw9[num3 + 2] << 8);
					uint num6 = num4 & 0xFFFF;
					k0y[1024 + num6] = RwA;
					num7 = (num4 ^ (pE2.zEL[Cw9[num3 + 3]] << 5)) & l0Y;
				}
				else
				{
					num7 = (uint)(Cw9[num3] ^ (Cw9[num3 + 1] << 8));
				}
				uint num8 = k0y[f0p + num7];
				k0y[f0p + num7] = RwA;
				uint num9 = (T07 << 1) + 1;
				uint num10 = T07 << 1;
				uint val2;
				uint val = (val2 = b03);
				uint num11 = m0B;
				while (true)
				{
					if (num8 > num2 && num11-- != 0)
					{
						uint num12 = RwA - num8;
						uint num13 = ((num12 <= T07) ? (T07 - num12) : (T07 - num12 + h0D)) << 1;
						uint num14 = swG + num8;
						uint num15 = Math.Min(val, val2);
						if (Cw9[num14 + num15] == Cw9[num3 + num15])
						{
							while (++num15 != num && Cw9[num14 + num15] == Cw9[num3 + num15])
							{
							}
							if (num15 == num)
							{
								C0b[num10] = C0b[num13];
								C0b[num9] = C0b[num13 + 1];
								break;
							}
						}
						if (Cw9[num14 + num15] < Cw9[num3 + num15])
						{
							C0b[num10] = num8;
							num10 = num13 + 1;
							num8 = C0b[num10];
							val2 = num15;
						}
						else
						{
							C0b[num9] = num8;
							num9 = num13;
							num8 = C0b[num9];
							val = num15;
						}
						continue;
					}
					uint[] c0b = C0b;
					uint num16 = num9;
					C0b[num10] = 0u;
					c0b[num16] = 0u;
					break;
				}
				X0h();
			}
			while (--uint_0 != 0);
		}

		public void E0U(int int_0)
		{
			a0d = int_0 > 2;
			if (a0d)
			{
				b03 = 0u;
				o0r = 4u;
				f0p = 66560u;
			}
			else
			{
				b03 = 2u;
				o0r = 3u;
				f0p = 0u;
			}
		}

		public void X0h()
		{
			if (++T07 >= h0D)
			{
				T07 = 0u;
			}
			o0J();
			if (RwA == int.MaxValue)
			{
				W0F();
			}
		}

		private void v0P(uint[] uint_0, uint uint_1, uint uint_2)
		{
			for (uint num = 0u; num < uint_1; num++)
			{
				uint num2 = uint_0[num];
				num2 = ((num2 > uint_2) ? (num2 - uint_2) : 0u);
				uint_0[num] = num2;
			}
		}

		private void W0F()
		{
			uint num = RwA - h0D;
			v0P(C0b, h0D * 2, num);
			v0P(k0y, K0g, num);
			Fwe((int)num);
		}

		public void O0v(uint uint_0)
		{
			m0B = uint_0;
		}
	}
}
