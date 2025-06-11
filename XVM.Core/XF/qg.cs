using System;
using System.Runtime.InteropServices;

namespace XF
{
	internal static class qg
	{
		internal enum oLW
		{

		}

		internal enum NLE
		{

		}

		internal enum dLN : uint
		{

		}

		internal enum yL2 : uint
		{

		}

		internal enum gLK : uint
		{

		}

		internal static readonly IntPtr he1;

		[DllImport("crypt32.dll", SetLastError = true)]
		private static extern bool CryptProtectMemory(IntPtr intptr_0, uint uint_0, uint uint_1);

		[DllImport("crypt32.dll", SetLastError = true)]
		private static extern bool CryptUnprotectMemory(IntPtr intptr_0, uint uint_0, uint uint_1);

		[DllImport("kernel32.dll")]
		private unsafe static extern void* LocalAlloc(int int_0, ulong ulong_0);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr LocalFree(IntPtr intptr_0);

		[DllImport("user32.dll")]
		private static extern int MessageBoxA(IntPtr intptr_0, string string_0, string string_1, uint uint_0);

		[DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal unsafe static extern bool VirtualProtect(void* pVoid_0, uint uint_0, uint uint_1, out uint uint_2);

		[DllImport("kernel32.dll", EntryPoint = "VirtualProtect", SetLastError = true)]
		internal static extern bool VirtualProtect_1(IntPtr intptr_0, uint uint_0, uint uint_1, out uint uint_2);

		[DllImport("kernel32.dll", EntryPoint = "VirtualProtect", SetLastError = true)]
		internal static extern IntPtr VirtualProtect_2(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2, ref IntPtr intptr_3);

		[DllImport("kernel32.dll")]
		internal unsafe static extern void RtlSecureZeroMemory(byte* pByte_0, int int_0);

		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		internal static extern bool CheckRemoteDebuggerPresent(IntPtr intptr_0, ref bool bool_0);

		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern IntPtr ZeroMemory(IntPtr intptr_0, IntPtr intptr_1);

		[DllImport("kernel32.dll", EntryPoint = "ZeroMemory", SetLastError = true)]
		internal unsafe static extern bool ZeroMemory_1(byte* pByte_0, int int_0);

		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern IntPtr LoadLibrary(string string_0);

		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "LoadLibrary", SetLastError = true)]
		internal static extern IntPtr LoadLibrary_1(IntPtr intptr_0);

		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool FreeLibrary(IntPtr intptr_0);

		[DllImport("kernel32.dll", SetLastError = true)]
		internal unsafe static extern void* GetProcAddress(IntPtr intptr_0, string string_0);

		[DllImport("kernel32.dll", EntryPoint = "GetProcAddress", SetLastError = true)]
		internal static extern IntPtr GetProcAddress_1(IntPtr intptr_0, string string_0);

		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress", ExactSpelling = true, SetLastError = true)]
		internal static extern IntPtr GetProcAddress_2(IntPtr intptr_0, IntPtr intptr_1);

		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
		internal static extern IntPtr memset(IntPtr intptr_0, int int_0, UIntPtr uintptr_0);

		[DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = true)]
		public unsafe static extern void* GetModuleHandle(string string_0);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool Wow64DisableWow64FsRedirection(ref IntPtr intptr_0);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool Wow64RevertWow64FsRedirection(IntPtr intptr_0);

		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool SwitchToThread();

		internal static NLE MeM(string string_0)
		{
			return (NLE)MessageBoxA(IntPtr.Zero, string_0, "\0", 0u);
		}

		internal static NLE XeA(string string_0, string string_1)
		{
			return (NLE)MessageBoxA(IntPtr.Zero, string_0, string_1, 0u);
		}

		internal static NLE XeR(string string_0, string string_1, oLW oLW_0 = (oLW)0)
		{
			return (NLE)MessageBoxA(IntPtr.Zero, string_0, string_1, (uint)oLW_0);
		}

		internal static NLE fe0(string string_0, string string_1, oLW oLW_0, gLK gLK_0)
		{
			return (NLE)MessageBoxA(IntPtr.Zero, string_0, string_1, (uint)oLW_0 | (uint)gLK_0);
		}

		internal static NLE Pew(string string_0, string string_1, oLW oLW_0, gLK gLK_0, dLN dLN_0)
		{
			return (NLE)MessageBoxA(IntPtr.Zero, string_0, string_1, (uint)oLW_0 | (uint)gLK_0 | (uint)dLN_0);
		}

		internal static NLE teW(string string_0, string string_1, oLW oLW_0, gLK gLK_0, dLN dLN_0, yL2 yL2_0)
		{
			return (NLE)MessageBoxA(IntPtr.Zero, string_0, string_1, (uint)oLW_0 | (uint)gLK_0 | (uint)dLN_0 | (uint)yL2_0);
		}

		internal unsafe static void* geE(ulong ulong_0)
		{
			return LocalAlloc(0, ulong_0);
		}

		internal static bool BeN(IntPtr intptr_0)
		{
			if (!(he1 == LocalFree(intptr_0)))
			{
				return false;
			}
			return true;
		}

		public static void Ce2(IntPtr intptr_0, uint uint_0)
		{
			CryptProtectMemory(intptr_0, uint_0, 0u);
		}

		public static void teK(IntPtr intptr_0, uint uint_0)
		{
			CryptUnprotectMemory(intptr_0, uint_0, 0u);
		}

		static qg()
		{
			he1 = IntPtr.Zero;
		}
	}
}
