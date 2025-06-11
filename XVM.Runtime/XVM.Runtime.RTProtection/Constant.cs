using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace XVM.Runtime.XVM.Runtime.RTProtection
{
	internal static class Constant
	{
		private static byte[] Data;

		public static void Initialize()
		{
			uint intKey = (uint)Mutation.IntKey0;
			if (intKey == 0)
			{
				return;
			}
			uint[] array = new uint[intKey];
			RuntimeHelpers.InitializeArray(array, Mutation.LocationIndex<RuntimeFieldHandle>());
			uint num = (uint)Mutation.IntKey1;
			uint[] array2 = new uint[16];
			for (int i = 0; i < 16; i++)
			{
				num ^= num >> 12;
				num ^= num << 25;
				num = array2[i] = num ^ num >> 27;
			}
			int j = 0;
			int num2 = 0;
			uint[] array3 = new uint[16];
			byte[] array4 = new byte[intKey * 4];
			for (; j < intKey; j += 16)
			{
				for (int k = 0; k < 16; k++)
				{
					array3[k] = array[j + k];
				}
				Mutation.Crypt(array3, array2);
				for (int l = 0; l < 16; l++)
				{
					uint num3 = array3[l];
					array4[num2++] = (byte)num3;
					array4[num2++] = (byte)(num3 >> 8);
					array4[num2++] = (byte)(num3 >> 16);
					array4[num2++] = (byte)(num3 >> 24);
					array2[l] ^= num3;
				}
			}
			Data = Lzma.Decompress(array4);
		}

		public static string Get(int id, int index, RuntimeMethodHandle handle)
		{
			MethodBase methodFromHandle = MethodBase.GetMethodFromHandle(handle);
			byte[] iLAsByteArray = methodFromHandle.GetMethodBody().GetILAsByteArray();
			int num = iLAsByteArray[index] | iLAsByteArray[index + 1] << 8 | iLAsByteArray[index + 2] << 16 | iLAsByteArray[index + 3] << 24;
			id ^= num;
			id = Mutation.Placeholder(id);
			id = (id & 0x3FFFFFFF) << 2;
			int count = Data[id] | Data[id + 1] << 8 | Data[id + 2] << 16 | Data[id + 3] << 24;
			return string.Intern(Encoding.UTF8.GetString(Data, id + 4, count));
		}
	}
}
