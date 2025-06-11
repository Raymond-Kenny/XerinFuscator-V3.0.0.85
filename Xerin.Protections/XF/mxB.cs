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
	internal class mxB
	{
		private struct JmM
		{
			public Dictionary<uint, int> zLc;

			public Dictionary<uint, List<Instruction>> EL2;

			public Dictionary<uint, int> vL8;

			public Dictionary<uint, int> XLx;

			private static void Ime(Dictionary<uint, int> dictionary_0, uint uint_0)
			{
				if (!dictionary_0.TryGetValue(uint_0, out var value))
				{
					value = 0;
				}
				dictionary_0[uint_0] = value + 1;
			}

			public JmM(CilBody cilBody_0, bool bool_0)
			{
				zLc = new Dictionary<uint, int>();
				EL2 = new Dictionary<uint, List<Instruction>>();
				vL8 = new Dictionary<uint, int>();
				XLx = new Dictionary<uint, int>();
				cilBody_0.UpdateInstructionOffsets();
				foreach (ExceptionHandler exceptionHandler in cilBody_0.ExceptionHandlers)
				{
					vL8[exceptionHandler.TryStart.Offset] = 0;
					vL8[exceptionHandler.HandlerStart.Offset] = ((exceptionHandler.HandlerType != ExceptionHandlerType.Finally) ? 1 : 0);
					if (exceptionHandler.FilterStart != null)
					{
						vL8[exceptionHandler.FilterStart.Offset] = 1;
					}
				}
				int stack = 0;
				for (int i = 0; i < cilBody_0.Instructions.Count; i++)
				{
					Instruction instruction = cilBody_0.Instructions[i];
					if (vL8.ContainsKey(instruction.Offset))
					{
						stack = vL8[instruction.Offset];
					}
					vL8[instruction.Offset] = stack;
					instruction.UpdateStack(ref stack, bool_0);
					XLx[instruction.Offset] = stack;
					switch (instruction.OpCode.FlowControl)
					{
					case FlowControl.Branch:
					{
						uint offset = ((Instruction)instruction.Operand).Offset;
						if (!vL8.ContainsKey(offset))
						{
							vL8[offset] = stack;
						}
						Ime(zLc, offset);
						EL2.AddListEntry(offset, instruction);
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
								if (!vL8.ContainsKey(instruction2.Offset))
								{
									vL8[instruction2.Offset] = stack;
								}
								Ime(zLc, instruction2.Offset);
								EL2.AddListEntry(instruction2.Offset, instruction);
							}
						}
						else
						{
							uint offset = ((Instruction)instruction.Operand).Offset;
							if (!vL8.ContainsKey(offset))
							{
								vL8[offset] = stack;
							}
							Ime(zLc, offset);
							EL2.AddListEntry(offset, instruction);
						}
						goto case FlowControl.Break;
					case FlowControl.Break:
					case FlowControl.Meta:
					case FlowControl.Next:
						if (i + 1 < cilBody_0.Instructions.Count)
						{
							uint offset = cilBody_0.Instructions[i + 1].Offset;
							Ime(zLc, offset);
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

			public bool FmC(uint uint_0)
			{
				if (EL2.TryGetValue(uint_0, out var value))
				{
					return value.Count > 0;
				}
				return false;
			}

			public bool Wmz(uint uint_0)
			{
				if (!zLc.TryGetValue(uint_0, out var value))
				{
					return false;
				}
				return value > 1;
			}
		}

		[Serializable]
		[CompilerGenerated]
		private sealed class uL9
		{
			public static readonly uL9 ULm;

			public static Func<Instruction[], Instruction> ELL;

			public static Func<Instruction, bool> PL7;

			static uL9()
			{
				ULm = new uL9();
			}

			internal Instruction XLw(Instruction[] instruction_0)
			{
				return instruction_0.Last();
			}

			internal bool uLR(Instruction instruction_0)
			{
				return instruction_0.Operand is Instruction[];
			}
		}

		[CompilerGenerated]
		private sealed class QLh
		{
			public JmM oL5;

			public Local dLN;

			public MethodDef GLP;

			public CilBody pLU;
		}

		[CompilerGenerated]
		private sealed class aLk
		{
			public bxd.y7w mLa;

			public QLh gL0;
		}

		[CompilerGenerated]
		private sealed class DLQ
		{
			public LinkedList<Instruction[]> KLI;

			public HashSet<Instruction> vLT;

			public List<Instruction> xLi;

			public aLk wLZ;

			public Func<Instruction, bool> KLF;

			public Func<Instruction, bool> kLD;

			public Func<Instruction, bool> JLv;

			internal bool BLr(IList<Instruction> ilist_0)
			{
				return ilist_0.Any(delegate(Instruction instruction_0)
				{
					if (!wLZ.gL0.oL5.Wmz(instruction_0.Offset))
					{
						if (wLZ.gL0.oL5.EL2.TryGetValue(instruction_0.Offset, out var value))
						{
							if (value.Any(uL9.ULm.uLR))
							{
								return true;
							}
							if (value.Any((Instruction instruction) => instruction.Offset <= KLI.First.Value.Last().Offset || instruction.Offset >= wLZ.mLa.w7R().Last().Offset))
							{
								return true;
							}
							if (value.Any((Instruction item) => vLT.Contains(item)))
							{
								return true;
							}
						}
						return false;
					}
					return true;
				});
			}

			internal bool wL6(Instruction instruction_0)
			{
				if (!wLZ.gL0.oL5.Wmz(instruction_0.Offset))
				{
					if (wLZ.gL0.oL5.EL2.TryGetValue(instruction_0.Offset, out var value))
					{
						if (value.Any(uL9.ULm.uLR))
						{
							return true;
						}
						if (value.Any((Instruction instruction) => instruction.Offset <= KLI.First.Value.Last().Offset || instruction.Offset >= wLZ.mLa.w7R().Last().Offset))
						{
							return true;
						}
						if (value.Any((Instruction item) => vLT.Contains(item)))
						{
							return true;
						}
					}
					return false;
				}
				return true;
			}

			internal bool kLq(Instruction instruction_0)
			{
				return instruction_0.Offset <= KLI.First.Value.Last().Offset || instruction_0.Offset >= wLZ.mLa.w7R().Last().Offset;
			}

			internal bool GLA(Instruction instruction_0)
			{
				return vLT.Contains(instruction_0);
			}

			internal void XLl(Instruction instruction_0, int int_0)
			{
				xLi.Add(Instruction.Create(OpCodes.Ldloc, wLZ.gL0.dLN));
				Local local = new Local(wLZ.gL0.GLP.Module.CorLibTypes.Int32);
				wLZ.gL0.pLU.Variables.Add(local);
				new ThirdMutationStage().GenerateExpressionMutation(dxt, wLZ.gL0.GLP, local, xLi, int_0, dxt.NextInt32(1, 2));
				xLi.Add(Instruction.Create(OpCodes.Beq, instruction_0));
			}
		}

		[CompilerGenerated]
		private ModuleDefMD UxE;

		private static RandomGenerator dxt;

		private static Random Fxf;

		[SpecialName]
		[CompilerGenerated]
		public ModuleDefMD ix1()
		{
			return UxE;
		}

		[SpecialName]
		[CompilerGenerated]
		public void pxS(ModuleDefMD moduleDefMD_0)
		{
			UxE = moduleDefMD_0;
		}

		private static OpCode qxp(object object_0)
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

		protected static IEnumerable<bxd.y7w> Ixy(bxd.tLd tLd_0)
		{
			foreach (bxd.CLb item in tLd_0.l7c())
			{
				if (!(item is bxd.y7w))
				{
					foreach (bxd.y7w item2 in Ixy((bxd.tLd)item))
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

		public void txg(CilBody cilBody_0, bxd.tLd tLd_0, XContext xcontext_0, MethodDef methodDef_0, TypeSig typeSig_0)
		{
			QLh qLh = new QLh();
			qLh.GLP = methodDef_0;
			qLh.pLU = cilBody_0;
			if (JunkFlow.JunkMethod == null)
			{
				new JunkFlow().injectCFJunk(xcontext_0);
			}
			XCore.Utils.Utils.CreateBoolMethod(xcontext_0.Module);
			dxt = new RandomGenerator(default(Guid).ToString(), default(Guid).ToString());
			pxS(xcontext_0.Module);
			qLh.oL5 = new JmM(qLh.pLU, typeSig_0.RemoveModifiers().ElementType != ElementType.Void);
			qLh.dLN = new Local(qLh.GLP.Module.CorLibTypes.UInt32);
			qLh.pLU.Variables.Add(qLh.dLN);
			Local local = new Local(qLh.GLP.Module.ImportAsTypeSig(typeof(string)));
			qLh.pLU.Variables.Add(local);
			qLh.pLU.InitLocals = true;
			qLh.pLU.MaxStack += 2;
			k9R k9R2 = null;
			using (IEnumerator<bxd.y7w> enumerator = Ixy(tLd_0).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					aLk aLk = new aLk();
					aLk.gL0 = qLh;
					aLk.mLa = enumerator.Current;
					DLQ CS_0024_003C_003E8__locals70 = new DLQ();
					CS_0024_003C_003E8__locals70.wLZ = aLk;
					CS_0024_003C_003E8__locals70.KLI = txo(CS_0024_003C_003E8__locals70.wLZ.mLa, CS_0024_003C_003E8__locals70.wLZ.gL0.oL5);
					if (CS_0024_003C_003E8__locals70.wLZ.gL0.GLP.IsInstanceConstructor)
					{
						List<Instruction> list = new List<Instruction>();
						while (CS_0024_003C_003E8__locals70.KLI.First != null)
						{
							list.AddRange(CS_0024_003C_003E8__locals70.KLI.First.Value);
							Instruction instruction = CS_0024_003C_003E8__locals70.KLI.First.Value.Last();
							CS_0024_003C_003E8__locals70.KLI.RemoveFirst();
							if (instruction.OpCode == OpCodes.Call && ((IMethod)instruction.Operand).Name == ".ctor")
							{
								break;
							}
						}
						CS_0024_003C_003E8__locals70.KLI.AddFirst(list.ToArray());
					}
					if (CS_0024_003C_003E8__locals70.KLI.Count < 3)
					{
						continue;
					}
					int[] array = Enumerable.Range(0, CS_0024_003C_003E8__locals70.KLI.Count).ToArray();
					Qxn(array);
					int[] array2 = new int[array.Length];
					int i;
					for (i = 0; i < array2.Length; i++)
					{
						int num = dxt.NextInt32() & 0x7FFFFFFF;
						array2[i] = num - num % CS_0024_003C_003E8__locals70.KLI.Count + array[i];
					}
					Dictionary<Instruction, int> dictionary = new Dictionary<Instruction, int>();
					LinkedListNode<Instruction[]> linkedListNode = CS_0024_003C_003E8__locals70.KLI.First;
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
					CS_0024_003C_003E8__locals70.vLT = new HashSet<Instruction>(CS_0024_003C_003E8__locals70.KLI.Select((Instruction[] instruction_0) => instruction_0.Last()));
					Func<IList<Instruction>, bool> func = (IList<Instruction> ilist_0) => ilist_0.Any(delegate(Instruction instruction_0)
					{
						if (!CS_0024_003C_003E8__locals70.wLZ.gL0.oL5.Wmz(instruction_0.Offset))
						{
							if (CS_0024_003C_003E8__locals70.wLZ.gL0.oL5.EL2.TryGetValue(instruction_0.Offset, out var value5))
							{
								if (value5.Any(uL9.ULm.uLR))
								{
									return true;
								}
								if (value5.Any((Instruction instruction6) => instruction6.Offset <= CS_0024_003C_003E8__locals70.KLI.First.Value.Last().Offset || instruction6.Offset >= CS_0024_003C_003E8__locals70.wLZ.mLa.w7R().Last().Offset))
								{
									return true;
								}
								if (value5.Any((Instruction item2) => CS_0024_003C_003E8__locals70.vLT.Contains(item2)))
								{
									return true;
								}
							}
							return false;
						}
						return true;
					});
					Instruction instruction2 = new Instruction(OpCodes.Switch);
					CS_0024_003C_003E8__locals70.xLi = new List<Instruction>();
					if (k9R2 != null)
					{
						k9R2.pPA(CS_0024_003C_003E8__locals70.wLZ.gL0.pLU);
						CS_0024_003C_003E8__locals70.xLi.Add(Instruction.CreateLdcI4(k9R2.oPI(array2[1])));
						k9R2.PPl(CS_0024_003C_003E8__locals70.xLi);
					}
					else
					{
						CS_0024_003C_003E8__locals70.xLi.Add(Instruction.CreateLdcI4(array2[1]));
					}
					CS_0024_003C_003E8__locals70.xLi.Add(Instruction.Create(OpCodes.Ldc_I4, array2[1]));
					CS_0024_003C_003E8__locals70.xLi.Add(Instruction.Create(OpCodes.Stloc, CS_0024_003C_003E8__locals70.wLZ.gL0.dLN));
					CS_0024_003C_003E8__locals70.xLi.Add(Instruction.Create(OpCodes.Ldc_I4, dxt.NextInt32()));
					CS_0024_003C_003E8__locals70.xLi.Add(Instruction.Create(OpCodes.Ldc_I4, 0));
					CS_0024_003C_003E8__locals70.xLi.Add(Instruction.Create(OpCodes.Xor));
					CS_0024_003C_003E8__locals70.xLi.Add(Instruction.Create(OpCodes.Stloc, CS_0024_003C_003E8__locals70.wLZ.gL0.dLN));
					CS_0024_003C_003E8__locals70.xLi.Add(Instruction.Create(OpCodes.Dup));
					CS_0024_003C_003E8__locals70.xLi.Add(Instruction.Create(OpCodes.Stloc, CS_0024_003C_003E8__locals70.wLZ.gL0.dLN));
					CS_0024_003C_003E8__locals70.xLi.Add(Instruction.Create(OpCodes.Ldc_I4, CS_0024_003C_003E8__locals70.KLI.Count));
					CS_0024_003C_003E8__locals70.xLi.Add(Instruction.Create(OpCodes.Rem_Un));
					CS_0024_003C_003E8__locals70.xLi.Add(instruction2);
					Instruction[] array3 = new Instruction[CS_0024_003C_003E8__locals70.KLI.Count];
					linkedListNode = CS_0024_003C_003E8__locals70.KLI.First;
					i = 0;
					while (linkedListNode.Next != null)
					{
						List<Instruction> list2 = new List<Instruction>(linkedListNode.Value);
						if (i != 0)
						{
							List<Instruction> collection = list2.ToList();
							list2.Clear();
							Instruction instruction3 = new Instruction(OpCodes.Nop);
							list2.Add(Instruction.Create(OpCodes.Ldsfld, xcontext_0.Module.Import(typeof(string).GetField("Empty"))));
							list2.Add(Instruction.Create(OpCodes.Stloc, local));
							list2.Add(Instruction.Create(OpCodes.Ldloc, local));
							list2.Add(Instruction.Create(OpCodes.Ldstr, ""));
							list2.Add(Instruction.Create(OpCodes.Call, xcontext_0.Module.Import(typeof(string).GetMethod("op_Inequality"))));
							list2.Add(Instruction.Create(OpCodes.Brtrue, instruction3));
							list2.AddRange(collection);
							list2.Add(instruction3);
							bool flag = func(list2);
							bool flag2 = false;
							if (!list2.Last().IsBr())
							{
								if (list2.Last().IsConditionalBranch())
								{
									Instruction key = (Instruction)list2.Last().Operand;
									if (!CS_0024_003C_003E8__locals70.wLZ.gL0.oL5.FmC(list2.Last().Offset) && dictionary.TryGetValue(key, out var value))
									{
										int num2 = array2[i + 1];
										OpCode opCode = list2.Last().OpCode;
										list2.RemoveAt(list2.Count - 1);
										if (dxt.NextBoolean())
										{
											opCode = qxp(opCode);
											int num3 = value;
											value = num2;
											num2 = num3;
										}
										int num4 = array2[i];
										int num5 = 0;
										int num6 = 0;
										if (!flag)
										{
											num5 = dxt.NextInt32();
											num6 = num4 - num5;
										}
										Instruction instruction4 = Instruction.CreateLdcI4(num6 ^ (k9R2?.oPI(value) ?? value));
										Instruction item = Instruction.CreateLdcI4(num6 ^ (k9R2?.oPI(num2) ?? num2));
										Instruction instruction5 = Instruction.Create(OpCodes.Pop);
										list2.Add(Instruction.Create(opCode, instruction4));
										list2.Add(item);
										list2.Add(Instruction.Create(OpCodes.Dup));
										list2.Add(Instruction.Create(OpCodes.Br, instruction5));
										list2.Add(instruction4);
										list2.Add(Instruction.Create(OpCodes.Dup));
										list2.Add(instruction5);
										if (!flag)
										{
											list2.Add(Instruction.Create(OpCodes.Ldloc, CS_0024_003C_003E8__locals70.wLZ.gL0.dLN));
											list2.Add(Instruction.CreateLdcI4(num5));
											list2.Add(Instruction.Create(OpCodes.Sub));
											list2.Add(Instruction.Create(OpCodes.Xor));
										}
										dxG(list2, CS_0024_003C_003E8__locals70.xLi[1], CS_0024_003C_003E8__locals70.wLZ.gL0.GLP);
										cxj(list2, CS_0024_003C_003E8__locals70.wLZ.gL0.GLP);
										array3[array[i]] = list2[0];
										flag2 = true;
									}
								}
							}
							else
							{
								Instruction key2 = (Instruction)list2.Last().Operand;
								if (!CS_0024_003C_003E8__locals70.wLZ.gL0.oL5.FmC(list2.Last().Offset) && dictionary.TryGetValue(key2, out var value2))
								{
									int num7 = k9R2?.oPI(value2) ?? value2;
									list2.RemoveAt(list2.Count - 1);
									if (!flag)
									{
										int num8 = array2[i];
										int num9 = dxt.NextInt32();
										list2.Add(Instruction.Create(OpCodes.Ldloc, CS_0024_003C_003E8__locals70.wLZ.gL0.dLN));
										list2.Add(Instruction.CreateLdcI4(num9));
										list2.Add(Instruction.Create(OpCodes.Sub));
										list2.Add(Instruction.Create(OpCodes.Ldc_I4, (num8 - num9) ^ num7));
										list2.Add(Instruction.Create(OpCodes.Xor));
									}
									else
									{
										list2.Add(Instruction.Create(OpCodes.Ldc_I4, num7));
									}
									dxG(list2, CS_0024_003C_003E8__locals70.xLi[1], CS_0024_003C_003E8__locals70.wLZ.gL0.GLP);
									cxj(list2, CS_0024_003C_003E8__locals70.wLZ.gL0.GLP);
									array3[array[i]] = list2[0];
									flag2 = true;
								}
							}
							if (!flag2)
							{
								int num10 = k9R2?.oPI(array2[i + 1]) ?? array2[i + 1];
								if (!func(list2))
								{
									int num11 = array2[i];
									int num12 = dxt.NextInt32();
									list2.Add(Instruction.Create(OpCodes.Ldloc, CS_0024_003C_003E8__locals70.wLZ.gL0.dLN));
									list2.Add(Instruction.CreateLdcI4(num12));
									list2.Add(Instruction.Create(OpCodes.Sub));
									list2.Add(Instruction.Create(OpCodes.Ldc_I4, (num11 - num12) ^ num10));
									list2.Add(Instruction.Create(OpCodes.Xor));
									CS_0024_003C_003E8__locals70.XLl(list2[0], array[i]);
									Shuffler.cflowShuffle(list2);
								}
								else
								{
									list2.Add(Instruction.Create(OpCodes.Ldc_I4, num10));
								}
								dxG(list2, CS_0024_003C_003E8__locals70.xLi[1], CS_0024_003C_003E8__locals70.wLZ.gL0.GLP);
								cxj(list2, CS_0024_003C_003E8__locals70.wLZ.gL0.GLP);
								array3[array[i]] = list2[0];
							}
						}
						else
						{
							array3[array[i]] = CS_0024_003C_003E8__locals70.xLi[0];
						}
						linkedListNode.Value = list2.ToArray();
						linkedListNode = linkedListNode.Next;
						i++;
					}
					array3[array[i]] = linkedListNode.Value[0];
					instruction2.Operand = array3;
					Instruction[] value3 = CS_0024_003C_003E8__locals70.KLI.First.Value;
					CS_0024_003C_003E8__locals70.KLI.RemoveFirst();
					Instruction[] value4 = CS_0024_003C_003E8__locals70.KLI.Last.Value;
					CS_0024_003C_003E8__locals70.KLI.RemoveLast();
					List<Instruction[]> list3 = CS_0024_003C_003E8__locals70.KLI.ToList();
					CS_0024_003C_003E8__locals70.wLZ.mLa.w7R().Clear();
					CS_0024_003C_003E8__locals70.wLZ.mLa.w7R().AddRange(value3);
					CS_0024_003C_003E8__locals70.wLZ.mLa.w7R().AddRange(CS_0024_003C_003E8__locals70.xLi);
					foreach (Instruction[] item2 in list3)
					{
						CS_0024_003C_003E8__locals70.wLZ.mLa.w7R().AddRange(item2);
					}
					CS_0024_003C_003E8__locals70.wLZ.mLa.w7R().AddRange(value4);
				}
			}
		}

		private LinkedList<Instruction[]> txo(bxd.y7w y7w_0, JmM jmM_0)
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
					jmM_0.Wmz(y7w_0.w7R()[i + 1].Offset);
				}
				else
					_ = 0;
				FlowControl flowControl = instruction.OpCode.FlowControl;
				FlowControl flowControl2 = flowControl;
				if ((flowControl2 == FlowControl.Branch || flowControl2 == FlowControl.Cond_Branch || (uint)(flowControl2 - 7) <= 1u) && jmM_0.XLx[instruction.Offset] != 0)
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
				if (instruction.OpCode.OpCodeType != OpCodeType.Prefix && jmM_0.XLx[instruction.Offset] == 0 && hashSet.Count == 0)
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

		public void Qxn<gxK>(IList<gxK> ilist_0)
		{
			for (int num = ilist_0.Count - 1; num > 1; num--)
			{
				int index = new Random().Next(num + 1);
				gxK value = ilist_0[index];
				ilist_0[index] = ilist_0[num];
				ilist_0[num] = value;
			}
		}

		public void dxG(IList<Instruction> ilist_0, Instruction instruction_0, MethodDef methodDef_0)
		{
			if (!methodDef_0.Module.IsClr40 && !methodDef_0.DeclaringType.HasGenericParameters && !methodDef_0.HasGenericParameters && (ilist_0[0].OpCode.FlowControl == FlowControl.Call || ilist_0[0].OpCode.FlowControl == FlowControl.Next))
			{
				switch (dxt.NextInt32(3))
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
					if (dxt.NextBoolean())
					{
						TypeDef typeDef = methodDef_0.Module.Types[dxt.NextInt32(methodDef_0.Module.Types.Count)];
						if (typeDef.HasMethods)
						{
							ilist_0.Add(Instruction.Create(OpCodes.Ldtoken, typeDef.Methods[dxt.NextInt32(typeDef.Methods.Count)]));
							ilist_0.Add(Instruction.Create(OpCodes.Box, methodDef_0.Module.CorLibTypes.GetTypeRef("System", "RuntimeMethodHandle")));
							flag = true;
						}
					}
					if (!flag)
					{
						ilist_0.Add(Instruction.Create(OpCodes.Ldc_I4, (!dxt.NextBoolean()) ? 1 : 0));
						ilist_0.Add(Instruction.Create(OpCodes.Box, methodDef_0.Module.CorLibTypes.Int32.TypeDefOrRef));
					}
					Instruction item = Instruction.Create(OpCodes.Pop);
					ilist_0.Add(Instruction.Create(OpCodes.Brfalse, ilist_0[0]));
					ilist_0.Add(Instruction.Create(OpCodes.Ldc_I4, (!dxt.NextBoolean()) ? 1 : 0));
					ilist_0.Add(item);
					break;
				}
				}
			}
			ilist_0.Add(Instruction.Create(OpCodes.Br, instruction_0));
		}

		public void cxj(IList<Instruction> ilist_0, MethodDef methodDef_0)
		{
			if (!methodDef_0.Module.IsClr40)
			{
				switch (dxt.NextInt32(6))
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

		static mxB()
		{
			Fxf = new Random();
		}
	}
}
