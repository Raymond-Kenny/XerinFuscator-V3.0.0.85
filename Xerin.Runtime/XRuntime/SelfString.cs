using System.Collections.Generic;

namespace XRuntime
{
	public static class SelfString
	{
		public static Dictionary<string, string> hTable;

		public static string XorCipher(string cipherText, int key)
		{
			if (hTable == null)
			{
				hTable = new Dictionary<string, string>();
			}
			lock (hTable)
			{
				string value;
				if (hTable.TryGetValue(cipherText, out value))
				{
					return value;
				}
				char[] array = cipherText.ToCharArray();
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = (char)(array[i] ^ key);
				}
				string value2 = new string(array);
				hTable[cipherText] = value2;
				return hTable[cipherText];
			}
		}
	}
}
