namespace XVM.DynCipher
{
	public static class MathsUtils
	{
		public static ulong modInv(ulong ulong_0, ulong ulong_1)
		{
			ulong num = ulong_1;
			ulong num2 = ulong_0 % ulong_1;
			ulong num3 = 0uL;
			ulong num4 = 1uL;
			while (true)
			{
				if (num2 > 0L)
				{
					if (num2 == 1L)
					{
						break;
					}
					num3 += num / num2 * num4;
					num %= num2;
					switch (num)
					{
					default:
						goto IL_0061;
					case 0uL:
						break;
					case 1uL:
						return ulong_1 - num3;
					}
				}
				return 0uL;
				IL_0061:
				num4 += num2 / num * num3;
				num2 %= num;
			}
			return num4;
		}

		public static uint modInv(uint uint_0)
		{
			return (uint)modInv(uint_0, 4294967296uL);
		}

		public static byte modInv(byte byte_0)
		{
			return (byte)modInv(byte_0, 256uL);
		}
	}
}
