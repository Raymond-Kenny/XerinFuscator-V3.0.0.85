using System.IO;

namespace XF
{
	internal class v0X
	{
		public uint iwu;

		public byte[] Cw9 = null;

		public uint swG;

		private uint SwI;

		private uint Owq;

		private uint PwM;

		public uint RwA;

		private uint awR;

		private Stream Lw0;

		private bool Mww;

		public uint kwW;

		public void D0n()
		{
			uint num = swG + RwA - Owq;
			if (num != 0)
			{
				num--;
			}
			uint num2 = swG + kwW - num;
			for (uint num3 = 0u; num3 < num2; num3++)
			{
				Cw9[num3] = Cw9[num + num3];
			}
			swG -= num;
		}

		public virtual void qUb()
		{
			if (Mww)
			{
				return;
			}
			while (true)
			{
				int num = (int)(0 - swG + iwu - kwW);
				if (num != 0)
				{
					int num2 = Lw0.Read(Cw9, (int)(swG + kwW), num);
					if (num2 == 0)
					{
						break;
					}
					kwW += (uint)num2;
					if (kwW >= RwA + SwI)
					{
						awR = kwW - SwI;
					}
					continue;
				}
				return;
			}
			awR = kwW;
			uint num3 = swG + awR;
			if (num3 > PwM)
			{
				awR = PwM - swG;
			}
			Mww = true;
		}

		private void w06()
		{
			Cw9 = null;
		}

		public void j0x(uint uint_0, uint uint_1, uint uint_2)
		{
			Owq = uint_0;
			SwI = uint_1;
			uint num = uint_0 + uint_1 + uint_2;
			if (Cw9 == null || iwu != num)
			{
				w06();
				iwu = num;
				Cw9 = new byte[iwu];
			}
			PwM = iwu - uint_1;
		}

		public void V0s(Stream stream_0)
		{
			Lw0 = stream_0;
		}

		public void G0Q()
		{
			Lw0 = null;
		}

		public void j0f()
		{
			swG = 0u;
			RwA = 0u;
			kwW = 0u;
			Mww = false;
			qUb();
		}

		public void o0J()
		{
			RwA++;
			if (RwA > awR)
			{
				uint num = swG + RwA;
				if (num > PwM)
				{
					D0n();
				}
				qUb();
			}
		}

		public byte z08(int int_0)
		{
			return Cw9[swG + RwA + int_0];
		}

		public uint e0z(int int_0, uint uint_0, uint uint_1)
		{
			if (Mww && RwA + int_0 + uint_1 > kwW)
			{
				uint_1 = kwW - (uint)(int)(RwA + int_0);
			}
			uint_0++;
			uint num = swG + RwA + (uint)int_0;
			uint num2;
			for (num2 = 0u; num2 < uint_1 && Cw9[num + num2] == Cw9[num + num2 - uint_0]; num2++)
			{
			}
			return num2;
		}

		public uint Kw4()
		{
			return kwW - RwA;
		}

		public void Fwe(int int_0)
		{
			swG += (uint)int_0;
			awR -= (uint)int_0;
			RwA -= (uint)int_0;
			kwW -= (uint)int_0;
		}
	}
}
