using System.Collections.Generic;
using dnlib.DotNet;
using XF;
using XVM.Core.Services;

namespace XVM.Core.VM
{
	public class DataDescriptor
	{
		private readonly Dictionary<MethodDef, int> SIn = new Dictionary<MethodDef, int>();

		private readonly Dictionary<MethodDef, VMMethodInfo> HI6 = new Dictionary<MethodDef, VMMethodInfo>();

		private uint UIx;

		private uint qIs;

		private readonly Virtualizer GIQ;

		private readonly RandomGenerator hIf;

		internal byte[] xIi = new byte[0];

		internal Dictionary<IMemberRef, uint> EIJ = new Dictionary<IMemberRef, uint>();

		internal List<wqe> QI8 = new List<wqe>();

		internal Dictionary<byte[], uint> NIz = new Dictionary<byte[], uint>();

		internal DataDescriptor(Virtualizer virtualizer_0, RandomGenerator randomGenerator_0)
		{
			NIz[new byte[0]] = 1u;
			qIs = 2u;
			UIx = 1u;
			GIQ = virtualizer_0;
			hIf = randomGenerator_0;
		}

		public uint GetId(IMemberRef imemberRef_0)
		{
			if (!EIJ.TryGetValue(imemberRef_0, out var value))
			{
				value = (EIJ[imemberRef_0] = UIx++);
			}
			return value;
		}

		public void ReplaceReference(IMemberRef imemberRef_0, IMemberRef imemberRef_1)
		{
			if (EIJ.TryGetValue(imemberRef_0, out var value))
			{
				EIJ.Remove(imemberRef_0);
				EIJ[imemberRef_1] = value;
			}
		}

		public uint GetId(byte[] byte_0)
		{
			if (!NIz.TryGetValue(byte_0, out var value))
			{
				value = (NIz[byte_0] = qIs++);
			}
			return value;
		}

		public void ReadExportMDToken(MethodDef methodDef_0, MDToken mdtoken_0)
		{
			if (!SIn.TryGetValue(methodDef_0, out var _))
			{
				SIn[methodDef_0] = mdtoken_0.ToInt32();
				QI8.Add(new wqe(methodDef_0, mdtoken_0));
			}
		}

		public VMMethodInfo LookupInfo(MethodDef methodDef_0)
		{
			if (!HI6.TryGetValue(methodDef_0, out var value))
			{
				byte entryKey = hIf.NextByte();
				value = new VMMethodInfo
				{
					EntryKey = entryKey,
					ExitKey = 0
				};
				HI6[methodDef_0] = value;
			}
			return value;
		}

		public void SetInfo(MethodDef methodDef_0, VMMethodInfo vmmethodInfo_0)
		{
			HI6[methodDef_0] = vmmethodInfo_0;
		}
	}
}
