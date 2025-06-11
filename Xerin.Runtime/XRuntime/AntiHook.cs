using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace XRuntime
{
	public static class AntiHook
	{
		public struct UNICODE_STRING
		{
			public ushort Length;

			public ushort MaximumLength;

			public IntPtr Buffer;
		}

		public struct ANSI_STRING
		{
			public short Length;

			public short MaximumLength;

			public IntPtr Buffer;
		}

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetProcAddress(IntPtr ModuleHandle, string Function);

		[DllImport("ntdll.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern void RtlInitUnicodeString(out UNICODE_STRING DestinationString, string SourceString);

		[DllImport("ntdll.dll", CharSet = CharSet.Ansi, SetLastError = true)]
		private static extern void RtlUnicodeStringToAnsiString(out ANSI_STRING DestinationString, UNICODE_STRING UnicodeString, bool AllocateDestinationString);

		[DllImport("ntdll.dll", SetLastError = true)]
		private static extern uint LdrGetDllHandleEx(ulong Flags, [MarshalAs(UnmanagedType.LPWStr)] string DllPath, [MarshalAs(UnmanagedType.LPWStr)] string DllCharacteristics, UNICODE_STRING LibraryName, ref IntPtr DllHandle);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetModuleHandleA(string Library);

		[DllImport("ntdll.dll", CharSet = CharSet.Ansi, SetLastError = true)]
		private static extern uint LdrGetProcedureAddressForCaller(IntPtr Module, ANSI_STRING ProcedureName, ushort ProcedureNumber, out IntPtr FunctionHandle, ulong Flags, IntPtr CallBack);

		private static IntPtr LowLevelGetModuleHandle(string Library)
		{
			if (IntPtr.Size == 4)
			{
				return GetModuleHandleA(Library);
			}
			IntPtr DllHandle = IntPtr.Zero;
			UNICODE_STRING DestinationString = default(UNICODE_STRING);
			RtlInitUnicodeString(out DestinationString, Library);
			LdrGetDllHandleEx(0uL, null, null, DestinationString, ref DllHandle);
			return DllHandle;
		}

		private static IntPtr LowLevelGetProcAddress(IntPtr hModule, string Function)
		{
			if (IntPtr.Size == 4)
			{
				return GetProcAddress(hModule, Function);
			}
			IntPtr FunctionHandle = IntPtr.Zero;
			UNICODE_STRING DestinationString = default(UNICODE_STRING);
			ANSI_STRING DestinationString2 = default(ANSI_STRING);
			RtlInitUnicodeString(out DestinationString, Function);
			RtlUnicodeStringToAnsiString(out DestinationString2, DestinationString, true);
			LdrGetProcedureAddressForCaller(hModule, DestinationString2, 0, out FunctionHandle, 0uL, IntPtr.Zero);
			return FunctionHandle;
		}

		private static byte InternalReadByte(IntPtr ptr)
		{
			try
			{
				return Marshal.ReadByte(ptr);
			}
			catch
			{
				return 0;
			}
		}

		private static bool DetectHooksForDebugAndCrack(string ModuleName, string[] Functions)
		{
			string[] array = new string[3] { "kernel32.dll", "kernelbase.dll", "ntdll.dll" };
			string[] array2 = new string[2] { "ReadProcessMemory", "WriteProcessMemory" };
			string[] array3 = new string[6] { "NtQueryInformationProcess", "NtSetInformationThread", "NtClose", "NtGetContextThread", "NtReadVirtualMemory", "NtWriteVirtualMemory" };
			string[] array4 = array;
			foreach (string text in array4)
			{
				IntPtr intPtr = LowLevelGetModuleHandle(text);
				if (!(intPtr != IntPtr.Zero))
				{
					continue;
				}
				switch (text)
				{
				case "kernel32.dll":
				case "kernelbase.dll":
					try
					{
						string[] array6 = array2;
						foreach (string function2 in array6)
						{
							IntPtr intPtr2 = LowLevelGetProcAddress(intPtr, function2);
							for (int l = 0; l < 4; l++)
							{
								byte b2 = InternalReadByte(intPtr2 + l);
								if (b2 == 144 || b2 == 233 || b2 == 204 || b2 == 195 || b2 == 235)
								{
									Terminator.Kill((uint)Process.GetCurrentProcess().Id);
									return true;
								}
							}
						}
					}
					catch
					{
					}
					break;
				case "ntdll.dll":
					try
					{
						string[] array5 = array3;
						foreach (string function in array5)
						{
							IntPtr ptr = LowLevelGetProcAddress(intPtr, function);
							byte b = InternalReadByte(ptr);
							if (b == 144 || b == 233 || b == 204 || b == 195 || b == 235)
							{
								Terminator.Kill((uint)Process.GetCurrentProcess().Id);
								return true;
							}
						}
					}
					catch
					{
					}
					break;
				}
			}
			if (ModuleName != null && Functions != null)
			{
				try
				{
					foreach (string function3 in Functions)
					{
						IntPtr hModule = LowLevelGetModuleHandle(ModuleName);
						IntPtr ptr2 = LowLevelGetProcAddress(hModule, function3);
						byte b3 = InternalReadByte(ptr2);
						if (b3 == byte.MaxValue || b3 == 144 || b3 == 233)
						{
							Terminator.Kill((uint)Process.GetCurrentProcess().Id);
							return true;
						}
					}
				}
				catch
				{
				}
			}
			return false;
		}

		private static void Detector(object thread)
		{
			Thread thread2 = thread as Thread;
			if (thread2 == null)
			{
				thread2 = new Thread(Detector)
				{
					IsBackground = true,
					Priority = ThreadPriority.Lowest
				};
				thread2.Start(Thread.CurrentThread);
				Thread.Sleep(500);
			}
			while (true)
			{
				try
				{
					if (DetectHooksForDebugAndCrack(null, null))
					{
						Terminator.Kill((uint)Process.GetCurrentProcess().Id);
					}
					if (!thread2.IsAlive)
					{
						Terminator.Kill((uint)Process.GetCurrentProcess().Id);
					}
				}
				catch
				{
					Terminator.Kill((uint)Process.GetCurrentProcess().Id);
				}
				Thread.Sleep(2000);
			}
		}

		public static void Initialize()
		{
			try
			{
				if (DetectHooksForDebugAndCrack(null, null))
				{
					Terminator.Kill((uint)Process.GetCurrentProcess().Id);
				}
			}
			catch
			{
				Terminator.Kill((uint)Process.GetCurrentProcess().Id);
			}
			Thread thread = new Thread(Detector);
			thread.IsBackground = true;
			thread.Priority = ThreadPriority.Lowest;
			thread.Start();
		}
	}
}
