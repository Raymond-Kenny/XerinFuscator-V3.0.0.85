using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace XRuntime
{
	public static class embedRuntime
	{
		private static void AppStart()
		{
			AppDomain.CurrentDomain.AssemblyResolve += ResolveAssemblies;
		}

		private static Assembly ResolveAssemblies(object sender, ResolveEventArgs args)
		{
			try
			{
				string name = args.Name;
				string text = name.Split(',')[0];
				string[] array = new string[3]
				{
					text,
					text.Replace(".dll", ""),
					Path.GetFileNameWithoutExtension(text)
				};
				string[] manifestResourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
				string[] array2 = array;
				foreach (string name2 in array2)
				{
					Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name2);
					if (manifestResourceStream != null)
					{
						using (manifestResourceStream)
						{
							byte[] array3 = new byte[manifestResourceStream.Length];
							manifestResourceStream.Read(array3, 0, array3.Length);
							return Assembly.Load(Decompress(array3));
						}
					}
				}
				return null;
			}
			catch (Exception)
			{
				return null;
			}
		}

		private static byte[] Decompress(byte[] data)
		{
			MemoryStream stream = new MemoryStream(data);
			MemoryStream memoryStream = new MemoryStream();
			using (DeflateStream deflateStream = new DeflateStream(stream, CompressionMode.Decompress))
			{
				deflateStream.CopyTo(memoryStream);
			}
			return memoryStream.ToArray();
		}
	}
}
