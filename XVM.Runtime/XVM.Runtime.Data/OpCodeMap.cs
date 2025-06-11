using System;
using System.Collections.Generic;
using XVM.Runtime.XVM.Runtime.OpCodes;

namespace XVM.Runtime.XVM.Runtime.Data
{
	internal static class OpCodeMap
	{
		private static readonly Dictionary<byte, IOpCode> opCodes;

		static OpCodeMap()
		{
			opCodes = new Dictionary<byte, IOpCode>();
			Type[] types = typeof(OpCodeMap).Assembly.GetTypes();
			foreach (Type type in types)
			{
				if (typeof(IOpCode).IsAssignableFrom(type) && !type.IsAbstract)
				{
					IOpCode opCode = (IOpCode)Activator.CreateInstance(type);
					opCodes[opCode.Code] = opCode;
				}
			}
		}

		public static IOpCode Lookup(byte code)
		{
			return opCodes[code];
		}
	}
}
