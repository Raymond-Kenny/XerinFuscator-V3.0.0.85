using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

namespace XRuntime
{
	public static class ResRuntime
	{
		public static Assembly c;

		internal static void Initialize()
		{
			Stream manifestResourceStream = typeof(ResRuntime).Assembly.GetManifestResourceStream(XMutationClass.Key<string>(6));
			byte[] array = new byte[manifestResourceStream.Length];
			manifestResourceStream.Read(array, 0, array.Length);
			Rijndael rijndael = Rijndael.Create();
			rijndael.Key = SHA256.Create().ComputeHash(BitConverter.GetBytes(XMutationClass.Key<int>(5)));
			rijndael.IV = new byte[16];
			rijndael.Mode = CipherMode.CBC;
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateDecryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			array = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			c = Assembly.Load(QuickLZDecompression.decompress(array));
			AppDomain.CurrentDomain.AssemblyResolve += Handler;
		}

		public static Assembly Handler(object sender, ResolveEventArgs args)
		{
			if (c.FullName == args.Name)
			{
				return c;
			}
			return null;
		}
	}
}
