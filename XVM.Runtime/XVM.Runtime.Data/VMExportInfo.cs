using System;
using System.IO;

namespace XVM.Runtime.XVM.Runtime.Data
{
	internal class VMExportInfo
	{
		public uint CodeOffset { get; private set; }

		public uint EntryKey { get; private set; }

		public IntPtr CodeAddress { get; private set; }

		public VMFuncSig Signature { get; private set; }

		public unsafe static VMExportInfo FromReader(BinaryReader reader, ref IntPtr data)
		{
			uint num = reader.ReadUInt32();
			uint entryKey = num != 0 ? reader.ReadUInt32() : 0u;
			return new VMExportInfo
			{
				CodeOffset = num,
				EntryKey = entryKey,
				CodeAddress = (IntPtr)((byte*)(void*)data + num),
				Signature = new VMFuncSig(reader)
			};
		}
	}
}
