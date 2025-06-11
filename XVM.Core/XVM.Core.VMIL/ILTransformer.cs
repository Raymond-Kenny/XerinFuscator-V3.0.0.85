using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using XVM.Core.AST.IL;
using XVM.Core.CFG;
using XVM.Core.RT;
using XVM.Core.VM;
using XVM.Core.VMIL.Transforms;

namespace XVM.Core.VMIL
{
	public class ILTransformer
	{
		[CompilerGenerated]
		private sealed class tmc
		{
			public ITransform xmk;

			public ILTransformer smC;

			internal void vmL(BasicBlock<ILInstrList> basicBlock_0)
			{
				smC.WA9((ILBlock)basicBlock_0);
				xmk.Transform(smC);
			}
		}

		private ITransform[] dAM;

		[CompilerGenerated]
		private readonly VMRuntime EAA;

		[CompilerGenerated]
		private readonly MethodDef jAR;

		[CompilerGenerated]
		private readonly ScopeBlock vA0;

		[CompilerGenerated]
		private readonly Dictionary<object, object> pAw;

		[CompilerGenerated]
		private ILBlock bAW;

		public VMRuntime Runtime
		{
			[CompilerGenerated]
			get
			{
				return EAA;
			}
		}

		public MethodDef Method
		{
			[CompilerGenerated]
			get
			{
				return jAR;
			}
		}

		public ScopeBlock RootScope
		{
			[CompilerGenerated]
			get
			{
				return vA0;
			}
		}

		public VMDescriptor VM => Runtime.Descriptor;

		public ILTransformer(MethodDef methodDef_0, ScopeBlock scopeBlock_0, VMRuntime vmruntime_0)
		{
			vA0 = scopeBlock_0;
			jAR = methodDef_0;
			EAA = vmruntime_0;
			pAw = new Dictionary<object, object>();
			dAM = dMz();
		}

		[SpecialName]
		[CompilerGenerated]
		internal Dictionary<object, object> KA4()
		{
			return pAw;
		}

		[SpecialName]
		[CompilerGenerated]
		internal ILBlock uAu()
		{
			return bAW;
		}

		[SpecialName]
		[CompilerGenerated]
		private void WA9(ILBlock ilblock_0)
		{
			bAW = ilblock_0;
		}

		[SpecialName]
		internal ILInstrList VAI()
		{
			return uAu().Content;
		}

		private ITransform[] dMz()
		{
			return new ITransform[3]
			{
				new ReferenceOffsetTransform(),
				new EntryExitTransform(),
				new SaveInfoTransform()
			};
		}

		public void Transform()
		{
			if (dAM != null)
			{
				ITransform[] array = dAM;
				foreach (ITransform xmk in array)
				{
					xmk.Initialize(this);
					RootScope.ProcessBasicBlocks(delegate(BasicBlock<ILInstrList> basicBlock_0)
					{
						WA9((ILBlock)basicBlock_0);
						xmk.Transform(this);
					});
				}
				dAM = null;
				return;
			}
			throw new InvalidOperationException("Transformer already used.");
		}
	}
}
