using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XF
{
	internal class gU8 : IDisposable
	{
		private CilBody wUZ;

		private bool NUa;

		public gU8(MethodDef methodDef_0, bool bool_0)
		{
			wUZ = methodDef_0.Body;
			NUa = bool_0;
			wUZ.SimplifyMacros(methodDef_0.Parameters);
		}

		public void Dispose()
		{
			if (NUa)
			{
				wUZ.OptimizeMacros();
			}
		}
	}
}
