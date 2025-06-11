using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace XF
{
	[CompilerGenerated]
	internal sealed class PLe
	{
		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 3)]
		private struct jZJ
		{
		}

		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 7)]
		private struct nZ8
		{
		}

		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 12)]
		private struct WZz
		{
		}

		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 16)]
		private struct OT4
		{
		}

		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 20)]
		private struct CTe
		{
		}

		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 32)]
		private struct hTu
		{
		}

		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 64)]
		private struct aT9
		{
		}

		internal static uint OLu(string string_0)
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
