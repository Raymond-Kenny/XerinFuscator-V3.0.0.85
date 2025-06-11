using System.IO;

namespace XF
{
	internal class rRT
	{
		public ulong wRy;

		public uint fRY;

		private long oRg;

		private Stream RRV;

		private byte vRb;

		private uint tRp;

		public void uRS(Stream stream_0)
		{
			RRV = stream_0;
		}

		public void TRa()
		{
			RRV = null;
		}

		public void mRU()
		{
			oRg = RRV.Position;
			wRy = 0uL;
			fRY = uint.MaxValue;
			tRp = 1u;
			vRb = 0;
		}

		public void JRh()
		{
			for (int i = 0; i < 5; i++)
			{
				IRd();
			}
		}

		public void XRP()
		{
			RRV.Flush();
		}

		public void bRF()
		{
			RRV.Close();
		}

		public void TRv(uint uint_0, uint uint_1, uint uint_2)
		{
			wRy += uint_0 * (fRY /= uint_2);
			fRY *= uint_1;
			while (fRY < 16777216)
			{
				fRY <<= 8;
				IRd();
			}
		}

		public void IRd()
		{
			if ((uint)wRy < 4278190080u || (int)(wRy >> 32) == 1)
			{
				byte b = vRb;
				do
				{
					RRV.WriteByte((byte)(b + (wRy >> 32)));
					b = byte.MaxValue;
				}
				while (--tRp != 0);
				vRb = (byte)((uint)wRy >> 24);
			}
			tRp++;
			wRy = (uint)((int)wRy << 8);
		}

		public void yRB(uint uint_0, int int_0)
		{
			for (int num = int_0 - 1; num >= 0; num--)
			{
				fRY >>= 1;
				if (((uint_0 >> num) & 1) == 1)
				{
					wRy += fRY;
				}
				if (fRY < 16777216)
				{
					fRY <<= 8;
					IRd();
				}
			}
		}

		public void WR7(uint uint_0, int int_0, uint uint_1)
		{
			uint num = (fRY >> int_0) * uint_0;
			if (uint_1 == 0)
			{
				fRY = num;
			}
			else
			{
				wRy += num;
				fRY -= num;
			}
			while (fRY < 16777216)
			{
				fRY <<= 8;
				IRd();
			}
		}

		public long RRD()
		{
			return tRp + RRV.Position - oRg + 4L;
		}
	}
}
