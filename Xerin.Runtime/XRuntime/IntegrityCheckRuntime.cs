using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace XRuntime
{
	public static class IntegrityCheckRuntime
	{
		internal static void Initialize()
		{
			BinaryReader binaryReader = new BinaryReader(new StreamReader(typeof(IntegrityCheckRuntime).Assembly.Location).BaseStream);
			byte[] metin = binaryReader.ReadBytes(File.ReadAllBytes(typeof(IntegrityCheckRuntime).Assembly.Location).Length - 32);
			binaryReader.BaseStream.Position = binaryReader.BaseStream.Length - 32;
			if (MD5(metin) != Encoding.ASCII.GetString(binaryReader.ReadBytes(32)))
			{
				Terminator.Kill((uint)Process.GetCurrentProcess().Id);
			}
		}

		internal static string MD5(byte[] metin)
		{
			metin = new MD5CryptoServiceProvider().ComputeHash(metin);
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array = metin;
			foreach (byte b in array)
			{
				stringBuilder.Append(b.ToString("x2").ToLower());
			}
			return stringBuilder.ToString();
		}
	}
}
