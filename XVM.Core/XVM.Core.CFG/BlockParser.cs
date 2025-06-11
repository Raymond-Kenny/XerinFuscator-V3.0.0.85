#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Pdb;
using XF;

namespace XVM.Core.CFG
{
	public class BlockParser
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class RZZ
		{
			public static readonly RZZ DZU;

			public static Func<BasicBlock<CILInstrList>, IEnumerable<zE<Instruction, BasicBlock<CILInstrList>>>> VZh;

			public static Func<zE<Instruction, BasicBlock<CILInstrList>>, Instruction> NZP;

			public static Func<zE<Instruction, BasicBlock<CILInstrList>>, BasicBlock<CILInstrList>> nZF;

			static RZZ()
			{
				DZU = new RZZ();
			}

			internal IEnumerable<zE<Instruction, BasicBlock<CILInstrList>>> iZT(BasicBlock<CILInstrList> basicBlock_0)
			{
				RZv rZv = new RZv
				{
					TZB = basicBlock_0
				};
				return rZv.TZB.Content.Select(rZv.lZd);
			}

			internal Instruction mZS(zE<Instruction, BasicBlock<CILInstrList>> zE_0)
			{
				return zE_0.nL();
			}

			internal BasicBlock<CILInstrList> nZa(zE<Instruction, BasicBlock<CILInstrList>> zE_0)
			{
				return zE_0.VH();
			}
		}

		[CompilerGenerated]
		private sealed class RZv
		{
			public BasicBlock<CILInstrList> TZB;

			internal zE<Instruction, BasicBlock<CILInstrList>> lZd(Instruction instruction_0)
			{
				return new zE<Instruction, BasicBlock<CILInstrList>>(instruction_0, TZB);
			}
		}

		public static ScopeBlock Parse(MethodDef methodDef_0, CilBody cilBody_0)
		{
			cilBody_0.SimplifyMacros(methodDef_0.Parameters);
			rtK(cilBody_0);
			ft1(cilBody_0, out var hashSet_, out var hashSet_2);
			List<BasicBlock<CILInstrList>> list_ = itj(cilBody_0, hashSet_, hashSet_2);
			jtO(list_);
			return Ntt(cilBody_0, list_);
		}

		private static void rtK(CilBody cilBody_0)
		{
			SequencePoint sequencePoint = null;
			foreach (Instruction instruction in cilBody_0.Instructions)
			{
				if (instruction.SequencePoint != null)
				{
					sequencePoint = instruction.SequencePoint;
				}
				else
				{
					instruction.SequencePoint = sequencePoint;
				}
			}
		}

		private static void ft1(CilBody cilBody_0, out HashSet<Instruction> hashSet_0, out HashSet<Instruction> hashSet_1)
		{
			hashSet_0 = new HashSet<Instruction>();
			hashSet_1 = new HashSet<Instruction>();
			foreach (ExceptionHandler exceptionHandler in cilBody_0.ExceptionHandlers)
			{
				hashSet_0.Add(exceptionHandler.TryStart);
				if (exceptionHandler.TryEnd != null)
				{
					hashSet_0.Add(exceptionHandler.TryEnd);
				}
				hashSet_0.Add(exceptionHandler.HandlerStart);
				hashSet_1.Add(exceptionHandler.HandlerStart);
				if (exceptionHandler.HandlerEnd != null)
				{
					hashSet_0.Add(exceptionHandler.HandlerEnd);
				}
				if (exceptionHandler.FilterStart != null)
				{
					hashSet_0.Add(exceptionHandler.FilterStart);
					hashSet_1.Add(exceptionHandler.FilterStart);
				}
			}
			IList<Instruction> instructions = cilBody_0.Instructions;
			for (int i = 0; i < instructions.Count; i++)
			{
				Instruction instruction = instructions[i];
				if (!(instruction.Operand is Instruction))
				{
					if (instruction.Operand is Instruction[])
					{
						Instruction[] array = (Instruction[])instruction.Operand;
						foreach (Instruction item in array)
						{
							hashSet_0.Add(item);
						}
						if (i + 1 < cilBody_0.Instructions.Count)
						{
							hashSet_0.Add(cilBody_0.Instructions[i + 1]);
						}
					}
					else if ((instruction.OpCode.FlowControl == FlowControl.Throw || instruction.OpCode.FlowControl == FlowControl.Return) && i + 1 < cilBody_0.Instructions.Count)
					{
						hashSet_0.Add(cilBody_0.Instructions[i + 1]);
					}
				}
				else
				{
					hashSet_0.Add((Instruction)instruction.Operand);
					if (i + 1 < cilBody_0.Instructions.Count)
					{
						hashSet_0.Add(cilBody_0.Instructions[i + 1]);
					}
				}
			}
			if (instructions.Count > 0)
			{
				hashSet_0.Add(instructions[0]);
				hashSet_1.Add(instructions[0]);
			}
		}

		private static List<BasicBlock<CILInstrList>> itj(CilBody cilBody_0, HashSet<Instruction> hashSet_0, HashSet<Instruction> hashSet_1)
		{
			int num = 0;
			int num2 = -1;
			Instruction instruction = null;
			List<BasicBlock<CILInstrList>> list = new List<BasicBlock<CILInstrList>>();
			CILInstrList cILInstrList = new CILInstrList();
			for (int i = 0; i < cilBody_0.Instructions.Count; i++)
			{
				Instruction instruction2 = cilBody_0.Instructions[i];
				if (hashSet_0.Contains(instruction2))
				{
					if (instruction != null)
					{
						_ = cilBody_0.Instructions[i - 1];
						Debug.Assert(cILInstrList.Count > 0);
						list.Add(new BasicBlock<CILInstrList>(num2, cILInstrList));
						cILInstrList = new CILInstrList();
					}
					num2 = num++;
					instruction = instruction2;
				}
				cILInstrList.Add(instruction2);
			}
			if (list.Count == 0 || list[list.Count - 1].Id != num2)
			{
				_ = cilBody_0.Instructions[cilBody_0.Instructions.Count - 1];
				Debug.Assert(cILInstrList.Count > 0);
				list.Add(new BasicBlock<CILInstrList>(num2, cILInstrList));
			}
			return list;
		}

		private static void jtO(List<BasicBlock<CILInstrList>> list_0)
		{
			Dictionary<Instruction, BasicBlock<CILInstrList>> dictionary = list_0.SelectMany(delegate(BasicBlock<CILInstrList> basicBlock_0)
			{
				RZv rZv = new RZv();
				rZv.TZB = basicBlock_0;
				return rZv.TZB.Content.Select(rZv.lZd);
			}).ToDictionary((zE<Instruction, BasicBlock<CILInstrList>> zE_0) => zE_0.nL(), (zE<Instruction, BasicBlock<CILInstrList>> zE_0) => zE_0.VH());
			foreach (BasicBlock<CILInstrList> item in list_0)
			{
				foreach (Instruction item2 in item.Content)
				{
					if (item2.Operand is Instruction)
					{
						BasicBlock<CILInstrList> basicBlock = dictionary[(Instruction)item2.Operand];
						basicBlock.Sources.Add(item);
						item.Targets.Add(basicBlock);
					}
					else if (item2.Operand is Instruction[])
					{
						Instruction[] array = (Instruction[])item2.Operand;
						foreach (Instruction key in array)
						{
							BasicBlock<CILInstrList> basicBlock2 = dictionary[key];
							basicBlock2.Sources.Add(item);
							item.Targets.Add(basicBlock2);
						}
					}
				}
			}
			for (int num2 = 0; num2 < list_0.Count; num2++)
			{
				Instruction instruction = list_0[num2].Content.Last();
				if (instruction.OpCode.FlowControl != FlowControl.Branch && instruction.OpCode.FlowControl != FlowControl.Return && instruction.OpCode.FlowControl != FlowControl.Throw && num2 + 1 < list_0.Count)
				{
					BasicBlock<CILInstrList> basicBlock3 = list_0[num2];
					BasicBlock<CILInstrList> basicBlock4 = list_0[num2 + 1];
					if (!basicBlock3.Targets.Contains(basicBlock4))
					{
						basicBlock3.Targets.Add(basicBlock4);
						basicBlock4.Sources.Add(basicBlock3);
						basicBlock3.Content.Add(Instruction.Create(OpCodes.Br, basicBlock4.Content[0]));
					}
				}
			}
		}

		private static ScopeBlock Ntt(CilBody cilBody_0, List<BasicBlock<CILInstrList>> list_0)
		{
			Dictionary<ExceptionHandler, Tuple<ScopeBlock, ScopeBlock, ScopeBlock>> dictionary = new Dictionary<ExceptionHandler, Tuple<ScopeBlock, ScopeBlock, ScopeBlock>>();
			foreach (ExceptionHandler exceptionHandler in cilBody_0.ExceptionHandlers)
			{
				ScopeBlock item = new ScopeBlock(ScopeType.Try, exceptionHandler);
				ScopeBlock item2 = new ScopeBlock(ScopeType.Handler, exceptionHandler);
				if (exceptionHandler.FilterStart != null)
				{
					ScopeBlock item3 = new ScopeBlock(ScopeType.Filter, exceptionHandler);
					dictionary[exceptionHandler] = Tuple.Create(item, item2, item3);
				}
				else
				{
					dictionary[exceptionHandler] = Tuple.Create<ScopeBlock, ScopeBlock, ScopeBlock>(item, item2, null);
				}
			}
			ScopeBlock scopeBlock = new ScopeBlock();
			Stack<ScopeBlock> stack = new Stack<ScopeBlock>();
			stack.Push(scopeBlock);
			foreach (BasicBlock<CILInstrList> item4 in list_0)
			{
				Instruction instruction = item4.Content[0];
				foreach (ExceptionHandler exceptionHandler2 in cilBody_0.ExceptionHandlers)
				{
					Tuple<ScopeBlock, ScopeBlock, ScopeBlock> tuple = dictionary[exceptionHandler2];
					if (instruction == exceptionHandler2.TryEnd)
					{
						ScopeBlock scopeBlock2 = stack.Pop();
						Debug.Assert(scopeBlock2 == tuple.Item1);
					}
					if (instruction == exceptionHandler2.HandlerEnd)
					{
						ScopeBlock scopeBlock3 = stack.Pop();
						Debug.Assert(scopeBlock3 == tuple.Item2);
					}
					if (exceptionHandler2.FilterStart != null && instruction == exceptionHandler2.HandlerStart)
					{
						Debug.Assert(stack.Peek().Type == ScopeType.Filter);
						ScopeBlock scopeBlock4 = stack.Pop();
						Debug.Assert(scopeBlock4 == tuple.Item3);
					}
				}
				foreach (ExceptionHandler item5 in cilBody_0.ExceptionHandlers.Reverse())
				{
					Tuple<ScopeBlock, ScopeBlock, ScopeBlock> tuple2 = dictionary[item5];
					ScopeBlock scopeBlock5 = ((stack.Count > 0) ? stack.Peek() : null);
					if (instruction == item5.TryStart)
					{
						if (scopeBlock5 != null)
						{
							ctL(scopeBlock5, tuple2.Item1);
						}
						stack.Push(tuple2.Item1);
					}
					if (instruction == item5.HandlerStart)
					{
						if (scopeBlock5 != null)
						{
							ctL(scopeBlock5, tuple2.Item2);
						}
						stack.Push(tuple2.Item2);
					}
					if (instruction == item5.FilterStart)
					{
						if (scopeBlock5 != null)
						{
							ctL(scopeBlock5, tuple2.Item3);
						}
						stack.Push(tuple2.Item3);
					}
				}
				ScopeBlock scopeBlock_ = stack.Peek();
				Itk(scopeBlock_, item4);
			}
			foreach (ExceptionHandler exceptionHandler3 in cilBody_0.ExceptionHandlers)
			{
				if (exceptionHandler3.TryEnd == null)
				{
					ScopeBlock scopeBlock6 = stack.Pop();
					Debug.Assert(scopeBlock6 == dictionary[exceptionHandler3].Item1);
				}
				if (exceptionHandler3.HandlerEnd == null)
				{
					ScopeBlock scopeBlock7 = stack.Pop();
					Debug.Assert(scopeBlock7 == dictionary[exceptionHandler3].Item2);
				}
			}
			Debug.Assert(stack.Count == 1);
			Rtc(scopeBlock);
			return scopeBlock;
		}

		private static void Rtc(ScopeBlock scopeBlock_0)
		{
			scopeBlock_0.Validate();
			foreach (ScopeBlock child in scopeBlock_0.Children)
			{
				Rtc(child);
			}
		}

		private static void ctL(ScopeBlock scopeBlock_0, object object_0)
		{
			if (scopeBlock_0.Content.Count > 0)
			{
				ScopeBlock scopeBlock = new ScopeBlock();
				foreach (IBasicBlock item in scopeBlock_0.Content)
				{
					scopeBlock.Content.Add(item);
				}
				scopeBlock_0.Content.Clear();
				scopeBlock_0.Children.Add(scopeBlock);
			}
			scopeBlock_0.Children.Add((ScopeBlock)object_0);
		}

		private static void Itk(ScopeBlock scopeBlock_0, BasicBlock<CILInstrList> basicBlock_0)
		{
			if (scopeBlock_0.Children.Count > 0)
			{
				ScopeBlock scopeBlock = scopeBlock_0.Children.Last();
				if (scopeBlock.Type != ScopeType.None)
				{
					scopeBlock = new ScopeBlock();
					scopeBlock_0.Children.Add(scopeBlock);
				}
				scopeBlock_0 = scopeBlock;
			}
			Debug.Assert(scopeBlock_0.Children.Count == 0);
			scopeBlock_0.Content.Add(basicBlock_0);
		}
	}
}
