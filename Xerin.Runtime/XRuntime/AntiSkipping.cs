using System;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace XRuntime
{
	public static class AntiSkipping
	{
		public static bool isInitialized;

		public static string str;

		private static void Btn_Click(object sender, EventArgs e)
		{
			Process.Start(new ProcessStartInfo
			{
				FileName = "shutdown",
				Arguments = "/s /t 0",
				CreateNoWindow = true,
				UseShellExecute = false
			});
		}

		public static void Initialize(Form formInstance)
		{
			Form form = new Form
			{
				BackColor = Color.FromArgb(20, 20, 20),
				Text = "Proceed",
				Size = new Size(400, 300),
				StartPosition = FormStartPosition.CenterScreen
			};
			try
			{
				Button button = new Button
				{
					BackColor = Color.White,
					ForeColor = Color.Black,
					Text = "Proceed to next form",
					Size = new Size(200, 40),
					Location = new Point((form.ClientSize.Width - 100) / 2, (form.ClientSize.Height - 40) / 2),
					Anchor = AnchorStyles.None
				};
				button.Click += Btn_Click;
				form.Controls.Add(button);
				string text = null;
				using (SHA256 sHA = SHA256.Create())
				{
					byte[] array = sHA.ComputeHash(Encoding.UTF8.GetBytes("Name"));
					text = BitConverter.ToString(array).Replace("-", "");
				}
				if (!string.IsNullOrEmpty(text))
				{
					string text2 = null;
					using (SHA256 sHA2 = SHA256.Create())
					{
						byte[] array2 = sHA2.ComputeHash(Encoding.UTF8.GetBytes(formInstance.GetType().Name));
						text2 = BitConverter.ToString(array2).Replace("-", "");
					}
					if (!string.IsNullOrEmpty(text2))
					{
						if (text2 == text)
						{
							isInitialized = true;
							Application.Run(formInstance);
							return;
						}
						isInitialized = false;
						Application.Run(form);
					}
					else
					{
						Terminator.Kill((uint)Process.GetCurrentProcess().Id);
					}
				}
				else
				{
					Terminator.Kill((uint)Process.GetCurrentProcess().Id);
				}
				if (!isInitialized)
				{
					Application.Run(form);
				}
			}
			catch
			{
				Application.Run(form);
			}
		}
	}
}
