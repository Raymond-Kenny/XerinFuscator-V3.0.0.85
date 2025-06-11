using System;
using System.IO;

namespace XF
{
	internal class twQ : PRC, sRo, LRl
	{
		private enum D5y
		{

		}

		private class G5Y
		{
			private readonly l0N[] n5p = new l0N[16];

			private readonly l0N[] g5r = new l0N[16];

			private F04 E53 = default(F04);

			private F04 B5X = default(F04);

			private l0N l5n = new l0N(8);

			public G5Y()
			{
				for (uint num = 0u; num < 16; num++)
				{
					n5p[num] = new l0N(3);
					g5r[num] = new l0N(3);
				}
			}

			public void C5g(uint uint_0)
			{
				E53.j0e();
				B5X.j0e();
				for (uint num = 0u; num < uint_0; num++)
				{
					n5p[num].t02();
					g5r[num].t02();
				}
				l5n.t02();
			}

			public void D5V(rRT rRT_0, uint uint_0, uint uint_1)
			{
				if (uint_0 < 8)
				{
					E53.B09(rRT_0, 0u);
					n5p[uint_1].K0K(rRT_0, uint_0);
					return;
				}
				uint_0 -= 8;
				E53.B09(rRT_0, 1u);
				if (uint_0 < 8)
				{
					B5X.B09(rRT_0, 0u);
					g5r[uint_1].K0K(rRT_0, uint_0);
				}
				else
				{
					B5X.B09(rRT_0, 1u);
					l5n.K0K(rRT_0, uint_0 - 8);
				}
			}

			public void C5b(uint uint_0, uint uint_1, uint[] uint_2, uint uint_3)
			{
				uint num = E53.a0I();
				uint num2 = E53.B0q();
				uint num3 = num2 + B5X.a0I();
				uint num4 = num2 + B5X.B0q();
				uint num5 = 0u;
				num5 = 0u;
				while (true)
				{
					if (num5 < 8)
					{
						if (num5 < uint_1)
						{
							uint_2[uint_3 + num5] = num + n5p[uint_0].t0j(num5);
							num5++;
							continue;
						}
						break;
					}
					while (true)
					{
						if (num5 < 16)
						{
							if (num5 < uint_1)
							{
								uint_2[uint_3 + num5] = num3 + g5r[uint_0].t0j(num5 - 8);
								num5++;
								continue;
							}
							break;
						}
						for (; num5 < uint_1; num5++)
						{
							uint_2[uint_3 + num5] = num4 + l5n.t0j(num5 - 8 - 8);
						}
						break;
					}
					break;
				}
			}
		}

		private class i56 : G5Y
		{
			private readonly uint[] Q5J = new uint[16];

			private readonly uint[] i58 = new uint[4352];

			private uint n5z;

			public void S5x(uint uint_0)
			{
				n5z = uint_0;
			}

			public uint B5s(uint uint_0, uint uint_1)
			{
				return i58[uint_1 * 272 + uint_0];
			}

			private void K5Q(uint uint_0)
			{
				C5b(uint_0, n5z, i58, uint_0 * 272);
				Q5J[uint_0] = n5z;
			}

			public void C5f(uint uint_0)
			{
				for (uint num = 0u; num < uint_0; num++)
				{
					K5Q(num);
				}
			}

			public void h5i(rRT rRT_0, uint uint_0, uint uint_1)
			{
				D5V(rRT_0, uint_0, uint_1);
				if (--Q5J[uint_1] == 0)
				{
					K5Q(uint_1);
				}
			}
		}

		private class co4
		{
			public struct OT0
			{
				private F04[] XT1;

				public void MTw()
				{
					XT1 = new F04[768];
				}

				public void QTW()
				{
					for (int i = 0; i < 768; i++)
					{
						XT1[i].j0e();
					}
				}

				public void gTN(rRT rRT_0, byte byte_0)
				{
					uint num = 1u;
					for (int num2 = 7; num2 >= 0; num2--)
					{
						uint num3 = (uint)((byte_0 >> num2) & 1);
						XT1[num].B09(rRT_0, num3);
						num = (num << 1) | num3;
					}
				}

				public void HT2(rRT rRT_0, byte byte_0, byte byte_1)
				{
					uint num = 1u;
					bool flag = true;
					for (int num2 = 7; num2 >= 0; num2--)
					{
						uint num3 = (uint)((byte_1 >> num2) & 1);
						uint num4 = num;
						if (flag)
						{
							uint num5 = (uint)((byte_0 >> num2) & 1);
							num4 += 1 + num5 << 8;
							flag = num5 == num3;
						}
						XT1[num4].B09(rRT_0, num3);
						num = (num << 1) | num3;
					}
				}

				public uint eTK(bool bool_0, byte byte_0, byte byte_1)
				{
					uint num = 0u;
					uint num2 = 1u;
					int num3 = 7;
					if (bool_0)
					{
						while (num3 >= 0)
						{
							uint num4 = (uint)((byte_0 >> num3) & 1);
							uint num5 = (uint)((byte_1 >> num3) & 1);
							num += XT1[(1 + num4 << 8) + num2].y0G(num5);
							num2 = (num2 << 1) | num5;
							if (num4 == num5)
							{
								num3--;
								continue;
							}
							num3--;
							break;
						}
					}
					while (num3 >= 0)
					{
						uint num6 = (uint)((byte_1 >> num3) & 1);
						num += XT1[num2].y0G(num6);
						num2 = (num2 << 1) | num6;
						num3--;
					}
					return num;
				}
			}

			private OT0[] koG;

			private int KoI;

			private int Foq;

			private uint xoM;

			public void moe(int int_0, int int_1)
			{
				if (koG == null || Foq != int_1 || KoI != int_0)
				{
					KoI = int_0;
					xoM = (uint)((1 << int_0) - 1);
					Foq = int_1;
					uint num = (uint)(1 << Foq + KoI);
					koG = new OT0[num];
					for (uint num2 = 0u; num2 < num; num2++)
					{
						koG[num2].MTw();
					}
				}
			}

			public void Kou()
			{
				uint num = (uint)(1 << Foq + KoI);
				for (uint num2 = 0u; num2 < num; num2++)
				{
					koG[num2].QTW();
				}
			}

			public OT0 do9(uint uint_0, byte byte_0)
			{
				return koG[(int)((uint_0 & xoM) << Foq) + (byte_0 >> 8 - Foq)];
			}
		}

		private class QoA
		{
			public uint UoW;

			public uint eoE;

			public uint DoN;

			public uint ao2;

			public uint xoK;

			public uint Yo1;

			public uint joj;

			public uint yoO;

			public bool Foc;

			public bool noL;

			public uint eok;

			public Kwl.v5N coH;

			public void WoR()
			{
				UoW = uint.MaxValue;
				Foc = false;
			}

			public void To0()
			{
				UoW = 0u;
				Foc = false;
			}

			public bool Fow()
			{
				return UoW == 0;
			}
		}

		private static readonly byte[] YWk;

		private static readonly string[] VWH;

		private readonly uint[] nWC = new uint[16];

		private readonly uint[] FWm = new uint[512];

		private readonly F04[] nW5 = new F04[192];

		private readonly F04[] TWo = new F04[12];

		private readonly F04[] PWl = new F04[192];

		private readonly F04[] pWZ = new F04[12];

		private readonly F04[] OWT = new F04[12];

		private readonly F04[] GWS = new F04[12];

		private readonly i56 zWa = new i56();

		private readonly co4 hWU = new co4();

		private readonly uint[] eWh = new uint[548];

		private readonly QoA[] xWP = new QoA[4096];

		private readonly F04[] QWF = new F04[114];

		private readonly l0N[] zWv = new l0N[4];

		private readonly uint[] eWd = new uint[256];

		private readonly rRT wWB = new rRT();

		private readonly uint[] yW7 = new uint[4];

		private readonly i56 NWy = new i56();

		private readonly byte[] CWY = new byte[5];

		private readonly uint[] EWg = new uint[4];

		private readonly uint[] yWV = new uint[4];

		private readonly uint[] uWb = new uint[128];

		private uint mWp;

		private uint oW3;

		private uint vWX = 4194304u;

		private uint wWn = uint.MaxValue;

		private uint fW6 = 44u;

		private bool TWx;

		private Stream vWs;

		private uint CWQ;

		private bool WWf;

		private object oWi;

		private D5y NWJ = (D5y)1;

		private uint LW8;

		private bool VWz;

		private uint dE4;

		private uint fEe = 32u;

		private uint uEu = uint.MaxValue;

		private int EE9 = 3;

		private int zEG;

		private uint kEI;

		private uint sEq;

		private l0N AEM = new l0N(4);

		private int IEA = 2;

		private uint EER = 3u;

		private byte wE0;

		private Kwl.v5N WEw = default(Kwl.v5N);

		private uint zEW;

		private bool UEE;

		private long vEN;

		static twQ()
		{
			YWk = new byte[2048];
			VWH = new string[2] { "BT2", "BT4" };
			int num = 2;
			YWk[0] = 0;
			YWk[1] = 1;
			for (byte b = 2; b < 22; b++)
			{
				uint num2 = (uint)(1 << (b >> 1) - 1);
				uint num3 = 0u;
				while (num3 < num2)
				{
					YWk[num] = b;
					num3++;
					num++;
				}
			}
		}

		public twQ()
		{
			for (int i = 0; i < 4096L; i++)
			{
				xWP[i] = new QoA();
			}
			for (int j = 0; j < 4L; j++)
			{
				zWv[j] = new l0N(6);
			}
		}

		public void VUa(Stream stream_0, Stream stream_1, long long_0, long long_1, DRH drh_0)
		{
			VWz = false;
			try
			{
				IW1(stream_0, stream_1, long_0, long_1);
				while (true)
				{
					TWW(out var long_2, out var long_3, out var bool_);
					if (!bool_)
					{
						drh_0?.dUS(long_2, long_3);
						continue;
					}
					break;
				}
			}
			finally
			{
				nWK();
			}
		}

		public void HUU(XuQ[] xuQ_0, object[] object_0)
		{
			for (uint num = 0u; num < object_0.Length; num++)
			{
				object obj = object_0[num];
				switch (xuQ_0[num])
				{
				case (XuQ)1:
					if (obj is int num3)
					{
						if (num3 >= 1L && num3 <= 1073741824L)
						{
							vWX = (uint)num3;
							int i;
							for (i = 0; i < 30L && num3 > (uint)(1 << i); i++)
							{
							}
							fW6 = (uint)(i * 2);
							break;
						}
						throw new nRk();
					}
					throw new nRk();
				case (XuQ)5:
					if (obj is int num7)
					{
						if (num7 >= 0 && num7 <= 4L)
						{
							IEA = num7;
							EER = (uint)((1 << IEA) - 1);
							break;
						}
						throw new nRk();
					}
					throw new nRk();
				case (XuQ)6:
					if (obj is int num2)
					{
						if (num2 >= 0 && num2 <= 8L)
						{
							EE9 = num2;
							break;
						}
						throw new nRk();
					}
					throw new nRk();
				case (XuQ)7:
					if (obj is int num6)
					{
						if (num6 >= 0 && num6 <= 4L)
						{
							zEG = num6;
							break;
						}
						throw new nRk();
					}
					throw new nRk();
				case (XuQ)8:
					if (obj is int num5)
					{
						if (num5 >= 5 && num5 <= 273L)
						{
							fEe = (uint)num5;
							break;
						}
						throw new nRk();
					}
					throw new nRk();
				case (XuQ)9:
					if (obj is string)
					{
						D5y nWJ = NWJ;
						int num4 = qWc(((string)obj).ToUpper());
						if (num4 >= 0)
						{
							NWJ = (D5y)num4;
							if (oWi != null && nWJ != NWJ)
							{
								wWn = uint.MaxValue;
								oWi = null;
							}
							break;
						}
						throw new nRk();
					}
					throw new nRk();
				case (XuQ)14:
					if (obj is bool)
					{
						ewz((bool)obj);
						break;
					}
					throw new nRk();
				case (XuQ)12:
					break;
				default:
					throw new nRk();
				}
			}
		}

		public void aUh(Stream stream_0)
		{
			CWY[0] = (byte)((IEA * 5 + zEG) * 9 + EE9);
			for (int i = 0; i < 4; i++)
			{
				CWY[1 + i] = (byte)((vWX >> 8 * i) & 0xFF);
			}
			stream_0.Write(CWY, 0, 5);
		}

		private static uint Uwf(uint uint_0)
		{
			if (uint_0 >= 2048)
			{
				if (uint_0 < 2097152)
				{
					return (uint)(YWk[uint_0 >> 10] + 20);
				}
				return (uint)(YWk[uint_0 >> 20] + 40);
			}
			return YWk[uint_0];
		}

		private static uint mwi(uint uint_0)
		{
			if (uint_0 < 131072)
			{
				return (uint)(YWk[uint_0 >> 6] + 12);
			}
			if (uint_0 >= 134217728)
			{
				return (uint)(YWk[uint_0 >> 26] + 52);
			}
			return (uint)(YWk[uint_0 >> 16] + 32);
		}

		private void twJ()
		{
			WEw.W52();
			wE0 = 0;
			for (uint num = 0u; num < 4; num++)
			{
				yW7[num] = 0u;
			}
		}

		private void Fw8()
		{
			if (oWi == null)
			{
				L0a l0a = new L0a();
				int int_ = 4;
				if (NWJ == (D5y)0)
				{
					int_ = 2;
				}
				l0a.E0U(int_);
				oWi = l0a;
			}
			hWU.moe(zEG, EE9);
			if (vWX != wWn || uEu != fEe)
			{
				((k0S)oWi).PUY(vWX, 4096u, fEe, 274u);
				wWn = vWX;
				uEu = fEe;
			}
		}

		private void ewz(bool bool_0)
		{
			UEE = bool_0;
		}

		private void xW4()
		{
			twJ();
			wWB.mRU();
			for (uint num = 0u; num < 12; num++)
			{
				for (uint num2 = 0u; num2 <= EER; num2++)
				{
					uint num3 = (num << 4) + num2;
					nW5[num3].j0e();
					PWl[num3].j0e();
				}
				TWo[num].j0e();
				pWZ[num].j0e();
				OWT[num].j0e();
				GWS[num].j0e();
			}
			hWU.Kou();
			for (uint num = 0u; num < 4; num++)
			{
				zWv[num].t02();
			}
			for (uint num = 0u; num < 114; num++)
			{
				QWF[num].j0e();
			}
			zWa.C5g((uint)(1 << IEA));
			NWy.C5g((uint)(1 << IEA));
			AEM.t02();
			WWf = false;
			sEq = 0u;
			kEI = 0u;
			mWp = 0u;
		}

		private void dWe(out uint uint_0, out uint uint_1)
		{
			uint_0 = 0u;
			uint_1 = ((k0S)oWi).zUg(eWh);
			if (uint_1 != 0)
			{
				uint_0 = eWh[uint_1 - 2];
				if (uint_0 == fEe)
				{
					uint_0 += ((p0T)oWi).UUD((int)(uint_0 - 1), eWh[uint_1 - 1], 273 - uint_0);
				}
			}
			mWp++;
		}

		private void AWu(uint uint_0)
		{
			if (uint_0 != 0)
			{
				((k0S)oWi).nUV(uint_0);
				mWp += uint_0;
			}
		}

		private uint IW9(Kwl.v5N v5N_0, uint uint_0)
		{
			return pWZ[v5N_0.n5c].a0I() + PWl[(v5N_0.n5c << 4) + uint_0].a0I();
		}

		private uint dWG(uint uint_0, Kwl.v5N v5N_0, uint uint_1)
		{
			uint num;
			if (uint_0 == 0)
			{
				num = pWZ[v5N_0.n5c].a0I();
				return num + PWl[(v5N_0.n5c << 4) + uint_1].B0q();
			}
			num = pWZ[v5N_0.n5c].B0q();
			if (uint_0 != 1)
			{
				num += OWT[v5N_0.n5c].B0q();
				return num + GWS[v5N_0.n5c].y0G(uint_0 - 2);
			}
			return num + OWT[v5N_0.n5c].a0I();
		}

		private uint GWI(uint uint_0, uint uint_1, Kwl.v5N v5N_0, uint uint_2)
		{
			uint num = NWy.B5s(uint_1 - 2, uint_2);
			return num + dWG(uint_0, v5N_0, uint_2);
		}

		private uint NWq(uint uint_0, uint uint_1, uint uint_2)
		{
			uint num = Kwl.owZ(uint_1);
			uint num2 = ((uint_0 >= 128) ? (eWd[(num << 6) + mwi(uint_0)] + nWC[uint_0 & 0xF]) : FWm[num * 128 + uint_0]);
			return num2 + zWa.B5s(uint_1 - 2, uint_2);
		}

		private uint zWM(out uint uint_0, uint uint_1)
		{
			sEq = uint_1;
			uint joj = xWP[uint_1].joj;
			uint uoW = xWP[uint_1].UoW;
			do
			{
				if (xWP[uint_1].Foc)
				{
					xWP[joj].WoR();
					xWP[joj].joj = joj - 1;
					if (xWP[uint_1].noL)
					{
						xWP[joj - 1].Foc = false;
						xWP[joj - 1].joj = xWP[uint_1].yoO;
						xWP[joj - 1].UoW = xWP[uint_1].eoE;
					}
				}
				uint num = joj;
				uint uoW2 = uoW;
				uoW = xWP[num].UoW;
				joj = xWP[num].joj;
				xWP[num].UoW = uoW2;
				xWP[num].joj = uint_1;
				uint_1 = num;
			}
			while (uint_1 != 0);
			uint_0 = xWP[0].UoW;
			kEI = xWP[0].joj;
			return kEI;
		}

		private uint MWA(uint uint_0, out uint uint_1)
		{
			if (sEq != kEI)
			{
				uint result = xWP[kEI].joj - kEI;
				uint_1 = xWP[kEI].UoW;
				kEI = xWP[kEI].joj;
				return result;
			}
			sEq = 0u;
			kEI = 0u;
			uint uint_2;
			uint uint_3;
			if (!WWf)
			{
				dWe(out uint_2, out uint_3);
			}
			else
			{
				uint_2 = CWQ;
				uint_3 = dE4;
				WWf = false;
			}
			uint num = ((p0T)oWi).jUy() + 1;
			if (num >= 2)
			{
				if (num > 273)
				{
					num = 273u;
				}
				uint num2 = 0u;
				for (uint num3 = 0u; num3 < 4; num3++)
				{
					yWV[num3] = yW7[num3];
					EWg[num3] = ((p0T)oWi).UUD(-1, yWV[num3], 273u);
					if (EWg[num3] > EWg[num2])
					{
						num2 = num3;
					}
				}
				if (EWg[num2] < fEe)
				{
					if (uint_2 >= fEe)
					{
						uint_1 = eWh[uint_3 - 1] + 4;
						AWu(uint_2 - 1);
						return uint_2;
					}
					byte b = ((p0T)oWi).MU7(-1);
					byte b2 = ((p0T)oWi).MU7((int)(0 - yW7[0] - 1 - 1));
					if (uint_2 < 2 && b != b2 && EWg[num2] < 2)
					{
						uint_1 = uint.MaxValue;
						return 1u;
					}
					xWP[0].coH = WEw;
					uint num4 = uint_0 & EER;
					xWP[1].eok = nW5[(WEw.n5c << 4) + num4].a0I() + hWU.do9(uint_0, wE0).eTK(!WEw.A5t(), b2, b);
					xWP[1].WoR();
					uint num5 = nW5[(WEw.n5c << 4) + num4].B0q();
					uint num6 = num5 + TWo[WEw.n5c].B0q();
					if (b2 == b)
					{
						uint num7 = num6 + IW9(WEw, num4);
						if (num7 < xWP[1].eok)
						{
							xWP[1].eok = num7;
							xWP[1].To0();
						}
					}
					uint num8 = ((uint_2 < EWg[num2]) ? EWg[num2] : uint_2);
					if (num8 >= 2)
					{
						xWP[1].joj = 0u;
						xWP[0].DoN = yWV[0];
						xWP[0].ao2 = yWV[1];
						xWP[0].xoK = yWV[2];
						xWP[0].Yo1 = yWV[3];
						uint num9 = num8;
						do
						{
							xWP[num9--].eok = 268435455u;
						}
						while (num9 >= 2);
						for (uint num3 = 0u; num3 < 4; num3++)
						{
							uint num10 = EWg[num3];
							if (num10 < 2)
							{
								continue;
							}
							uint num11 = num6 + dWG(num3, WEw, num4);
							do
							{
								uint num12 = num11 + NWy.B5s(num10 - 2, num4);
								QoA qoA = xWP[num10];
								if (num12 < qoA.eok)
								{
									qoA.eok = num12;
									qoA.joj = 0u;
									qoA.UoW = num3;
									qoA.Foc = false;
								}
							}
							while (--num10 >= 2);
						}
						uint num13 = num5 + TWo[WEw.n5c].a0I();
						num9 = ((EWg[0] < 2) ? 2u : (EWg[0] + 1));
						if (num9 <= uint_2)
						{
							uint num14;
							for (num14 = 0u; num9 > eWh[num14]; num14 += 2)
							{
							}
							while (true)
							{
								uint num15 = eWh[num14 + 1];
								uint num16 = num13 + NWq(num15, num9, num4);
								QoA qoA2 = xWP[num9];
								if (num16 < qoA2.eok)
								{
									qoA2.eok = num16;
									qoA2.joj = 0u;
									qoA2.UoW = num15 + 4;
									qoA2.Foc = false;
								}
								if (num9 == eWh[num14])
								{
									num14 += 2;
									if (num14 == uint_3)
									{
										break;
									}
								}
								num9++;
							}
						}
						uint num17 = 0u;
						uint uint_4;
						while (true)
						{
							num17++;
							if (num17 != num8)
							{
								dWe(out uint_4, out uint_3);
								if (uint_4 >= fEe)
								{
									break;
								}
								uint_0++;
								uint num18 = xWP[num17].joj;
								Kwl.v5N coH;
								if (xWP[num17].Foc)
								{
									num18--;
									if (xWP[num17].noL)
									{
										coH = xWP[xWP[num17].yoO].coH;
										if (xWP[num17].eoE < 4)
										{
											coH.v5j();
										}
										else
										{
											coH.y51();
										}
									}
									else
									{
										coH = xWP[num18].coH;
									}
									coH.J5K();
								}
								else
								{
									coH = xWP[num18].coH;
								}
								if (num18 == num17 - 1)
								{
									if (xWP[num17].Fow())
									{
										coH.E5O();
									}
									else
									{
										coH.J5K();
									}
								}
								else
								{
									uint num19;
									if (xWP[num17].Foc && xWP[num17].noL)
									{
										num18 = xWP[num17].yoO;
										num19 = xWP[num17].eoE;
										coH.v5j();
									}
									else
									{
										num19 = xWP[num17].UoW;
										if (num19 < 4)
										{
											coH.v5j();
										}
										else
										{
											coH.y51();
										}
									}
									QoA qoA3 = xWP[num18];
									switch (num19)
									{
									case 0u:
										yWV[0] = qoA3.DoN;
										yWV[1] = qoA3.ao2;
										yWV[2] = qoA3.xoK;
										yWV[3] = qoA3.Yo1;
										break;
									case 2u:
										yWV[0] = qoA3.xoK;
										yWV[1] = qoA3.DoN;
										yWV[2] = qoA3.ao2;
										yWV[3] = qoA3.Yo1;
										break;
									case 3u:
										yWV[0] = qoA3.Yo1;
										yWV[1] = qoA3.DoN;
										yWV[2] = qoA3.ao2;
										yWV[3] = qoA3.xoK;
										break;
									case 1u:
										yWV[0] = qoA3.ao2;
										yWV[1] = qoA3.DoN;
										yWV[2] = qoA3.xoK;
										yWV[3] = qoA3.Yo1;
										break;
									default:
										yWV[0] = num19 - 4;
										yWV[1] = qoA3.DoN;
										yWV[2] = qoA3.ao2;
										yWV[3] = qoA3.xoK;
										break;
									}
								}
								xWP[num17].coH = coH;
								xWP[num17].DoN = yWV[0];
								xWP[num17].ao2 = yWV[1];
								xWP[num17].xoK = yWV[2];
								xWP[num17].Yo1 = yWV[3];
								uint eok = xWP[num17].eok;
								b = ((p0T)oWi).MU7(-1);
								b2 = ((p0T)oWi).MU7((int)(0 - yWV[0] - 1 - 1));
								num4 = uint_0 & EER;
								uint num20 = eok + nW5[(coH.n5c << 4) + num4].a0I() + hWU.do9(uint_0, ((p0T)oWi).MU7(-2)).eTK(!coH.A5t(), b2, b);
								QoA qoA4 = xWP[num17 + 1];
								bool flag = false;
								if (num20 < qoA4.eok)
								{
									qoA4.eok = num20;
									qoA4.joj = num17;
									qoA4.WoR();
									flag = true;
								}
								num5 = eok + nW5[(coH.n5c << 4) + num4].B0q();
								num6 = num5 + TWo[coH.n5c].B0q();
								if (b2 == b && (qoA4.joj >= num17 || qoA4.UoW != 0))
								{
									uint num21 = num6 + IW9(coH, num4);
									if (num21 <= qoA4.eok)
									{
										qoA4.eok = num21;
										qoA4.joj = num17;
										qoA4.To0();
										flag = true;
									}
								}
								uint val = ((p0T)oWi).jUy() + 1;
								val = Math.Min(4095 - num17, val);
								num = val;
								if (num < 2)
								{
									continue;
								}
								if (num > fEe)
								{
									num = fEe;
								}
								if (!flag && b2 != b)
								{
									uint uint_5 = Math.Min(val - 1, fEe);
									uint num22 = ((p0T)oWi).UUD(0, yWV[0], uint_5);
									if (num22 >= 2)
									{
										Kwl.v5N v5N_ = coH;
										v5N_.J5K();
										uint num23 = (uint_0 + 1) & EER;
										uint num24 = num20 + nW5[(v5N_.n5c << 4) + num23].B0q() + TWo[v5N_.n5c].B0q();
										uint num25 = num17 + 1 + num22;
										while (num8 < num25)
										{
											xWP[++num8].eok = 268435455u;
										}
										uint num26 = num24 + GWI(0u, num22, v5N_, num23);
										QoA qoA5 = xWP[num25];
										if (num26 < qoA5.eok)
										{
											qoA5.eok = num26;
											qoA5.joj = num17 + 1;
											qoA5.UoW = 0u;
											qoA5.Foc = true;
											qoA5.noL = false;
										}
									}
								}
								uint num27 = 2u;
								for (uint num28 = 0u; num28 < 4; num28++)
								{
									uint num29 = ((p0T)oWi).UUD(-1, yWV[num28], num);
									if (num29 < 2)
									{
										continue;
									}
									uint num30 = num29;
									while (true)
									{
										if (num8 >= num17 + num29)
										{
											uint num31 = num6 + GWI(num28, num29, coH, num4);
											QoA qoA6 = xWP[num17 + num29];
											if (num31 < qoA6.eok)
											{
												qoA6.eok = num31;
												qoA6.joj = num17;
												qoA6.UoW = num28;
												qoA6.Foc = false;
											}
											if (--num29 < 2)
											{
												break;
											}
										}
										else
										{
											xWP[++num8].eok = 268435455u;
										}
									}
									num29 = num30;
									if (num28 == 0)
									{
										num27 = num29 + 1;
									}
									if (num29 >= val)
									{
										continue;
									}
									uint uint_6 = Math.Min(val - 1 - num29, fEe);
									uint num32 = ((p0T)oWi).UUD((int)num29, yWV[num28], uint_6);
									if (num32 >= 2)
									{
										Kwl.v5N v5N_2 = coH;
										v5N_2.v5j();
										uint num33 = (uint_0 + num29) & EER;
										uint num34 = num6 + GWI(num28, num29, coH, num4) + nW5[(v5N_2.n5c << 4) + num33].a0I() + hWU.do9(uint_0 + num29, ((p0T)oWi).MU7((int)(num29 - 1 - 1))).eTK(bool_0: true, ((p0T)oWi).MU7((int)(num29 - 1 - (yWV[num28] + 1))), ((p0T)oWi).MU7((int)(num29 - 1)));
										v5N_2.J5K();
										num33 = (uint_0 + num29 + 1) & EER;
										uint num35 = num34 + nW5[(v5N_2.n5c << 4) + num33].B0q();
										uint num36 = num35 + TWo[v5N_2.n5c].B0q();
										uint num37 = num29 + 1 + num32;
										while (num8 < num17 + num37)
										{
											xWP[++num8].eok = 268435455u;
										}
										uint num38 = num36 + GWI(0u, num32, v5N_2, num33);
										QoA qoA7 = xWP[num17 + num37];
										if (num38 < qoA7.eok)
										{
											qoA7.eok = num38;
											qoA7.joj = num17 + num29 + 1;
											qoA7.UoW = 0u;
											qoA7.Foc = true;
											qoA7.noL = true;
											qoA7.yoO = num17;
											qoA7.eoE = num28;
										}
									}
								}
								if (uint_4 > num)
								{
									uint_4 = num;
									for (uint_3 = 0u; uint_4 > eWh[uint_3]; uint_3 += 2)
									{
									}
									eWh[uint_3] = uint_4;
									uint_3 += 2;
								}
								if (uint_4 < num27)
								{
									continue;
								}
								num13 = num5 + TWo[coH.n5c].a0I();
								while (num8 < num17 + uint_4)
								{
									xWP[++num8].eok = 268435455u;
								}
								uint num39;
								for (num39 = 0u; num27 > eWh[num39]; num39 += 2)
								{
								}
								uint num40 = num27;
								while (true)
								{
									uint num41 = eWh[num39 + 1];
									uint num42 = num13 + NWq(num41, num40, num4);
									QoA qoA8 = xWP[num17 + num40];
									if (num42 < qoA8.eok)
									{
										qoA8.eok = num42;
										qoA8.joj = num17;
										qoA8.UoW = num41 + 4;
										qoA8.Foc = false;
									}
									if (num40 == eWh[num39])
									{
										if (num40 < val)
										{
											uint uint_7 = Math.Min(val - 1 - num40, fEe);
											uint num43 = ((p0T)oWi).UUD((int)num40, num41, uint_7);
											if (num43 >= 2)
											{
												Kwl.v5N v5N_3 = coH;
												v5N_3.y51();
												uint num44 = (uint_0 + num40) & EER;
												uint num45 = num42 + nW5[(v5N_3.n5c << 4) + num44].a0I() + hWU.do9(uint_0 + num40, ((p0T)oWi).MU7((int)(num40 - 1 - 1))).eTK(bool_0: true, ((p0T)oWi).MU7((int)(num40 - (num41 + 1) - 1)), ((p0T)oWi).MU7((int)(num40 - 1)));
												v5N_3.J5K();
												num44 = (uint_0 + num40 + 1) & EER;
												uint num46 = num45 + nW5[(v5N_3.n5c << 4) + num44].B0q();
												uint num47 = num46 + TWo[v5N_3.n5c].B0q();
												uint num48 = num40 + 1 + num43;
												while (num8 < num17 + num48)
												{
													xWP[++num8].eok = 268435455u;
												}
												num42 = num47 + GWI(0u, num43, v5N_3, num44);
												qoA8 = xWP[num17 + num48];
												if (num42 < qoA8.eok)
												{
													qoA8.eok = num42;
													qoA8.joj = num17 + num40 + 1;
													qoA8.UoW = 0u;
													qoA8.Foc = true;
													qoA8.noL = true;
													qoA8.yoO = num17;
													qoA8.eoE = num41 + 4;
												}
											}
										}
										num39 += 2;
										if (num39 == uint_3)
										{
											break;
										}
									}
									num40++;
								}
								continue;
							}
							return zWM(out uint_1, num17);
						}
						dE4 = uint_3;
						CWQ = uint_4;
						WWf = true;
						return zWM(out uint_1, num17);
					}
					uint_1 = xWP[1].UoW;
					return 1u;
				}
				uint_1 = num2;
				uint num49 = EWg[num2];
				AWu(num49 - 1);
				return num49;
			}
			uint_1 = uint.MaxValue;
			return 1u;
		}

		private bool JWR(uint uint_0, uint uint_1)
		{
			return uint_0 < 33554432 && uint_1 >= uint_0 << 7;
		}

		private void aW0(uint uint_0)
		{
			if (UEE)
			{
				nW5[(WEw.n5c << 4) + uint_0].B09(wWB, 1u);
				TWo[WEw.n5c].B09(wWB, 0u);
				WEw.y51();
				zWa.h5i(wWB, 0u, uint_0);
				uint num = Kwl.owZ(2u);
				zWv[num].K0K(wWB, 63u);
				wWB.yRB(67108863u, 26);
				AEM.U01(wWB, 15u);
			}
		}

		private void eWw(uint uint_0)
		{
			kWE();
			aW0(uint_0 & EER);
			wWB.JRh();
			wWB.XRP();
		}

		public void TWW(out long long_0, out long long_1, out bool bool_0)
		{
			long_0 = 0L;
			long_1 = 0L;
			bool_0 = true;
			if (vWs != null)
			{
				((p0T)oWi).PUF(vWs);
				((p0T)oWi).Init();
				VWz = true;
				vWs = null;
				if (zEW != 0)
				{
					((k0S)oWi).nUV(zEW);
				}
			}
			if (TWx)
			{
				return;
			}
			TWx = true;
			long num = vEN;
			if (vEN == 0L)
			{
				if (((p0T)oWi).jUy() == 0)
				{
					eWw((uint)vEN);
					return;
				}
				dWe(out var _, out var _);
				uint num2 = (uint)(int)vEN & EER;
				nW5[(WEw.n5c << 4) + num2].B09(wWB, 0u);
				WEw.J5K();
				byte byte_ = ((p0T)oWi).MU7((int)(0 - mWp));
				hWU.do9((uint)vEN, wE0).gTN(wWB, byte_);
				wE0 = byte_;
				mWp--;
				vEN++;
			}
			if (((p0T)oWi).jUy() == 0)
			{
				eWw((uint)vEN);
				return;
			}
			while (true)
			{
				uint uint_3;
				uint num3 = MWA((uint)vEN, out uint_3);
				uint num4 = (uint)(int)vEN & EER;
				uint num5 = (WEw.n5c << 4) + num4;
				if (num3 != 1 || uint_3 != uint.MaxValue)
				{
					nW5[num5].B09(wWB, 1u);
					if (uint_3 < 4)
					{
						TWo[WEw.n5c].B09(wWB, 1u);
						if (uint_3 == 0)
						{
							pWZ[WEw.n5c].B09(wWB, 0u);
							if (num3 == 1)
							{
								PWl[num5].B09(wWB, 0u);
							}
							else
							{
								PWl[num5].B09(wWB, 1u);
							}
						}
						else
						{
							pWZ[WEw.n5c].B09(wWB, 1u);
							if (uint_3 == 1)
							{
								OWT[WEw.n5c].B09(wWB, 0u);
							}
							else
							{
								OWT[WEw.n5c].B09(wWB, 1u);
								GWS[WEw.n5c].B09(wWB, uint_3 - 2);
							}
						}
						if (num3 == 1)
						{
							WEw.E5O();
						}
						else
						{
							NWy.h5i(wWB, num3 - 2, num4);
							WEw.v5j();
						}
						uint num6 = yW7[uint_3];
						if (uint_3 != 0)
						{
							for (uint num7 = uint_3; num7 >= 1; num7--)
							{
								yW7[num7] = yW7[num7 - 1];
							}
							yW7[0] = num6;
						}
					}
					else
					{
						TWo[WEw.n5c].B09(wWB, 0u);
						WEw.y51();
						zWa.h5i(wWB, num3 - 2, num4);
						uint_3 -= 4;
						uint num8 = Uwf(uint_3);
						uint num9 = Kwl.owZ(num3);
						zWv[num9].K0K(wWB, num8);
						if (num8 >= 4)
						{
							int num10 = (int)((num8 >> 1) - 1);
							uint num11 = (2 | (num8 & 1)) << num10;
							uint num12 = uint_3 - num11;
							if (num8 >= 14)
							{
								wWB.yRB(num12 >> 4, num10 - 4);
								AEM.U01(wWB, num12 & 0xF);
								oW3++;
							}
							else
							{
								l0N.a0c(QWF, num11 - num8 - 1, wWB, num10, num12);
							}
						}
						uint num13 = uint_3;
						for (uint num14 = 3u; num14 >= 1; num14--)
						{
							yW7[num14] = yW7[num14 - 1];
						}
						yW7[0] = num13;
						LW8++;
					}
					wE0 = ((p0T)oWi).MU7((int)(num3 - 1 - mWp));
				}
				else
				{
					nW5[num5].B09(wWB, 0u);
					byte b = ((p0T)oWi).MU7((int)(0 - mWp));
					co4.OT0 oT = hWU.do9((uint)vEN, wE0);
					if (!WEw.A5t())
					{
						byte byte_2 = ((p0T)oWi).MU7((int)(0 - yW7[0] - 1 - mWp));
						oT.HT2(wWB, byte_2, b);
					}
					else
					{
						oT.gTN(wWB, b);
					}
					wE0 = b;
					WEw.J5K();
				}
				mWp -= num3;
				vEN += num3;
				if (mWp == 0)
				{
					if (LW8 >= 128)
					{
						MWj();
					}
					if (oW3 >= 16)
					{
						hWO();
					}
					long_0 = vEN;
					long_1 = wWB.RRD();
					if (((p0T)oWi).jUy() == 0)
					{
						break;
					}
					if (vEN - num >= 4096L)
					{
						TWx = false;
						bool_0 = false;
						return;
					}
				}
			}
			eWw((uint)vEN);
		}

		private void kWE()
		{
			if (oWi != null && VWz)
			{
				((p0T)oWi).pUB();
				VWz = false;
			}
		}

		private void JWN(Stream stream_0)
		{
			wWB.uRS(stream_0);
		}

		private void cW2()
		{
			wWB.TRa();
		}

		private void nWK()
		{
			kWE();
			cW2();
		}

		private void IW1(Stream stream_0, Stream stream_1, long long_0, long long_1)
		{
			vWs = stream_0;
			TWx = false;
			Fw8();
			JWN(stream_1);
			xW4();
			MWj();
			hWO();
			zWa.S5x(fEe + 1 - 2);
			zWa.C5f((uint)(1 << IEA));
			NWy.S5x(fEe + 1 - 2);
			NWy.C5f((uint)(1 << IEA));
			vEN = 0L;
		}

		private void MWj()
		{
			for (uint num = 4u; num < 128; num++)
			{
				uint num2 = Uwf(num);
				int num3 = (int)((num2 >> 1) - 1);
				uint num4 = (2 | (num2 & 1)) << num3;
				uWb[num] = l0N.T0t(QWF, num4 - num2 - 1, num3, num - num4);
			}
			for (uint num5 = 0u; num5 < 4; num5++)
			{
				l0N l0N2 = zWv[num5];
				uint num6 = num5 << 6;
				for (uint num7 = 0u; num7 < fW6; num7++)
				{
					eWd[num6 + num7] = l0N2.t0j(num7);
				}
				for (uint num7 = 14u; num7 < fW6; num7++)
				{
					eWd[num6 + num7] += (num7 >> 1) - 1 - 4 << 6;
				}
				uint num8 = num5 * 128;
				uint num9;
				for (num9 = 0u; num9 < 4; num9++)
				{
					FWm[num8 + num9] = eWd[num6 + num9];
				}
				for (; num9 < 128; num9++)
				{
					FWm[num8 + num9] = eWd[num6 + Uwf(num9)] + uWb[num9];
				}
			}
			LW8 = 0u;
		}

		private void hWO()
		{
			for (uint num = 0u; num < 16; num++)
			{
				nWC[num] = AEM.y0O(num);
			}
			oW3 = 0u;
		}

		private static int qWc(string string_0)
		{
			int num = 0;
			while (true)
			{
				if (num < VWH.Length)
				{
					if (string_0 == VWH[num])
					{
						break;
					}
					num++;
					continue;
				}
				return -1;
			}
			return num;
		}

		public void yWL(uint uint_0)
		{
			zEW = uint_0;
		}
	}
}
