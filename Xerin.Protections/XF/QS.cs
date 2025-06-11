using System;
using System.Collections.Generic;
using Confuser.DynCipher.AST;
using Confuser.DynCipher.Generation;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Generator;

namespace XF
{
	internal class QS : EH
	{
		private class jw5 : CILCodeGen
		{
			private readonly Instruction[] TwN;

			public jw5(Instruction[] instruction_0, MethodDef methodDef_0, IList<Instruction> ilist_0)
				: base(methodDef_0, ilist_0)
			{
				TwN = instruction_0;
			}

			protected override void LoadVar(Variable variable_0)
			{
				if (variable_0.Name == "{RESULT}")
				{
					Instruction[] twN = TwN;
					foreach (Instruction instruction in twN)
					{
						Emit(instruction);
					}
				}
				else
				{
					base.LoadVar(variable_0);
				}
			}
		}

		private readonly Dictionary<MethodDef, Tuple<Expression, Func<int, int>>> YW = new Dictionary<MethodDef, Tuple<Expression, Func<int, int>>>();

		public Instruction[] sP0(MethodDef methodDef_0, x29 x29_0, Instruction[] instruction_0)
		{
			Tuple<Expression, Func<int, int>> tuple = @if(x29_0, methodDef_0);
			List<Instruction> list = new List<Instruction>();
			new jw5(instruction_0, x29_0.K2k, list).method_0(tuple.Item1);
			methodDef_0.Body.MaxStack += (ushort)x29_0.L27;
			return list.ToArray();
		}

		public int xPQ(MethodDef methodDef_0, x29 x29_0, int int_0)
		{
			Tuple<Expression, Func<int, int>> tuple = @if(x29_0, methodDef_0);
			return tuple.Item2(int_0);
		}

		private void sE(RandomGenerator randomGenerator_0, Expression expression_0, Expression expression_1, int int_0, out Expression expression_2, out Expression expression_3)
		{
			ExpressionGenerator.GeneratePair(randomGenerator_0, expression_0, expression_1, int_0, out expression_2, out expression_3);
		}

		private void xt(x29 x29_0, CilBody cilBody_0, out Func<int, int> func_0, out Expression expression_0)
		{
			Variable variable = new Variable("{VAR}");
			Variable variable2 = new Variable("{RESULT}");
			sE(x29_0.d2r, new VariableExpression
			{
				Variable = variable
			}, new VariableExpression
			{
				Variable = variable2
			}, x29_0.L27, out var expression_1, out expression_0);
			func_0 = new DMCodeGen(typeof(int), new Tuple<string, Type>[1] { Tuple.Create("{VAR}", typeof(int)) }).method_0(expression_1).Compile<Func<int, int>>();
		}

		private Tuple<Expression, Func<int, int>> @if(x29 x29_0, MethodDef methodDef_0)
		{
			if (!YW.TryGetValue(methodDef_0, out var value))
			{
				xt(x29_0, methodDef_0.Body, out var func_, out var expression_);
				value = (YW[methodDef_0] = Tuple.Create(expression_, func_));
			}
			return value;
		}
	}
}
