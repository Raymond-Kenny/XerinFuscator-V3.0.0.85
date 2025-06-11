#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core;

namespace XF
{
	internal class EAP
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class G50
		{
			public static readonly G50 W5W;

			public static Func<MethodDef, EAP> R5E;

			static G50()
			{
				W5W = new G50();
			}

			internal EAP S5w(MethodDef methodDef_0)
			{
				return JAs[methodDef_0] = new EAP(methodDef_0);
			}
		}

		private static readonly Dictionary<MethodDef, EAP> JAs;

		private readonly MethodDef OAQ;

		private Dictionary<int, List<Instruction>> dAi;

		private Dictionary<uint, int> EAJ;

		[CompilerGenerated]
		private Instruction[] WA8;

		[CompilerGenerated]
		private int[] LAz;

		[CompilerGenerated]
		private int[] lR4;

		internal EAP(MethodDef methodDef_0)
		{
			OAQ = methodDef_0;
		}

		public static EAP cAF(object object_0)
		{
			if (object_0 == null)
			{
				throw new ArgumentNullException("method");
			}
			return JAs.GetValueOrDefaultLazy((MethodDef)object_0, (MethodDef methodDef_0) => JAs[methodDef_0] = new EAP(methodDef_0)).GAd();
		}

		[SpecialName]
		public MethodDef vAD()
		{
			return OAQ;
		}

		[SpecialName]
		[CompilerGenerated]
		public Instruction[] RAY()
		{
			return WA8;
		}

		[SpecialName]
		[CompilerGenerated]
		private void LAg(Instruction[] instruction_0)
		{
			WA8 = instruction_0;
		}

		[SpecialName]
		public Func<uint, int> UAb()
		{
			return (uint uint_0) => EAJ[uint_0];
		}

		[SpecialName]
		[CompilerGenerated]
		public int[] cAr()
		{
			return LAz;
		}

		[SpecialName]
		[CompilerGenerated]
		private void LA3(int[] int_0)
		{
			LAz = int_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public int[] nAn()
		{
			return lR4;
		}

		[SpecialName]
		[CompilerGenerated]
		private void aA6(int[] int_0)
		{
			lR4 = int_0;
		}

		public bool AAv(int int_0)
		{
			return dAi.ContainsKey(int_0);
		}

		internal EAP GAd()
		{
			CilBody body = OAQ.Body;
			OAQ.Body.UpdateInstructionOffsets();
			LAg(OAQ.Body.Instructions.ToArray());
			EAJ = new Dictionary<uint, int>();
			int[] array = new int[body.Instructions.Count];
			int[] array2 = new int[body.Instructions.Count];
			dAi = new Dictionary<int, List<Instruction>>();
			IList<Instruction> instructions = body.Instructions;
			for (int i = 0; i < instructions.Count; i++)
			{
				EAJ.Add(instructions[i].Offset, i);
				array[i] = int.MinValue;
			}
			foreach (ExceptionHandler exceptionHandler in body.ExceptionHandlers)
			{
				array[EAJ[exceptionHandler.TryStart.Offset]] = 0;
				array[EAJ[exceptionHandler.HandlerStart.Offset]] = ((exceptionHandler.HandlerType != ExceptionHandlerType.Finally) ? 1 : 0);
				if (exceptionHandler.FilterStart != null)
				{
					array[EAJ[exceptionHandler.FilterStart.Offset]] = 1;
				}
			}
			int stack = 0;
			for (int j = 0; j < instructions.Count; j++)
			{
				Instruction instruction = instructions[j];
				if (array[j] != int.MinValue)
				{
					stack = array[j];
				}
				array[j] = stack;
				instruction.UpdateStack(ref stack);
				array2[j] = stack;
				switch (instruction.OpCode.FlowControl)
				{
				case FlowControl.Branch:
				{
					int num3 = EAJ[((Instruction)instruction.Operand).Offset];
					if (array[num3] == int.MinValue)
					{
						array[num3] = stack;
					}
					dAi.AddListEntry(EAJ[((Instruction)instruction.Operand).Offset], instruction);
					stack = 0;
					break;
				}
				case FlowControl.Call:
					if (instruction.OpCode.Code == Code.Jmp)
					{
						stack = 0;
					}
					break;
				case FlowControl.Cond_Branch:
					if (instruction.OpCode.Code == Code.Switch)
					{
						Instruction[] array3 = (Instruction[])instruction.Operand;
						foreach (Instruction instruction2 in array3)
						{
							int num = EAJ[instruction2.Offset];
							if (array[num] == int.MinValue)
							{
								array[num] = stack;
							}
							dAi.AddListEntry(EAJ[instruction2.Offset], instruction);
						}
					}
					else
					{
						int num2 = EAJ[((Instruction)instruction.Operand).Offset];
						if (array[num2] == int.MinValue)
						{
							array[num2] = stack;
						}
						dAi.AddListEntry(EAJ[((Instruction)instruction.Operand).Offset], instruction);
					}
					break;
				case FlowControl.Break:
				case FlowControl.Meta:
				case FlowControl.Next:
				case FlowControl.Return:
				case FlowControl.Throw:
					break;
				default:
					throw new NIS();
				}
			}
			int[] array4 = array;
			int num4 = 0;
			while (true)
			{
				if (num4 < array4.Length)
				{
					int num5 = array4[num4];
					if (num5 != int.MinValue)
					{
						num4++;
						continue;
					}
					throw new InvalidMethodException("Bad method body.");
				}
				int[] array5 = array2;
				foreach (int num6 in array5)
				{
					if (num6 == int.MinValue)
					{
						throw new InvalidMethodException("Bad method body.");
					}
				}
				break;
			}
			LA3(array);
			aA6(array2);
			return this;
		}

		public int[] PAB(Instruction instruction_0)
		{
			if (instruction_0.OpCode.Code == Code.Call || instruction_0.OpCode.Code == Code.Callvirt || instruction_0.OpCode.Code == Code.Newobj)
			{
				instruction_0.CalculateStackUsage(out var pushes, out var pops);
				if (pops != 0)
				{
					int num = EAJ[instruction_0.Offset];
					int num2 = pops;
					int num3 = cAr()[num] - num2;
					int num4 = -1;
					HashSet<uint> hashSet = new HashSet<uint>();
					Queue<int> queue = new Queue<int>();
					queue.Enqueue(EAJ[instruction_0.Offset] - 1);
					while (queue.Count > 0)
					{
						int num5 = queue.Dequeue();
						while (num5 >= 0 && cAr()[num5] != num3)
						{
							if (dAi.ContainsKey(num5))
							{
								foreach (Instruction item2 in dAi[num5])
								{
									if (!hashSet.Contains(item2.Offset))
									{
										hashSet.Add(item2.Offset);
										queue.Enqueue(EAJ[item2.Offset]);
									}
								}
							}
							num5--;
						}
						if (num5 >= 0)
						{
							if (num4 != -1)
							{
								if (num4 != num5)
								{
									return null;
								}
							}
							else
							{
								num4 = num5;
							}
							continue;
						}
						return null;
					}
					hashSet.Clear();
					Queue<Tuple<int, Stack<int>>> queue2 = new Queue<Tuple<int, Stack<int>>>();
					queue2.Clear();
					queue2.Enqueue(Tuple.Create(num4, new Stack<int>()));
					int[] array = null;
					while (true)
					{
						if (queue2.Count > 0)
						{
							Tuple<int, Stack<int>> tuple = queue2.Dequeue();
							int num6 = tuple.Item1;
							Stack<int> item = tuple.Item2;
							while (num6 != num && num6 < OAQ.Body.Instructions.Count)
							{
								Instruction instruction = RAY()[num6];
								instruction.CalculateStackUsage(out pushes, out pops);
								int num7 = pops - pushes;
								if (num7 >= 0)
								{
									if (item.Count < num7)
									{
										return null;
									}
									for (int i = 0; i < num7; i++)
									{
										item.Pop();
									}
								}
								else
								{
									Debug.Assert(num7 == -1);
									item.Push(num6);
								}
								if (instruction.Operand is Instruction)
								{
									int num8 = EAJ[((Instruction)instruction.Operand).Offset];
									if (instruction.OpCode.FlowControl != FlowControl.Branch)
									{
										queue2.Enqueue(Tuple.Create(num8, new Stack<int>(item)));
										num6++;
									}
									else
									{
										num6 = num8;
									}
								}
								else if (instruction.Operand is Instruction[])
								{
									Instruction[] array2 = (Instruction[])instruction.Operand;
									foreach (Instruction instruction2 in array2)
									{
										queue2.Enqueue(Tuple.Create(EAJ[instruction2.Offset], new Stack<int>(item)));
									}
									num6++;
								}
								else
								{
									num6++;
								}
							}
							if (item.Count != num2)
							{
								break;
							}
							if (array == null || item.SequenceEqual(array))
							{
								array = item.ToArray();
								continue;
							}
							return null;
						}
						if (array == null)
						{
							return array;
						}
						Array.Reverse(array);
						return array;
					}
					return null;
				}
				return new int[0];
			}
			throw new ArgumentException("Invalid call instruction.", "instr");
		}

		static EAP()
		{
			JAs = new Dictionary<MethodDef, EAP>();
		}

		[CompilerGenerated]
		private int gA7(uint uint_0)
		{
			return EAJ[uint_0];
		}
	}
}
