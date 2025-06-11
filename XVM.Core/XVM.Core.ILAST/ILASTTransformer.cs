using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using XVM.Core.AST.ILAST;
using XVM.Core.CFG;
using XVM.Core.ILAST.Transformation;
using XVM.Core.RT;
using XVM.Core.VM;

namespace XVM.Core.ILAST
{
	public class ILASTTransformer
	{
		[CompilerGenerated]
		private sealed class xlz
		{
			public ITransformationHandler cZe;

			public ILASTTransformer vZu;

			internal void tZ4(BasicBlock<ILASTTree> basicBlock_0)
			{
				vZu.LjT(basicBlock_0);
				cZe.Transform(vZu);
			}
		}

		private ITransformationHandler[] Ejh;

		[CompilerGenerated]
		private MethodDef wjP;

		[CompilerGenerated]
		private ScopeBlock JjF;

		[CompilerGenerated]
		private VMRuntime Qjv;

		[CompilerGenerated]
		private Dictionary<object, object> ajd;

		[CompilerGenerated]
		private BasicBlock<ILASTTree> UjB;

		public MethodDef Method
		{
			[CompilerGenerated]
			get
			{
				return wjP;
			}
			[CompilerGenerated]
			private set
			{
				wjP = value;
			}
		}

		public ScopeBlock RootScope
		{
			[CompilerGenerated]
			get
			{
				return JjF;
			}
			[CompilerGenerated]
			private set
			{
				JjF = value;
			}
		}

		public VMRuntime Runtime
		{
			[CompilerGenerated]
			get
			{
				return Qjv;
			}
			[CompilerGenerated]
			private set
			{
				Qjv = value;
			}
		}

		public VMDescriptor VM => Runtime.Descriptor;

		public ILASTTransformer(MethodDef methodDef_0, ScopeBlock scopeBlock_0, VMRuntime vmruntime_0)
		{
			RootScope = scopeBlock_0;
			Method = methodDef_0;
			Runtime = vmruntime_0;
			Ijo(new Dictionary<object, object>());
			bjk();
		}

		private void bjk()
		{
			Ejh = new ITransformationHandler[7]
			{
				new VariableInlining(),
				new StringTransform(),
				new ArrayTransform(),
				new IndirectTransform(),
				new GClass11(),
				new NullTransform(),
				new BranchTransform()
			};
		}

		[SpecialName]
		[CompilerGenerated]
		internal Dictionary<object, object> mj5()
		{
			return ajd;
		}

		[SpecialName]
		[CompilerGenerated]
		private void Ijo(Dictionary<object, object> dictionary_0)
		{
			ajd = dictionary_0;
		}

		[SpecialName]
		[CompilerGenerated]
		internal BasicBlock<ILASTTree> IjZ()
		{
			return UjB;
		}

		[SpecialName]
		[CompilerGenerated]
		private void LjT(BasicBlock<ILASTTree> basicBlock_0)
		{
			UjB = basicBlock_0;
		}

		[SpecialName]
		internal ILASTTree aja()
		{
			return IjZ().Content;
		}

		public void Transform()
		{
			if (Ejh != null)
			{
				ITransformationHandler[] ejh = Ejh;
				foreach (ITransformationHandler cZe in ejh)
				{
					cZe.Initialize(this);
					RootScope.ProcessBasicBlocks(delegate(BasicBlock<ILASTTree> basicBlock_0)
					{
						LjT(basicBlock_0);
						cZe.Transform(this);
					});
				}
				Ejh = null;
				return;
			}
			throw new InvalidOperationException("Transformer already used.");
		}
	}
}
