using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using XVM.Core;

namespace XF
{
	internal class vRj
	{
		private readonly Dictionary<MethodDef, EAP> dRc = new Dictionary<MethodDef, EAP>();

		public EAP PRO(MethodDef methodDef_0)
		{
			if (methodDef_0 == null)
			{
				throw new ArgumentNullException("method");
			}
			return dRc.GetValueOrDefaultLazy(methodDef_0, (MethodDef methodDef) => dRc[methodDef] = new EAP(methodDef)).GAd();
		}

		[CompilerGenerated]
		private EAP jRt(MethodDef methodDef_0)
		{
			return dRc[methodDef_0] = new EAP(methodDef_0);
		}
	}
}
