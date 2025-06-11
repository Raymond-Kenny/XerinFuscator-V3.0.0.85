using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XF
{
	internal static class rM
	{
		public static async Task qD(Form P_0)
		{
			Point original = P_0.Location;
			Random rnd = new Random(1337);
			for (int i = 0; i < 10; i++)
			{
				P_0.Location = new Point(original.X + rnd.Next(-10, 10), original.Y + rnd.Next(-10, 10));
				await Task.Delay(2);
			}
			P_0.Location = original;
		}
	}
}
