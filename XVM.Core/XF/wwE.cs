using System.IO;

namespace XF
{
	internal class wwE
	{
		public uint ewL = 0u;

		private byte[] bwH;

		private uint twC;

		private Stream qwm;

		private uint uw5;

		private uint Vwo;

		public void CwN(uint uint_0)
		{
			if (Vwo != uint_0)
			{
				bwH = new byte[uint_0];
			}
			Vwo = uint_0;
			twC = 0u;
			uw5 = 0u;
		}

		public void mw2(Stream stream_0, bool bool_0)
		{
			vw1();
			qwm = stream_0;
			if (!bool_0)
			{
				uw5 = 0u;
				twC = 0u;
				ewL = 0u;
			}
		}

		public bool HwK(Stream stream_0)
		{
			long length = stream_0.Length;
			uint num = (ewL = (uint)((length >= Vwo) ? Vwo : length));
			stream_0.Position = length - num;
			twC = 0u;
			uw5 = 0u;
			while (true)
			{
				if (num != 0)
				{
					uint num2 = Vwo - twC;
					if (num < num2)
					{
						num2 = num;
					}
					int num3 = stream_0.Read(bwH, (int)twC, (int)num2);
					if (num3 == 0)
					{
						break;
					}
					num -= (uint)num3;
					twC += (uint)num3;
					uw5 += (uint)num3;
					if (twC == Vwo)
					{
						twC = 0u;
						uw5 = 0u;
					}
					continue;
				}
				return true;
			}
			return false;
		}

		public void vw1()
		{
			ewj();
			qwm = null;
		}

		public void ewj()
		{
			uint num = twC - uw5;
			if (num != 0)
			{
				qwm.Write(bwH, (int)uw5, (int)num);
				if (twC >= Vwo)
				{
					twC = 0u;
				}
				uw5 = twC;
			}
		}

		public void rwO(uint uint_0, uint uint_1)
		{
			uint num = twC - uint_0 - 1;
			if (num >= Vwo)
			{
				num += Vwo;
			}
			while (uint_1 != 0)
			{
				if (num >= Vwo)
				{
					num = 0u;
				}
				bwH[twC++] = bwH[num++];
				if (twC >= Vwo)
				{
					ewj();
				}
				uint_1--;
			}
		}

		public void awt(byte byte_0)
		{
			bwH[twC++] = byte_0;
			if (twC >= Vwo)
			{
				ewj();
			}
		}

		public byte ewc(uint uint_0)
		{
			uint num = twC - uint_0 - 1;
			if (num >= Vwo)
			{
				num += Vwo;
			}
			return bwH[num];
		}
	}
}
