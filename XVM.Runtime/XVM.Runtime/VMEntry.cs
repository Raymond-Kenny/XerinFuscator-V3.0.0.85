using System;
using System.Diagnostics;
using XVM.Runtime.XVM.Runtime.JIT;
using XVM.Runtime.XVM.Runtime.RTProtection;

namespace XVM.Runtime.XVM.Runtime
{
	public class VMEntry
	{
		public static void EntryInitialize(Version ver)
		{
			AntiDump.Initialize();
			if (AntiDump.AntiDumpIsRunning)
			{
				Constant.Initialize();
				if ((object)VMInstance.__ExecuteModule == null)
				{
					VMInstance.__ExecuteModule = new StackFrame(1, false).GetMethod().Module;
				}
				if (VMInstance.STATIC_Instance == null)
				{
					VMInstance.STATIC_Instance = new VMInstance();
				}
				JITRuntime.Initialize(ver);
				return;
			}
			throw new BadImageFormatException("Anti Dump not running!");
		}
	}
}
