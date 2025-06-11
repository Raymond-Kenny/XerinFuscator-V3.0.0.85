#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Confuser.DynCipher.AST;

namespace Confuser.DynCipher.Generation
{
	public class x86CodeGen
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class Y0N
		{
			public static readonly Y0N j0Y;

			public static Func<x86Instruction, string> b0Q;

			static Y0N()
			{
				j0Y = new Y0N();
			}

			internal string t0U(x86Instruction x86Instruction_0)
			{
				return x86Instruction_0.ToString();
			}
		}

		private List<x86Instruction> eFp;

		private bool[] BFB;

		[CompilerGenerated]
		private int gCN;

		public IList<x86Instruction> Instructions => eFp;

		public int MaxUsedRegister
		{
			[CompilerGenerated]
			get
			{
				return gCN;
			}
			[CompilerGenerated]
			private set
			{
				gCN = value;
			}
		}

		public x86Register? method_0(Expression expression_0, Func<Variable, x86Register, IEnumerable<x86Instruction>> func_0)
		{
			eFp = new List<x86Instruction>();
			BFB = new bool[8];
			MaxUsedRegister = -1;
			BFB[5] = true;
			BFB[4] = true;
			try
			{
				return ((GClass0)NFE(expression_0, func_0)).Register;
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

		private x86Register zFO()
		{
			int num = 0;
			while (true)
			{
				if (num < 8)
				{
					if (!BFB[num])
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

		private void uFI(x86Register x86Register_0)
		{
			BFB[(int)x86Register_0] = true;
			if ((int)x86Register_0 > MaxUsedRegister)
			{
				MaxUsedRegister = (int)x86Register_0;
			}
		}

		private void oF2(x86Register x86Register_0)
		{
			BFB[(int)x86Register_0] = false;
		}

		private x86Register DFs(x86Instruction x86Instruction_0)
		{
			if (x86Instruction_0.Operands.Length == 2 && x86Instruction_0.Operands[0] is GClass1 && x86Instruction_0.Operands[1] is GClass1)
			{
				x86Register x86Register2 = zFO();
				eFp.Add(x86Instruction.Create(x86OpCode.MOV, new GClass0(x86Register2), x86Instruction_0.Operands[0]));
				x86Instruction_0.Operands[0] = new GClass0(x86Register2);
				eFp.Add(x86Instruction_0);
				return x86Register2;
			}
			if (x86Instruction_0.Operands.Length != 1 || !(x86Instruction_0.Operands[0] is GClass1))
			{
				if (x86Instruction_0.OpCode == x86OpCode.SUB && x86Instruction_0.Operands[0] is GClass1 && x86Instruction_0.Operands[1] is GClass0)
				{
					x86Register register = ((GClass0)x86Instruction_0.Operands[1]).Register;
					eFp.Add(x86Instruction.Create(x86OpCode.NEG, new GClass0(register)));
					x86Instruction_0.OpCode = x86OpCode.ADD;
					x86Instruction_0.Operands[1] = x86Instruction_0.Operands[0];
					x86Instruction_0.Operands[0] = new GClass0(register);
					eFp.Add(x86Instruction_0);
					return register;
				}
				if (x86Instruction_0.Operands.Length == 2 && x86Instruction_0.Operands[0] is GClass1 && x86Instruction_0.Operands[1] is GClass0)
				{
					x86Register register2 = ((GClass0)x86Instruction_0.Operands[1]).Register;
					x86Instruction_0.Operands[1] = x86Instruction_0.Operands[0];
					x86Instruction_0.Operands[0] = new GClass0(register2);
					eFp.Add(x86Instruction_0);
					return register2;
				}
				Debug.Assert(x86Instruction_0.Operands.Length != 0);
				Debug.Assert(x86Instruction_0.Operands[0] is GClass0);
				if (x86Instruction_0.Operands.Length == 2 && x86Instruction_0.Operands[1] is GClass0)
				{
					oF2(((GClass0)x86Instruction_0.Operands[1]).Register);
				}
				eFp.Add(x86Instruction_0);
				return ((GClass0)x86Instruction_0.Operands[0]).Register;
			}
			x86Register x86Register3 = zFO();
			eFp.Add(x86Instruction.Create(x86OpCode.MOV, new GClass0(x86Register3), x86Instruction_0.Operands[0]));
			x86Instruction_0.Operands[0] = new GClass0(x86Register3);
			eFp.Add(x86Instruction_0);
			return x86Register3;
		}

		private Ix86Operand NFE(Expression expression_0, Func<Variable, x86Register, IEnumerable<x86Instruction>> func_0)
		{
			if (expression_0 is BinOpExpression)
			{
				BinOpExpression binOpExpression = (BinOpExpression)expression_0;
				x86Register x86Register_;
				switch (binOpExpression.Operation)
				{
				case BinOps.Add:
					x86Register_ = DFs(x86Instruction.Create(x86OpCode.ADD, NFE(binOpExpression.Left, func_0), NFE(binOpExpression.Right, func_0)));
					break;
				case BinOps.Sub:
					x86Register_ = DFs(x86Instruction.Create(x86OpCode.SUB, NFE(binOpExpression.Left, func_0), NFE(binOpExpression.Right, func_0)));
					break;
				case BinOps.Mul:
					x86Register_ = DFs(x86Instruction.Create(x86OpCode.IMUL, NFE(binOpExpression.Left, func_0), NFE(binOpExpression.Right, func_0)));
					break;
				default:
					throw new NotSupportedException();
				case BinOps.Xor:
					x86Register_ = DFs(x86Instruction.Create(x86OpCode.XOR, NFE(binOpExpression.Left, func_0), NFE(binOpExpression.Right, func_0)));
					break;
				}
				uFI(x86Register_);
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
					x86Register_2 = DFs(x86Instruction.Create(x86OpCode.NEG, NFE(unaryOpExpression.Value, func_0)));
					break;
				case UnaryOps.Not:
					x86Register_2 = DFs(x86Instruction.Create(x86OpCode.NOT, NFE(unaryOpExpression.Value, func_0)));
					break;
				}
				uFI(x86Register_2);
				return new GClass0(x86Register_2);
			}
			if (expression_0 is LiteralExpression)
			{
				return new GClass1((int)((LiteralExpression)expression_0).Value);
			}
			if (expression_0 is VariableExpression)
			{
				x86Register x86Register2 = zFO();
				uFI(x86Register2);
				eFp.AddRange(func_0(((VariableExpression)expression_0).Variable, x86Register2));
				return new GClass0(x86Register2);
			}
			throw new NotSupportedException();
		}

		public override string ToString()
		{
			return string.Join("\r\n", eFp.Select((x86Instruction x86Instruction_0) => x86Instruction_0.ToString()).ToArray());
		}
	}
}
