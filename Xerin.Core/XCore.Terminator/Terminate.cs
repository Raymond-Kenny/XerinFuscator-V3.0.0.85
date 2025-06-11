using dnlib.DotNet;
using XCore.Context;
using XCore.Injection;
using XRuntime;

namespace XCore.Terminator
{
	public class Terminate
	{
		private static newInjector SUu;

		public static MethodDef Kill;

		public void injectKill(XContext xcontext_0)
		{
			SUu = new newInjector(xcontext_0.Module, typeof(XRuntime.Terminator));
			Kill = SUu.FindMember("Kill") as MethodDef;
			SUu.Rename();
		}
	}
}
