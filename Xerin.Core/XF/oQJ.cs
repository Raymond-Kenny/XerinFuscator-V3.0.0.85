using System.Runtime.CompilerServices;
using dnlib.DotNet.Emit;
using XCore.Emulator;

namespace XF
{
	internal class oQJ : uQQ
	{
		[SpecialName]
		internal override OpCode QD5()
		{
			return OpCodes.And;
		}

		internal override void BDH(EmuContext emuContext_0, Instruction instruction_0)
		{
			int num = (int)emuContext_0.dQN.Pop();
			int num2 = (int)emuContext_0.dQN.Pop();
			emuContext_0.dQN.Push(num2 & num);
		}
	}
}
