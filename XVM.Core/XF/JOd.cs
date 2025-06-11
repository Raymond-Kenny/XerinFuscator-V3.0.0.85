using System;

namespace XF
{
	internal static class JOd
	{
		public static readonly int qO7;

		public static int OOB(int int_0, int int_1)
		{
			uint num = (uint)(int_0 << 5) | ((uint)int_0 >> 27);
			return ((int)num + int_0) ^ int_1;
		}

		static JOd()
		{
			qO7 = new Random().Next(int.MinValue, int.MaxValue);
		}
	}
}
