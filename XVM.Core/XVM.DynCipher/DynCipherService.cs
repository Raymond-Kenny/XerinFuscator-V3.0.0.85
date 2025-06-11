using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XF;
using XVM.Core;
using XVM.Core.Services;
using XVM.DynCipher.AST;
using XVM.DynCipher.Generation;

namespace XVM.DynCipher
{
	public class DynCipherService
	{
		private class CLc : CILCodeGen
		{
			private readonly Local DLL;

			public CLc(Local local_0, MethodDef methodDef_0, IList<Instruction> ilist_0)
				: base(methodDef_0, ilist_0)
			{
				DLL = local_0;
			}

			protected override Local Var(Variable variable_0)
			{
				if (!(variable_0.Name == "{RESULT}"))
				{
					return base.Var(variable_0);
				}
				return DLL;
			}
		}

		public void GenerateCipherPair(RandomGenerator randomGenerator_0, out StatementBlock statementBlock_0, out StatementBlock statementBlock_1)
		{
			HuN.Cuj(randomGenerator_0, out statementBlock_0, out statementBlock_1);
		}

		public void GenerateExpressionPair(RandomGenerator randomGenerator_0, Expression expression_0, Expression expression_1, int int_0, out Expression expression_2, out Expression expression_3)
		{
			Tum.vuT(randomGenerator_0, expression_0, expression_1, int_0, out expression_2, out expression_3);
		}

		public void GenerateExpressionMutation(RandomGenerator randomGenerator_0, MethodDef methodDef_0, Local local_0, IList<Instruction> ilist_0, int int_0, int int_1)
		{
			new List<Instruction>();
			Variable variable = new Variable("{VAR}");
			Variable variable2 = new Variable("{RESULT}");
			GenerateExpressionPair(randomGenerator_0, new VariableExpression
			{
				Variable = variable
			}, new VariableExpression
			{
				Variable = variable2
			}, int_1, out var expression_, out var expression_2);
			CilBody body = methodDef_0.Body;
			body.MaxStack += (ushort)int_1;
			body.InitLocals = true;
			IList<Instruction> list = new List<Instruction>();
			CLc cLc = new CLc(local_0, methodDef_0, list);
			cLc.method_0(expression_2);
			Func<int, int> func = new DMCodeGen(typeof(int), new Tuple<string, Type>[1] { Tuple.Create("{VAR}", typeof(int)) }).method_0(expression_).Compile<Func<int, int>>();
			int value = func(int_0);
			ilist_0.Add(Instruction.CreateLdcI4(value));
			ilist_0.Add(Instruction.Create(OpCodes.Stloc, local_0));
			ilist_0.AddRange(list);
		}

		public void GenerateStatementMutation(RandomGenerator randomGenerator_0, MethodDef methodDef_0, Local local_0, IList<Instruction> ilist_0, int int_0, int int_1)
		{
			new List<Instruction>();
			Variable variable = new Variable("{VAR}");
			Variable variable2 = new Variable("{RESULT}");
			IuS.XuU(randomGenerator_0, new VariableExpression
			{
				Variable = variable
			}, new VariableExpression
			{
				Variable = variable2
			}, int_1, out var loopStatement_, out var loopStatement_2);
			CilBody body = methodDef_0.Body;
			body.MaxStack += (ushort)int_1;
			body.InitLocals = true;
			IList<Instruction> list = new List<Instruction>();
			CLc cLc = new CLc(local_0, methodDef_0, list);
			cLc.method_1(loopStatement_2);
			Func<int, int> func = new DMCodeGen(typeof(int), new Tuple<string, Type>[1] { Tuple.Create("{VAR}", typeof(int)) }).method_1(loopStatement_).method_0(new VariableExpression
			{
				Variable = variable
			}).Compile<Func<int, int>>();
			int value = func(int_0);
			ilist_0.Add(Instruction.CreateLdcI4(value));
			ilist_0.Add(Instruction.Create(OpCodes.Stloc, local_0));
			ilist_0.AddRange(list);
			ilist_0.Add(OpCodes.Ldloc.ToInstruction(local_0));
		}
	}
}
