using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class IConvR64 : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_ICONV_R64;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot value = ctx.Stack[u];
			double r = value.R8;
			value.U8 = (ulong)(long)r;
			byte b = (byte)(ctx.Registers[ctx.Data.Constants.REG_FL].U1 & ~ctx.Data.Constants.FL_OVERFLOW);
			if ((b & ctx.Data.Constants.FL_UNSIGNED) != 0)
			{
				if (!(r > -1.0) || !(r < 1.8446744073709552E+19))
				{
					b |= ctx.Data.Constants.FL_OVERFLOW;
				}
				if (!(r < 9.223372036854776E+18))
				{
					value.U8 = (ulong)((long)r - 9.223372036854776E+18) + 9223372036854775808uL;
				}
			}
			else if (!(r > -9.223372036854778E+18) || !(r < 9.223372036854776E+18))
			{
				b |= ctx.Data.Constants.FL_OVERFLOW;
			}
			ctx.Registers[ctx.Data.Constants.REG_FL].U1 = (byte)(b & ~ctx.Data.Constants.FL_UNSIGNED);
			ctx.Stack[u] = value;
			state = ExecutionState.Next;
		}
	}
}
