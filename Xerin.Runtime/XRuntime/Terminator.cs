using System;
using System.Runtime.InteropServices;

namespace XRuntime
{
	public static class Terminator
	{
		private struct CLIENT_ID
		{
			public IntPtr UniqueProcess;

			public IntPtr UniqueThread;
		}

		private struct OBJECT_ATTRIBUTES
		{
			public int Length;

			public IntPtr RootDirectory;

			public IntPtr ObjectName;

			public uint Attributes;

			public IntPtr SecurityDescriptor;

			public IntPtr SecurityQualityOfService;
		}

		private const uint PROCESS_ALL_ACCESS = 2097151u;

		[DllImport("ntdll.dll")]
		private static extern int NtOpenProcess(out IntPtr processHandle, uint desiredAccess, ref OBJECT_ATTRIBUTES objectAttributes, ref CLIENT_ID clientId);

		[DllImport("ntdll.dll")]
		private static extern int NtTerminateProcess(IntPtr processHandle, int exitCode);

		[DllImport("ntdll.dll")]
		private static extern int NtClose(IntPtr handle);

		public static void Kill(uint pid)
		{
			CLIENT_ID clientId = new CLIENT_ID
			{
				UniqueProcess = (IntPtr)pid,
				UniqueThread = IntPtr.Zero
			};
			OBJECT_ATTRIBUTES objectAttributes = new OBJECT_ATTRIBUTES
			{
				Length = Marshal.SizeOf<OBJECT_ATTRIBUTES>()
			};
			IntPtr processHandle;
			int num = NtOpenProcess(out processHandle, 2097151u, ref objectAttributes, ref clientId);
			if (num == 0 && processHandle != IntPtr.Zero)
			{
				NtTerminateProcess(processHandle, 0);
				NtClose(processHandle);
			}
			else
			{
				Console.WriteLine($"Failed to open process {pid}, NTSTATUS: 0x{num:X}");
			}
		}
	}
}
