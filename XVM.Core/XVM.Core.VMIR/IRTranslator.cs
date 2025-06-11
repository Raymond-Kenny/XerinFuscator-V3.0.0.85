#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;
using XVM.Core.CFG;
using XVM.Core.RT;
using XVM.Core.VM;

namespace XVM.Core.VMIR
{
	public class IRTranslator
	{
		[CompilerGenerated]
		private sealed class tCj
		{
			public IRTranslator ECc;

			public Dictionary<BasicBlock<ILASTTree>, BasicBlock<IRInstrList>> fCL;

			internal IRInstrList TCO(BasicBlock<ILASTTree> basicBlock_0)
			{
				return ECc.KqV(basicBlock_0);
			}

			internal void HCt(BasicBlock<IRInstrList> basicBlock_0)
			{
				foreach (IRInstruction item in basicBlock_0.Content)
				{
					if (item.Operand1 is IRBlockTarget)
					{
						IRBlockTarget iRBlockTarget = (IRBlockTarget)item.Operand1;
						iRBlockTarget.Target = fCL[(BasicBlock<ILASTTree>)iRBlockTarget.Target];
					}
					else if (item.Operand1 is IRJumpTable)
					{
						IRJumpTable iRJumpTable = (IRJumpTable)item.Operand1;
						for (int i = 0; i < iRJumpTable.Targets.Length; i++)
						{
							iRJumpTable.Targets[i] = fCL[(BasicBlock<ILASTTree>)iRJumpTable.Targets[i]];
						}
					}
					if (item.Operand2 is IRBlockTarget)
					{
						IRBlockTarget iRBlockTarget2 = (IRBlockTarget)item.Operand2;
						iRBlockTarget2.Target = fCL[(BasicBlock<ILASTTree>)iRBlockTarget2.Target];
					}
					else if (item.Operand2 is IRJumpTable)
					{
						IRJumpTable iRJumpTable2 = (IRJumpTable)item.Operand2;
						for (int j = 0; j < iRJumpTable2.Targets.Length; j++)
						{
							iRJumpTable2.Targets[j] = fCL[(BasicBlock<ILASTTree>)iRJumpTable2.Targets[j]];
						}
					}
				}
			}
		}

		private static readonly Dictionary<Code, GInterface0> Mqx;

		[CompilerGenerated]
		private ScopeBlock vqs;

		[CompilerGenerated]
		private readonly IRContext rqQ;

		[CompilerGenerated]
		private readonly VMRuntime Oqi;

		[CompilerGenerated]
		private BasicBlock<ILASTTree> yqJ;

		[CompilerGenerated]
		private IRInstrList xq8;

		public ScopeBlock RootScope
		{
			[CompilerGenerated]
			get
			{
				return vqs;
			}
			[CompilerGenerated]
			private set
			{
				vqs = value;
			}
		}

		public IRContext Context
		{
			[CompilerGenerated]
			get
			{
				return rqQ;
			}
		}

		public VMRuntime Runtime
		{
			[CompilerGenerated]
			get
			{
				return Oqi;
			}
		}

		public VMDescriptor VM => Runtime.Descriptor;

		public ArchDescriptor Arch => VM.Architecture;

		static IRTranslator()
		{
			Mqx = new Dictionary<Code, GInterface0>();
			Type[] exportedTypes = typeof(IRTranslator).Assembly.GetExportedTypes();
			foreach (Type type in exportedTypes)
			{
				if (typeof(GInterface0).IsAssignableFrom(type) && !type.IsAbstract)
				{
					GInterface0 gInterface = (GInterface0)Activator.CreateInstance(type);
					Mqx.Add(gInterface.ILCode, gInterface);
				}
			}
		}

		public IRTranslator(IRContext ircontext_0, VMRuntime vmruntime_0)
		{
			rqQ = ircontext_0;
			Oqi = vmruntime_0;
		}

		[SpecialName]
		[CompilerGenerated]
		internal BasicBlock<ILASTTree> gqp()
		{
			return yqJ;
		}

		[SpecialName]
		[CompilerGenerated]
		private void Bqr(BasicBlock<ILASTTree> basicBlock_0)
		{
			yqJ = basicBlock_0;
		}

		[SpecialName]
		[CompilerGenerated]
		internal IRInstrList JqX()
		{
			return xq8;
		}

		[SpecialName]
		[CompilerGenerated]
		private void hqn(IRInstrList irinstrList_0)
		{
			xq8 = irinstrList_0;
		}

		internal IIROperand Qqg(IILASTNode iilastnode_0)
		{
			if (iilastnode_0 is ILASTExpression)
			{
				ILASTExpression iLASTExpression = (ILASTExpression)iilastnode_0;
				try
				{
					if (Mqx.TryGetValue(iLASTExpression.ILCode, out var value))
					{
						int i = JqX().Count;
						IIROperand result = value.Translate(iLASTExpression, this);
						for (; i < JqX().Count; i++)
						{
							JqX()[i].ILAST = iLASTExpression;
						}
						return result;
					}
					throw new NotSupportedException(iLASTExpression.ILCode.ToString());
				}
				catch (Exception innerException)
				{
					throw new Exception($"Failed to translate expr {iLASTExpression.CILInstr} @ {iLASTExpression.CILInstr.GetOffset():x4}.", innerException);
				}
			}
			if (!(iilastnode_0 is ILASTVariable))
			{
				throw new NotSupportedException();
			}
			return Context.ResolveVRegister((ILASTVariable)iilastnode_0);
		}

		private IRInstrList KqV(BasicBlock<ILASTTree> basicBlock_0)
		{
			Bqr(basicBlock_0);
			hqn(new IRInstrList());
			bool flag = false;
			foreach (IILASTStatement item in basicBlock_0.Content)
			{
				if (item is ILASTPhi)
				{
					ILASTVariable variable = ((ILASTPhi)item).Variable;
					JqX().Add(new IRInstruction(IROpCode.POP)
					{
						Operand1 = Context.ResolveVRegister(variable),
						ILAST = item
					});
					continue;
				}
				if (item is ILASTAssignment)
				{
					ILASTAssignment iLASTAssignment = (ILASTAssignment)item;
					IIROperand operand = Qqg(iLASTAssignment.Value);
					JqX().Add(new IRInstruction(IROpCode.MOV)
					{
						Operand1 = Context.ResolveVRegister(iLASTAssignment.Variable),
						Operand2 = operand,
						ILAST = item
					});
					continue;
				}
				if (item is ILASTExpression)
				{
					ILASTExpression iLASTExpression = (ILASTExpression)item;
					OpCode opCode = iLASTExpression.ILCode.ToOpCode();
					if (!flag && (opCode.FlowControl == FlowControl.Cond_Branch || opCode.FlowControl == FlowControl.Branch || opCode.FlowControl == FlowControl.Return || opCode.FlowControl == FlowControl.Throw))
					{
						ILASTVariable[] stackRemains = basicBlock_0.Content.StackRemains;
						foreach (ILASTVariable ilastvariable_ in stackRemains)
						{
							JqX().Add(new IRInstruction(IROpCode.PUSH)
							{
								Operand1 = Context.ResolveVRegister(ilastvariable_),
								ILAST = item
							});
						}
						flag = true;
					}
					Qqg((ILASTExpression)item);
					continue;
				}
				throw new NotSupportedException();
			}
			Debug.Assert(flag);
			IRInstrList result = JqX();
			hqn(null);
			return result;
		}

		public void Translate(ScopeBlock scopeBlock_0)
		{
			RootScope = scopeBlock_0;
			Dictionary<BasicBlock<ILASTTree>, BasicBlock<IRInstrList>> fCL = scopeBlock_0.UpdateBasicBlocks((BasicBlock<ILASTTree> basicBlock_0) => KqV(basicBlock_0));
			scopeBlock_0.ProcessBasicBlocks(delegate(BasicBlock<IRInstrList> basicBlock_0)
			{
				foreach (IRInstruction item in basicBlock_0.Content)
				{
					if (item.Operand1 is IRBlockTarget)
					{
						IRBlockTarget iRBlockTarget = (IRBlockTarget)item.Operand1;
						iRBlockTarget.Target = fCL[(BasicBlock<ILASTTree>)iRBlockTarget.Target];
					}
					else if (item.Operand1 is IRJumpTable)
					{
						IRJumpTable iRJumpTable = (IRJumpTable)item.Operand1;
						for (int i = 0; i < iRJumpTable.Targets.Length; i++)
						{
							iRJumpTable.Targets[i] = fCL[(BasicBlock<ILASTTree>)iRJumpTable.Targets[i]];
						}
					}
					if (item.Operand2 is IRBlockTarget)
					{
						IRBlockTarget iRBlockTarget2 = (IRBlockTarget)item.Operand2;
						iRBlockTarget2.Target = fCL[(BasicBlock<ILASTTree>)iRBlockTarget2.Target];
					}
					else if (item.Operand2 is IRJumpTable)
					{
						IRJumpTable iRJumpTable2 = (IRJumpTable)item.Operand2;
						for (int j = 0; j < iRJumpTable2.Targets.Length; j++)
						{
							iRJumpTable2.Targets[j] = fCL[(BasicBlock<ILASTTree>)iRJumpTable2.Targets[j]];
						}
					}
				}
			});
		}
	}
}
