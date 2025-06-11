using System;
using System.Collections.Generic;
using dnlib.DotNet.Emit;
using XVM.DynCipher.AST;
using XVM.DynCipher.Generation;

namespace XVM.Core.RTProtections.KroksCFlow
{
	public class ExpressionPredicate
	{
		private class joS : CILCodeGen
		{
			private readonly Local uoa;

			public joS(Local local_0, KroksContext kroksContext_0, IList<Instruction> ilist_0)
				: base(kroksContext_0.Method, ilist_0)
			{
				uoa = local_0;
			}

			protected override Local Var(Variable variable_0)
			{
				if (variable_0.Name == "{RESULT}")
				{
					return uoa;
				}
				return base.Var(variable_0);
			}
		}

		private readonly KroksContext vKf;

		private Func<int, int> zKi;

		private Expression SKJ;

		private bool SK8;

		private List<Instruction> qKz;

		private Expression I14;

		private Local P1e;

		public ExpressionPredicate(KroksContext kroksContext_0)
		{
			vKf = kroksContext_0;
		}

		public void Init(CilBody cilBody_0)
		{
			if (!SK8)
			{
				P1e = new Local(vKf.Method.Module.CorLibTypes.Int32);
				cilBody_0.Variables.Add(P1e);
				cilBody_0.InitLocals = true;
				qKQ(cilBody_0);
				SK8 = true;
			}
		}

		public void EmitSwitchLoad(IList<Instruction> ilist_0)
		{
			ilist_0.Add(Instruction.Create(OpCodes.Stloc, P1e));
			foreach (Instruction item in qKz)
			{
				ilist_0.Add(item.Clone());
			}
		}

		public int GetSwitchKey(int int_0)
		{
			return zKi(int_0);
		}

		private void qKQ(CilBody cilBody_0)
		{
			Variable variable = new Variable("{VAR}");
			Variable variable2 = new Variable("{RESULT}");
			vKf.DynCipher.GenerateExpressionPair(vKf.Random, new VariableExpression
			{
				Variable = variable
			}, new VariableExpression
			{
				Variable = variable2
			}, vKf.Depth, out SKJ, out I14);
			zKi = new DMCodeGen(typeof(int), new Tuple<string, Type>[1] { Tuple.Create("{VAR}", typeof(int)) }).method_0(SKJ).Compile<Func<int, int>>();
			qKz = new List<Instruction>();
			new joS(P1e, vKf, qKz).method_0(I14);
			cilBody_0.MaxStack += (ushort)vKf.Depth;
		}
	}
}
