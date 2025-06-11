using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.DynCipher.AST;

namespace XVM.DynCipher.Generation
{
	public class CILCodeGen
	{
		private readonly Dictionary<string, Local> Fei = new Dictionary<string, Local>();

		[CompilerGenerated]
		private MethodDef qeJ;

		[CompilerGenerated]
		private IList<Instruction> de8;

		public MethodDef Method
		{
			[CompilerGenerated]
			get
			{
				return qeJ;
			}
			[CompilerGenerated]
			private set
			{
				qeJ = value;
			}
		}

		public IList<Instruction> Instructions
		{
			[CompilerGenerated]
			get
			{
				return de8;
			}
			[CompilerGenerated]
			private set
			{
				de8 = value;
			}
		}

		public CILCodeGen(MethodDef methodDef_0, IList<Instruction> ilist_0)
		{
			Method = methodDef_0;
			Instructions = ilist_0;
		}

		protected void Emit(Instruction instruction_0)
		{
			Instructions.Add(instruction_0);
		}

		protected virtual Local Var(Variable variable_0)
		{
			if (!Fei.TryGetValue(variable_0.Name, out var value))
			{
				value = new Local(Method.Module.CorLibTypes.UInt32);
				value.Name = variable_0.Name;
				Fei[variable_0.Name] = value;
			}
			return value;
		}

		protected virtual void LoadVar(Variable variable_0)
		{
			Emit(Instruction.Create(OpCodes.Ldloc, Var(variable_0)));
		}

		protected virtual void StoreVar(Variable variable_0)
		{
			Emit(Instruction.Create(OpCodes.Stloc, Var(variable_0)));
		}

		public void Commit(CilBody cilBody_0)
		{
			foreach (Local value in Fei.Values)
			{
				cilBody_0.InitLocals = true;
				cilBody_0.Variables.Add(value);
			}
		}

		public void method_0(Expression expression_0)
		{
			se6(expression_0);
		}

		public void method_1(Statement statement_0)
		{
			Nes(statement_0);
		}

		private void se6(Expression expression_0)
		{
			if (expression_0 is ArrayIndexExpression)
			{
				ArrayIndexExpression arrayIndexExpression = (ArrayIndexExpression)expression_0;
				se6(arrayIndexExpression.Array);
				Emit(Instruction.CreateLdcI4(arrayIndexExpression.Index));
				Emit(Instruction.Create(OpCodes.Ldelem_U4));
				return;
			}
			if (!(expression_0 is BinOpExpression))
			{
				if (expression_0 is UnaryOpExpression)
				{
					UnaryOpExpression unaryOpExpression = (UnaryOpExpression)expression_0;
					se6(unaryOpExpression.Value);
					OpCode opCode;
					switch (unaryOpExpression.Operation)
					{
					case UnaryOps.Not:
						opCode = OpCodes.Not;
						break;
					default:
						throw new NotSupportedException();
					case UnaryOps.Negate:
						opCode = OpCodes.Neg;
						break;
					}
					Emit(Instruction.Create(opCode));
				}
				else if (expression_0 is LiteralExpression)
				{
					LiteralExpression literalExpression = (LiteralExpression)expression_0;
					Emit(Instruction.CreateLdcI4((int)literalExpression.Value));
				}
				else
				{
					if (!(expression_0 is VariableExpression))
					{
						throw new NotSupportedException();
					}
					VariableExpression variableExpression = (VariableExpression)expression_0;
					LoadVar(variableExpression.Variable);
				}
				return;
			}
			BinOpExpression binOpExpression = (BinOpExpression)expression_0;
			se6(binOpExpression.Left);
			se6(binOpExpression.Right);
			OpCode opCode2;
			switch (binOpExpression.Operation)
			{
			default:
				throw new NotSupportedException();
			case BinOps.Add:
				opCode2 = OpCodes.Add;
				break;
			case BinOps.Sub:
				opCode2 = OpCodes.Sub;
				break;
			case BinOps.Div:
				opCode2 = OpCodes.Div;
				break;
			case BinOps.Mul:
				opCode2 = OpCodes.Mul;
				break;
			case BinOps.Or:
				opCode2 = OpCodes.Or;
				break;
			case BinOps.And:
				opCode2 = OpCodes.And;
				break;
			case BinOps.Xor:
				opCode2 = OpCodes.Xor;
				break;
			case BinOps.Lsh:
				opCode2 = OpCodes.Shl;
				break;
			case BinOps.Rsh:
				opCode2 = OpCodes.Shr_Un;
				break;
			}
			Emit(Instruction.Create(opCode2));
		}

		private void dex(Expression expression_0, Expression expression_1)
		{
			if (expression_0 is ArrayIndexExpression)
			{
				ArrayIndexExpression arrayIndexExpression = (ArrayIndexExpression)expression_0;
				se6(arrayIndexExpression.Array);
				Emit(Instruction.CreateLdcI4(arrayIndexExpression.Index));
				se6(expression_1);
				Emit(Instruction.Create(OpCodes.Stelem_I4));
				return;
			}
			if (expression_0 is VariableExpression)
			{
				VariableExpression variableExpression = (VariableExpression)expression_0;
				se6(expression_1);
				StoreVar(variableExpression.Variable);
				return;
			}
			throw new NotSupportedException();
		}

		private void Nes(Statement statement_0)
		{
			if (statement_0 is AssignmentStatement)
			{
				AssignmentStatement assignmentStatement = (AssignmentStatement)statement_0;
				dex(assignmentStatement.Target, assignmentStatement.Value);
				return;
			}
			if (statement_0 is LoopStatement)
			{
				LoopStatement loopStatement = (LoopStatement)statement_0;
				Local local = new Local(Method.Module.CorLibTypes.Int32);
				Method.Body.Variables.Add(local);
				Instruction instruction = OpCodes.Ldloc.ToInstruction(local);
				Instruction instruction2 = OpCodes.Nop.ToInstruction();
				Instruction instruction3 = OpCodes.Nop.ToInstruction();
				Emit(OpCodes.Ldc_I4_0.ToInstruction());
				Emit(OpCodes.Stloc.ToInstruction(local));
				Emit(instruction);
				Emit(Instruction.CreateLdcI4(loopStatement.Limit));
				Emit(OpCodes.Blt.ToInstruction(instruction3));
				Emit(OpCodes.Br.ToInstruction(instruction2));
				Emit(instruction3);
				foreach (Statement statement in loopStatement.Statements)
				{
					Nes(statement);
				}
				Emit(OpCodes.Ldc_I4_1.ToInstruction());
				Emit(OpCodes.Ldloc.ToInstruction(local));
				Emit(OpCodes.Add.ToInstruction());
				Emit(OpCodes.Stloc.ToInstruction(local));
				Emit(OpCodes.Br.ToInstruction(instruction));
				Emit(instruction2);
				return;
			}
			if (statement_0 is StatementBlock)
			{
				foreach (Statement statement2 in ((StatementBlock)statement_0).Statements)
				{
					Nes(statement2);
				}
				return;
			}
			throw new NotSupportedException();
		}
	}
}
