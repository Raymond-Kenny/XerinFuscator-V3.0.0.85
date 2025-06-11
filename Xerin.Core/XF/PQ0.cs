using System.Runtime.CompilerServices;
using dnlib.DotNet.Emit;
using XCore.Emulator;

namespace XF
{
	internal class PQ0 : uQQ
	{
		[SpecialName]
		internal override OpCode QD5()
		{
			return OpCodes.Ldloc;
		}

		internal override void BDH(EmuContext emuContext_0, Instruction instruction_0)
		{
			emuContext_0.dQN.Push(emuContext_0.GYB((Local)instruction_0.Operand));
		}
	}
}
