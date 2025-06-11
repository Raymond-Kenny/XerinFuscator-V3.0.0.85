using System.Drawing;
using System.Windows.Forms;

namespace XF
{
	internal static class a2r
	{
		public static void g2n(object P_0)
		{
			int num = Screen.GetWorkingArea((Control)P_0).Width - 14;
			int num2 = Screen.GetWorkingArea((Control)P_0).Height - 14;
			((Form)P_0).Location = new Point(num - ((Control)P_0).Width, num2 - ((Control)P_0).Height);
		}

		public static void T2H(string P_0, string P_1)
		{
			aqe.Rqb(P_0);
			aqe.vqU(P_1);
			new aqe().ShowDialog();
		}
	}
}
