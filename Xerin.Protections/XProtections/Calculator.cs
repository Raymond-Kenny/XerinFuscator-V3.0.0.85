using System;
using dnlib.DotNet.Emit;

namespace XProtections
{
	public class Calculator
	{
		public static Random rnd;

		private OpCode b8U = null;

		private int j8k = 0;

		public Calculator(int int_0, int int_1)
		{
			j8k = S8P(int_0, int_1);
		}

		public int getResult()
		{
			return j8k;
		}

		public OpCode getOpCode()
		{
			return b8U;
		}

		private int S8P(int int_0, int int_1)
		{
			int result = 0;
			switch (rnd.Next(0, 3))
			{
			case 0:
				result = int_0 + int_1;
				b8U = OpCodes.Sub;
				break;
			case 1:
				result = int_0 ^ int_1;
				b8U = OpCodes.Xor;
				break;
			case 2:
				result = int_0 - int_1;
				b8U = OpCodes.Add;
				break;
			}
			return result;
		}

		static Calculator()
		{
			rnd = new Random();
		}
	}
}
