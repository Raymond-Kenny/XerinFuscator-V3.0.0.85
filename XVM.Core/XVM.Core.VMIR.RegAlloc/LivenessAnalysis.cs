#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using XVM.Core.AST.IR;
using XVM.Core.CFG;

namespace XVM.Core.VMIR.RegAlloc
{
	public class LivenessAnalysis
	{
		private enum ACT
		{

		}

		[Serializable]
		[CompilerGenerated]
		private sealed class iCS
		{
			public static readonly iCS qCU;

			public static Func<BasicBlock<IRInstrList>, bool> XCh;

			static iCS()
			{
				qCU = new iCS();
			}

			internal bool BCa(BasicBlock<IRInstrList> basicBlock_0)
			{
				return basicBlock_0.Sources.Count == 0;
			}
		}

		[CompilerGenerated]
		private sealed class zCP
		{
			public List<BasicBlock<IRInstrList>> SCv;

			public Action<BasicBlock<IRInstrList>> XCd;

			internal void jCF(BasicBlock<IRInstrList> basicBlock_0)
			{
				SCv.Add(basicBlock_0);
			}
		}

		private static readonly Dictionary<IROpCode, ACT> KMv;

		public static Dictionary<BasicBlock<IRInstrList>, BlockLiveness> ComputeLiveness(IList<BasicBlock<IRInstrList>> ilist_0)
		{
			Dictionary<BasicBlock<IRInstrList>, BlockLiveness> dictionary = new Dictionary<BasicBlock<IRInstrList>, BlockLiveness>();
			List<BasicBlock<IRInstrList>> list = ilist_0.Where((BasicBlock<IRInstrList> basicBlock_0) => basicBlock_0.Sources.Count == 0).ToList();
			List<BasicBlock<IRInstrList>> SCv = new List<BasicBlock<IRInstrList>>();
			HashSet<BasicBlock<IRInstrList>> hashSet_ = new HashSet<BasicBlock<IRInstrList>>();
			foreach (BasicBlock<IRInstrList> item in list)
			{
				rMh(item, hashSet_, delegate(BasicBlock<IRInstrList> basicBlock_0)
				{
					SCv.Add(basicBlock_0);
				});
			}
			bool flag = false;
			do
			{
				foreach (BasicBlock<IRInstrList> item2 in SCv)
				{
					BlockLiveness blockLiveness = BlockLiveness.WMT();
					foreach (BasicBlock<IRInstrList> target in item2.Targets)
					{
						if (dictionary.TryGetValue(target, out var value))
						{
							blockLiveness.OutLive.UnionWith(value.InLive);
						}
					}
					HashSet<IRVariable> hashSet = new HashSet<IRVariable>(blockLiveness.OutLive);
					for (int num = item2.Content.Count - 1; num >= 0; num--)
					{
						IRInstruction irinstruction_ = item2.Content[num];
						HMF(irinstruction_, hashSet);
					}
					blockLiveness.InLive.UnionWith(hashSet);
					if (!flag && dictionary.TryGetValue(item2, out var value2))
					{
						flag = !value2.InLive.SetEquals(blockLiveness.InLive) || !value2.OutLive.SetEquals(blockLiveness.OutLive);
					}
					dictionary[item2] = blockLiveness;
				}
			}
			while (flag);
			return dictionary;
		}

		public static Dictionary<IRInstruction, HashSet<IRVariable>> ComputeLiveness(BasicBlock<IRInstrList> basicBlock_0, BlockLiveness blockLiveness_0)
		{
			Dictionary<IRInstruction, HashSet<IRVariable>> dictionary = new Dictionary<IRInstruction, HashSet<IRVariable>>();
			HashSet<IRVariable> hashSet = new HashSet<IRVariable>(blockLiveness_0.OutLive);
			for (int num = basicBlock_0.Content.Count - 1; num >= 0; num--)
			{
				IRInstruction iRInstruction = basicBlock_0.Content[num];
				HMF(iRInstruction, hashSet);
				dictionary[iRInstruction] = new HashSet<IRVariable>(hashSet);
			}
			Debug.Assert(hashSet.SetEquals(blockLiveness_0.InLive));
			return dictionary;
		}

		private static void rMh(BasicBlock<IRInstrList> basicBlock_0, HashSet<BasicBlock<IRInstrList>> hashSet_0, Action<BasicBlock<IRInstrList>> action_0)
		{
			hashSet_0.Add(basicBlock_0);
			foreach (BasicBlock<IRInstrList> target in basicBlock_0.Targets)
			{
				if (!hashSet_0.Contains(target))
				{
					rMh(target, hashSet_0, action_0);
				}
			}
			action_0(basicBlock_0);
		}

		private static void HMF(IRInstruction irinstruction_0, HashSet<IRVariable> hashSet_0)
		{
			if (!KMv.TryGetValue(irinstruction_0.OpCode, out var value))
			{
				value = (ACT)0;
			}
			IRVariable iRVariable = irinstruction_0.Operand1 as IRVariable;
			IRVariable iRVariable2 = irinstruction_0.Operand2 as IRVariable;
			if ((value & (ACT)4) != 0 && iRVariable != null)
			{
				hashSet_0.Remove(iRVariable);
			}
			if ((value & (ACT)8) != 0 && iRVariable2 != null)
			{
				hashSet_0.Remove(iRVariable2);
			}
			if ((value & (ACT)1) != 0 && iRVariable != null)
			{
				hashSet_0.Add(iRVariable);
			}
			if ((value & (ACT)2) != 0 && iRVariable2 != null)
			{
				hashSet_0.Add(iRVariable2);
			}
		}

		static LivenessAnalysis()
		{
			KMv = new Dictionary<IROpCode, ACT>
			{
				{
					IROpCode.MOV,
					(ACT)6
				},
				{
					IROpCode.POP,
					(ACT)4
				},
				{
					IROpCode.PUSH,
					(ACT)1
				},
				{
					IROpCode.CALL,
					(ACT)9
				},
				{
					IROpCode.NOR,
					(ACT)7
				},
				{
					IROpCode.CMP,
					(ACT)3
				},
				{
					IROpCode.JZ,
					(ACT)2
				},
				{
					IROpCode.JNZ,
					(ACT)2
				},
				{
					IROpCode.SWT,
					(ACT)2
				},
				{
					IROpCode.ADD,
					(ACT)7
				},
				{
					IROpCode.SUB,
					(ACT)7
				},
				{
					IROpCode.MUL,
					(ACT)7
				},
				{
					IROpCode.DIV,
					(ACT)7
				},
				{
					IROpCode.REM,
					(ACT)7
				},
				{
					IROpCode.SHR,
					(ACT)7
				},
				{
					IROpCode.SHL,
					(ACT)7
				},
				{
					IROpCode.FCONV,
					(ACT)6
				},
				{
					IROpCode.ICONV,
					(ACT)6
				},
				{
					IROpCode.SX,
					(ACT)6
				},
				{
					IROpCode.VCALL,
					(ACT)1
				},
				{
					IROpCode.TRY,
					(ACT)3
				},
				{
					IROpCode.LEAVE,
					(ACT)1
				},
				{
					IROpCode.__EHRET,
					(ACT)1
				},
				{
					IROpCode.__LEA,
					(ACT)6
				},
				{
					IROpCode.__LDOBJ,
					(ACT)9
				},
				{
					IROpCode.__STOBJ,
					(ACT)3
				},
				{
					IROpCode.__GEN,
					(ACT)1
				},
				{
					IROpCode.__KILL,
					(ACT)4
				}
			};
		}
	}
}
