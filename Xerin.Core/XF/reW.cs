using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XF
{
	[CompilerGenerated]
	internal sealed class reW
	{
		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 3)]
		private struct N0r
		{
		}

		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 6)]
		private struct q0c
		{
		}

		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 7)]
		private struct n0w
		{
		}

		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 10)]
		private struct e0q
		{
		}

		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 64)]
		private struct y0y
		{
		}

		internal static uint xeG(string string_0)
		{
			uint num = default(uint);
			if (string_0 != null)
			{
				num = 2166136261u;
				for (int i = 0; i < string_0.Length; i++)
				{
					num = (string_0[i] ^ num) * 16777619;
				}
			}
			return num;
		}
	}
}
