using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using XVM.DynCipher.AST;

namespace XVM.DynCipher.Generation
{
	public class DMCodeGen
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class Nkt
		{
			public static readonly Nkt IkL;

			public static Func<Tuple<string, Type>, Type> ckk;

			static Nkt()
			{
				IkL = new Nkt();
			}

			internal Type Bkc(Tuple<string, Type> tuple_0)
			{
				return tuple_0.Item2;
			}
		}

		private readonly DynamicMethod XuL;

		private readonly ILGenerator Luk;

		private readonly Dictionary<string, LocalBuilder> huH = new Dictionary<string, LocalBuilder>();

		private readonly Dictionary<string, int> XuC;

		public DMCodeGen(Type type_0, Tuple<string, Type>[] tuple_0)
		{
			XuL = new DynamicMethod("", type_0, tuple_0.Select((Tuple<string, Type> tuple) => tuple.Item2).ToArray(), restrictedSkipVisibility: true);
			XuC = new Dictionary<string, int>();
			for (int num = 0; num < tuple_0.Length; num++)
			{
				XuC.Add(tuple_0[num].Item1, num);
			}
			Luk = XuL.GetILGenerator();
		}

		protected virtual LocalBuilder Var(Variable variable_0)
		{
			if (!huH.TryGetValue(variable_0.Name, out var value))
			{
				value = Luk.DeclareLocal(typeof(int));
				huH[variable_0.Name] = value;
			}
			return value;
		}

		protected virtual void LoadVar(Variable variable_0)
		{
			if (XuC.ContainsKey(variable_0.Name))
			{
				Luk.Emit(OpCodes.Ldarg, XuC[variable_0.Name]);
			}
			else
			{
				Luk.Emit(OpCodes.Ldloc, Var(variable_0));
			}
		}

		protected virtual void StoreVar(Variable variable_0)
		{
			if (!XuC.ContainsKey(variable_0.Name))
			{
				Luk.Emit(OpCodes.Stloc, Var(variable_0));
			}
			else
			{
				Luk.Emit(OpCodes.Starg, XuC[variable_0.Name]);
			}
		}

		public T Compile<T>()
		{
			Luk.Emit(OpCodes.Ret);
			return (T)(object)XuL.CreateDelegate(typeof(T));
		}

		public DMCodeGen method_0(Expression expression_0)
		{
			yuO(expression_0);
			return this;
		}

		public DMCodeGen method_1(Statement statement_0)
		{
			nuc(statement_0);
			return this;
		}

		private void yuO(Expression expression_0)
		{
			if (!(expression_0 is ArrayIndexExpression))
			{
				if (expression_0 is BinOpExpression)
				{
					BinOpExpression binOpExpression = (BinOpExpression)expression_0;
					yuO(binOpExpression.Left);
					yuO(binOpExpression.Right);
					OpCode opcode;
					switch (binOpExpression.Operation)
					{
					default:
						throw new NotSupportedException();
					case BinOps.Add:
						opcode = OpCodes.Add;
						break;
					case BinOps.Sub:
						opcode = OpCodes.Sub;
						break;
					case BinOps.Div:
						opcode = OpCodes.Div;
						break;
					case BinOps.Mul:
						opcode = OpCodes.Mul;
						break;
					case BinOps.Or:
						opcode = OpCodes.Or;
						break;
					case BinOps.And:
						opcode = OpCodes.And;
						break;
					case BinOps.Xor:
						opcode = OpCodes.Xor;
						break;
					case BinOps.Lsh:
						opcode = OpCodes.Shl;
						break;
					case BinOps.Rsh:
						opcode = OpCodes.Shr_Un;
						break;
					}
					Luk.Emit(opcode);
				}
				else if (expression_0 is UnaryOpExpression)
				{
					UnaryOpExpression unaryOpExpression = (UnaryOpExpression)expression_0;
					yuO(unaryOpExpression.Value);
					OpCode opcode2;
					switch (unaryOpExpression.Operation)
					{
					case UnaryOps.Not:
						opcode2 = OpCodes.Not;
						break;
					default:
						throw new NotSupportedException();
					case UnaryOps.Negate:
						opcode2 = OpCodes.Neg;
						break;
					}
					Luk.Emit(opcode2);
				}
				else if (expression_0 is LiteralExpression)
				{
					LiteralExpression literalExpression = (LiteralExpression)expression_0;
					Luk.Emit(OpCodes.Ldc_I4, (int)literalExpression.Value);
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
			}
			else
			{
				ArrayIndexExpression arrayIndexExpression = (ArrayIndexExpression)expression_0;
				yuO(arrayIndexExpression.Array);
				Luk.Emit(OpCodes.Ldc_I4, arrayIndexExpression.Index);
				Luk.Emit(OpCodes.Ldelem_U4);
			}
		}

		private void Uut(Expression expression_0, Expression expression_1)
		{
			if (expression_0 is ArrayIndexExpression)
			{
				ArrayIndexExpression arrayIndexExpression = (ArrayIndexExpression)expression_0;
				yuO(arrayIndexExpression.Array);
				Luk.Emit(OpCodes.Ldc_I4, arrayIndexExpression.Index);
				yuO(expression_1);
				Luk.Emit(OpCodes.Stelem_I4);
				return;
			}
			if (expression_0 is VariableExpression)
			{
				VariableExpression variableExpression = (VariableExpression)expression_0;
				yuO(expression_1);
				StoreVar(variableExpression.Variable);
				return;
			}
			throw new NotSupportedException();
		}

		private void nuc(Statement statement_0)
		{
			if (!(statement_0 is AssignmentStatement))
			{
				if (!(statement_0 is LoopStatement))
				{
					if (statement_0 is StatementBlock)
					{
						foreach (Statement statement in ((StatementBlock)statement_0).Statements)
						{
							nuc(statement);
						}
						return;
					}
					throw new NotSupportedException();
				}
				LoopStatement loopStatement = (LoopStatement)statement_0;
				LocalBuilder local = Luk.DeclareLocal(typeof(int));
				Label label = Luk.DefineLabel();
				Label label2 = Luk.DefineLabel();
				Label label3 = Luk.DefineLabel();
				Luk.Emit(OpCodes.Ldc_I4_0);
				Luk.Emit(OpCodes.Stloc, local);
				Luk.MarkLabel(label);
				Luk.Emit(OpCodes.Ldloc, local);
				Luk.Emit(OpCodes.Ldc_I4, loopStatement.Limit);
				Luk.Emit(OpCodes.Blt, label2);
				Luk.Emit(OpCodes.Br, label3);
				Luk.MarkLabel(label2);
				foreach (Statement statement2 in loopStatement.Statements)
				{
					nuc(statement2);
				}
				Luk.Emit(OpCodes.Ldc_I4_1);
				Luk.Emit(OpCodes.Ldloc, local);
				Luk.Emit(OpCodes.Add);
				Luk.Emit(OpCodes.Stloc, local);
				Luk.Emit(OpCodes.Br, label);
				Luk.MarkLabel(label3);
				Luk.Emit(OpCodes.Nop);
			}
			else
			{
				AssignmentStatement assignmentStatement = (AssignmentStatement)statement_0;
				Uut(assignmentStatement.Target, assignmentStatement.Value);
			}
		}
	}
}
