using dnlib.DotNet;
using XCore.Context;
using XCore.Injection;
using XRuntime;

namespace XCore.Decompression
{
	public class QuickLZ
	{
		private static newInjector gQn;

		public static MethodDef QLZDecompression;

		public void injectQuickLZ(XContext xcontext_0)
		{
			gQn = new newInjector(xcontext_0.Module, typeof(QuickLZDecompression));
			QLZDecompression = gQn.FindMember("decompress") as MethodDef;
			gQn.Rename();
		}
	}
}
