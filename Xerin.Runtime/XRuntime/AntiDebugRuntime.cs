using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace XRuntime
{
	public static class AntiDebugRuntime
	{
		internal delegate int GetProcA();

		internal delegate int GetProcA2(IntPtr hProcess, ref int pbDebuggerPresent);

		internal delegate int WL(IntPtr wnd, IntPtr lParam);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate bool IsDebuggerPresentDelegate();

		[DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
		internal static extern GetProcA GetProcAddress(IntPtr hModule, string procName);

		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress")]
		internal static extern GetProcA2 GetProcAddress_2(IntPtr hModule, string procName);

		[DllImport("kernel32.dll")]
		internal static extern IntPtr OpenProcess(uint hModule, int procName, uint procId);

		[DllImport("kernel32.dll")]
		internal static extern uint GetCurrentProcessId();

		[DllImport("kernel32.dll")]
		internal static extern int CloseHandle(IntPtr hModule);

		[DllImport("kernel32.dll")]
		public static extern IntPtr LoadLibrary(string dllToLoad);

		[DllImport("kernel32.dll")]
		public static extern bool IsDebuggerPresent();

		internal static bool Detected()
		{
			try
			{
				IntPtr intPtr = LoadLibrary("kernel32.dll");
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				GetProcA procAddress = GetProcAddress(intPtr, "IsDebuggerPresent");
				if (procAddress != null && procAddress() != 0)
				{
					return true;
				}
				IntPtr intPtr2 = OpenProcess(1024u, 0, GetCurrentProcessId());
				if (intPtr2 != IntPtr.Zero)
				{
					try
					{
						GetProcA2 procAddress_ = GetProcAddress_2(intPtr, "CheckRemoteDebuggerPresent");
						if (procAddress_ != null)
						{
							int pbDebuggerPresent = 0;
							if (procAddress_(intPtr2, ref pbDebuggerPresent) != 0 && pbDebuggerPresent != 0)
							{
								return true;
							}
						}
					}
					finally
					{
						CloseHandle(intPtr2);
					}
				}
				try
				{
					CloseHandle(new IntPtr(305419896));
				}
				catch (Exception)
				{
					return false;
				}
				try
				{
					Type typeFromHandle = typeof(Debugger);
					MethodInfo method = typeFromHandle.GetMethod("get_IsAttached");
					if (method != null)
					{
						IntPtr functionPointer = method.MethodHandle.GetFunctionPointer();
						byte[] array = new byte[1];
						Marshal.Copy(functionPointer, array, 0, 1);
						if (array[0] == 51)
						{
							return true;
						}
					}
				}
				catch
				{
				}
			}
			catch (Exception)
			{
				return false;
			}
			return false;
		}

		public static void Initialize()
		{
			try
			{
				if (Detected())
				{
					Terminator.Kill((uint)Process.GetCurrentProcess().Id);
				}
				if (Debugger.IsAttached || Debugger.IsLogging())
				{
					Terminator.Kill((uint)Process.GetCurrentProcess().Id);
				}
				string text = "COR";
				if (Environment.GetEnvironmentVariable(text + "_PROFILER") != null || Environment.GetEnvironmentVariable(text + "_ENABLE_PROFILING") != null)
				{
					Terminator.Kill((uint)Process.GetCurrentProcess().Id);
				}
				Process currentProcess = Process.GetCurrentProcess();
				if (currentProcess.Handle == IntPtr.Zero)
				{
					Terminator.Kill((uint)Process.GetCurrentProcess().Id);
					currentProcess.Close();
				}
				try
				{
					CloseHandle(IntPtr.Zero);
				}
				catch
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

		public static void Detector(object thread)
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
					if (Detected())
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
	}
}
