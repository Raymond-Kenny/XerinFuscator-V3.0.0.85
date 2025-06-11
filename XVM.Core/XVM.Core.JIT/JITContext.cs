using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.RT;

namespace XVM.Core.JIT
{
	public class JITContext
	{
		public VMRuntime Runtime;

		public HashSet<MethodDef> Targets;

		public static List<CilBody> RealBodies;
	}
}
