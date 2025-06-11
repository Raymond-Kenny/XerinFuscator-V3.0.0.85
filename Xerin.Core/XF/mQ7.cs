using System.Runtime.CompilerServices;
using dnlib.DotNet.Emit;
using XCore.Emulator;

namespace XF
{
	internal class mQ7 : uQQ
	{
		[SpecialName]
		internal override OpCode QD5()
		{
			return OpCodes.Br;
		}

		internal override void BDH(EmuContext emuContext_0, Instruction instruction_0)
		{
			emuContext_0.yQY = emuContext_0.KQU.IndexOf((Instruction)instruction_0.Operand);
		}
	}
}
