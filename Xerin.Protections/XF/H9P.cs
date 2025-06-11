using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Context;
using XCore.Generator;
using XCore.Junk;
using XCore.Shuffler;
using XCore.Utils;
using XProtections.ControlFlow;
using XProtections.Mutation;

namespace XF
{
	internal class H9P
	{
		private struct S7i
		{
			public Dictionary<uint, int> B7v;

			public Dictionary<uint, List<Instruction>> I7O;

			public Dictionary<uint, int> c7u;

			public Dictionary<uint, int> e7V;

			private static void e7Z(Dictionary<uint, int> dictionary_0, uint uint_0)
			{
				if (!dictionary_0.TryGetValue(uint_0, out var value))
				{
					value = 0;
				}
				dictionary_0[uint_0] = value + 1;
			}

			public S7i(CilBody cilBody_0, bool bool_0)
			{
				B7v = new Dictionary<uint, int>();
				I7O = new Dictionary<uint, List<Instruction>>();
				c7u = new Dictionary<uint, int>();
				e7V = new Dictionary<uint, int>();
				cilBody_0.UpdateInstructionOffsets();
				foreach (ExceptionHandler exceptionHandler in cilBody_0.ExceptionHandlers)
				{
					c7u[exceptionHandler.TryStart.Offset] = 0;
					c7u[exceptionHandler.HandlerStart.Offset] = ((exceptionHandler.HandlerType != ExceptionHandlerType.Finally) ? 1 : 0);
					if (exceptionHandler.FilterStart != null)
					{
						c7u[exceptionHandler.FilterStart.Offset] = 1;
					}
				}
				int stack = 0;
				for (int i = 0; i < cilBody_0.Instructions.Count; i++)
				{
					Instruction instruction = cilBody_0.Instructions[i];
					if (c7u.ContainsKey(instruction.Offset))
					{
						stack = c7u[instruction.Offset];
					}
					c7u[instruction.Offset] = stack;
					instruction.UpdateStack(ref stack, bool_0);
					e7V[instruction.Offset] = stack;
					switch (instruction.OpCode.FlowControl)
					{
					case FlowControl.Branch:
					{
						uint offset = ((Instruction)instruction.Operand).Offset;
						if (!c7u.ContainsKey(offset))
						{
							c7u[offset] = stack;
						}
						e7Z(B7v, offset);
						I7O.AddListEntry(offset, instruction);
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
								if (!c7u.ContainsKey(instruction2.Offset))
								{
									c7u[instruction2.Offset] = stack;
								}
								e7Z(B7v, instruction2.Offset);
								I7O.AddListEntry(instruction2.Offset, instruction);
							}
						}
						else
						{
							uint offset = ((Instruction)instruction.Operand).Offset;
							if (!c7u.ContainsKey(offset))
							{
								c7u[offset] = stack;
							}
							e7Z(B7v, offset);
							I7O.AddListEntry(offset, instruction);
						}
						goto case FlowControl.Break;
					case FlowControl.Break:
					case FlowControl.Meta:
					case FlowControl.Next:
						if (i + 1 < cilBody_0.Instructions.Count)
						{
							uint offset = cilBody_0.Instructions[i + 1].Offset;
							e7Z(B7v, offset);
						}
						break;
					case FlowControl.Return:
					case FlowControl.Throw:
						break;
					default:
						throw new Exception();
					}
				}
			}

			public bool M7F(uint uint_0)
			{
				if (I7O.TryGetValue(uint_0, out var value))
				{
					return value.Count > 0;
				}
				return false;
			}

			public bool A7D(uint uint_0)
			{
				if (!B7v.TryGetValue(uint_0, out var value))
				{
					return false;
				}
				return value > 1;
			}
		}

		[Serializable]
		[CompilerGenerated]
		private sealed class k74
		{
			public static readonly k74 e7B;

			public static Func<Instruction[], Instruction> e7p;

			public static Func<Instruction, bool> s7X;

			static k74()
			{
				e7B = new k74();
			}

			internal Instruction u7s(Instruction[] instruction_0)
			{
				return instruction_0.Last();
			}

			internal bool W7Y(Instruction instruction_0)
			{
				return instruction_0.Operand is Instruction[];
			}
		}

		[CompilerGenerated]
		private sealed class y7g
		{
			public S7i N7n;

			public Local g7K;

			public MethodDef T7G;

			public CilBody A7j;
		}

		[CompilerGenerated]
		private sealed class L71
		{
			public bxd.y7w d7S;

			public y7g R7b;
		}

		[CompilerGenerated]
		private sealed class k7E
		{
			public LinkedList<Instruction[]> K7M;

			public HashSet<Instruction> E7e;

			public List<Instruction> U7C;

			public L71 W7J;

			public Func<Instruction, bool> i7z;

			public Func<Instruction, bool> whc;

			public Func<Instruction, bool> lh2;

			internal bool c7f(IList<Instruction> ilist_0)
			{
				return ilist_0.Any(delegate(Instruction instruction_0)
				{
					if (!W7J.R7b.N7n.A7D(instruction_0.Offset))
					{
						if (W7J.R7b.N7n.I7O.TryGetValue(instruction_0.Offset, out var value))
						{
							if (value.Any(k74.e7B.W7Y))
							{
								return true;
							}
							if (value.Any((Instruction instruction) => instruction.Offset <= K7M.First.Value.Last().Offset || instruction.Offset >= W7J.d7S.w7R().Last().Offset))
							{
								return true;
							}
							if (value.Any((Instruction item) => E7e.Contains(item)))
							{
								return true;
							}
						}
						return false;
					}
					return true;
				});
			}

			internal bool k7W(Instruction instruction_0)
			{
				if (!W7J.R7b.N7n.A7D(instruction_0.Offset))
				{
					if (W7J.R7b.N7n.I7O.TryGetValue(instruction_0.Offset, out var value))
					{
						if (value.Any(k74.e7B.W7Y))
						{
							return true;
						}
						if (value.Any((Instruction instruction) => instruction.Offset <= K7M.First.Value.Last().Offset || instruction.Offset >= W7J.d7S.w7R().Last().Offset))
						{
							return true;
						}
						if (value.Any((Instruction item) => E7e.Contains(item)))
						{
							return true;
						}
					}
					return false;
				}
				return true;
			}

			internal bool M7H(Instruction instruction_0)
			{
				return instruction_0.Offset <= K7M.First.Value.Last().Offset || instruction_0.Offset >= W7J.d7S.w7R().Last().Offset;
			}

			internal bool d7d(Instruction instruction_0)
			{
				return E7e.Contains(instruction_0);
			}

			internal void x73(Instruction instruction_0, int int_0)
			{
				U7C.Add(Instruction.Create(OpCodes.Ldloc, W7J.R7b.g7K));
				Local local = new Local(W7J.R7b.T7G.Module.CorLibTypes.Int32);
				W7J.R7b.A7j.Variables.Add(local);
				new ThirdMutationStage().GenerateExpressionMutation(M9F, W7J.R7b.T7G, local, U7C, int_0, M9F.NextInt32(0, 2));
				U7C.Add(Instruction.Create(OpCodes.Beq, instruction_0));
			}
		}

		[CompilerGenerated]
		private ModuleDefMD B9Z;

		private static RandomGenerator M9F;

		private static Random G9D;

		private static Random p9v;

		[SpecialName]
		[CompilerGenerated]
		public ModuleDefMD P9I()
		{
			return B9Z;
		}

		[SpecialName]
		[CompilerGenerated]
		public void r9T(ModuleDefMD moduleDefMD_0)
		{
			B9Z = moduleDefMD_0;
		}

		private static OpCode b9U(object object_0)
		{
			switch (((OpCode)object_0).Code)
			{
			default:
				throw new NotSupportedException();
			case Code.Brfalse:
				return OpCodes.Brtrue;
			case Code.Brtrue:
				return OpCodes.Brfalse;
			case Code.Beq:
				return OpCodes.Bne_Un;
			case Code.Bge:
				return OpCodes.Blt;
			case Code.Bgt:
				return OpCodes.Ble;
			case Code.Ble:
				return OpCodes.Bgt;
			case Code.Blt:
				return OpCodes.Bge;
			case Code.Bne_Un:
				return OpCodes.Beq;
			case Code.Bge_Un:
				return OpCodes.Blt_Un;
			case Code.Bgt_Un:
				return OpCodes.Ble_Un;
			case Code.Ble_Un:
				return OpCodes.Bgt_Un;
			case Code.Blt_Un:
				return OpCodes.Bge_Un;
			}
		}

		protected static IEnumerable<bxd.y7w> r9k(bxd.tLd tLd_0)
		{
			foreach (bxd.CLb item in tLd_0.l7c())
			{
				if (!(item is bxd.y7w))
				{
					foreach (bxd.y7w item2 in r9k((bxd.tLd)item))
					{
						yield return item2;
					}
				}
				else
				{
					yield return (bxd.y7w)item;
				}
			}
		}

		public void N9a(CilBody cilBody_0, bxd.tLd tLd_0, XContext xcontext_0, MethodDef methodDef_0, TypeSig typeSig_0)
		{
			y7g y7g = new y7g();
			y7g.T7G = methodDef_0;
			y7g.A7j = cilBody_0;
			if (JunkFlow.JunkMethod == null)
			{
				new JunkFlow().injectCFJunk(xcontext_0);
			}
			XCore.Utils.Utils.CreateBoolMethod(xcontext_0.Module);
			M9F = new RandomGenerator(GGeneration.GenerateGuidStartingWithLetter(), GGeneration.GenerateGuidStartingWithLetter());
			r9T(xcontext_0.Module);
			y7g.N7n = new S7i(y7g.A7j, typeSig_0.RemoveModifiers().ElementType != ElementType.Void);
			y7g.g7K = new Local(y7g.T7G.Module.CorLibTypes.UInt32);
			y7g.A7j.Variables.Add(y7g.g7K);
			Local local = new Local(y7g.T7G.Module.ImportAsTypeSig(typeof(uint[])));
			y7g.A7j.Variables.Add(local);
			Local local2 = new Local(y7g.T7G.Module.ImportAsTypeSig(typeof(string)));
			y7g.A7j.Variables.Add(local2);
			Local local3 = new Local(y7g.T7G.Module.CorLibTypes.UInt32);
			y7g.A7j.Variables.Add(local3);
			y7g.A7j.MaxStack += 2;
			y7g.A7j.InitLocals = true;
			k9R k9R2 = null;
			using (IEnumerator<bxd.y7w> enumerator = r9k(tLd_0).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					L71 l = new L71();
					l.R7b = y7g;
					l.d7S = enumerator.Current;
					k7E CS_0024_003C_003E8__locals71 = new k7E();
					CS_0024_003C_003E8__locals71.W7J = l;
					CS_0024_003C_003E8__locals71.K7M = X9r(CS_0024_003C_003E8__locals71.W7J.d7S, CS_0024_003C_003E8__locals71.W7J.R7b.N7n);
					if (CS_0024_003C_003E8__locals71.W7J.R7b.T7G.IsInstanceConstructor)
					{
						List<Instruction> list = new List<Instruction>();
						while (CS_0024_003C_003E8__locals71.K7M.First != null)
						{
							list.AddRange(CS_0024_003C_003E8__locals71.K7M.First.Value);
							Instruction instruction = CS_0024_003C_003E8__locals71.K7M.First.Value.Last();
							CS_0024_003C_003E8__locals71.K7M.RemoveFirst();
							if (instruction.OpCode == OpCodes.Call && ((IMethod)instruction.Operand).Name == ".ctor")
							{
								break;
							}
						}
						CS_0024_003C_003E8__locals71.K7M.AddFirst(list.ToArray());
					}
					if (CS_0024_003C_003E8__locals71.K7M.Count < 3)
					{
						continue;
					}
					int[] array = Enumerable.Range(0, CS_0024_003C_003E8__locals71.K7M.Count).ToArray();
					T96(array);
					int[] array2 = new int[array.Length];
					int i;
					for (i = 0; i < array2.Length; i++)
					{
						int num = M9F.NextInt32() & 0x7FFFFFFF;
						array2[i] = num - num % CS_0024_003C_003E8__locals71.K7M.Count + array[i];
					}
					Dictionary<Instruction, int> dictionary = new Dictionary<Instruction, int>();
					LinkedListNode<Instruction[]> linkedListNode = CS_0024_003C_003E8__locals71.K7M.First;
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
					CS_0024_003C_003E8__locals71.E7e = new HashSet<Instruction>(CS_0024_003C_003E8__locals71.K7M.Select((Instruction[] instruction_0) => instruction_0.Last()));
					Func<IList<Instruction>, bool> func = (IList<Instruction> ilist_0) => ilist_0.Any(delegate(Instruction instruction_0)
					{
						if (!CS_0024_003C_003E8__locals71.W7J.R7b.N7n.A7D(instruction_0.Offset))
						{
							if (CS_0024_003C_003E8__locals71.W7J.R7b.N7n.I7O.TryGetValue(instruction_0.Offset, out var value6))
							{
								if (value6.Any(k74.e7B.W7Y))
								{
									return true;
								}
								if (value6.Any((Instruction instruction6) => instruction6.Offset <= CS_0024_003C_003E8__locals71.K7M.First.Value.Last().Offset || instruction6.Offset >= CS_0024_003C_003E8__locals71.W7J.d7S.w7R().Last().Offset))
								{
									return true;
								}
								if (value6.Any((Instruction item2) => CS_0024_003C_003E8__locals71.E7e.Contains(item2)))
								{
									return true;
								}
							}
							return false;
						}
						return true;
					});
					Instruction instruction2 = new Instruction(OpCodes.Switch);
					CS_0024_003C_003E8__locals71.U7C = new List<Instruction>();
					if (k9R2 != null)
					{
						k9R2.pPA(CS_0024_003C_003E8__locals71.W7J.R7b.A7j);
						CS_0024_003C_003E8__locals71.U7C.Add(Instruction.CreateLdcI4(k9R2.oPI(array2[1])));
						k9R2.PPl(CS_0024_003C_003E8__locals71.U7C);
					}
					else
					{
						CS_0024_003C_003E8__locals71.U7C.Add(Instruction.CreateLdcI4(array2[1]));
					}
					CS_0024_003C_003E8__locals71.U7C.Add(Instruction.Create(OpCodes.Ldc_I4, array2[1]));
					CS_0024_003C_003E8__locals71.U7C.Add(Instruction.Create(OpCodes.Stloc, CS_0024_003C_003E8__locals71.W7J.R7b.g7K));
					CS_0024_003C_003E8__locals71.U7C.Add(Instruction.Create(OpCodes.Ldc_I4, M9F.NextInt32()));
					CS_0024_003C_003E8__locals71.U7C.Add(Instruction.Create(OpCodes.Ldc_I4, 0));
					CS_0024_003C_003E8__locals71.U7C.Add(Instruction.Create(OpCodes.Xor));
					CS_0024_003C_003E8__locals71.U7C.Add(Instruction.Create(OpCodes.Stloc, CS_0024_003C_003E8__locals71.W7J.R7b.g7K));
					CS_0024_003C_003E8__locals71.U7C.Add(Instruction.Create(OpCodes.Dup));
					CS_0024_003C_003E8__locals71.U7C.Add(Instruction.Create(OpCodes.Stloc, CS_0024_003C_003E8__locals71.W7J.R7b.g7K));
					CS_0024_003C_003E8__locals71.U7C.Add(Instruction.Create(OpCodes.Ldc_I4, CS_0024_003C_003E8__locals71.K7M.Count));
					CS_0024_003C_003E8__locals71.U7C.Add(Instruction.Create(OpCodes.Rem_Un));
					CS_0024_003C_003E8__locals71.U7C.Add(instruction2);
					Instruction[] array3 = new Instruction[CS_0024_003C_003E8__locals71.K7M.Count];
					linkedListNode = CS_0024_003C_003E8__locals71.K7M.First;
					i = 0;
					while (linkedListNode.Next != null)
					{
						List<Instruction> list_ = new List<Instruction>(linkedListNode.Value);
						if (i == 0)
						{
							array3[array[i]] = CS_0024_003C_003E8__locals71.U7C[0];
						}
						else
						{
							List<Instruction> collection = list_.ToList();
							list_.Clear();
							Instruction instruction3 = new Instruction(OpCodes.Nop);
							list_.Add(Instruction.Create(OpCodes.Ldsfld, xcontext_0.Module.Import(typeof(string).GetField("Empty"))));
							list_.Add(Instruction.Create(OpCodes.Stloc, local2));
							list_.Add(Instruction.Create(OpCodes.Ldloc, local2));
							list_.Add(Instruction.Create(OpCodes.Ldstr, ""));
							list_.Add(Instruction.Create(OpCodes.Call, xcontext_0.Module.Import(typeof(string).GetMethod("op_Inequality"))));
							list_.Add(Instruction.Create(OpCodes.Brtrue, instruction3));
							list_.AddRange(collection);
							list_.Add(instruction3);
							bool flag = func(list_);
							bool flag2 = false;
							if (list_.Last().IsBr())
							{
								Instruction key = (Instruction)list_.Last().Operand;
								if (!CS_0024_003C_003E8__locals71.W7J.R7b.N7n.M7F(list_.Last().Offset) && dictionary.TryGetValue(key, out var value))
								{
									int num2 = k9R2?.oPI(value) ?? value;
									list_.RemoveAt(list_.Count - 1);
									if (!flag)
									{
										int num3 = array2[i];
										int num4 = M9F.NextInt32();
										list_.Add(Instruction.Create(OpCodes.Ldloc, CS_0024_003C_003E8__locals71.W7J.R7b.g7K));
										list_.Add(Instruction.CreateLdcI4(num4));
										list_.Add(Instruction.Create(OpCodes.Sub));
										list_.Add(Instruction.Create(OpCodes.Ldc_I4, (num3 - num4) ^ num2));
										list_.Add(Instruction.Create(OpCodes.Xor));
									}
									else
									{
										list_.Add(Instruction.Create(OpCodes.Ldc_I4, num2));
									}
									Y9A(list_, CS_0024_003C_003E8__locals71.U7C[1], CS_0024_003C_003E8__locals71.W7J.R7b.T7G);
									Y9l(list_, CS_0024_003C_003E8__locals71.W7J.R7b.T7G);
									array3[array[i]] = list_[0];
									flag2 = true;
								}
							}
							else if (list_.Last().IsConditionalBranch())
							{
								Instruction key2 = (Instruction)list_.Last().Operand;
								if (!CS_0024_003C_003E8__locals71.W7J.R7b.N7n.M7F(list_.Last().Offset) && dictionary.TryGetValue(key2, out var value2))
								{
									int num5 = array2[i + 1];
									OpCode opCode = list_.Last().OpCode;
									list_.RemoveAt(list_.Count - 1);
									if (M9F.NextBoolean())
									{
										opCode = b9U(opCode);
										int num6 = value2;
										value2 = num5;
										num5 = num6;
									}
									int num7 = array2[i];
									int num8 = 0;
									int num9 = 0;
									if (!flag)
									{
										num8 = M9F.NextInt32();
										num9 = num7 - num8;
									}
									Instruction instruction4 = Instruction.CreateLdcI4(num9 ^ (k9R2?.oPI(value2) ?? value2));
									Instruction item = Instruction.CreateLdcI4(num9 ^ (k9R2?.oPI(num5) ?? num5));
									Instruction instruction5 = Instruction.Create(OpCodes.Pop);
									list_.Add(Instruction.Create(opCode, instruction4));
									list_.Add(item);
									list_.Add(Instruction.Create(OpCodes.Dup));
									list_.Add(Instruction.Create(OpCodes.Br, instruction5));
									list_.Add(instruction4);
									list_.Add(Instruction.Create(OpCodes.Dup));
									list_.Add(instruction5);
									if (!flag)
									{
										_ = k9R2?.oPI(array2[i + 1]) ?? array2[i + 1];
										list_.Add(Instruction.Create(OpCodes.Ldloc, CS_0024_003C_003E8__locals71.W7J.R7b.g7K));
										list_.Add(Instruction.CreateLdcI4(num8));
										list_.Add(Instruction.Create(OpCodes.Sub));
										list_.Add(Instruction.Create(OpCodes.Xor));
									}
									Y9A(list_, CS_0024_003C_003E8__locals71.U7C[1], CS_0024_003C_003E8__locals71.W7J.R7b.T7G);
									Y9l(list_, CS_0024_003C_003E8__locals71.W7J.R7b.T7G);
									array3[array[i]] = list_[0];
									flag2 = true;
								}
							}
							if (!flag2)
							{
								int num10 = k9R2?.oPI(array2[i + 1]) ?? array2[i + 1];
								if (!func(list_))
								{
									int num11 = array2[i];
									int num12 = M9F.NextInt32();
									int[] array4 = v90(1);
									int num13 = array4[array4.Length - 1];
									int value3 = (num11 - num13) ^ num10;
									list_.Add(OpCodes.Ldc_I4.ToInstruction(num11 - num12));
									list_.Add(OpCodes.Ldc_I4.ToInstruction((num11 - num12) ^ num10));
									list_.Add(OpCodes.Xor.ToInstruction());
									list_.Add(OpCodes.Stloc.ToInstruction(local3));
									n9Q(CS_0024_003C_003E8__locals71.W7J.R7b.T7G, array4, ref list_, local);
									list_.Add(OpCodes.Ldloc.ToInstruction(CS_0024_003C_003E8__locals71.W7J.R7b.g7K));
									list_.Add(OpCodes.Ldloc_S.ToInstruction(local));
									list_.Add(OpCodes.Ldc_I4.ToInstruction(array4.Length - 1));
									list_.Add(OpCodes.Ldelem_I4.ToInstruction());
									list_.Add(OpCodes.Sub.ToInstruction());
									list_.Add(OpCodes.Stloc.ToInstruction(local3));
									list_.Add(OpCodes.Ldloc.ToInstruction(local3));
									list_.Add(OpCodes.Ldc_I4.ToInstruction(value3));
									list_.Add(OpCodes.Xor.ToInstruction());
									CS_0024_003C_003E8__locals71.x73(list_[0], array[i]);
									Shuffler.cflowShuffle(list_);
								}
								else
								{
									list_.Add(Instruction.Create(OpCodes.Ldc_I4, num10));
								}
								Y9A(list_, CS_0024_003C_003E8__locals71.U7C[1], CS_0024_003C_003E8__locals71.W7J.R7b.T7G);
								Y9l(list_, CS_0024_003C_003E8__locals71.W7J.R7b.T7G);
								array3[array[i]] = list_[0];
							}
						}
						linkedListNode.Value = list_.ToArray();
						linkedListNode = linkedListNode.Next;
						i++;
					}
					array3[array[i]] = linkedListNode.Value[0];
					instruction2.Operand = array3;
					Instruction[] value4 = CS_0024_003C_003E8__locals71.K7M.First.Value;
					CS_0024_003C_003E8__locals71.K7M.RemoveFirst();
					Instruction[] value5 = CS_0024_003C_003E8__locals71.K7M.Last.Value;
					CS_0024_003C_003E8__locals71.K7M.RemoveLast();
					List<Instruction[]> list2 = CS_0024_003C_003E8__locals71.K7M.ToList();
					CS_0024_003C_003E8__locals71.W7J.d7S.w7R().Clear();
					CS_0024_003C_003E8__locals71.W7J.d7S.w7R().AddRange(value4);
					CS_0024_003C_003E8__locals71.W7J.d7S.w7R().AddRange(CS_0024_003C_003E8__locals71.U7C);
					foreach (Instruction[] item2 in list2)
					{
						CS_0024_003C_003E8__locals71.W7J.d7S.w7R().AddRange(item2);
					}
					CS_0024_003C_003E8__locals71.W7J.d7S.w7R().AddRange(value5);
				}
			}
		}

		private static int[] v90(int int_0)
		{
			if (int_0 == 1)
			{
				return new int[1] { p9v.Next(2, 4) };
			}
			int[] array = new int[int_0];
			for (int i = 0; i < int_0; i++)
			{
				array[i] = p9v.Next(2, 4);
			}
			return array;
		}

		private static void n9Q(MethodDef methodDef_0, object object_0, ref List<Instruction> list_0, Local local_0)
		{
			list_0.Add(OpCodes.Ldc_I4.ToInstruction(((Array)object_0).Length));
			list_0.Add(OpCodes.Newarr.ToInstruction(methodDef_0.Module.CorLibTypes.Int32));
			list_0.Add(OpCodes.Stloc_S.ToInstruction(local_0));
			for (int i = 0; i < ((Array)object_0).Length; i++)
			{
				list_0.Add(OpCodes.Ldloc_S.ToInstruction(local_0));
				list_0.Add(OpCodes.Ldc_I4.ToInstruction(i));
				list_0.Add(OpCodes.Ldc_I4.ToInstruction(((int[])object_0)[i]));
				list_0.Add(OpCodes.Stelem_I4.ToInstruction());
			}
		}

		private LinkedList<Instruction[]> X9r(bxd.y7w y7w_0, S7i s7i_0)
		{
			LinkedList<Instruction[]> linkedList = new LinkedList<Instruction[]>();
			List<Instruction> list = new List<Instruction>();
			HashSet<Instruction> hashSet = new HashSet<Instruction>();
			for (int i = 0; i < y7w_0.w7R().Count; i++)
			{
				Instruction instruction = y7w_0.w7R()[i];
				list.Add(instruction);
				if (i + 1 < y7w_0.w7R().Count)
				{
					s7i_0.A7D(y7w_0.w7R()[i + 1].Offset);
				}
				else
					_ = 0;
				FlowControl flowControl = instruction.OpCode.FlowControl;
				FlowControl flowControl2 = flowControl;
				if ((flowControl2 == FlowControl.Branch || flowControl2 == FlowControl.Cond_Branch || (uint)(flowControl2 - 7) <= 1u) && s7i_0.e7V[instruction.Offset] != 0)
				{
					if (instruction.Operand is Instruction item)
					{
						hashSet.Add(item);
					}
					else if (instruction.Operand is Instruction[] array)
					{
						Instruction[] array2 = array;
						foreach (Instruction item2 in array2)
						{
							hashSet.Add(item2);
						}
					}
				}
				hashSet.Remove(instruction);
				if (instruction.OpCode.OpCodeType != OpCodeType.Prefix && s7i_0.e7V[instruction.Offset] == 0 && hashSet.Count == 0)
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

		public void T96<Q9q>(IList<Q9q> ilist_0)
		{
			for (int num = ilist_0.Count - 1; num > 1; num--)
			{
				int index = new Random().Next(num + 1);
				Q9q value = ilist_0[index];
				ilist_0[index] = ilist_0[num];
				ilist_0[num] = value;
			}
		}

		public void Y9A(IList<Instruction> ilist_0, Instruction instruction_0, MethodDef methodDef_0)
		{
			if (!methodDef_0.Module.IsClr40 && !methodDef_0.DeclaringType.HasGenericParameters && !methodDef_0.HasGenericParameters && (ilist_0[0].OpCode.FlowControl == FlowControl.Call || ilist_0[0].OpCode.FlowControl == FlowControl.Next))
			{
				switch (M9F.NextInt32(3))
				{
				case 0:
					ilist_0.Add(Instruction.Create(OpCodes.Ldc_I4_0));
					ilist_0.Add(Instruction.Create(OpCodes.Brtrue, ilist_0[0]));
					break;
				case 1:
					ilist_0.Add(Instruction.Create(OpCodes.Ldc_I4_1));
					ilist_0.Add(Instruction.Create(OpCodes.Brfalse, ilist_0[0]));
					break;
				case 2:
				{
					bool flag = false;
					if (M9F.NextBoolean())
					{
						TypeDef typeDef = methodDef_0.Module.Types[M9F.NextInt32(methodDef_0.Module.Types.Count)];
						if (typeDef.HasMethods)
						{
							ilist_0.Add(Instruction.Create(OpCodes.Ldtoken, typeDef.Methods[M9F.NextInt32(typeDef.Methods.Count)]));
							ilist_0.Add(Instruction.Create(OpCodes.Box, methodDef_0.Module.CorLibTypes.GetTypeRef("System", "RuntimeMethodHandle")));
							flag = true;
						}
					}
					if (!flag)
					{
						ilist_0.Add(Instruction.Create(OpCodes.Ldc_I4, (!M9F.NextBoolean()) ? 1 : 0));
						ilist_0.Add(Instruction.Create(OpCodes.Box, methodDef_0.Module.CorLibTypes.Int32.TypeDefOrRef));
					}
					Instruction item = Instruction.Create(OpCodes.Pop);
					ilist_0.Add(Instruction.Create(OpCodes.Brfalse, ilist_0[0]));
					ilist_0.Add(Instruction.Create(OpCodes.Ldc_I4, (!M9F.NextBoolean()) ? 1 : 0));
					ilist_0.Add(item);
					break;
				}
				}
			}
			ilist_0.Add(Instruction.Create(OpCodes.Br, instruction_0));
		}

		public void Y9l(IList<Instruction> ilist_0, MethodDef methodDef_0)
		{
			if (!methodDef_0.Module.IsClr40)
			{
				switch (M9F.NextInt32(6))
				{
				case 0:
					ilist_0.Add(Instruction.Create(OpCodes.Pop));
					break;
				case 1:
					ilist_0.Add(Instruction.Create(OpCodes.Dup));
					break;
				case 2:
					ilist_0.Add(Instruction.Create(OpCodes.Throw));
					break;
				case 3:
					ilist_0.Add(Instruction.Create(OpCodes.Ldarg, new Parameter(255)));
					break;
				case 4:
					ilist_0.Add(Instruction.Create(OpCodes.Ldloc, new Local(null, null, 255)));
					break;
				case 5:
					ilist_0.Add(Instruction.Create(OpCodes.Ldtoken, methodDef_0));
					break;
				}
			}
		}

		static H9P()
		{
			G9D = new Random();
			p9v = new Random();
		}
	}
}
