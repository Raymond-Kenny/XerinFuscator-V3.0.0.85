using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace XF
{
	internal static class VYK
	{
		private static readonly char[] qYi;

		public static hYc xYh<RYr, hYc>(this Dictionary<RYr, hYc> dictionary_0, RYr IYw, hYc oYq = default(hYc))
		{
			hYc value;
			if (dictionary_0.TryGetValue(IYw, out value))
			{
				return value;
			}
			return oYq;
		}

		public static GYu FYb<JYk, GYu>(this Dictionary<JYk, GYu> dictionary_0, JYk yY3, Func<JYk, GYu> func_0)
		{
			GYu value;
			if (dictionary_0.TryGetValue(yY3, out value))
			{
				return value;
			}
			return func_0(yY3);
		}

		public static void zYM<CYL, NYV>(this IDictionary<CYL, List<NYV>> idictionary_0, CYL lYW, NYV wYG)
		{
			if (lYW == null)
			{
				throw new ArgumentNullException("key");
			}
			List<NYV> value;
			if (!idictionary_0.TryGetValue(lYW, out value))
			{
				List<NYV> list = (idictionary_0[lYW] = new List<NYV>());
				value = list;
			}
			value.Add(wYG);
		}

		public static string HY8(string string_0, string string_1)
		{
			if (string_0 != null)
			{
				if (string_1 == null)
				{
					throw new ArgumentNullException("fileSpec");
				}
				return gYZ(new FileInfo(string_0), new DirectoryInfo(string_1));
			}
			throw new ArgumentNullException("fileSpec");
		}

		public static string gYZ(object object_0, FileSystemInfo fileSystemInfo_0)
		{
			if (object_0 == null)
			{
				throw new ArgumentNullException("fileSpec");
			}
			if (fileSystemInfo_0 == null)
			{
				throw new ArgumentNullException("fileSpec");
			}
			if (fileSystemInfo_0.FullName.EndsWith(Path.DirectorySeparatorChar.ToString()))
			{
				fileSystemInfo_0 = new DirectoryInfo(fileSystemInfo_0.FullName.TrimEnd(Path.DirectorySeparatorChar));
			}
			string text = ((FileSystemInfo)object_0).Name;
			DirectoryInfo directoryInfo = ((FileInfo)object_0).Directory;
			while (directoryInfo != null && !string.Equals(directoryInfo.FullName, fileSystemInfo_0.FullName, StringComparison.OrdinalIgnoreCase))
			{
				text = directoryInfo.Name + Path.DirectorySeparatorChar + text;
				directoryInfo = directoryInfo.Parent;
			}
			if (directoryInfo == null)
			{
				return null;
			}
			return text;
		}

		public static string nYa(this string string_0)
		{
			if (!string.IsNullOrEmpty(string_0))
			{
				return string_0;
			}
			return null;
		}

		public static byte[] iYX(byte[] byte_0)
		{
			SHA1Managed sHA1Managed = new SHA1Managed();
			return sHA1Managed.ComputeHash(byte_0);
		}

		public static byte[] nYm(object object_0, object object_1)
		{
			if (((Array)object_0).Length != ((Array)object_1).Length)
			{
				throw new ArgumentException("Length mismatched.");
			}
			byte[] array = new byte[((Array)object_0).Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(((byte[])object_0)[i] ^ ((byte[])object_1)[i]);
			}
			return array;
		}

		public static byte[] UYA(byte[] byte_0)
		{
			SHA256Managed sHA256Managed = new SHA256Managed();
			return sHA256Managed.ComputeHash(byte_0);
		}

		public static string WY9(object object_0, object object_1)
		{
			int num = ((byte[])object_0)[0];
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i < ((Array)object_0).Length; i++)
			{
				num = (num << 8) + ((byte[])object_0)[i];
				while (num >= ((Array)object_1).Length)
				{
					int result;
					num = Math.DivRem(num, ((Array)object_1).Length, out result);
					stringBuilder.Append((char)((ushort[])object_1)[result]);
				}
			}
			if (num != 0)
			{
				stringBuilder.Append((char)((ushort[])object_1)[num % ((Array)object_1).Length]);
			}
			return stringBuilder.ToString();
		}

		public static string oYP(byte[] byte_0)
		{
			char[] array = new char[byte_0.Length * 2];
			int num = 0;
			foreach (byte b in byte_0)
			{
				array[num++] = qYi[b >> 4];
				array[num++] = qYi[b & 0xF];
			}
			return new string(array);
		}

		public static void CYf<rYT>(this IList<rYT> ilist_0, Predicate<rYT> predicate_0)
		{
			List<rYT> list = ilist_0 as List<rYT>;
			if (list != null)
			{
				list.RemoveAll(predicate_0);
				return;
			}
			for (int num = ilist_0.Count - 1; num >= 0; num--)
			{
				if (predicate_0(ilist_0[num]))
				{
					ilist_0.RemoveAt(num);
				}
			}
		}

		static VYK()
		{
			qYi = "0123456789abcdef".ToCharArray();
		}
	}
}
