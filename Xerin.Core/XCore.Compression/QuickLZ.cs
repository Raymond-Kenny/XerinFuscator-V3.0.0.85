using System;
using System.IO;
using System.IO.Compression;

namespace XCore.Compression
{
	public static class QuickLZ
	{
		public const int QLZ_VERSION_MAJOR = 1;

		public const int QLZ_VERSION_MINOR = 5;

		public const int QLZ_VERSION_REVISION = 0;

		public const int QLZ_STREAMING_BUFFER = 0;

		public const int QLZ_MEMORY_SAFE = 0;

		public static byte[] CompressBytes2(byte[] byte_0)
		{
			MemoryStream memoryStream = new MemoryStream();
			using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionLevel.Optimal))
			{
				deflateStream.Write(byte_0, 0, byte_0.Length);
			}
			return memoryStream.ToArray();
		}

		private static int tQh(object object_0)
		{
			return ((((byte[])object_0)[0] & 2) == 2) ? 9 : 3;
		}

		public static int sizeCompressed(byte[] byte_0)
		{
			if (tQh(byte_0) != 9)
			{
				return byte_0[1];
			}
			return byte_0[1] | (byte_0[2] << 8) | (byte_0[3] << 16) | (byte_0[4] << 24);
		}

		private static void tQr(object object_0, int int_0, bool bool_0, int int_1, int int_2)
		{
			((sbyte[])object_0)[0] = (sbyte)(byte)(2 | (bool_0 ? 1 : 0));
			((byte[])object_0)[0] |= (byte)(int_0 << 2);
			((byte[])object_0)[0] |= 64;
			((byte[])object_0)[0] |= 0;
			uQc(object_0, 1, int_2, 4);
			uQc(object_0, 5, int_1, 4);
		}

		public static byte[] CompressBytes(byte[] byte_0)
		{
			int num = 3;
			int i = 0;
			int num2 = 13;
			uint num3 = 2147483648u;
			int int_ = 9;
			byte[] array = new byte[byte_0.Length + 400];
			int[] array2 = new int[4096];
			byte[] array3 = new byte[4096];
			int num4 = 0;
			int num5 = byte_0.Length - 6 - 4 - 1;
			int num6 = 0;
			int[,] array4 = new int[4096, 16];
			if (byte_0.Length != 0)
			{
				if (i <= num5)
				{
					num4 = byte_0[i] | (byte_0[i + 1] << 8) | (byte_0[i + 2] << 16);
				}
				byte[] array5;
				while (i <= num5)
				{
					if ((num3 & 1) == 1)
					{
						if (i > byte_0.Length >> 1 && num2 > i - (i >> 5))
						{
							array5 = new byte[byte_0.Length + 9];
							tQr(array5, num, false, byte_0.Length, byte_0.Length + 9);
							Array.Copy(byte_0, 0, array5, 9, byte_0.Length);
							return array5;
						}
						uQc(array, int_, (int)(num3 >> 1) | int.MinValue, 4);
						int_ = num2;
						num2 += 4;
						num3 = 2147483648u;
					}
					if (num == 1)
					{
						int num7 = ((num4 >> 12) ^ num4) & 0xFFF;
						int num8 = array4[num7, 0];
						int num9 = array2[num7] ^ num4;
						array2[num7] = num4;
						array4[num7, 0] = i;
						if (num9 == 0 && array3[num7] != 0 && (i - num8 > 2 || (i == num8 + 1 && num6 >= 3 && i > 3 && byte_0[i] == byte_0[i - 3] && byte_0[i] == byte_0[i - 2] && byte_0[i] == byte_0[i - 1] && byte_0[i] == byte_0[i + 1] && byte_0[i] == byte_0[i + 2])))
						{
							num3 = (num3 >> 1) | 0x80000000u;
							if (byte_0[num8 + 3] != byte_0[i + 3])
							{
								int num10 = 1 | (num7 << 4);
								array[num2] = (byte)num10;
								array[num2 + 1] = (byte)(num10 >> 8);
								i += 3;
								num2 += 2;
							}
							else
							{
								int num11 = i;
								int num12 = ((byte_0.Length - 4 - i + 1 - 1 > 255) ? 255 : (byte_0.Length - 4 - i + 1 - 1));
								i += 4;
								if (byte_0[num8 + i - num11] == byte_0[i])
								{
									i++;
									if (byte_0[num8 + i - num11] == byte_0[i])
									{
										for (i++; byte_0[num8 + (i - num11)] == byte_0[i] && i - num11 < num12; i++)
										{
										}
									}
								}
								int num13 = i - num11;
								num7 <<= 4;
								if (num13 < 18)
								{
									int num14 = num7 | (num13 - 2);
									array[num2] = (byte)num14;
									array[num2 + 1] = (byte)(num14 >> 8);
									num2 += 2;
								}
								else
								{
									uQc(array, num2, num7 | (num13 << 16), 3);
									num2 += 3;
								}
							}
							num4 = byte_0[i] | (byte_0[i + 1] << 8) | (byte_0[i + 2] << 16);
							num6 = 0;
						}
						else
						{
							num6++;
							array3[num7] = 1;
							array[num2] = byte_0[i];
							num3 >>= 1;
							i++;
							num2++;
							num4 = ((num4 >> 8) & 0xFFFF) | (byte_0[i + 2] << 16);
						}
						continue;
					}
					num4 = byte_0[i] | (byte_0[i + 1] << 8) | (byte_0[i + 2] << 16);
					int num15 = ((byte_0.Length - 4 - i + 1 - 1 <= 255) ? (byte_0.Length - 4 - i + 1 - 1) : 255);
					int num16 = ((num4 >> 12) ^ num4) & 0xFFF;
					byte b = array3[num16];
					int num17 = 0;
					int num18 = 0;
					int num19;
					for (int j = 0; j < 16 && b > j; j++)
					{
						num19 = array4[num16, j];
						if ((byte)num4 == byte_0[num19] && (byte)(num4 >> 8) == byte_0[num19 + 1] && (byte)(num4 >> 16) == byte_0[num19 + 2] && num19 < i - 2)
						{
							int k;
							for (k = 3; byte_0[num19 + k] == byte_0[i + k] && k < num15; k++)
							{
							}
							if (k > num17 || (k == num17 && num19 > num18))
							{
								num18 = num19;
								num17 = k;
							}
						}
					}
					num19 = num18;
					array4[num16, b & 0xF] = i;
					b++;
					array3[num16] = b;
					if (num17 < 3 || i - num19 >= 131071)
					{
						array[num2] = byte_0[i];
						num3 >>= 1;
						i++;
						num2++;
						continue;
					}
					int num20 = i - num19;
					for (int l = 1; l < num17; l++)
					{
						num4 = byte_0[i + l] | (byte_0[i + l + 1] << 8) | (byte_0[i + l + 2] << 16);
						num16 = ((num4 >> 12) ^ num4) & 0xFFF;
						array4[num16, array3[num16]++ & 0xF] = i + l;
					}
					i += num17;
					num3 = (num3 >> 1) | 0x80000000u;
					if (num17 == 3 && num20 <= 63)
					{
						uQc(array, num2, num20 << 2, 1);
						num2++;
					}
					else if (num17 != 3 || num20 > 16383)
					{
						if (num17 <= 18 && num20 <= 1023)
						{
							uQc(array, num2, (num17 - 3 << 2) | (num20 << 6) | 2, 2);
							num2 += 2;
						}
						else if (num17 > 33)
						{
							uQc(array, num2, (num17 - 3 << 7) | (num20 << 15) | 3, 4);
							num2 += 4;
						}
						else
						{
							uQc(array, num2, (num17 - 2 << 2) | (num20 << 7) | 3, 3);
							num2 += 3;
						}
					}
					else
					{
						uQc(array, num2, (num20 << 2) | 1, 2);
						num2 += 2;
					}
					num6 = 0;
				}
				while (i <= byte_0.Length - 1)
				{
					if ((num3 & 1) == 1)
					{
						uQc(array, int_, (int)(num3 >> 1) | int.MinValue, 4);
						int_ = num2;
						num2 += 4;
						num3 = 2147483648u;
					}
					array[num2] = byte_0[i];
					i++;
					num2++;
					num3 >>= 1;
				}
				while ((num3 & 1) != 1)
				{
					num3 >>= 1;
				}
				uQc(array, int_, (int)(num3 >> 1) | int.MinValue, 4);
				tQr(array, num, true, byte_0.Length, num2);
				array5 = new byte[num2];
				Array.Copy(array, array5, num2);
				return array5;
			}
			return new byte[0];
		}

		private static void uQc(object object_0, int int_0, int int_1, int int_2)
		{
			for (int i = 0; i < int_2; i++)
			{
				((sbyte[])object_0)[int_0 + i] = (sbyte)(byte)(int_1 >> i * 8);
			}
		}
	}
}
