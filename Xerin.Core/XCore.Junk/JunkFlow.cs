using dnlib.DotNet;
using XCore.Context;
using XCore.Injection;
using XRuntime;

namespace XCore.Junk
{
	public class JunkFlow
	{
		private static newInjector kQw;

		public static MethodDef JunkMethod;

		public void injectCFJunk(XContext xcontext_0)
		{
			kQw = new newInjector(xcontext_0.Module, typeof(Cflow));
			JunkMethod = kQw.FindMember("Junk") as MethodDef;
			kQw.Rename();
		}
	}
}
