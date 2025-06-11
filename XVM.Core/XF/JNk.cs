#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.MD;
using XVM.Core;
using XVM.Core.AST.IL;
using XVM.Core.RT;
using XVM.Core.Services;

namespace XF
{
	internal class JNk : IChunk
	{
		private VMRuntime HNo;

		private byte[] JNl;

		[CompilerGenerated]
		private uint tNZ;

		public uint Length
		{
			[CompilerGenerated]
			get
			{
				return tNZ;
			}
			[CompilerGenerated]
			set
			{
				tNZ = value;
			}
		}

		public JNk(VMRuntime vmruntime_0)
		{
			HNo = vmruntime_0;
			Length = PNC(vmruntime_0);
		}

		public void OnOffsetComputed(uint uint_0)
		{
		}

		public byte[] GetData()
		{
			return JNl;
		}

		private int uNH(MDToken mdtoken_0)
		{
			switch (mdtoken_0.Table)
			{
			case Table.MemberRef:
				return (int)(mdtoken_0.Rid | 0xA000000);
			case Table.TypeRef:
				return (int)(mdtoken_0.Rid | 0x1000000);
			case Table.TypeDef:
				return (int)(mdtoken_0.Rid | 0x2000000);
			case Table.Field:
				return (int)(mdtoken_0.Rid | 0x4000000);
			case Table.Method:
				return (int)(mdtoken_0.Rid | 0x6000000);
			default:
				throw new NotSupportedException();
			case Table.MethodSpec:
				return (int)(mdtoken_0.Rid | 0x2B000000);
			case Table.TypeSpec:
				return (int)(mdtoken_0.Rid | 0x1B000000);
			}
		}

		private uint PNC(VMRuntime vmruntime_0)
		{
			uint num = (uint)vmruntime_0.Descriptor.Data.xIi.Length;
			foreach (KeyValuePair<byte[], uint> item in vmruntime_0.Descriptor.Data.NIz)
			{
				num += (uint)(item.Key.Length + 8);
			}
			foreach (KeyValuePair<IMemberRef, uint> item2 in vmruntime_0.Descriptor.Data.EIJ)
			{
				_ = item2;
				num += 16;
			}
			foreach (wqe item3 in vmruntime_0.Descriptor.Data.QI8)
			{
				ITypeDefOrRef[] paramSigs = item3.Gqq.ParamSigs;
				for (int i = 0; i < paramSigs.Length; i++)
				{
					num += 12;
				}
				num = ((item3.uq9 != null) ? (num + 28) : (num + 24));
			}
			return num;
		}

		internal void xNm(VMRuntime vmruntime_0)
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			byte[] xIi = vmruntime_0.Descriptor.Data.xIi;
			foreach (byte value in xIi)
			{
				binaryWriter.Write(value);
			}
			foreach (KeyValuePair<byte[], uint> item2 in vmruntime_0.Descriptor.Data.NIz)
			{
				binaryWriter.Write(item2.Value);
				binaryWriter.Write(item2.Key.Length);
				binaryWriter.Write(item2.Key);
			}
			foreach (KeyValuePair<IMemberRef, uint> item3 in vmruntime_0.Descriptor.Data.EIJ)
			{
				double num = new RandomGenerator().NextDouble() / (double)new RandomGenerator().method_0();
				binaryWriter.Write(item3.Value);
				binaryWriter.Write(uNH(item3.Key.MDToken).EncryptInt(num));
				binaryWriter.Write(num);
			}
			foreach (wqe item4 in vmruntime_0.Descriptor.Data.QI8)
			{
				double num2 = new RandomGenerator().NextDouble() / (double)new RandomGenerator().method_0();
				binaryWriter.Write(item4.hqu);
				if (item4.uq9 != null)
				{
					ILBlock item = vmruntime_0.z2P[item4.uq9].Item2;
					uint offset = item.Content[0].Offset;
					Debug.Assert(offset != 0);
					binaryWriter.Write(offset);
					uint num3 = vmruntime_0.Descriptor.iqK().method_3();
					num3 = (num3 << 8) | vmruntime_0.Descriptor.Data.LookupInfo(item4.uq9).EntryKey;
					binaryWriter.Write(num3);
				}
				else
				{
					binaryWriter.Write(0u);
				}
				binaryWriter.Write(item4.Gqq.ParamSigs.Length);
				ITypeDefOrRef[] paramSigs = item4.Gqq.ParamSigs;
				foreach (ITypeDefOrRef typeDefOrRef in paramSigs)
				{
					double num4 = new RandomGenerator().NextDouble() / (double)new RandomGenerator().method_0();
					binaryWriter.Write(uNH(typeDefOrRef.MDToken).EncryptInt(num4));
					binaryWriter.Write(num4);
				}
				binaryWriter.Write(uNH(item4.Gqq.RetType.MDToken).EncryptInt(num2));
				binaryWriter.Write(num2);
			}
			JNl = memoryStream.ToArray();
			Debug.Assert(JNl.Length == Length);
		}
	}
}
