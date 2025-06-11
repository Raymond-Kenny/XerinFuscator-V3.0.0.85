using System.IO;
using System.Reflection;

namespace XCore
{
	public class asmInfo
	{
		public static string asmName(string string_0)
		{
			string text = "";
			try
			{
				Assembly assembly = Assembly.ReflectionOnlyLoadFrom(string_0);
				return assembly.GetName().Name;
			}
			catch
			{
				return "Failed to read info";
			}
		}

		public static string asmArch(string string_0)
		{
			string text = "";
			try
			{
				Assembly assembly = Assembly.ReflectionOnlyLoadFrom(string_0);
				PortableExecutableKinds peKind;
				ImageFileMachine machine;
				assembly.ManifestModule.GetPEKind(out peKind, out machine);
				if (!peKind.HasFlag(PortableExecutableKinds.PE32Plus))
				{
					if (machine == ImageFileMachine.I386 && peKind.HasFlag(PortableExecutableKinds.Required32Bit))
					{
						return "x86";
					}
					if (machine != ImageFileMachine.I386 || peKind.HasFlag(PortableExecutableKinds.Required32Bit))
					{
						return "Unknown";
					}
					return "Any CPU";
				}
				return "x64";
			}
			catch
			{
				return "Failed to read info";
			}
		}

		public static string asmSize(string string_0)
		{
			string text = "";
			try
			{
				Assembly.ReflectionOnlyLoadFrom(string_0);
				FileInfo fileInfo = new FileInfo(string_0);
				long length = fileInfo.Length;
				if (length >= 1048576L)
				{
					return $"{(double)length / 1048576.0:F2} MB";
				}
				return $"{(double)length / 1024.0:F2} KB";
			}
			catch
			{
				return "N/A";
			}
		}
	}
}
