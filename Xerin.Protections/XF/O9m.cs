using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Context;

namespace XF
{
	internal abstract class O9m
	{
		protected static IEnumerable<bxd.y7w> r9L(bxd.tLd tLd_0)
		{
			foreach (bxd.CLb item in tLd_0.l7c())
			{
				if (!(item is bxd.y7w))
				{
					foreach (bxd.y7w item2 in r9L((bxd.tLd)item))
					{
						yield return item2;
					}
				}
				else
				{
					yield return (bxd.y7w)item;
				}
			}
		}

		public abstract void VPT(CilBody cilBody_0, bxd.tLd tLd_0, XContext xcontext_0, MethodDef methodDef_0, TypeSig typeSig_0);
	}
}
