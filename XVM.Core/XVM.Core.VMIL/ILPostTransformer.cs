using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using XVM.Core.AST.IL;
using XVM.Core.CFG;
using XVM.Core.RT;
using XVM.Core.VMIL.Transforms;

namespace XVM.Core.VMIL
{
	public class ILPostTransformer
	{
		[CompilerGenerated]
		private sealed class ymK
		{
			public IPostTransform Pmj;

			public ILPostTransformer umt;

			internal void zm1(BasicBlock<ILInstrList> basicBlock_0)
			{
				umt.QMX((ILBlock)basicBlock_0);
				Pmj.Transform(umt);
			}
		}

		private IPostTransform[] BMs;

		[CompilerGenerated]
		private readonly VMRuntime vMQ;

		[CompilerGenerated]
		private readonly MethodDef dMf;

		[CompilerGenerated]
		private readonly ScopeBlock IMi;

		[CompilerGenerated]
		private readonly Dictionary<object, object> WMJ;

		[CompilerGenerated]
		private ILBlock FM8;

		public VMRuntime Runtime
		{
			[CompilerGenerated]
			get
			{
				return vMQ;
			}
		}

		public MethodDef Method
		{
			[CompilerGenerated]
			get
			{
				return dMf;
			}
		}

		public ScopeBlock RootScope
		{
			[CompilerGenerated]
			get
			{
				return IMi;
			}
		}

		public ILPostTransformer(MethodDef methodDef_0, ScopeBlock scopeBlock_0, VMRuntime vmruntime_0)
		{
			IMi = scopeBlock_0;
			dMf = methodDef_0;
			vMQ = vmruntime_0;
			WMJ = new Dictionary<object, object>();
			BMs = BMb();
		}

		[SpecialName]
		[CompilerGenerated]
		internal Dictionary<object, object> fMp()
		{
			return WMJ;
		}

		[SpecialName]
		[CompilerGenerated]
		internal ILBlock lM3()
		{
			return FM8;
		}

		[SpecialName]
		[CompilerGenerated]
		private void QMX(ILBlock ilblock_0)
		{
			FM8 = ilblock_0;
		}

		[SpecialName]
		internal ILInstrList fM6()
		{
			return lM3().Content;
		}

		private IPostTransform[] BMb()
		{
			return new IPostTransform[3]
			{
				new SaveRegistersTransform(),
				new FixMethodRefTransform(),
				new BlockKeyTransform()
			};
		}

		public void Transform()
		{
			if (BMs == null)
			{
				throw new InvalidOperationException("Transformer already used.");
			}
			IPostTransform[] bMs = BMs;
			foreach (IPostTransform Pmj in bMs)
			{
				Pmj.Initialize(this);
				RootScope.ProcessBasicBlocks(delegate(BasicBlock<ILInstrList> basicBlock_0)
				{
					QMX((ILBlock)basicBlock_0);
					Pmj.Transform(this);
				});
			}
			BMs = null;
		}
	}
}
