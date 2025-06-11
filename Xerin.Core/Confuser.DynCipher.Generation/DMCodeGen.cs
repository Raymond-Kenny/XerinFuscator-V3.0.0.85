using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using Confuser.DynCipher.AST;

namespace Confuser.DynCipher.Generation
{
	public class DMCodeGen
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class h6E
		{
			public static readonly h6E w6p;

			public static Func<Tuple<string, Type>, Type> B6B;

			static h6E()
			{
				w6p = new h6E();
			}

			internal Type B6g(Tuple<string, Type> tuple_0)
			{
				return tuple_0.Item2;
			}
		}

		private readonly DynamicMethod UFm;

		private readonly ILGenerator xFA;

		private readonly Dictionary<string, LocalBuilder> XF9 = new Dictionary<string, LocalBuilder>();

		private readonly Dictionary<string, int> oFP;

		public DMCodeGen(Type type_0, Tuple<string, Type>[] tuple_0)
		{
			UFm = new DynamicMethod("", type_0, tuple_0.Select((Tuple<string, Type> tuple) => tuple.Item2).ToArray(), true);
			oFP = new Dictionary<string, int>();
			for (int num = 0; num < tuple_0.Length; num++)
			{
				oFP.Add(tuple_0[num].Item1, num);
			}
			xFA = UFm.GetILGenerator();
		}

		protected virtual LocalBuilder Var(Variable variable_0)
		{
			LocalBuilder value;
			if (!XF9.TryGetValue(variable_0.Name, out value))
			{
				value = xFA.DeclareLocal(typeof(int));
				XF9[variable_0.Name] = value;
			}
			return value;
		}

		protected virtual void LoadVar(Variable variable_0)
		{
			if (!oFP.ContainsKey(variable_0.Name))
			{
				xFA.Emit(OpCodes.Ldloc, Var(variable_0));
			}
			else
			{
				xFA.Emit(OpCodes.Ldarg, oFP[variable_0.Name]);
			}
		}

		protected virtual void StoreVar(Variable variable_0)
		{
			if (!oFP.ContainsKey(variable_0.Name))
			{
				xFA.Emit(OpCodes.Stloc, Var(variable_0));
			}
			else
			{
				xFA.Emit(OpCodes.Starg, oFP[variable_0.Name]);
			}
		}

		public T Compile<T>()
		{
			xFA.Emit(OpCodes.Ret);
			return (T)(object)UFm.CreateDelegate(typeof(T));
		}

		public DMCodeGen method_0(Expression expression_0)
		{
			PFZ(expression_0);
			return this;
		}

		public DMCodeGen method_1(Statement statement_0)
		{
			FFX(statement_0);
			return this;
		}

		private void PFZ(Expression expression_0)
		{
			if (!(expression_0 is ArrayIndexExpression))
			{
				if (expression_0 is BinOpExpression)
				{
					BinOpExpression binOpExpression = (BinOpExpression)expression_0;
					PFZ(binOpExpression.Left);
					PFZ(binOpExpression.Right);
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
					xFA.Emit(opcode);
				}
				else if (expression_0 is UnaryOpExpression)
				{
					UnaryOpExpression unaryOpExpression = (UnaryOpExpression)expression_0;
					PFZ(unaryOpExpression.Value);
					OpCode opcode2;
					switch (unaryOpExpression.Operation)
					{
					default:
						throw new NotSupportedException();
					case UnaryOps.Negate:
						opcode2 = OpCodes.Neg;
						break;
					case UnaryOps.Not:
						opcode2 = OpCodes.Not;
						break;
					}
					xFA.Emit(opcode2);
				}
				else if (!(expression_0 is LiteralExpression))
				{
					if (!(expression_0 is VariableExpression))
					{
						throw new NotSupportedException();
					}
					VariableExpression variableExpression = (VariableExpression)expression_0;
					LoadVar(variableExpression.Variable);
				}
				else
				{
					LiteralExpression literalExpression = (LiteralExpression)expression_0;
					xFA.Emit(OpCodes.Ldc_I4, (int)literalExpression.Value);
				}
			}
			else
			{
				ArrayIndexExpression arrayIndexExpression = (ArrayIndexExpression)expression_0;
				PFZ(arrayIndexExpression.Array);
				xFA.Emit(OpCodes.Ldc_I4, arrayIndexExpression.Index);
				xFA.Emit(OpCodes.Ldelem_U4);
			}
		}

		private void eFa(Expression expression_0, Expression expression_1)
		{
			if (expression_0 is ArrayIndexExpression)
			{
				ArrayIndexExpression arrayIndexExpression = (ArrayIndexExpression)expression_0;
				PFZ(arrayIndexExpression.Array);
				xFA.Emit(OpCodes.Ldc_I4, arrayIndexExpression.Index);
				PFZ(expression_1);
				xFA.Emit(OpCodes.Stelem_I4);
				return;
			}
			if (expression_0 is VariableExpression)
			{
				VariableExpression variableExpression = (VariableExpression)expression_0;
				PFZ(expression_1);
				StoreVar(variableExpression.Variable);
				return;
			}
			throw new NotSupportedException();
		}

		private void FFX(Statement statement_0)
		{
			if (!(statement_0 is AssignmentStatement))
			{
				if (!(statement_0 is LoopStatement))
				{
					if (!(statement_0 is StatementBlock))
					{
						throw new NotSupportedException();
					}
					{
						foreach (Statement statement in ((StatementBlock)statement_0).Statements)
						{
							FFX(statement);
						}
						return;
					}
				}
				LoopStatement loopStatement = (LoopStatement)statement_0;
				Label label = xFA.DefineLabel();
				Label label2 = xFA.DefineLabel();
				xFA.Emit(OpCodes.Ldc_I4, loopStatement.Begin);
				xFA.Emit(OpCodes.Br, label2);
				xFA.Emit(OpCodes.Ldc_I4, loopStatement.Begin);
				xFA.MarkLabel(label);
				foreach (Statement statement2 in loopStatement.Statements)
				{
					FFX(statement2);
				}
				xFA.Emit(OpCodes.Ldc_I4_1);
				xFA.Emit(OpCodes.Add);
				xFA.MarkLabel(label2);
				xFA.Emit(OpCodes.Dup);
				xFA.Emit(OpCodes.Ldc_I4, loopStatement.Limit);
				xFA.Emit(OpCodes.Blt, label);
				xFA.Emit(OpCodes.Pop);
			}
			else
			{
				AssignmentStatement assignmentStatement = (AssignmentStatement)statement_0;
				eFa(assignmentStatement.Target, assignmentStatement.Value);
			}
		}
	}
}
