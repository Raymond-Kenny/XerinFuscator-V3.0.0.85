using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using XerinFuscator_G3.Properties;

namespace XF
{
	internal class aqe : Form
	{
		[CompilerGenerated]
		private static int Lqp;

		[CompilerGenerated]
		private static int nqj;

		[CompilerGenerated]
		private static int Wq3;

		[CompilerGenerated]
		private static string YqW;

		[CompilerGenerated]
		private static string Dqy;

		private Container fqL = null;

		private Guna2Elipse wqJ;

		private Panel vqA;

		private Guna2HtmlLabel Bqk;

		private Guna2ProgressBar fqG;

		private Guna2CirclePictureBox pqS;

		private Guna2HtmlLabel pq5;

		private Guna2ShadowForm Iqs;

		public aqe()
		{
			InitializeComponent();
			DoubleBuffered = true;
		}

		[SpecialName]
		[CompilerGenerated]
		public static int tqQ()
		{
			return Lqp;
		}

		[SpecialName]
		[CompilerGenerated]
		public static void tqF(int P_0)
		{
			Lqp = P_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public static int pqM()
		{
			return nqj;
		}

		[SpecialName]
		[CompilerGenerated]
		public static void wqD(int P_0)
		{
			nqj = P_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public static int Gqo()
		{
			return Wq3;
		}

		[SpecialName]
		[CompilerGenerated]
		public static void BqB(int P_0)
		{
			Wq3 = P_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public static string Tqu()
		{
			return YqW;
		}

		[SpecialName]
		[CompilerGenerated]
		public static void Rqb(string P_0)
		{
			YqW = P_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public static string MqY()
		{
			return Dqy;
		}

		[SpecialName]
		[CompilerGenerated]
		public static void vqU(string P_0)
		{
			Dqy = P_0;
		}

		private async void Vq9(object sender, EventArgs e)
		{
			Invalidate();
			Iqs.SetShadowForm(this);
			((Control)Bqk).ForeColor = r2X.a2K(tqQ(), pqM(), Gqo());
			fqG.ProgressColor = r2X.a2K(tqQ(), pqM(), Gqo());
			fqG.ProgressColor2 = r2X.a2K(tqQ(), pqM(), Gqo());
			a2r.g2n(this);
			((Control)Bqk).Text = Tqu();
			((Control)pq5).Text = MqY();
			await Task.Delay(1500);
			Close();
		}

		private void Mq0(object sender, EventArgs e)
		{
			Invalidate();
		}

		protected override void Dispose(bool P_0)
		{
			if (P_0 && fqL != null)
			{
				((IDisposable)fqL).Dispose();
			}
			base.Dispose(P_0);
		}

		private void InitializeComponent()
		{
			fqL = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(aqe));
			wqJ = new Guna2Elipse(fqL);
			vqA = new Panel();
			Bqk = new Guna2HtmlLabel();
			fqG = new Guna2ProgressBar();
			pq5 = new Guna2HtmlLabel();
			pqS = new Guna2CirclePictureBox();
			Iqs = new Guna2ShadowForm(fqL);
			vqA.SuspendLayout();
			((ISupportInitialize)pqS).BeginInit();
			SuspendLayout();
			wqJ.BorderRadius = 10;
			wqJ.TargetControl = this;
			vqA.BackColor = Color.FromArgb(26, 26, 26);
			vqA.Controls.Add(Bqk);
			vqA.Location = new Point(0, 0);
			vqA.Name = "header";
			vqA.Size = new Size(440, 40);
			vqA.TabIndex = 8;
			((Control)Bqk).BackColor = Color.Transparent;
			((Control)Bqk).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)Bqk).ForeColor = Color.FromArgb(41, 230, 124);
			Bqk.IsContextMenuEnabled = false;
			Bqk.IsSelectionEnabled = false;
			((Control)Bqk).Location = new Point(10, 11);
			((Control)Bqk).Name = "headerTitle";
			((Control)Bqk).Size = new Size(28, 18);
			((Control)Bqk).TabIndex = 2;
			((Control)Bqk).Text = "TITLE";
			fqG.FillColor = Color.FromArgb(36, 36, 36);
			((Control)fqG).Location = new Point(0, 117);
			((Control)fqG).Name = "guna2ProgressBar1";
			fqG.ProgressColor = Color.FromArgb(41, 230, 124);
			fqG.ProgressColor2 = Color.FromArgb(41, 230, 124);
			((Control)fqG).Size = new Size(440, 2);
			fqG.Style = ProgressBarStyle.Marquee;
			((Control)fqG).TabIndex = 10;
			((Control)fqG).Text = "guna2ProgressBar1";
			fqG.TextRenderingHint = TextRenderingHint.SystemDefault;
			((Control)pq5).AutoSize = false;
			((Control)pq5).BackColor = Color.Transparent;
			((Control)pq5).Font = new Font("Bahnschrift", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)pq5).ForeColor = Color.White;
			pq5.IsContextMenuEnabled = false;
			pq5.IsSelectionEnabled = false;
			((Control)pq5).Location = new Point(55, 54);
			((Control)pq5).Name = "content";
			((Control)pq5).Size = new Size(371, 47);
			((Control)pq5).TabIndex = 11;
			((Control)pq5).Text = "CONTENT";
			pq5.TextAlignment = ContentAlignment.MiddleLeft;
			((PictureBox)pqS).Image = Resources.info_32px;
			pqS.ImageRotate = 0f;
			((Control)pqS).Location = new Point(17, 63);
			((Control)pqS).Name = "guna2CirclePictureBox1";
			pqS.ShadowDecoration.Mode = ShadowMode.Circle;
			((Control)pqS).Size = new Size(32, 32);
			((PictureBox)pqS).TabIndex = 12;
			((PictureBox)pqS).TabStop = false;
			Iqs.BorderRadius = 10;
			Iqs.TargetForm = this;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(18, 18, 18);
			base.ClientSize = new Size(440, 120);
			base.Controls.Add(pqS);
			base.Controls.Add(pq5);
			base.Controls.Add(fqG);
			base.Controls.Add(vqA);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			MaximumSize = new Size(440, 120);
			base.Name = "PopUp";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.Manual;
			Text = "PopUp";
			base.TopMost = true;
			base.Load += Vq9;
			base.Shown += Mq0;
			vqA.ResumeLayout(false);
			vqA.PerformLayout();
			((ISupportInitialize)pqS).EndInit();
			ResumeLayout(false);
		}
	}
}
