using System.Runtime.CompilerServices;
using dnlib.DotNet.Emit;
using XCore.Emulator;

namespace XF
{
	internal class HQ6 : uQQ
	{
		[SpecialName]
		internal override OpCode QD5()
		{
			return OpCodes.Ldc_I4;
		}

		internal override void BDH(EmuContext emuContext_0, Instruction instruction_0)
		{
			emuContext_0.dQN.Push(instruction_0.Operand);
		}
	}
}
