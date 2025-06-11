using System.Collections.Generic;
using XVM.Runtime.XVM.Runtime.Data;

namespace XVM.Runtime.XVM.Runtime.Execution
{
	public class VMContext
	{
		private const int NumRegisters = 16;

		internal readonly VMSlot[] Registers = new VMSlot[16];

		internal readonly VMStack Stack = new VMStack();

		internal readonly VMInstance Instance;

		internal readonly VMData Data;

		internal readonly List<EHFrame> EHStack = new List<EHFrame>();

		internal readonly List<EHState> EHStates = new List<EHState>();

		internal VMContext(VMInstance inst)
		{
			Instance = inst;
			Data = inst.Data;
		}

		internal unsafe byte ReadByte()
		{
			uint u = Registers[Data.Constants.REG_K1].U4;
			byte* ptr = (byte*)Registers[Data.Constants.REG_IP].U8++;
			byte b = (byte)(*ptr ^ u);
			u = u * 7 + b;
			Registers[Data.Constants.REG_K1].U4 = u;
			return b;
		}
	}
}
