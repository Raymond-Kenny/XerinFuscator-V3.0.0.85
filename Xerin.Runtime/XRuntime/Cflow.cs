using System;
using System.Runtime.CompilerServices;

namespace XRuntime
{
	public static class Cflow
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Junk(int num1, int num2, int num3, int num4, int num5, int num6, int num7, int num8, int num9, int num10)
		{
			int num11 = num1 << num2;
			int num12 = num11 << num3;
			int num13 = num12 << num4;
			int num14 = num13 << num5;
			int num15 = num14 << num6;
			int num16 = num15 << num7;
			int num17 = num16 << num8;
			int num18 = num17 << num9;
			int num19 = num18 << num10;
			int num20 = num1 << num2 << num3 << num4 << num5 << num6 << num7 << num8 << num9 << num10;
			if (num20 == num19)
			{
				return num19;
			}
			throw new ArithmeticException("");
		}
	}
}
