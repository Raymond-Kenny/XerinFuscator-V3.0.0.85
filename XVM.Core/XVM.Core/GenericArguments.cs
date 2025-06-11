using System.Collections.Generic;
using dnlib.DotNet;
using XF;

namespace XVM.Core
{
	public sealed class GenericArguments
	{
		private PIW lI0 = new PIW(bool_0: true);

		private PIW WIw = new PIW(bool_0: false);

		public void PushTypeArgs(IList<TypeSig> ilist_0)
		{
			lI0.VIE(ilist_0);
		}

		public IList<TypeSig> PopTypeArgs()
		{
			return lI0.LIN();
		}

		public void PushMethodArgs(IList<TypeSig> ilist_0)
		{
			WIw.VIE(ilist_0);
		}

		public IList<TypeSig> PopMethodArgs()
		{
			return WIw.LIN();
		}

		public TypeSig Resolve(TypeSig typeSig_0)
		{
			if (typeSig_0 != null)
			{
				if (!(typeSig_0 is GenericMVar genericMVar))
				{
					if (!(typeSig_0 is GenericVar genericVar))
					{
						return typeSig_0;
					}
					TypeSig typeSig = lI0.cI2(genericVar.Number);
					if (typeSig == null || typeSig == typeSig_0)
					{
						return typeSig_0;
					}
					return typeSig;
				}
				TypeSig typeSig2 = WIw.cI2(genericMVar.Number);
				if (typeSig2 == null || typeSig2 == typeSig_0)
				{
					return typeSig_0;
				}
				return typeSig2;
			}
			return null;
		}
	}
}
