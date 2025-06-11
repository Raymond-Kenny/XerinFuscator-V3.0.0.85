using System.Runtime.CompilerServices;
using XVM.Core.AST.IR;
using XVM.Core.CFG;

namespace XVM.Core.VMIR.Transforms
{
	public class GuardBlockTransform : ITransform
	{
		[CompilerGenerated]
		private sealed class nCm
		{
			public int HCl;

			public BasicBlock<IRInstrList> CCZ;

			internal void KC5(BasicBlock<IRInstrList> basicBlock_0)
			{
				basicBlock_0.Id++;
				if (basicBlock_0.Id > HCl)
				{
					HCl = basicBlock_0.Id;
				}
				if (CCZ == null)
				{
					CCZ = basicBlock_0;
				}
			}
		}

		private BasicBlock<IRInstrList> EMN;

		private BasicBlock<IRInstrList> JM2;

		public void Initialize(IRTransformer irtransformer_0)
		{
			int HCl = 0;
			BasicBlock<IRInstrList> CCZ = null;
			irtransformer_0.RootScope.ProcessBasicBlocks(delegate(BasicBlock<IRInstrList> basicBlock_0)
			{
				basicBlock_0.Id++;
				if (basicBlock_0.Id > HCl)
				{
					HCl = basicBlock_0.Id;
				}
				if (CCZ == null)
				{
					CCZ = basicBlock_0;
				}
			});
			JM2 = new BasicBlock<IRInstrList>(0, new IRInstrList
			{
				new IRInstruction(IROpCode.__ENTRY),
				new IRInstruction(IROpCode.JMP, new IRBlockTarget(CCZ))
			});
			JM2.Targets.Add(CCZ);
			CCZ.Sources.Add(JM2);
			EMN = new BasicBlock<IRInstrList>(HCl + 1, new IRInstrList
			{
				new IRInstruction(IROpCode.__EXIT)
			});
			XMw(irtransformer_0.RootScope);
			rMW(irtransformer_0.RootScope);
		}

		public void Transform(IRTransformer irtransformer_0)
		{
			irtransformer_0.SqF().VisitInstrs(MME, irtransformer_0);
		}

		private void XMw(ScopeBlock scopeBlock_0)
		{
			if (scopeBlock_0.Children.Count <= 0)
			{
				scopeBlock_0.Content.Insert(0, JM2);
				return;
			}
			if (scopeBlock_0.Children[0].Type == ScopeType.None)
			{
				XMw(scopeBlock_0.Children[0]);
				return;
			}
			ScopeBlock scopeBlock = new ScopeBlock();
			scopeBlock.Content.Add(JM2);
			scopeBlock_0.Children.Insert(0, scopeBlock);
		}

		private void rMW(ScopeBlock scopeBlock_0)
		{
			if (scopeBlock_0.Children.Count <= 0)
			{
				scopeBlock_0.Content.Insert(scopeBlock_0.Content.Count, EMN);
			}
			else if (scopeBlock_0.Children[scopeBlock_0.Children.Count - 1].Type != ScopeType.None)
			{
				ScopeBlock scopeBlock = new ScopeBlock();
				scopeBlock.Content.Add(EMN);
				scopeBlock_0.Children.Insert(scopeBlock_0.Children.Count, scopeBlock);
			}
			else
			{
				rMW(scopeBlock_0.Children[scopeBlock_0.Children.Count - 1]);
			}
		}

		private void MME(IRInstrList irinstrList_0, IRInstruction irinstruction_0, ref int int_0, IRTransformer irtransformer_0)
		{
			if (irinstruction_0.OpCode == IROpCode.RET)
			{
				irinstrList_0.Replace(int_0, new IRInstruction[1]
				{
					new IRInstruction(IROpCode.JMP, new IRBlockTarget(EMN))
				});
				if (!irtransformer_0.pqU().Targets.Contains(EMN))
				{
					irtransformer_0.pqU().Targets.Add(EMN);
					EMN.Sources.Add(irtransformer_0.pqU());
				}
			}
		}
	}
}
