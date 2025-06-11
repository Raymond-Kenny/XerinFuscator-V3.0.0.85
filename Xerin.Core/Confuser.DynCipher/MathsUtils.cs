namespace Confuser.DynCipher
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
				switch (num2)
				{
				default:
					num3 += num / num2 * num4;
					num %= num2;
					switch (num)
					{
					default:
						goto IL_0061;
					case 1uL:
						return ulong_1 - num3;
					case 0uL:
						break;
					}
					break;
				case 1uL:
					return num4;
				case 0uL:
					break;
				}
				break;
				IL_0061:
				num4 += num2 / num * num3;
				num2 %= num;
			}
			return 0uL;
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
