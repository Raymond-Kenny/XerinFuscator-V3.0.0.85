using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Writer;
using XF;
using XVM.Core.CFG;
using XVM.Core.JIT;
using XVM.Core.RT;
using XVM.Core.VMIL;
using XVM.Runtime;

namespace XVM.Core
{
	public class Virtualizer : IVMSettings
	{
		private ModuleDef OIY;

		private MethodVirtualizer yIg;

		private HashSet<MethodDef> jIV = new HashSet<MethodDef>();

		private HashSet<ModuleDef> oIb = new HashSet<ModuleDef>();

		[CompilerGenerated]
		private VMRuntime DIp;

		public VMRuntime Runtime
		{
			[CompilerGenerated]
			get
			{
				return DIp;
			}
			[CompilerGenerated]
			private set
			{
				DIp = value;
			}
		}

		public Virtualizer(ModuleDef moduleDef_0, string string_0)
		{
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(VMEntry).Module);
			moduleDefMD.Assembly.Name = string_0;
			moduleDefMD.Name = string.Empty;
			if (Path.GetExtension(string_0) == ".dll")
			{
				moduleDefMD.Assembly.Name = Path.GetFileNameWithoutExtension(string_0);
			}
			moduleDefMD.AssemblyReferencesAdder();
			moduleDef_0.AssemblyReferencesAdder();
			OIY = moduleDef_0;
			Runtime = new VMRuntime(this, moduleDefMD);
			yIg = new MethodVirtualizer(Runtime);
			XjJ.BO0 = XjJ.oON;
			XjJ.HOw = XjJ.WO2;
			XjJ.vOW = XjJ.fOK;
			XjJ.yOE = XjJ.EO1;
			TNd.Q29 = "Mutation";
			TNd.Y2G = "Placeholder";
			TNd.w2I = "LocationIndex";
			TNd.O2q = "Value";
			TNd.a2M = "Value";
			TNd.T2A = "Crypt";
			Runtime.n2m(new PKj(Runtime.RTModule, Runtime).dKO());
			Runtime.i2L().KKq();
		}

		public void AddMethod(MethodDef methodDef_0)
		{
			if (methodDef_0.HasBody && !methodDef_0.HasGenericParameters)
			{
				jIV.Add(methodDef_0);
			}
		}

		public void JIT(ModuleDef moduleDef_0, ModuleWriterOptions moduleWriterOptions_0, out JITContext jitcontext_0)
		{
			jitcontext_0 = new JITContext();
			HashSet<MethodDef> hashSet = new HashSet<MethodDef>();
			for (int i = 0; i < moduleDef_0.Types.Count; i++)
			{
				for (int j = 0; j < moduleDef_0.Types[i].Methods.Count; j++)
				{
					MethodDef methodDef = moduleDef_0.Types[i].Methods[j];
					if (GetMethods_FullNames().Contains(methodDef.FullName))
					{
						hashSet.Add(methodDef);
					}
				}
			}
			jitcontext_0.Runtime = Runtime;
			jitcontext_0.Targets = hashSet;
			JITWriter jITWriter = new JITWriter(jitcontext_0, moduleDef_0);
			jITWriter.HandleRun(moduleWriterOptions_0);
		}

		public IEnumerable<MethodDef> GetMethods()
		{
			return jIV;
		}

		public void ResolveMethods()
		{
			HashSet<MethodDef> hashSet = new HashSet<MethodDef>();
			for (int i = 0; i < OIY.Types.Count; i++)
			{
				for (int j = 0; j < OIY.Types[i].Methods.Count; j++)
				{
					MethodDef methodDef = OIY.Types[i].Methods[j];
					if (GetMethods_FullNames().Contains(methodDef.FullName))
					{
						hashSet.Add(methodDef);
					}
				}
			}
			jIV = hashSet;
		}

		public IEnumerable<string> GetMethods_FullNames()
		{
			HashSet<string> hashSet = new HashSet<string>();
			foreach (MethodDef item in jIV)
			{
				hashSet.Add(item.FullName);
			}
			return hashSet;
		}

		public void ProcessMethods(ModuleWriterBase moduleWriterBase_0)
		{
			if (oIb.Contains(OIY))
			{
				throw new InvalidOperationException("Module already processed.");
			}
			List<MethodDef> list = jIV.Where((MethodDef methodDef_0) => methodDef_0.Module == OIY).ToList();
			for (int num = 0; num < list.Count; num++)
			{
				MethodDef methodDef = list[num];
				YId(methodDef, moduleWriterBase_0.Metadata.GetToken(methodDef));
			}
			oIb.Add(OIY);
		}

		public void CommitModule(Metadata metadata_0)
		{
			MethodDef[] array = jIV.Where((MethodDef methodDef) => methodDef.Module == OIY).ToArray();
			foreach (MethodDef methodDef_ in array)
			{
				NIB(methodDef_);
			}
			Runtime.i2L().JKM(OIY, metadata_0);
		}

		private void YId(MethodDef methodDef_0, MDToken mdtoken_0)
		{
			yIg.Run(methodDef_0, mdtoken_0);
		}

		private void NIB(MethodDef methodDef_0)
		{
			ScopeBlock scopeBlock_ = Runtime.LookupMethod(methodDef_0);
			ILPostTransformer iLPostTransformer = new ILPostTransformer(methodDef_0, scopeBlock_, Runtime);
			iLPostTransformer.Transform();
		}

		bool IVMSettings.IsVirtualized(MethodDef methodDef_0)
		{
			return jIV.Contains(methodDef_0);
		}

		public void Clear()
		{
			Runtime.f2C().Dispose();
			Runtime.ResetData();
			oIb.Clear();
			jIV.Clear();
			OIY = null;
			yIg = null;
		}

		[CompilerGenerated]
		private bool vI7(MethodDef methodDef_0)
		{
			return methodDef_0.Module == OIY;
		}

		[CompilerGenerated]
		private bool rID(MethodDef methodDef_0)
		{
			return methodDef_0.Module == OIY;
		}
	}
}
