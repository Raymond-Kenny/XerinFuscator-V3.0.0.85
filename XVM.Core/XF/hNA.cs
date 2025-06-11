using System;
using System.IO;
using dnlib.DotNet.Pdb;
using XVM.Core.AST.IL;
using XVM.Core.RT;

namespace XF
{
	internal class hNA
	{
		private VMRuntime PN2;

		public hNA(VMRuntime vmruntime_0)
		{
			PN2 = vmruntime_0;
		}

		public uint DNR(ILBlock ilblock_0)
		{
			uint num = 0u;
			foreach (ILInstruction item in ilblock_0.Content)
			{
				num += yN0(item);
			}
			return num;
		}

		public uint yN0(ILInstruction ilinstruction_0)
		{
			uint num = 2u;
			if (ilinstruction_0.Operand != null)
			{
				if (!(ilinstruction_0.Operand is ILRegister))
				{
					if (ilinstruction_0.Operand is ILImmediate)
					{
						object value = ((ILImmediate)ilinstruction_0.Operand).Value;
						if (value is uint || value is int || value is float)
						{
							num += 4;
						}
						else
						{
							if (!(value is ulong) && !(value is long) && !(value is double))
							{
								throw new NotSupportedException();
							}
							num += 8;
						}
					}
					else
					{
						if (!(ilinstruction_0.Operand is ILRelReference))
						{
							throw new NotSupportedException();
						}
						num += 4;
					}
				}
				else
				{
					num++;
				}
			}
			return num;
		}

		public uint mNw(ILBlock ilblock_0, uint uint_0)
		{
			foreach (ILInstruction item in ilblock_0.Content)
			{
				item.Offset = uint_0;
				uint_0 += 2;
				if (item.Operand == null)
				{
					continue;
				}
				if (!(item.Operand is ILRegister))
				{
					if (!(item.Operand is ILImmediate))
					{
						if (item.Operand is ILRelReference)
						{
							uint_0 += 4;
							continue;
						}
						throw new NotSupportedException();
					}
					object value = ((ILImmediate)item.Operand).Value;
					if (!(value is uint) && !(value is int) && !(value is float))
					{
						if (!(value is ulong) && !(value is long) && !(value is double))
						{
							throw new NotSupportedException();
						}
						uint_0 += 8;
					}
					else
					{
						uint_0 += 4;
					}
				}
				else
				{
					uint_0++;
				}
			}
			return uint_0;
		}

		private static bool HNW(SequencePoint sequencePoint_0, SequencePoint sequencePoint_1)
		{
			return sequencePoint_0.Document.Url == sequencePoint_1.Document.Url && sequencePoint_0.StartLine == sequencePoint_1.StartLine;
		}

		public void oNN(ILBlock ilblock_0, BinaryWriter binaryWriter_0)
		{
			uint num = 0u;
			foreach (ILInstruction item in ilblock_0.Content)
			{
				binaryWriter_0.Write(PN2.Descriptor.Architecture.OpCodes[item.OpCode]);
				binaryWriter_0.Write(PN2.Descriptor.iqK().NextByte());
				num += 2;
				if (item.Operand == null)
				{
					continue;
				}
				if (item.Operand is ILRegister)
				{
					binaryWriter_0.Write(PN2.Descriptor.Architecture.Registers[((ILRegister)item.Operand).Register]);
					num++;
					continue;
				}
				if (item.Operand is ILImmediate)
				{
					object value = ((ILImmediate)item.Operand).Value;
					if (!(value is int))
					{
						if (!(value is uint))
						{
							if (value is long)
							{
								binaryWriter_0.Write((long)value);
								num += 8;
							}
							else if (!(value is ulong))
							{
								if (!(value is float))
								{
									if (value is double)
									{
										binaryWriter_0.Write((double)value);
										num += 8;
									}
								}
								else
								{
									binaryWriter_0.Write((float)value);
									num += 4;
								}
							}
							else
							{
								binaryWriter_0.Write((ulong)value);
								num += 8;
							}
						}
						else
						{
							binaryWriter_0.Write((uint)value);
							num += 4;
						}
					}
					else
					{
						binaryWriter_0.Write((int)value);
						num += 4;
					}
					continue;
				}
				throw new NotSupportedException();
			}
		}
	}
}
