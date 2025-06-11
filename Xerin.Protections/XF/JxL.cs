using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XF
{
	internal abstract class JxL
	{
		public JxL(ModuleDef moduleDef_0)
		{
			TPr(moduleDef_0);
		}

		protected abstract void TPr(ModuleDef moduleDef_0);

		public abstract void jP6(IList<Instruction> ilist_0, int int_0);
	}
}
