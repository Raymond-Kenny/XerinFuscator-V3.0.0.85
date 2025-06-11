using System.Collections;
using System.Collections.Generic;
using dnlib.DotNet.Emit;

namespace XProtections.ControlFlow
{
	public class ControlFlowGraph : IEnumerable<ControlFlowBlock>, IEnumerable
	{
		private readonly List<ControlFlowBlock> ixJ;

		private readonly CilBody lxz;

		private readonly int[] F9c;

		private readonly Dictionary<Instruction, int> l92;

		public int Count => ixJ.Count;

		public ControlFlowBlock this[int int_0] => ixJ[int_0];

		public CilBody Body => lxz;

		private ControlFlowGraph(CilBody cilBody_0)
		{
			lxz = cilBody_0;
			F9c = new int[cilBody_0.Instructions.Count];
			ixJ = new List<ControlFlowBlock>();
			l92 = new Dictionary<Instruction, int>();
			for (int i = 0; i < cilBody_0.Instructions.Count; i++)
			{
				l92.Add(cilBody_0.Instructions[i], i);
			}
		}

		IEnumerator<ControlFlowBlock> IEnumerable<ControlFlowBlock>.GetEnumerator()
		{
			return ixJ.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ixJ.GetEnumerator();
		}

		public ControlFlowBlock GetContainingBlock(int int_0)
		{
			return ixJ[F9c[int_0]];
		}

		public int IndexOf(Instruction instruction_0)
		{
			return l92[instruction_0];
		}

		private void axM(HashSet<Instruction> hashSet_0, HashSet<Instruction> hashSet_1)
		{
			for (int i = 0; i < lxz.Instructions.Count; i++)
			{
				Instruction instruction = lxz.Instructions[i];
				if (instruction.Operand is Instruction)
				{
					hashSet_0.Add((Instruction)instruction.Operand);
					if (i + 1 < lxz.Instructions.Count)
					{
						hashSet_0.Add(lxz.Instructions[i + 1]);
					}
				}
				else if (instruction.Operand is Instruction[])
				{
					Instruction[] array = (Instruction[])instruction.Operand;
					foreach (Instruction item in array)
					{
						hashSet_0.Add(item);
					}
					if (i + 1 < lxz.Instructions.Count)
					{
						hashSet_0.Add(lxz.Instructions[i + 1]);
					}
				}
				else if ((instruction.OpCode.FlowControl == FlowControl.Throw || instruction.OpCode.FlowControl == FlowControl.Return) && i + 1 < lxz.Instructions.Count)
				{
					hashSet_0.Add(lxz.Instructions[i + 1]);
				}
			}
			hashSet_0.Add(lxz.Instructions[0]);
			foreach (ExceptionHandler exceptionHandler in lxz.ExceptionHandlers)
			{
				hashSet_0.Add(exceptionHandler.TryStart);
				hashSet_0.Add(exceptionHandler.HandlerStart);
				hashSet_0.Add(exceptionHandler.FilterStart);
				hashSet_1.Add(exceptionHandler.HandlerStart);
				hashSet_1.Add(exceptionHandler.FilterStart);
			}
		}

		private void Fxe(HashSet<Instruction> hashSet_0, HashSet<Instruction> hashSet_1)
		{
			int num = 0;
			int num2 = -1;
			Instruction instruction = null;
			for (int i = 0; i < lxz.Instructions.Count; i++)
			{
				Instruction instruction2 = lxz.Instructions[i];
				if (hashSet_0.Contains(instruction2))
				{
					if (instruction != null)
					{
						Instruction instruction3 = lxz.Instructions[i - 1];
						ControlFlowBlockType controlFlowBlockType = ControlFlowBlockType.Normal;
						if (hashSet_1.Contains(instruction) || instruction == lxz.Instructions[0])
						{
							controlFlowBlockType |= ControlFlowBlockType.Entry;
						}
						if (instruction3.OpCode.FlowControl == FlowControl.Return || instruction3.OpCode.FlowControl == FlowControl.Throw)
						{
							controlFlowBlockType |= ControlFlowBlockType.Exit;
						}
						ixJ.Add(new ControlFlowBlock(num2, controlFlowBlockType, instruction, instruction3));
					}
					num2 = num++;
					instruction = instruction2;
				}
				F9c[i] = num2;
			}
			if (ixJ.Count == 0 || ixJ[ixJ.Count - 1].Id != num2)
			{
				Instruction instruction4 = lxz.Instructions[lxz.Instructions.Count - 1];
				ControlFlowBlockType controlFlowBlockType2 = ControlFlowBlockType.Normal;
				if (hashSet_1.Contains(instruction) || instruction == lxz.Instructions[0])
				{
					controlFlowBlockType2 |= ControlFlowBlockType.Entry;
				}
				if (instruction4.OpCode.FlowControl == FlowControl.Return || instruction4.OpCode.FlowControl == FlowControl.Throw)
				{
					controlFlowBlockType2 |= ControlFlowBlockType.Exit;
				}
				ixJ.Add(new ControlFlowBlock(num2, controlFlowBlockType2, instruction, instruction4));
			}
		}

		private void ixC()
		{
			for (int i = 0; i < lxz.Instructions.Count; i++)
			{
				Instruction instruction = lxz.Instructions[i];
				if (instruction.Operand is Instruction)
				{
					ControlFlowBlock controlFlowBlock = ixJ[F9c[i]];
					ControlFlowBlock controlFlowBlock2 = ixJ[F9c[l92[(Instruction)instruction.Operand]]];
					controlFlowBlock2.Sources.Add(controlFlowBlock);
					controlFlowBlock.Targets.Add(controlFlowBlock2);
				}
				else if (instruction.Operand is Instruction[])
				{
					Instruction[] array = (Instruction[])instruction.Operand;
					foreach (Instruction key in array)
					{
						ControlFlowBlock controlFlowBlock3 = ixJ[F9c[i]];
						ControlFlowBlock controlFlowBlock4 = ixJ[F9c[l92[key]]];
						controlFlowBlock4.Sources.Add(controlFlowBlock3);
						controlFlowBlock3.Targets.Add(controlFlowBlock4);
					}
				}
			}
			for (int k = 0; k < ixJ.Count; k++)
			{
				if (ixJ[k].Footer.OpCode.FlowControl != FlowControl.Branch && ixJ[k].Footer.OpCode.FlowControl != FlowControl.Return && ixJ[k].Footer.OpCode.FlowControl != FlowControl.Throw)
				{
					ixJ[k].Targets.Add(ixJ[k + 1]);
					ixJ[k + 1].Sources.Add(ixJ[k]);
				}
			}
		}

		public static ControlFlowGraph Construct(CilBody cilBody_0)
		{
			ControlFlowGraph controlFlowGraph = new ControlFlowGraph(cilBody_0);
			if (cilBody_0.Instructions.Count == 0)
			{
				return controlFlowGraph;
			}
			HashSet<Instruction> hashSet_ = new HashSet<Instruction>();
			HashSet<Instruction> hashSet_2 = new HashSet<Instruction>();
			controlFlowGraph.axM(hashSet_, hashSet_2);
			controlFlowGraph.Fxe(hashSet_, hashSet_2);
			controlFlowGraph.ixC();
			return controlFlowGraph;
		}
	}
}
