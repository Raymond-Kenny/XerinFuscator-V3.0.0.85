using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace XCore.CE
{
	public static class Utils
	{
		private static readonly char[] iQl;

		public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary_0, TKey EQP, TValue VQf = default(TValue))
		{
			TValue value;
			if (dictionary_0.TryGetValue(EQP, out value))
			{
				return value;
			}
			return VQf;
		}

		public static TValue GetValueOrDefaultLazy<TKey, TValue>(this Dictionary<TKey, TValue> dictionary_0, TKey rQT, Func<TKey, TValue> func_0)
		{
			TValue value;
			if (dictionary_0.TryGetValue(rQT, out value))
			{
				return value;
			}
			return func_0(rQT);
		}

		public static void AddListEntry<TKey, TValue>(this IDictionary<TKey, List<TValue>> idictionary_0, TKey IQi, TValue AQS)
		{
			if (IQi == null)
			{
				throw new ArgumentNullException("key");
			}
			List<TValue> value;
			if (!idictionary_0.TryGetValue(IQi, out value))
			{
				List<TValue> list = (idictionary_0[IQi] = new List<TValue>());
				value = list;
			}
			value.Add(AQS);
		}

		public static string GetRelativePath(string string_0, string string_1)
		{
			if (string_0 == null)
			{
				throw new ArgumentNullException("fileSpec");
			}
			if (string_1 == null)
			{
				throw new ArgumentNullException("fileSpec");
			}
			return GetRelativePath(new FileInfo(string_0), new DirectoryInfo(string_1));
		}

		public static string GetRelativePath(FileInfo fileInfo_0, DirectoryInfo directoryInfo_0)
		{
			if (fileInfo_0 != null)
			{
				if (directoryInfo_0 == null)
				{
					throw new ArgumentNullException("fileSpec");
				}
				if (directoryInfo_0.FullName.EndsWith(Path.DirectorySeparatorChar.ToString()))
				{
					directoryInfo_0 = new DirectoryInfo(directoryInfo_0.FullName.TrimEnd(Path.DirectorySeparatorChar));
				}
				string text = fileInfo_0.Name;
				DirectoryInfo directoryInfo = fileInfo_0.Directory;
				while (directoryInfo != null && !string.Equals(directoryInfo.FullName, directoryInfo_0.FullName, StringComparison.OrdinalIgnoreCase))
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
			throw new ArgumentNullException("fileSpec");
		}

		public static string NullIfEmpty(this string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return null;
			}
			return string_0;
		}

		public static byte[] SHA1(byte[] byte_0)
		{
			SHA1Managed sHA1Managed = new SHA1Managed();
			return sHA1Managed.ComputeHash(byte_0);
		}

		public static byte[] Xor(byte[] byte_0, byte[] byte_1)
		{
			if (byte_0.Length != byte_1.Length)
			{
				throw new ArgumentException("Length mismatched.");
			}
			byte[] array = new byte[byte_0.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(byte_0[i] ^ byte_1[i]);
			}
			return array;
		}

		public static byte[] SHA256(byte[] byte_0)
		{
			SHA256Managed sHA256Managed = new SHA256Managed();
			return sHA256Managed.ComputeHash(byte_0);
		}

		public static string EncodeString(byte[] byte_0, char[] char_0)
		{
			int num = byte_0[0];
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i < byte_0.Length; i++)
			{
				num = (num << 8) + byte_0[i];
				while (num >= char_0.Length)
				{
					int result;
					num = Math.DivRem(num, char_0.Length, out result);
					stringBuilder.Append(char_0[result]);
				}
			}
			if (num != 0)
			{
				stringBuilder.Append(char_0[num % char_0.Length]);
			}
			return stringBuilder.ToString();
		}

		public static string ToHexString(byte[] byte_0)
		{
			char[] array = new char[byte_0.Length * 2];
			int num = 0;
			foreach (byte b in byte_0)
			{
				array[num++] = iQl[b >> 4];
				array[num++] = iQl[b & 0xF];
			}
			return new string(array);
		}

		public static void RemoveWhere<T>(this IList<T> ilist_0, Predicate<T> predicate_0)
		{
			List<T> list = ilist_0 as List<T>;
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

		static Utils()
		{
			iQl = "0123456789abcdef".ToCharArray();
		}
	}
}
