using System.IO;
using dnlib.DotNet;

namespace XCore.DynConverter
{
	public static class Extension
	{
		public static void ConvertToBytes(this BinaryWriter binaryWriter_0, MethodDef methodDef_0)
		{
			new XConverter(methodDef_0, binaryWriter_0).ConvertToBytes();
		}
	}
}
