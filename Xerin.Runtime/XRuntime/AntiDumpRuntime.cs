using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace XRuntime
{
	public static class AntiDumpRuntime
	{
		[DllImport("kernel32.dll")]
		private unsafe static extern bool VirtualProtect(byte* lpAddress, int dwSize, uint flNewProtect, out uint lpflOldProtect);

		[DllImport("kernel32.dll")]
		public static extern IntPtr GetModuleHandle(string moduleName);

		private unsafe static void Initialize()
		{
			IntPtr moduleHandle = GetModuleHandle(null);
			if (moduleHandle == IntPtr.Zero)
			{
				Environment.FailFast(null);
			}
			Module module = typeof(AntiDumpRuntime).Module;
			byte* ptr = (byte*)(void*)Marshal.GetHINSTANCE(module);
			byte* ptr2 = ptr + 60;
			byte* ptr3;
			ptr2 = ptr3 = ptr + (uint)*(int*)ptr2;
			ptr2 += 6;
			ushort num = *(ushort*)ptr2;
			ptr2 += 14;
			ushort num2 = *(ushort*)ptr2;
			ptr2 = ptr3 = ptr2 + 4 + num2;
			byte* ptr4 = stackalloc byte[11];
			uint lpflOldProtect;
			if (module.FullyQualifiedName[0] != '<')
			{
				byte* ptr5 = ptr + (uint)*((int*)ptr2 - 4);
				if (*((uint*)ptr2 - 30) != 0)
				{
					byte* ptr6 = ptr + (uint)*((int*)ptr2 - 30);
					byte* ptr7 = ptr + (uint)*(int*)ptr6;
					byte* ptr8 = ptr + (uint)((int*)ptr6)[3];
					byte* ptr9 = ptr + (uint)*(int*)ptr7 + 2;
					VirtualProtect(ptr8, 11, 64u, out lpflOldProtect);
					*(int*)ptr4 = 1818522734;
					((int*)ptr4)[1] = 1818504812;
					((short*)ptr4)[4] = 108;
					ptr4[10] = 0;
					for (int i = 0; i < 11; i++)
					{
						ptr8[i] = ptr4[i];
					}
					VirtualProtect(ptr9, 11, 64u, out lpflOldProtect);
					*(int*)ptr4 = 1866691662;
					((int*)ptr4)[1] = 1852404846;
					((short*)ptr4)[4] = 25973;
					ptr4[10] = 0;
					for (int j = 0; j < 11; j++)
					{
						ptr9[j] = ptr4[j];
					}
				}
				for (int k = 0; k < num; k++)
				{
					VirtualProtect(ptr2, 8, 64u, out lpflOldProtect);
					Marshal.Copy(new byte[8], 0, (IntPtr)ptr2, 8);
					ptr2 += 40;
				}
				VirtualProtect(ptr5, 72, 64u, out lpflOldProtect);
				byte* ptr10 = ptr + (uint)((int*)ptr5)[2];
				*(int*)ptr5 = 0;
				((int*)ptr5)[1] = 0;
				((int*)ptr5)[2] = 0;
				((int*)ptr5)[3] = 0;
				VirtualProtect(ptr10, 4, 64u, out lpflOldProtect);
				*(int*)ptr10 = 0;
				ptr10 += 12;
				ptr10 += (uint)*(int*)ptr10;
				ptr10 = (byte*)((long)ptr10 + 7L & -4);
				ptr10 += 2;
				ushort num3 = *ptr10;
				ptr10 += 2;
				for (int l = 0; l < num3; l++)
				{
					VirtualProtect(ptr10, 8, 64u, out lpflOldProtect);
					ptr10 += 4;
					ptr10 += 4;
					for (int m = 0; m < 8; m++)
					{
						VirtualProtect(ptr10, 4, 64u, out lpflOldProtect);
						*ptr10 = 0;
						ptr10++;
						if (*ptr10 == 0)
						{
							ptr10 += 3;
							break;
						}
						*ptr10 = 0;
						ptr10++;
						if (*ptr10 == 0)
						{
							ptr10 += 2;
							break;
						}
						*ptr10 = 0;
						ptr10++;
						if (*ptr10 == 0)
						{
							ptr10++;
							break;
						}
						*ptr10 = 0;
						ptr10++;
					}
				}
				return;
			}
			uint num4 = *((uint*)ptr2 - 4);
			uint num5 = *((uint*)ptr2 - 30);
			uint[] array = new uint[num];
			uint[] array2 = new uint[num];
			uint[] array3 = new uint[num];
			for (int n = 0; n < num; n++)
			{
				VirtualProtect(ptr2, 8, 64u, out lpflOldProtect);
				Marshal.Copy(new byte[8], 0, (IntPtr)ptr2, 8);
				array[n] = ((uint*)ptr2)[3];
				array2[n] = ((uint*)ptr2)[2];
				array3[n] = ((uint*)ptr2)[5];
				ptr2 += 40;
			}
			if (num5 != 0)
			{
				for (int num6 = 0; num6 < num; num6++)
				{
					if (array[num6] <= num5 && num5 < array[num6] + array2[num6])
					{
						num5 = num5 - array[num6] + array3[num6];
						break;
					}
				}
				byte* ptr11 = ptr + num5;
				uint num7 = *(uint*)ptr11;
				for (int num8 = 0; num8 < num; num8++)
				{
					if (array[num8] <= num7 && num7 < array[num8] + array2[num8])
					{
						num7 = num7 - array[num8] + array3[num8];
						break;
					}
				}
				byte* ptr12 = ptr + num7;
				uint num9 = ((uint*)ptr11)[3];
				for (int num10 = 0; num10 < num; num10++)
				{
					if (array[num10] <= num9 && num9 < array[num10] + array2[num10])
					{
						num9 = num9 - array[num10] + array3[num10];
						break;
					}
				}
				uint num11 = *(uint*)ptr12 + 2;
				for (int num12 = 0; num12 < num; num12++)
				{
					if (array[num12] <= num11 && num11 < array[num12] + array2[num12])
					{
						num11 = num11 - array[num12] + array3[num12];
						break;
					}
				}
				VirtualProtect(ptr + num9, 11, 64u, out lpflOldProtect);
				*(int*)ptr4 = 1818522734;
				((int*)ptr4)[1] = 1818504812;
				((short*)ptr4)[4] = 108;
				ptr4[10] = 0;
				for (int num13 = 0; num13 < 11; num13++)
				{
					(ptr + num9)[num13] = ptr4[num13];
				}
				VirtualProtect(ptr + num11, 11, 64u, out lpflOldProtect);
				*(int*)ptr4 = 1866691662;
				((int*)ptr4)[1] = 1852404846;
				((short*)ptr4)[4] = 25973;
				ptr4[10] = 0;
				for (int num14 = 0; num14 < 11; num14++)
				{
					(ptr + num11)[num14] = ptr4[num14];
				}
			}
			for (int num15 = 0; num15 < num; num15++)
			{
				if (array[num15] <= num4 && num4 < array[num15] + array2[num15])
				{
					num4 = num4 - array[num15] + array3[num15];
					break;
				}
			}
			byte* ptr13 = ptr + num4;
			VirtualProtect(ptr13, 72, 64u, out lpflOldProtect);
			uint num16 = ((uint*)ptr13)[2];
			for (int num17 = 0; num17 < num; num17++)
			{
				if (array[num17] <= num16 && num16 < array[num17] + array2[num17])
				{
					num16 = num16 - array[num17] + array3[num17];
					break;
				}
			}
			*(int*)ptr13 = 0;
			((int*)ptr13)[1] = 0;
			((int*)ptr13)[2] = 0;
			((int*)ptr13)[3] = 0;
			byte* ptr14 = ptr + num16;
			VirtualProtect(ptr14, 4, 64u, out lpflOldProtect);
			*(int*)ptr14 = 0;
			ptr14 += 12;
			ptr14 += (uint)*(int*)ptr14;
			ptr14 = (byte*)((long)ptr14 + 7L & -4);
			ptr14 += 2;
			ushort num18 = *ptr14;
			ptr14 += 2;
			for (int num19 = 0; num19 < num18; num19++)
			{
				VirtualProtect(ptr14, 8, 64u, out lpflOldProtect);
				ptr14 += 4;
				ptr14 += 4;
				for (int num20 = 0; num20 < 8; num20++)
				{
					VirtualProtect(ptr14, 4, 64u, out lpflOldProtect);
					*ptr14 = 0;
					ptr14++;
					if (*ptr14 == 0)
					{
						ptr14 += 3;
						break;
					}
					*ptr14 = 0;
					ptr14++;
					if (*ptr14 == 0)
					{
						ptr14 += 2;
						break;
					}
					*ptr14 = 0;
					ptr14++;
					if (*ptr14 == 0)
					{
						ptr14++;
						break;
					}
					*ptr14 = 0;
					ptr14++;
				}
			}
		}
	}
}
