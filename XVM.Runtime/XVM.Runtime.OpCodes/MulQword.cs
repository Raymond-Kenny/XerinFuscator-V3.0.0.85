using XVM.Runtime.XVM.Runtime;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class MulQword : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_MUL_QWORD;

		private static ulong Carry(ulong a, ulong b)
		{
			ulong num = a & 0xFFFFFFFFu;
			ulong num2 = a >> 32;
			ulong num3 = b & 0xFFFFFFFFu;
			ulong num4 = b >> 32;
			ulong num5 = num * num3;
			ulong num6 = num5 & 0xFFFFFFFFu;
			num5 = num2 * num3 + (num5 >> 32);
			ulong num7 = num5 & 0xFFFFFFFFu;
			ulong num8 = num5 >> 32;
			num5 = num7 + num * num4;
			num7 = num5 & 0xFFFFFFFFu;
			return num8 + num2 * num4 + (num5 >> 32);
		}

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot vMSlot = ctx.Stack[u - 1];
			VMSlot vMSlot2 = ctx.Stack[u];
			u--;
			ctx.Stack.SetTopPosition(u);
			ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
			byte u2 = ctx.Registers[ctx.Data.Constants.REG_FL].U1;
			VMSlot value = default(VMSlot);
			ulong num = value.U8 = vMSlot.U8 * vMSlot2.U8;
			ctx.Stack[u] = value;
			byte mask = (byte)(ctx.Data.Constants.FL_ZERO | ctx.Data.Constants.FL_SIGN | ctx.Data.Constants.FL_UNSIGNED);
			byte b = (byte)(ctx.Data.Constants.FL_CARRY | ctx.Data.Constants.FL_OVERFLOW);
			byte b2 = 0;
			if ((u2 & ctx.Data.Constants.FL_UNSIGNED) != 0)
			{
				if (Carry(vMSlot.U8, vMSlot2.U8) != 0)
				{
					b2 = b;
				}
			}
			else if (num >> 63 != (vMSlot.U8 ^ vMSlot2.U8) >> 63)
			{
				b2 = b;
			}
			u2 = (byte)(u2 & ~b | b2);
			Utils.UpdateFL(ctx, vMSlot.U4, vMSlot2.U8, value.U8, value.U8, ref u2, mask);
			ctx.Registers[ctx.Data.Constants.REG_FL].U1 = u2;
			state = ExecutionState.Next;
		}
	}
}
