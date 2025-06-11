using System.Runtime.CompilerServices;
using dnlib.DotNet;

namespace XF
{
	internal class WUX
	{
		private static WUX KUf;

		[SpecialName]
		public static WUX HU9()
		{
			return KUf;
		}

		public bool eUm(IMethod imethod_0, IMethod imethod_1)
		{
			return imethod_0.Equals(imethod_1);
		}

		public int TUA(IMethod imethod_0)
		{
			return imethod_0.FullName.GetHashCode();
		}

		static WUX()
		{
			KUf = new WUX();
		}
	}
}
