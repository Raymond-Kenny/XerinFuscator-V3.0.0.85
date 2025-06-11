using System.Collections.Generic;
using dnlib.DotNet;

namespace XF
{
	internal struct PIW
	{
		private readonly List<IList<TypeSig>> fIK;

		private readonly bool II1;

		public PIW(bool bool_0)
		{
			fIK = new List<IList<TypeSig>>();
			II1 = bool_0;
		}

		public void VIE(IList<TypeSig> ilist_0)
		{
			fIK.Add(ilist_0);
		}

		public IList<TypeSig> LIN()
		{
			int index = fIK.Count - 1;
			IList<TypeSig> result = fIK[index];
			fIK.RemoveAt(index);
			return result;
		}

		public TypeSig cI2(uint uint_0)
		{
			TypeSig result = null;
			int num = fIK.Count - 1;
			while (num >= 0)
			{
				IList<TypeSig> list = fIK[num];
				if (uint_0 < list.Count)
				{
					TypeSig typeSig = list[(int)uint_0];
					if (typeSig is GenericSig genericSig && genericSig.IsTypeVar == II1)
					{
						result = genericSig;
						uint_0 = genericSig.Number;
						num--;
						continue;
					}
					return typeSig;
				}
				return null;
			}
			return result;
		}
	}
}
