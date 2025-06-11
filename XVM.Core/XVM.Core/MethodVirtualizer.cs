using System.Runtime.CompilerServices;
using dnlib.DotNet;
using XVM.Core.CFG;
using XVM.Core.ILAST;
using XVM.Core.RT;
using XVM.Core.VMIL;
using XVM.Core.VMIR;

namespace XVM.Core
{
	public class MethodVirtualizer
	{
		[CompilerGenerated]
		private VMRuntime SIo;

		[CompilerGenerated]
		private MethodDef xIl;

		[CompilerGenerated]
		private ScopeBlock jIZ;

		[CompilerGenerated]
		private IRContext hIT;

		protected VMRuntime Runtime
		{
			[CompilerGenerated]
			get
			{
				return SIo;
			}
			[CompilerGenerated]
			private set
			{
				SIo = value;
			}
		}

		protected MethodDef Method
		{
			[CompilerGenerated]
			get
			{
				return xIl;
			}
			[CompilerGenerated]
			private set
			{
				xIl = value;
			}
		}

		protected ScopeBlock RootScope
		{
			[CompilerGenerated]
			get
			{
				return jIZ;
			}
			[CompilerGenerated]
			private set
			{
				jIZ = value;
			}
		}

		protected IRContext IRContext
		{
			[CompilerGenerated]
			get
			{
				return hIT;
			}
			[CompilerGenerated]
			private set
			{
				hIT = value;
			}
		}

		public MethodVirtualizer(VMRuntime vmruntime_0)
		{
			Runtime = vmruntime_0;
		}

		public ScopeBlock Run(MethodDef methodDef_0, MDToken mdtoken_0)
		{
			try
			{
				Method = methodDef_0;
				Init();
				vmethod_0();
				TransformILAST();
				vmethod_1();
				TransformVMIR();
				vmethod_2();
				TransformVMIL();
				Deinitialize(mdtoken_0);
				ScopeBlock rootScope = RootScope;
				RootScope = null;
				Method = null;
				return rootScope;
			}
			catch
			{
				ScopeBlock rootScope2 = RootScope;
				RootScope = null;
				Method = null;
				return rootScope2;
			}
		}

		protected virtual void Init()
		{
			RootScope = BlockParser.Parse(Method, Method.Body);
			IRContext = new IRContext(Method, Method.Body);
		}

		protected virtual void vmethod_0()
		{
			ILASTBuilder.BuildAST(Method, Method.Body, RootScope);
		}

		protected virtual void TransformILAST()
		{
			ILASTTransformer iLASTTransformer = new ILASTTransformer(Method, RootScope, Runtime);
			iLASTTransformer.Transform();
		}

		protected virtual void vmethod_1()
		{
			IRTranslator iRTranslator = new IRTranslator(IRContext, Runtime);
			iRTranslator.Translate(RootScope);
		}

		protected virtual void TransformVMIR()
		{
			IRTransformer iRTransformer = new IRTransformer(RootScope, IRContext, Runtime);
			iRTransformer.Transform();
		}

		protected virtual void vmethod_2()
		{
			ILTranslator iLTranslator = new ILTranslator(Runtime);
			iLTranslator.Translate(RootScope);
		}

		protected virtual void TransformVMIL()
		{
			ILTransformer iLTransformer = new ILTransformer(Method, RootScope, Runtime);
			iLTransformer.Transform();
		}

		protected virtual void Deinitialize(MDToken mdtoken_0)
		{
			IRContext = null;
			Runtime.AddMethod(Method, RootScope);
			Runtime.ExportMethod(Method, mdtoken_0);
		}
	}
}
