using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Context;
using XCore.Injection;
using XCore.Protections;
using XRuntime;

namespace XProtections
{
	public class AntiDump : Protection
	{
		private static newInjector a8B;

		private static MethodDef L8p;

		public override string name => "Anti Dump";

		public override int number => 9;

		public override void Execute(XContext xcontext_0)
		{
			a8B = new newInjector(xcontext_0.Module, typeof(AntiDumpRuntime));
			L8p = a8B.FindMember("Initialize") as MethodDef;
			MethodDef methodDef = xcontext_0.Module.GlobalType.FindOrCreateStaticConstructor();
			methodDef.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(L8p));
			a8B.Rename();
		}
	}
}
