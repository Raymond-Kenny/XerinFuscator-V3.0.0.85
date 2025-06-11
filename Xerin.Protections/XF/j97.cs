using System;
using System.Collections.Generic;
using dnlib.DotNet.Emit;
using XCore.Context;

namespace XF
{
	internal class j97 : k9R
	{
		private readonly XContext x9h;

		private bool P95;

		private int u9N;

		public j97(XContext xcontext_0)
		{
			x9h = xcontext_0;
		}

		public void pPA(CilBody cilBody_0)
		{
			if (!P95)
			{
				u9N = new Random().Next();
				P95 = true;
			}
		}

		public int oPI(int int_0)
		{
			return int_0 ^ u9N;
		}

		public void PPl(IList<Instruction> ilist_0)
		{
			ilist_0.Add(Instruction.Create(OpCodes.Ldc_I4, u9N));
			ilist_0.Add(Instruction.Create(OpCodes.Xor));
		}
	}
}
