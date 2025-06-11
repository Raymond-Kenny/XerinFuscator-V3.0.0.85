#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using dnlib.DotNet.Writer;
using XF;

namespace XCore.Generator
{
	public class RandomGenerator
	{
		private static readonly byte[] DYO;

		private readonly SHA256Managed KYI = new SHA256Managed();

		private int zY2;

		private byte[] yYs;

		private int vYE;

		private readonly byte[] MYg;

		[CompilerGenerated]
		private readonly string GYp;

		public string SeedString
		{
			[CompilerGenerated]
			get
			{
				return GYp;
			}
		}

		public RandomGenerator(string string_0, string string_1)
		{
			GYp = (string.IsNullOrEmpty(string_1) ? Guid.NewGuid().ToString() : string_1);
			MYg = DYS(SeedString);
			if (!string.IsNullOrEmpty(string_0))
			{
				byte[] mYg = MYg;
				byte[] array = VYK.UYA(Encoding.UTF8.GetBytes(string_0));
				for (int i = 0; i < 32; i++)
				{
					mYg[i] ^= array[i];
				}
				yYs = (byte[])MYg.Clone();
				vYE = 32;
				zY2 = 0;
				return;
			}
			throw new ArgumentNullException("id");
		}

		internal static byte[] DYS(string string_0)
		{
			byte[] array = VYK.UYA((!string.IsNullOrEmpty(string_0)) ? Encoding.UTF8.GetBytes(string_0) : Guid.NewGuid().ToByteArray());
			for (int i = 0; i < 32; i++)
			{
				array[i] *= DYO[i % DYO.Length];
				array = VYK.UYA(array);
			}
			return array;
		}

		private void zYl()
		{
			for (int i = 0; i < 32; i++)
			{
				yYs[i] ^= DYO[zY2 = (zY2 + 1) % DYO.Length];
			}
			yYs = KYI.ComputeHash(yYs);
			vYE = 32;
		}

		public void NextBytes(byte[] byte_0, int int_0, int int_1)
		{
			if (byte_0 != null)
			{
				if (int_0 < 0)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (int_1 >= 0)
				{
					if (byte_0.Length - int_0 < int_1)
					{
						throw new ArgumentException("Invalid offset or length.");
					}
					while (int_1 > 0)
					{
						if (int_1 < vYE)
						{
							Buffer.BlockCopy(yYs, 32 - vYE, byte_0, int_0, int_1);
							vYE -= int_1;
							int_1 = 0;
						}
						else
						{
							Buffer.BlockCopy(yYs, 32 - vYE, byte_0, int_0, vYE);
							int_0 += vYE;
							int_1 -= vYE;
							vYE = 0;
						}
						if (vYE == 0)
						{
							zYl();
						}
					}
					return;
				}
				throw new ArgumentOutOfRangeException("length");
			}
			throw new ArgumentNullException("buffer");
		}

		public byte NextByte()
		{
			byte result = yYs[32 - vYE];
			vYE--;
			if (vYE == 0)
			{
				zYl();
			}
			return result;
		}

		public byte[] NextBytes(int int_0)
		{
			byte[] array = new byte[int_0];
			NextBytes(array, 0, int_0);
			return array;
		}

		public int NextInt32()
		{
			return BitConverter.ToInt32(NextBytes(4), 0);
		}

		public int NextInt32(int int_0)
		{
			return (int)(NextUInt32() % int_0);
		}

		public int NextInt32(int int_0, int int_1)
		{
			if (int_1 > int_0)
			{
				return int_0 + (int)(NextUInt32() % (int_1 - int_0));
			}
			return int_0;
		}

		public uint NextUInt32()
		{
			return BitConverter.ToUInt32(NextBytes(4), 0);
		}

		public uint NextUInt32(uint uint_0)
		{
			return NextUInt32() % uint_0;
		}

		public double NextDouble()
		{
			return (double)NextUInt32() / 4294967296.0;
		}

		public bool NextBoolean()
		{
			byte b = yYs[32 - vYE];
			vYE--;
			if (vYE == 0)
			{
				zYl();
			}
			return b % 2 == 0;
		}

		public void Shuffle<T>(IList<T> ilist_0)
		{
			for (int num = ilist_0.Count - 1; num > 1; num--)
			{
				int index = NextInt32(num + 1);
				T value = ilist_0[index];
				ilist_0[index] = ilist_0[num];
				ilist_0[num] = value;
			}
		}

		public void Shuffle<T>(MDTable<T> mdtable_0) where T : struct
		{
			if (!mdtable_0.IsEmpty)
			{
				for (uint num = (uint)mdtable_0.Rows; num > 2; num--)
				{
					uint num2 = NextUInt32(num - 1) + 1;
					Debug.Assert(num2 >= 1, "k >= 1");
					Debug.Assert(num2 < num, "k < i");
					Debug.Assert(num2 <= mdtable_0.Rows, "k <= table.Rows");
					T value = mdtable_0[num2];
					mdtable_0[num2] = mdtable_0[num];
					mdtable_0[num] = value;
				}
			}
		}

		static RandomGenerator()
		{
			DYO = new byte[7] { 7, 11, 23, 37, 43, 59, 71 };
		}
	}
}
