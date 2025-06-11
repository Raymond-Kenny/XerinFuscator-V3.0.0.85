#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.IR;
using XVM.Core.CFG;

namespace XVM.Core.VMIR.Transforms
{
	public class EHTransform : ITransform
	{
		[CompilerGenerated]
		private sealed class vCk
		{
			public ScopeBlock zCC;

			internal bool hCH(ScopeBlock scopeBlock_0)
			{
				return scopeBlock_0 != zCC;
			}
		}

		private ScopeBlock[] bMR;

		public void Initialize(IRTransformer irtransformer_0)
		{
		}

		public void Transform(IRTransformer irtransformer_0)
		{
			bMR = irtransformer_0.RootScope.SearchBlock(irtransformer_0.pqU());
			NMI(irtransformer_0);
			if (bMR[bMR.Length - 1].Type == ScopeType.Handler)
			{
				ScopeBlock zCC = iMq(irtransformer_0.RootScope, bMR[bMR.Length - 1].ExceptionHandler);
				ScopeBlock[] source = irtransformer_0.RootScope.SearchBlock(zCC.GetBasicBlocks().First());
				bMR = source.TakeWhile((ScopeBlock scopeBlock_0) => scopeBlock_0 != zCC).ToArray();
			}
			irtransformer_0.SqF().VisitInstrs(xMA, irtransformer_0);
		}

		private void EMG(ScopeBlock scopeBlock_0, ExceptionHandler exceptionHandler_0, ref IBasicBlock ibasicBlock_0, ref IBasicBlock ibasicBlock_1)
		{
			if (scopeBlock_0.ExceptionHandler == exceptionHandler_0)
			{
				if (scopeBlock_0.Type == ScopeType.Handler)
				{
					ibasicBlock_0 = scopeBlock_0.GetBasicBlocks().First();
				}
				else if (scopeBlock_0.Type == ScopeType.Filter)
				{
					ibasicBlock_1 = scopeBlock_0.GetBasicBlocks().First();
				}
			}
			foreach (ScopeBlock child in scopeBlock_0.Children)
			{
				EMG(child, exceptionHandler_0, ref ibasicBlock_0, ref ibasicBlock_1);
			}
		}

		private void NMI(IRTransformer irtransformer_0)
		{
			List<IRInstruction> list = new List<IRInstruction>();
			for (int i = 0; i < bMR.Length; i++)
			{
				ScopeBlock scopeBlock = bMR[i];
				if (scopeBlock.Type != ScopeType.Try || scopeBlock.GetBasicBlocks().First() != irtransformer_0.pqU())
				{
					continue;
				}
				IBasicBlock ibasicBlock_ = null;
				IBasicBlock ibasicBlock_2 = null;
				EMG(irtransformer_0.RootScope, scopeBlock.ExceptionHandler, ref ibasicBlock_, ref ibasicBlock_2);
				Debug.Assert(ibasicBlock_ != null && (scopeBlock.ExceptionHandler.HandlerType != ExceptionHandlerType.Filter || ibasicBlock_2 != null));
				list.Add(new IRInstruction(IROpCode.PUSH, new IRBlockTarget(ibasicBlock_)));
				IIROperand iiroperand_ = null;
				int int_;
				if (scopeBlock.ExceptionHandler.HandlerType != ExceptionHandlerType.Catch)
				{
					if (scopeBlock.ExceptionHandler.HandlerType == ExceptionHandlerType.Filter)
					{
						iiroperand_ = new IRBlockTarget(ibasicBlock_2);
						int_ = irtransformer_0.VM.Runtime.RTFlags.EH_FILTER;
					}
					else if (scopeBlock.ExceptionHandler.HandlerType != ExceptionHandlerType.Fault)
					{
						if (scopeBlock.ExceptionHandler.HandlerType != ExceptionHandlerType.Finally)
						{
							throw new InvalidProgramException();
						}
						int_ = irtransformer_0.VM.Runtime.RTFlags.EH_FINALLY;
					}
					else
					{
						int_ = irtransformer_0.VM.Runtime.RTFlags.EH_FAULT;
					}
				}
				else
				{
					iiroperand_ = IRConstant.FromI4((int)irtransformer_0.VM.Data.GetId(scopeBlock.ExceptionHandler.CatchType));
					int_ = irtransformer_0.VM.Runtime.RTFlags.EH_CATCH;
				}
				list.Add(new IRInstruction(IROpCode.TRY, IRConstant.FromI4(int_), iiroperand_)
				{
					Annotation = new EHInfo(scopeBlock.ExceptionHandler)
				});
			}
			irtransformer_0.SqF().InsertRange(0, list);
		}

		private ScopeBlock iMq(ScopeBlock scopeBlock_0, ExceptionHandler exceptionHandler_0)
		{
			if (scopeBlock_0.ExceptionHandler != exceptionHandler_0 || scopeBlock_0.Type != ScopeType.Try)
			{
				foreach (ScopeBlock child in scopeBlock_0.Children)
				{
					ScopeBlock scopeBlock = iMq(child, exceptionHandler_0);
					if (scopeBlock != null)
					{
						return scopeBlock;
					}
				}
				return null;
			}
			return scopeBlock_0;
		}

		private static ScopeBlock TMM(object object_0, object object_1)
		{
			ScopeBlock result = null;
			for (int i = 0; i < ((Array)object_0).Length && i < ((Array)object_1).Length && ((object[])object_0)[i] == ((object[])object_1)[i]; i++)
			{
				result = (ScopeBlock)((object[])object_0)[i];
			}
			return result;
		}

		private void xMA(IRInstrList irinstrList_0, IRInstruction irinstruction_0, ref int int_0, IRTransformer irtransformer_0)
		{
			if (irinstruction_0.OpCode != IROpCode.__LEAVE)
			{
				return;
			}
			ScopeBlock[] object_ = irtransformer_0.RootScope.SearchBlock(((IRBlockTarget)irinstruction_0.Operand1).Target);
			ScopeBlock scopeBlock = TMM(bMR, object_);
			List<IRInstruction> list = new List<IRInstruction>();
			int num = bMR.Length - 1;
			while (num >= 0 && bMR[num] != scopeBlock)
			{
				if (bMR[num].Type == ScopeType.Try)
				{
					IBasicBlock ibasicBlock_ = null;
					IBasicBlock ibasicBlock_2 = null;
					EMG(irtransformer_0.RootScope, bMR[num].ExceptionHandler, ref ibasicBlock_, ref ibasicBlock_2);
					if (ibasicBlock_ == null)
					{
						throw new InvalidProgramException();
					}
					list.Add(new IRInstruction(IROpCode.LEAVE, new IRBlockTarget(ibasicBlock_))
					{
						Annotation = new EHInfo(bMR[num].ExceptionHandler)
					});
				}
				num--;
			}
			irinstruction_0.OpCode = IROpCode.JMP;
			list.Add(irinstruction_0);
			irinstrList_0.Replace(int_0, list);
		}
	}
}
