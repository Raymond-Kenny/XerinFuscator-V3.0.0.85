using System.Collections.Generic;
using XVM.Core.Helpers;

namespace XVM.Core.AST.IL
{
	public class ILInstrList : List<ILInstruction>
	{
		public void VisitInstrs<T>(VisitFunc<ILInstrList, ILInstruction, T> visitFunc_0, T GcK)
		{
			for (int i = 0; i < base.Count; i++)
			{
				visitFunc_0(this, base[i], ref i, GcK);
			}
		}
	}
}
