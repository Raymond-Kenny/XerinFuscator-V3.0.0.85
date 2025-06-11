#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using XVM.DynCipher.AST;

namespace XVM.DynCipher.Generation
{
	public class x86CodeGen
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class lkC
		{
			public static readonly lkC lk5;

			public static Func<x86Instruction, string> Mko;

			static lkC()
			{
				lk5 = new lkC();
			}

			internal string mkm(x86Instruction x86Instruction_0)
			{
				return x86Instruction_0.ToString();
			}
		}

		private List<x86Instruction> Nu7;

		private bool[] BuD;

		[CompilerGenerated]
		private int muy;

		public IList<x86Instruction> Instructions => Nu7;

		public int MaxUsedRegister
		{
			[CompilerGenerated]
			get
			{
				return muy;
			}
			[CompilerGenerated]
			private set
			{
				muy = value;
			}
		}

		public x86Register? method_0(Expression expression_0, Func<Variable, x86Register, IEnumerable<x86Instruction>> func_0)
		{
			Nu7 = new List<x86Instruction>();
			BuD = new bool[8];
			MaxUsedRegister = -1;
			BuD[5] = true;
			BuD[4] = true;
			try
			{
				return ((GClass0)Oud(expression_0, func_0)).Register;
			}
			catch (Exception ex)
			{
				if (!(ex.Message == "Register overflowed."))
				{
					throw;
				}
				return null;
			}
		}

		private x86Register buh()
		{
			int num = 0;
			while (true)
			{
				if (num < 8)
				{
					if (!BuD[num])
					{
						break;
					}
					num++;
					continue;
				}
				throw new Exception("Register overflowed.");
			}
			return (x86Register)num;
		}

		private void guP(x86Register x86Register_0)
		{
			BuD[(int)x86Register_0] = true;
			if ((int)x86Register_0 > MaxUsedRegister)
			{
				MaxUsedRegister = (int)x86Register_0;
			}
		}

		private void huF(x86Register x86Register_0)
		{
			BuD[(int)x86Register_0] = false;
		}

		private x86Register buv(x86Instruction x86Instruction_0)
		{
			if (x86Instruction_0.Operands.Length != 2 || !(x86Instruction_0.Operands[0] is GClass1) || !(x86Instruction_0.Operands[1] is GClass1))
			{
				if (x86Instruction_0.Operands.Length != 1 || !(x86Instruction_0.Operands[0] is GClass1))
				{
					if (x86Instruction_0.OpCode == x86OpCode.SUB && x86Instruction_0.Operands[0] is GClass1 && x86Instruction_0.Operands[1] is GClass0)
					{
						x86Register register = ((GClass0)x86Instruction_0.Operands[1]).Register;
						Nu7.Add(x86Instruction.Create(x86OpCode.NEG, new GClass0(register)));
						x86Instruction_0.OpCode = x86OpCode.ADD;
						x86Instruction_0.Operands[1] = x86Instruction_0.Operands[0];
						x86Instruction_0.Operands[0] = new GClass0(register);
						Nu7.Add(x86Instruction_0);
						return register;
					}
					if (x86Instruction_0.Operands.Length == 2 && x86Instruction_0.Operands[0] is GClass1 && x86Instruction_0.Operands[1] is GClass0)
					{
						x86Register register2 = ((GClass0)x86Instruction_0.Operands[1]).Register;
						x86Instruction_0.Operands[1] = x86Instruction_0.Operands[0];
						x86Instruction_0.Operands[0] = new GClass0(register2);
						Nu7.Add(x86Instruction_0);
						return register2;
					}
					Debug.Assert(x86Instruction_0.Operands.Length != 0);
					Debug.Assert(x86Instruction_0.Operands[0] is GClass0);
					if (x86Instruction_0.Operands.Length == 2 && x86Instruction_0.Operands[1] is GClass0)
					{
						huF(((GClass0)x86Instruction_0.Operands[1]).Register);
					}
					Nu7.Add(x86Instruction_0);
					return ((GClass0)x86Instruction_0.Operands[0]).Register;
				}
				x86Register x86Register2 = buh();
				Nu7.Add(x86Instruction.Create(x86OpCode.MOV, new GClass0(x86Register2), x86Instruction_0.Operands[0]));
				x86Instruction_0.Operands[0] = new GClass0(x86Register2);
				Nu7.Add(x86Instruction_0);
				return x86Register2;
			}
			x86Register x86Register3 = buh();
			Nu7.Add(x86Instruction.Create(x86OpCode.MOV, new GClass0(x86Register3), x86Instruction_0.Operands[0]));
			x86Instruction_0.Operands[0] = new GClass0(x86Register3);
			Nu7.Add(x86Instruction_0);
			return x86Register3;
		}

		private Ix86Operand Oud(Expression expression_0, Func<Variable, x86Register, IEnumerable<x86Instruction>> func_0)
		{
			if (expression_0 is BinOpExpression)
			{
				BinOpExpression binOpExpression = (BinOpExpression)expression_0;
				x86Register x86Register_;
				switch (binOpExpression.Operation)
				{
				case BinOps.Add:
					x86Register_ = buv(x86Instruction.Create(x86OpCode.ADD, Oud(binOpExpression.Left, func_0), Oud(binOpExpression.Right, func_0)));
					break;
				case BinOps.Sub:
					x86Register_ = buv(x86Instruction.Create(x86OpCode.SUB, Oud(binOpExpression.Left, func_0), Oud(binOpExpression.Right, func_0)));
					break;
				case BinOps.Mul:
					x86Register_ = buv(x86Instruction.Create(x86OpCode.IMUL, Oud(binOpExpression.Left, func_0), Oud(binOpExpression.Right, func_0)));
					break;
				default:
					throw new NotSupportedException();
				case BinOps.Xor:
					x86Register_ = buv(x86Instruction.Create(x86OpCode.XOR, Oud(binOpExpression.Left, func_0), Oud(binOpExpression.Right, func_0)));
					break;
				}
				guP(x86Register_);
				return new GClass0(x86Register_);
			}
			if (expression_0 is UnaryOpExpression)
			{
				UnaryOpExpression unaryOpExpression = (UnaryOpExpression)expression_0;
				x86Register x86Register_2;
				switch (unaryOpExpression.Operation)
				{
				default:
					throw new NotSupportedException();
				case UnaryOps.Negate:
					x86Register_2 = buv(x86Instruction.Create(x86OpCode.NEG, Oud(unaryOpExpression.Value, func_0)));
					break;
				case UnaryOps.Not:
					x86Register_2 = buv(x86Instruction.Create(x86OpCode.NOT, Oud(unaryOpExpression.Value, func_0)));
					break;
				}
				guP(x86Register_2);
				return new GClass0(x86Register_2);
			}
			if (expression_0 is LiteralExpression)
			{
				return new GClass1((int)((LiteralExpression)expression_0).Value);
			}
			if (expression_0 is VariableExpression)
			{
				x86Register x86Register2 = buh();
				guP(x86Register2);
				Nu7.AddRange(func_0(((VariableExpression)expression_0).Variable, x86Register2));
				return new GClass0(x86Register2);
			}
			throw new NotSupportedException();
		}

		public override string ToString()
		{
			return string.Join("\r\n", Nu7.Select((x86Instruction x86Instruction_0) => x86Instruction_0.ToString()).ToArray());
		}
	}
}
