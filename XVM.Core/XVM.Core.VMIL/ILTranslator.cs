using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using XVM.Core.AST.IL;
using XVM.Core.AST.IR;
using XVM.Core.CFG;
using XVM.Core.RT;
using XVM.Core.VM;
using XVM.Core.VMIR;

namespace XVM.Core.VMIL
{
	public class ILTranslator
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class Gmm
		{
			public static readonly Gmm lmo;

			public static Func<int, ILInstrList, BasicBlock<ILInstrList>> Wml;

			static Gmm()
			{
				lmo = new Gmm();
			}

			internal BasicBlock<ILInstrList> bm5(int int_0, ILInstrList ilinstrList_0)
			{
				return new ILBlock(int_0, ilinstrList_0);
			}
		}

		[CompilerGenerated]
		private sealed class omZ
		{
			public ILTranslator fma;

			public Dictionary<BasicBlock<IRInstrList>, BasicBlock<ILInstrList>> amU;

			internal ILInstrList jmT(BasicBlock<IRInstrList> basicBlock_0)
			{
				return fma.Translate(basicBlock_0.Content);
			}

			internal void OmS(BasicBlock<ILInstrList> basicBlock_0)
			{
				foreach (ILInstruction item in basicBlock_0.Content)
				{
					if (item.Operand is ILBlockTarget)
					{
						ILBlockTarget iLBlockTarget = (ILBlockTarget)item.Operand;
						iLBlockTarget.Target = amU[(BasicBlock<IRInstrList>)iLBlockTarget.Target];
					}
					else if (item.Operand is ILJumpTable)
					{
						ILJumpTable iLJumpTable = (ILJumpTable)item.Operand;
						for (int i = 0; i < iLJumpTable.Targets.Length; i++)
						{
							iLJumpTable.Targets[i] = amU[(BasicBlock<IRInstrList>)iLJumpTable.Targets[i]];
						}
					}
				}
			}
		}

		private static readonly Dictionary<IROpCode, GInterface1> KAK;

		[CompilerGenerated]
		private readonly VMRuntime AA1;

		[CompilerGenerated]
		private ILInstrList GAj;

		public VMRuntime Runtime
		{
			[CompilerGenerated]
			get
			{
				return AA1;
			}
		}

		public VMDescriptor VM => Runtime.Descriptor;

		static ILTranslator()
		{
			KAK = new Dictionary<IROpCode, GInterface1>();
			Type[] exportedTypes = typeof(ILTranslator).Assembly.GetExportedTypes();
			foreach (Type type in exportedTypes)
			{
				if (typeof(GInterface1).IsAssignableFrom(type) && !type.IsAbstract)
				{
					GInterface1 gInterface = (GInterface1)Activator.CreateInstance(type);
					KAK.Add(gInterface.IRCode, gInterface);
				}
			}
		}

		public ILTranslator(VMRuntime vmruntime_0)
		{
			AA1 = vmruntime_0;
		}

		[SpecialName]
		[CompilerGenerated]
		internal ILInstrList wAE()
		{
			return GAj;
		}

		[SpecialName]
		[CompilerGenerated]
		private void pAN(ILInstrList ilinstrList_0)
		{
			GAj = ilinstrList_0;
		}

		public ILInstrList Translate(IRInstrList irinstrList_0)
		{
			pAN(new ILInstrList());
			int i = 0;
			foreach (IRInstruction item in irinstrList_0)
			{
				if (KAK.TryGetValue(item.OpCode, out var value))
				{
					try
					{
						value.Translate(item, this);
					}
					catch (Exception innerException)
					{
						throw new Exception($"Failed to translate ir {item.ILAST}.", innerException);
					}
					for (; i < wAE().Count; i++)
					{
						wAE()[i].IR = item;
					}
					continue;
				}
				throw new NotSupportedException(item.OpCode.ToString());
			}
			ILInstrList result = wAE();
			pAN(null);
			return result;
		}

		public void Translate(ScopeBlock scopeBlock_0)
		{
			Dictionary<BasicBlock<IRInstrList>, BasicBlock<ILInstrList>> amU = scopeBlock_0.UpdateBasicBlocks((BasicBlock<IRInstrList> basicBlock_0) => Translate(basicBlock_0.Content), (int int_0, ILInstrList ilinstrList_0) => new ILBlock(int_0, ilinstrList_0));
			scopeBlock_0.ProcessBasicBlocks(delegate(BasicBlock<ILInstrList> basicBlock_0)
			{
				foreach (ILInstruction item in basicBlock_0.Content)
				{
					if (item.Operand is ILBlockTarget)
					{
						ILBlockTarget iLBlockTarget = (ILBlockTarget)item.Operand;
						iLBlockTarget.Target = amU[(BasicBlock<IRInstrList>)iLBlockTarget.Target];
					}
					else if (item.Operand is ILJumpTable)
					{
						ILJumpTable iLJumpTable = (ILJumpTable)item.Operand;
						for (int i = 0; i < iLJumpTable.Targets.Length; i++)
						{
							iLJumpTable.Targets[i] = amU[(BasicBlock<IRInstrList>)iLJumpTable.Targets[i]];
						}
					}
				}
			});
		}
	}
}
