namespace XF
{
	internal abstract class Kwl
	{
		public struct v5N
		{
			public uint n5c;

			public void W52()
			{
				n5c = 0u;
			}

			public void J5K()
			{
				if (n5c < 4)
				{
					n5c = 0u;
				}
				else if (n5c < 10)
				{
					n5c -= 3u;
				}
				else
				{
					n5c -= 6u;
				}
			}

			public void y51()
			{
				n5c = ((n5c >= 7) ? 10u : 7u);
			}

			public void v5j()
			{
				n5c = ((n5c >= 7) ? 11u : 8u);
			}

			public void E5O()
			{
				n5c = ((n5c >= 7) ? 11u : 9u);
			}

			public bool A5t()
			{
				return n5c < 7;
			}
		}

		public static uint owZ(uint uint_0)
		{
			uint_0 -= 2;
			if (uint_0 < 4)
			{
				return uint_0;
			}
			return 3u;
		}
	}
}
