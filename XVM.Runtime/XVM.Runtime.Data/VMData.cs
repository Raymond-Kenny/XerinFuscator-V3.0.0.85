using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using XVM.Runtime.XVM.Runtime.Dynamic;
using XVM.Runtime.XVM.Runtime.RTProtection;

namespace XVM.Runtime.XVM.Runtime.Data
{
	internal class VMData
	{
		private static Dictionary<Module, VMData> ModuleVMData = new Dictionary<Module, VMData> { 
		{
			VMInstance.__ExecuteModule,
			new VMData()
		} };

		private Dictionary<uint, string> Strings;

		private Dictionary<uint, RefInfo> References;

		private Dictionary<MethodBase, VMExportInfo> Exports;

		public Constants Constants { get; private set; }

		public unsafe VMData()
		{
			Strings = new Dictionary<uint, string>();
			References = new Dictionary<uint, RefInfo>();
			Exports = new Dictionary<MethodBase, VMExportInfo>();
			uint[] array = new uint[Mutation.IntKey0];
			if (array.Length != 0 && AntiDump.AntiDumpIsRunning)
			{
				RuntimeHelpers.InitializeArray(array, Mutation.LocationIndex<RuntimeFieldHandle>());
				ulong num = (uint)Mutation.IntKey1;
				uint[] array2 = new uint[16];
				uint[] array3 = new uint[16];
				for (int i = 0; i < 16; i++)
				{
					num = num * num % 339722377;
					array3[i] = (uint)num;
					array2[i] = (uint)(num * num % 1145919227);
				}
				Mutation.Crypt(array2, array3);
				for (int j = 0; j < 16; j++)
				{
					num ^= num >> 13;
					num ^= num << 25;
					num ^= num >> 27;
					array3[j] = 0u;
					switch (j % 3)
					{
					case 0:
						array2[j] ^= (uint)(int)num;
						break;
					case 1:
						array2[j] *= (uint)(int)num;
						break;
					case 2:
						array2[j] += (uint)(int)num;
						break;
					}
				}
				byte[] array4 = new byte[array.Length << 2];
				uint num2 = 0u;
				for (int k = 0; k < array.Length; k++)
				{
					uint num3 = array[k] ^ array2[k & 0xF];
					array2[k & 0xF] = (array2[k & 0xF] ^ num3) + 1037772825;
					array4[num2] = (byte)num3;
					array4[num2 + 1] = (byte)(num3 >> 8);
					array4[num2 + 2] = (byte)(num3 >> 16);
					array4[num2 + 3] = (byte)(num3 >> 24);
					num2 += 4;
				}
				for (int l = 0; l < 16; l++)
				{
					array2[l] = 0u;
				}
				byte[] array5 = Lzma.Decompress(array4);
				for (int m = 0; m < array4.Length; m++)
				{
					array4[m] = 0;
				}
				for (int n = 0; n < array5.Length; n++)
				{
					array5[n] ^= (byte)num;
					if ((n & 0xFF) == 0)
					{
						num = num * num % 9067703;
					}
				}
				IntPtr data = Marshal.AllocHGlobal(array5.Length);
				Marshal.Copy(array5, 0, data, array5.Length);
				UnmanagedMemoryStream unmanagedMemoryStream = new UnmanagedMemoryStream((byte*)(void*)data, array5.Length);
				BinaryReader binaryReader = new BinaryReader(unmanagedMemoryStream);
				try
				{
					Constants = Utils.ReadConstants(binaryReader);
					for (int num4 = 0; num4 < Mutation.IntKey2; num4++)
					{
						uint key = binaryReader.ReadUInt32();
						int count = binaryReader.ReadInt32();
						byte[] bytes = binaryReader.ReadBytes(count);
						Strings.Add(key, Encoding.Unicode.GetString(bytes));
					}
					for (int num5 = 0; num5 < Mutation.IntKey3; num5++)
					{
						uint key2 = binaryReader.ReadUInt32();
						int token = binaryReader.ReadInt32();
						double encryptKey = binaryReader.ReadDouble();
						References.Add(key2, new RefInfo(token, encryptKey));
					}
					for (int num6 = 0; num6 < Mutation.IntKey4; num6++)
					{
						int metadataToken = binaryReader.ReadInt32();
						VMExportInfo value = VMExportInfo.FromReader(binaryReader, ref data);
						Exports.Add(VMInstance.__ExecuteModule.ResolveMethod(metadataToken), value);
					}
					return;
				}
				finally
				{
					unmanagedMemoryStream.Dispose();
					binaryReader.Close();
				}
			}
			Strings = new Dictionary<uint, string>();
			References = new Dictionary<uint, RefInfo>();
			Exports = new Dictionary<MethodBase, VMExportInfo>();
		}

		public static VMData GetVMData()
		{
			Dictionary<Module, VMData>.ValueCollection.Enumerator enumerator = ModuleVMData.Values.GetEnumerator();
			enumerator.MoveNext();
			return enumerator.Current;
		}

		public string LookupString(uint id)
		{
			if (id == 0)
			{
				return null;
			}
			return Strings[id];
		}

		public MemberInfo LookupReference(uint id)
		{
			return References[id].Member();
		}

		public VMExportInfo LookupExport(MethodBase methodBase)
		{
			return Exports[methodBase];
		}
	}
}
