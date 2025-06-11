using dnlib.DotNet;
using XVM.Core.VM;

namespace XF
{
	internal class wqe
	{
		public readonly int hqu;

		public readonly MethodDef uq9;

		public readonly MethodSig lqG;

		public readonly object pqI;

		public readonly FuncSig Gqq;

		public wqe(MethodDef methodDef_0, MDToken mdtoken_0)
		{
			uq9 = methodDef_0;
			hqu = mdtoken_0.ToInt32();
			lqG = methodDef_0.MethodSig;
			pqI = methodDef_0.DeclaringType;
			Gqq = new FuncSig();
		}
	}
}
