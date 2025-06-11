using System;
using System.IO;

namespace XVM.Runtime.XVM.Runtime.Data
{
	internal class VMFuncSig
	{
		private readonly int[] paramToks;

		private readonly double[] paramToks_Keys;

		private readonly int retTok;

		private readonly double retTok_Key;

		private Type[] paramTypes;

		private Type retType;

		public Type[] ParamTypes
		{
			get
			{
				if (paramTypes != null)
				{
					return paramTypes;
				}
				Type[] array = new Type[paramToks.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = VMInstance.__ExecuteModule.ResolveType(Utils.Decrypt(paramToks[i], paramToks_Keys[i]));
				}
				paramTypes = array;
				return array;
			}
		}

		public Type RetType => retType ?? (retType = VMInstance.__ExecuteModule.ResolveType(Utils.Decrypt(retTok, retTok_Key)));

		public VMFuncSig(BinaryReader reader)
		{
			paramToks = new int[reader.ReadInt32()];
			paramToks_Keys = new double[paramToks.Length];
			for (int i = 0; i < paramToks.Length; i++)
			{
				paramToks[i] = reader.ReadInt32();
				paramToks_Keys[i] = reader.ReadDouble();
			}
			retTok = reader.ReadInt32();
			retTok_Key = reader.ReadDouble();
		}
	}
}
