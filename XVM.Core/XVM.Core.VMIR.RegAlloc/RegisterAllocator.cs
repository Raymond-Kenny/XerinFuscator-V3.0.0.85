#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using XVM.Core.AST.IR;
using XVM.Core.CFG;
using XVM.Core.VM;

namespace XVM.Core.VMIR.RegAlloc
{
	public class RegisterAllocator
	{
		private struct RCB
		{
			public readonly int zC7;

			public readonly IRVariable dCD;

			public RCB(int int_0, IRVariable irvariable_0)
			{
				zC7 = int_0;
				dCD = irvariable_0;
			}
		}

		private class pCy
		{
			private IRVariable[] Tm4;

			private Dictionary<IRVariable, RCB> fme;

			[CompilerGenerated]
			private int gmu;

			[SpecialName]
			[CompilerGenerated]
			public int kCs()
			{
				return gmu;
			}

			[SpecialName]
			[CompilerGenerated]
			public void LC8(int int_0)
			{
				gmu = int_0;
			}

			private static VMRegisters VCY(int int_0)
			{
				return (VMRegisters)int_0;
			}

			private static int hCV(VMRegisters vmregisters_0)
			{
				return (int)vmregisters_0;
			}

			public static pCy xCp(int int_0, Dictionary<IRVariable, RCB> dictionary_0)
			{
				pCy pCy = new pCy();
				pCy.Tm4 = new IRVariable[8];
				pCy.fme = new Dictionary<IRVariable, RCB>(dictionary_0);
				pCy.LC8(int_0);
				return pCy;
			}

			public VMRegisters? iCr(IRVariable irvariable_0)
			{
				int num = 0;
				while (true)
				{
					if (num < Tm4.Length)
					{
						if (Tm4[num] == null)
						{
							break;
						}
						num++;
						continue;
					}
					return null;
				}
				Tm4[num] = irvariable_0;
				return VCY(num);
			}

			public void KC3(IRVariable irvariable_0, VMRegisters vmregisters_0)
			{
				Debug.Assert(Tm4[hCV(vmregisters_0)] == irvariable_0);
				Tm4[hCV(vmregisters_0)] = null;
			}

			public void MCX(HashSet<IRVariable> hashSet_0)
			{
				for (int i = 0; i < Tm4.Length; i++)
				{
					if (Tm4[i] != null && !hashSet_0.Contains(Tm4[i]))
					{
						Tm4[i].Annotation = null;
						Tm4[i] = null;
					}
				}
			}

			public RCB KC6(IRVariable irvariable_0)
			{
				int num = kCs();
				LC8(num + 1);
				RCB rCB = new RCB(num, irvariable_0);
				fme[irvariable_0] = rCB;
				return rCB;
			}

			public RCB? KCx(IRVariable irvariable_0)
			{
				if (!fme.TryGetValue(irvariable_0, out var value))
				{
					return null;
				}
				return value;
			}
		}

		[Serializable]
		[CompilerGenerated]
		private sealed class gm9
		{
			public static readonly gm9 OmA;

			public static Func<IRVariable, IRVariable> um0;

			public static Func<KeyValuePair<IRVariable, RCB>, IRVariable> Qmw;

			public static Func<KeyValuePair<IRVariable, RCB>, object> tmW;

			static gm9()
			{
				OmA = new gm9();
			}

			internal IRVariable BmG(IRVariable irvariable_0)
			{
				return irvariable_0;
			}

			internal IRVariable Bmq(KeyValuePair<IRVariable, RCB> keyValuePair_0)
			{
				return keyValuePair_0.Key;
			}

			internal object EmM(KeyValuePair<IRVariable, RCB> keyValuePair_0)
			{
				return keyValuePair_0.Value;
			}
		}

		[CompilerGenerated]
		private sealed class OmE
		{
			public int Ym2;

			internal RCB amN(IRVariable irvariable_0)
			{
				return new RCB(Ym2++, irvariable_0);
			}
		}

		private Dictionary<IRVariable, object> uM7;

		private int tMD;

		private Dictionary<IRVariable, RCB> LMy;

		private Dictionary<BasicBlock<IRInstrList>, BlockLiveness> MMY;

		private readonly IRTransformer kMg;

		[CompilerGenerated]
		private int zMV;

		public int LocalSize
		{
			[CompilerGenerated]
			get
			{
				return zMV;
			}
			[CompilerGenerated]
			set
			{
				zMV = value;
			}
		}

		public RegisterAllocator(IRTransformer irtransformer_0)
		{
			kMg = irtransformer_0;
		}

		public void Initialize()
		{
			List<BasicBlock<IRInstrList>> ilist_ = kMg.RootScope.GetBasicBlocks().Cast<BasicBlock<IRInstrList>>().ToList();
			MMY = LivenessAnalysis.ComputeLiveness(ilist_);
			HashSet<IRVariable> hashSet = new HashSet<IRVariable>();
			foreach (KeyValuePair<BasicBlock<IRInstrList>, BlockLiveness> item in MMY)
			{
				foreach (IRInstruction item2 in item.Key.Content)
				{
					if (item2.OpCode == IROpCode.__LEA)
					{
						IRVariable iRVariable = (IRVariable)item2.Operand2;
						if (iRVariable.VariableType != IRVariableType.Argument)
						{
							hashSet.Add(iRVariable);
						}
					}
				}
				hashSet.UnionWith(item.Value.OutLive);
			}
			int Ym2 = 1;
			LMy = hashSet.ToDictionary((IRVariable irvariable_0) => irvariable_0, (IRVariable irvariable_0) => new RCB(Ym2++, irvariable_0));
			tMD = Ym2;
			LocalSize = tMD - 1;
			Ym2 = -2;
			IRVariable[] parameters = kMg.Context.GetParameters();
			for (int num = parameters.Length - 1; num >= 0; num--)
			{
				IRVariable iRVariable2 = parameters[num];
				LMy[iRVariable2] = new RCB(Ym2--, iRVariable2);
			}
			uM7 = ((IEnumerable<KeyValuePair<IRVariable, RCB>>)LMy).ToDictionary((Func<KeyValuePair<IRVariable, RCB>, IRVariable>)((KeyValuePair<IRVariable, RCB> keyValuePair_0) => keyValuePair_0.Key), (Func<KeyValuePair<IRVariable, RCB>, object>)((KeyValuePair<IRVariable, RCB> keyValuePair_0) => keyValuePair_0.Value));
		}

		public void Allocate(BasicBlock<IRInstrList> basicBlock_0)
		{
			BlockLiveness blockLiveness_ = MMY[basicBlock_0];
			Dictionary<IRInstruction, HashSet<IRVariable>> dictionary = LivenessAnalysis.ComputeLiveness(basicBlock_0, blockLiveness_);
			pCy pCy = pCy.xCp(tMD, LMy);
			for (int i = 0; i < basicBlock_0.Content.Count; i++)
			{
				IRInstruction iRInstruction = basicBlock_0.Content[i];
				pCy.MCX(dictionary[iRInstruction]);
				if (iRInstruction.Operand1 != null)
				{
					iRInstruction.Operand1 = mMd(iRInstruction.Operand1, pCy);
				}
				if (iRInstruction.Operand2 != null)
				{
					iRInstruction.Operand2 = mMd(iRInstruction.Operand2, pCy);
				}
			}
			if (pCy.kCs() - 1 > LocalSize)
			{
				LocalSize = pCy.kCs() - 1;
			}
			tMD = pCy.kCs();
		}

		private IIROperand mMd(IIROperand iiroperand_0, pCy pCy_0)
		{
			if (!(iiroperand_0 is IRVariable))
			{
				return iiroperand_0;
			}
			IRVariable iRVariable = (IRVariable)iiroperand_0;
			RCB? nullable_;
			VMRegisters? vMRegisters = GMB(pCy_0, iRVariable, out nullable_);
			if (vMRegisters.HasValue)
			{
				return new IRRegister(vMRegisters.Value)
				{
					SourceVariable = iRVariable,
					Type = iRVariable.Type
				};
			}
			iRVariable.Annotation = nullable_.Value;
			return new IRPointer
			{
				Register = IRRegister.BP,
				Offset = nullable_.Value.zC7,
				SourceVariable = iRVariable,
				Type = iRVariable.Type
			};
		}

		private VMRegisters? GMB(pCy pCy_0, IRVariable irvariable_0, out RCB? nullable_0)
		{
			nullable_0 = pCy_0.KCx(irvariable_0);
			if (!nullable_0.HasValue)
			{
				VMRegisters? result = ((irvariable_0.Annotation == null) ? ((VMRegisters?)null) : new VMRegisters?((VMRegisters)irvariable_0.Annotation));
				if (!result.HasValue)
				{
					result = pCy_0.iCr(irvariable_0);
				}
				if (result.HasValue)
				{
					if (irvariable_0.Annotation == null)
					{
						irvariable_0.Annotation = result.Value;
					}
					return result;
				}
				nullable_0 = pCy_0.KC6(irvariable_0);
			}
			return null;
		}
	}
}
