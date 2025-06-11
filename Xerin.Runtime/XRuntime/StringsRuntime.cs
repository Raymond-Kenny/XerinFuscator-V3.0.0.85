using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace XRuntime
{
	public static class StringsRuntime
	{
		public static string[] stringsList;

		public static uint? field;

		public static Dictionary<string, string> hTable;

		public static string Xor(this string szPlainText)
		{
			StringBuilder stringBuilder = new StringBuilder(szPlainText);
			StringBuilder stringBuilder2 = new StringBuilder(szPlainText.Length);
			for (int i = 0; i < szPlainText.Length; i++)
			{
				char c = stringBuilder[i];
				c = (char)(c ^ 1);
				stringBuilder2.Append(c);
			}
			return stringBuilder2.ToString();
		}

		public static string Revert(this string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return str;
			}
			string str2 = str.Xor();
			TextElementEnumerator textElementEnumerator = StringInfo.GetTextElementEnumerator(str2);
			List<string> list = new List<string>();
			while (textElementEnumerator.MoveNext())
			{
				list.Add(textElementEnumerator.GetTextElement());
			}
			list.Reverse();
			return string.Concat(list);
		}

		public static byte[] Read(Stream stream)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				stream.CopyTo(memoryStream);
				return memoryStream.ToArray();
			}
		}

		public static void Extract(string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				stringsList = new string[0];
				Stream manifestResourceStream = typeof(StringsRuntime).Assembly.GetManifestResourceStream(name);
				StreamReader streamReader = new StreamReader(new MemoryStream(QuickLZDecompression.decompress(Read(manifestResourceStream))));
				string text;
				while ((text = streamReader.ReadLine()) != null)
				{
					Array.Resize(ref stringsList, stringsList.Length + 1);
					stringsList[stringsList.Length - 1] = text;
				}
			}
		}

		public static string Call(string[] arr, uint? ui, string password, int index, DateTime dateTime, bool t)
		{
			if (hTable == null)
			{
				hTable = new Dictionary<string, string>();
			}
			if (index < 0 || index >= arr.Length)
			{
				return GenerateJunkString();
			}
			string text = arr[index];
			ui = field;
			if (!ui.HasValue)
			{
				lock (hTable)
				{
					string value;
					if (hTable.TryGetValue(text, out value))
					{
						return value;
					}
				}
				if (dateTime == default(DateTime))
				{
					return dateTime.ToLongDateString();
				}
				byte[] bytes = Convert.FromBase64String(password);
				string s = Encoding.UTF8.GetString(bytes);
				byte[] bytes2 = Encoding.UTF8.GetBytes(s);
				byte[] array = Convert.FromBase64String(text);
				for (int i = 0; i < array.Length; i++)
				{
					array[i] ^= bytes2[i % bytes2.Length];
				}
				string str = Encoding.UTF8.GetString(array);
				TextElementEnumerator textElementEnumerator = StringInfo.GetTextElementEnumerator(str);
				List<string> list = new List<string>();
				while (textElementEnumerator.MoveNext())
				{
					list.Add(textElementEnumerator.GetTextElement());
				}
				list.Reverse();
				string str2 = string.Concat(list);
				str2 = str2.Revert();
				byte[] bytes3 = Convert.FromBase64String(str2);
				string text2 = Encoding.UTF8.GetString(bytes3);
				lock (hTable)
				{
					hTable[text] = text2;
				}
				return text2;
			}
			return GenerateJunkString();
		}

		public static string GenerateJunkString()
		{
			return Guid.NewGuid().ToString("N").Substring(0, 8);
		}
	}
}
