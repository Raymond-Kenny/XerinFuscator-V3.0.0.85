using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace XF
{
	internal class r2X
	{
		public static Color a2K(int P_0, int P_1, int P_2)
		{
			return Color.FromArgb(P_0, P_1, P_2);
		}

		public static void q26(Control P_0, Control[] P_1, Control[] P_2, Guna2Separator P_3, Color P_4)
		{
			Guna2ControlBox[] array = P_0.Controls.OfType<Guna2ControlBox>().ToArray();
			Guna2ControlBox[] array2 = array;
			foreach (Guna2ControlBox guna2ControlBox in array2)
			{
				guna2ControlBox.HoverState.IconColor = P_4;
			}
			foreach (Control control in P_1)
			{
				control.ForeColor = P_4;
			}
			P_3.FillColor = P_4;
			foreach (Control control2 in P_2)
			{
				Guna2ToggleSwitch[] array3 = control2.Controls.OfType<Guna2ToggleSwitch>().ToArray();
				Guna2ToggleSwitch[] array4 = array3;
				foreach (Guna2ToggleSwitch guna2ToggleSwitch in array4)
				{
					guna2ToggleSwitch.CheckedState.FillColor = P_4;
				}
				Guna2TextBox[] array5 = control2.Controls.OfType<Guna2TextBox>().ToArray();
				Guna2TextBox[] array6 = array5;
				foreach (Guna2TextBox guna2TextBox in array6)
				{
					guna2TextBox.HoverState.BorderColor = P_4;
					guna2TextBox.FocusedState.BorderColor = P_4;
				}
				Panel[] array7 = control2.Controls.OfType<Panel>().ToArray();
				Panel[] array8 = array7;
				Panel[] array9 = array8;
				foreach (Panel panel in array9)
				{
					Guna2ToggleSwitch[] array10 = panel.Controls.OfType<Guna2ToggleSwitch>().ToArray();
					Guna2VSeparator[] array11 = panel.Controls.OfType<Guna2VSeparator>().ToArray();
					Guna2ToggleSwitch[] array12 = array10;
					foreach (Guna2ToggleSwitch guna2ToggleSwitch2 in array12)
					{
						guna2ToggleSwitch2.CheckedState.FillColor = P_4;
					}
					Guna2VSeparator[] array13 = array11;
					foreach (Guna2VSeparator guna2VSeparator in array13)
					{
						guna2VSeparator.FillColor = P_4;
					}
				}
			}
		}
	}
}
