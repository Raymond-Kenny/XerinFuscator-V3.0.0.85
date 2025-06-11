using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace XF
{
	internal class w0G
	{
		private delegate void Yo0(object o);

		internal class KoR : Attribute
		{
			internal class xoo<woD>
			{
				internal static object GIC;

				internal static bool oIe()
				{
					return GIC == null;
				}

				internal static object KIJ()
				{
					return GIC;
				}
			}

			public KoR(object object_0)
			{
			}
		}

		internal class uod
		{
			internal static string So1(string string_0, string string_1)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string_0);
				byte[] key = new byte[32]
				{
					82, 102, 104, 110, 32, 77, 24, 34, 118, 181,
					51, 17, 18, 51, 12, 109, 10, 32, 77, 24,
					34, 158, 161, 41, 97, 28, 118, 181, 5, 25,
					1, 88
				};
				byte[] iV = t0l(Encoding.Unicode.GetBytes(string_1));
				MemoryStream memoryStream = new MemoryStream();
				SymmetricAlgorithm symmetricAlgorithm = B0i();
				symmetricAlgorithm.Key = key;
				symmetricAlgorithm.IV = iV;
				CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
				cryptoStream.Write(bytes, 0, bytes.Length);
				cryptoStream.Close();
				return Convert.ToBase64String(memoryStream.ToArray());
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal delegate uint Cov(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr mox();

		internal struct eoj
		{
			internal bool foK;

			internal byte[] Jo4;
		}

		internal class oon
		{
			private BinaryReader aoq;

			public oon(Stream stream_0)
			{
				aoq = new BinaryReader(stream_0);
			}

			[SpecialName]
			internal Stream method_0()
			{
				return aoq.BaseStream;
			}

			internal byte[] Toh(int int_0)
			{
				return aoq.ReadBytes(int_0);
			}

			internal int Cor(byte[] byte_0, int int_0, int int_1)
			{
				return aoq.Read(byte_0, int_0, int_1);
			}

			internal int Koc()
			{
				return aoq.ReadInt32();
			}

			internal void Row()
			{
				aoq.Close();
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
		private delegate IntPtr boy(IntPtr hModule, string lpName, uint lpType);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr Cob(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate int Tok(IntPtr hProcess, IntPtr lpBaseAddress, [In][Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate int rou(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate IntPtr Lo3(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate int Ro5(IntPtr ptr);

		[Flags]
		private enum voH
		{

		}

		private static List<string> uRa;

		private static int vRg;

		private static bool XR3;

		private static object vRZ;

		private static bool rRz;

		private static int DR8;

		private static byte[] SRm;

		private static long lRI;

		private static IntPtr LRP;

		private static SortedList eRl;

		private static uint[] WRH;

		[KoR(typeof(KoR.xoo<object>[]))]
		private static bool HoY;

		private static IntPtr Lo6;

		private static Ro5 Jo7;

		internal static Assembly SR5;

		internal static Hashtable roQ;

		private static Lo3 aot;

		private static object dRG;

		private static byte[] KRA;

		internal static Cov kR2;

		private static IntPtr xR9;

		private static rou woJ;

		internal static object TRV;

		private static Dictionary<int, int> ERW;

		private static bool ORL;

		private static bool lRM;

		private static List<int> rRX;

		private static Cob GoC;

		private static Tok Yoe;

		private static IntPtr aoU;

		internal static Cov xRs;

		private static int sRi;

		private static bool VRp;

		private static int[] dRT;

		private static boy MoF;

		private static string[] KRf;

		private static int poN;

		private static bool BRS;

		private static long CRE;

		private static int qRO;

		static w0G()
		{
			XR3 = false;
			SR5 = typeof(w0G).Assembly;
			WRH = new uint[64]
			{
				3614090360u, 3905402710u, 606105819u, 3250441966u, 4118548399u, 1200080426u, 2821735955u, 4249261313u, 1770035416u, 2336552879u,
				4294925233u, 2304563134u, 1804603682u, 4254626195u, 2792965006u, 1236535329u, 4129170786u, 3225465664u, 643717713u, 3921069994u,
				3593408605u, 38016083u, 3634488961u, 3889429448u, 568446438u, 3275163606u, 4107603335u, 1163531501u, 2850285829u, 4243563512u,
				1735328473u, 2368359562u, 4294588738u, 2272392833u, 1839030562u, 4259657740u, 2763975236u, 1272893353u, 4139469664u, 3200236656u,
				681279174u, 3936430074u, 3572445317u, 76029189u, 3654602809u, 3873151461u, 530742520u, 3299628645u, 4096336452u, 1126891415u,
				2878612391u, 4237533241u, 1700485571u, 2399980690u, 4293915773u, 2240044497u, 1873313359u, 4264355552u, 2734768916u, 1309151649u,
				4149444226u, 3174756917u, 718787259u, 3951481745u
			};
			lRM = false;
			ORL = false;
			TRV = null;
			ERW = null;
			dRG = new object();
			DR8 = 0;
			vRZ = new object();
			uRa = null;
			rRX = null;
			SRm = new byte[0];
			KRA = new byte[0];
			xR9 = IntPtr.Zero;
			LRP = IntPtr.Zero;
			KRf = new string[0];
			dRT = new int[0];
			sRi = 1;
			BRS = false;
			eRl = new SortedList();
			qRO = 0;
			lRI = 0L;
			kR2 = null;
			xRs = null;
			CRE = 0L;
			vRg = 0;
			VRp = false;
			rRz = false;
			poN = 0;
			aoU = IntPtr.Zero;
			HoY = false;
			roQ = new Hashtable();
			MoF = null;
			GoC = null;
			Yoe = null;
			woJ = null;
			aot = null;
			Jo7 = null;
			Lo6 = IntPtr.Zero;
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		private void V2d()
		{
		}

		internal static byte[] g08(object object_0)
		{
			uint[] array = new uint[16];
			uint num = (uint)((448 - ((Array)object_0).Length * 8 % 512 + 512) % 512);
			if (num == 0)
			{
				num = 512u;
			}
			uint num2 = (uint)(((Array)object_0).Length + num / 8 + 8L);
			ulong num3 = (ulong)(((Array)object_0).Length * 8L);
			byte[] array2 = new byte[num2];
			for (int i = 0; i < ((Array)object_0).Length; i++)
			{
				array2[i] = ((byte[])object_0)[i];
			}
			array2[((Array)object_0).Length] |= 128;
			for (int num4 = 8; num4 > 0; num4--)
			{
				array2[num2 - num4] = (byte)((num3 >> (8 - num4) * 8) & 0xFFL);
			}
			uint num5 = (uint)(array2.Length * 8) / 32u;
			uint uint_ = 1732584193u;
			uint uint_2 = 4023233417u;
			uint uint_3 = 2562383102u;
			uint uint_4 = 271733878u;
			for (uint num6 = 0u; num6 < num5 / 16; num6++)
			{
				uint num7 = num6 << 6;
				for (uint num8 = 0u; num8 < 61; num8 += 4)
				{
					array[num8 >> 2] = (uint)((array2[num7 + (num8 + 3)] << 24) | (array2[num7 + (num8 + 2)] << 16) | (array2[num7 + (num8 + 1)] << 8) | array2[num7 + num8]);
				}
				uint num9 = uint_;
				uint num10 = uint_2;
				uint num11 = uint_3;
				uint num12 = uint_4;
				w0Z(ref uint_, uint_2, uint_3, uint_4, 0u, 7, 1u, array);
				w0Z(ref uint_4, uint_, uint_2, uint_3, 1u, 12, 2u, array);
				w0Z(ref uint_3, uint_4, uint_, uint_2, 2u, 17, 3u, array);
				w0Z(ref uint_2, uint_3, uint_4, uint_, 3u, 22, 4u, array);
				w0Z(ref uint_, uint_2, uint_3, uint_4, 4u, 7, 5u, array);
				w0Z(ref uint_4, uint_, uint_2, uint_3, 5u, 12, 6u, array);
				w0Z(ref uint_3, uint_4, uint_, uint_2, 6u, 17, 7u, array);
				w0Z(ref uint_2, uint_3, uint_4, uint_, 7u, 22, 8u, array);
				w0Z(ref uint_, uint_2, uint_3, uint_4, 8u, 7, 9u, array);
				w0Z(ref uint_4, uint_, uint_2, uint_3, 9u, 12, 10u, array);
				w0Z(ref uint_3, uint_4, uint_, uint_2, 10u, 17, 11u, array);
				w0Z(ref uint_2, uint_3, uint_4, uint_, 11u, 22, 12u, array);
				w0Z(ref uint_, uint_2, uint_3, uint_4, 12u, 7, 13u, array);
				w0Z(ref uint_4, uint_, uint_2, uint_3, 13u, 12, 14u, array);
				w0Z(ref uint_3, uint_4, uint_, uint_2, 14u, 17, 15u, array);
				w0Z(ref uint_2, uint_3, uint_4, uint_, 15u, 22, 16u, array);
				x0a(ref uint_, uint_2, uint_3, uint_4, 1u, 5, 17u, array);
				x0a(ref uint_4, uint_, uint_2, uint_3, 6u, 9, 18u, array);
				x0a(ref uint_3, uint_4, uint_, uint_2, 11u, 14, 19u, array);
				x0a(ref uint_2, uint_3, uint_4, uint_, 0u, 20, 20u, array);
				x0a(ref uint_, uint_2, uint_3, uint_4, 5u, 5, 21u, array);
				x0a(ref uint_4, uint_, uint_2, uint_3, 10u, 9, 22u, array);
				x0a(ref uint_3, uint_4, uint_, uint_2, 15u, 14, 23u, array);
				x0a(ref uint_2, uint_3, uint_4, uint_, 4u, 20, 24u, array);
				x0a(ref uint_, uint_2, uint_3, uint_4, 9u, 5, 25u, array);
				x0a(ref uint_4, uint_, uint_2, uint_3, 14u, 9, 26u, array);
				x0a(ref uint_3, uint_4, uint_, uint_2, 3u, 14, 27u, array);
				x0a(ref uint_2, uint_3, uint_4, uint_, 8u, 20, 28u, array);
				x0a(ref uint_, uint_2, uint_3, uint_4, 13u, 5, 29u, array);
				x0a(ref uint_4, uint_, uint_2, uint_3, 2u, 9, 30u, array);
				x0a(ref uint_3, uint_4, uint_, uint_2, 7u, 14, 31u, array);
				x0a(ref uint_2, uint_3, uint_4, uint_, 12u, 20, 32u, array);
				x0X(ref uint_, uint_2, uint_3, uint_4, 5u, 4, 33u, array);
				x0X(ref uint_4, uint_, uint_2, uint_3, 8u, 11, 34u, array);
				x0X(ref uint_3, uint_4, uint_, uint_2, 11u, 16, 35u, array);
				x0X(ref uint_2, uint_3, uint_4, uint_, 14u, 23, 36u, array);
				x0X(ref uint_, uint_2, uint_3, uint_4, 1u, 4, 37u, array);
				x0X(ref uint_4, uint_, uint_2, uint_3, 4u, 11, 38u, array);
				x0X(ref uint_3, uint_4, uint_, uint_2, 7u, 16, 39u, array);
				x0X(ref uint_2, uint_3, uint_4, uint_, 10u, 23, 40u, array);
				x0X(ref uint_, uint_2, uint_3, uint_4, 13u, 4, 41u, array);
				x0X(ref uint_4, uint_, uint_2, uint_3, 0u, 11, 42u, array);
				x0X(ref uint_3, uint_4, uint_, uint_2, 3u, 16, 43u, array);
				x0X(ref uint_2, uint_3, uint_4, uint_, 6u, 23, 44u, array);
				x0X(ref uint_, uint_2, uint_3, uint_4, 9u, 4, 45u, array);
				x0X(ref uint_4, uint_, uint_2, uint_3, 12u, 11, 46u, array);
				x0X(ref uint_3, uint_4, uint_, uint_2, 15u, 16, 47u, array);
				x0X(ref uint_2, uint_3, uint_4, uint_, 2u, 23, 48u, array);
				H09(ref uint_, uint_2, uint_3, uint_4, 0u, 6, 49u, array);
				H09(ref uint_4, uint_, uint_2, uint_3, 7u, 10, 50u, array);
				H09(ref uint_3, uint_4, uint_, uint_2, 14u, 15, 51u, array);
				H09(ref uint_2, uint_3, uint_4, uint_, 5u, 21, 52u, array);
				H09(ref uint_, uint_2, uint_3, uint_4, 12u, 6, 53u, array);
				H09(ref uint_4, uint_, uint_2, uint_3, 3u, 10, 54u, array);
				H09(ref uint_3, uint_4, uint_, uint_2, 10u, 15, 55u, array);
				H09(ref uint_2, uint_3, uint_4, uint_, 1u, 21, 56u, array);
				H09(ref uint_, uint_2, uint_3, uint_4, 8u, 6, 57u, array);
				H09(ref uint_4, uint_, uint_2, uint_3, 15u, 10, 58u, array);
				H09(ref uint_3, uint_4, uint_, uint_2, 6u, 15, 59u, array);
				H09(ref uint_2, uint_3, uint_4, uint_, 13u, 21, 60u, array);
				H09(ref uint_, uint_2, uint_3, uint_4, 4u, 6, 61u, array);
				H09(ref uint_4, uint_, uint_2, uint_3, 11u, 10, 62u, array);
				H09(ref uint_3, uint_4, uint_, uint_2, 2u, 15, 63u, array);
				H09(ref uint_2, uint_3, uint_4, uint_, 9u, 21, 64u, array);
				uint_ += num9;
				uint_2 += num10;
				uint_3 += num11;
				uint_4 += num12;
			}
			byte[] array3 = new byte[16];
			Array.Copy(BitConverter.GetBytes(uint_), 0, array3, 0, 4);
			Array.Copy(BitConverter.GetBytes(uint_2), 0, array3, 4, 4);
			Array.Copy(BitConverter.GetBytes(uint_3), 0, array3, 8, 4);
			Array.Copy(BitConverter.GetBytes(uint_4), 0, array3, 12, 4);
			return array3;
		}

		private static void w0Z(ref uint uint_0, uint uint_1, uint uint_2, uint uint_3, uint uint_4, ushort ushort_0, uint uint_5, object object_0)
		{
			uint_0 = uint_1 + L0P(uint_0 + ((uint_1 & uint_2) | (~uint_1 & uint_3)) + ((uint[])object_0)[uint_4] + WRH[uint_5 - 1], ushort_0);
		}

		private static void x0a(ref uint uint_0, uint uint_1, uint uint_2, uint uint_3, uint uint_4, ushort ushort_0, uint uint_5, object object_0)
		{
			uint_0 = uint_1 + L0P(uint_0 + ((uint_1 & uint_3) | (uint_2 & ~uint_3)) + ((uint[])object_0)[uint_4] + WRH[uint_5 - 1], ushort_0);
		}

		private static void x0X(ref uint uint_0, uint uint_1, uint uint_2, uint uint_3, uint uint_4, ushort ushort_0, uint uint_5, object object_0)
		{
			uint_0 = uint_1 + L0P(uint_0 + (uint_1 ^ uint_2 ^ uint_3) + ((uint[])object_0)[uint_4] + WRH[uint_5 - 1], ushort_0);
		}

		private static void H09(ref uint uint_0, uint uint_1, uint uint_2, uint uint_3, uint uint_4, ushort ushort_0, uint uint_5, object object_0)
		{
			uint_0 = uint_1 + L0P(uint_0 + (uint_2 ^ (uint_1 | ~uint_3)) + ((uint[])object_0)[uint_4] + WRH[uint_5 - 1], ushort_0);
		}

		private static uint L0P(uint uint_0, ushort ushort_0)
		{
			return (uint_0 >> 32 - ushort_0) | (uint_0 << (int)ushort_0);
		}

		internal static bool A0f()
		{
			if (!lRM)
			{
				S0S();
				lRM = true;
			}
			return ORL;
		}

		internal w0G()
		{
		}

		private void R0T(byte[] byte_0, byte[] byte_1, byte[] byte_2)
		{
			int num = byte_2.Length % 4;
			int num2 = byte_2.Length / 4;
			byte[] array = new byte[byte_2.Length];
			int num3 = byte_0.Length / 4;
			uint num4 = 0u;
			uint num5 = 0u;
			uint num6 = 0u;
			if (num > 0)
			{
				num2++;
			}
			uint num7 = 0u;
			for (int i = 0; i < num2; i++)
			{
				int num8 = i % num3;
				int num9 = i * 4;
				num7 = (uint)(num8 * 4);
				num5 = (uint)((byte_0[num7 + 3] << 24) | (byte_0[num7 + 2] << 16) | (byte_0[num7 + 1] << 8) | byte_0[num7]);
				uint num10 = 255u;
				int num11 = 0;
				if (i == num2 - 1 && num > 0)
				{
					num6 = 0u;
					num4 += num5;
					for (int k = 0; k < num; k++)
					{
						if (k > 0)
						{
							num6 <<= 8;
						}
						num6 |= byte_2[byte_2.Length - (1 + k)];
					}
				}
				else
				{
					num4 += num5;
					num7 = (uint)num9;
					num6 = (uint)((byte_2[num7 + 3] << 24) | (byte_2[num7 + 2] << 16) | (byte_2[num7 + 1] << 8) | byte_2[num7]);
				}
				uint num12 = num4;
				num4 = 0u;
				uint num13 = 485342649u;
				uint num14 = 326621713u;
				uint num15 = num12;
				uint num16 = 873418232u;
				ulong num17 = 2307900331uL;
				num17 = 2307900331uL;
				num15 = (uint)((ulong)(num15 * num15) % 2307900331uL);
				num17 = 484439473 * num15;
				num17 |= 1L;
				num13 = (uint)(1294249905L % num17);
				uint num18 = num15 / 326621713 + 326621713;
				num14 = (num15 + num15) * num18 + num15;
				num18 = num15 / 873418232 + 873418232;
				num16 = num15 + num15 + num18 + num15;
				num15 ^= num15 >> 15;
				num15 += num13;
				num15 ^= num15 >> 29;
				num15 += num14;
				num15 ^= num15 << 1;
				num15 += num16;
				num15 = (((num13 << 4) - num14) ^ num14) + num15;
				num4 = num12 + (uint)(double)num15;
				if (i == num2 - 1 && num > 0)
				{
					uint num19 = num4 ^ num6;
					for (int l = 0; l < num; l++)
					{
						if (l > 0)
						{
							num10 <<= 8;
							num11 += 8;
						}
						array[num9 + l] = (byte)((num19 & num10) >> num11);
					}
				}
				else
				{
					uint num20 = num4 ^ num6;
					array[num9] = (byte)(num20 & 0xFF);
					array[num9 + 1] = (byte)((num20 & 0xFF00) >> 8);
					array[num9 + 2] = (byte)((num20 & 0xFF0000) >> 16);
					array[num9 + 3] = (byte)((num20 & 0xFF000000u) >> 24);
				}
			}
			SRm = array;
		}

		internal static SymmetricAlgorithm B0i()
		{
			SymmetricAlgorithm symmetricAlgorithm = null;
			if (A0f())
			{
				return new AesCryptoServiceProvider();
			}
			try
			{
				return new RijndaelManaged();
			}
			catch
			{
				try
				{
					return (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
				}
				catch
				{
					return (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
				}
			}
		}

		internal static void S0S()
		{
			try
			{
				new MD5CryptoServiceProvider();
			}
			catch
			{
				ORL = true;
				return;
			}
			try
			{
				ORL = CryptoConfig.AllowOnlyFipsAlgorithms;
			}
			catch
			{
			}
		}

		internal static byte[] t0l(byte[] byte_0)
		{
			if (!A0f())
			{
				return new MD5CryptoServiceProvider().ComputeHash(byte_0);
			}
			return g08(byte_0);
		}

		internal static void d0O(HashAlgorithm hashAlgorithm_0, Stream stream_0, uint uint_0, byte[] byte_0)
		{
			while (uint_0 != 0)
			{
				int num = ((uint_0 > (uint)byte_0.Length) ? byte_0.Length : ((int)uint_0));
				stream_0.Read(byte_0, 0, num);
				L0I(hashAlgorithm_0, byte_0, 0, num);
				uint_0 -= (uint)num;
			}
		}

		internal static void L0I(HashAlgorithm hashAlgorithm_0, byte[] byte_0, int int_0, int int_1)
		{
			hashAlgorithm_0.TransformBlock(byte_0, int_0, int_1, byte_0, int_0);
		}

		internal static uint i02(uint uint_0, int int_0, long long_0, BinaryReader binaryReader_0)
		{
			int num = 0;
			uint num3;
			uint num4;
			while (true)
			{
				if (num < int_0)
				{
					binaryReader_0.BaseStream.Position = long_0 + (num * 40 + 8);
					uint num2 = binaryReader_0.ReadUInt32();
					num3 = binaryReader_0.ReadUInt32();
					binaryReader_0.ReadUInt32();
					num4 = binaryReader_0.ReadUInt32();
					if (num3 <= uint_0 && uint_0 < num3 + num2)
					{
						break;
					}
					num++;
					continue;
				}
				return 0u;
			}
			return num4 + uint_0 - num3;
		}

		private static void ORU(Stream stream_0, int int_0)
		{
			oon oon = new oon(stream_0);
			oon.method_0().Position = 0L;
			byte[] array = oon.Toh((int)oon.method_0().Length);
			oon.Row();
			byte[] array2 = new byte[32];
			array2[0] = 140;
			array2[0] = 96;
			array2[0] = 157;
			array2[1] = 98;
			array2[1] = 94;
			array2[1] = 95;
			array2[1] = 122;
			array2[1] = 247;
			array2[2] = 145;
			array2[2] = 137;
			array2[2] = 217;
			array2[3] = 137;
			array2[3] = 120;
			array2[3] = 125;
			array2[3] = 238;
			array2[4] = 146;
			array2[4] = 95;
			array2[4] = 76;
			array2[5] = 135;
			array2[5] = 133;
			array2[5] = 196;
			array2[5] = 142;
			array2[5] = 111;
			array2[5] = 24;
			array2[6] = 159;
			array2[6] = 168;
			array2[6] = 124;
			array2[6] = 54;
			array2[6] = 246;
			array2[7] = 136;
			array2[7] = 51;
			array2[7] = 112;
			array2[7] = 126;
			array2[7] = 99;
			array2[8] = 156;
			array2[8] = 100;
			array2[8] = 129;
			array2[8] = 156;
			array2[8] = 128;
			array2[8] = 184;
			array2[9] = 144;
			array2[9] = 160;
			array2[9] = 128;
			array2[9] = 114;
			array2[9] = 209;
			array2[10] = 92;
			array2[10] = 214;
			array2[10] = 143;
			array2[10] = 67;
			array2[11] = 183;
			array2[11] = 168;
			array2[11] = 134;
			array2[11] = 87;
			array2[11] = 211;
			array2[11] = 118;
			array2[12] = 184;
			array2[12] = 134;
			array2[12] = 122;
			array2[12] = 182;
			array2[12] = 104;
			array2[13] = 89;
			array2[13] = 147;
			array2[13] = 112;
			array2[13] = 86;
			array2[14] = 166;
			array2[14] = 166;
			array2[14] = 208;
			array2[14] = 249;
			array2[15] = 139;
			array2[15] = 103;
			array2[15] = 26;
			array2[15] = 233;
			array2[16] = 166;
			array2[16] = 140;
			array2[16] = 160;
			array2[16] = 98;
			array2[17] = 131;
			array2[17] = 112;
			array2[17] = 157;
			array2[17] = 115;
			array2[18] = 152;
			array2[18] = 141;
			array2[18] = 221;
			array2[18] = 91;
			array2[19] = 200;
			array2[19] = 227;
			array2[19] = 69;
			array2[19] = 13;
			array2[20] = 146;
			array2[20] = 123;
			array2[20] = 26;
			array2[21] = 94;
			array2[21] = 93;
			array2[21] = 43;
			array2[21] = 198;
			array2[22] = 72;
			array2[22] = 87;
			array2[22] = 178;
			array2[22] = 158;
			array2[22] = 164;
			array2[22] = 231;
			array2[23] = 130;
			array2[23] = 133;
			array2[23] = 235;
			array2[24] = 110;
			array2[24] = 88;
			array2[24] = 104;
			array2[24] = 113;
			array2[24] = 134;
			array2[24] = 109;
			array2[25] = 156;
			array2[25] = 98;
			array2[25] = 147;
			array2[25] = 125;
			array2[25] = 194;
			array2[26] = 107;
			array2[26] = 70;
			array2[26] = 124;
			array2[26] = 167;
			array2[26] = 101;
			array2[26] = 228;
			array2[27] = 42;
			array2[27] = 126;
			array2[27] = 170;
			array2[27] = 83;
			array2[27] = 156;
			array2[27] = 215;
			array2[28] = 85;
			array2[28] = 94;
			array2[28] = 249;
			array2[29] = 123;
			array2[29] = 132;
			array2[29] = 134;
			array2[29] = 100;
			array2[29] = 144;
			array2[29] = 130;
			array2[30] = 142;
			array2[30] = 90;
			array2[30] = 151;
			array2[30] = 123;
			array2[30] = 154;
			array2[30] = 157;
			array2[31] = 29;
			array2[31] = 169;
			array2[31] = 95;
			array2[31] = 135;
			array2[31] = 104;
			array2[31] = 121;
			byte[] array3 = array2;
			byte[] array4 = new byte[16];
			array4[0] = 37;
			array4[0] = 160;
			array4[0] = 160;
			array4[0] = 100;
			array4[1] = 153;
			array4[1] = 166;
			array4[1] = 111;
			array4[1] = 193;
			array4[1] = 161;
			array4[2] = 150;
			array4[2] = 126;
			array4[2] = 88;
			array4[2] = 109;
			array4[2] = 154;
			array4[2] = 75;
			array4[3] = 110;
			array4[3] = 115;
			array4[3] = 144;
			array4[3] = 9;
			array4[4] = 131;
			array4[4] = 160;
			array4[4] = 40;
			array4[4] = 100;
			array4[5] = 151;
			array4[5] = 196;
			array4[5] = 203;
			array4[6] = 154;
			array4[6] = 85;
			array4[6] = 220;
			array4[6] = 97;
			array4[6] = 91;
			array4[7] = 100;
			array4[7] = 93;
			array4[7] = 140;
			array4[7] = 184;
			array4[8] = 130;
			array4[8] = 96;
			array4[8] = 89;
			array4[8] = 93;
			array4[8] = 26;
			array4[9] = 83;
			array4[9] = 99;
			array4[9] = 137;
			array4[9] = 140;
			array4[9] = 68;
			array4[10] = 150;
			array4[10] = 170;
			array4[10] = 93;
			array4[11] = 218;
			array4[11] = 101;
			array4[11] = 165;
			array4[12] = 108;
			array4[12] = 99;
			array4[12] = 99;
			array4[12] = 167;
			array4[12] = 105;
			array4[13] = 141;
			array4[13] = 100;
			array4[13] = 158;
			array4[14] = 132;
			array4[14] = 87;
			array4[14] = 149;
			array4[14] = 91;
			array4[14] = 73;
			array4[15] = 68;
			array4[15] = 120;
			array4[15] = 165;
			byte[] array5 = array4;
			Array.Reverse(array5);
			byte[] publicKeyToken = SR5.GetName().GetPublicKeyToken();
			if (publicKeyToken != null && publicKeyToken.Length != 0)
			{
				array5[1] = publicKeyToken[0];
				array5[3] = publicKeyToken[1];
				array5[5] = publicKeyToken[2];
				array5[7] = publicKeyToken[3];
				array5[9] = publicKeyToken[4];
				array5[11] = publicKeyToken[5];
				array5[13] = publicKeyToken[6];
				array5[15] = publicKeyToken[7];
			}
			for (int i = 0; i < array5.Length; i++)
			{
				array3[i] ^= array5[i];
			}
			if (int_0 == -1)
			{
				SymmetricAlgorithm symmetricAlgorithm = B0i();
				symmetricAlgorithm.Mode = CipherMode.CBC;
				ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor(array3, array5);
				Stream stream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Write);
				cryptoStream.Write(array, 0, array.Length);
				cryptoStream.FlushFinalBlock();
				SRm = lRK((MemoryStream)stream);
				stream.Close();
				cryptoStream.Close();
				array = SRm;
			}
			if (SR5.EntryPoint == null)
			{
				DR8 = 80;
			}
			new w0G().R0T(array3, array5, array);
		}

		internal static string tRQ(string string_0)
		{
			"7PC3EFVZjFlDkxpKIvv24C".Trim();
			byte[] array = Convert.FromBase64String(string_0);
			return Encoding.Unicode.GetString(array, 0, array.Length);
		}

		internal static uint yRF(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2, [MarshalAs(UnmanagedType.U4)] uint uint_0, IntPtr intptr_3, ref uint uint_1)
		{
			IntPtr ptr = intptr_2;
			if (XR3)
			{
				ptr = intptr_1;
			}
			long num = 0L;
			num = ((IntPtr.Size != 4) ? Marshal.ReadInt64(ptr, IntPtr.Size * 2) : Marshal.ReadInt32(ptr, IntPtr.Size * 2));
			object obj = roQ[num];
			if (obj != null)
			{
				eoj eoj = (eoj)obj;
				IntPtr intPtr = Marshal.AllocCoTaskMem(eoj.Jo4.Length);
				Marshal.Copy(eoj.Jo4, 0, intPtr, eoj.Jo4.Length);
				if (eoj.foK)
				{
					intptr_3 = intPtr;
					uint_1 = (uint)eoj.Jo4.Length;
					KRd(intptr_3, eoj.Jo4.Length, 64, ref poN);
					return 0u;
				}
				Marshal.WriteIntPtr(ptr, IntPtr.Size * 2, intPtr);
				Marshal.WriteInt32(ptr, IntPtr.Size * 3, eoj.Jo4.Length);
				uint result = 0u;
				if (uint_0 == 216669565 && !HoY)
				{
					HoY = true;
				}
				else
				{
					result = kR2(intptr_0, intptr_1, intptr_2, uint_0, intptr_3, ref uint_1);
					Marshal.WriteIntPtr(ptr, IntPtr.Size * 2, IntPtr.Zero);
				}
				return result;
			}
			return kR2(intptr_0, intptr_1, intptr_2, uint_0, intptr_3, ref uint_1);
		}

		private static int oRC()
		{
			return 5;
		}

		private static void uRe()
		{
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		private static Delegate ORJ(IntPtr intptr_0, Type type_0)
		{
			return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[2]
			{
				typeof(IntPtr),
				typeof(Type)
			}).Invoke(null, new object[2] { intptr_0, type_0 });
		}

		internal unsafe static void gRt()
		{
			if (BRS)
			{
				return;
			}
			BRS = true;
			long num = 0L;
			Marshal.ReadIntPtr(new IntPtr(&num), 0);
			Marshal.ReadInt32(new IntPtr(&num), 0);
			Marshal.ReadInt64(new IntPtr(&num), 0);
			Marshal.WriteIntPtr(new IntPtr(&num), 0, IntPtr.Zero);
			Marshal.WriteInt32(new IntPtr(&num), 0, 0);
			Marshal.WriteInt64(new IntPtr(&num), 0, 0L);
			Marshal.Copy(new byte[1], 0, Marshal.AllocCoTaskMem(8), 1);
			uRe();
			if (IntPtr.Size == 4 && Type.GetType("System.Reflection.ReflectionContext", false) != null)
			{
				foreach (ProcessModule module in Process.GetCurrentProcess().Modules)
				{
					if (module.ModuleName.ToLower() == "clrjit.dll")
					{
						Version version = new Version(module.FileVersionInfo.ProductMajorPart, module.FileVersionInfo.ProductMinorPart, module.FileVersionInfo.ProductBuildPart, module.FileVersionInfo.ProductPrivatePart);
						Version version2 = new Version(4, 0, 30319, 17020);
						Version version3 = new Version(4, 0, 30319, 17921);
						if (version >= version2 && version < version3)
						{
							XR3 = true;
							break;
						}
					}
				}
			}
			oon oon = new oon(SR5.GetManifestResourceStream("4giPAfJspp9geow9T7.drUjvbtm4PnwC0JZm1"));
			oon.method_0().Position = 0L;
			byte[] array = oon.Toh((int)oon.method_0().Length);
			byte[] array2 = new byte[32];
			array2[0] = 136;
			array2[0] = 110;
			array2[0] = 85;
			array2[0] = 162;
			array2[0] = 153;
			array2[0] = 135;
			array2[1] = 88;
			array2[1] = 130;
			array2[1] = 141;
			array2[1] = 164;
			array2[1] = 135;
			array2[1] = 121;
			array2[2] = 147;
			array2[2] = 146;
			array2[2] = 131;
			array2[2] = 158;
			array2[2] = 109;
			array2[3] = 117;
			array2[3] = 144;
			array2[3] = 121;
			array2[3] = 62;
			array2[4] = 165;
			array2[4] = 130;
			array2[4] = 166;
			array2[4] = 144;
			array2[4] = 58;
			array2[4] = 217;
			array2[5] = 61;
			array2[5] = 144;
			array2[5] = 87;
			array2[5] = 205;
			array2[6] = 205;
			array2[6] = 181;
			array2[6] = 92;
			array2[6] = 188;
			array2[7] = 144;
			array2[7] = 163;
			array2[7] = 98;
			array2[7] = 222;
			array2[7] = 126;
			array2[7] = 13;
			array2[8] = 146;
			array2[8] = 86;
			array2[8] = 102;
			array2[8] = 136;
			array2[9] = 31;
			array2[9] = 152;
			array2[9] = 112;
			array2[9] = 119;
			array2[9] = 207;
			array2[9] = 50;
			array2[10] = 116;
			array2[10] = 63;
			array2[10] = 100;
			array2[10] = 232;
			array2[11] = 110;
			array2[11] = 152;
			array2[11] = 62;
			array2[12] = 94;
			array2[12] = 167;
			array2[12] = 157;
			array2[12] = 175;
			array2[13] = 114;
			array2[13] = 150;
			array2[13] = 65;
			array2[14] = 120;
			array2[14] = 104;
			array2[14] = 3;
			array2[15] = 114;
			array2[15] = 104;
			array2[15] = 145;
			array2[15] = 103;
			array2[15] = 194;
			array2[16] = 68;
			array2[16] = 100;
			array2[16] = 250;
			array2[17] = 114;
			array2[17] = 121;
			array2[17] = 115;
			array2[17] = 107;
			array2[17] = 166;
			array2[17] = 153;
			array2[18] = 155;
			array2[18] = 98;
			array2[18] = 124;
			array2[18] = 143;
			array2[18] = 109;
			array2[19] = 160;
			array2[19] = 142;
			array2[19] = 165;
			array2[19] = 164;
			array2[20] = 105;
			array2[20] = 90;
			array2[20] = 198;
			array2[21] = 152;
			array2[21] = 126;
			array2[21] = 70;
			array2[22] = 140;
			array2[22] = 123;
			array2[22] = 154;
			array2[22] = 169;
			array2[22] = 128;
			array2[22] = 138;
			array2[23] = 129;
			array2[23] = 128;
			array2[23] = 116;
			array2[23] = 114;
			array2[23] = 180;
			array2[24] = 102;
			array2[24] = 136;
			array2[24] = 56;
			array2[24] = 82;
			array2[24] = 73;
			array2[24] = 56;
			array2[25] = 7;
			array2[25] = 139;
			array2[25] = 163;
			array2[25] = 138;
			array2[25] = 15;
			array2[26] = 130;
			array2[26] = 132;
			array2[26] = 128;
			array2[27] = 103;
			array2[27] = 94;
			array2[27] = 219;
			array2[28] = 85;
			array2[28] = 158;
			array2[28] = 157;
			array2[28] = 95;
			array2[28] = 124;
			array2[28] = 173;
			array2[29] = 116;
			array2[29] = 52;
			array2[29] = 155;
			array2[29] = 105;
			array2[30] = 151;
			array2[30] = 87;
			array2[30] = 112;
			array2[31] = 154;
			array2[31] = 104;
			array2[31] = 124;
			array2[31] = 190;
			array2[31] = 88;
			byte[] array3 = array2;
			byte[] array4 = new byte[16];
			array4[0] = 145;
			array4[0] = 42;
			array4[0] = 86;
			array4[0] = 138;
			array4[0] = 62;
			array4[1] = 140;
			array4[1] = 85;
			array4[1] = 94;
			array4[2] = 142;
			array4[2] = 94;
			array4[2] = 43;
			array4[2] = 122;
			array4[3] = 136;
			array4[3] = 112;
			array4[3] = 117;
			array4[4] = 203;
			array4[4] = 130;
			array4[4] = 158;
			array4[4] = 46;
			array4[4] = 122;
			array4[4] = 210;
			array4[5] = 117;
			array4[5] = 116;
			array4[5] = 191;
			array4[5] = 254;
			array4[6] = 132;
			array4[6] = 80;
			array4[6] = 96;
			array4[6] = 63;
			array4[7] = 89;
			array4[7] = 85;
			array4[7] = 76;
			array4[7] = 146;
			array4[7] = 22;
			array4[7] = 37;
			array4[8] = 112;
			array4[8] = 108;
			array4[8] = 91;
			array4[8] = 92;
			array4[9] = 76;
			array4[9] = 167;
			array4[9] = 131;
			array4[9] = 89;
			array4[9] = 86;
			array4[9] = 104;
			array4[10] = 187;
			array4[10] = 164;
			array4[10] = 163;
			array4[11] = 154;
			array4[11] = 52;
			array4[11] = 99;
			array4[11] = 99;
			array4[11] = 129;
			array4[11] = 185;
			array4[12] = 148;
			array4[12] = 140;
			array4[12] = 213;
			array4[12] = 240;
			array4[13] = 154;
			array4[13] = 150;
			array4[13] = 101;
			array4[14] = 165;
			array4[14] = 111;
			array4[14] = 186;
			array4[15] = 165;
			array4[15] = 126;
			array4[15] = 146;
			array4[15] = 56;
			array4[15] = 123;
			byte[] array5 = array4;
			Array.Reverse(array5);
			byte[] publicKeyToken = SR5.GetName().GetPublicKeyToken();
			if (publicKeyToken != null && publicKeyToken.Length != 0)
			{
				array5[1] = publicKeyToken[0];
				array5[3] = publicKeyToken[1];
				array5[5] = publicKeyToken[2];
				array5[7] = publicKeyToken[3];
				array5[9] = publicKeyToken[4];
				array5[11] = publicKeyToken[5];
				array5[13] = publicKeyToken[6];
				array5[15] = publicKeyToken[7];
				Array.Clear(publicKeyToken, 0, publicKeyToken.Length);
			}
			for (int i = 0; i < array5.Length; i++)
			{
				array3[i] ^= array5[i];
			}
			byte[] array6 = array;
			int num2 = array6.Length % 4;
			int num3 = array6.Length / 4;
			byte[] array7 = new byte[array6.Length];
			int num4 = array3.Length / 4;
			uint num5 = 0u;
			uint num6 = 0u;
			uint num7 = 0u;
			if (num2 > 0)
			{
				num3++;
			}
			uint num8 = 0u;
			for (int k = 0; k < num3; k++)
			{
				int num9 = k % num4;
				int num10 = k * 4;
				num8 = (uint)(num9 * 4);
				num6 = (uint)((array3[num8 + 3] << 24) | (array3[num8 + 2] << 16) | (array3[num8 + 1] << 8) | array3[num8]);
				uint num11 = 255u;
				int num12 = 0;
				if (k == num3 - 1 && num2 > 0)
				{
					num5 += num6;
					num7 = 0u;
					for (int l = 0; l < num2; l++)
					{
						if (l > 0)
						{
							num7 <<= 8;
						}
						num7 |= array6[array6.Length - (1 + l)];
					}
				}
				else
				{
					num8 = (uint)num10;
					num5 += num6;
					num7 = (uint)((array6[num8 + 3] << 24) | (array6[num8 + 2] << 16) | (array6[num8 + 1] << 8) | array6[num8]);
				}
				num5 = num5;
				uint num13 = num5;
				uint num14 = num5;
				uint num15 = 485342649u;
				uint num16 = 326621713u;
				uint num17 = num14;
				uint num18 = 873418232u;
				ulong num19 = 2307900331uL;
				num19 = 2307900331uL;
				num17 = (uint)((ulong)(num17 * num17) % 2307900331uL);
				num19 = 484439473 * num17;
				num19 |= 1L;
				num15 = (uint)(1294249905L % num19);
				uint num20 = num17 / 326621713 + 326621713;
				num16 = (num17 + num17) * num20 + num17;
				num20 = num17 / 873418232 + 873418232;
				num18 = num17 + num17 + num20 + num17;
				num17 ^= num17 >> 15;
				num17 += num15;
				num17 ^= num17 >> 29;
				num17 += num16;
				num17 ^= num17 << 1;
				num17 += num18;
				num17 = (((num15 << 4) - num16) ^ num16) + num17;
				num5 = num13 + (uint)(double)num17;
				if (k == num3 - 1 && num2 > 0)
				{
					uint num21 = num5 ^ num7;
					for (int m = 0; m < num2; m++)
					{
						if (m > 0)
						{
							num11 <<= 8;
							num12 += 8;
						}
						array7[num10 + m] = (byte)((num21 & num11) >> num12);
					}
				}
				else
				{
					uint num22 = num5 ^ num7;
					array7[num10] = (byte)(num22 & 0xFF);
					array7[num10 + 1] = (byte)((num22 & 0xFF00) >> 8);
					array7[num10 + 2] = (byte)((num22 & 0xFF0000) >> 16);
					array7[num10 + 3] = (byte)((num22 & 0xFF000000u) >> 24);
				}
			}
			byte[] array8 = array7;
			int num23 = array8.Length / 8;
			fixed (byte* ptr = array8)
			{
				for (int n = 0; n < num23; n++)
				{
					*(long*)(ptr + n * 8) ^= 1869283427L;
				}
			}
			oon = new oon(new MemoryStream(array8));
			oon.method_0().Position = 0L;
			long num24 = Marshal.GetHINSTANCE(SR5.GetModules()[0]).ToInt64();
			int int_ = 0;
			int num25 = 0;
			if (SR5.Location == null || SR5.Location.Length == 0)
			{
				num25 = 7680;
			}
			oon.Koc();
			oon.Koc();
			oon.Koc();
			oon.Koc();
			int num26 = oon.Koc();
			int num27 = oon.Koc();
			if (num27 == 4)
			{
				SymmetricAlgorithm symmetricAlgorithm = B0i();
				symmetricAlgorithm.Mode = CipherMode.CBC;
				ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor(array3, array5);
				Array.Clear(array3, 0, array3.Length);
				MemoryStream memoryStream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
				cryptoStream.Write(array, 0, array.Length);
				cryptoStream.FlushFinalBlock();
				array8 = memoryStream.ToArray();
				Array.Clear(array5, 0, array5.Length);
				memoryStream.Close();
				cryptoStream.Close();
				oon.Row();
				num26 = oon.Koc();
				num27 = oon.Koc();
			}
			if (num27 == 1)
			{
				IntPtr zero = IntPtr.Zero;
				zero = JR1(56u, 1, (uint)Process.GetCurrentProcess().Id);
				if (IntPtr.Size == 4)
				{
					qRO = Marshal.GetHINSTANCE(SR5.GetModules()[0]).ToInt32();
				}
				lRI = Marshal.GetHINSTANCE(SR5.GetModules()[0]).ToInt64();
				IntPtr intptr_ = IntPtr.Zero;
				for (int num28 = 0; num28 < num26; num28++)
				{
					IntPtr intPtr = new IntPtr(lRI + oon.Koc() - num25);
					if (KRd(intPtr, 4, 4, ref int_) == 0)
					{
						KRd(intPtr, 4, 8, ref int_);
					}
					if (IntPtr.Size == 4)
					{
						aRD(zero, intPtr, BitConverter.GetBytes(oon.Koc()), 4u, out intptr_);
					}
					else
					{
						aRD(zero, intPtr, BitConverter.GetBytes(oon.Koc()), 4u, out intptr_);
					}
					KRd(intPtr, 4, int_, ref int_);
				}
				while (oon.method_0().Position < oon.method_0().Length - 1L)
				{
					int num29 = oon.Koc();
					IntPtr intptr_2 = new IntPtr(lRI + num29 - num25);
					int num30 = oon.Koc();
					if (KRd(intptr_2, num30 * 4, 4, ref int_) == 0)
					{
						KRd(intptr_2, num30 * 4, 8, ref int_);
					}
					for (int num31 = 0; num31 < num30; num31++)
					{
						Marshal.WriteInt32(new IntPtr(intptr_2.ToInt64() + num31 * 4), oon.Koc());
					}
					KRd(intptr_2, num30 * 4, int_, ref int_);
				}
				FRv(zero);
				return;
			}
			for (int num32 = 0; num32 < num26; num32++)
			{
				IntPtr intPtr2 = new IntPtr(num24 + oon.Koc() - num25);
				if (KRd(intPtr2, 4, 4, ref int_) == 0)
				{
					KRd(intPtr2, 4, 8, ref int_);
				}
				Marshal.WriteInt32(intPtr2, oon.Koc());
				KRd(intPtr2, 4, int_, ref int_);
			}
			roQ = new Hashtable(oon.Koc() + 1);
			eoj eoj = new eoj
			{
				Jo4 = new byte[1] { 42 },
				foK = false
			};
			roQ.Add(0L, eoj);
			bool flag = false;
			while (oon.method_0().Position < oon.method_0().Length - 1L)
			{
				int num33 = oon.Koc() - num25;
				int num34 = oon.Koc();
				flag = false;
				if (num34 >= 1879048192)
				{
					flag = true;
				}
				int int_2 = oon.Koc();
				byte[] jo2 = oon.Toh(int_2);
				eoj eoj2 = new eoj
				{
					Jo4 = jo2,
					foK = flag
				};
				roQ.Add(num24 + num33, eoj2);
			}
			CRE = Marshal.GetHINSTANCE(typeof(w0G).Assembly.GetModules()[0]).ToInt64();
			if (IntPtr.Size == 4)
			{
				vRg = Convert.ToInt32(CRE);
			}
			byte[] bytes = new byte[12]
			{
				109, 115, 99, 111, 114, 106, 105, 116, 46, 100,
				108, 108
			};
			string text = Encoding.UTF8.GetString(bytes);
			IntPtr intPtr3 = IntPtr.Zero;
			if (intPtr3 == IntPtr.Zero)
			{
				bytes = new byte[10] { 99, 108, 114, 106, 105, 116, 46, 100, 108, 108 };
				text = Encoding.UTF8.GetString(bytes);
				intPtr3 = LoadLibrary(text);
			}
			byte[] bytes2 = new byte[6] { 103, 101, 116, 74, 105, 116 };
			string string_ = Encoding.UTF8.GetString(bytes2);
			IntPtr ptr2 = ((mox)ORJ(GetProcAddress(intPtr3, string_), typeof(mox)))();
			long num35 = 0L;
			num35 = ((IntPtr.Size != 4) ? Marshal.ReadInt64(ptr2) : Marshal.ReadInt32(ptr2));
			Marshal.ReadIntPtr(ptr2, 0);
			xRs = yRF;
			IntPtr zero2 = IntPtr.Zero;
			zero2 = Marshal.GetFunctionPointerForDelegate((Delegate)xRs);
			long num36 = 0L;
			num36 = ((IntPtr.Size != 4) ? Marshal.ReadInt64(new IntPtr(num35)) : Marshal.ReadInt32(new IntPtr(num35)));
			Process currentProcess = Process.GetCurrentProcess();
			try
			{
				foreach (ProcessModule module2 in currentProcess.Modules)
				{
					if (module2.ModuleName == text && (num36 < module2.BaseAddress.ToInt64() || num36 > module2.BaseAddress.ToInt64() + module2.ModuleMemorySize) && typeof(w0G).Assembly.EntryPoint != null)
					{
						return;
					}
				}
			}
			catch
			{
			}
			try
			{
				foreach (ProcessModule module3 in currentProcess.Modules)
				{
					if (module3.BaseAddress.ToInt64() == CRE)
					{
						num25 = 0;
						break;
					}
				}
			}
			catch
			{
			}
			kR2 = null;
			try
			{
				kR2 = (Cov)ORJ(new IntPtr(num36), typeof(Cov));
			}
			catch
			{
				try
				{
					Delegate obj4 = ORJ(new IntPtr(num36), typeof(Cov));
					kR2 = (Cov)Delegate.CreateDelegate(typeof(Cov), obj4.Method);
				}
				catch
				{
				}
			}
			int int_3 = 0;
			if (typeof(w0G).Assembly.EntryPoint != null && typeof(w0G).Assembly.EntryPoint.GetParameters().Length == 2 && typeof(w0G).Assembly.Location != null && typeof(w0G).Assembly.Location.Length > 0)
			{
				return;
			}
			try
			{
				object value = typeof(w0G).Assembly.ManifestModule.ModuleHandle.GetType().GetField("m_ptr", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(typeof(w0G).Assembly.ManifestModule.ModuleHandle);
				if (value is IntPtr)
				{
					aoU = (IntPtr)value;
				}
				if (value.GetType().ToString() == "System.Reflection.RuntimeModule")
				{
					aoU = (IntPtr)value.GetType().GetField("m_pData", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(value);
				}
				MemoryStream memoryStream2 = new MemoryStream();
				memoryStream2.Write(new byte[IntPtr.Size], 0, IntPtr.Size);
				if (IntPtr.Size == 4)
				{
					memoryStream2.Write(BitConverter.GetBytes(aoU.ToInt32()), 0, 4);
				}
				else
				{
					memoryStream2.Write(BitConverter.GetBytes(aoU.ToInt64()), 0, 8);
				}
				memoryStream2.Write(new byte[IntPtr.Size], 0, IntPtr.Size);
				memoryStream2.Write(new byte[IntPtr.Size], 0, IntPtr.Size);
				memoryStream2.Position = 0L;
				byte[] array9 = memoryStream2.ToArray();
				memoryStream2.Close();
				uint nativeSizeOfCode = 0u;
				fixed (byte* value2 = array9)
				{
					xRs(new IntPtr(value2), new IntPtr(value2), new IntPtr(value2), 216669565u, new IntPtr(value2), ref nativeSizeOfCode);
				}
			}
			catch
			{
			}
			RuntimeHelpers.PrepareDelegate(kR2);
			RuntimeHelpers.PrepareMethod(kR2.Method.MethodHandle);
			RuntimeHelpers.PrepareDelegate(xRs);
			RuntimeHelpers.PrepareMethod(xRs.Method.MethodHandle);
			byte[] array10 = null;
			array10 = ((IntPtr.Size == 4) ? new byte[30]
			{
				85, 139, 236, 139, 69, 16, 129, 120, 4, 125,
				29, 234, 12, 116, 7, 184, 182, 177, 74, 6,
				235, 5, 184, 182, 146, 64, 12, 93, 255, 224
			} : new byte[40]
			{
				72, 184, 0, 0, 0, 0, 0, 0, 0, 0,
				73, 57, 64, 8, 116, 12, 72, 184, 0, 0,
				0, 0, 0, 0, 0, 0, 255, 224, 72, 184,
				0, 0, 0, 0, 0, 0, 0, 0, 255, 224
			});
			IntPtr intPtr4 = WRo(IntPtr.Zero, (uint)array10.Length, 4096u, 64u);
			byte[] array11 = array10;
			byte[] array12 = null;
			byte[] array13 = null;
			byte[] array14 = null;
			if (IntPtr.Size == 4)
			{
				array14 = BitConverter.GetBytes(aoU.ToInt32());
				array12 = BitConverter.GetBytes(zero2.ToInt32());
				array13 = BitConverter.GetBytes(Convert.ToInt32(num36));
			}
			else
			{
				array14 = BitConverter.GetBytes(aoU.ToInt64());
				array12 = BitConverter.GetBytes(zero2.ToInt64());
				array13 = BitConverter.GetBytes(num36);
			}
			if (IntPtr.Size == 4)
			{
				array11[9] = array14[0];
				array11[10] = array14[1];
				array11[11] = array14[2];
				array11[12] = array14[3];
				array11[16] = array13[0];
				array11[17] = array13[1];
				array11[18] = array13[2];
				array11[19] = array13[3];
				array11[23] = array12[0];
				array11[24] = array12[1];
				array11[25] = array12[2];
				array11[26] = array12[3];
			}
			else
			{
				array11[2] = array14[0];
				array11[3] = array14[1];
				array11[4] = array14[2];
				array11[5] = array14[3];
				array11[6] = array14[4];
				array11[7] = array14[5];
				array11[8] = array14[6];
				array11[9] = array14[7];
				array11[18] = array13[0];
				array11[19] = array13[1];
				array11[20] = array13[2];
				array11[21] = array13[3];
				array11[22] = array13[4];
				array11[23] = array13[5];
				array11[24] = array13[6];
				array11[25] = array13[7];
				array11[30] = array12[0];
				array11[31] = array12[1];
				array11[32] = array12[2];
				array11[33] = array12[3];
				array11[34] = array12[4];
				array11[35] = array12[5];
				array11[36] = array12[6];
				array11[37] = array12[7];
			}
			Marshal.Copy(array11, 0, intPtr4, array11.Length);
			VRp = false;
			KRd(new IntPtr(num35), IntPtr.Size, 64, ref int_3);
			Marshal.WriteIntPtr(new IntPtr(num35), intPtr4);
			KRd(new IntPtr(num35), IntPtr.Size, int_3, ref int_3);
		}

		internal static object xR7(Assembly assembly_0)
		{
			try
			{
				if (File.Exists(assembly_0.Location))
				{
					return assembly_0.Location;
				}
			}
			catch
			{
			}
			try
			{
				if (File.Exists(assembly_0.GetName().CodeBase.ToString().Replace("file:///", "")))
				{
					return assembly_0.GetName().CodeBase.ToString().Replace("file:///", "");
				}
			}
			catch
			{
			}
			try
			{
				if (File.Exists(assembly_0.GetType().GetProperty("Location").GetValue(assembly_0, new object[0])
					.ToString()))
				{
					return assembly_0.GetType().GetProperty("Location").GetValue(assembly_0, new object[0])
						.ToString();
				}
			}
			catch
			{
			}
			return "";
		}

		[DllImport("kernel32")]
		public static extern IntPtr LoadLibrary(string string_0);

		[DllImport("kernel32", CharSet = CharSet.Ansi)]
		public static extern IntPtr GetProcAddress(IntPtr intptr_0, string string_0);

		private static IntPtr ERR(IntPtr intptr_0, string string_0, uint uint_0)
		{
			if (MoF == null)
			{
				MoF = (boy)Marshal.GetDelegateForFunctionPointer(GetProcAddress(smethod_0(), "Find ".Trim() + "ResourceA"), typeof(boy));
			}
			return MoF(intptr_0, string_0, uint_0);
		}

		private static IntPtr WRo(IntPtr intptr_0, uint uint_0, uint uint_1, uint uint_2)
		{
			if (GoC == null)
			{
				GoC = (Cob)Marshal.GetDelegateForFunctionPointer(GetProcAddress(smethod_0(), "Virtual ".Trim() + "Alloc"), typeof(Cob));
			}
			return GoC(intptr_0, uint_0, uint_1, uint_2);
		}

		private static int aRD(IntPtr intptr_0, IntPtr intptr_1, [In][Out] byte[] byte_0, uint uint_0, out IntPtr intptr_2)
		{
			if (Yoe == null)
			{
				Yoe = (Tok)Marshal.GetDelegateForFunctionPointer(GetProcAddress(smethod_0(), "Write ".Trim() + "Process ".Trim() + "Memory"), typeof(Tok));
			}
			return Yoe(intptr_0, intptr_1, byte_0, uint_0, out intptr_2);
		}

		private static int KRd(IntPtr intptr_0, int int_0, int int_1, ref int int_2)
		{
			if (woJ == null)
			{
				woJ = (rou)Marshal.GetDelegateForFunctionPointer(GetProcAddress(smethod_0(), "Virtual ".Trim() + "Protect"), typeof(rou));
			}
			return woJ(intptr_0, int_0, int_1, ref int_2);
		}

		private static IntPtr JR1(uint uint_0, int int_0, uint uint_1)
		{
			if (aot == null)
			{
				aot = (Lo3)Marshal.GetDelegateForFunctionPointer(GetProcAddress(smethod_0(), "Open ".Trim() + "Process"), typeof(Lo3));
			}
			return aot(uint_0, int_0, uint_1);
		}

		private static int FRv(IntPtr intptr_0)
		{
			if (Jo7 == null)
			{
				Jo7 = (Ro5)Marshal.GetDelegateForFunctionPointer(GetProcAddress(smethod_0(), "Close ".Trim() + "Handle"), typeof(Ro5));
			}
			return Jo7(intptr_0);
		}

		[SpecialName]
		private static IntPtr smethod_0()
		{
			if (Lo6 == IntPtr.Zero)
			{
				Lo6 = LoadLibrary("kernel ".Trim() + "32.dll");
			}
			return Lo6;
		}

		private static byte[] IRx(string string_0)
		{
			using (FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				int num = 0;
				int num2 = (int)fileStream.Length;
				byte[] array = new byte[num2];
				while (num2 > 0)
				{
					int num3 = fileStream.Read(array, num, num2);
					num += num3;
					num2 -= num3;
				}
				return array;
			}
		}

		internal static byte[] lRK(MemoryStream memoryStream_0)
		{
			return memoryStream_0.ToArray();
		}

		private static byte[] rR4(byte[] byte_0)
		{
			Stream stream = new MemoryStream();
			SymmetricAlgorithm symmetricAlgorithm = B0i();
			symmetricAlgorithm.Key = new byte[32]
			{
				250, 202, 75, 136, 39, 154, 243, 209, 167, 27,
				210, 166, 135, 14, 67, 171, 11, 83, 228, 12,
				170, 202, 1, 226, 222, 237, 149, 242, 22, 52,
				106, 116
			};
			symmetricAlgorithm.IV = new byte[16]
			{
				133, 43, 170, 140, 244, 17, 125, 174, 22, 8,
				146, 28, 69, 90, 209, 252
			};
			CryptoStream cryptoStream = new CryptoStream(stream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(byte_0, 0, byte_0.Length);
			cryptoStream.Close();
			return lRK((MemoryStream)stream);
		}

		private byte[] MRn()
		{
			return null;
		}

		private byte[] dRh()
		{
			return null;
		}

		private byte[] RRr()
		{
			return null;
		}

		private byte[] CRc()
		{
			return null;
		}

		private byte[] pRw()
		{
			return null;
		}

		private byte[] GRq()
		{
			return null;
		}

		internal byte[] rRy()
		{
			int length = "QV390bCmL30315SyI0i0l".Length;
			return new byte[2] { 1, 2 };
		}

		internal byte[] wRb()
		{
			int length = "kIH6ZaFpPQASrEa1".Length;
			return new byte[2] { 1, 2 };
		}

		internal byte[] nRk()
		{
			int length = "gfnk3jOOYQ3lljOgCwh".Length;
			return new byte[2] { 1, 2 };
		}

		internal byte[] SRu()
		{
			int length = "UdmpcVIiTp9C4nfXafb0V".Length;
			return new byte[2] { 1, 2 };
		}

		internal static bool CDS()
		{
			return (object)null == null;
		}

		internal static object FDl()
		{
			return null;
		}

		internal static bool QmB()
		{
			return (object)null == null;
		}

		internal static object Ymz()
		{
			return null;
		}

		static int o2j()
		{
			return 1;
		}

		internal static IntPtr I2n(IntPtr intptr_0, int int_0)
		{
			return Marshal.ReadIntPtr(intptr_0, int_0);
		}

		internal static int N2h(IntPtr intptr_0, int int_0)
		{
			return Marshal.ReadInt32(intptr_0, int_0);
		}

		internal static long r2r(IntPtr intptr_0, int int_0)
		{
			return Marshal.ReadInt64(intptr_0, int_0);
		}

		internal static void o2c(IntPtr intptr_0, int int_0, IntPtr intptr_1)
		{
			Marshal.WriteIntPtr(intptr_0, int_0, intptr_1);
		}

		internal static void u2w(IntPtr intptr_0, int int_0, int int_1)
		{
			Marshal.WriteInt32(intptr_0, int_0, int_1);
		}

		internal static void T2q(IntPtr intptr_0, int int_0, long long_0)
		{
			Marshal.WriteInt64(intptr_0, int_0, long_0);
		}

		internal static IntPtr d2y(int int_0)
		{
			return Marshal.AllocCoTaskMem(int_0);
		}

		internal static void S2b(byte[] byte_0, int int_0, IntPtr intptr_0, int int_1)
		{
			Marshal.Copy(byte_0, int_0, intptr_0, int_1);
		}

		internal static void J2k()
		{
			uRe();
		}

		internal static object Q2u()
		{
			return Process.GetCurrentProcess();
		}

		internal static object y23(Process process_0)
		{
			return process_0.MainModule;
		}

		internal static IntPtr u25(ProcessModule processModule_0)
		{
			return processModule_0.BaseAddress;
		}

		internal static IntPtr I2H(IntPtr intptr_0, string string_0, uint uint_0)
		{
			return ERR(intptr_0, string_0, uint_0);
		}

		internal static bool V2M(IntPtr intptr_0, IntPtr intptr_1)
		{
			return intptr_0 != intptr_1;
		}

		internal static void n2L()
		{
		}

		internal static int F2V()
		{
			return IntPtr.Size;
		}

		internal static Type N2W(string string_0, bool bool_0)
		{
			return Type.GetType(string_0, bool_0);
		}

		internal static bool G2G(Type type_0, Type type_1)
		{
			return type_0 != type_1;
		}

		internal static object x28(Process process_0)
		{
			return process_0.Modules;
		}

		internal static object q2Z(ReadOnlyCollectionBase readOnlyCollectionBase_0)
		{
			return readOnlyCollectionBase_0.GetEnumerator();
		}

		internal static object w2a(IEnumerator ienumerator_0)
		{
			return ienumerator_0.Current;
		}

		internal static object z2X(ProcessModule processModule_0)
		{
			return processModule_0.ModuleName;
		}

		internal static object S2m(string string_0)
		{
			return string_0.ToLower();
		}

		internal static bool p2A(string string_0, string string_1)
		{
			return string_0 == string_1;
		}

		internal static object Y29(ProcessModule processModule_0)
		{
			return processModule_0.FileVersionInfo;
		}

		internal static int U2P(FileVersionInfo fileVersionInfo_0)
		{
			return fileVersionInfo_0.ProductMajorPart;
		}

		internal static int F2f(FileVersionInfo fileVersionInfo_0)
		{
			return fileVersionInfo_0.ProductMinorPart;
		}

		internal static int c2T(FileVersionInfo fileVersionInfo_0)
		{
			return fileVersionInfo_0.ProductBuildPart;
		}

		internal static int c2i(FileVersionInfo fileVersionInfo_0)
		{
			return fileVersionInfo_0.ProductPrivatePart;
		}

		internal static bool r2S(Version version_0, Version version_1)
		{
			return version_0 >= version_1;
		}

		internal static bool t2l(Version version_0, Version version_1)
		{
			return version_0 < version_1;
		}

		internal static bool N2O(IEnumerator ienumerator_0)
		{
			return ienumerator_0.MoveNext();
		}

		internal static void o2I(IDisposable idisposable_0)
		{
			idisposable_0.Dispose();
		}

		internal static object d22(Assembly assembly_0, string string_0)
		{
			return assembly_0.GetManifestResourceStream(string_0);
		}

		internal static object f2s(oon oon_0)
		{
			return oon_0.method_0();
		}

		internal static void m2E(Stream stream_0, long long_0)
		{
			stream_0.Position = long_0;
		}

		internal static long v2g(Stream stream_0)
		{
			return stream_0.Length;
		}

		internal static object s2p(oon oon_0, int int_0)
		{
			return oon_0.Toh(int_0);
		}

		internal static void T2B(Array array_0)
		{
			Array.Reverse(array_0);
		}

		internal static object y2z(Assembly assembly_0)
		{
			return assembly_0.GetName();
		}

		internal static object asN(AssemblyName assemblyName_0)
		{
			return assemblyName_0.GetPublicKeyToken();
		}

		internal static void RsU(Array array_0, int int_0, int int_1)
		{
			Array.Clear(array_0, int_0, int_1);
		}

		internal static object SsY(Assembly assembly_0)
		{
			return assembly_0.GetModules();
		}

		internal static IntPtr zsQ(Module module_0)
		{
			return Marshal.GetHINSTANCE(module_0);
		}

		internal static object jsF(Assembly assembly_0)
		{
			return assembly_0.Location;
		}

		internal static int IsC(string string_0)
		{
			return string_0.Length;
		}

		internal static int Yse(oon oon_0)
		{
			return oon_0.Koc();
		}

		internal static object ksJ()
		{
			return B0i();
		}

		internal static void Gst(SymmetricAlgorithm symmetricAlgorithm_0, CipherMode cipherMode_0)
		{
			symmetricAlgorithm_0.Mode = cipherMode_0;
		}

		internal static object Is7(SymmetricAlgorithm symmetricAlgorithm_0, byte[] byte_0, byte[] byte_1)
		{
			return symmetricAlgorithm_0.CreateDecryptor(byte_0, byte_1);
		}

		internal static void Ps6(Stream stream_0, byte[] byte_0, int int_0, int int_1)
		{
			stream_0.Write(byte_0, int_0, int_1);
		}

		internal static void Cs0(CryptoStream cryptoStream_0)
		{
			cryptoStream_0.FlushFinalBlock();
		}

		internal static object rsR(MemoryStream memoryStream_0)
		{
			return memoryStream_0.ToArray();
		}

		internal static void cso(Stream stream_0)
		{
			stream_0.Close();
		}

		internal static void VsD(oon oon_0)
		{
			oon_0.Row();
		}

		internal static int Msd(Process process_0)
		{
			return process_0.Id;
		}

		internal static IntPtr Qs1(uint uint_0, int int_0, uint uint_1)
		{
			return JR1(uint_0, int_0, uint_1);
		}

		internal static object Csv(int int_0)
		{
			return BitConverter.GetBytes(int_0);
		}

		internal static long vsx(Stream stream_0)
		{
			return stream_0.Position;
		}

		internal static void lsK(IntPtr intptr_0, int int_0)
		{
			Marshal.WriteInt32(intptr_0, int_0);
		}

		internal static int qs4(IntPtr intptr_0)
		{
			return FRv(intptr_0);
		}

		internal static void Jsn(Hashtable hashtable_0, object object_0, object object_1)
		{
			hashtable_0.Add(object_0, object_1);
		}

		internal static Type Ysh(RuntimeTypeHandle runtimeTypeHandle_0)
		{
			return Type.GetTypeFromHandle(runtimeTypeHandle_0);
		}

		internal static int Osr(long long_0)
		{
			return Convert.ToInt32(long_0);
		}

		internal static object Dsc()
		{
			return Encoding.UTF8;
		}

		internal static object ysw(Encoding encoding_0, byte[] byte_0)
		{
			return encoding_0.GetString(byte_0);
		}

		internal static bool Gsq(IntPtr intptr_0, IntPtr intptr_1)
		{
			return intptr_0 == intptr_1;
		}

		internal static object Usy(IntPtr intptr_0, Type type_0)
		{
			return ORJ(intptr_0, type_0);
		}

		internal static int Ssk(IntPtr intptr_0)
		{
			return Marshal.ReadInt32(intptr_0);
		}

		internal static long msu(IntPtr intptr_0)
		{
			return Marshal.ReadInt64(intptr_0);
		}

		internal static IntPtr gs3(Delegate delegate_0)
		{
			return Marshal.GetFunctionPointerForDelegate(delegate_0);
		}

		internal static int ms5(ProcessModule processModule_0)
		{
			return processModule_0.ModuleMemorySize;
		}

		internal static object CsH(Assembly assembly_0)
		{
			return assembly_0.EntryPoint;
		}

		internal static bool usM(MethodInfo methodInfo_0, MethodInfo methodInfo_1)
		{
			return methodInfo_0 != methodInfo_1;
		}

		internal static object OsL(Delegate delegate_0)
		{
			return delegate_0.Method;
		}

		internal static object tsV(Type type_0, MethodInfo methodInfo_0)
		{
			return Delegate.CreateDelegate(type_0, methodInfo_0);
		}

		internal static object DsG(MethodBase methodBase_0)
		{
			return methodBase_0.GetParameters();
		}

		internal static object ls8(Assembly assembly_0)
		{
			return assembly_0.ManifestModule;
		}

		internal static ModuleHandle PsZ(Module module_0)
		{
			return module_0.ModuleHandle;
		}

		internal static Type rsa(object object_0)
		{
			return object_0.GetType();
		}

		internal static object Vsm(FieldInfo fieldInfo_0, object object_0)
		{
			return fieldInfo_0.GetValue(object_0);
		}

		internal static object ysA(long long_0)
		{
			return BitConverter.GetBytes(long_0);
		}

		internal static void vs9(Delegate delegate_0)
		{
			RuntimeHelpers.PrepareDelegate(delegate_0);
		}

		internal static RuntimeMethodHandle Ysf(MethodBase methodBase_0)
		{
			return methodBase_0.MethodHandle;
		}

		internal static void lsT(RuntimeMethodHandle runtimeMethodHandle_0)
		{
			RuntimeHelpers.PrepareMethod(runtimeMethodHandle_0);
		}

		internal static void osi(Array array_0, RuntimeFieldHandle runtimeFieldHandle_0)
		{
			RuntimeHelpers.InitializeArray(array_0, runtimeFieldHandle_0);
		}

		internal static IntPtr xsS(IntPtr intptr_0, uint uint_0, uint uint_1, uint uint_2)
		{
			return WRo(intptr_0, uint_0, uint_1, uint_2);
		}

		internal static void Bsl(IntPtr intptr_0, IntPtr intptr_1)
		{
			Marshal.WriteIntPtr(intptr_0, intptr_1);
		}

		internal static bool O2K()
		{
			return (object)null == null;
		}

		internal static object Y24()
		{
			return null;
		}
	}
}
