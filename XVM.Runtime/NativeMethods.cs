using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal static class NativeMethods
{
	internal enum MessageBoxButtons
	{
		AbortRetryIgnore = 2,
		CancelTryIgnore = 6,
		Help = 16384,
		OK = 0,
		OKCancel = 1,
		RetryCancel = 5,
		YesNo = 4,
		YesNoCancel = 3
	}

	internal enum MessageBoxResult
	{
		Abort = 3,
		Cancel = 2,
		Continue = 11,
		Ignore = 5,
		No = 7,
		Ok = 1,
		Retry = 10,
		Yes = 6
	}

	internal enum MessageBoxDefaultButton : uint
	{
		Button1 = 0u,
		Button2 = 256u,
		Button3 = 512u,
		Button4 = 768u
	}

	internal enum MessageBoxModal : uint
	{
		Application = 0u,
		System = 0x1000u,
		Task = 0x2000u
	}

	internal enum MessageBoxIcon : uint
	{
		None = 0u,
		Warning = 48u,
		Information = 64u,
		Question = 32u,
		Error = 16u
	}

	[UnmanagedFunctionPointer(CallingConvention.StdCall, SetLastError = true)]
	internal unsafe delegate int CompileMethodDelegate(IntPtr thisPtr, IntPtr corJitInfo, CORINFO_METHOD_INFO* methodInfo, [MarshalAs(UnmanagedType.U4)] CorJitFlag flags, IntPtr nativeEntry, IntPtr nativeSizeOfCode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, SetLastError = true)]
	internal unsafe delegate IntPtr* getJit();

	[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 136)]
	internal struct CORINFO_METHOD_INFO
	{
		public IntPtr MethodHandle;

		public IntPtr ModuleHandle;

		public IntPtr ILCode;

		public uint ILCodeSize;

		public uint MaxStack;
	}

	public enum CorJitFlag : uint
	{
		CORJIT_UNKNOWN = 216669565u,
		CORJIT_FLAG_CALL_GETJITFLAGS = uint.MaxValue,
		CORJIT_FLAG_SPEED_OPT = 0u,
		CORJIT_FLAG_SIZE_OPT = 1u,
		CORJIT_FLAG_DEBUG_CODE = 2u,
		CORJIT_FLAG_DEBUG_EnC = 3u,
		CORJIT_FLAG_DEBUG_INFO = 4u,
		CORJIT_FLAG_MIN_OPT = 5u,
		CORJIT_FLAG_ENABLE_CFG = 6u,
		CORJIT_FLAG_MCJIT_BACKGROUND = 7u,
		CORJIT_FLAG_UNUSED2 = 8u,
		CORJIT_FLAG_UNUSED3 = 9u,
		CORJIT_FLAG_UNUSED4 = 10u,
		CORJIT_FLAG_UNUSED5 = 11u,
		CORJIT_FLAG_UNUSED6 = 12u,
		CORJIT_FLAG_OSR = 13u,
		CORJIT_FLAG_ALT_JIT = 14u,
		CORJIT_FLAG_UNUSED10 = 17u,
		CORJIT_FLAG_MAKEFINALCODE = 18u,
		CORJIT_FLAG_READYTORUN = 19u,
		CORJIT_FLAG_PROF_ENTERLEAVE = 20u,
		CORJIT_FLAG_UNUSED7 = 21u,
		CORJIT_FLAG_PROF_NO_PINVOKE_INLINE = 22u,
		CORJIT_FLAG_SKIP_VERIFICATION = 23u,
		CORJIT_FLAG_PREJIT = 24u,
		CORJIT_FLAG_RELOC = 25u,
		CORJIT_FLAG_IMPORT_ONLY = 26u,
		CORJIT_FLAG_IL_STUB = 27u,
		CORJIT_FLAG_PROCSPLIT = 28u,
		CORJIT_FLAG_BBINSTR = 29u,
		CORJIT_FLAG_BBOPT = 30u,
		CORJIT_FLAG_FRAMED = 31u,
		CORJIT_FLAG_BBINSTR_IF_LOOPS = 32u,
		CORJIT_FLAG_PUBLISH_SECRET_PARAM = 33u,
		CORJIT_FLAG_UNUSED9 = 34u,
		CORJIT_FLAG_SAMPLING_JIT_BACKGROUND = 35u,
		CORJIT_FLAG_USE_PINVOKE_HELPERS = 36u,
		CORJIT_FLAG_REVERSE_PINVOKE = 37u,
		CORJIT_FLAG_TRACK_TRANSITIONS = 38u,
		CORJIT_FLAG_TIER0 = 39u,
		CORJIT_FLAG_TIER1 = 40u,
		CORJIT_FLAG_RELATIVE_CODE_RELOCS = 41u,
		CORJIT_FLAG_NO_INLINING = 42u,
		CORJIT_FLAG_SOFTFP_ABI = 43u
	}

	internal static readonly IntPtr NULL = IntPtr.Zero;

	[DllImport("crypt32.dll", SetLastError = true)]
	private static extern bool CryptProtectMemory(IntPtr pData, uint cbData, uint dwFlags);

	[DllImport("crypt32.dll", SetLastError = true)]
	private static extern bool CryptUnprotectMemory(IntPtr pData, uint cbData, uint dwFlags);

	[DllImport("kernel32.dll")]
	private unsafe static extern void* LocalAlloc(int uFlags, ulong sizetdwBytes);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr LocalFree(IntPtr handle);

	[DllImport("user32.dll")]
	private static extern int MessageBoxA(IntPtr hWnd, string lpText, string lpCaption, uint uType);

	[DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal unsafe static extern bool VirtualProtect(void* lpAddress, uint dwSize, uint flNewProtect, out uint lpflOldProtect);

	[DllImport("kernel32.dll", SetLastError = true)]
	internal static extern bool VirtualProtect(IntPtr lpAddress, uint dwSize, uint flNewProtect, out uint lpflOldProtect);

	[DllImport("kernel32.dll", SetLastError = true)]
	internal static extern IntPtr VirtualProtect(IntPtr lpAddress, IntPtr dwSize, IntPtr flNewProtect, ref IntPtr lpflOldProtect);

	[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr memcpy(IntPtr dest, IntPtr src, int count);

	[DllImport("Kernel32.dll", EntryPoint = "RtlSecureZeroMemory")]
	internal unsafe static extern void SecureZeroMemory(byte* dest, int size);

	[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
	internal static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);

	[DllImport("kernel32.dll", SetLastError = true)]
	internal static extern IntPtr ZeroMemory(IntPtr addr, IntPtr size);

	[DllImport("kernel32.dll", SetLastError = true)]
	internal unsafe static extern bool ZeroMemory(byte* destination, int length);

	[DllImport("kernel32.dll", SetLastError = true)]
	internal static extern IntPtr LoadLibrary(string lib);

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
	internal static extern IntPtr LoadLibrary(IntPtr lpFileName);

	[DllImport("kernel32.dll", SetLastError = true)]
	internal static extern bool FreeLibrary(IntPtr hModule);

	[DllImport("kernel32.dll", EntryPoint = "GetProcAddress", SetLastError = true)]
	internal unsafe static extern void* _GetProcAddress(IntPtr lib, string proc);

	[DllImport("kernel32.dll", SetLastError = true)]
	internal static extern IntPtr GetProcAddress(IntPtr lib, string proc);

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	internal static extern IntPtr GetProcAddress(IntPtr hModule, IntPtr procName);

	[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "memset")]
	internal static extern IntPtr MemSet(IntPtr dest, int c, UIntPtr count);

	[DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = true)]
	public unsafe static extern void* GetModuleHandle(string lpModuleName);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool Wow64DisableWow64FsRedirection(ref IntPtr ptr);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool Wow64RevertWow64FsRedirection(IntPtr ptr);

	[DllImport("kernel32.dll", SetLastError = true)]
	internal static extern bool SwitchToThread();

	internal static MessageBoxResult MessageBox(string text)
	{
		return (MessageBoxResult)MessageBoxA(IntPtr.Zero, text, "\0", 0u);
	}

	internal static MessageBoxResult MessageBox(string text, string caption)
	{
		return (MessageBoxResult)MessageBoxA(IntPtr.Zero, text, caption, 0u);
	}

	internal static MessageBoxResult MessageBox(string text, string caption, MessageBoxButtons buttons = MessageBoxButtons.OK)
	{
		return (MessageBoxResult)MessageBoxA(IntPtr.Zero, text, caption, (uint)buttons);
	}

	internal static MessageBoxResult MessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
	{
		return (MessageBoxResult)MessageBoxA(IntPtr.Zero, text, caption, (uint)buttons | (uint)icon);
	}

	internal static MessageBoxResult MessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton button)
	{
		return (MessageBoxResult)MessageBoxA(IntPtr.Zero, text, caption, (uint)buttons | (uint)icon | (uint)button);
	}

	internal static MessageBoxResult MessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton button, MessageBoxModal modal)
	{
		return (MessageBoxResult)MessageBoxA(IntPtr.Zero, text, caption, (uint)buttons | (uint)icon | (uint)button | (uint)modal);
	}

	internal unsafe static void* malloc(ulong sizetdwBytes)
	{
		return LocalAlloc(0, sizetdwBytes);
	}

	internal static bool FreeMemory(IntPtr hglobal)
	{
		if (NULL == LocalFree(hglobal))
		{
			return true;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CryptProtectMemory(IntPtr pBuffer, uint byteCount)
	{
		CryptProtectMemory(pBuffer, byteCount, 0u);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CryptUnprotectMemory(IntPtr pBuffer, uint byteCount)
	{
		CryptUnprotectMemory(pBuffer, byteCount, 0u);
	}
}
