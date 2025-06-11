#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using XVM.Runtime.XVM.Runtime.Data;
using XVM.Runtime.XVM.Runtime.Execution;
using XVM.Runtime.XVM.Runtime.RTProtection;

namespace XVM.Runtime.XVM.Runtime
{
	internal class VMInstance
	{
		public static Module __ExecuteModule;

		public static VMInstance STATIC_Instance;

		public VMData Data => VMData.GetVMData();

		[MethodImpl(MethodImplOptions.NoInlining)]
		public object Invoke(object[] arguments, RuntimeMethodHandle handle)
		{
			if (AntiDump.AntiDumpIsRunning)
			{
				MethodBase methodFromHandle = MethodBase.GetMethodFromHandle(handle);
				VMExportInfo vMExportInfo = Data.LookupExport(methodFromHandle);
				return Invoke((ulong)(long)vMExportInfo.CodeAddress, vMExportInfo.EntryKey, vMExportInfo.Signature, arguments);
			}
			throw new BadImageFormatException("Anti Dump not running!");
		}

		private unsafe object Invoke(ulong codeAddr, uint key, VMFuncSig sig, object[] arguments)
		{
			Stack<VMContext> stack = new Stack<VMContext>();
			VMContext vMContext = new VMContext(this);
			if (arguments == null)
			{
				arguments = new object[0];
			}
			if (vMContext != null)
			{
				stack.Push(vMContext);
			}
			try
			{
				Debug.Assert(sig.ParamTypes.Length == arguments.Length);
				vMContext.Stack.SetTopPosition((uint)(arguments.Length + 1));
				for (uint num = 0u; num < arguments.Length; num++)
				{
					Type type = sig.ParamTypes[num];
					if (AntiDump.AntiDumpIsRunning)
					{
						if (type.IsByRef)
						{
							vMContext.Stack[num + 1] = new VMSlot
							{
								O = arguments[num]
							};
						}
						else if (type.IsPointer)
						{
							vMContext.Stack[num + 1] = new VMSlot
							{
								U8 = (ulong)Pointer.Unbox(arguments[num])
							};
						}
						else
						{
							vMContext.Stack[num + 1] = VMSlot.FromObject(arguments[num], sig.ParamTypes[num]);
						}
					}
				}
				vMContext.Stack[(uint)(arguments.Length + 1)] = new VMSlot
				{
					U8 = 1uL
				};
				vMContext.Registers[vMContext.Data.Constants.REG_K1] = new VMSlot
				{
					U8 = key
				};
				vMContext.Registers[vMContext.Data.Constants.REG_BP] = new VMSlot
				{
					U8 = 0uL
				};
				vMContext.Registers[vMContext.Data.Constants.REG_SP] = new VMSlot
				{
					U8 = (ulong)arguments.Length + 1uL
				};
				vMContext.Registers[vMContext.Data.Constants.REG_IP] = new VMSlot
				{
					U8 = codeAddr
				};
				VMDispatcher.Invoke(vMContext);
				Debug.Assert(vMContext.EHStack.Count == 0);
				object result = null;
				if ((object)sig.RetType != typeof(void))
				{
					VMSlot vMSlot = vMContext.Registers[vMContext.Data.Constants.REG_R0];
					result = Type.GetTypeCode(sig.RetType) != TypeCode.String || vMSlot.O != null ? vMSlot.ToObject(sig.RetType) : Data.LookupString(vMSlot.U4);
				}
				return result;
			}
			finally
			{
				vMContext.Stack.FreeAllLocalloc();
				if (stack.Count > 0)
				{
					vMContext = stack.Pop();
				}
			}
		}
	}
}
