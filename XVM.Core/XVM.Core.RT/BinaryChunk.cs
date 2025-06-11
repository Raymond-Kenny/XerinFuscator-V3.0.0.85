using System;
using System.Runtime.CompilerServices;

namespace XVM.Core.RT
{
	public class BinaryChunk : IChunk
	{
		[CompilerGenerated]
		private byte[] lNO;

		[CompilerGenerated]
		private uint KNt;

		public EventHandler<OffsetComputeEventArgs> OffsetComputed;

		public byte[] Data
		{
			[CompilerGenerated]
			get
			{
				return lNO;
			}
			[CompilerGenerated]
			private set
			{
				lNO = value;
			}
		}

		public uint Offset
		{
			[CompilerGenerated]
			get
			{
				return KNt;
			}
			[CompilerGenerated]
			private set
			{
				KNt = value;
			}
		}

		uint IChunk.Length => (uint)Data.Length;

		public BinaryChunk(byte[] byte_0)
		{
			Data = byte_0;
		}

		void IChunk.OnOffsetComputed(uint uint_0)
		{
			if (OffsetComputed != null)
			{
				OffsetComputed(this, new OffsetComputeEventArgs(uint_0));
			}
			Offset = uint_0;
		}

		byte[] IChunk.GetData()
		{
			return Data;
		}
	}
}
