#define DEBUG
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.IL;
using XVM.Core.RT;
using XVM.Core.VM;
using XVM.Core.VMIL;

namespace XF
{
	internal class IEJ : IChunk
	{
		private VMRuntime KNG;

		private MethodDef MNI;

		[CompilerGenerated]
		private ILBlock WNq;

		[CompilerGenerated]
		private uint qNM;

		public uint Length
		{
			[CompilerGenerated]
			get
			{
				return qNM;
			}
			[CompilerGenerated]
			set
			{
				qNM = value;
			}
		}

		public IEJ(VMRuntime vmruntime_0, MethodDef methodDef_0, ILBlock ilblock_0)
		{
			KNG = vmruntime_0;
			MNI = methodDef_0;
			ENe(ilblock_0);
			Length = vmruntime_0.W2O().DNR(ilblock_0);
		}

		[SpecialName]
		[CompilerGenerated]
		public ILBlock vN4()
		{
			return WNq;
		}

		[SpecialName]
		[CompilerGenerated]
		public void ENe(ILBlock ilblock_0)
		{
			WNq = ilblock_0;
		}

		public void OnOffsetComputed(uint uint_0)
		{
			uint num = KNG.W2O().mNw(vN4(), uint_0);
			Debug.Assert(num - uint_0 == Length);
		}

		public byte[] GetData()
		{
			MemoryStream memoryStream = new MemoryStream();
			KNG.W2O().oNN(vN4(), new BinaryWriter(memoryStream));
			return jE8(memoryStream.ToArray());
		}

		private byte[] jE8(byte[] byte_0)
		{
			VMBlockKey vMBlockKey = KNG.Descriptor.Data.LookupInfo(MNI).BlockKeys[vN4()];
			byte b = vMBlockKey.EntryKey;
			ILInstruction iLInstruction = vN4().Content[0];
			ILInstruction iLInstruction2 = vN4().Content[vN4().Content.Count - 1];
			foreach (ILInstruction item in vN4().Content)
			{
				uint num = item.Offset - iLInstruction.Offset;
				uint num2 = num + KNG.W2O().yN0(item);
				byte b2 = byte_0[num];
				byte_0[num] ^= b;
				b = (byte)(b * 7 + b2);
				byte? b3 = null;
				if (item.Annotation != InstrAnnotation.JUMP && item != iLInstruction2)
				{
					if (item.OpCode != ILOpCode.LEAVE)
					{
						if (item.OpCode == ILOpCode.CALL)
						{
							InstrCallInfo instrCallInfo = (InstrCallInfo)item.Annotation;
							VMMethodInfo vMMethodInfo = KNG.Descriptor.Data.LookupInfo((MethodDef)instrCallInfo.Method);
							b3 = vMMethodInfo.EntryKey;
						}
					}
					else
					{
						ExceptionHandler exceptionHandler = ((EHInfo)item.Annotation).ExceptionHandler;
						if (exceptionHandler.HandlerType == ExceptionHandlerType.Finally)
						{
							b3 = vMBlockKey.ExitKey;
						}
					}
				}
				else
				{
					b3 = vMBlockKey.ExitKey;
				}
				if (b3.HasValue)
				{
					byte b4 = vEz(b3.Value, byte_0, b, num + 1, num2);
					byte_0[num + 1] = b4;
				}
				for (uint num3 = num + 1; num3 < num2; num3++)
				{
					byte b5 = byte_0[num3];
					byte_0[num3] ^= b;
					b = (byte)(b * 7 + b5);
				}
				if (b3.HasValue)
				{
					Debug.Assert(b == b3.Value);
				}
				if (item.OpCode == ILOpCode.CALL)
				{
					InstrCallInfo instrCallInfo2 = (InstrCallInfo)item.Annotation;
					VMMethodInfo vMMethodInfo2 = KNG.Descriptor.Data.LookupInfo((MethodDef)instrCallInfo2.Method);
					b = vMMethodInfo2.ExitKey;
				}
			}
			return byte_0;
		}

		private static byte vEz(byte byte_0, object object_0, uint uint_0, uint uint_1, uint uint_2)
		{
			byte b = byte_0;
			for (uint num = uint_2 - 1; num > uint_1; num--)
			{
				b = (byte)((b - ((byte[])object_0)[num]) * 183);
			}
			return (byte)(b - (byte)(uint_0 * 7));
		}
	}
}
