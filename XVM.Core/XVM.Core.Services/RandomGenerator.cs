#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using dnlib.DotNet.Writer;

namespace XVM.Core.Services
{
	public class RandomGenerator
	{
		private static readonly byte[] DRG;

		private static readonly RNGCryptoServiceProvider GRI;

		private readonly SHA256Managed fRq = new SHA256Managed();

		private int nRM;

		private byte[] aRA;

		private int mRR;

		private int kR0;

		internal RandomGenerator()
		{
			byte[] array = new byte[32];
			GRI.GetBytes(array);
			aRA = aRe((byte[])array.Clone());
			kR0 = array.Length;
			mRR = 32;
			nRM = 0;
		}

		internal RandomGenerator(int int_0)
		{
			byte[] array = new byte[(int_0 != 0) ? int_0 : 32];
			GRI.GetBytes(array);
			aRA = aRe((byte[])array.Clone());
			kR0 = array.Length;
			mRR = 32;
			nRM = 0;
		}

		internal RandomGenerator(string string_0)
		{
			byte[] array = aRe((byte[])((!string.IsNullOrEmpty(string_0)) ? Encoding.UTF8.GetBytes(string_0) : Guid.NewGuid().ToByteArray()).Clone());
			for (int i = 0; i < 32; i++)
			{
				array[i] *= DRG[i % DRG.Length];
				array = aRe(array);
			}
			aRA = array;
			kR0 = array.Length;
			mRR = 32;
			nRM = 0;
		}

		internal RandomGenerator(byte[] byte_0)
		{
			aRA = (byte[])byte_0.Clone();
			kR0 = byte_0.Length;
			mRR = 32;
			nRM = 0;
		}

		private static byte[] aRe(byte[] byte_0)
		{
			SHA256Managed sHA256Managed = new SHA256Managed();
			return sHA256Managed.ComputeHash(byte_0);
		}

		private void lRu()
		{
			for (int i = 0; i < 32; i++)
			{
				aRA[i] ^= DRG[nRM = (nRM + 1) % DRG.Length];
			}
			aRA = fRq.ComputeHash(aRA);
			mRR = 32;
		}

		public void NextBytes(byte[] byte_0, int int_0, int int_1)
		{
			if (byte_0 != null)
			{
				if (int_0 < 0)
				{
					throw new ArgumentOutOfRangeException("offset");
				}
				if (int_1 < 0)
				{
					throw new ArgumentOutOfRangeException("length");
				}
				if (byte_0.Length - int_0 < int_1)
				{
					throw new ArgumentException("Invalid offset or length.");
				}
				while (int_1 > 0)
				{
					if (int_1 < mRR)
					{
						Buffer.BlockCopy(aRA, 32 - mRR, byte_0, int_0, int_1);
						mRR -= int_1;
						int_1 = 0;
					}
					else
					{
						Buffer.BlockCopy(aRA, 32 - mRR, byte_0, int_0, mRR);
						int_0 += mRR;
						int_1 -= mRR;
						mRR = 0;
					}
					if (mRR == 0)
					{
						lRu();
					}
				}
				return;
			}
			throw new ArgumentNullException("buffer");
		}

		public byte NextByte()
		{
			byte result = aRA[32 - mRR];
			mRR--;
			if (mRR == 0)
			{
				lRu();
			}
			return result;
		}

		public string NextString(int int_0)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < int_0; i++)
				{
					char value = Convert.ToChar(Convert.ToInt32(Math.Floor(32m + (decimal)method_1(122) - 32m)));
					stringBuilder.Append(value);
				}
				return stringBuilder.ToString();
			}
			catch
			{
			}
			return string.Empty;
		}

		public string NextHexString(int int_0, bool bool_0 = false)
		{
			if (!int_0.ToString().Contains("5"))
			{
				try
				{
					string element = "qwertyuıopğüasdfghjklşizxcvbnmöçQWERTYUIOPĞÜASDFGHJKLŞİZXCVBNMÖÇ0123456789/*-.:,;!'^+%&/()=?_~|\\}][{½$#£>";
					string s = new string((from string_0 in Enumerable.Repeat(element, int_0 / 2)
						select string_0[method_1(string_0.Length)]).ToArray());
					if (!bool_0)
					{
						return BitConverter.ToString(Encoding.Default.GetBytes(s)).Replace("-", string.Empty).ToLower();
					}
					if (bool_0)
					{
						return BitConverter.ToString(Encoding.Default.GetBytes(s)).Replace("-", string.Empty);
					}
				}
				catch
				{
				}
				return string.Empty;
			}
			throw new Exception("5 is an unacceptable number!");
		}

		public string NextHexString(bool bool_0 = false)
		{
			return NextHexString(8, bool_0);
		}

		public string NextString()
		{
			return NextString(kR0);
		}

		public byte[] NextBytes(int int_0)
		{
			byte[] array = new byte[int_0];
			NextBytes(array, 0, int_0);
			return array;
		}

		public byte[] NextBytes()
		{
			byte[] array = new byte[kR0];
			NextBytes(array, 0, kR0);
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

		public double NextDouble(double double_0, double double_1)
		{
			return NextDouble() * (double_1 - double_0) + double_0;
		}

		public bool NextBoolean()
		{
			byte b = aRA[32 - mRR];
			mRR--;
			if (mRR == 0)
			{
				lRu();
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
			DRG = new byte[7] { 7, 11, 23, 37, 43, 59, 71 };
			GRI = new RNGCryptoServiceProvider();
		}

		[CompilerGenerated]
		private char rR9(string string_0)
		{
			return string_0[method_1(string_0.Length)];
		}
	}
}
