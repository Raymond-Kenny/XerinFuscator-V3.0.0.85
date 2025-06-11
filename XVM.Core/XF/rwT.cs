using System;
using System.IO;

namespace XF
{
	internal class rwT : PRC, FRZ
	{
		private class N5L
		{
			private readonly u0H[] Y5m = new u0H[16];

			private readonly u0H[] o55 = new u0H[16];

			private b0R U5o = default(b0R);

			private b0R b5l = default(b0R);

			private u0H v5Z = new u0H(8);

			private uint i5T;

			public void H5k(uint uint_0)
			{
				for (uint num = i5T; num < uint_0; num++)
				{
					Y5m[num] = new u0H(3);
					o55[num] = new u0H(3);
				}
				i5T = uint_0;
			}

			public void e5H()
			{
				U5o.K0w();
				for (uint num = 0u; num < i5T; num++)
				{
					Y5m[num].T0C();
					o55[num].T0C();
				}
				b5l.K0w();
				v5Z.T0C();
			}

			public uint O5C(RRr rrr_0, uint uint_0)
			{
				if (U5o.Y0W(rrr_0) != 0)
				{
					uint num = 8u;
					if (b5l.Y0W(rrr_0) == 0)
					{
						num += o55[uint_0].n0m(rrr_0);
					}
					else
					{
						num += 8;
						num += v5Z.n0m(rrr_0);
					}
					return num;
				}
				return Y5m[uint_0].n0m(rrr_0);
			}
		}

		private class c5S
		{
			private struct RTG
			{
				private b0R[] ITR;

				public void YTI()
				{
					ITR = new b0R[768];
				}

				public void kTq()
				{
					for (int i = 0; i < 768; i++)
					{
						ITR[i].K0w();
					}
				}

				public byte KTM(RRr rrr_0)
				{
					uint num = 1u;
					do
					{
						num = (num << 1) | ITR[num].Y0W(rrr_0);
					}
					while (num < 256);
					return (byte)num;
				}

				public byte FTA(RRr rrr_0, byte byte_0)
				{
					uint num = 1u;
					do
					{
						uint num2 = (uint)((byte_0 >> 7) & 1);
						byte_0 <<= 1;
						uint num3 = ITR[(1 + num2 << 8) + num].Y0W(rrr_0);
						num = (num << 1) | num3;
						if (num2 != num3)
						{
							while (num < 256)
							{
								num = (num << 1) | ITR[num].Y0W(rrr_0);
							}
							break;
						}
					}
					while (num < 256);
					return (byte)num;
				}
			}

			private RTG[] T5d;

			private int y5B;

			private int T57;

			private uint K5D;

			public void T5a(int int_0, int int_1)
			{
				if (T5d == null || T57 != int_1 || y5B != int_0)
				{
					y5B = int_0;
					K5D = (uint)((1 << int_0) - 1);
					T57 = int_1;
					uint num = (uint)(1 << T57 + y5B);
					T5d = new RTG[num];
					for (uint num2 = 0u; num2 < num; num2++)
					{
						T5d[num2].YTI();
					}
				}
			}

			public void m5U()
			{
				uint num = (uint)(1 << T57 + y5B);
				for (uint num2 = 0u; num2 < num; num2++)
				{
					T5d[num2].kTq();
				}
			}

			private uint P5P(uint uint_0, byte byte_0)
			{
				return ((uint_0 & K5D) << T57) + (uint)(byte_0 >> 8 - T57);
			}

			public byte b5F(RRr rrr_0, uint uint_0, byte byte_0)
			{
				return T5d[P5P(uint_0, byte_0)].KTM(rrr_0);
			}

			public byte w5v(RRr rrr_0, uint uint_0, byte byte_0, byte byte_1)
			{
				return T5d[P5P(uint_0, byte_0)].FTA(rrr_0, byte_1);
			}
		}

		private readonly b0R[] pwv = new b0R[192];

		private readonly b0R[] Awd = new b0R[192];

		private readonly b0R[] AwB = new b0R[12];

		private readonly b0R[] uw7 = new b0R[12];

		private readonly b0R[] ywD = new b0R[12];

		private readonly b0R[] Owy = new b0R[12];

		private readonly N5L swY = new N5L();

		private readonly c5S Xwg = new c5S();

		private readonly wwE LwV = new wwE();

		private readonly b0R[] zwb = new b0R[114];

		private readonly u0H[] Iwp = new u0H[4];

		private readonly RRr Twr = new RRr();

		private readonly N5L pw3 = new N5L();

		private bool CwX;

		private uint Dwn;

		private uint Yw6;

		private u0H ywx = new u0H(4);

		private uint xws;

		public rwT()
		{
			Dwn = uint.MaxValue;
			for (int i = 0; i < 4L; i++)
			{
				Iwp[i] = new u0H(6);
			}
		}

		public void VUa(Stream stream_0, Stream stream_1, long long_0, long long_1, DRH drh_0)
		{
			gwP(stream_0, stream_1);
			Kwl.v5N v5N = default(Kwl.v5N);
			v5N.W52();
			uint num = 0u;
			uint num2 = 0u;
			uint num3 = 0u;
			uint num4 = 0u;
			ulong num5 = 0uL;
			if (0uL < (ulong)long_1)
			{
				if (pwv[v5N.n5c << 4].Y0W(Twr) != 0)
				{
					throw new hRL();
				}
				v5N.J5K();
				byte byte_ = Xwg.b5F(Twr, 0u, 0);
				LwV.awt(byte_);
				num5++;
			}
			while (num5 < (ulong)long_1)
			{
				uint num6 = (uint)(int)num5 & xws;
				if (pwv[(v5N.n5c << 4) + num6].Y0W(Twr) == 0)
				{
					byte byte_2 = LwV.ewc(0u);
					byte byte_3 = (v5N.A5t() ? Xwg.b5F(Twr, (uint)num5, byte_2) : Xwg.w5v(Twr, (uint)num5, byte_2, LwV.ewc(num)));
					LwV.awt(byte_3);
					v5N.J5K();
					num5++;
					continue;
				}
				uint num8;
				if (AwB[v5N.n5c].Y0W(Twr) == 1)
				{
					if (uw7[v5N.n5c].Y0W(Twr) != 0)
					{
						uint num7;
						if (ywD[v5N.n5c].Y0W(Twr) == 0)
						{
							num7 = num2;
						}
						else
						{
							if (Owy[v5N.n5c].Y0W(Twr) == 0)
							{
								num7 = num3;
							}
							else
							{
								num7 = num4;
								num4 = num3;
							}
							num3 = num2;
						}
						num2 = num;
						num = num7;
					}
					else if (Awd[(v5N.n5c << 4) + num6].Y0W(Twr) == 0)
					{
						v5N.E5O();
						LwV.awt(LwV.ewc(num));
						num5++;
						continue;
					}
					num8 = pw3.O5C(Twr, num6) + 2;
					v5N.v5j();
				}
				else
				{
					num4 = num3;
					num3 = num2;
					num2 = num;
					num8 = 2 + swY.O5C(Twr, num6);
					v5N.y51();
					uint num9 = Iwp[Kwl.owZ(num8)].n0m(Twr);
					if (num9 >= 4)
					{
						int num10 = (int)((num9 >> 1) - 1);
						num = (2 | (num9 & 1)) << num10;
						if (num9 < 14)
						{
							num += u0H.q0o(zwb, num - num9 - 1, Twr, num10);
						}
						else
						{
							num += Twr.RRf(num10 - 4) << 4;
							num += ywx.G05(Twr);
						}
					}
					else
					{
						num = num9;
					}
				}
				if (num < LwV.ewL + num5 && num < Yw6)
				{
					LwV.rwO(num, num8);
					num5 += num8;
					continue;
				}
				if (num == uint.MaxValue)
				{
					break;
				}
				throw new hRL();
			}
			LwV.ewj();
			LwV.vw1();
			Twr.XRX();
		}

		public void mUP(byte[] byte_0)
		{
			if (byte_0.Length >= 5)
			{
				int int_ = byte_0[0] % 9;
				int num = byte_0[0] / 9;
				int int_2 = num % 5;
				int num2 = num / 5;
				if (num2 > 4)
				{
					throw new nRk();
				}
				uint num3 = 0u;
				for (int i = 0; i < 4; i++)
				{
					num3 += (uint)(byte_0[1 + i] << i * 8);
				}
				UwS(num3);
				Nwa(int_2, int_);
				PwU(num2);
				return;
			}
			throw new nRk();
		}

		private void UwS(uint uint_0)
		{
			if (Dwn != uint_0)
			{
				Dwn = uint_0;
				Yw6 = Math.Max(Dwn, 1u);
				uint uint_1 = Math.Max(Yw6, 4096u);
				LwV.CwN(uint_1);
			}
		}

		private void Nwa(int int_0, int int_1)
		{
			if (int_0 > 8)
			{
				throw new nRk();
			}
			if (int_1 > 8)
			{
				throw new nRk();
			}
			Xwg.T5a(int_0, int_1);
		}

		private void PwU(int int_0)
		{
			if (int_0 > 4)
			{
				throw new nRk();
			}
			uint num = (uint)(1 << int_0);
			swY.H5k(num);
			pw3.H5k(num);
			xws = num - 1;
		}

		private void gwP(Stream stream_0, Stream stream_1)
		{
			Twr.uR3(stream_0);
			LwV.mw2(stream_1, CwX);
			for (uint num = 0u; num < 12; num++)
			{
				for (uint num2 = 0u; num2 <= xws; num2++)
				{
					uint num3 = (num << 4) + num2;
					pwv[num3].K0w();
					Awd[num3].K0w();
				}
				AwB[num].K0w();
				uw7[num].K0w();
				ywD[num].K0w();
				Owy[num].K0w();
			}
			Xwg.m5U();
			for (uint num = 0u; num < 4; num++)
			{
				Iwp[num].T0C();
			}
			for (uint num = 0u; num < 114; num++)
			{
				zwb[num].K0w();
			}
			swY.e5H();
			pw3.e5H();
			ywx.T0C();
		}

		public bool twF(Stream stream_0)
		{
			CwX = true;
			return LwV.HwK(stream_0);
		}
	}
}
