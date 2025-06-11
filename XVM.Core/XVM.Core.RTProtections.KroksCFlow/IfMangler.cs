using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XF;

namespace XVM.Core.RTProtections.KroksCFlow
{
	public class IfMangler : ManglerBase
	{
		private struct RoU
		{
			public Dictionary<uint, int> Sov;

			public Dictionary<uint, List<Instruction>> doB;

			public Dictionary<uint, int> do7;

			public Dictionary<uint, int> PoD;

			private static void woh(Dictionary<uint, int> dictionary_0, uint uint_0)
			{
				if (!dictionary_0.TryGetValue(uint_0, out var value))
				{
					value = 0;
				}
				dictionary_0[uint_0] = value + 1;
			}

			public RoU(CilBody cilBody_0, bool bool_0)
			{
				Sov = new Dictionary<uint, int>();
				doB = new Dictionary<uint, List<Instruction>>();
				do7 = new Dictionary<uint, int>();
				PoD = new Dictionary<uint, int>();
				cilBody_0.UpdateInstructionOffsets();
				foreach (ExceptionHandler exceptionHandler in cilBody_0.ExceptionHandlers)
				{
					do7[exceptionHandler.TryStart.Offset] = 0;
					do7[exceptionHandler.HandlerStart.Offset] = ((exceptionHandler.HandlerType != ExceptionHandlerType.Finally) ? 1 : 0);
					if (exceptionHandler.FilterStart != null)
					{
						do7[exceptionHandler.FilterStart.Offset] = 1;
					}
				}
				int stack = 0;
				for (int i = 0; i < cilBody_0.Instructions.Count; i++)
				{
					Instruction instruction = cilBody_0.Instructions[i];
					if (do7.ContainsKey(instruction.Offset))
					{
						stack = do7[instruction.Offset];
					}
					do7[instruction.Offset] = stack;
					instruction.UpdateStack(ref stack, bool_0);
					PoD[instruction.Offset] = stack;
					switch (instruction.OpCode.FlowControl)
					{
					case FlowControl.Branch:
					{
						uint offset = ((Instruction)instruction.Operand).Offset;
						if (!do7.ContainsKey(offset))
						{
							do7[offset] = stack;
						}
						woh(Sov, offset);
						doB.AddListEntry(offset, instruction);
						stack = 0;
						break;
					}
					case FlowControl.Call:
						if (instruction.OpCode.Code == Code.Jmp)
						{
							stack = 0;
						}
						goto case FlowControl.Break;
					case FlowControl.Cond_Branch:
						if (instruction.OpCode.Code == Code.Switch)
						{
							Instruction[] array = (Instruction[])instruction.Operand;
							foreach (Instruction instruction2 in array)
							{
								if (!do7.ContainsKey(instruction2.Offset))
								{
									do7[instruction2.Offset] = stack;
								}
								woh(Sov, instruction2.Offset);
								doB.AddListEntry(instruction2.Offset, instruction);
							}
						}
						else
						{
							uint offset = ((Instruction)instruction.Operand).Offset;
							if (!do7.ContainsKey(offset))
							{
								do7[offset] = stack;
							}
							woh(Sov, offset);
							doB.AddListEntry(offset, instruction);
						}
						goto case FlowControl.Break;
					case FlowControl.Break:
					case FlowControl.Meta:
					case FlowControl.Next:
						if (i + 1 < cilBody_0.Instructions.Count)
						{
							uint offset = cilBody_0.Instructions[i + 1].Offset;
							woh(Sov, offset);
						}
						break;
					case FlowControl.Return:
					case FlowControl.Throw:
						break;
					default:
						throw new NIS();
					}
				}
			}

			public bool hoP(uint uint_0)
			{
				if (!doB.TryGetValue(uint_0, out var value))
				{
					return false;
				}
				return value.Count > 0;
			}

			public bool boF(uint uint_0)
			{
				if (!Sov.TryGetValue(uint_0, out var value))
				{
					return false;
				}
				return value > 1;
			}
		}

		[Serializable]
		[CompilerGenerated]
		private sealed class poy
		{
			public static readonly poy doV;

			public static Func<Instruction[], Instruction> Qob;

			public static Func<Instruction, bool> uop;

			static poy()
			{
				doV = new poy();
			}

			internal Instruction NoY(Instruction[] instruction_0)
			{
				return instruction_0.Last();
			}

			internal bool vog(Instruction instruction_0)
			{
				return instruction_0.Operand is Instruction[];
			}
		}

		[CompilerGenerated]
		private sealed class @for
		{
			public RoU eo3;

			public Local joX;

			public KroksContext Qon;

			public CilBody qo6;
		}

		[CompilerGenerated]
		private sealed class rox
		{
			public InstrBlock Cos;

			public @for noQ;
		}

		[CompilerGenerated]
		private sealed class aof
		{
			public LinkedList<Instruction[]> Ule;

			public HashSet<Instruction> Llu;

			public List<Instruction> Dl9;

			public rox JlG;

			public Func<Instruction, bool> HlI;

			public Func<Instruction, bool> Olq;

			public Func<Instruction, bool> QlM;

			internal bool Joi(IList<Instruction> ilist_0)
			{
				return ilist_0.Any(delegate(Instruction instruction_0)
				{
					if (!JlG.noQ.eo3.boF(instruction_0.Offset))
					{
						if (JlG.noQ.eo3.doB.TryGetValue(instruction_0.Offset, out var value))
						{
							if (value.Any(poy.doV.vog))
							{
								return true;
							}
							if (value.Any((Instruction instruction) => instruction.Offset <= Ule.First.Value.Last().Offset || instruction.Offset >= JlG.Cos.Instructions.Last().Offset))
							{
								return true;
							}
							if (value.Any())
							{
								return true;
							}
							if (value.Any((Instruction item) => !Llu.Contains(item)))
							{
								return true;
							}
						}
						return false;
					}
					return true;
				});
			}

			internal bool LoJ(Instruction instruction_0)
			{
				if (!JlG.noQ.eo3.boF(instruction_0.Offset))
				{
					if (JlG.noQ.eo3.doB.TryGetValue(instruction_0.Offset, out var value))
					{
						if (value.Any(poy.doV.vog))
						{
							return true;
						}
						if (value.Any((Instruction instruction) => instruction.Offset <= Ule.First.Value.Last().Offset || instruction.Offset >= JlG.Cos.Instructions.Last().Offset))
						{
							return true;
						}
						if (value.Any())
						{
							return true;
						}
						if (value.Any((Instruction item) => !Llu.Contains(item)))
						{
							return true;
						}
					}
					return false;
				}
				return true;
			}

			internal bool Po8(Instruction instruction_0)
			{
				return instruction_0.Offset <= Ule.First.Value.Last().Offset || instruction_0.Offset >= JlG.Cos.Instructions.Last().Offset;
			}

			internal bool xoz(Instruction instruction_0)
			{
				return !Llu.Contains(instruction_0);
			}

			internal void xl4(Instruction instruction_0, int int_0)
			{
				Dl9.Add(Instruction.Create(OpCodes.Ldloc, JlG.noQ.joX));
				Local local = new Local(JlG.noQ.Qon.Method.Module.CorLibTypes.Int32);
				JlG.noQ.qo6.Variables.Add(local);
				JlG.noQ.Qon.DynCipher.GenerateExpressionMutation(JlG.noQ.Qon.Random, JlG.noQ.Qon.Method, local, Dl9, int_0, JlG.noQ.Qon.Random.method_2(0, 2));
				Dl9.Add(Instruction.Create(OpCodes.Beq, instruction_0));
			}
		}

		private LinkedList<Instruction[]> L1u(InstrBlock instrBlock_0, RoU roU_0, KroksContext kroksContext_0)
		{
			LinkedList<Instruction[]> linkedList = new LinkedList<Instruction[]>();
			List<Instruction> list = new List<Instruction>();
			HashSet<Instruction> hashSet = new HashSet<Instruction>();
			for (int i = 0; i < instrBlock_0.Instructions.Count; i++)
			{
				Instruction instruction = instrBlock_0.Instructions[i];
				list.Add(instruction);
				bool flag = i + 1 < instrBlock_0.Instructions.Count && roU_0.boF(instrBlock_0.Instructions[i + 1].Offset);
				FlowControl flowControl = instruction.OpCode.FlowControl;
				FlowControl flowControl2 = flowControl;
				if (flowControl2 == FlowControl.Branch || flowControl2 == FlowControl.Cond_Branch || (uint)(flowControl2 - 7) <= 1u)
				{
					flag = true;
					if (roU_0.PoD[instruction.Offset] != 0)
					{
						if (instruction.Operand is Instruction)
						{
							hashSet.Add((Instruction)instruction.Operand);
						}
						else if (instruction.Operand is Instruction[])
						{
							Instruction[] array = (Instruction[])instruction.Operand;
							foreach (Instruction item in array)
							{
								hashSet.Add(item);
							}
						}
					}
				}
				hashSet.Remove(instruction);
				if (instruction.OpCode.OpCodeType != OpCodeType.Prefix && roU_0.PoD[instruction.Offset] == 0 && hashSet.Count == 0 && (flag || kroksContext_0.Intensity > kroksContext_0.Random.NextDouble()))
				{
					linkedList.AddLast(list.ToArray());
					list.Clear();
				}
			}
			if (list.Count > 0)
			{
				linkedList.AddLast(list.ToArray());
			}
			return linkedList;
		}

		public override void Mangle(CilBody cilBody_0, ScopeBlock scopeBlock_0, KroksContext kroksContext_0)
		{
			@for obj = new @for();
			obj.Qon = kroksContext_0;
			obj.qo6 = cilBody_0;
			obj.eo3 = new RoU(obj.qo6, obj.Qon.Method.ReturnType.RemoveModifiers().ElementType != ElementType.Void);
			Local local = new Local(obj.Qon.Method.Module.CorLibTypes.UInt32);
			obj.qo6.Variables.Add(local);
			obj.joX = new Local(obj.Qon.Method.Module.CorLibTypes.UInt32);
			obj.qo6.Variables.Add(obj.joX);
			obj.qo6.InitLocals = true;
			obj.qo6.MaxStack += 2;
			ExpressionPredicate expressionPredicate = new ExpressionPredicate(obj.Qon);
			using (IEnumerator<InstrBlock> enumerator = ManglerBase.GetAllBlocks(scopeBlock_0).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					rox rox = new rox();
					rox.noQ = obj;
					rox.Cos = enumerator.Current;
					aof CS_0024_003C_003E8__locals74 = new aof();
					CS_0024_003C_003E8__locals74.JlG = rox;
					CS_0024_003C_003E8__locals74.Ule = L1u(CS_0024_003C_003E8__locals74.JlG.Cos, CS_0024_003C_003E8__locals74.JlG.noQ.eo3, CS_0024_003C_003E8__locals74.JlG.noQ.Qon);
					if (CS_0024_003C_003E8__locals74.JlG.noQ.Qon.Method.IsInstanceConstructor)
					{
						List<Instruction> list = new List<Instruction>();
						while (CS_0024_003C_003E8__locals74.Ule.First != null)
						{
							list.AddRange(CS_0024_003C_003E8__locals74.Ule.First.Value);
							Instruction instruction = CS_0024_003C_003E8__locals74.Ule.First.Value.Last();
							CS_0024_003C_003E8__locals74.Ule.RemoveFirst();
							if (instruction.OpCode == OpCodes.Call && ((IMethod)instruction.Operand).Name == ".ctor")
							{
								break;
							}
						}
						CS_0024_003C_003E8__locals74.Ule.AddFirst(list.ToArray());
					}
					if (CS_0024_003C_003E8__locals74.Ule.Count < 3)
					{
						continue;
					}
					int[] array = Enumerable.Range(0, CS_0024_003C_003E8__locals74.Ule.Count).ToArray();
					CS_0024_003C_003E8__locals74.JlG.noQ.Qon.Random.Shuffle(array);
					int[] array2 = new int[array.Length];
					int i;
					for (i = 0; i < array2.Length; i++)
					{
						int num = CS_0024_003C_003E8__locals74.JlG.noQ.Qon.Random.method_0() & 0x7FFFFFFF;
						array2[i] = num - num % CS_0024_003C_003E8__locals74.Ule.Count + array[i];
					}
					Dictionary<Instruction, int> dictionary = new Dictionary<Instruction, int>();
					LinkedListNode<Instruction[]> linkedListNode = CS_0024_003C_003E8__locals74.Ule.First;
					i = 0;
					while (linkedListNode != null)
					{
						if (i != 0)
						{
							dictionary[linkedListNode.Value[0]] = array2[i];
						}
						i++;
						linkedListNode = linkedListNode.Next;
					}
					CS_0024_003C_003E8__locals74.Llu = new HashSet<Instruction>(CS_0024_003C_003E8__locals74.Ule.Select((Instruction[] instruction_0) => instruction_0.Last()));
					Func<IList<Instruction>, bool> func = (IList<Instruction> ilist_0) => ilist_0.Any(delegate(Instruction instruction_0)
					{
						if (!CS_0024_003C_003E8__locals74.JlG.noQ.eo3.boF(instruction_0.Offset))
						{
							if (CS_0024_003C_003E8__locals74.JlG.noQ.eo3.doB.TryGetValue(instruction_0.Offset, out var value5))
							{
								if (value5.Any(poy.doV.vog))
								{
									return true;
								}
								if (value5.Any((Instruction instruction4) => instruction4.Offset <= CS_0024_003C_003E8__locals74.Ule.First.Value.Last().Offset || instruction4.Offset >= CS_0024_003C_003E8__locals74.JlG.Cos.Instructions.Last().Offset))
								{
									return true;
								}
								if (value5.Any())
								{
									return true;
								}
								if (value5.Any((Instruction item2) => !CS_0024_003C_003E8__locals74.Llu.Contains(item2)))
								{
									return true;
								}
							}
							return false;
						}
						return true;
					});
					new Instruction(OpCodes.Switch);
					CS_0024_003C_003E8__locals74.Dl9 = new List<Instruction>();
					if (expressionPredicate == null)
					{
						CS_0024_003C_003E8__locals74.Dl9.Add(Instruction.CreateLdcI4(array2[1]));
					}
					else
					{
						expressionPredicate.Init(CS_0024_003C_003E8__locals74.JlG.noQ.qo6);
						CS_0024_003C_003E8__locals74.Dl9.Add(Instruction.CreateLdcI4(expressionPredicate.GetSwitchKey(array2[1])));
						expressionPredicate.EmitSwitchLoad(CS_0024_003C_003E8__locals74.Dl9);
					}
					CS_0024_003C_003E8__locals74.Dl9.Add(Instruction.Create(OpCodes.Dup));
					CS_0024_003C_003E8__locals74.Dl9.Add(Instruction.Create(OpCodes.Stloc, local));
					CS_0024_003C_003E8__locals74.Dl9.Add(Instruction.Create(OpCodes.Ldc_I4, CS_0024_003C_003E8__locals74.Ule.Count));
					CS_0024_003C_003E8__locals74.Dl9.Add(Instruction.Create(OpCodes.Rem_Un));
					CS_0024_003C_003E8__locals74.Dl9.Add(Instruction.Create(OpCodes.Stloc, CS_0024_003C_003E8__locals74.JlG.noQ.joX));
					linkedListNode = CS_0024_003C_003E8__locals74.Ule.First;
					i = 0;
					while (linkedListNode.Next != null)
					{
						List<Instruction> list2 = new List<Instruction>(linkedListNode.Value);
						if (i == 0)
						{
							CS_0024_003C_003E8__locals74.xl4(CS_0024_003C_003E8__locals74.Dl9[0], array[i]);
						}
						else
						{
							bool flag = false;
							if (list2.Last().IsBr())
							{
								Instruction key = (Instruction)list2.Last().Operand;
								if (!CS_0024_003C_003E8__locals74.JlG.noQ.eo3.hoP(list2.Last().Offset) && dictionary.TryGetValue(key, out var value))
								{
									int num2 = expressionPredicate?.GetSwitchKey(value) ?? value;
									bool flag2 = func(list2);
									list2.RemoveAt(list2.Count - 1);
									if (flag2)
									{
										list2.Add(Instruction.Create(OpCodes.Ldc_I4, num2));
									}
									else
									{
										int num3 = array2[i];
										int num4 = CS_0024_003C_003E8__locals74.JlG.noQ.Qon.Random.method_0();
										list2.Add(Instruction.Create(OpCodes.Ldloc, local));
										list2.Add(Instruction.CreateLdcI4(num4));
										list2.Add(Instruction.Create(OpCodes.Mul));
										list2.Add(Instruction.Create(OpCodes.Ldc_I4, (num3 * num4) ^ num2));
										list2.Add(Instruction.Create(OpCodes.Xor));
									}
									CS_0024_003C_003E8__locals74.JlG.noQ.Qon.AddJump(list2, CS_0024_003C_003E8__locals74.Dl9[1]);
									CS_0024_003C_003E8__locals74.JlG.noQ.Qon.AddJunk(list2);
									CS_0024_003C_003E8__locals74.xl4(list2[0], array[i]);
									flag = true;
								}
							}
							else if (list2.Last().IsConditionalBranch())
							{
								Instruction key2 = (Instruction)list2.Last().Operand;
								if (!CS_0024_003C_003E8__locals74.JlG.noQ.eo3.hoP(list2.Last().Offset) && dictionary.TryGetValue(key2, out var value2))
								{
									bool flag3 = func(list2);
									int num5 = array2[i + 1];
									OpCode opCode = list2.Last().OpCode;
									list2.RemoveAt(list2.Count - 1);
									int num6 = array2[i];
									int num7 = 0;
									int num8 = 0;
									if (!flag3)
									{
										num7 = CS_0024_003C_003E8__locals74.JlG.noQ.Qon.Random.method_0();
										num8 = num6 * num7;
									}
									Instruction instruction2 = Instruction.CreateLdcI4(num8 ^ (expressionPredicate?.GetSwitchKey(value2) ?? value2));
									Instruction item = Instruction.CreateLdcI4(num8 ^ (expressionPredicate?.GetSwitchKey(num5) ?? num5));
									Instruction instruction3 = Instruction.Create(OpCodes.Pop);
									list2.Add(Instruction.Create(opCode, instruction2));
									list2.Add(item);
									list2.Add(Instruction.Create(OpCodes.Dup));
									list2.Add(Instruction.Create(OpCodes.Br, instruction3));
									list2.Add(instruction2);
									list2.Add(Instruction.Create(OpCodes.Dup));
									list2.Add(instruction3);
									if (!flag3)
									{
										list2.Add(Instruction.Create(OpCodes.Ldloc, local));
										list2.Add(Instruction.CreateLdcI4(num7));
										list2.Add(Instruction.Create(OpCodes.Mul));
										list2.Add(Instruction.Create(OpCodes.Xor));
									}
									CS_0024_003C_003E8__locals74.JlG.noQ.Qon.AddJump(list2, CS_0024_003C_003E8__locals74.Dl9[1]);
									CS_0024_003C_003E8__locals74.JlG.noQ.Qon.AddJunk(list2);
									CS_0024_003C_003E8__locals74.xl4(list2[0], array[i]);
									flag = true;
								}
							}
							if (!flag)
							{
								int num9 = expressionPredicate?.GetSwitchKey(array2[i + 1]) ?? array2[i + 1];
								if (func(list2))
								{
									list2.Add(Instruction.Create(OpCodes.Ldc_I4, num9));
								}
								else
								{
									int num10 = array2[i];
									int num11 = CS_0024_003C_003E8__locals74.JlG.noQ.Qon.Random.method_0();
									list2.Add(Instruction.Create(OpCodes.Ldloc, local));
									list2.Add(Instruction.CreateLdcI4(num11));
									list2.Add(Instruction.Create(OpCodes.Mul));
									list2.Add(Instruction.Create(OpCodes.Ldc_I4, (num10 * num11) ^ num9));
									list2.Add(Instruction.Create(OpCodes.Xor));
								}
								CS_0024_003C_003E8__locals74.JlG.noQ.Qon.AddJump(list2, CS_0024_003C_003E8__locals74.Dl9[1]);
								CS_0024_003C_003E8__locals74.JlG.noQ.Qon.AddJunk(list2);
								CS_0024_003C_003E8__locals74.xl4(list2[0], array[i]);
							}
						}
						linkedListNode.Value = list2.ToArray();
						linkedListNode = linkedListNode.Next;
						i++;
					}
					CS_0024_003C_003E8__locals74.xl4(linkedListNode.Value[0], array[i]);
					CS_0024_003C_003E8__locals74.JlG.noQ.Qon.AddJump(CS_0024_003C_003E8__locals74.Dl9, CS_0024_003C_003E8__locals74.Ule.Last.Value[0]);
					CS_0024_003C_003E8__locals74.JlG.noQ.Qon.AddJunk(CS_0024_003C_003E8__locals74.Dl9);
					Instruction[] value3 = CS_0024_003C_003E8__locals74.Ule.First.Value;
					CS_0024_003C_003E8__locals74.Ule.RemoveFirst();
					Instruction[] value4 = CS_0024_003C_003E8__locals74.Ule.Last.Value;
					CS_0024_003C_003E8__locals74.Ule.RemoveLast();
					List<Instruction[]> list3 = CS_0024_003C_003E8__locals74.Ule.ToList();
					CS_0024_003C_003E8__locals74.JlG.noQ.Qon.Random.Shuffle(list3);
					CS_0024_003C_003E8__locals74.JlG.Cos.Instructions.Clear();
					CS_0024_003C_003E8__locals74.JlG.Cos.Instructions.AddRange(value3);
					CS_0024_003C_003E8__locals74.JlG.Cos.Instructions.AddRange(CS_0024_003C_003E8__locals74.Dl9);
					foreach (Instruction[] item2 in list3)
					{
						CS_0024_003C_003E8__locals74.JlG.Cos.Instructions.AddRange(item2);
					}
					CS_0024_003C_003E8__locals74.JlG.Cos.Instructions.AddRange(value4);
				}
			}
		}
	}
}
