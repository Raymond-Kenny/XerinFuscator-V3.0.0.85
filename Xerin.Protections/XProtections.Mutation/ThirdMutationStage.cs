using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Confuser.DynCipher;
using Confuser.DynCipher.AST;
using Confuser.DynCipher.Generation;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Context;
using XCore.Generator;
using XCore.Protections;
using XCore.Utils;
using XF;

namespace XProtections.Mutation
{
	public class ThirdMutationStage : Protection, IDynCipherService
	{
		private class vmX : CILCodeGen
		{
			private readonly Local Gmy;

			public vmX(Local local_0, MethodDef methodDef_0, IList<Instruction> ilist_0)
				: base(methodDef_0, ilist_0)
			{
				Gmy = local_0;
			}

			protected override Local Var(Variable variable_0)
			{
				if (!(variable_0.Name == "{RESULT}"))
				{
					return base.Var(variable_0);
				}
				return Gmy;
			}
		}

		[Serializable]
		[CompilerGenerated]
		private sealed class lmg
		{
			public static readonly lmg wmj;

			public static Func<Instruction, bool> Bm1;

			public static Func<Local, bool> RmS;

			public static Func<Instruction, bool> Pmb;

			public static Func<Local, bool> tmE;

			static lmg()
			{
				wmj = new lmg();
			}

			internal bool gmo(Instruction instruction_0)
			{
				return instruction_0.IsLdcI4();
			}

			internal bool Nmn(Local local_0)
			{
				return !local_0.Type.IsValueType;
			}

			internal bool GmK(Instruction instruction_0)
			{
				return instruction_0.IsLdcI4();
			}

			internal bool amG(Local local_0)
			{
				return !local_0.Type.IsValueType;
			}
		}

		private List<(MethodDef, int)> VxU = new List<(MethodDef, int)>();

		private RandomGenerator cxk = new RandomGenerator(GGeneration.GenerateGuidStartingWithLetter(), GGeneration.GenerateGuidStartingWithLetter());

		private Random Dxa = new Random();

		public override string name => "Strong mutation stage";

		public override int number => 3;

		public void GenerateCipherPair(RandomGenerator randomGenerator_0, out StatementBlock statementBlock_0, out StatementBlock statementBlock_1)
		{
			CipherGenerator.GeneratePair(randomGenerator_0, out statementBlock_0, out statementBlock_1);
		}

		public void GenerateExpressionPair(RandomGenerator randomGenerator_0, Expression expression_0, Expression expression_1, int int_0, out Expression expression_2, out Expression expression_3)
		{
			ExpressionGenerator.GeneratePair(randomGenerator_0, expression_0, expression_1, int_0, out expression_2, out expression_3);
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
			vmX vmX = new vmX(local_0, methodDef_0, list);
			vmX.method_0(expression_2);
			Func<int, int> func = new DMCodeGen(typeof(int), new Tuple<string, Type>[1] { Tuple.Create("{VAR}", typeof(int)) }).method_0(expression_).Compile<Func<int, int>>();
			int value = func(int_0);
			ilist_0.Add(Instruction.CreateLdcI4(value));
			ilist_0.Add(Instruction.Create(OpCodes.Stloc, local_0));
			ilist_0.Txh(list);
		}

		public void GenerateStatementMutation(RandomGenerator randomGenerator_0, MethodDef methodDef_0, Local local_0, IList<Instruction> ilist_0, int int_0, int int_1)
		{
			new List<Instruction>();
			Variable variable = new Variable("{VAR}");
			Variable variable2 = new Variable("{RESULT}");
			StatementGenerator.GeneratePair(randomGenerator_0, new VariableExpression
			{
				Variable = variable
			}, new VariableExpression
			{
				Variable = variable2
			}, int_1, out var loopStatement, out var loopStatement2);
			CilBody body = methodDef_0.Body;
			body.MaxStack += (ushort)int_1;
			body.InitLocals = true;
			IList<Instruction> list = new List<Instruction>();
			vmX vmX = new vmX(local_0, methodDef_0, list);
			vmX.method_1(loopStatement2);
			Func<int, int> func = new DMCodeGen(typeof(int), new Tuple<string, Type>[1] { Tuple.Create("{VAR}", typeof(int)) }).method_1(loopStatement).method_0(new VariableExpression
			{
				Variable = variable
			}).Compile<Func<int, int>>();
			int value = func(int_0);
			ilist_0.Add(Instruction.CreateLdcI4(value));
			ilist_0.Add(Instruction.Create(OpCodes.Stloc, local_0));
			ilist_0.Txh(list);
			ilist_0.Add(OpCodes.Ldloc.ToInstruction(local_0));
		}

		private void RxP(TypeDef typeDef_0, XContext xcontext_0)
		{
			ICorLibTypes corLibTypes = xcontext_0.Module.CorLibTypes;
			MethodDefUser methodDefUser = new MethodDefUser(GGeneration.GenerateGuidStartingWithLetter(), MethodSig.CreateStatic(corLibTypes.Int32, corLibTypes.Int32))
			{
				Body = new CilBody(),
				ImplAttributes = MethodImplAttributes.AggressiveInlining,
				Attributes = (MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig)
			};
			methodDefUser.excludeMethod(xcontext_0.Module);
			typeDef_0.Methods.Add(methodDefUser);
			int num = cxk.NextInt32(0, int.MaxValue);
			Local local = new Local(corLibTypes.Int32);
			methodDefUser.Body.Variables.Add(local);
			IList<Instruction> instructions = methodDefUser.Body.Instructions;
			instructions.Add(OpCodes.Ldarg_0.ToInstruction());
			int int_ = Dxa.Next(1, 3);
			Dxa.Next(0, 1);
			GenerateExpressionMutation(cxk, methodDefUser, local, instructions, num, int_);
			instructions.Add(OpCodes.Xor.ToInstruction());
			instructions.Add(OpCodes.Ret.ToInstruction());
			VxU.Add((methodDefUser, num));
		}

		public override void Execute(XContext xcontext_0)
		{
			foreach (TypeDef type in xcontext_0.Module.GetTypes())
			{
				foreach (MethodDef method in type.Methods)
				{
					if (!method.HasBody || method.DeclaringType.IsGlobalModuleType || method.MethodHasL2FAttribute())
					{
						continue;
					}
					DnlibUtils.Simplify(method);
					IList<Instruction> instructions = method.Body.Instructions;
					List<Instruction> list = instructions.Where((Instruction instruction_0) => instruction_0.IsLdcI4()).ToList();
					if (list.Count == 0)
					{
						continue;
					}
					int num = 1;
					if (1 > list.Count)
					{
						num = list.Count;
					}
					for (int num2 = 0; num2 < num; num2++)
					{
						RxP(xcontext_0.Module.GlobalType, xcontext_0);
					}
					List<Local> list2 = method.Body.Variables.Where((Local local_0) => !local_0.Type.IsValueType).ToList();
					_ = list2.Count > 0;
					foreach (Instruction item in list)
					{
						(MethodDef, int) tuple = VxU[cxk.NextInt32(0, VxU.Count)];
						int ldcI4Value = item.GetLdcI4Value();
						int value = ldcI4Value ^ tuple.Item2;
						List<Instruction> ilist_ = new List<Instruction>
						{
							Instruction.CreateLdcI4(value),
							OpCodes.Call.ToInstruction(tuple.Item1)
						};
						item.KxN(ilist_, method);
					}
					DnlibUtils.Optimize(method);
				}
			}
			VxU.Clear();
		}

		public void ExecuteFor(XContext xcontext_0, MethodDef methodDef_0)
		{
			TypeDef[] array = xcontext_0.Module.GetTypes().ToArray();
			foreach (TypeDef typeDef in array)
			{
				MethodDef[] array2 = typeDef.Methods.ToArray();
				foreach (MethodDef methodDef in array2)
				{
					if (methodDef != methodDef_0 || !methodDef_0.HasBody || !methodDef_0.Body.HasInstructions)
					{
						continue;
					}
					DnlibUtils.Simplify(methodDef_0);
					IList<Instruction> instructions = methodDef_0.Body.Instructions;
					List<Instruction> list = instructions.Where((Instruction instruction_0) => instruction_0.IsLdcI4()).ToList();
					if (list.Count == 0)
					{
						continue;
					}
					int num = 1;
					if (1 > list.Count)
					{
						num = list.Count;
					}
					for (int num2 = 0; num2 < num; num2++)
					{
						RxP(xcontext_0.Module.GlobalType, xcontext_0);
					}
					List<Local> list2 = methodDef_0.Body.Variables.Where((Local local_0) => !local_0.Type.IsValueType).ToList();
					_ = list2.Count > 0;
					foreach (Instruction item in list)
					{
						(MethodDef, int) tuple = VxU[cxk.NextInt32(0, VxU.Count)];
						int ldcI4Value = item.GetLdcI4Value();
						int value = ldcI4Value ^ tuple.Item2;
						List<Instruction> ilist_ = new List<Instruction>
						{
							Instruction.CreateLdcI4(value),
							OpCodes.Call.ToInstruction(tuple.Item1)
						};
						item.KxN(ilist_, methodDef_0);
					}
				}
			}
			DnlibUtils.Optimize(methodDef_0);
			VxU.Clear();
		}
	}
}
