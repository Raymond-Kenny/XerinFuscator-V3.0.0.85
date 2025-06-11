using XCore.Context;

namespace XCore.Protections
{
	public abstract class Protection
	{
		public abstract int number { get; }

		public abstract string name { get; }

		public abstract void Execute(XContext xcontext_0);
	}
}
