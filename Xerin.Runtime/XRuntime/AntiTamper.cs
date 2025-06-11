using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace XRuntime
{
	public static class AntiTamper
	{
		private static bool IsMethodInExternalAssembly(MethodBase method)
		{
			Assembly assembly = method.DeclaringType?.Assembly;
			Assembly entryAssembly = Assembly.GetEntryAssembly();
			if (assembly == null || entryAssembly == null)
			{
				return true;
			}
			return assembly != entryAssembly && assembly.FullName.StartsWith("System");
		}

		private static bool AnalyzeMethod(string typeName, string methodName)
		{
			MethodInfo methodInfo = Type.GetType(typeName)?.GetMethod(methodName);
			if (methodInfo == null)
			{
				return true;
			}
			if (IsMethodInExternalAssembly(methodInfo))
			{
				return false;
			}
			return DetectMethodModification(methodInfo);
		}

		private static bool CheckDynamicCalls(string typeName, string methodNameA, string methodNameB)
		{
			Type type = Type.GetType(typeName);
			if (type == null)
			{
				return true;
			}
			MethodInfo method = type.GetMethod(methodNameA);
			MethodInfo method2 = type.GetMethod(methodNameB);
			IntPtr intPtr = method?.MethodHandle.GetFunctionPointer() ?? IntPtr.Zero;
			IntPtr intPtr2 = method2?.MethodHandle.GetFunctionPointer() ?? IntPtr.Zero;
			return intPtr != intPtr2;
		}

		private unsafe static bool DetectMethodModification(MethodBase method)
		{
			try
			{
				IntPtr functionPointer = method.MethodHandle.GetFunctionPointer();
				byte* ptr = (byte*)functionPointer.ToPointer();
				byte b = *ptr;
				byte b2 = ptr[1];
				byte b3 = ptr[2];
				switch (b)
				{
				case 194:
				case 195:
				case 233:
				case 235:
					return true;
				case byte.MaxValue:
					if (b2 == 37)
					{
						return true;
					}
					break;
				case 144:
					if (b2 == 144)
					{
						return true;
					}
					break;
				}
				byte b4 = Marshal.ReadByte(functionPointer);
				return b != b4;
			}
			catch
			{
				return true;
			}
		}

		public static void Initialize()
		{
			if (!CheckDynamicCalls("System.Reflection.Assembly", "GetCallingAssembly", "GetExecutingAssembly"))
			{
				Terminator.Kill((uint)Process.GetCurrentProcess().Id);
			}
			else if (AnalyzeMethod("System.Reflection.Assembly", "GetCallingAssembly"))
			{
				Terminator.Kill((uint)Process.GetCurrentProcess().Id);
			}
			else if (AnalyzeMethod("System.Reflection.Assembly", "GetExecutingAssembly"))
			{
				Terminator.Kill((uint)Process.GetCurrentProcess().Id);
			}
		}
	}
}
