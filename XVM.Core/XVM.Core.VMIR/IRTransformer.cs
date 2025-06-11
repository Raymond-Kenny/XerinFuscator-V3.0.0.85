using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using XVM.Core.AST.IR;
using XVM.Core.CFG;
using XVM.Core.RT;
using XVM.Core.VM;
using XVM.Core.VMIR.Transforms;

namespace XVM.Core.VMIR
{
	public class IRTransformer
	{
		[CompilerGenerated]
		private sealed class SCN
		{
			public ITransform aCK;

			public IRTransformer XC1;

			internal void PC2(BasicBlock<IRInstrList> basicBlock_0)
			{
				XC1.dqh(basicBlock_0);
				aCK.Transform(XC1);
			}
		}

		private ITransform[] Gqd;

		[CompilerGenerated]
		private readonly IRContext qqB;

		[CompilerGenerated]
		private readonly VMRuntime fq7;

		[CompilerGenerated]
		private readonly ScopeBlock PqD;

		[CompilerGenerated]
		private readonly Dictionary<object, object> Vqy;

		[CompilerGenerated]
		private BasicBlock<IRInstrList> oqY;

		public IRContext Context
		{
			[CompilerGenerated]
			get
			{
				return qqB;
			}
		}

		public VMRuntime Runtime
		{
			[CompilerGenerated]
			get
			{
				return fq7;
			}
		}

		public VMDescriptor VM => Runtime.Descriptor;

		public ScopeBlock RootScope
		{
			[CompilerGenerated]
			get
			{
				return PqD;
			}
		}

		public IRTransformer(ScopeBlock scopeBlock_0, IRContext ircontext_0, VMRuntime vmruntime_0)
		{
			PqD = scopeBlock_0;
			qqB = ircontext_0;
			fq7 = vmruntime_0;
			Vqy = new Dictionary<object, object>();
			vqT();
		}

		[SpecialName]
		[CompilerGenerated]
		internal Dictionary<object, object> yqS()
		{
			return Vqy;
		}

		[SpecialName]
		[CompilerGenerated]
		internal BasicBlock<IRInstrList> pqU()
		{
			return oqY;
		}

		[SpecialName]
		[CompilerGenerated]
		private void dqh(BasicBlock<IRInstrList> basicBlock_0)
		{
			oqY = basicBlock_0;
		}

		[SpecialName]
		internal IRInstrList SqF()
		{
			return pqU().Content;
		}

		private void vqT()
		{
			Gqd = new ITransform[12]
			{
				(!Context.IsRuntime) ? new GuardBlockTransform() : null,
				Context.IsRuntime ? null : new EHTransform(),
				new InitLocalTransform(),
				new ConstantTypePromotionTransform(),
				new GetSetFlagTransform(),
				new LogicTransform(),
				new InvokeTransform(),
				new MetadataTransform(),
				Context.IsRuntime ? null : new RegisterAllocationTransform(),
				Context.IsRuntime ? null : new StackFrameTransform(),
				new LeaTransform(),
				Context.IsRuntime ? null : new MarkReturnRegTransform()
			};
		}

		public void Transform()
		{
			if (Gqd == null)
			{
				throw new InvalidOperationException("Transformer already used.");
			}
			ITransform[] gqd = Gqd;
			foreach (ITransform aCK in gqd)
			{
				if (aCK != null)
				{
					aCK.Initialize(this);
					RootScope.ProcessBasicBlocks(delegate(BasicBlock<IRInstrList> basicBlock_0)
					{
						dqh(basicBlock_0);
						aCK.Transform(this);
					});
				}
			}
			Gqd = null;
		}
	}
}
