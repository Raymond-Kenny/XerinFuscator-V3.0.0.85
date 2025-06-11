using System.Runtime.CompilerServices;
using dnlib.DotNet.Emit;
using XCore.Emulator;

namespace XF
{
	internal class fQt : uQQ
	{
		[SpecialName]
		internal override OpCode QD5()
		{
			return OpCodes.Blt;
		}

		internal override void BDH(EmuContext emuContext_0, Instruction instruction_0)
		{
			int num = (int)emuContext_0.dQN.Pop();
			int num2 = (int)emuContext_0.dQN.Pop();
			if (num2 < num)
			{
				emuContext_0.yQY = emuContext_0.KQU.IndexOf((Instruction)instruction_0.Operand);
			}
		}
	}
}
