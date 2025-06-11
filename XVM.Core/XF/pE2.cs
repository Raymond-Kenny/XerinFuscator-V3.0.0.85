namespace XF
{
	internal class pE2
	{
		public static readonly uint[] zEL;

		private uint iEk = uint.MaxValue;

		static pE2()
		{
			zEL = new uint[256];
			for (uint num = 0u; num < 256; num++)
			{
				uint num2 = num;
				for (int i = 0; i < 8; i++)
				{
					num2 = (((num2 & 1) != 0) ? ((num2 >> 1) ^ 0xEDB88320u) : (num2 >> 1));
				}
				zEL[num] = num2;
			}
		}

		public void JEK()
		{
			iEk = uint.MaxValue;
		}

		public void CE1(byte byte_0)
		{
			iEk = zEL[(byte)iEk ^ byte_0] ^ (iEk >> 8);
		}

		public void JEj(byte[] byte_0, uint uint_0, uint uint_1)
		{
			for (uint num = 0u; num < uint_1; num++)
			{
				iEk = zEL[(byte)iEk ^ byte_0[uint_0 + num]] ^ (iEk >> 8);
			}
		}

		public uint GEO()
		{
			return iEk ^ 0xFFFFFFFFu;
		}

		private static uint UEt(byte[] byte_0, uint uint_0, uint uint_1)
		{
			pE2 pE3 = new pE2();
			pE3.JEj(byte_0, uint_0, uint_1);
			return pE3.GEO();
		}

		private static bool bEc(uint uint_0, byte[] byte_0, uint uint_1, uint uint_2)
		{
			return UEt(byte_0, uint_1, uint_2) == uint_0;
		}
	}
}
