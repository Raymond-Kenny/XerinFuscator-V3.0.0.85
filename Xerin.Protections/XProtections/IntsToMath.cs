using System;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Utils;

namespace XProtections
{
	public class IntsToMath
	{
		[CompilerGenerated]
		private MethodDef X85;

		private static readonly Random d8N;

		[SpecialName]
		[CompilerGenerated]
		private MethodDef L8L()
		{
			return X85;
		}

		[SpecialName]
		[CompilerGenerated]
		private void r87(MethodDef methodDef_0)
		{
			X85 = methodDef_0;
		}

		public IntsToMath(MethodDef methodDef_0)
		{
			r87(methodDef_0);
		}

		public void Execute(ref int int_0)
		{
			switch (d8N.Next(0, 10))
			{
			case 0:
				G82(ref int_0);
				break;
			case 1:
				M8x(ref int_0);
				break;
			case 2:
				h8R(ref int_0);
				break;
			case 3:
				w89(ref int_0);
				break;
			case 4:
				D8w(ref int_0);
				break;
			case 5:
				U88(ref int_0);
				break;
			case 6:
				r8m(ref int_0);
				break;
			case 7:
				A8c(ref int_0);
				break;
			case 8:
				X2J(ref int_0);
				break;
			case 9:
				j2z(ref int_0);
				break;
			}
		}

		private void X2J(ref int int_0)
		{
			int ldcI4Value = L8L().Body.Instructions[int_0].GetLdcI4Value();
			int num = Utils.RandomBigInt32();
			if ((long)ldcI4Value - (long)num >= -2147483648L && (long)ldcI4Value + (long)num <= 2147483647L)
			{
				int num2 = ldcI4Value - num;
				L8L().Body.Instructions[int_0].OpCode = OpCodes.Ldc_I4;
				L8L().Body.Instructions[int_0].Operand = num2;
				L8L().Body.Instructions.Insert(++int_0, OpCodes.Ldc_I4.ToInstruction(num));
				L8L().Body.Instructions.Insert(++int_0, OpCodes.Add.ToInstruction());
			}
		}

		private void j2z(ref int int_0)
		{
			int ldcI4Value = L8L().Body.Instructions[int_0].GetLdcI4Value();
			int num = Utils.RandomBigInt32();
			if ((long)ldcI4Value - (long)num >= -2147483648L && (long)ldcI4Value + (long)num <= 2147483647L)
			{
				int num2 = ldcI4Value ^ num;
				L8L().Body.Instructions[int_0].OpCode = OpCodes.Ldc_I4;
				L8L().Body.Instructions[int_0].Operand = num2;
				L8L().Body.Instructions.Insert(++int_0, OpCodes.Ldc_I4.ToInstruction(num));
				L8L().Body.Instructions.Insert(++int_0, OpCodes.Xor.ToInstruction());
			}
		}

		private void A8c(ref int int_0)
		{
			int ldcI4Value = L8L().Body.Instructions[int_0].GetLdcI4Value();
			int num = Utils.RandomBigInt32();
			if ((long)ldcI4Value - (long)num >= -2147483648L && (long)ldcI4Value + (long)num <= 2147483647L)
			{
				int num2 = ldcI4Value + num;
				L8L().Body.Instructions[int_0].OpCode = OpCodes.Ldc_I4;
				L8L().Body.Instructions[int_0].Operand = num2;
				L8L().Body.Instructions.Insert(++int_0, OpCodes.Ldc_I4.ToInstruction(num));
				L8L().Body.Instructions.Insert(++int_0, OpCodes.Sub.ToInstruction());
			}
		}

		private void G82(ref int int_0)
		{
			int ldcI4Value = L8L().Body.Instructions[int_0].GetLdcI4Value();
			int num = Utils.RandomBigInt32();
			if ((long)ldcI4Value - (long)num >= -2147483648L && (long)ldcI4Value + (long)num <= 2147483647L)
			{
				int int_1 = -num;
				Calculator calculator = new Calculator(ldcI4Value, int_1);
				L8L().Body.Instructions[int_0].OpCode = OpCodes.Ldc_I4;
				L8L().Body.Instructions[int_0].Operand = calculator.getResult();
				L8L().Body.Instructions.Insert(int_0 + 1, OpCodes.Ldc_I4.ToInstruction(num));
				L8L().Body.Instructions.Insert(int_0 + 2, OpCodes.Neg.ToInstruction());
				L8L().Body.Instructions.Insert(int_0 + 3, calculator.getOpCode().ToInstruction());
				int_0 += 3;
			}
		}

		private void U88(ref int int_0)
		{
			int ldcI4Value = L8L().Body.Instructions[int_0].GetLdcI4Value();
			int num = Utils.RandomBigInt32();
			int num2 = Utils.RandomBigInt32();
			int int_1 = num2 % num;
			Calculator calculator = new Calculator(ldcI4Value, int_1);
			L8L().Body.Instructions[int_0].OpCode = OpCodes.Ldc_I4;
			L8L().Body.Instructions[int_0].Operand = calculator.getResult();
			L8L().Body.Instructions.Insert(int_0 + 1, OpCodes.Ldc_I4.ToInstruction(num2));
			L8L().Body.Instructions.Insert(int_0 + 2, OpCodes.Ldc_I4.ToInstruction(num));
			L8L().Body.Instructions.Insert(int_0 + 3, OpCodes.Rem.ToInstruction());
			L8L().Body.Instructions.Insert(int_0 + 4, calculator.getOpCode().ToInstruction());
			int_0 += 4;
		}

		private void M8x(ref int int_0)
		{
			int ldcI4Value = L8L().Body.Instructions[int_0].GetLdcI4Value();
			int num = Utils.RandomBigInt32();
			if ((long)ldcI4Value - (long)num >= -2147483648L && (long)ldcI4Value + (long)num <= 2147483647L)
			{
				int int_1 = ~num;
				Calculator calculator = new Calculator(ldcI4Value, int_1);
				L8L().Body.Instructions[int_0].OpCode = OpCodes.Ldc_I4;
				L8L().Body.Instructions[int_0].Operand = calculator.getResult();
				L8L().Body.Instructions.Insert(int_0 + 1, OpCodes.Ldc_I4.ToInstruction(num));
				L8L().Body.Instructions.Insert(int_0 + 2, OpCodes.Not.ToInstruction());
				L8L().Body.Instructions.Insert(int_0 + 3, calculator.getOpCode().ToInstruction());
				int_0 += 3;
			}
		}

		private void w89(ref int int_0)
		{
			int ldcI4Value = L8L().Body.Instructions[int_0].GetLdcI4Value();
			int num = Utils.RandomBigInt32();
			int num2 = Utils.RandomBigInt32();
			int int_1 = num2 << num;
			Calculator calculator = new Calculator(ldcI4Value, int_1);
			L8L().Body.Instructions[int_0].OpCode = OpCodes.Ldc_I4;
			L8L().Body.Instructions[int_0].Operand = calculator.getResult();
			L8L().Body.Instructions.Insert(int_0 + 1, OpCodes.Ldc_I4.ToInstruction(num2));
			L8L().Body.Instructions.Insert(int_0 + 2, OpCodes.Ldc_I4.ToInstruction(num));
			L8L().Body.Instructions.Insert(int_0 + 3, OpCodes.Shl.ToInstruction());
			L8L().Body.Instructions.Insert(int_0 + 4, calculator.getOpCode().ToInstruction());
			int_0 += 4;
		}

		private void D8w(ref int int_0)
		{
			int ldcI4Value = L8L().Body.Instructions[int_0].GetLdcI4Value();
			int num = Utils.RandomBigInt32();
			int num2 = Utils.RandomBigInt32();
			int int_1 = num2 | num;
			Calculator calculator = new Calculator(ldcI4Value, int_1);
			L8L().Body.Instructions[int_0].OpCode = OpCodes.Ldc_I4;
			L8L().Body.Instructions[int_0].Operand = calculator.getResult();
			L8L().Body.Instructions.Insert(int_0 + 1, OpCodes.Ldc_I4.ToInstruction(num2));
			L8L().Body.Instructions.Insert(int_0 + 2, OpCodes.Ldc_I4.ToInstruction(num));
			L8L().Body.Instructions.Insert(int_0 + 3, OpCodes.Or.ToInstruction());
			L8L().Body.Instructions.Insert(int_0 + 4, calculator.getOpCode().ToInstruction());
			int_0 += 4;
		}

		private void h8R(ref int int_0)
		{
			int ldcI4Value = L8L().Body.Instructions[int_0].GetLdcI4Value();
			int num = Utils.RandomBigInt32();
			int num2 = Utils.RandomBigInt32();
			int int_1 = num2 >> num;
			Calculator calculator = new Calculator(ldcI4Value, int_1);
			L8L().Body.Instructions[int_0].OpCode = OpCodes.Ldc_I4;
			L8L().Body.Instructions[int_0].Operand = calculator.getResult();
			L8L().Body.Instructions.Insert(int_0 + 1, OpCodes.Ldc_I4.ToInstruction(num2));
			L8L().Body.Instructions.Insert(int_0 + 2, OpCodes.Ldc_I4.ToInstruction(num));
			L8L().Body.Instructions.Insert(int_0 + 3, OpCodes.Shr.ToInstruction());
			L8L().Body.Instructions.Insert(int_0 + 4, calculator.getOpCode().ToInstruction());
			int_0 += 4;
		}

		private void r8m(ref int int_0)
		{
			Instruction instruction = L8L().Body.Instructions[int_0];
			Local local = new Local(L8L().Module.ImportAsTypeSig(typeof(int)));
			int ldcI4Value = instruction.GetLdcI4Value();
			int num = Utils.RandomBigInt32();
			int num2 = Utils.RandomBigInt32();
			int value;
			int value2;
			if (num > num2)
			{
				value = ldcI4Value;
				value2 = ldcI4Value + ldcI4Value / 3;
			}
			else
			{
				value2 = ldcI4Value;
				value = ldcI4Value + ldcI4Value / 3;
			}
			L8L().Body.Variables.Add(local);
			instruction.OpCode = OpCodes.Ldc_I4;
			instruction.Operand = num2;
			L8L().Body.Instructions.Insert(int_0 + 1, Instruction.Create(OpCodes.Ldc_I4, num));
			L8L().Body.Instructions.Insert(int_0 + 2, Instruction.Create(OpCodes.Nop));
			L8L().Body.Instructions.Insert(int_0 + 3, Instruction.Create(OpCodes.Ldc_I4, value));
			L8L().Body.Instructions.Insert(int_0 + 4, Instruction.Create(OpCodes.Nop));
			L8L().Body.Instructions.Insert(int_0 + 5, Instruction.Create(OpCodes.Ldc_I4, value2));
			L8L().Body.Instructions.Insert(int_0 + 6, Instruction.Create(OpCodes.Stloc, local));
			L8L().Body.Instructions.Insert(int_0 + 7, Instruction.Create(OpCodes.Ldloc, local));
			L8L().Body.Instructions[int_0 + 2].OpCode = OpCodes.Bgt_S;
			L8L().Body.Instructions[int_0 + 2].Operand = L8L().Body.Instructions[int_0 + 5];
			L8L().Body.Instructions[int_0 + 4].OpCode = OpCodes.Br_S;
			L8L().Body.Instructions[int_0 + 4].Operand = L8L().Body.Instructions[int_0 + 6];
			int_0 += 7;
		}

		static IntsToMath()
		{
			d8N = new Random();
		}
	}
}
