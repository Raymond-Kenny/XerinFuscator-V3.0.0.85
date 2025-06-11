using System;
using System.IO;

internal static class Lzma
{
	private struct BitDecoder
	{
		public const int kNumBitModelTotalBits = 11;

		public const uint kBitModelTotal = 2048u;

		private const int kNumMoveBits = 5;

		private uint Prob;

		public void Init()
		{
			Prob = 1024u;
		}

		public uint Decode(Decoder rangeDecoder)
		{
			uint num = (rangeDecoder.Range >> 11) * Prob;
			if (rangeDecoder.Code < num)
			{
				rangeDecoder.Range = num;
				Prob += 2048 - Prob >> 5;
				if (rangeDecoder.Range < 16777216)
				{
					rangeDecoder.Code = (rangeDecoder.Code << 8) | (byte)rangeDecoder.Stream.ReadByte();
					rangeDecoder.Range <<= 8;
				}
				return 0u;
			}
			rangeDecoder.Range -= num;
			rangeDecoder.Code -= num;
			Prob -= Prob >> 5;
			if (rangeDecoder.Range < 16777216)
			{
				rangeDecoder.Code = (rangeDecoder.Code << 8) | (byte)rangeDecoder.Stream.ReadByte();
				rangeDecoder.Range <<= 8;
			}
			return 1u;
		}
	}

	private struct BitTreeDecoder
	{
		private readonly BitDecoder[] Models;

		private readonly int NumBitLevels;

		public BitTreeDecoder(int numBitLevels)
		{
			NumBitLevels = numBitLevels;
			Models = new BitDecoder[1 << numBitLevels];
		}

		public void Init()
		{
			for (uint num = 1u; num < 1 << NumBitLevels; num++)
			{
				Models[num].Init();
			}
		}

		public uint Decode(Decoder rangeDecoder)
		{
			uint num = 1u;
			for (int num2 = NumBitLevels; num2 > 0; num2--)
			{
				num = (num << 1) + Models[num].Decode(rangeDecoder);
			}
			return num - (uint)(1 << NumBitLevels);
		}

		public uint ReverseDecode(Decoder rangeDecoder)
		{
			uint num = 1u;
			uint num2 = 0u;
			for (int i = 0; i < NumBitLevels; i++)
			{
				uint num3 = Models[num].Decode(rangeDecoder);
				num <<= 1;
				num += num3;
				num2 |= num3 << i;
			}
			return num2;
		}

		public static uint ReverseDecode(BitDecoder[] Models, uint startIndex, Decoder rangeDecoder, int NumBitLevels)
		{
			uint num = 1u;
			uint num2 = 0u;
			for (int i = 0; i < NumBitLevels; i++)
			{
				uint num3 = Models[startIndex + num].Decode(rangeDecoder);
				num <<= 1;
				num += num3;
				num2 |= num3 << i;
			}
			return num2;
		}
	}

	private class Decoder
	{
		public const uint kTopValue = 16777216u;

		public uint Code;

		public uint Range;

		public Stream Stream;

		public void Init(Stream stream)
		{
			Stream = stream;
			Code = 0u;
			Range = uint.MaxValue;
			for (int i = 0; i < 5; i++)
			{
				Code = (Code << 8) | (byte)Stream.ReadByte();
			}
		}

		public void ReleaseStream()
		{
			Stream = null;
		}

		public void Normalize()
		{
			while (Range < 16777216)
			{
				Code = (Code << 8) | (byte)Stream.ReadByte();
				Range <<= 8;
			}
		}

		public uint DecodeDirectBits(int numTotalBits)
		{
			uint num = Range;
			uint num2 = Code;
			uint num3 = 0u;
			for (int num4 = numTotalBits; num4 > 0; num4--)
			{
				num >>= 1;
				uint num5 = num2 - num >> 31;
				num2 -= num & (num5 - 1);
				num3 = (num3 << 1) | (1 - num5);
				if (num < 16777216)
				{
					num2 = (num2 << 8) | (byte)Stream.ReadByte();
					num <<= 8;
				}
			}
			Range = num;
			Code = num2;
			return num3;
		}
	}

	public class LzmaDecoder
	{
		private class LenDecoder
		{
			private readonly BitTreeDecoder[] m_LowCoder = new BitTreeDecoder[16];

			private readonly BitTreeDecoder[] m_MidCoder = new BitTreeDecoder[16];

			private BitDecoder m_Choice = default(BitDecoder);

			private BitDecoder m_Choice2 = default(BitDecoder);

			private BitTreeDecoder m_HighCoder = new BitTreeDecoder(8);

			private uint m_NumPosStates;

			public void Create(uint numPosStates)
			{
				for (uint num = m_NumPosStates; num < numPosStates; num++)
				{
					m_LowCoder[num] = new BitTreeDecoder(3);
					m_MidCoder[num] = new BitTreeDecoder(3);
				}
				m_NumPosStates = numPosStates;
			}

			public void Init()
			{
				m_Choice.Init();
				for (uint num = 0u; num < m_NumPosStates; num++)
				{
					m_LowCoder[num].Init();
					m_MidCoder[num].Init();
				}
				m_Choice2.Init();
				m_HighCoder.Init();
			}

			public uint Decode(Decoder rangeDecoder, uint posState)
			{
				if (m_Choice.Decode(rangeDecoder) == 0)
				{
					return m_LowCoder[posState].Decode(rangeDecoder);
				}
				uint num = 8u;
				if (m_Choice2.Decode(rangeDecoder) == 0)
				{
					num += m_MidCoder[posState].Decode(rangeDecoder);
				}
				else
				{
					num += 8;
					num += m_HighCoder.Decode(rangeDecoder);
				}
				return num;
			}
		}

		private class LiteralDecoder
		{
			private struct Decoder2
			{
				private BitDecoder[] m_Decoders;

				public void Create()
				{
					m_Decoders = new BitDecoder[768];
				}

				public void Init()
				{
					for (int i = 0; i < 768; i++)
					{
						m_Decoders[i].Init();
					}
				}

				public byte DecodeNormal(Decoder rangeDecoder)
				{
					uint num = 1u;
					do
					{
						num = (num << 1) | m_Decoders[num].Decode(rangeDecoder);
					}
					while (num < 256);
					return (byte)num;
				}

				public byte DecodeWithMatchByte(Decoder rangeDecoder, byte matchByte)
				{
					uint num = 1u;
					do
					{
						uint num2 = (uint)((matchByte >> 7) & 1);
						matchByte <<= 1;
						uint num3 = m_Decoders[(1 + num2 << 8) + num].Decode(rangeDecoder);
						num = (num << 1) | num3;
						if (num2 != num3)
						{
							while (num < 256)
							{
								num = (num << 1) | m_Decoders[num].Decode(rangeDecoder);
							}
							break;
						}
					}
					while (num < 256);
					return (byte)num;
				}
			}

			private Decoder2[] m_Coders;

			private int m_NumPosBits;

			private int m_NumPrevBits;

			private uint m_PosMask;

			public void Create(int numPosBits, int numPrevBits)
			{
				if (m_Coders == null || m_NumPrevBits != numPrevBits || m_NumPosBits != numPosBits)
				{
					m_NumPosBits = numPosBits;
					m_PosMask = (uint)((1 << numPosBits) - 1);
					m_NumPrevBits = numPrevBits;
					uint num = (uint)(1 << m_NumPrevBits + m_NumPosBits);
					m_Coders = new Decoder2[num];
					for (uint num2 = 0u; num2 < num; num2++)
					{
						m_Coders[num2].Create();
					}
				}
			}

			public void Init()
			{
				uint num = (uint)(1 << m_NumPrevBits + m_NumPosBits);
				for (uint num2 = 0u; num2 < num; num2++)
				{
					m_Coders[num2].Init();
				}
			}

			private uint GetState(uint pos, byte prevByte)
			{
				return ((pos & m_PosMask) << m_NumPrevBits) + (uint)(prevByte >> 8 - m_NumPrevBits);
			}

			public byte DecodeNormal(Decoder rangeDecoder, uint pos, byte prevByte)
			{
				return m_Coders[GetState(pos, prevByte)].DecodeNormal(rangeDecoder);
			}

			public byte DecodeWithMatchByte(Decoder rangeDecoder, uint pos, byte prevByte, byte matchByte)
			{
				return m_Coders[GetState(pos, prevByte)].DecodeWithMatchByte(rangeDecoder, matchByte);
			}
		}

		private const uint kNumStates = 12u;

		private const int kNumPosSlotBits = 6;

		private const uint kNumLenToPosStates = 4u;

		private const uint kMatchMinLen = 2u;

		private const int kNumAlignBits = 4;

		private const uint kAlignTableSize = 16u;

		private const uint kStartPosModelIndex = 4u;

		private const uint kEndPosModelIndex = 14u;

		private const uint kNumFullDistances = 128u;

		private const int kNumPosStatesBitsMax = 4;

		private const uint kNumPosStatesMax = 16u;

		private const int kNumLowLenBits = 3;

		private const int kNumMidLenBits = 3;

		private const int kNumHighLenBits = 8;

		private const uint kNumLowLenSymbols = 8u;

		private const uint kNumMidLenSymbols = 8u;

		private readonly BitDecoder[] m_IsMatchDecoders = new BitDecoder[192];

		private readonly BitDecoder[] m_IsRep0LongDecoders = new BitDecoder[192];

		private readonly BitDecoder[] m_IsRepDecoders = new BitDecoder[12];

		private readonly BitDecoder[] m_IsRepG0Decoders = new BitDecoder[12];

		private readonly BitDecoder[] m_IsRepG1Decoders = new BitDecoder[12];

		private readonly BitDecoder[] m_IsRepG2Decoders = new BitDecoder[12];

		private readonly LenDecoder m_LenDecoder = new LenDecoder();

		private readonly LiteralDecoder m_LiteralDecoder = new LiteralDecoder();

		private readonly OutWindow m_OutWindow = new OutWindow();

		private readonly BitDecoder[] m_PosDecoders = new BitDecoder[114];

		private readonly BitTreeDecoder[] m_PosSlotDecoder = new BitTreeDecoder[4];

		private readonly Decoder m_RangeDecoder = new Decoder();

		private readonly LenDecoder m_RepLenDecoder = new LenDecoder();

		private bool _solid = false;

		private uint m_DictionarySize;

		private uint m_DictionarySizeCheck;

		private BitTreeDecoder m_PosAlignDecoder = new BitTreeDecoder(4);

		private uint m_PosStateMask;

		public LzmaDecoder()
		{
			m_DictionarySize = uint.MaxValue;
			for (int i = 0; (long)i < 4L; i++)
			{
				m_PosSlotDecoder[i] = new BitTreeDecoder(6);
			}
		}

		private void SetDictionarySize(uint dictionarySize)
		{
			if (m_DictionarySize != dictionarySize)
			{
				m_DictionarySize = dictionarySize;
				m_DictionarySizeCheck = Math.Max(m_DictionarySize, 1u);
				uint windowSize = Math.Max(m_DictionarySizeCheck, 4096u);
				m_OutWindow.Create(windowSize);
			}
		}

		private void SetLiteralProperties(int lp, int lc)
		{
			m_LiteralDecoder.Create(lp, lc);
		}

		private void SetPosBitsProperties(int pb)
		{
			uint num = (uint)(1 << pb);
			m_LenDecoder.Create(num);
			m_RepLenDecoder.Create(num);
			m_PosStateMask = num - 1;
		}

		private void Init(Stream inStream, Stream outStream)
		{
			m_RangeDecoder.Init(inStream);
			m_OutWindow.Init(outStream, _solid);
			for (uint num = 0u; num < 12; num++)
			{
				for (uint num2 = 0u; num2 <= m_PosStateMask; num2++)
				{
					uint num3 = (num << 4) + num2;
					m_IsMatchDecoders[num3].Init();
					m_IsRep0LongDecoders[num3].Init();
				}
				m_IsRepDecoders[num].Init();
				m_IsRepG0Decoders[num].Init();
				m_IsRepG1Decoders[num].Init();
				m_IsRepG2Decoders[num].Init();
			}
			m_LiteralDecoder.Init();
			for (uint num = 0u; num < 4; num++)
			{
				m_PosSlotDecoder[num].Init();
			}
			for (uint num = 0u; num < 114; num++)
			{
				m_PosDecoders[num].Init();
			}
			m_LenDecoder.Init();
			m_RepLenDecoder.Init();
			m_PosAlignDecoder.Init();
		}

		public void Code(Stream inStream, Stream outStream, long inSize, long outSize)
		{
			Init(inStream, outStream);
			State state = default(State);
			state.Init();
			uint num = 0u;
			uint num2 = 0u;
			uint num3 = 0u;
			uint num4 = 0u;
			ulong num5 = 0uL;
			if (num5 < (ulong)outSize)
			{
				m_IsMatchDecoders[state.Index << 4].Decode(m_RangeDecoder);
				state.UpdateChar();
				byte b = m_LiteralDecoder.DecodeNormal(m_RangeDecoder, 0u, 0);
				m_OutWindow.PutByte(b);
				num5++;
			}
			while (num5 < (ulong)outSize)
			{
				uint num6 = (uint)(int)num5 & m_PosStateMask;
				if (m_IsMatchDecoders[(state.Index << 4) + num6].Decode(m_RangeDecoder) == 0)
				{
					byte prevByte = m_OutWindow.GetByte(0u);
					byte b2 = (state.IsCharState() ? m_LiteralDecoder.DecodeNormal(m_RangeDecoder, (uint)num5, prevByte) : m_LiteralDecoder.DecodeWithMatchByte(m_RangeDecoder, (uint)num5, prevByte, m_OutWindow.GetByte(num)));
					m_OutWindow.PutByte(b2);
					state.UpdateChar();
					num5++;
					continue;
				}
				uint num8;
				if (m_IsRepDecoders[state.Index].Decode(m_RangeDecoder) == 1)
				{
					if (m_IsRepG0Decoders[state.Index].Decode(m_RangeDecoder) == 0)
					{
						if (m_IsRep0LongDecoders[(state.Index << 4) + num6].Decode(m_RangeDecoder) == 0)
						{
							state.UpdateShortRep();
							m_OutWindow.PutByte(m_OutWindow.GetByte(num));
							num5++;
							continue;
						}
					}
					else
					{
						uint num7;
						if (m_IsRepG1Decoders[state.Index].Decode(m_RangeDecoder) == 0)
						{
							num7 = num2;
						}
						else
						{
							if (m_IsRepG2Decoders[state.Index].Decode(m_RangeDecoder) == 0)
							{
								num7 = num3;
							}
							else
							{
								num7 = num4;
								num4 = num3;
							}
							num3 = num2;
						}
						num2 = num;
						num = num7;
					}
					num8 = m_RepLenDecoder.Decode(m_RangeDecoder, num6) + 2;
					state.UpdateRep();
				}
				else
				{
					num4 = num3;
					num3 = num2;
					num2 = num;
					num8 = 2 + m_LenDecoder.Decode(m_RangeDecoder, num6);
					state.UpdateMatch();
					uint num9 = m_PosSlotDecoder[GetLenToPosState(num8)].Decode(m_RangeDecoder);
					if (num9 >= 4)
					{
						int num10 = (int)((num9 >> 1) - 1);
						num = (2 | (num9 & 1)) << num10;
						if (num9 < 14)
						{
							num += BitTreeDecoder.ReverseDecode(m_PosDecoders, num - num9 - 1, m_RangeDecoder, num10);
						}
						else
						{
							num += m_RangeDecoder.DecodeDirectBits(num10 - 4) << 4;
							num += m_PosAlignDecoder.ReverseDecode(m_RangeDecoder);
						}
					}
					else
					{
						num = num9;
					}
				}
				if ((num >= num5 || num >= m_DictionarySizeCheck) && num == uint.MaxValue)
				{
					break;
				}
				m_OutWindow.CopyBlock(num, num8);
				num5 += num8;
			}
			m_OutWindow.Flush();
			m_OutWindow.ReleaseStream();
			m_RangeDecoder.ReleaseStream();
		}

		public void SetDecoderProperties(byte[] properties)
		{
			int lc = properties[0] % 9;
			int num = properties[0] / 9;
			int lp = num % 5;
			int posBitsProperties = num / 5;
			uint num2 = 0u;
			for (int i = 0; i < 4; i++)
			{
				num2 += (uint)(properties[1 + i] << i * 8);
			}
			SetDictionarySize(num2);
			SetLiteralProperties(lp, lc);
			SetPosBitsProperties(posBitsProperties);
		}

		private static uint GetLenToPosState(uint len)
		{
			len -= 2;
			if (len < 4)
			{
				return len;
			}
			return 3u;
		}
	}

	private class OutWindow
	{
		private byte[] _buffer;

		private uint _pos;

		private Stream _stream;

		private uint _streamPos;

		private uint _windowSize;

		public void Create(uint windowSize)
		{
			if (_windowSize != windowSize)
			{
				_buffer = new byte[windowSize];
			}
			_windowSize = windowSize;
			_pos = 0u;
			_streamPos = 0u;
		}

		public void Init(Stream stream, bool solid)
		{
			ReleaseStream();
			_stream = stream;
			if (!solid)
			{
				_streamPos = 0u;
				_pos = 0u;
			}
		}

		public void ReleaseStream()
		{
			Flush();
			_stream = null;
			Buffer.BlockCopy(new byte[_buffer.Length], 0, _buffer, 0, _buffer.Length);
		}

		public void Flush()
		{
			uint num = _pos - _streamPos;
			if (num != 0)
			{
				_stream.Write(_buffer, (int)_streamPos, (int)num);
				if (_pos >= _windowSize)
				{
					_pos = 0u;
				}
				_streamPos = _pos;
			}
		}

		public void CopyBlock(uint distance, uint len)
		{
			uint num = _pos - distance - 1;
			if (num >= _windowSize)
			{
				num += _windowSize;
			}
			while (len != 0)
			{
				if (num >= _windowSize)
				{
					num = 0u;
				}
				_buffer[_pos++] = _buffer[num++];
				if (_pos >= _windowSize)
				{
					Flush();
				}
				len--;
			}
		}

		public void PutByte(byte b)
		{
			_buffer[_pos++] = b;
			if (_pos >= _windowSize)
			{
				Flush();
			}
		}

		public byte GetByte(uint distance)
		{
			uint num = _pos - distance - 1;
			if (num >= _windowSize)
			{
				num += _windowSize;
			}
			return _buffer[num];
		}
	}

	private struct State
	{
		public uint Index;

		public void Init()
		{
			Index = 0u;
		}

		public void UpdateChar()
		{
			if (Index < 4)
			{
				Index = 0u;
			}
			else if (Index < 10)
			{
				Index -= 3u;
			}
			else
			{
				Index -= 6u;
			}
		}

		public void UpdateMatch()
		{
			Index = ((Index < 7) ? 7u : 10u);
		}

		public void UpdateRep()
		{
			Index = ((Index < 7) ? 8u : 11u);
		}

		public void UpdateShortRep()
		{
			Index = ((Index < 7) ? 9u : 11u);
		}

		public bool IsCharState()
		{
			return Index < 7;
		}
	}

	public static byte[] Decompress(byte[] data)
	{
		MemoryStream memoryStream = new MemoryStream(data);
		LzmaDecoder lzmaDecoder = new LzmaDecoder();
		byte[] array = new byte[5];
		for (int i = 0; i < 5; i += memoryStream.Read(array, i, 5 - i))
		{
		}
		lzmaDecoder.SetDecoderProperties(array);
		for (int i = 0; i < 4; i += memoryStream.Read(array, i, 4 - i))
		{
		}
		if (!BitConverter.IsLittleEndian)
		{
			int num = array.GetLowerBound(0);
			int num2 = array.GetLowerBound(0) + 4 - 1;
            object[] array2 = new object[array.Length]; 
			if (array2 != null)
			{
				while (num < num2)
				{
					byte b = (byte)array2[num];
					array2[num] = array2[num2];
					array2[num2] = b;
					num++;
					num2--;
				}
			}
			else
			{
				while (num < num2)
				{
					object value = array.GetValue(num);
					array.SetValue(array.GetValue(num2), num);
					array.SetValue(value, num2);
					num++;
					num2--;
				}
			}
		}
		int num3 = BitConverter.ToInt32(array, 0);
		byte[] array3 = new byte[num3];
		MemoryStream outStream = new MemoryStream(array3, true);
		long inSize = memoryStream.Length - 5 - 4;
		lzmaDecoder.Code(memoryStream, outStream, inSize, num3);
		return array3;
	}
}
