using System.IO;

namespace XF
{
	internal class RRr
	{
		public uint ORJ;

		public uint IR8;

		public Stream HRz;

		public void uR3(Stream stream_0)
		{
			HRz = stream_0;
			ORJ = 0u;
			IR8 = uint.MaxValue;
			for (int i = 0; i < 5; i++)
			{
				ORJ = (ORJ << 8) | (byte)HRz.ReadByte();
			}
		}

		public void XRX()
		{
			HRz = null;
		}

		public void BRn()
		{
			HRz.Close();
		}

		public void UR6()
		{
			while (IR8 < 16777216)
			{
				ORJ = (ORJ << 8) | (byte)HRz.ReadByte();
				IR8 <<= 8;
			}
		}

		public void qRx()
		{
			if (IR8 < 16777216)
			{
				ORJ = (ORJ << 8) | (byte)HRz.ReadByte();
				IR8 <<= 8;
			}
		}

		public uint lRs(uint uint_0)
		{
			return ORJ / (IR8 /= uint_0);
		}

		public void eRQ(uint uint_0, uint uint_1, uint uint_2)
		{
			ORJ -= uint_0 * IR8;
			IR8 *= uint_1;
			UR6();
		}

		public uint RRf(int int_0)
		{
			uint num = IR8;
			uint num2 = ORJ;
			uint num3 = 0u;
			for (int num4 = int_0; num4 > 0; num4--)
			{
				num >>= 1;
				uint num5 = num2 - num >> 31;
				num2 -= num & (num5 - 1);
				num3 = (num3 << 1) | (1 - num5);
				if (num < 16777216)
				{
					num2 = (num2 << 8) | (byte)HRz.ReadByte();
					num <<= 8;
				}
			}
			IR8 = num;
			ORJ = num2;
			return num3;
		}

		public uint JRi(uint uint_0, int int_0)
		{
			uint num = (IR8 >> int_0) * uint_0;
			uint result;
			if (ORJ < num)
			{
				result = 0u;
				IR8 = num;
			}
			else
			{
				result = 1u;
				ORJ -= num;
				IR8 -= num;
			}
			UR6();
			return result;
		}
	}
}
