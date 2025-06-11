using System.Collections.Generic;
using System.IO;
using XF;
using XVM.Core.VM;
using XVM.Core.VMIL;

namespace XVM.Core.RT.Mutation
{
	public class RTConstants
	{
		private readonly Dictionary<string, byte> LK9 = new Dictionary<string, byte>();

		private double sKG;

		public RTConstants(double double_0)
		{
			sKG = double_0;
		}

		private void qKu(string string_0, byte byte_0)
		{
			LK9[string_0] = byte_0;
		}

		public void ReadConstants(VMDescriptor vmdescriptor_0)
		{
			for (int i = 0; i < 13; i++)
			{
				VMRegisters vmregisters_ = (VMRegisters)i;
				byte byte_ = vmdescriptor_0.Architecture.Registers[vmregisters_];
				string string_ = vmregisters_.ToString();
				qKu(string_, byte_);
			}
			for (int j = 0; j < 5; j++)
			{
				VMFlags vmflags_ = (VMFlags)j;
				int num = vmdescriptor_0.Architecture.Flags[vmflags_];
				string string_2 = vmflags_.ToString();
				qKu(string_2, (byte)(1 << num));
			}
			for (int k = 0; k < 68; k++)
			{
				ILOpCode ilopCode_ = (ILOpCode)k;
				byte byte_2 = vmdescriptor_0.Architecture.OpCodes[ilopCode_];
				string string_3 = ilopCode_.ToString();
				qKu(string_3, byte_2);
			}
			for (int l = 0; l < 17; l++)
			{
				VMCalls vmcalls_ = (VMCalls)l;
				int num2 = vmdescriptor_0.Runtime.VMCall[vmcalls_];
				string string_4 = vmcalls_.ToString();
				qKu(string_4, (byte)num2);
			}
			qKu(G2x.E_CALL.ToString(), (byte)vmdescriptor_0.Runtime.VCallOps.ECALL_CALL);
			qKu(G2x.E_CALLVIRT.ToString(), (byte)vmdescriptor_0.Runtime.VCallOps.ECALL_CALLVIRT);
			qKu(G2x.E_NEWOBJ.ToString(), (byte)vmdescriptor_0.Runtime.VCallOps.ECALL_NEWOBJ);
			qKu(G2x.E_CALLVIRT_CONSTRAINED.ToString(), (byte)vmdescriptor_0.Runtime.VCallOps.ECALL_CALLVIRT_CONSTRAINED);
			qKu(G2x.CATCH.ToString(), vmdescriptor_0.Runtime.RTFlags.EH_CATCH);
			qKu(G2x.FILTER.ToString(), vmdescriptor_0.Runtime.RTFlags.EH_FILTER);
			qKu(G2x.FAULT.ToString(), vmdescriptor_0.Runtime.RTFlags.EH_FAULT);
			qKu(G2x.FINALLY.ToString(), vmdescriptor_0.Runtime.RTFlags.EH_FINALLY);
			MemoryStream memoryStream = new MemoryStream();
			using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
			{
				List<byte> list = new List<byte>();
				list.AddRange(LK9.Values);
				for (int m = 0; m < list.Count; m++)
				{
					binaryWriter.Write(Utils.EncryptInt(list[m], sKG));
				}
			}
			vmdescriptor_0.Data.xIi = memoryStream.ToArray();
		}
	}
}
