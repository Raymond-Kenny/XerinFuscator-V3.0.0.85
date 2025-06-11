using System;
using System.Collections.Generic;
using XVM.Runtime.XVM.Runtime.VCalls;

namespace XVM.Runtime.XVM.Runtime.Data
{
	internal static class VCallMap
	{
		private static readonly Dictionary<byte, IVCall> vCalls;

		static VCallMap()
		{
			vCalls = new Dictionary<byte, IVCall>();
			Type[] types = typeof(VCallMap).Assembly.GetTypes();
			foreach (Type type in types)
			{
				if (typeof(IVCall).IsAssignableFrom(type) && !type.IsAbstract)
				{
					IVCall iVCall = (IVCall)Activator.CreateInstance(type);
					vCalls[iVCall.Code] = iVCall;
				}
			}
		}

		public static IVCall Lookup(byte code)
		{
			return vCalls[code];
		}
	}
}
