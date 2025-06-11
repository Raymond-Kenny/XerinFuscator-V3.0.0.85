#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using dnlib.DotNet.Writer;

namespace XCore.CE
{
	public class RandomGenerator
	{
		private static readonly byte[] SQ8;

		private readonly SHA256Managed CQZ = new SHA256Managed();

		private int gQa;

		private byte[] bQX;

		private int NQm;

		private readonly byte[] bQA;

		[CompilerGenerated]
		private readonly string VQ9;

		public string SeedString
		{
			[CompilerGenerated]
			get
			{
				return VQ9;
			}
		}

		public RandomGenerator(string string_0, string string_1)
		{
			VQ9 = (string.IsNullOrEmpty(string_1) ? Guid.NewGuid().ToString() : string_1);
			bQA = JQW(SeedString);
			if (!string.IsNullOrEmpty(string_0))
			{
				byte[] array = bQA;
				byte[] array2 = Utils.SHA256(Encoding.UTF8.GetBytes(string_0));
				for (int i = 0; i < 32; i++)
				{
					array[i] ^= array2[i];
				}
				bQX = (byte[])bQA.Clone();
				NQm = 32;
				gQa = 0;
				return;
			}
			throw new ArgumentNullException("id");
		}

		internal static byte[] JQW(string string_0)
		{
			byte[] array = Utils.SHA256((!string.IsNullOrEmpty(string_0)) ? Encoding.UTF8.GetBytes(string_0) : Guid.NewGuid().ToByteArray());
			for (int i = 0; i < 32; i++)
			{
				array[i] *= SQ8[i % SQ8.Length];
				array = Utils.SHA256(array);
			}
			return array;
		}

		private void WQG()
		{
			for (int i = 0; i < 32; i++)
			{
				bQX[i] ^= SQ8[gQa = (gQa + 1) % SQ8.Length];
			}
			bQX = CQZ.ComputeHash(bQX);
			NQm = 32;
		}

		public void NextBytes(byte[] byte_0, int int_0, int int_1)
		{
			if (byte_0 == null)
			{
				throw new ArgumentNullException("buffer");
			}
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
					if (int_1 < NQm)
					{
						Buffer.BlockCopy(bQX, 32 - NQm, byte_0, int_0, int_1);
						NQm -= int_1;
						int_1 = 0;
					}
					else
					{
						Buffer.BlockCopy(bQX, 32 - NQm, byte_0, int_0, NQm);
						int_0 += NQm;
						int_1 -= NQm;
						NQm = 0;
					}
					if (NQm == 0)
					{
						WQG();
					}
				}
				return;
			}
			throw new ArgumentOutOfRangeException("length");
		}

		public byte NextByte()
		{
			byte result = bQX[32 - NQm];
			NQm--;
			if (NQm == 0)
			{
				WQG();
			}
			return result;
		}

		public byte[] NextBytes(int int_0)
		{
			byte[] array = new byte[int_0];
			NextBytes(array, 0, int_0);
			return array;
		}

		public int method_0()
		{
			return BitConverter.ToInt32(NextBytes(4), 0);
		}

		public int method_1(int int_0)
		{
			return (int)(method_3() % int_0);
		}

		public int method_2(int int_0, int int_1)
		{
			if (int_1 <= int_0)
			{
				return int_0;
			}
			return int_0 + (int)(method_3() % (int_1 - int_0));
		}

		public uint method_3()
		{
			return BitConverter.ToUInt32(NextBytes(4), 0);
		}

		public uint method_4(uint uint_0)
		{
			return method_3() % uint_0;
		}

		public double NextDouble()
		{
			return (double)method_3() / 4294967296.0;
		}

		public bool NextBoolean()
		{
			byte b = bQX[32 - NQm];
			NQm--;
			if (NQm == 0)
			{
				WQG();
			}
			return b % 2 == 0;
		}

		public void Shuffle<T>(IList<T> ilist_0)
		{
			for (int num = ilist_0.Count - 1; num > 1; num--)
			{
				int index = method_1(num + 1);
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
					uint num2 = method_4(num - 1) + 1;
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
			SQ8 = new byte[7] { 7, 11, 23, 37, 43, 59, 71 };
		}
	}
}
