using System.Runtime.CompilerServices;
using dnlib.DotNet.Emit;
using XCore.Emulator;

namespace XF
{
	internal class AQo : uQQ
	{
		[SpecialName]
		internal override OpCode QD5()
		{
			return OpCodes.Stloc;
		}

		internal override void BDH(EmuContext emuContext_0, Instruction instruction_0)
		{
			object object_ = emuContext_0.dQN.Pop();
			emuContext_0.sYz((Local)instruction_0.Operand, object_);
		}
	}
}
