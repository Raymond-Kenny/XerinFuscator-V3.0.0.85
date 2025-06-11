using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using XVM.Runtime.XVM.Runtime.RTProtection;

namespace XVM.Runtime.XVM.Runtime.JIT
{
	internal static class JITRuntime
	{
		private static IntPtr EXECModuleHandle;

		private static bool ver4
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get;
			[MethodImpl(MethodImplOptions.NoInlining)]
			set;
		}

		private static bool FirstRunDone
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get;
			[MethodImpl(MethodImplOptions.NoInlining)]
			set;
		}

		private static Dictionary<IntPtr, JITEDMethodInfo> EncryptedHandles
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get;
			[MethodImpl(MethodImplOptions.NoInlining)]
			set;
		}

		private static NativeMethods.CompileMethodDelegate OriginalCompileMethod
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get;
			[MethodImpl(MethodImplOptions.NoInlining)]
			set;
		}

		private static NativeMethods.CompileMethodDelegate CustomCompileMethod
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get;
			[MethodImpl(MethodImplOptions.NoInlining)]
			set;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public unsafe static void Initialize(Version ver)
		{
			if (!AntiDump.AntiDumpIsRunning)
			{
				return;
			}
			ver4 = ver.Major == 4;
			FirstRunDone = false;
			ulong* ptr = stackalloc ulong[2];
			if (ver4)
			{
				*ptr = 7218835248827755619uL;
				ptr[1] = 27756uL;
			}
			else
			{
				*ptr = 8388352820681864045uL;
				ptr[1] = 1819042862uL;
			}
			IntPtr intPtr = NativeMethods.LoadLibrary(new string((sbyte*)ptr));
			*ptr = 127995569530215uL;
			IntPtr procAddress = NativeMethods.GetProcAddress(intPtr, new string((sbyte*)ptr));
			NativeMethods.getJit getJit = (NativeMethods.getJit)Utils.GetDelegateForFunctionPointer(procAddress, typeof(NativeMethods.getJit));
			IntPtr intPtr2 = *getJit();
			IntPtr val = *(IntPtr*)(void*)intPtr2;
			IntPtr zero = IntPtr.Zero;
			uint lpflOldProtect;
			if (IntPtr.Size == 8)
			{
				zero = Marshal.AllocHGlobal(16);
				*(long*)(void*)zero = -18360L;
				((long*)(void*)zero)[1] = -8029759183677030401L;
				NativeMethods.VirtualProtect(zero, 12u, 64u, out lpflOldProtect);
				Marshal.WriteIntPtr(zero, 2, val);
			}
			else
			{
				zero = Marshal.AllocHGlobal(8);
				*(long*)(void*)zero = -8007118662488031304L;
				NativeMethods.VirtualProtect(zero, 7u, 64u, out lpflOldProtect);
				Marshal.WriteIntPtr(zero, 1, val);
			}
			OriginalCompileMethod = (NativeMethods.CompileMethodDelegate)Utils.GetDelegateForFunctionPointer(zero, typeof(NativeMethods.CompileMethodDelegate));
			if (ver4)
			{
				*ptr = 27431033849798509uL;
				ptr[1] = 7uL;
			}
			else
			{
				*ptr = 7022344665548414829uL;
				ptr[1] = 8uL;
			}
			EXECModuleHandle = (IntPtr)VMInstance.__ExecuteModule.GetType().GetField(new string((sbyte*)ptr, 0, (int)ptr[1]), BindingFlags.Instance | BindingFlags.NonPublic).GetValue(VMInstance.__ExecuteModule);
			CustomCompileMethod = HookCompileMethod;
			RuntimeHelpers.PrepareDelegate(CustomCompileMethod);
			RuntimeHelpers.PrepareDelegate(OriginalCompileMethod);
			RuntimeHelpers.PrepareMethod(CustomCompileMethod.Method.MethodHandle);
			RuntimeHelpers.PrepareMethod(OriginalCompileMethod.Method.MethodHandle);
			uint[] array = new uint[Mutation.IntKey0];
			EncryptedHandles = new Dictionary<IntPtr, JITEDMethodInfo>();
			if (array.Length != 0)
			{
				RuntimeHelpers.InitializeArray(array, Mutation.LocationIndex<RuntimeFieldHandle>());
				uint num = (uint)Mutation.IntKey1;
				uint[] array2 = new uint[16];
				uint[] array3 = new uint[16];
				for (int i = 0; i < 16; i++)
				{
					num ^= num >> 13;
					num ^= num << 25;
					num = array3[i] = num ^ num >> 27;
				}
				byte[] array4 = new byte[array.Length * 4];
				int j = 0;
				int num2 = 0;
				for (; j < array.Length; j += 16)
				{
					for (int k = 0; k < 16; k++)
					{
						array2[k] = array[j + k];
					}
					Mutation.Crypt(array2, array3);
					for (int l = 0; l < 16; l++)
					{
						uint num3 = array2[l];
						array4[num2++] = (byte)num3;
						array4[num2++] = (byte)(num3 >> 8);
						array4[num2++] = (byte)(num3 >> 16);
						array4[num2++] = (byte)(num3 >> 24);
						array3[l] ^= num3;
					}
				}
				array4 = Lzma.Decompress(array4);
				BinaryReader binaryReader = new BinaryReader(new MemoryStream(array4));
				int num4 = binaryReader.ReadInt32();
				for (int m = 0; m < num4; m++)
				{
					JITEDMethodInfo jITEDMethodInfo = new JITEDMethodInfo();
					jITEDMethodInfo.MethodToken = binaryReader.ReadInt32();
					jITEDMethodInfo.MaxStack = binaryReader.ReadUInt32();
					jITEDMethodInfo.ILCodeSize = binaryReader.ReadUInt32();
					jITEDMethodInfo.ILCode = binaryReader.ReadBytes((int)jITEDMethodInfo.ILCodeSize);
					MethodBase methodBase = VMInstance.__ExecuteModule.ResolveMethod(jITEDMethodInfo.MethodToken);
					EncryptedHandles.Add(methodBase.MethodHandle.Value, jITEDMethodInfo);
				}
			}
			uint lpflOldProtect2;
			NativeMethods.VirtualProtect(procAddress, (uint)IntPtr.Size, 64u, out lpflOldProtect2);
			NativeMethods.ZeroMemory(procAddress, IntPtr.Zero);
			NativeMethods.CryptProtectMemory(procAddress, (uint)IntPtr.Size);
			NativeMethods.VirtualProtect(procAddress, (uint)IntPtr.Size, lpflOldProtect2, out lpflOldProtect2);
			uint lpflOldProtect3;
			NativeMethods.VirtualProtect(intPtr, (uint)IntPtr.Size, 64u, out lpflOldProtect3);
			NativeMethods.ZeroMemory(intPtr, IntPtr.Zero);
			NativeMethods.CryptProtectMemory(intPtr, (uint)IntPtr.Size);
			NativeMethods.VirtualProtect(intPtr, (uint)IntPtr.Size, lpflOldProtect3, out lpflOldProtect3);
			uint lpflOldProtect4;
			NativeMethods.VirtualProtect(intPtr2, (uint)IntPtr.Size, 64u, out lpflOldProtect4);
			Marshal.WriteIntPtr(intPtr2, Marshal.GetFunctionPointerForDelegate((Delegate)CustomCompileMethod));
			NativeMethods.VirtualProtect(intPtr2, (uint)IntPtr.Size, lpflOldProtect4, out lpflOldProtect4);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private unsafe static int HookCompileMethod(IntPtr thisPtr, IntPtr corJitInfo, NativeMethods.CORINFO_METHOD_INFO* methodInfo, [MarshalAs(UnmanagedType.U4)] NativeMethods.CorJitFlag flags, IntPtr nativeEntry, IntPtr nativeSizeOfCode)
		{
			bool flag = false;
			if (methodInfo->ModuleHandle != EXECModuleHandle)
			{
				return OriginalCompileMethod(thisPtr, corJitInfo, methodInfo, flags, nativeEntry, nativeSizeOfCode);
			}
			if (!EncryptedHandles.ContainsKey(methodInfo->MethodHandle))
			{
				return OriginalCompileMethod(thisPtr, corJitInfo, methodInfo, flags, nativeEntry, nativeSizeOfCode);
			}
			NativeMethods.CORINFO_METHOD_INFO methodInfo2 = *methodInfo;
			JITHooker(ref methodInfo2);
			uint lpflOldProtect;
			NativeMethods.VirtualProtect((IntPtr)methodInfo, 136u, 64u, out lpflOldProtect);
			NativeMethods.memcpy((IntPtr)methodInfo, (IntPtr)(&methodInfo2), 136);
			NativeMethods.VirtualProtect((IntPtr)methodInfo, 136u, lpflOldProtect, out lpflOldProtect);
			int result = 0;
			if (flags == NativeMethods.CorJitFlag.CORJIT_UNKNOWN && !FirstRunDone)
			{
				FirstRunDone = true;
			}
			else
			{
				flags |= NativeMethods.CorJitFlag.CORJIT_FLAG_IMPORT_ONLY;
				result = OriginalCompileMethod(thisPtr, corJitInfo, methodInfo, flags, nativeEntry, nativeSizeOfCode);
				methodInfo2 = new NativeMethods.CORINFO_METHOD_INFO
				{
					ModuleHandle = IntPtr.Zero,
					MethodHandle = IntPtr.Zero,
					ILCode = IntPtr.Zero,
					ILCodeSize = 0u,
					MaxStack = 0u
				};
				methodInfo = &methodInfo2;
			}
			return result;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void JITHooker(ref NativeMethods.CORINFO_METHOD_INFO methodInfo)
		{
			if (AntiDump.AntiDumpIsRunning)
			{
				JITEDMethodInfo jITEDMethodInfo = EncryptedHandles[methodInfo.MethodHandle];
				IntPtr intPtr = Marshal.AllocHGlobal(jITEDMethodInfo.ILCode.Length);
				Marshal.Copy(jITEDMethodInfo.ILCode, 0, intPtr, jITEDMethodInfo.ILCode.Length);
				methodInfo.ILCode = intPtr;
				methodInfo.ILCodeSize = jITEDMethodInfo.ILCodeSize;
				methodInfo.MaxStack = jITEDMethodInfo.MaxStack;
			}
		}
	}
}
