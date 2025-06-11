using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace XVM.DynCipher.Generation
{
	public class x86Instruction
	{
		[CompilerGenerated]
		private x86OpCode qup;

		[CompilerGenerated]
		private Ix86Operand[] Sur;

		public x86OpCode OpCode
		{
			[CompilerGenerated]
			get
			{
				return qup;
			}
			[CompilerGenerated]
			set
			{
				qup = value;
			}
		}

		public Ix86Operand[] Operands
		{
			[CompilerGenerated]
			get
			{
				return Sur;
			}
			[CompilerGenerated]
			set
			{
				Sur = value;
			}
		}

		public static x86Instruction Create(x86OpCode x86OpCode_0, params Ix86Operand[] operands)
		{
			x86Instruction x86Instruction2 = new x86Instruction();
			x86Instruction2.OpCode = x86OpCode_0;
			x86Instruction2.Operands = operands;
			return x86Instruction2;
		}

		public byte[] Assemble()
		{
			switch (OpCode)
			{
			case x86OpCode.MOV:
			{
				if (Operands.Length != 2)
				{
					throw new InvalidOperationException();
				}
				if (Operands[0] is GClass0 && Operands[1] is GClass0)
				{
					byte[] array5 = new byte[2] { 137, 192 };
					array5[1] |= (byte)((int)(Operands[1] as GClass0).Register << 3);
					array5[1] |= (byte)(Operands[0] as GClass0).Register;
					return array5;
				}
				if (!(Operands[0] is GClass0) || !(Operands[1] is GClass1))
				{
					throw new NotSupportedException();
				}
				byte[] array6 = new byte[5] { 184, 0, 0, 0, 0 };
				array6[0] |= (byte)(Operands[0] as GClass0).Register;
				Buffer.BlockCopy(BitConverter.GetBytes((Operands[1] as GClass1).Immediate), 0, array6, 1, 4);
				return array6;
			}
			case x86OpCode.ADD:
			{
				if (Operands.Length != 2)
				{
					throw new InvalidOperationException();
				}
				if (Operands[0] is GClass0 && Operands[1] is GClass0)
				{
					byte[] array10 = new byte[2] { 1, 192 };
					array10[1] |= (byte)((int)(Operands[1] as GClass0).Register << 3);
					array10[1] |= (byte)(Operands[0] as GClass0).Register;
					return array10;
				}
				if (!(Operands[0] is GClass0) || !(Operands[1] is GClass1))
				{
					throw new NotSupportedException();
				}
				byte[] array11 = new byte[6] { 129, 192, 0, 0, 0, 0 };
				array11[1] |= (byte)(Operands[0] as GClass0).Register;
				Buffer.BlockCopy(BitConverter.GetBytes((Operands[1] as GClass1).Immediate), 0, array11, 2, 4);
				return array11;
			}
			case x86OpCode.SUB:
				if (Operands.Length == 2)
				{
					if (!(Operands[0] is GClass0) || !(Operands[1] is GClass0))
					{
						if (!(Operands[0] is GClass0) || !(Operands[1] is GClass1))
						{
							throw new NotSupportedException();
						}
						byte[] array12 = new byte[6] { 129, 232, 0, 0, 0, 0 };
						array12[1] |= (byte)(Operands[0] as GClass0).Register;
						Buffer.BlockCopy(BitConverter.GetBytes((Operands[1] as GClass1).Immediate), 0, array12, 2, 4);
						return array12;
					}
					byte[] array13 = new byte[2] { 41, 192 };
					array13[1] |= (byte)((int)(Operands[1] as GClass0).Register << 3);
					array13[1] |= (byte)(Operands[0] as GClass0).Register;
					return array13;
				}
				throw new InvalidOperationException();
			case x86OpCode.IMUL:
			{
				if (Operands.Length != 2)
				{
					throw new InvalidOperationException();
				}
				if (Operands[0] is GClass0 && Operands[1] is GClass0)
				{
					byte[] array3 = new byte[3];
					array3[0] = 15;
					array3[1] = 175;
					array3[1] = 192;
					array3[1] |= (byte)((int)(Operands[1] as GClass0).Register << 3);
					array3[1] |= (byte)(Operands[0] as GClass0).Register;
					return array3;
				}
				if (!(Operands[0] is GClass0) || !(Operands[1] is GClass1))
				{
					throw new NotSupportedException();
				}
				byte[] array4 = new byte[6] { 105, 192, 0, 0, 0, 0 };
				array4[1] |= (byte)((int)(Operands[0] as GClass0).Register << 3);
				array4[1] |= (byte)(Operands[0] as GClass0).Register;
				Buffer.BlockCopy(BitConverter.GetBytes((Operands[1] as GClass1).Immediate), 0, array4, 2, 4);
				return array4;
			}
			default:
				throw new NotSupportedException();
			case x86OpCode.NEG:
			{
				if (Operands.Length != 1)
				{
					throw new InvalidOperationException();
				}
				if (!(Operands[0] is GClass0))
				{
					throw new NotSupportedException();
				}
				byte[] array2 = new byte[2] { 247, 216 };
				array2[1] |= (byte)(Operands[0] as GClass0).Register;
				return array2;
			}
			case x86OpCode.NOT:
				if (Operands.Length == 1)
				{
					if (!(Operands[0] is GClass0))
					{
						throw new NotSupportedException();
					}
					byte[] array9 = new byte[2] { 247, 208 };
					array9[1] |= (byte)(Operands[0] as GClass0).Register;
					return array9;
				}
				throw new InvalidOperationException();
			case x86OpCode.XOR:
				if (Operands.Length == 2)
				{
					if (!(Operands[0] is GClass0) || !(Operands[1] is GClass0))
					{
						if (!(Operands[0] is GClass0) || !(Operands[1] is GClass1))
						{
							throw new NotSupportedException();
						}
						byte[] array7 = new byte[6] { 129, 240, 0, 0, 0, 0 };
						array7[1] |= (byte)(Operands[0] as GClass0).Register;
						Buffer.BlockCopy(BitConverter.GetBytes((Operands[1] as GClass1).Immediate), 0, array7, 2, 4);
						return array7;
					}
					byte[] array8 = new byte[2] { 49, 192 };
					array8[1] |= (byte)((int)(Operands[1] as GClass0).Register << 3);
					array8[1] |= (byte)(Operands[0] as GClass0).Register;
					return array8;
				}
				throw new InvalidOperationException();
			case x86OpCode.POP:
			{
				if (Operands.Length != 1)
				{
					throw new InvalidOperationException();
				}
				if (!(Operands[0] is GClass0))
				{
					throw new NotSupportedException();
				}
				byte[] array = new byte[1] { 88 };
				array[0] |= (byte)(Operands[0] as GClass0).Register;
				return array;
			}
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(OpCode);
			for (int i = 0; i < Operands.Length; i++)
			{
				stringBuilder.AppendFormat("{0}{1}", (i == 0) ? " " : ", ", Operands[i]);
			}
			return stringBuilder.ToString();
		}
	}
}
