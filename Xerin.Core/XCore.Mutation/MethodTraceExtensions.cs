using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XCore.Mutation
{
	public static class MethodTraceExtensions
	{
		public static int[] TraceArguments(this IList<Instruction> ilist_0, Instruction instruction_0)
		{
			List<int> list = new List<int>();
			HashSet<Instruction> hashSet = new HashSet<Instruction>();
			Queue<Instruction> queue = new Queue<Instruction>();
			queue.Enqueue(instruction_0);
			while (queue.Count > 0)
			{
				Instruction instruction = queue.Dequeue();
				if (!hashSet.Add(instruction) || instruction.OpCode == OpCodes.Nop)
				{
					continue;
				}
				if (instruction.OpCode.Code == Code.Ldarg_0 || instruction.OpCode.Code == Code.Ldarg_1 || instruction.OpCode.Code == Code.Ldarg_2 || instruction.OpCode.Code == Code.Ldarg_3 || instruction.OpCode.Code == Code.Ldarg_S || instruction.OpCode.Code == Code.Ldarg)
				{
					Parameter parameter = instruction.Operand as Parameter;
					if (parameter != null)
					{
						int index = parameter.Index;
					}
					else
					{
						object operand = instruction.Operand;
						if (!(operand is int) || 1 == 0)
						{
							throw new ArgumentException("Failed to determine argument index.");
						}
					}
					list.Add(ilist_0.IndexOf(instruction));
				}
				Instruction instruction2 = instruction.Operand as Instruction;
				if (instruction2 != null && ilist_0.Contains(instruction2))
				{
					queue.Enqueue(instruction2);
				}
				switch (instruction.OpCode.FlowControl)
				{
				default:
				{
					int num = ilist_0.IndexOf(instruction) - 1;
					if (num >= 0 && !hashSet.Contains(ilist_0[num]))
					{
						queue.Enqueue(ilist_0[num]);
					}
					break;
				}
				case FlowControl.Branch:
				case FlowControl.Cond_Branch:
				{
					Instruction instruction3 = instruction.Operand as Instruction;
					if (instruction3 != null && ilist_0.Contains(instruction3))
					{
						queue.Enqueue(instruction3);
					}
					break;
				}
				case FlowControl.Call:
					break;
				}
			}
			return list.ToArray();
		}
	}
}
