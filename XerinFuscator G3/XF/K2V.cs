using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using XerinFuscator_G3.Properties;

namespace XF
{
	internal class K2V
	{
		[CompilerGenerated]
		private static string zZg;

		[SpecialName]
		[CompilerGenerated]
		public static string wZh()
		{
			return zZg;
		}

		[SpecialName]
		[CompilerGenerated]
		public static void iZq(string P_0)
		{
			zZg = P_0;
		}

		public static void e2z(object P_0, Control P_1, Control P_2, Control P_3, Control P_4)
		{
			Guna2Button[] array = P_1.Controls.OfType<Guna2Button>().ToArray();
			Guna2Button[] array2 = array;
			foreach (Guna2Button guna2Button in array2)
			{
				bool flag = guna2Button == P_3;
				((Control)guna2Button).ForeColor = ((!flag) ? Color.FromArgb(90, 90, 90) : Color.White);
				switch (((Control)guna2Button).Name)
				{
				case "gotoColors":
					guna2Button.Image = (flag ? Resources.invert_colors_24px : Resources.invert_colors_24px2);
					break;
				case "gotoCodeVirt":
					guna2Button.Image = ((!flag) ? Resources.data_protection_24px2 : Resources.data_protection_24px);
					break;
				case "gotoCodeEnc":
					guna2Button.Image = ((!flag) ? Resources.shield_24px2 : Resources.shield_24px);
					break;
				case "gotoAssembly":
					guna2Button.Image = (flag ? Resources.file_24px : Resources.file_24px2);
					break;
				case "gotoProtections":
					guna2Button.Image = (flag ? Resources.security_configuration_24px : Resources.security_configuration_24px2);
					break;
				case "gotoProject":
					guna2Button.Image = (flag ? Resources.merge_24px : Resources.merge_24px2);
					break;
				case "gotoRenamer":
					guna2Button.Image = (flag ? Resources.translation_24px : Resources.translation_24px2);
					break;
				case "gotoPacker":
					guna2Button.Image = (flag ? Resources.compress_24px1 : Resources.compress_24px2);
					break;
				}
				if (flag)
				{
					P_2.BringToFront();
				}
				P_4.Visible = true;
				P_4.Location = new Point(-2, P_3.Location.Y);
			}
		}
	}
}
