using System;

namespace XRuntime
{
	public static class QuickLZDecompression
	{
		public const int CWORD_LEN = 4;

		public const int HASH_VALUES = 4096;

		public const int UNCONDITIONAL_MATCHLEN = 6;

		public const int UNCOMPRESSED_END = 4;

		public static int headerLen(byte[] source)
		{
			return (source[0] & 2) == 2 ? 9 : 3;
		}

		public static int sizeDecompressed(byte[] source)
		{
			if (headerLen(source) == 9)
			{
				return source[5] | source[6] << 8 | source[7] << 16 | source[8] << 24;
			}
			return source[2];
		}

		public static byte[] decompress(byte[] source)
		{
			int num = sizeDecompressed(source);
			int num2 = headerLen(source);
			int num3 = 0;
			uint num4 = 1u;
			byte[] array = new byte[num];
			int[] array2 = new int[4096];
			byte[] array3 = new byte[4096];
			int num5 = num - 6 - 4 - 1;
			int num6 = -1;
			uint num7 = 0u;
			int num8 = source[0] >> 2 & 3;
			if (num8 != 1 && num8 != 3)
			{
				throw new ArgumentException("C# version only supports level 1 and 3");
			}
			if ((source[0] & 1) != 1)
			{
				byte[] array4 = new byte[num];
				Array.Copy(source, headerLen(source), array4, 0, num);
				return array4;
			}
			while (true)
			{
				if (num4 == 1)
				{
					num4 = (uint)(source[num2] | source[num2 + 1] << 8 | source[num2 + 2] << 16 | source[num2 + 3] << 24);
					num2 += 4;
					if (num3 <= num5)
					{
						num7 = (uint)(num8 != 1 ? source[num2] | source[num2 + 1] << 8 | source[num2 + 2] << 16 | source[num2 + 3] << 24 : source[num2] | source[num2 + 1] << 8 | source[num2 + 2] << 16);
					}
				}
				if ((num4 & 1) == 1)
				{
					num4 >>= 1;
					uint num10;
					uint num11;
					if (num8 == 1)
					{
						int num9 = (int)num7 >> 4 & 0xFFF;
						num10 = (uint)array2[num9];
						if ((num7 & 0xF) != 0)
						{
							num11 = (num7 & 0xF) + 2;
							num2 += 2;
						}
						else
						{
							num11 = source[num2 + 2];
							num2 += 3;
						}
					}
					else
					{
						uint num12;
						if ((num7 & 3) == 0)
						{
							num12 = (num7 & 0xFF) >> 2;
							num11 = 3u;
							num2++;
						}
						else if ((num7 & 2) == 0)
						{
							num12 = (num7 & 0xFFFF) >> 2;
							num11 = 3u;
							num2 += 2;
						}
						else if ((num7 & 1) == 0)
						{
							num12 = (num7 & 0xFFFF) >> 6;
							num11 = (num7 >> 2 & 0xF) + 3;
							num2 += 2;
						}
						else if ((num7 & 0x7F) != 3)
						{
							num12 = num7 >> 7 & 0x1FFFF;
							num11 = (num7 >> 2 & 0x1F) + 2;
							num2 += 3;
						}
						else
						{
							num12 = num7 >> 15;
							num11 = (num7 >> 7 & 0xFF) + 3;
							num2 += 4;
						}
						num10 = (uint)(num3 - num12);
					}
					array[num3] = array[num10];
					array[num3 + 1] = array[num10 + 1];
					array[num3 + 2] = array[num10 + 2];
					for (int i = 3; i < num11; i++)
					{
						array[num3 + i] = array[num10 + i];
					}
					num3 += (int)num11;
					if (num8 == 1)
					{
						num7 = (uint)(array[num6 + 1] | array[num6 + 2] << 8 | array[num6 + 3] << 16);
						while (num6 < num3 - num11)
						{
							num6++;
							int num9 = (int)((num7 >> 12 ^ num7) & 0xFFF);
							array2[num9] = num6;
							array3[num9] = 1;
							num7 = (uint)(num7 >> 8 & 0xFFFF | array[num6 + 3] << 16);
						}
						num7 = (uint)(source[num2] | source[num2 + 1] << 8 | source[num2 + 2] << 16);
					}
					else
					{
						num7 = (uint)(source[num2] | source[num2 + 1] << 8 | source[num2 + 2] << 16 | source[num2 + 3] << 24);
					}
					num6 = num3 - 1;
					continue;
				}
				if (num3 > num5)
				{
					break;
				}
				array[num3] = source[num2];
				num3++;
				num2++;
				num4 >>= 1;
				if (num8 == 1)
				{
					while (num6 < num3 - 3)
					{
						num6++;
						int num13 = array[num6] | array[num6 + 1] << 8 | array[num6 + 2] << 16;
						int num9 = (num13 >> 12 ^ num13) & 0xFFF;
						array2[num9] = num6;
						array3[num9] = 1;
					}
					num7 = (uint)(num7 >> 8 & 0xFFFF | source[num2 + 2] << 16);
				}
				else
				{
					num7 = (uint)(num7 >> 8 & 0xFFFF | source[num2 + 2] << 16 | source[num2 + 3] << 24);
				}
			}
			while (num3 <= num - 1)
			{
				if (num4 == 1)
				{
					num2 += 4;
					num4 = 2147483648u;
				}
				array[num3] = source[num2];
				num3++;
				num2++;
				num4 >>= 1;
			}
			return array;
		}
	}
}
