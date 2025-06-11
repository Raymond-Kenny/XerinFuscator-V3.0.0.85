using System.Collections.Generic;
using XVM.Core.Helpers;

namespace XVM.Core.AST.IR
{
	public class IRInstrList : List<IRInstruction>
	{
		public void VisitInstrs<T>(VisitFunc<IRInstrList, IRInstruction, T> visitFunc_0, T xtQ)
		{
			for (int i = 0; i < base.Count; i++)
			{
				visitFunc_0(this, base[i], ref i, xtQ);
			}
		}
	}
}
