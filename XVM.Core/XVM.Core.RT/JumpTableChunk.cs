using System;
using System.Runtime.CompilerServices;
using XVM.Core.AST.IL;

namespace XVM.Core.RT
{
	public class JumpTableChunk : IChunk
	{
		internal VMRuntime kNP;

		[CompilerGenerated]
		private ILJumpTable rNF;

		[CompilerGenerated]
		private uint hNv;

		public ILJumpTable Table
		{
			[CompilerGenerated]
			get
			{
				return rNF;
			}
			[CompilerGenerated]
			private set
			{
				rNF = value;
			}
		}

		public uint Offset
		{
			[CompilerGenerated]
			get
			{
				return hNv;
			}
			[CompilerGenerated]
			private set
			{
				hNv = value;
			}
		}

		uint IChunk.Length => (uint)(Table.Targets.Length * 4 + 2);

		public JumpTableChunk(ILJumpTable iljumpTable_0)
		{
			Table = iljumpTable_0;
			if (iljumpTable_0.Targets.Length > 65535)
			{
				throw new NotSupportedException("Jump table too large.");
			}
		}

		void IChunk.OnOffsetComputed(uint uint_0)
		{
			Offset = uint_0 + 2;
		}

		byte[] IChunk.GetData()
		{
			byte[] array = new byte[Table.Targets.Length * 4 + 2];
			_ = (ushort)Table.Targets.Length;
			int num = 0;
			num = 1;
			array[0] = (byte)Table.Targets.Length;
			num = 2;
			array[1] = (byte)(Table.Targets.Length >> 8);
			uint offset = Table.RelativeBase.Offset;
			offset += kNP.W2O().yN0(Table.RelativeBase);
			for (int i = 0; i < Table.Targets.Length; i++)
			{
				uint offset2 = ((ILBlock)Table.Targets[i]).Content[0].Offset;
				offset2 -= offset;
				array[num++] = (byte)offset2;
				array[num++] = (byte)(offset2 >> 8);
				array[num++] = (byte)(offset2 >> 16);
				array[num++] = (byte)(offset2 >> 24);
			}
			return array;
		}
	}
}
