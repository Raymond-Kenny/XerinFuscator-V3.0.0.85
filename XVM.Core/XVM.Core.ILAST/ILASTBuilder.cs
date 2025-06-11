#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.ILAST;
using XVM.Core.CFG;

namespace XVM.Core.ILAST
{
	public class ILASTBuilder
	{
		private struct qlF
		{
			public ILASTVariable[] jlv;

			public ILASTTree Tld;
		}

		[Serializable]
		[CompilerGenerated]
		private sealed class elB
		{
			public static readonly elB YlY;

			public static Func<BasicBlock<CILInstrList>, Instruction> nlg;

			public static Func<BasicBlock<CILInstrList>, BasicBlock<CILInstrList>> Hlb;

			public static Func<KeyValuePair<Instruction, BasicBlock<CILInstrList>>, Instruction> tlp;

			static elB()
			{
				YlY = new elB();
			}

			internal Instruction rl7(BasicBlock<CILInstrList> basicBlock_0)
			{
				return basicBlock_0.Content[0];
			}

			internal BasicBlock<CILInstrList> DlD(BasicBlock<CILInstrList> basicBlock_0)
			{
				return basicBlock_0;
			}

			internal Instruction oly(KeyValuePair<Instruction, BasicBlock<CILInstrList>> keyValuePair_0)
			{
				return keyValuePair_0.Key;
			}
		}

		[CompilerGenerated]
		private sealed class Mlr
		{
			public ILASTBuilder Rl6;

			public Dictionary<BasicBlock<CILInstrList>, BasicBlock<ILASTTree>> ylx;

			public Dictionary<Instruction, BasicBlock<ILASTTree>> plQ;

			public Func<Instruction, IBasicBlock> Hlf;

			internal ILASTTree fl3(BasicBlock<CILInstrList> basicBlock_0)
			{
				return Rl6.Ijc[basicBlock_0].Tld;
			}

			internal BasicBlock<ILASTTree> ilX(KeyValuePair<Instruction, BasicBlock<CILInstrList>> keyValuePair_0)
			{
				return ylx[keyValuePair_0.Value];
			}

			internal IBasicBlock Hln(Instruction instruction_0)
			{
				return plQ[instruction_0];
			}
		}

		[CompilerGenerated]
		private sealed class Yli
		{
			public Stack<ILASTVariable> ll8;

			internal IILASTNode[] flJ(int int_0)
			{
				IILASTNode[] array = new IILASTNode[int_0];
				for (int num = int_0 - 1; num >= 0; num--)
				{
					array[num] = ll8.Pop();
				}
				return array;
			}
		}

		private MethodDef tjK;

		private CilBody Jj1;

		private ScopeBlock gjj;

		private IList<BasicBlock<CILInstrList>> gjO;

		private Dictionary<Instruction, BasicBlock<CILInstrList>> wjt;

		private Dictionary<BasicBlock<CILInstrList>, qlF> Ijc;

		private List<ILASTExpression> GjL;

		private ILASTBuilder(MethodDef methodDef_0, CilBody cilBody_0, ScopeBlock scopeBlock_0)
		{
			tjK = methodDef_0;
			Jj1 = cilBody_0;
			gjj = scopeBlock_0;
			gjO = scopeBlock_0.GetBasicBlocks().Cast<BasicBlock<CILInstrList>>().ToList();
			wjt = gjO.ToDictionary((BasicBlock<CILInstrList> basicBlock_0) => basicBlock_0.Content[0], (BasicBlock<CILInstrList> basicBlock_0) => basicBlock_0);
			Ijc = new Dictionary<BasicBlock<CILInstrList>, qlF>();
			GjL = new List<ILASTExpression>();
			Debug.Assert(gjO.Count > 0);
		}

		public static void BuildAST(MethodDef methodDef_0, CilBody cilBody_0, ScopeBlock scopeBlock_0)
		{
			ILASTBuilder iLASTBuilder = new ILASTBuilder(methodDef_0, cilBody_0, scopeBlock_0);
			scopeBlock_0.GetBasicBlocks().Cast<BasicBlock<CILInstrList>>().ToList();
			iLASTBuilder.qjw();
		}

		private void qjw()
		{
			ljW();
			jjN();
			Dictionary<BasicBlock<CILInstrList>, BasicBlock<ILASTTree>> ylx = gjj.UpdateBasicBlocks((BasicBlock<CILInstrList> basicBlock_0) => Ijc[basicBlock_0].Tld);
			Dictionary<Instruction, BasicBlock<ILASTTree>> plQ = wjt.ToDictionary((KeyValuePair<Instruction, BasicBlock<CILInstrList>> keyValuePair_0) => keyValuePair_0.Key, (KeyValuePair<Instruction, BasicBlock<CILInstrList>> keyValuePair_0) => ylx[keyValuePair_0.Value]);
			foreach (ILASTExpression item in GjL)
			{
				if (item.Operand is Instruction)
				{
					item.Operand = plQ[(Instruction)item.Operand];
					continue;
				}
				item.Operand = ((IEnumerable<Instruction>)(Instruction[])item.Operand).Select((Func<Instruction, IBasicBlock>)((Instruction instruction_0) => plQ[instruction_0])).ToArray();
			}
		}

		private void ljW()
		{
			Stack<BasicBlock<CILInstrList>> stack = new Stack<BasicBlock<CILInstrList>>();
			CjE(stack);
			HashSet<BasicBlock<CILInstrList>> hashSet = new HashSet<BasicBlock<CILInstrList>>();
			while (stack.Count > 0)
			{
				BasicBlock<CILInstrList> basicBlock = stack.Pop();
				if (hashSet.Contains(basicBlock))
				{
					continue;
				}
				hashSet.Add(basicBlock);
				Debug.Assert(Ijc.ContainsKey(basicBlock));
				qlF value = Ijc[basicBlock];
				Debug.Assert(value.Tld == null);
				ILASTTree iLASTTree = fj2(basicBlock.Content, value.jlv);
				ILASTVariable[] stackRemains = iLASTTree.StackRemains;
				value.Tld = iLASTTree;
				Ijc[basicBlock] = value;
				foreach (BasicBlock<CILInstrList> target in basicBlock.Targets)
				{
					if (Ijc.TryGetValue(target, out var value2))
					{
						if (value2.jlv.Length != stackRemains.Length)
						{
							throw new InvalidProgramException("Inconsistent stack depth.");
						}
					}
					else
					{
						ILASTVariable[] array = new ILASTVariable[stackRemains.Length];
						for (int i = 0; i < array.Length; i++)
						{
							array[i] = new ILASTVariable
							{
								Name = $"ph_{target.Id:x2}_{i:x2}",
								Type = stackRemains[i].Type,
								VariableType = ILASTVariableType.PhiVar
							};
						}
						value2 = new qlF
						{
							jlv = array
						};
						Ijc[target] = value2;
					}
					stack.Push(target);
				}
			}
		}

		private void CjE(Stack<BasicBlock<CILInstrList>> stack_0)
		{
			for (int i = 0; i < Jj1.ExceptionHandlers.Count; i++)
			{
				ExceptionHandler exceptionHandler = Jj1.ExceptionHandlers[i];
				Ijc[wjt[exceptionHandler.TryStart]] = new qlF
				{
					jlv = new ILASTVariable[0]
				};
				BasicBlock<CILInstrList> basicBlock = wjt[exceptionHandler.HandlerStart];
				stack_0.Push(basicBlock);
				if (exceptionHandler.HandlerType == ExceptionHandlerType.Fault || exceptionHandler.HandlerType == ExceptionHandlerType.Finally)
				{
					Ijc[basicBlock] = new qlF
					{
						jlv = new ILASTVariable[0]
					};
					continue;
				}
				ASTType type = TypeInference.smethod_0(exceptionHandler.CatchType.ToTypeSig());
				if (!Ijc.ContainsKey(basicBlock))
				{
					ILASTVariable iLASTVariable = new ILASTVariable
					{
						Name = $"ex_{i:x2}",
						Type = type,
						VariableType = ILASTVariableType.ExceptionVar,
						Annotation = exceptionHandler
					};
					Ijc[basicBlock] = new qlF
					{
						jlv = new ILASTVariable[1] { iLASTVariable }
					};
				}
				else
				{
					Debug.Assert(Ijc[basicBlock].jlv.Length == 1);
				}
				if (exceptionHandler.FilterStart != null)
				{
					ILASTVariable iLASTVariable2 = new ILASTVariable
					{
						Name = $"ef_{i:x2}",
						Type = type,
						VariableType = ILASTVariableType.FilterVar,
						Annotation = exceptionHandler
					};
					BasicBlock<CILInstrList> basicBlock2 = wjt[exceptionHandler.FilterStart];
					stack_0.Push(basicBlock2);
					Ijc[basicBlock2] = new qlF
					{
						jlv = new ILASTVariable[1] { iLASTVariable2 }
					};
				}
			}
			Ijc[gjO[0]] = new qlF
			{
				jlv = new ILASTVariable[0]
			};
			stack_0.Push(gjO[0]);
			foreach (BasicBlock<CILInstrList> item in gjO)
			{
				if (item.Sources.Count <= 0 && !stack_0.Contains(item))
				{
					Ijc[item] = new qlF
					{
						jlv = new ILASTVariable[0]
					};
					stack_0.Push(item);
				}
			}
		}

		private void jjN()
		{
			foreach (KeyValuePair<BasicBlock<CILInstrList>, qlF> item2 in Ijc)
			{
				BasicBlock<CILInstrList> key = item2.Key;
				qlF value = item2.Value;
				if (key.Sources.Count == 0 && value.jlv.Length != 0)
				{
					Debug.Assert(value.jlv.Length == 1);
					ILASTPhi iLASTPhi = new ILASTPhi();
					iLASTPhi.Variable = value.jlv[0];
					iLASTPhi.SourceVariables = new ILASTVariable[1] { value.jlv[0] };
					ILASTPhi item = iLASTPhi;
					value.Tld.Insert(0, item);
				}
				else
				{
					if (value.jlv.Length == 0)
					{
						continue;
					}
					for (int i = 0; i < value.jlv.Length; i++)
					{
						ILASTPhi iLASTPhi2 = new ILASTPhi
						{
							Variable = value.jlv[i]
						};
						iLASTPhi2.SourceVariables = new ILASTVariable[key.Sources.Count];
						for (int j = 0; j < iLASTPhi2.SourceVariables.Length; j++)
						{
							iLASTPhi2.SourceVariables[j] = Ijc[key.Sources[j]].Tld.StackRemains[i];
						}
						value.Tld.Insert(0, iLASTPhi2);
					}
				}
			}
		}

		private ILASTTree fj2(CILInstrList cilinstrList_0, ILASTVariable[] ilastvariable_0)
		{
			ILASTTree iLASTTree = new ILASTTree();
			Stack<ILASTVariable> ll8 = new Stack<ILASTVariable>(ilastvariable_0);
			Func<int, IILASTNode[]> func = delegate(int int_0)
			{
				IILASTNode[] array = new IILASTNode[int_0];
				for (int num = int_0 - 1; num >= 0; num--)
				{
					array[num] = ll8.Pop();
				}
				return array;
			};
			List<Instruction> list = new List<Instruction>();
			foreach (Instruction item in cilinstrList_0)
			{
				if (item.OpCode.OpCodeType == OpCodeType.Prefix)
				{
					list.Add(item);
					continue;
				}
				int pushes;
				int pops;
				ILASTExpression iLASTExpression;
				if (item.OpCode.Code != Code.Dup)
				{
					item.CalculateStackUsage(tjK.ReturnType.ElementType != ElementType.Void, out pushes, out pops);
					Debug.Assert(pushes == 0 || pushes == 1);
					if (pops == -1)
					{
						ll8.Clear();
						pops = 0;
					}
					iLASTExpression = new ILASTExpression
					{
						ILCode = item.OpCode.Code,
						Operand = item.Operand,
						Arguments = func(pops)
					};
					if (iLASTExpression.Operand is Instruction || iLASTExpression.Operand is Instruction[])
					{
						GjL.Add(iLASTExpression);
					}
				}
				else
				{
					pops = 1;
					pushes = 1;
					ILASTVariable iLASTVariable = ll8.Peek();
					ILASTExpression iLASTExpression2 = new ILASTExpression();
					iLASTExpression2.ILCode = Code.Dup;
					iLASTExpression2.Operand = null;
					iLASTExpression2.Arguments = new IILASTNode[1] { iLASTVariable };
					iLASTExpression = iLASTExpression2;
				}
				iLASTExpression.CILInstr = item;
				if (list.Count > 0)
				{
					iLASTExpression.Prefixes = list.ToArray();
					list.Clear();
				}
				if (pushes != 1)
				{
					iLASTTree.Add(iLASTExpression);
					continue;
				}
				ILASTVariable iLASTVariable2 = new ILASTVariable
				{
					Name = $"s_{item.Offset:x4}",
					VariableType = ILASTVariableType.StackVar
				};
				ll8.Push(iLASTVariable2);
				iLASTTree.Add(new ILASTAssignment
				{
					Variable = iLASTVariable2,
					Value = iLASTExpression
				});
			}
			iLASTTree.StackRemains = ll8.Reverse().ToArray();
			return iLASTTree;
		}
	}
}
