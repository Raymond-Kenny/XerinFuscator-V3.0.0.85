using System.IO;

namespace XF
{
	internal class MED
	{
		private readonly byte[] EE6;

		private readonly uint EEx;

		private uint pEQ;

		private ulong OEf;

		private Stream PEi;

		public MED(uint uint_0)
		{
			EE6 = new byte[uint_0];
			EEx = uint_0;
		}

		public void IEy(Stream stream_0)
		{
			PEi = stream_0;
		}

		public void DEY()
		{
			PEi.Flush();
		}

		public void pEV()
		{
			PEi.Close();
		}

		public void nEb()
		{
			PEi = null;
		}

		public void dEr()
		{
			OEf = 0uL;
			pEQ = 0u;
		}

		public void BE3(byte byte_0)
		{
			EE6[pEQ++] = byte_0;
			if (pEQ >= EEx)
			{
				mEX();
			}
		}

		public void mEX()
		{
			if (pEQ != 0)
			{
				PEi.Write(EE6, 0, (int)pEQ);
				pEQ = 0u;
			}
		}

		public ulong aEn()
		{
			return OEf + pEQ;
		}
	}
}
