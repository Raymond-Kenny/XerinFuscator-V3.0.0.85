using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Confuser.DynCipher.AST;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Confuser.DynCipher.Generation
{
	public class CILCodeGen
	{
		private readonly Dictionary<string, Local> WF4 = new Dictionary<string, Local>();

		[CompilerGenerated]
		private MethodDef HFn;

		[CompilerGenerated]
		private IList<Instruction> rFh;

		public MethodDef Method
		{
			[CompilerGenerated]
			get
			{
				return HFn;
			}
			[CompilerGenerated]
			private set
			{
				HFn = value;
			}
		}

		public IList<Instruction> Instructions
		{
			[CompilerGenerated]
			get
			{
				return rFh;
			}
			[CompilerGenerated]
			private set
			{
				rFh = value;
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
			Local value;
			if (!WF4.TryGetValue(variable_0.Name, out value))
			{
				value = new Local(Method.Module.CorLibTypes.UInt32);
				value.Name = variable_0.Name;
				WF4[variable_0.Name] = value;
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
			foreach (Local value in WF4.Values)
			{
				cilBody_0.InitLocals = true;
				cilBody_0.Variables.Add(value);
			}
		}

		public void method_0(Expression expression_0)
		{
			PF1(expression_0);
		}

		public void method_1(Statement statement_0)
		{
			HFx(statement_0);
		}

		private void PF1(Expression expression_0)
		{
			if (expression_0 is ArrayIndexExpression)
			{
				ArrayIndexExpression arrayIndexExpression = (ArrayIndexExpression)expression_0;
				PF1(arrayIndexExpression.Array);
				Emit(Instruction.CreateLdcI4(arrayIndexExpression.Index));
				Emit(Instruction.Create(OpCodes.Ldelem_U4));
				return;
			}
			if (!(expression_0 is BinOpExpression))
			{
				if (expression_0 is UnaryOpExpression)
				{
					UnaryOpExpression unaryOpExpression = (UnaryOpExpression)expression_0;
					PF1(unaryOpExpression.Value);
					OpCode opCode;
					switch (unaryOpExpression.Operation)
					{
					default:
						throw new NotSupportedException();
					case UnaryOps.Negate:
						opCode = OpCodes.Neg;
						break;
					case UnaryOps.Not:
						opCode = OpCodes.Not;
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
			PF1(binOpExpression.Left);
			PF1(binOpExpression.Right);
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

		private void lFv(Expression expression_0, Expression expression_1)
		{
			if (expression_0 is ArrayIndexExpression)
			{
				ArrayIndexExpression arrayIndexExpression = (ArrayIndexExpression)expression_0;
				PF1(arrayIndexExpression.Array);
				Emit(Instruction.CreateLdcI4(arrayIndexExpression.Index));
				PF1(expression_1);
				Emit(Instruction.Create(OpCodes.Stelem_I4));
				return;
			}
			if (expression_0 is VariableExpression)
			{
				VariableExpression variableExpression = (VariableExpression)expression_0;
				PF1(expression_1);
				StoreVar(variableExpression.Variable);
				return;
			}
			throw new NotSupportedException();
		}

		private void HFx(Statement statement_0)
		{
			if (!(statement_0 is AssignmentStatement))
			{
				if (!(statement_0 is LoopStatement))
				{
					if (statement_0 is StatementBlock)
					{
						foreach (Statement statement in ((StatementBlock)statement_0).Statements)
						{
							HFx(statement);
						}
						return;
					}
					throw new NotSupportedException();
				}
				LoopStatement loopStatement = (LoopStatement)statement_0;
				Instruction instruction = Instruction.Create(OpCodes.Nop);
				Instruction instruction2 = Instruction.Create(OpCodes.Dup);
				Emit(Instruction.CreateLdcI4(loopStatement.Begin));
				Emit(Instruction.Create(OpCodes.Br, instruction2));
				Emit(Instruction.CreateLdcI4(loopStatement.Begin));
				Emit(instruction);
				foreach (Statement statement2 in loopStatement.Statements)
				{
					HFx(statement2);
				}
				Emit(Instruction.CreateLdcI4(1));
				Emit(Instruction.Create(OpCodes.Add));
				Emit(instruction2);
				Emit(Instruction.CreateLdcI4(loopStatement.Limit));
				Emit(Instruction.Create(OpCodes.Blt, instruction));
				Emit(Instruction.Create(OpCodes.Pop));
			}
			else
			{
				AssignmentStatement assignmentStatement = (AssignmentStatement)statement_0;
				lFv(assignmentStatement.Target, assignmentStatement.Value);
			}
		}
	}
}
