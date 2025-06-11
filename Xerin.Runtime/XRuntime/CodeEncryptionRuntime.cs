using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace XRuntime
{
	public static class CodeEncryptionRuntime
	{
		[DllImport("kernel32.dll")]
		private static extern bool VirtualProtect(IntPtr lpAddress, uint dwSize, uint flNewProtect, out uint lpflOldProtect);

		private unsafe static void Initialize()
		{
			Module module = typeof(CodeEncryptionRuntime).Module;
			string fullyQualifiedName = module.FullyQualifiedName;
			bool flag = fullyQualifiedName.Length > 0 && fullyQualifiedName[0] == '<';
			byte* ptr = (byte*)(void*)Marshal.GetHINSTANCE(module);
			byte* ptr2 = ptr + (uint)((int*)ptr)[15];
			ushort num = ((ushort*)ptr2)[3];
			ushort num2 = ((ushort*)ptr2)[10];
			uint* ptr3 = null;
			uint num3 = 0u;
			uint* ptr4 = (uint*)(ptr2 + 24 + num2);
			uint num4 = (uint)XMutationClass.Key<int>(1);
			uint num5 = (uint)XMutationClass.Key<int>(2);
			uint num6 = (uint)XMutationClass.Key<int>(3);
			uint num7 = (uint)XMutationClass.Key<int>(4);
			for (int i = 0; i < num; i++)
			{
				uint num8 = *ptr4++ * *ptr4++;
				if (num8 == (uint)XMutationClass.Key<int>(0))
				{
					int millisecondsTimeout = new Random().Next(100, 1000);
					Thread.Sleep(millisecondsTimeout);
					ptr3 = (uint*)(ptr + (flag ? ptr4[3] : ptr4[1]));
					num3 = (flag ? ptr4[2] : *ptr4) >> 2;
				}
				else if (num8 != 0)
				{
					uint* ptr5 = (uint*)(ptr + (flag ? ptr4[3] : ptr4[1]));
					uint num9 = ptr4[2] >> 2;
					for (uint num10 = 0u; num10 < num9; num10++)
					{
						uint num11 = (num4 ^ *ptr5++) + num5 + num6 * num7;
						num4 = num5;
						num5 = num6;
						num5 = num7;
						num7 = num11;
					}
				}
				ptr4 += 8;
			}
			uint[] array = new uint[16];
			uint[] array2 = new uint[16];
			for (int j = 0; j < 16; j++)
			{
				array[j] = num7;
				array2[j] = num5;
				num4 = num5 >> 5 | num5 << 27;
				num5 = num6 >> 3 | num6 << 29;
				num6 = num7 >> 7 | num7 << 25;
				num7 = num4 >> 11 | num4 << 21;
			}
			XMutationClass.Crypt(array, array2);
			uint lpflOldProtect = 64u;
			VirtualProtect((IntPtr)ptr3, num3 << 2, lpflOldProtect, out lpflOldProtect);
			if (lpflOldProtect != 64)
			{
				uint num12 = 0u;
				for (uint num13 = 0u; num13 < num3; num13++)
				{
					*ptr3 ^= array[num12 & 0xF];
					array[num12 & 0xF] = (array[num12 & 0xF] ^ *ptr3++) + 1035675673;
					num12++;
				}
			}
		}
	}
}
