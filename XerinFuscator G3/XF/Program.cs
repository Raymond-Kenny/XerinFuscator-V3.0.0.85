using System;
using System.Windows.Forms;

namespace XF
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(true);
			Application.Run(new Rql());
		}
	}
}
