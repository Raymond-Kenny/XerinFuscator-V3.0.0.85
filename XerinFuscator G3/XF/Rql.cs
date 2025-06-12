using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using cfex.Renamer;
using Confuser.Protections.ReferenceProxy;
using Guna.UI2.WinForms; 
using Guna.UI2.WinForms.Enums;
using OLD.Renamer;
using XCore;
using XCore.Context;
using XCore.Embed;
using XCore.Generator;
using XCore.Optimizer;
using XCore.Protections;
using XCore.Utils;
using XCore.XVM.Helper;
using XerinFuscator_G3.Properties;
using XProtections;
using XProtections.AntiCrack.Globals;
using XProtections.CodeEncryption;
using XProtections.ControlFlow;
using XProtections.Mutation;

namespace XF
{
	internal class Rql : Form
	{

		private bool Rix = false;

		private Point yiO;

		private Point Diw;

		private object Pif;

		public static XContext Jid;

		public static ProtectionManager Iie;

		private ControlProj mi9 = new ControlProj();

		public static MethodTreeLoader xi0;

		[CompilerGenerated]
		private static string QiI;

		private static bool jiQ;

		public static int NiF;

		public static int oim;

		private bool DiM = false;

		private Container YiD = null;

		private Guna2Elipse Ii8;

		private Panel rio;

		private Guna2HtmlLabel piB;

		private Guna2HtmlLabel eiv;

		private Panel Wiu;

		private Panel qib;

		private Guna2ShadowForm tiE;

		private Guna2PictureBox YiR;

		private Guna2HtmlLabel siY;

		private Guna2HtmlLabel iiU;

		private Guna2HtmlLabel Pia;

		private Guna2CirclePictureBox Xip;

		private Guna2Button bij;

		private Guna2Button ii3;

		private Guna2VSeparator qiW;

		private Guna2Button yiy;

		private Guna2Button ziL;

		private Guna2Button HiJ;

		private Guna2Button DiA;

		private Panel aik;

		private Guna2HtmlLabel qiG;

		private Guna2TextBox miS;

		private Guna2HtmlLabel gi5;

		private Guna2TextBox nis;

		private Guna2ImageButton oic;

		private Guna2ImageButton Ni7;

		private Panel Til;

		private Panel tiX;

		private Guna2HtmlLabel ciK;

		private Guna2VSeparator ti6;

		private Guna2ImageButton xir;

		private Guna2ToggleSwitch Pin;

		private Panel PiH;

		private Guna2ToggleSwitch KiV;

		private Guna2HtmlLabel Riz;

		private Guna2VSeparator DNh;

		private Panel FNq;

		private Guna2ToggleSwitch wNt;

		private Guna2HtmlLabel tNg;

		private Guna2VSeparator mNi;

		private Panel jNN;

		private Guna2ToggleSwitch pNP;

		private Guna2HtmlLabel cN1;

		private Guna2VSeparator hN4;

		private Panel lN2;

		private Guna2ToggleSwitch qNZ;

		private Guna2HtmlLabel ONC;

		private Guna2VSeparator dNT;

		private Panel sNx;

		private Guna2ImageButton bNO;

		private Guna2ToggleSwitch SNw;

		private Guna2HtmlLabel sNf;

		private Guna2VSeparator ENd;

		private Panel ENe;

		private Guna2ImageButton aN9;

		private Guna2ToggleSwitch NN0;

		private Guna2HtmlLabel BNI;

		private Guna2VSeparator NNQ;

		private Panel RNF;

		private Guna2ToggleSwitch aNm;

		private Guna2HtmlLabel kNM;

		private Guna2VSeparator SND;

		private Panel DN8;

		private Guna2ToggleSwitch ENo;

		private Guna2HtmlLabel UNB;

		private Guna2VSeparator xNv;

		private Panel KNu;

		private Guna2ToggleSwitch nNb;

		private Guna2HtmlLabel PNE;

		private Guna2VSeparator pNR;

		private Panel ANY;

		private Guna2ToggleSwitch lNU;

		private Guna2HtmlLabel yNa;

		private Guna2VSeparator fNp;

		private Panel RNj;

		private Guna2ToggleSwitch TN3;

		private Guna2HtmlLabel VNW;

		private Guna2VSeparator zNy;

		private Guna2ImageButton GNL;

		private Guna2VSeparator qNJ;

		private Panel ONA;

		private Panel GNk;

		private Guna2ToggleSwitch ENG;

		private Guna2HtmlLabel FNS;

		private Guna2VSeparator HN5;

		private Panel ANs;

		private Guna2ToggleSwitch tNc;

		private Guna2HtmlLabel mN7;

		private Guna2VSeparator CNl;

		private Panel WNX;

		private Guna2ToggleSwitch UNK;

		private Guna2HtmlLabel pN6;

		private Guna2VSeparator lNr;

		private Guna2HtmlLabel xNn;

		private Guna2HtmlLabel iNH;

		private Guna2TextBox mNV;

		private Guna2TextBox lNz;

		private Panel KPh;

		private Panel iPq;

		private Guna2ToggleSwitch PPt;

		private Guna2HtmlLabel gPg;

		private Guna2VSeparator bPi;

		private Panel aPN;

		private Guna2ToggleSwitch wPP;

		private Guna2HtmlLabel BP1;

		private Guna2VSeparator CP4;

		private Guna2HtmlLabel BP2;

		private Guna2HtmlLabel EPZ;

		private Panel ePC;

		private Panel OPT;

		private Guna2ToggleSwitch IPx;

		private Guna2HtmlLabel NPO;

		private Guna2VSeparator APw;

		private Panel iPf;

		private Guna2ToggleSwitch KPd;

		private Guna2HtmlLabel lPe;

		private Guna2VSeparator rP9;

		private Guna2HtmlLabel YP0;

		private Panel RPI;

		private Panel xPQ;

		private Guna2ToggleSwitch MPF;

		private Guna2HtmlLabel yPm;

		private Guna2VSeparator rPM;

		private Guna2HtmlLabel XPD;

		private Panel IP8;

		private Panel CPo;

		private Guna2ToggleSwitch NPB;

		private Guna2HtmlLabel qPv;

		private Guna2VSeparator WPu;

		private Guna2HtmlLabel BPb;

		private Guna2ToggleSwitch oPE;

		private Guna2TextBox TPR;

		private Guna2HtmlLabel NPY;

		private CheckedListBox APU;

		private Guna2HtmlLabel vPa;

		private Panel yPp;

		private Guna2TextBox pPj;

		private Guna2HtmlLabel aP3;

		private Panel rPW;

		private Guna2ToggleSwitch OPy;

		private Guna2HtmlLabel aPL;

		private Guna2VSeparator yPJ;

		private Guna2HtmlLabel GPA;

		private Guna2ImageButton sPk;

		private Panel KPG;

		private Guna2HtmlLabel nPS;

		private Guna2Button iP5;

		private Guna2Button kPs;

		private Panel iPc;

		private Guna2HtmlLabel jP7;

		private Guna2HtmlLabel qPl;

		private Guna2HtmlLabel rPX;

		private Guna2HtmlLabel KPK;

		private Guna2HtmlLabel BP6;

		private Guna2HtmlLabel DPr;

		private Guna2ImageButton wPn;

		private Guna2ImageButton vPH;

		private Guna2ImageButton gPV;

		private Panel WPz;

		private Panel p1h;

		private Guna2ToggleSwitch v1q;

		private Guna2HtmlLabel B1t;

		private Guna2VSeparator y1g;

		private Panel u1i;

		private Guna2ToggleSwitch x1N;

		private Guna2HtmlLabel R1P;

		private Guna2VSeparator K11;

		private Guna2HtmlLabel X14;

		private Guna2HtmlLabel I12;

		private Guna2HtmlLabel n1Z;

		private Guna2HtmlLabel D1C;

		private Guna2HtmlLabel K1T;

		private Guna2ImageButton i1x;

		private Guna2TextBox g1O;

		private Guna2TextBox T1w;

		private Guna2TextBox M1f;

		private Guna2ImageButton I1d;

		private Guna2HtmlToolTip f1e;

		private Guna2ImageButton I19;

		private Panel K10;

		private Guna2ToggleSwitch C1I;

		private Guna2HtmlLabel E1Q;

		private Guna2VSeparator H1F;

		private Guna2TextBox N1m;

		private Guna2ImageButton O1M;

		private Panel T1D;

		private ListBox J18;

		private Panel i1o;

		private Guna2ToggleSwitch S1B;

		private Guna2HtmlLabel P1v;

		private Guna2VSeparator N1u;

		private Guna2HtmlLabel B1b;

		private Guna2HtmlLabel t1E;

		private Guna2ImageButton G1R;

		private Guna2ImageButton v1Y;

		private Guna2ImageButton y1U;

		private Guna2ImageButton Q1a;

		private Guna2ImageButton S1p;

		private Guna2VSeparator U1j;

		private Guna2ImageButton J13;

		private Guna2ImageButton h1W;

		private Panel Y1y;

		private Guna2HtmlLabel U1L;

		private Guna2HtmlLabel m1J;

		private Guna2CirclePictureBox f1A;

		private Guna2HtmlLabel S1k;

		private Guna2HtmlLabel U1G;

		private Label c1S;

		private Guna2HtmlLabel A15;

		private Guna2ImageButton D1s;

		private Guna2ImageButton q1c;

		private Panel c17;

		private Guna2ToggleSwitch K1X;

		private Guna2HtmlLabel F1K;

		private Guna2VSeparator W16;

		private Panel w1r;

		private Guna2ToggleSwitch s1n;

		private Guna2HtmlLabel Y1H;

		private Guna2VSeparator q1V;

		private Panel S1z;

		private Guna2ToggleSwitch m4h;

		private Guna2HtmlLabel S4q;

		private Guna2VSeparator W4t;

		private Panel i4g;

		private Guna2ToggleSwitch r4i;

		private Guna2HtmlLabel n4N;

		private Guna2VSeparator F4P;

		private Panel L41;

		private Guna2ToggleSwitch U44;

		private Guna2HtmlLabel S42;

		private Guna2VSeparator S4Z;

		private Panel d4C;

		private Guna2ToggleSwitch m4T;

		private Guna2HtmlLabel J4x;

		private Guna2VSeparator G4O;

		private Panel y4w;

		private Guna2ToggleSwitch d4f;

		private Guna2HtmlLabel B4d;

		private Guna2VSeparator Y4e;

		private Guna2ImageButton H49;

		private Guna2ImageButton k40;

		private Guna2ImageButton o4I;

		private Guna2Button l4Q;

		private Guna2TextBox P4m;

		private Guna2ToggleSwitch O4M;

		private Guna2HtmlLabel p4D;

		private Panel u48;

		private Guna2ToggleSwitch Q4o;

		private Guna2HtmlLabel L4B;

		private Guna2VSeparator T4v;

		private Guna2ImageButton o4u;

		private Guna2VSeparator I4b;

		private Guna2HtmlLabel s4E;

		private Panel b4R;

		private Guna2ToggleSwitch w4Y;

		private Guna2HtmlLabel n4U;

		private Guna2VSeparator m4a;

		private Guna2ToggleSwitch J4j;

		private Guna2HtmlLabel C43;

		private Panel V4W;

		private Guna2ToggleSwitch R4y;

		private Guna2HtmlLabel H4L;

		private Guna2VSeparator i4J;

		private Panel X4A;

		private Guna2ToggleSwitch U4k;

		private Guna2HtmlLabel U4G;

		private Guna2VSeparator H4S;

		private Panel H45;

		private Guna2ToggleSwitch w4s;

		private Guna2HtmlLabel R4c;

		private Guna2VSeparator e47;

		private Guna2ToggleSwitch L4l;

		private Guna2HtmlLabel f4X;

		private Guna2PictureBox p4K;

		private Guna2Button u46;

		private Panel Y4r;

		private Panel l4n;

		private Guna2ToggleSwitch C4H;

		private Guna2HtmlLabel v4V;

		private Guna2VSeparator r4z;

		private Guna2HtmlLabel X2h;

		private Guna2HtmlLabel m2q;

		private Guna2TextBox f2t;

		private ImageList m2g;

		private TreeView Q2i;

		public Rql()
		{
			InitializeComponent();
			DoubleBuffered = true;
		}

		private void uqX(object sender, MouseEventArgs e)
		{
			Rix = true;
			yiO = Cursor.Position;
			Diw = base.Location;
		}

		private void Fq6(object sender, MouseEventArgs e)
		{
			if (Rix)
			{
				base.Opacity = 0.94;
				Cursor = Cursors.Hand;
				Point pt = Point.Subtract(Cursor.Position, new Size(yiO));
				base.Location = Point.Add(Diw, new Size(pt));
			}
		}

		private void eqn(object sender, MouseEventArgs e)
		{
			base.Opacity = 1.0;
			Cursor = Cursors.Default;
			Rix = false;
		}

		private void PqH(object sender, EventArgs e)
		{
			tiE.SetShadowForm(this);
		//	XLogger.ThemeColorR(Convert.ToInt32(((Control)M1f).Text));
		//	XLogger.H2B(Convert.ToInt32(((Control)T1w).Text));
		//	XLogger.i2b(Convert.ToInt32(((Control)g1O).Text));
			aqe.tqF(Convert.ToInt32(((Control)M1f).Text));
			aqe.wqD(Convert.ToInt32(((Control)T1w).Text));
			aqe.BqB(Convert.ToInt32(((Control)g1O).Text));
			f1e.BorderColor = r2X.a2K(Convert.ToInt32(((Control)M1f).Text), Convert.ToInt32(((Control)T1w).Text), Convert.ToInt32(((Control)g1O).Text));
			K1X.Checked = true;
			m4T.Checked = true;
			((Control)A15).Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			((Control)iiU).Text = Dqz().ToUpper();
			K2V.iZq("assembly");
		}

		private async void LqV(object sender, EventArgs e)
		{
			Invalidate();
			await rM.qD(this);
		}

		private string Dqz()
		{
			DateTime dateTime = new DateTime();
			TimeSpan timeSpan = dateTime - DateTime.Now;
			if (timeSpan.Days > 365)
			{
				return Convert.ToString("Proud Lifetime user");
			}
			return Convert.ToString("Expires after: " + timeSpan.Days + " Days");
		}

		private void nth(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void gtq(object sender, EventArgs e)
		{
		}

		private void Xtt(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void otg(object sender, EventArgs e)
		{
			((Control)J13).Visible = false;
			K2V.iZq("colors");
			iPc.BringToFront();
			((Control)qiW).Visible = false;
		}

		private void Cti(object sender, EventArgs e)
		{
			((Control)J13).Visible = false;
			K2V.iZq("assembly");
			K2V.e2z(this, Wiu, aik, (Guna2Button)sender, qiW);
		}

		private void stN(object sender, EventArgs e)
		{
			((Control)J13).Visible = true;
			K2V.iZq("protections");
			K2V.e2z(this, Wiu, Til, (Guna2Button)sender, qiW);
		}

		private void ntP(object sender, EventArgs e)
		{
			((Control)J13).Visible = false;
			K2V.iZq("renamer");
			K2V.e2z(this, Wiu, IP8, (Guna2Button)sender, qiW);
		}

		private void it1(object sender, EventArgs e)
		{
			((Control)J13).Visible = false;
			K2V.iZq("codeenc");
			K2V.e2z(this, Wiu, RPI, (Guna2Button)sender, qiW);
		}

		private void Jt4(object sender, EventArgs e)
		{
			((Control)J13).Visible = false;
			K2V.iZq("codevirt");
			K2V.e2z(this, Wiu, yPp, (Guna2Button)sender, qiW);
		}

		private void Vt2(object sender, EventArgs e)
		{
			((Control)J13).Visible = false;
			K2V.iZq("emped");
			K2V.e2z(this, Wiu, T1D, (Guna2Button)sender, qiW);
		}

		private void HtZ(object sender, EventArgs e)
		{
			((Control)J13).Visible = false;
			K2V.iZq("packer");
			K2V.e2z(this, Wiu, Y4r, (Guna2Button)sender, qiW);
		}

		private void QtC(object sender, EventArgs e)
		{
			Til.BringToFront();
		}

		private void TtT(object sender, EventArgs e)
		{
			Til.BringToFront();
		}

		private void ptx(object sender, EventArgs e)
		{
			Til.BringToFront();
		}

		private void JtO(object sender, EventArgs e)
		{
			ONA.BringToFront();
		}

		private void dtw(object sender, EventArgs e)
		{
			KPh.BringToFront();
		}

		private void Dtf(object sender, EventArgs e)
		{
			ePC.BringToFront();
		}

		private void Htd(object sender, EventArgs e)
		{
			((Control)J13).Visible = false;
			WPz.BringToFront();
			((Control)qiW).Visible = false;
		}

		private void Lte(object sender, EventArgs e)
		{
			((Control)J13).Visible = false;
			KPG.BringToFront();
			((Control)qiW).Visible = false;
		}

		private void Tt9(object sender, EventArgs e)
		{
			Y1y.BringToFront();
			((Control)qiW).Visible = false;
		}

		private void Qt0(object sender, EventArgs e)
		{
			switch (K2V.wZh())
			{
			case "codevirt":
				yPp.BringToFront();
				break;
			case "renamer":
				IP8.BringToFront();
				break;
			case "assembly":
				aik.BringToFront();
				break;
			case "protections":
				((Control)J13).Visible = true;
				Til.BringToFront();
				break;
			case "codeenc":
				RPI.BringToFront();
				break;
			case "emped":
				T1D.BringToFront();
				break;
			case "colors":
				iPc.BringToFront();
				break;
			}
		}

		private void EtI(object sender, EventArgs e)
		{
			switch (K2V.wZh())
			{
			case "codevirt":
				yPp.BringToFront();
				break;
			case "renamer":
				IP8.BringToFront();
				break;
			case "assembly":
				aik.BringToFront();
				break;
			case "protections":
				((Control)J13).Visible = true;
				Til.BringToFront();
				break;
			case "codeenc":
				RPI.BringToFront();
				break;
			case "emped":
				T1D.BringToFront();
				break;
			case "colors":
				iPc.BringToFront();
				break;
			}
		}

		private void ctQ(object sender, EventArgs e)
		{
			switch (K2V.wZh())
			{
			case "codevirt":
				yPp.BringToFront();
				break;
			case "renamer":
				IP8.BringToFront();
				break;
			case "assembly":
				aik.BringToFront();
				break;
			case "protections":
				((Control)J13).Visible = true;
				Til.BringToFront();
				break;
			case "codeenc":
				RPI.BringToFront();
				break;
			case "emped":
				T1D.BringToFront();
				break;
			case "colors":
				iPc.BringToFront();
				break;
			}
		}

		private void LtF(object sender, EventArgs e)
		{
			Random random = new Random();
			int num = random.Next(0, 256);
			((Control)M1f).Text = Convert.ToString(num);
		//	XLogger.d2M(num);
			aqe.tqF(num);
			int num2 = random.Next(0, 256);
			((Control)T1w).Text = Convert.ToString(num2);
		//	XLogger.H2B(num2);
			aqe.wqD(num2);
			int num3 = random.Next(0, 256);
			((Control)g1O).Text = Convert.ToString(num3);
		//	XLogger.i2b(num3);
			aqe.BqB(num3);
			r2X.q26(rio, new Control[4] { U1G, eiv, Pia, qiW }, new Control[12]
			{
				Y1y, T1D, iPc, WPz, aik, Til, IP8, RPI, yPp, ONA,
				ePC, KPh
			}, qiW, r2X.a2K(num, num2, num3));
			f1e.BorderColor = r2X.a2K(num, num2, num3);
		}

		private void Itm(object sender, EventArgs e)
		{
			try
			{
			//	XLogger.d2M(Convert.ToInt32(((Control)M1f).Text));
			//	XLogger.H2B(Convert.ToInt32(((Control)T1w).Text));
			//	XLogger.i2b(Convert.ToInt32(((Control)g1O).Text));
				aqe.tqF(Convert.ToInt32(((Control)M1f).Text));
				aqe.wqD(Convert.ToInt32(((Control)T1w).Text));
				aqe.BqB(Convert.ToInt32(((Control)g1O).Text));
				r2X.q26(rio, new Control[4] { U1G, eiv, Pia, qiW }, new Control[12]
				{
					Y1y, T1D, iPc, WPz, aik, Til, IP8, RPI, yPp, ONA,
					ePC, KPh
				}, qiW, r2X.a2K(Convert.ToInt32(((Control)M1f).Text), Convert.ToInt32(((Control)T1w).Text), Convert.ToInt32(((Control)g1O).Text)));
				f1e.BorderColor = r2X.a2K(Convert.ToInt32(((Control)M1f).Text), Convert.ToInt32(((Control)T1w).Text), Convert.ToInt32(((Control)g1O).Text));
			}
			catch
			{
				a2r.T2H("ERROR", "CHECK RGB VALUE !");
			}
		}

		private void jtM(object sender, EventArgs e)
		{
			ControlProj.R = Convert.ToInt32(((Control)M1f).Text);
		}

		private void jtD(object sender, EventArgs e)
		{
			ControlProj.G = Convert.ToInt32(((Control)T1w).Text);
		}

		private void Ot8(object sender, EventArgs e)
		{
			ControlProj.B = Convert.ToInt32(((Control)g1O).Text);
		}

		private void qto(object sender, DragEventArgs e)
		{
			string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
			string[] array2 = array;
			string[] array3 = array2;
			foreach (string path in array3)
			{
				if (Path.GetExtension(path).Equals(".exe", StringComparison.OrdinalIgnoreCase))
				{
					((Control)miS).Text = path;
					((Control)nis).Text = Path.Combine(Path.GetDirectoryName(((Control)miS).Text) + "\\Secured");
					Jid = new XContext(((Control)miS).Text)
					{
						DirPath = ((Control)nis).Text,
						OutPutPath = ((Control)nis).Text + "\\" + Path.GetFileName(((Control)miS).Text)
					};
					ControlProj.path = ((Control)miS).Text;
					((Control)OPy).Enabled = true;
					Q2i.Nodes.Clear();
					xi0 = new MethodTreeLoader(Q2i);
					xi0.LoadModule(Jid.Module);
				}
				else if (Path.GetExtension(path).Equals(".dll", StringComparison.OrdinalIgnoreCase))
				{
					((Control)miS).Text = path;
					((Control)nis).Text = Path.Combine(Path.GetDirectoryName(((Control)miS).Text) + "\\Secured");
					Jid = new XContext(((Control)miS).Text)
					{
						DirPath = ((Control)nis).Text,
						OutPutPath = ((Control)nis).Text + "\\" + Path.GetFileName(((Control)miS).Text)
					};
					ControlProj.path = ((Control)miS).Text;
					((Control)OPy).Enabled = true;
					Q2i.Nodes.Clear();
					xi0 = new MethodTreeLoader(Q2i);
					xi0.LoadModule(Jid.Module);
				}
				P4m.Clear();
				P4m.AppendText(string.Concat("NAME: ", asmInfo.asmName(((Control)miS).Text) + Environment.NewLine));
				P4m.AppendText(string.Concat("ARCHITECTURE: ", asmInfo.asmArch(((Control)miS).Text) + Environment.NewLine));
				P4m.AppendText(string.Concat("SIZE: ", asmInfo.asmSize(((Control)miS).Text) + Environment.NewLine));
			}
		}

		private void xtB(object sender, DragEventArgs e)
		{
			if (!e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.None;
			}
			else
			{
				e.Effect = DragDropEffects.Copy;
			}
		}

		private void stv(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Load .NET assembly",
				Filter = ".NET Assembly (*.exe)|*.exe|(*.dll)|*.dll",
				Multiselect = false
			};
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			string fileName = openFileDialog.FileName;
			int num = fileName.LastIndexOf(".");
			if (num != -1)
			{
				string text = fileName.Substring(num);
				text = text.ToLower();
				if (text == ".exe")
				{
					((Control)miS).Text = fileName;
					((Control)nis).Text = Path.Combine(Path.GetDirectoryName(((Control)miS).Text) + "\\Secured");
					Jid = new XContext(((Control)miS).Text)
					{
						DirPath = ((Control)nis).Text,
						OutPutPath = ((Control)nis).Text + "\\" + Path.GetFileName(((Control)miS).Text)
					};
					ControlProj.path = ((Control)miS).Text;
					((Control)OPy).Enabled = true;
					Q2i.Nodes.Clear();
					xi0 = new MethodTreeLoader(Q2i);
					xi0.LoadModule(Jid.Module);
				}
				else if (text == ".dll")
				{
					((Control)miS).Text = fileName;
					((Control)nis).Text = Path.Combine(Path.GetDirectoryName(((Control)miS).Text) + "\\Secured");
					Jid = new XContext(((Control)miS).Text)
					{
						DirPath = ((Control)nis).Text,
						OutPutPath = ((Control)nis).Text + "\\" + Path.GetFileName(((Control)miS).Text)
					};
					ControlProj.path = ((Control)miS).Text;
					((Control)OPy).Enabled = true;
					Q2i.Nodes.Clear();
					xi0 = new MethodTreeLoader(Q2i);
					xi0.LoadModule(Jid.Module);
				}
				P4m.Clear();
				P4m.AppendText(string.Concat("NAME: ", asmInfo.asmName(((Control)miS).Text) + Environment.NewLine));
				P4m.AppendText(string.Concat("ARCHITECTURE: ", asmInfo.asmArch(((Control)miS).Text) + Environment.NewLine));
				P4m.AppendText(string.Concat("SIZE: ", asmInfo.asmSize(((Control)miS).Text) + Environment.NewLine));
			}
		}

		private void etu(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
			{
				Description = "Select destination"
			};
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				((Control)nis).Text = folderBrowserDialog.SelectedPath;
			}
		}

		private void rtE(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(l4n, "CONVERTS / PACK .NET ASSEMBLY TO C ASSEMBLY");
		}

		private void CtR(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(L41, "THIS CODE IS DESIGNED TO BYPASS THE ANTIMALWARE SCAN INTERFACE (AMSI) IN WINDOWS");
		}

		private void CtY(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(V4W, "CHECK IF FORM HAS BEEN SKIPPED OR NOT");
		}

		private void ytU(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(b4R, "CONVERTS CTOR TO DYNAMIC TO HIDE ALL CALLS INSIDE TO PREVENT NOP OR REMOVE CALLS");
		}

		private void tta(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(y4w, "PREVENTS EMULATING PROCESS ON KEYAUTH");
		}

		private void ptp(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(c17, "IT CAN BE USEFUL IN SCENARIOS THAT INVOLVE PERFORMANCE-CRITICAL CODE<br>OR UNSAFE CODE, OR INTEROPERABILITY WITH UNMANAGED RESOURCES");
		}

		private void wtj(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(tiX, "ADVANCED ANTI CRACK THAT DETECTS CRACKING PROCESSES WITH MANY OPTIONS");
		}

		private void ut3(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(ANY, "CAN STOP SOME DECOMPILERS FROM DECOMBILING YOUR ASSEMBLY");
		}

		private void otW(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(KNu, "PREVENTS DEBUGGING PROCESSES ON ASSEMBLY");
		}

		private void Rty(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(DN8, "PREVENTS DUMPING PROCESS ON ASSEMBLY FROM MEMORY");
		}

		private void YtL(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(RNF, "PREVENTS ASSEMBLY FROM BEING RAN ON VM");
		}

		private void htJ(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(ENe, "MANGLES CODE INSIDE METHODS TO CONFUSE CODE");
		}

		private void JtA(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(sNx, "MUTATE CODE INSIDE METHODS");
		}

		private void ktk(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(lN2, "ENCODE, COMPRESS & CACHE STRINGS FOR BEST PERFORMANCE");
		}

		private void gtG(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(jNN, "ENCODE & COMPRESS ASSEMBLY RESOURCES");
		}

		private void PtS(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(FNq, "REDIRECT CALLS / REFERENCES INTO METHODS TO CONFUSE IT");
		}

		private void At5(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(PiH, "CONVERTS LOCALS TO FIELD");
		}

		private void Cts(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(PiH, "HASH MODULE TO PREVENT FILE MODIFICATIONS");
		}

		private void ktc(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(rPW, "VIRTUALIZING CODE IN METHOD");
		}

		private void Tt7(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(CPo, "RENAME SYMBOLS { METHODS / FIELDS / ETC }");
		}

		private void atl(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(w1r, "RENAME SYMBOLS { METHODS / FIELDS / ETC } BUT NEEDS TO RESOLVE DEPENDENCIES");
		}

		private void dtK(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(xPQ, "ENCRYPT & STORE DATA IN METHODS");
		}

		private void Dt6(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(S1z, "ENCODING & SECURING INTEGERS INSIDE ASSEMBLY");
		}

		private void Atr(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(i4g, " IF ANY TAMPERING IS DETECTED (E.G., METHOD MODIFICATIONS OR DYNAMIC CALLS FROM UNEXPECTED ASSEMBLIES)<br>IT TERMINATES THE EXECUTION TO PREVENT FURTHER OPERATIONS");
		}

		private void Gtn(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(d4C, "SIMPLIFYING METHOD BRANCHES AND MACROS, THIS CAN LEAD TO BETTER APP PERFORMANCE");
		}

		private void BtH(object sender, MouseEventArgs e)
		{
			f1e.SetToolTip(L41, "OPTIMIZING METHOD MACROS, REMOVING USELESS VALUES & OTHER THINGS, THIS CAN LEAD TO BETTER APP PERFORMANCE");
		}

		private void KtV(object sender, EventArgs e)
		{
			if (C4H.Checked)
			{
				XContext.Pack = true;
				TN3.Checked = false;
			}
			else
			{
				XContext.Pack = false;
			}
		}

		private void Stz(object sender, EventArgs e)
		{
			if (L4l.Checked)
			{
				XContext.AMSI = true;
			}
			else
			{
				XContext.AMSI = false;
			}
		}

		private void mgh(object sender, EventArgs e)
		{
			if (U4k.Checked)
			{
				XContext.ChanegAttr = true;
			}
			else
			{
				XContext.ChanegAttr = false;
			}
		}

		private void Ugq(object sender, EventArgs e)
		{
			if (R4y.Checked)
			{
				Iie.AddProtection(new AntiSkipping());
			}
			else
			{
				Iie.RemoveProtection(new AntiSkipping());
			}
		}

		private void egt(object sender, EventArgs e)
		{
			if (w4Y.Checked)
			{
				cctorHider.isDynamc = true;
			}
			else
			{
				cctorHider.isDynamc = false;
			}
		}

		private void agg(object sender, EventArgs e)
		{
			if (O4M.Checked)
			{
				ReferenceProxyPhase.isDelegate = true;
				OPy.Checked = false;
			}
			else
			{
				ReferenceProxyPhase.isDelegate = false;
			}
		}

		private void wgi(object sender, EventArgs e)
		{
			if (!d4f.Checked)
			{
				if (!d4f.Checked)
				{
					Iie.RemoveProtection(new AntiEmulate());
				}
			}
			else
			{
				Iie.AddProtection(new AntiEmulate());
			}
		}

		private void CgN(object sender, EventArgs e)
		{
			if (K1X.Checked)
			{
				UnverifiableCodeAttributeAttr.attr = true;
			}
			else
			{
				UnverifiableCodeAttributeAttr.attr = false;
			}
		}

		private void AgP(object sender, EventArgs e)
		{
			if (m4T.Checked)
			{
				XContext.Simpilify = true;
			}
			else
			{
				XContext.Simpilify = false;
			}
		}

		private void pg1(object sender, EventArgs e)
		{
			if (!U44.Checked)
			{
				XContext.Optimize = false;
				ControlProj.optimizeAsm = false;
			}
			else
			{
				XContext.Optimize = true;
				ControlProj.optimizeAsm = true;
			}
		}

		private void ug4(object sender, EventArgs e)
		{
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Expected O, but got Unknown
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Expected O, but got Unknown
			if (!Pin.Checked)
			{
				if (!Pin.Checked)
				{
					Iie.RemoveProtection((Protection)new GClass0());
				}
			}
			else
			{
				Iie.AddProtection((Protection)new GClass0());
			}
		}

		private void fg2(object sender, EventArgs e)
		{
			if (!lNU.Checked)
			{
				if (!lNU.Checked)
				{
					XContext.AD = false;
					Iie.RemoveProtection(new AntiDecompiler());
				}
			}
			else
			{
				XContext.AD = true;
				Iie.AddProtection(new AntiDecompiler());
			}
		}

		private void PgZ(object sender, EventArgs e)
		{
			if (!nNb.Checked)
			{
				if (!nNb.Checked)
				{
					Iie.RemoveProtection(new AntiDebug());
				}
			}
			else
			{
				Iie.AddProtection(new AntiDebug());
			}
		}

		private void tgC(object sender, EventArgs e)
		{
			if (!ENo.Checked)
			{
				if (!ENo.Checked)
				{
					Iie.RemoveProtection(new AntiDump());
				}
			}
			else
			{
				Iie.AddProtection(new AntiDump());
			}
		}

		private void ngT(object sender, EventArgs e)
		{
			if (aNm.Checked)
			{
				Iie.AddProtection(new AntiVM());
			}
			else if (!aNm.Checked)
			{
				Iie.RemoveProtection(new AntiVM());
			}
		}

		private void Cgx(object sender, EventArgs e)
		{
			if (NN0.Checked)
			{
				((Control)wPP).Enabled = true;
				((Control)PPt).Enabled = true;
				((Control)Q4o).Enabled = true;
				if (wPP.Checked)
				{
					Iie.AddProtection(new ControlFlow());
				}
				if (PPt.Checked)
				{
					Iie.AddProtection(new ControlFlow());
				}
				if (Q4o.Checked)
				{
					Iie.AddProtection(new ControlFlow());
				}
			}
			else
			{
				Iie.RemoveProtection(new ControlFlow());
				((Control)wPP).Enabled = false;
				((Control)PPt).Enabled = false;
				((Control)Q4o).Enabled = false;
			}
		}

		private void igO(object sender, EventArgs e)
		{
			Iie.RemoveProtection(new ControlFlow());
			if (wPP.Checked)
			{
				PPt.Checked = false;
				Q4o.Checked = false;
				ControlFlow.isPerformance = false;
				ControlFlow.ultraPerformance = false;
				ControlFlow.isStrong = true;
				Iie.AddProtection(new ControlFlow());
			}
			else if (!wPP.Checked)
			{
				Iie.RemoveProtection(new ControlFlow());
			}
		}

		private void ngw(object sender, EventArgs e)
		{
			Iie.RemoveProtection(new ControlFlow());
			if (PPt.Checked)
			{
				wPP.Checked = false;
				Q4o.Checked = false;
				ControlFlow.ultraPerformance = false;
				ControlFlow.isStrong = false;
				ControlFlow.isPerformance = true;
				Iie.AddProtection(new ControlFlow());
			}
			else if (!PPt.Checked)
			{
				Iie.RemoveProtection(new ControlFlow());
			}
		}

		private void Bgf(object sender, EventArgs e)
		{
			Iie.RemoveProtection(new ControlFlow());
			if (!Q4o.Checked)
			{
				Iie.RemoveProtection(new ControlFlow());
				return;
			}
			PPt.Checked = false;
			wPP.Checked = false;
			ControlFlow.isStrong = false;
			ControlFlow.isPerformance = false;
			ControlFlow.ultraPerformance = true;
			Iie.AddProtection(new ControlFlow());
		}

		private void Egd(object sender, EventArgs e)
		{
			if (qNZ.Checked)
			{
				Iie.AddProtection(new eConstants());
			}
			else if (!qNZ.Checked)
			{
				Iie.RemoveProtection(new eConstants());
			}
		}

		private void tge(object sender, EventArgs e)
		{
			if (pNP.Checked)
			{
				Iie.AddProtection(new ResourcesEncoder());
			}
			else if (!pNP.Checked)
			{
				Iie.RemoveProtection(new ResourcesEncoder());
			}
		}

		private void Bg9(object sender, EventArgs e)
		{
			if (!wNt.Checked)
			{
				if (!wNt.Checked)
				{
					Iie.RemoveProtection(new ReferenceProxyPhase());
				}
			}
			else
			{
				Iie.AddProtection(new ReferenceProxyPhase());
			}
		}

		private void Tg0(object sender, EventArgs e)
		{
			if (KiV.Checked)
			{
				Iie.AddProtection(new L2F());
			}
			else if (!KiV.Checked)
			{
				Iie.RemoveProtection(new L2F());
			}
		}

		private void lgI(object sender, EventArgs e)
		{
			if (TN3.Checked)
			{
				OPy.Checked = false;
				C4H.Checked = false;
				Iie.AddProtection(new IntegrityCheck());
			}
			else if (!TN3.Checked)
			{
				Iie.RemoveProtection(new IntegrityCheck());
			}
		}

		private void kgQ(object sender, EventArgs e)
		{
			if (OPy.Checked)
			{
				O4M.Checked = false;
				s1n.Checked = false;
				MPF.Checked = false;
				TN3.Checked = false;
				MethodTreeLoader.IsVirt = true;
			}
			else
			{
				MethodTreeLoader.IsVirt = false;
			}
		}

		private void Ygm(object sender, EventArgs e)
		{
			if (!NPB.Checked)
			{
				if (!NPB.Checked)
				{
					AntiSkipping.isRenamer = false;
					Iie.RemoveProtection(new Renamer());
				}
			}
			else
			{
				AntiSkipping.isRenamer = true;
				s1n.Checked = false;
				APU.Enabled = true;
				((Control)TPR).Enabled = true;
				((Control)oPE).Enabled = true;
				Iie.AddProtection(new Renamer());
			}
		}

		private void ogM(object sender, EventArgs e)
		{
			if (s1n.Checked)
			{
				OPy.Checked = false;
				NPB.Checked = false;
				APU.Enabled = false;
				((Control)TPR).Enabled = false;
				((Control)oPE).Enabled = false;
				Iie.AddProtection(new cfexRenamer());
			}
			else if (!s1n.Checked)
			{
				Iie.RemoveProtection(new cfexRenamer());
			}
		}

		private void HgD(object sender, EventArgs e)
		{
			try
			{
				if (!MPF.Checked)
				{
					XContext.CE = false;
					Iie.RemoveProtection(new CodeEncryption());
				}
				else
				{
					XContext.CE = true;
					OPy.Checked = false;
					Iie.AddProtection(new CodeEncryption());
				}
			}
			catch
			{
			}
		}

		private void lg8(object sender, EventArgs e)
		{
			if (!m4h.Checked)
			{
				if (!m4h.Checked)
				{
					Iie.RemoveProtection(new IntEncoding());
				}
			}
			else
			{
				Iie.AddProtection(new IntEncoding());
			}
		}

		private void Xgo(object sender, EventArgs e)
		{
			if (!SNw.Checked)
			{
				Iie.RemoveProtection(new SecondMutationStage());
				Iie.RemoveProtection(new ThirdMutationStage());
				Iie.RemoveProtection(new MutationV2());
				((Control)KPd).Enabled = false;
				((Control)IPx).Enabled = false;
				return;
			}
			((Control)KPd).Enabled = true;
			((Control)IPx).Enabled = true;
			((Control)w4s).Enabled = true;
			if (KPd.Checked)
			{
				Iie.AddProtection(new ThirdMutationStage());
			}
			if (IPx.Checked)
			{
				Iie.AddProtection(new SecondMutationStage());
			}
		}

		private void dgB(object sender, EventArgs e)
		{
			Iie.RemoveProtection(new SecondMutationStage());
			Iie.RemoveProtection(new ThirdMutationStage());
			Iie.RemoveProtection(new MutationV2());
			if (!w4s.Checked)
			{
				if (!KPd.Checked)
				{
					Iie.RemoveProtection(new MutationV2());
				}
			}
			else
			{
				IPx.Checked = false;
				KPd.Checked = false;
				Iie.AddProtection(new MutationV2());
			}
		}

		private void bgv(object sender, EventArgs e)
		{
			Iie.RemoveProtection(new SecondMutationStage());
			Iie.RemoveProtection(new ThirdMutationStage());
			Iie.RemoveProtection(new MutationV2());
			if (!KPd.Checked)
			{
				if (!KPd.Checked)
				{
					Iie.RemoveProtection(new ThirdMutationStage());
				}
			}
			else
			{
				IPx.Checked = false;
				w4s.Checked = false;
				Iie.AddProtection(new ThirdMutationStage());
			}
		}

		private void Rgu(object sender, EventArgs e)
		{
			Iie.RemoveProtection(new SecondMutationStage());
			Iie.RemoveProtection(new ThirdMutationStage());
			Iie.RemoveProtection(new MutationV2());
			if (!IPx.Checked)
			{
				if (!IPx.Checked)
				{
					Iie.RemoveProtection(new SecondMutationStage());
				}
			}
			else
			{
				KPd.Checked = false;
				w4s.Checked = false;
				Iie.AddProtection(new SecondMutationStage());
			}
		}

		private void Ygb(object sender, EventArgs e)
		{
			if (S1B.Checked)
			{
				Embeder.isEmbed = true;
				Iie.AddProtection(new Embeder());
			}
			else
			{
				Embeder.isEmbed = false;
				Iie.RemoveProtection(new Embeder());
			}
		}

		private void igE(object sender, EventArgs e)
		{
			if (r4i.Checked)
			{
				Iie.AddProtection(new AntiTamper());
			}
			else if (!r4i.Checked)
			{
				Iie.RemoveProtection(new AntiTamper());
			}
		}

		private void EgR(object sender, EventArgs e)
		{
			Process.Start(Path.Combine(Directory.GetCurrentDirectory(), "Config", "Processes list.ini"));
		}

		private void WgY(object sender, EventArgs e)
		{
			if (UNK.Checked)
			{
				Global.Normal = true;
			}
			else
			{
				Global.Normal = false;
			}
		}

		private void ggU(object sender, EventArgs e)
		{
			if (!tNc.Checked)
			{
				Global.Silent = false;
				ControlProj.silentMsg = false;
			}
			else
			{
				Global.Silent = true;
				ControlProj.silentMsg = true;
			}
		}

		private void Gga(object sender, EventArgs e)
		{
			if (ENG.Checked)
			{
				Global.Exclude = true;
			}
			else
			{
				Global.Exclude = false;
			}
		}

		private void Qgp(object sender, EventArgs e)
		{
			if (C1I.Checked)
			{
				Global.Bsod = true;
				ControlProj.bsod = true;
			}
			else
			{
				Global.Bsod = false;
				ControlProj.bsod = false;
			}
		}

		private void Vgj(object sender, EventArgs e)
		{
			Global.webhookLink = ((Control)lNz).Text.e_e();
			ControlProj.webhook = ((Control)lNz).Text.e_e();
		}

		private void ig3(object sender, EventArgs e)
		{
			Global.excludeString = ((Control)mNV).Text;
			ControlProj.exclude = ((Control)mNV).Text;
		}

		private void GgW(object sender, EventArgs e)
		{
			Global.customMessage = ((Control)N1m).Text;
			ControlProj.customMsg = ((Control)N1m).Text;
		}

		private void Tgy(object sender, DragEventArgs e)
		{
			string[] array = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			string[] array2 = array;
			string[] array3 = array2;
			foreach (string text in array3)
			{
				if (!Path.GetExtension(text).Equals(".dll", StringComparison.OrdinalIgnoreCase) || !XCore.Utils.Utils.isAssemblyDotNet(text))
				{
					a2r.T2H("ERROR", "THIS LIBRARY IS NOT .NET OR NOT DLL!");
				}
				else if (!J18.Items.Contains(text))
				{
					J18.Items.Add(text);
					Embeder.dlls.Add(text);
				}
				else
				{
					a2r.T2H("ERROR", "THIS LIBRARY IS ATTACHED BEFORE !");
				}
			}
		}

		private void CgL(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}

		private void xgJ(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				FileName = string.Empty,
				Title = "Select assembly to embed",
				Filter = "Assembly (*.dll)|*.dll",
				CheckFileExists = true,
				Multiselect = true
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string[] fileNames = openFileDialog.FileNames;
				string[] array = fileNames;
				foreach (string text in array)
				{
					try
					{
						Stream stream;
						if ((stream = openFileDialog.OpenFile()) == null)
						{
							continue;
						}
						using (stream)
						{
							if (text.Length <= 0 || !XCore.Utils.Utils.isAssemblyDotNet(text))
							{
								a2r.T2H("ERROR", "THIS LIBRARY IS NOT .NET !");
							}
							else if (!J18.Items.Contains(text))
							{
								J18.Items.Add(text);
								Embeder.dlls.Add(text);
							}
							else
							{
								a2r.T2H("ERROR", "THIS LIBRARY IS ATTACHED BEFORE !");
							}
						}
					}
					catch
					{
					}
				}
			}
			J18.Focus();
		}

		private void mgA(object sender, EventArgs e)
		{
			try
			{
				Embeder.dlls.Remove(J18.SelectedItem.ToString());
				J18.Items.Remove(J18.SelectedItem);
			}
			catch
			{
			}
		}

		private void Ygk(object sender, EventArgs e)
		{
			J18.Items.Clear();
			Embeder.dlls.Clear();
		}

		[SpecialName]
		[CompilerGenerated]
		public static string si2()
		{
			return QiI;
		}

		[SpecialName]
		[CompilerGenerated]
		public static void JiZ(string P_0)
		{
			QiI = P_0;
		}

		private void JgG(object sender, EventArgs e)
		{
			JiZ(((Control)f2t).Text);
		}

		private void bgS(TreeNode P_0)
		{
            if (P_0.Tag is MethodTreeLoader.NodeInfo nodeInfo && (nodeInfo.Type == MethodTreeLoader.NodeType.Method || nodeInfo.Type == MethodTreeLoader.NodeType.Type))
            {
                if (nodeInfo.Type == MethodTreeLoader.NodeType.Method)
                {
                    P_0.ForeColor = (P_0.Checked ? MethodTreeLoader.Colors.SelectedMethod : MethodTreeLoader.GetMethodColor(nodeInfo.Method));
                }
                P_0.ImageIndex = (P_0.Checked ? 1 : 0);
                P_0.SelectedImageIndex = P_0.ImageIndex;
            }
        }

        private void Lg5(object P_0, TreeNodeMouseClickEventArgs P_1)
        {
            Q2i.BeginUpdate();
            P_1.Node.Checked = !P_1.Node.Checked;
            if (P_1.Node.Tag is MethodTreeLoader.NodeInfo nodeInfo)
            {
                if (nodeInfo.Type != MethodTreeLoader.NodeType.Method)
                {
                    if (nodeInfo.Type == MethodTreeLoader.NodeType.Type)
                    {
                        bgS(P_1.Node);
                        MethodTreeLoader.UpdateChildNodes(P_1.Node, P_1.Node.Checked);
                    }
                }
                else
                {
                    bgS(P_1.Node);
                }
            }
            Q2i.EndUpdate();
        }

        private void lgs(object P_0, TreeViewEventArgs P_1)
        {
            if (P_1.Action == TreeViewAction.Unknown)
            {
                return;
            }
            Q2i.BeginUpdate();
            TreeNode node = P_1.Node;
            if (node.Tag is MethodTreeLoader.NodeInfo nodeInfo)
            {
                if (nodeInfo.Type == MethodTreeLoader.NodeType.Type)
                {
                    bgS(node);
                    MethodTreeLoader.UpdateChildNodes(node, node.Checked);
                }
                else if (nodeInfo.Type == MethodTreeLoader.NodeType.Method)
                {
                    bgS(node);
                }
                if (nodeInfo.Type == MethodTreeLoader.NodeType.Method)
                {
                    fgc(node.Parent);
                }
            }
            Q2i.EndUpdate();
        }

		private void fgc(TreeNode P_0)
		{
			if (P_0 == null || !(P_0.Tag is MethodTreeLoader.NodeInfo nodeInfo) || nodeInfo.Type != MethodTreeLoader.NodeType.Type)
			{
				return;
			}
			bool flag = true;
			foreach (TreeNode node in P_0.Nodes)
			{
				if (!node.Checked)
				{
					flag = false;
				}
			}
			P_0.Checked = flag;
			bgS(P_0);
		}

        private void tg7(TreeNode P_0, HashSet<string> P_1)
		{
			foreach (TreeNode node in P_0.Nodes)
			{
				if (P_1.Contains(node.Text))
				{
					node.ImageIndex = 1;
					node.SelectedImageIndex = 1;
				}
				tg7(node, P_1);
			}
		}

		private bool Kgl(IEnumerable P_0, string P_1)
		{
			foreach (TreeNode item in P_0)
			{
				if (item.Text.ToUpper().Contains(P_1))
				{
					Q2i.SelectedNode = item;
				}
				if (Kgl(item.Nodes, P_1))
				{
					return true;
				}
			}
			return false;
		}

		private void ogX(object sender, EventArgs e)
		{
			Q2i.Focus();
			string text = ((Control)pPj).Text.Trim().ToUpper();
			if (text != "" && Q2i.Nodes.Count > 0 && Kgl(Q2i.Nodes, text))
			{
				Q2i.SelectedNode.Expand();
				Q2i.Focus();
				Q2i.SelectedNode = Q2i.SelectedNode.NextVisibleNode;
			}
		}

		public static List<string> vgK(TreeView P_0)
		{
			List<string> list = new List<string>();
			foreach (TreeNode node in P_0.Nodes)
			{
				Fg6(node, list);
			}
			return list;
		}

		private static void Fg6(TreeNode P_0, List<string> P_1)
		{
			P_1.Add(P_0.Text);
			foreach (TreeNode node in P_0.Nodes)
			{
				Fg6(node, P_1);
			}
		}

		private void Ngr(object sender, EventArgs e)
		{
			if (jiQ)
			{
				jiQ = false;
				q1c.Image = Resources.uncheck_all_18px;
				xi0.All = false;
			}
			else
			{
				jiQ = true;
				q1c.Image = Resources.check_all_18px;
				xi0.All = true;
			}
		}

		private void Jgn(object sender, ItemCheckEventArgs e)
		{
			switch (e.Index)
			{
			case 0:
				Globals.events = e.NewValue == CheckState.Checked;
				ControlProj.rChecked[0] = true;
				break;
			case 1:
				Globals.flds = e.NewValue == CheckState.Checked;
				ControlProj.rChecked[1] = true;
				break;
			case 2:
				Globals.methods = e.NewValue == CheckState.Checked;
				ControlProj.rChecked[2] = true;
				break;
			case 3:
				Globals.parameters = e.NewValue == CheckState.Checked;
				ControlProj.rChecked[3] = true;
				break;
			case 4:
				Globals.props = e.NewValue == CheckState.Checked;
				ControlProj.rChecked[4] = true;
				break;
			case 5:
				Globals.types = e.NewValue == CheckState.Checked;
				ControlProj.rChecked[5] = true;
				break;
			}
		}

		private void TgH(object sender, EventArgs e)
		{
			if (oPE.Checked)
			{
				ControlProj.CustomRN = true;
				GGeneration.CustomRN = true;
			}
			else
			{
				ControlProj.CustomRN = false;
				GGeneration.CustomRN = false;
			}
		}

		private void ugV(object sender, EventArgs e)
		{
			ControlProj.Custom = ((Control)TPR).Text;
			GGeneration.Custom = ((Control)TPR).Text;
		}

		private void igz(object sender, EventArgs e)
		{
			if (!J4j.Checked)
			{
				((Control)nis).Enabled = true;
				XContext.sameLocation = false;
			}
			else
			{
				((Control)nis).Enabled = false;
				XContext.sameLocation = true;
			}
		}

		private void mih(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				FileName = string.Empty,
				Title = "Open Xerin's Project File",
				Filter = "Project File(*.xml)|*.xml",
				CheckFileExists = true
			};
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			byte[] buffer = File.ReadAllBytes(openFileDialog.FileName);
			using (MemoryStream memoryStream_ = new MemoryStream(buffer))
			{
				mi9.Load(memoryStream_);
			}
			if (ControlProj.path != string.Empty)
			{
				((Control)miS).Text = ControlProj.path;
			}
			try
			{
				if (((Control)miS).Text.EndsWith(".exe"))
				{
					((Control)nis).Text = Path.Combine(Path.GetDirectoryName(((Control)miS).Text) + "\\Secured");
					Jid = new XContext(((Control)miS).Text)
					{
						DirPath = ((Control)nis).Text,
						OutPutPath = ((Control)nis).Text + "\\" + Path.GetFileName(((Control)miS).Text)
					};
					ControlProj.path = ((Control)miS).Text;
					((Control)OPy).Enabled = true;
					xi0 = new MethodTreeLoader(Q2i);
					xi0.LoadModule(Jid.Module);
				}
				else if (((Control)miS).Text.EndsWith(".dll"))
				{
					((Control)nis).Text = Path.Combine(Path.GetDirectoryName(((Control)miS).Text) + "\\Secured");
					Jid = new XContext(((Control)miS).Text)
					{
						DirPath = ((Control)nis).Text,
						OutPutPath = ((Control)nis).Text + "\\" + Path.GetFileName(((Control)miS).Text)
					};
					OPy.Checked = false;
					((Control)OPy).Enabled = false;
					ControlProj.path = ((Control)miS).Text;
				}
				P4m.AppendText(string.Concat("NAME: ", asmInfo.asmName(((Control)miS).Text) + Environment.NewLine));
				P4m.AppendText(string.Concat("ARCHITECTURE: ", asmInfo.asmArch(((Control)miS).Text) + Environment.NewLine));
				P4m.AppendText(string.Concat("SIZE: ", asmInfo.asmSize(((Control)miS).Text) + Environment.NewLine));
			}
			catch
			{
			}
			if (ControlProj.optimizeAsm)
			{
				U44.Checked = true;
			}
			if (ControlProj.sameloc)
			{
				J4j.Checked = true;
			}
			((Control)M1f).Text = Convert.ToString(ControlProj.R);
			((Control)T1w).Text = Convert.ToString(ControlProj.G);
			((Control)g1O).Text = Convert.ToString(ControlProj.B);
		//	XLogger.ThemeColorR(Convert.ToInt32(((Control)M1f).Text));
		//	XLogger.H2B(Convert.ToInt32(((Control)T1w).Text));
		//	XLogger.i2b(Convert.ToInt32(((Control)g1O).Text));
			aqe.tqF(Convert.ToInt32(((Control)M1f).Text));
			aqe.wqD(Convert.ToInt32(((Control)T1w).Text));
			aqe.BqB(Convert.ToInt32(((Control)g1O).Text));
			r2X.q26(rio, new Control[3] { eiv, Pia, qiW }, new Control[10] { iPc, WPz, aik, Til, IP8, RPI, yPp, ONA, ePC, KPh }, qiW, r2X.a2K(Convert.ToInt32(((Control)M1f).Text), Convert.ToInt32(((Control)T1w).Text), Convert.ToInt32(((Control)g1O).Text)));
			f1e.BorderColor = r2X.a2K(Convert.ToInt32(((Control)M1f).Text), Convert.ToInt32(((Control)T1w).Text), Convert.ToInt32(((Control)g1O).Text));
			if (ControlProj.dynamicctor)
			{
				w4Y.Checked = true;
			}
			if (ControlProj.delegatesref)
			{
				O4M.Checked = true;
			}
			if (ControlProj.integrityCheck)
			{
				TN3.Checked = true;
			}
			if (ControlProj.cfexrenamer)
			{
				s1n.Checked = true;
			}
			if (ControlProj.renamer)
			{
				NPB.Checked = true;
			}
			if (ControlProj.antiCrack)
			{
				Pin.Checked = true;
			}
			if (ControlProj.antiDebug)
			{
				nNb.Checked = true;
			}
			if (ControlProj.antiDecombiler)
			{
				lNU.Checked = true;
			}
			if (ControlProj.antiDump)
			{
				ENo.Checked = true;
			}
			if (ControlProj.antiVM)
			{
				aNm.Checked = true;
			}
			if (ControlProj.antiemulate)
			{
				d4f.Checked = true;
			}
			if (ControlProj.antiskip)
			{
				R4y.Checked = true;
			}
			if (ControlProj.antitamper)
			{
				r4i.Checked = true;
			}
			if (ControlProj.stringsEncoder)
			{
				qNZ.Checked = true;
			}
			if (ControlProj.intencoding)
			{
				m4h.Checked = true;
			}
			if (ControlProj.aggressivecodemutation2)
			{
				SNw.Checked = true;
				w4s.Checked = true;
			}
			if (ControlProj.aggressivecodemutation)
			{
				SNw.Checked = true;
				KPd.Checked = true;
			}
			if (ControlProj.balancedcodemutation)
			{
				SNw.Checked = true;
				IPx.Checked = true;
			}
			if (ControlProj.controlFlow)
			{
				NN0.Checked = true;
			}
			if (ControlProj.cflowUltraPerformance)
			{
				ControlFlow.ultraPerformance = true;
				ControlFlow.isPerformance = false;
				ControlFlow.isStrong = false;
				NN0.Checked = true;
				Q4o.Checked = true;
			}
			if (ControlProj.cflowPerformance)
			{
				ControlFlow.isPerformance = true;
				ControlFlow.isStrong = false;
				ControlFlow.ultraPerformance = false;
				NN0.Checked = true;
				PPt.Checked = true;
			}
			if (ControlProj.cflowStrong)
			{
				ControlFlow.isStrong = true;
				ControlFlow.isPerformance = false;
				ControlFlow.ultraPerformance = false;
				NN0.Checked = true;
				wPP.Checked = true;
			}
			if (ControlProj.localtofield)
			{
				KiV.Checked = true;
			}
			if (ControlProj.integrityCheck)
			{
				TN3.Checked = true;
			}
			if (ControlProj.refProxy)
			{
				wNt.Checked = true;
			}
			if (ControlProj.resourcesEncoder)
			{
				pNP.Checked = true;
			}
			if (ControlProj.codeEncryption)
			{
				MPF.Checked = true;
			}
			if (ControlProj.codeVirt)
			{
				OPy.Checked = true;
			}
			if (ControlProj.webhook != string.Empty)
			{
				((Control)lNz).Text = Encoding.UTF8.GetString(Convert.FromBase64String(ControlProj.webhook));
			}
			if (ControlProj.exclude != string.Empty)
			{
				((Control)mNV).Text = ControlProj.exclude;
			}
			if (ControlProj.customMsg != string.Empty)
			{
				((Control)N1m).Text = ControlProj.customMsg;
			}
			if (ControlProj.excludep)
			{
				if (string.IsNullOrEmpty(ControlProj.exclude) || string.IsNullOrWhiteSpace(ControlProj.exclude))
				{
					ENG.Checked = false;
				}
				else
				{
					ENG.Checked = true;
				}
			}
			if (ControlProj.normal)
			{
				UNK.Checked = true;
			}
			if (ControlProj.silentMsg)
			{
				tNc.Checked = true;
			}
			if (ControlProj.bsod)
			{
				C1I.Checked = true;
			}
			if (ControlProj.CustomRN)
			{
				oPE.Checked = true;
				((Control)TPR).Text = ControlProj.Custom;
			}
			if (ControlProj.RenameEvents)
			{
				APU.SetItemChecked(0, true);
			}
			if (ControlProj.RenameFields)
			{
				APU.SetItemChecked(1, true);
			}
			if (ControlProj.RenameMethods)
			{
				APU.SetItemChecked(2, true);
			}
			if (ControlProj.RenameParameters)
			{
				APU.SetItemChecked(3, true);
			}
			if (ControlProj.RenameProperties)
			{
				APU.SetItemChecked(4, true);
			}
			if (ControlProj.RenameTypes)
			{
				APU.SetItemChecked(5, true);
			}
			if (ControlProj.embeder)
			{
				S1B.Checked = true;
			}
			foreach (string item in ControlProj.dlls2)
			{
				J18.Items.Add(item);
				Embeder.dlls.Add(item);
			}
		}

		private void ciq(object sender, EventArgs e)
		{
			MemoryStream memoryStream_ = new MemoryStream();
			mi9.Save(memoryStream_);
		}

		private void lit(object sender, EventArgs e)
		{
			if (Jid == null)
			{
				Jid = new XContext(miS.Text)
				{
					DirPath = miS.Text,
					OutPutPath = miS.Text + "\\" + Path.GetFileName(miS.Text)
				};
				ControlProj.path = miS.Text;
			}
			new XLogger().Show();
		}

		private void Kig(object sender, EventArgs e)
		{
			if (x1N.Checked)
			{
			//	XLogger.h2f(true);
			}
			else
			{
			//	XLogger.h2f(false);
			}
		}

		private void Mii(object sender, EventArgs e)
		{
			if (!v1q.Checked)
			{
			//	XLogger.t29(false);
			}
			else
			{
			//	XLogger.t29(true);
			}
		}

		private IEnumerable<Control> tiN(Control P_0)
		{
			IEnumerable<Control> enumerable = P_0.Controls.Cast<Control>();
			return enumerable.SelectMany((Control control) => tiN(control)).Concat(enumerable);
		}

		private void ViP(object sender, EventArgs e)
		{
			if (DiM)
			{
				DiM = false;
				J13.Image = Resources.uncheck_all_18px;
				for (int i = 0; i < APU.Items.Count; i++)
				{
					APU.SetItemChecked(i, false);
				}
				Guna2ToggleSwitch[] array = tiN(Til).OfType<Guna2ToggleSwitch>().ToArray();
				for (int k = 0; k < array.Length; k++)
				{
					array[k].Checked = false;
				}
				PPt.Checked = false;
				Q4o.Checked = false;
				wPP.Checked = false;
				IPx.Checked = false;
				KPd.Checked = false;
				w4s.Checked = false;
				m4h.Checked = false;
				UNK.Checked = false;
				s1n.Checked = false;
				NPB.Checked = false;
				MPF.Checked = false;
				S1B.Checked = false;
				OPy.Checked = false;
				O4M.Checked = false;
				C4H.Checked = false;
			}
			else
			{
				DiM = true;
				J13.Image = Resources.check_all_18px;
				for (int l = 0; l < APU.Items.Count; l++)
				{
					APU.SetItemChecked(l, true);
				}
				Guna2ToggleSwitch[] array2 = tiN(Til).OfType<Guna2ToggleSwitch>().ToArray();
				for (int m = 0; m < array2.Length; m++)
				{
					array2[m].Checked = true;
				}
				wPP.Checked = true;
				w4s.Checked = true;
				m4h.Checked = true;
				UNK.Checked = true;
				s1n.Checked = true;
				NPB.Checked = true;
				MPF.Checked = true;
				S1B.Checked = false;
				OPy.Checked = false;
				O4M.Checked = true;
				C4H.Checked = false;
			}
		}

		protected override void Dispose(bool P_0)
		{
			if (P_0 && YiD != null)
			{
				((IDisposable)YiD).Dispose();
			}
			base.Dispose(P_0);
		}

		private void InitializeComponent()
		{
			YiD = new Container();
            System.ComponentModel.ComponentResourceManager componentResourceManager =
            new System.ComponentModel.ComponentResourceManager(typeof(Rql));
			Ii8 = new Guna2Elipse(YiD);
			rio = new Panel();
			o4u = new Guna2ImageButton();
			I4b = new Guna2VSeparator();
			H49 = new Guna2ImageButton();
			k40 = new Guna2ImageButton();
			o4I = new Guna2ImageButton();
			h1W = new Guna2ImageButton();
			S1p = new Guna2ImageButton();
			U1j = new Guna2VSeparator();
			O1M = new Guna2ImageButton();
			GNL = new Guna2ImageButton();
			qNJ = new Guna2VSeparator();
			piB = new Guna2HtmlLabel();
			eiv = new Guna2HtmlLabel();
			tiE = new Guna2ShadowForm(YiD);
			Wiu = new Panel();
			u46 = new Guna2Button();
			J13 = new Guna2ImageButton();
			DiA = new Guna2Button();
			HiJ = new Guna2Button();
			ziL = new Guna2Button();
			yiy = new Guna2Button();
			ii3 = new Guna2Button();
			qiW = new Guna2VSeparator();
			bij = new Guna2Button();
			YiR = new Guna2PictureBox();
			siY = new Guna2HtmlLabel();
			qib = new Panel();
			iiU = new Guna2HtmlLabel();
			Pia = new Guna2HtmlLabel();
			Xip = new Guna2CirclePictureBox();
			aik = new Panel();
			X4A = new Panel();
			U4k = new Guna2ToggleSwitch();
			U4G = new Guna2HtmlLabel();
			H4S = new Guna2VSeparator();
			J4j = new Guna2ToggleSwitch();
			C43 = new Guna2HtmlLabel();
			s4E = new Guna2HtmlLabel();
			b4R = new Panel();
			w4Y = new Guna2ToggleSwitch();
			n4U = new Guna2HtmlLabel();
			m4a = new Guna2VSeparator();
			P4m = new Guna2TextBox();
			L41 = new Panel();
			p4K = new Guna2PictureBox();
			L4l = new Guna2ToggleSwitch();
			f4X = new Guna2HtmlLabel();
			S4Z = new Guna2VSeparator();
			d4C = new Panel();
			U44 = new Guna2ToggleSwitch();
			m4T = new Guna2ToggleSwitch();
			S42 = new Guna2HtmlLabel();
			J4x = new Guna2HtmlLabel();
			G4O = new Guna2VSeparator();
			c17 = new Panel();
			K1X = new Guna2ToggleSwitch();
			F1K = new Guna2HtmlLabel();
			W16 = new Guna2VSeparator();
			oic = new Guna2ImageButton();
			Ni7 = new Guna2ImageButton();
			gi5 = new Guna2HtmlLabel();
			nis = new Guna2TextBox();
			qiG = new Guna2HtmlLabel();
			miS = new Guna2TextBox();
			Til = new Panel();
			V4W = new Panel();
			R4y = new Guna2ToggleSwitch();
			H4L = new Guna2HtmlLabel();
			i4J = new Guna2VSeparator();
			y4w = new Panel();
			d4f = new Guna2ToggleSwitch();
			B4d = new Guna2HtmlLabel();
			Y4e = new Guna2VSeparator();
			i4g = new Panel();
			r4i = new Guna2ToggleSwitch();
			n4N = new Guna2HtmlLabel();
			F4P = new Guna2VSeparator();
			S1z = new Panel();
			m4h = new Guna2ToggleSwitch();
			S4q = new Guna2HtmlLabel();
			W4t = new Guna2VSeparator();
			RNj = new Panel();
			TN3 = new Guna2ToggleSwitch();
			VNW = new Guna2HtmlLabel();
			zNy = new Guna2VSeparator();
			PiH = new Panel();
			KiV = new Guna2ToggleSwitch();
			Riz = new Guna2HtmlLabel();
			DNh = new Guna2VSeparator();
			FNq = new Panel();
			O4M = new Guna2ToggleSwitch();
			p4D = new Guna2HtmlLabel();
			wNt = new Guna2ToggleSwitch();
			tNg = new Guna2HtmlLabel();
			mNi = new Guna2VSeparator();
			jNN = new Panel();
			pNP = new Guna2ToggleSwitch();
			cN1 = new Guna2HtmlLabel();
			hN4 = new Guna2VSeparator();
			lN2 = new Panel();
			qNZ = new Guna2ToggleSwitch();
			ONC = new Guna2HtmlLabel();
			dNT = new Guna2VSeparator();
			sNx = new Panel();
			bNO = new Guna2ImageButton();
			SNw = new Guna2ToggleSwitch();
			sNf = new Guna2HtmlLabel();
			ENd = new Guna2VSeparator();
			ENe = new Panel();
			aN9 = new Guna2ImageButton();
			NN0 = new Guna2ToggleSwitch();
			BNI = new Guna2HtmlLabel();
			NNQ = new Guna2VSeparator();
			RNF = new Panel();
			aNm = new Guna2ToggleSwitch();
			kNM = new Guna2HtmlLabel();
			SND = new Guna2VSeparator();
			DN8 = new Panel();
			ENo = new Guna2ToggleSwitch();
			UNB = new Guna2HtmlLabel();
			xNv = new Guna2VSeparator();
			KNu = new Panel();
			nNb = new Guna2ToggleSwitch();
			PNE = new Guna2HtmlLabel();
			pNR = new Guna2VSeparator();
			ANY = new Panel();
			lNU = new Guna2ToggleSwitch();
			yNa = new Guna2HtmlLabel();
			fNp = new Guna2VSeparator();
			tiX = new Panel();
			xir = new Guna2ImageButton();
			Pin = new Guna2ToggleSwitch();
			ciK = new Guna2HtmlLabel();
			ti6 = new Guna2VSeparator();
			ONA = new Panel();
			l4Q = new Guna2Button();
			N1m = new Guna2TextBox();
			K10 = new Panel();
			C1I = new Guna2ToggleSwitch();
			E1Q = new Guna2HtmlLabel();
			H1F = new Guna2VSeparator();
			gPV = new Guna2ImageButton();
			mNV = new Guna2TextBox();
			lNz = new Guna2TextBox();
			GNk = new Panel();
			ENG = new Guna2ToggleSwitch();
			FNS = new Guna2HtmlLabel();
			HN5 = new Guna2VSeparator();
			ANs = new Panel();
			tNc = new Guna2ToggleSwitch();
			mN7 = new Guna2HtmlLabel();
			CNl = new Guna2VSeparator();
			WNX = new Panel();
			UNK = new Guna2ToggleSwitch();
			pN6 = new Guna2HtmlLabel();
			lNr = new Guna2VSeparator();
			xNn = new Guna2HtmlLabel();
			iNH = new Guna2HtmlLabel();
			KPh = new Panel();
			u48 = new Panel();
			Q4o = new Guna2ToggleSwitch();
			L4B = new Guna2HtmlLabel();
			T4v = new Guna2VSeparator();
			vPH = new Guna2ImageButton();
			iPq = new Panel();
			PPt = new Guna2ToggleSwitch();
			gPg = new Guna2HtmlLabel();
			bPi = new Guna2VSeparator();
			aPN = new Panel();
			wPP = new Guna2ToggleSwitch();
			BP1 = new Guna2HtmlLabel();
			CP4 = new Guna2VSeparator();
			BP2 = new Guna2HtmlLabel();
			EPZ = new Guna2HtmlLabel();
			ePC = new Panel();
			H45 = new Panel();
			w4s = new Guna2ToggleSwitch();
			R4c = new Guna2HtmlLabel();
			e47 = new Guna2VSeparator();
			wPn = new Guna2ImageButton();
			OPT = new Panel();
			IPx = new Guna2ToggleSwitch();
			NPO = new Guna2HtmlLabel();
			APw = new Guna2VSeparator();
			iPf = new Panel();
			KPd = new Guna2ToggleSwitch();
			lPe = new Guna2HtmlLabel();
			rP9 = new Guna2VSeparator();
			DPr = new Guna2HtmlLabel();
			YP0 = new Guna2HtmlLabel();
			RPI = new Panel();
			xPQ = new Panel();
			MPF = new Guna2ToggleSwitch();
			yPm = new Guna2HtmlLabel();
			rPM = new Guna2VSeparator();
			BP6 = new Guna2HtmlLabel();
			XPD = new Guna2HtmlLabel();
			IP8 = new Panel();
			w1r = new Panel();
			s1n = new Guna2ToggleSwitch();
			Y1H = new Guna2HtmlLabel();
			q1V = new Guna2VSeparator();
			oPE = new Guna2ToggleSwitch();
			TPR = new Guna2TextBox();
			NPY = new Guna2HtmlLabel();
			APU = new CheckedListBox();
			vPa = new Guna2HtmlLabel();
			CPo = new Panel();
			NPB = new Guna2ToggleSwitch();
			qPv = new Guna2HtmlLabel();
			WPu = new Guna2VSeparator();
			KPK = new Guna2HtmlLabel();
			BPb = new Guna2HtmlLabel();
			yPp = new Panel();
			Q2i = new TreeView();
			m2g = new ImageList(YiD);
			m2q = new Guna2HtmlLabel();
			f2t = new Guna2TextBox();
			q1c = new Guna2ImageButton();
			sPk = new Guna2ImageButton();
			pPj = new Guna2TextBox();
			aP3 = new Guna2HtmlLabel();
			rPW = new Panel();
			OPy = new Guna2ToggleSwitch();
			aPL = new Guna2HtmlLabel();
			yPJ = new Guna2VSeparator();
			rPX = new Guna2HtmlLabel();
			GPA = new Guna2HtmlLabel();
			KPG = new Panel();
			y1U = new Guna2ImageButton();
			kPs = new Guna2Button();
			qPl = new Guna2HtmlLabel();
			nPS = new Guna2HtmlLabel();
			iP5 = new Guna2Button();
			iPc = new Panel();
			I19 = new Guna2ImageButton();
			I1d = new Guna2ImageButton();
			g1O = new Guna2TextBox();
			T1w = new Guna2TextBox();
			M1f = new Guna2TextBox();
			jP7 = new Guna2HtmlLabel();
			n1Z = new Guna2HtmlLabel();
			D1C = new Guna2HtmlLabel();
			K1T = new Guna2HtmlLabel();
			WPz = new Panel();
			i1x = new Guna2ImageButton();
			p1h = new Panel();
			v1q = new Guna2ToggleSwitch();
			B1t = new Guna2HtmlLabel();
			y1g = new Guna2VSeparator();
			u1i = new Panel();
			x1N = new Guna2ToggleSwitch();
			R1P = new Guna2HtmlLabel();
			K11 = new Guna2VSeparator();
			X14 = new Guna2HtmlLabel();
			I12 = new Guna2HtmlLabel();
			f1e = new Guna2HtmlToolTip();
			T1D = new Panel();
			Q1a = new Guna2ImageButton();
			G1R = new Guna2ImageButton();
			v1Y = new Guna2ImageButton();
			i1o = new Panel();
			S1B = new Guna2ToggleSwitch();
			P1v = new Guna2HtmlLabel();
			N1u = new Guna2VSeparator();
			B1b = new Guna2HtmlLabel();
			t1E = new Guna2HtmlLabel();
			J18 = new ListBox();
			Y1y = new Panel();
			D1s = new Guna2ImageButton();
			S1k = new Guna2HtmlLabel();
			U1G = new Guna2HtmlLabel();
			c1S = new Label();
			A15 = new Guna2HtmlLabel();
			f1A = new Guna2CirclePictureBox();
			U1L = new Guna2HtmlLabel();
			m1J = new Guna2HtmlLabel();
			Y4r = new Panel();
			l4n = new Panel();
			C4H = new Guna2ToggleSwitch();
			v4V = new Guna2HtmlLabel();
			r4z = new Guna2VSeparator();
			X2h = new Guna2HtmlLabel();
			rio.SuspendLayout();
			Wiu.SuspendLayout();
			((ISupportInitialize)YiR).BeginInit();
			qib.SuspendLayout();
			((ISupportInitialize)Xip).BeginInit();
			aik.SuspendLayout();
			X4A.SuspendLayout();
			b4R.SuspendLayout();
			L41.SuspendLayout();
			((ISupportInitialize)p4K).BeginInit();
			d4C.SuspendLayout();
			c17.SuspendLayout();
			Til.SuspendLayout();
			V4W.SuspendLayout();
			y4w.SuspendLayout();
			i4g.SuspendLayout();
			S1z.SuspendLayout();
			RNj.SuspendLayout();
			PiH.SuspendLayout();
			FNq.SuspendLayout();
			jNN.SuspendLayout();
			lN2.SuspendLayout();
			sNx.SuspendLayout();
			ENe.SuspendLayout();
			RNF.SuspendLayout();
			DN8.SuspendLayout();
			KNu.SuspendLayout();
			ANY.SuspendLayout();
			tiX.SuspendLayout();
			ONA.SuspendLayout();
			K10.SuspendLayout();
			GNk.SuspendLayout();
			ANs.SuspendLayout();
			WNX.SuspendLayout();
			KPh.SuspendLayout();
			u48.SuspendLayout();
			iPq.SuspendLayout();
			aPN.SuspendLayout();
			ePC.SuspendLayout();
			H45.SuspendLayout();
			OPT.SuspendLayout();
			iPf.SuspendLayout();
			RPI.SuspendLayout();
			xPQ.SuspendLayout();
			IP8.SuspendLayout();
			w1r.SuspendLayout();
			CPo.SuspendLayout();
			yPp.SuspendLayout();
			rPW.SuspendLayout();
			KPG.SuspendLayout();
			iPc.SuspendLayout();
			WPz.SuspendLayout();
			p1h.SuspendLayout();
			u1i.SuspendLayout();
			T1D.SuspendLayout();
			i1o.SuspendLayout();
			Y1y.SuspendLayout();
			((ISupportInitialize)f1A).BeginInit();
			Y4r.SuspendLayout();
			l4n.SuspendLayout();
			SuspendLayout();
			Ii8.BorderRadius = 10;
			Ii8.TargetControl = this;
			rio.BackColor = Color.FromArgb(30, 30, 30);
			rio.Controls.Add(o4u);
			rio.Controls.Add(I4b);
			rio.Controls.Add(H49);
			rio.Controls.Add(k40);
			rio.Controls.Add(o4I);
			rio.Controls.Add(h1W);
			rio.Controls.Add(S1p);
			rio.Controls.Add(U1j);
			rio.Controls.Add(O1M);
			rio.Controls.Add(GNL);
			rio.Controls.Add(qNJ);
			rio.Controls.Add(piB);
			rio.Controls.Add(eiv);
			rio.Location = new Point(0, 0);
			rio.Name = "header";
			rio.Size = new Size(1000, 39);
			rio.TabIndex = 6;
			rio.MouseDown += uqX;
			rio.MouseMove += Fq6;
			rio.MouseUp += eqn;
			o4u.AnimatedGIF = true;
			((Control)o4u).BackColor = Color.Transparent;
			o4u.CheckedState.ImageSize = new Size(64, 64);
			((Control)o4u).Cursor = Cursors.Hand;
			o4u.HoverState.ImageSize = new Size(15, 15);
			o4u.Image = Resources.invert_colors_24px;
			o4u.ImageOffset = new Point(0, 0);
			o4u.ImageRotate = 0f;
			o4u.ImageSize = new Size(16, 16);
			((Control)o4u).Location = new Point(715, -1);
			((Control)o4u).Name = "guna2ImageButton1";
			o4u.PressedState.ImageSize = new Size(14, 14);
			((Control)o4u).Size = new Size(30, 40);
			((Control)o4u).TabIndex = 21;
			((Control)o4u).Click += otg;
			((Control)I4b).BackColor = Color.Transparent;
			I4b.FillColor = Color.FromArgb(48, 48, 48);
			((Control)I4b).Location = new Point(751, 14);
			((Control)I4b).Name = "guna2VSeparator39";
			((Control)I4b).Size = new Size(1, 10);
			((Control)I4b).TabIndex = 20;
			H49.CheckedState.ImageSize = new Size(64, 64);
			((Control)H49).Cursor = Cursors.Hand;
			H49.HoverState.ImageSize = new Size(13, 13);
			H49.Image = (Image)componentResourceManager.GetObject("minimizeApp.Image");
			H49.ImageOffset = new Point(0, 0);
			H49.ImageRotate = 0f;
			H49.ImageSize = new Size(14, 14);
			((Control)H49).Location = new Point(930, 10);
			((Control)H49).Name = "minimizeApp";
			H49.PressedState.ImageSize = new Size(12, 12);
			((Control)H49).Size = new Size(18, 18);
			((Control)H49).TabIndex = 19;
			((Control)H49).Click += nth;
			k40.CheckedState.ImageSize = new Size(64, 64);
			((Control)k40).Cursor = Cursors.Hand;
			k40.HoverState.ImageSize = new Size(13, 13);
			k40.Image = (Image)componentResourceManager.GetObject("maximizeApp.Image");
			k40.ImageOffset = new Point(0, 0);
			k40.ImageRotate = 0f;
			k40.ImageSize = new Size(14, 14);
			((Control)k40).Location = new Point(950, 10);
			((Control)k40).Name = "maximizeApp";
			k40.PressedState.ImageSize = new Size(12, 12);
			((Control)k40).Size = new Size(18, 18);
			((Control)k40).TabIndex = 18;
			((Control)k40).Click += gtq;
			o4I.CheckedState.ImageSize = new Size(64, 64);
			((Control)o4I).Cursor = Cursors.Hand;
			o4I.HoverState.ImageSize = new Size(13, 13);
			o4I.Image = (Image)componentResourceManager.GetObject("closeApp.Image");
			o4I.ImageOffset = new Point(0, 0);
			o4I.ImageRotate = 0f;
			o4I.ImageSize = new Size(14, 14);
			((Control)o4I).Location = new Point(970, 10);
			((Control)o4I).Name = "closeApp";
			o4I.PressedState.ImageSize = new Size(12, 12);
			((Control)o4I).Size = new Size(18, 18);
			((Control)o4I).TabIndex = 17;
			((Control)o4I).Click += Xtt;
			h1W.AnimatedGIF = true;
			((Control)h1W).BackColor = Color.Transparent;
			h1W.CheckedState.ImageSize = new Size(64, 64);
			((Control)h1W).Cursor = Cursors.Hand;
			h1W.HoverState.ImageSize = new Size(15, 15);
			h1W.Image = Resources.copyright_16px;
			h1W.ImageOffset = new Point(0, 0);
			h1W.ImageRotate = 0f;
			h1W.ImageSize = new Size(16, 16);
			((Control)h1W).Location = new Point(805, -1);
			((Control)h1W).Name = "gotoAbout";
			h1W.PressedState.ImageSize = new Size(14, 14);
			((Control)h1W).Size = new Size(30, 40);
			((Control)h1W).TabIndex = 16;
			((Control)h1W).Click += Tt9;
			S1p.AnimatedGIF = true;
			((Control)S1p).BackColor = Color.Transparent;
			S1p.CheckedState.ImageSize = new Size(64, 64);
			((Control)S1p).Cursor = Cursors.Hand;
			S1p.HoverState.ImageSize = new Size(15, 15);
			S1p.Image = Resources.shield_16px;
			S1p.ImageOffset = new Point(0, 0);
			S1p.ImageRotate = 0f;
			S1p.ImageSize = new Size(16, 16);
			((Control)S1p).Location = new Point(758, -1);
			((Control)S1p).Name = "obfuscateAssembly";
			S1p.PressedState.ImageSize = new Size(14, 14);
			((Control)S1p).Size = new Size(30, 40);
			((Control)S1p).TabIndex = 15;
			((Control)S1p).Click += lit;
			((Control)U1j).BackColor = Color.Transparent;
			U1j.FillColor = Color.FromArgb(48, 48, 48);
			((Control)U1j).Location = new Point(796, 14);
			((Control)U1j).Name = "guna2VSeparator27";
			((Control)U1j).Size = new Size(1, 10);
			((Control)U1j).TabIndex = 14;
			O1M.AnimatedGIF = true;
			((Control)O1M).BackColor = Color.Transparent;
			O1M.CheckedState.ImageSize = new Size(64, 64);
			((Control)O1M).Cursor = Cursors.Hand;
			O1M.HoverState.ImageSize = new Size(15, 15);
			O1M.Image = Resources.edit_file_16px;
			O1M.ImageOffset = new Point(0, 0);
			O1M.ImageRotate = 0f;
			O1M.ImageSize = new Size(16, 16);
			((Control)O1M).Location = new Point(841, -1);
			((Control)O1M).Name = "guna2ImageButton3";
			O1M.PressedState.ImageSize = new Size(14, 14);
			((Control)O1M).Size = new Size(30, 40);
			((Control)O1M).TabIndex = 13;
			((Control)O1M).Click += Lte;
			GNL.AnimatedGIF = true;
			((Control)GNL).BackColor = Color.Transparent;
			GNL.CheckedState.ImageSize = new Size(64, 64);
			((Control)GNL).Cursor = Cursors.Hand;
			GNL.HoverState.ImageSize = new Size(15, 15);
			GNL.Image = Resources.gear_16px;
			GNL.ImageOffset = new Point(0, 0);
			GNL.ImageRotate = 0f;
			GNL.ImageSize = new Size(16, 16);
			((Control)GNL).Location = new Point(877, -1);
			((Control)GNL).Name = "appSettings";
			GNL.PressedState.ImageSize = new Size(14, 14);
			((Control)GNL).Size = new Size(30, 40);
			((Control)GNL).TabIndex = 12;
			((Control)GNL).Click += Htd;
			((Control)qNJ).BackColor = Color.Transparent;
			qNJ.FillColor = Color.FromArgb(48, 48, 48);
			((Control)qNJ).Location = new Point(917, 14);
			((Control)qNJ).Name = "guna2VSeparator2";
			((Control)qNJ).Size = new Size(1, 10);
			((Control)qNJ).TabIndex = 8;
			((Control)piB).BackColor = Color.Transparent;
			((Control)piB).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)piB).ForeColor = Color.White;
			piB.IsContextMenuEnabled = false;
			piB.IsSelectionEnabled = false;
			((Control)piB).Location = new Point(42, 10);
			((Control)piB).Name = "headerTitle2";
			((Control)piB).Size = new Size(56, 18);
			((Control)piB).TabIndex = 2;
			((Control)piB).Text = "FUSCATOR";
			((Control)piB).MouseDown += uqX;
			((Control)piB).MouseMove += Fq6;
			((Control)piB).MouseUp += eqn;
			((Control)eiv).BackColor = Color.Transparent;
			((Control)eiv).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)eiv).ForeColor = Color.FromArgb(41, 230, 124);
			eiv.IsContextMenuEnabled = false;
			eiv.IsSelectionEnabled = false;
			((Control)eiv).Location = new Point(10, 10);
			((Control)eiv).Name = "headerTitle1";
			((Control)eiv).Size = new Size(32, 18);
			((Control)eiv).TabIndex = 1;
			((Control)eiv).Text = "XERIN";
			((Control)eiv).MouseDown += uqX;
			((Control)eiv).MouseMove += Fq6;
			((Control)eiv).MouseUp += eqn;
			tiE.BorderRadius = 10;
			tiE.TargetForm = this;
			Wiu.BackColor = Color.FromArgb(16, 16, 16);
			Wiu.Controls.Add(u46);
			Wiu.Controls.Add(J13);
			Wiu.Controls.Add(DiA);
			Wiu.Controls.Add(HiJ);
			Wiu.Controls.Add(ziL);
			Wiu.Controls.Add(yiy);
			Wiu.Controls.Add(ii3);
			Wiu.Controls.Add(qiW);
			Wiu.Controls.Add(bij);
			Wiu.Controls.Add(YiR);
			Wiu.Controls.Add(siY);
			Wiu.Controls.Add(qib);
			Wiu.Location = new Point(0, 39);
			Wiu.Name = "panel2";
			Wiu.Size = new Size(280, 481);
			Wiu.TabIndex = 7;
			u46.Animated = true;
			u46.AnimatedGIF = true;
			((Control)u46).Cursor = Cursors.Hand;
			u46.DisabledState.BorderColor = Color.DarkGray;
			u46.DisabledState.CustomBorderColor = Color.DarkGray;
			u46.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			u46.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			u46.FillColor = Color.Transparent;
			((Control)u46).Font = new Font("Bahnschrift", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)u46).ForeColor = Color.FromArgb(90, 90, 90);
			u46.HoverState.FillColor = Color.Transparent;
			u46.HoverState.ForeColor = Color.White;
			u46.Image = Resources.compress_24px2;
			u46.ImageAlign = HorizontalAlignment.Left;
			u46.ImageOffset = new Point(10, 0);
			u46.ImageSize = new Size(24, 24);
			((Control)u46).Location = new Point(13, 320);
			((Control)u46).Name = "gotoPacker";
			u46.PressedDepth = 0;
			((Control)u46).Size = new Size(264, 40);
			((Control)u46).TabIndex = 17;
			((Control)u46).Text = "PACKER";
			u46.TextAlign = HorizontalAlignment.Left;
			u46.TextOffset = new Point(14, 0);
			((Control)u46).Click += HtZ;
			J13.AnimatedGIF = true;
			((Control)J13).BackColor = Color.Transparent;
			J13.CheckedState.ImageSize = new Size(64, 64);
			((Control)J13).Cursor = Cursors.Hand;
			J13.HoverState.ImageSize = new Size(17, 17);
			J13.Image = Resources.uncheck_all_18px;
			J13.ImageOffset = new Point(0, 0);
			J13.ImageRotate = 0f;
			J13.ImageSize = new Size(18, 18);
			((Control)J13).Location = new Point(236, 102);
			((Control)J13).Name = "selectAll";
			J13.PressedState.ImageSize = new Size(16, 16);
			((Control)J13).Size = new Size(30, 40);
			((Control)J13).TabIndex = 14;
			((Control)J13).Visible = false;
			((Control)J13).Click += ViP;
			DiA.Animated = true;
			DiA.AnimatedGIF = true;
			((Control)DiA).Cursor = Cursors.Hand;
			DiA.DisabledState.BorderColor = Color.DarkGray;
			DiA.DisabledState.CustomBorderColor = Color.DarkGray;
			DiA.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			DiA.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			DiA.FillColor = Color.Transparent;
			((Control)DiA).Font = new Font("Bahnschrift", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)DiA).ForeColor = Color.FromArgb(90, 90, 90);
			DiA.HoverState.FillColor = Color.Transparent;
			DiA.HoverState.ForeColor = Color.White;
			DiA.Image = Resources.merge_24px2;
			DiA.ImageAlign = HorizontalAlignment.Left;
			DiA.ImageOffset = new Point(10, 0);
			DiA.ImageSize = new Size(24, 24);
			((Control)DiA).Location = new Point(13, 274);
			((Control)DiA).Name = "gotoProject";
			DiA.PressedDepth = 0;
			((Control)DiA).Size = new Size(264, 40);
			((Control)DiA).TabIndex = 16;
			((Control)DiA).Text = "EMBEDDER";
			DiA.TextAlign = HorizontalAlignment.Left;
			DiA.TextOffset = new Point(14, 0);
			((Control)DiA).Click += Vt2;
			HiJ.Animated = true;
			HiJ.AnimatedGIF = true;
			((Control)HiJ).Cursor = Cursors.Hand;
			HiJ.DisabledState.BorderColor = Color.DarkGray;
			HiJ.DisabledState.CustomBorderColor = Color.DarkGray;
			HiJ.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			HiJ.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			HiJ.FillColor = Color.Transparent;
			((Control)HiJ).Font = new Font("Bahnschrift", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)HiJ).ForeColor = Color.FromArgb(90, 90, 90);
			HiJ.HoverState.FillColor = Color.Transparent;
			HiJ.HoverState.ForeColor = Color.White;
			HiJ.Image = Resources.data_protection_24px2;
			HiJ.ImageAlign = HorizontalAlignment.Left;
			HiJ.ImageOffset = new Point(10, 0);
			HiJ.ImageSize = new Size(24, 24);
			((Control)HiJ).Location = new Point(13, 231);
			((Control)HiJ).Name = "gotoCodeVirt";
			HiJ.PressedDepth = 0;
			((Control)HiJ).Size = new Size(264, 40);
			((Control)HiJ).TabIndex = 15;
			((Control)HiJ).Text = "CODE VIRTUALIZATION";
			HiJ.TextAlign = HorizontalAlignment.Left;
			HiJ.TextOffset = new Point(14, 0);
			((Control)HiJ).Click += Jt4;
			ziL.Animated = true;
			ziL.AnimatedGIF = true;
			((Control)ziL).Cursor = Cursors.Hand;
			ziL.DisabledState.BorderColor = Color.DarkGray;
			ziL.DisabledState.CustomBorderColor = Color.DarkGray;
			ziL.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			ziL.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			ziL.FillColor = Color.Transparent;
			((Control)ziL).Font = new Font("Bahnschrift", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)ziL).ForeColor = Color.FromArgb(90, 90, 90);
			ziL.HoverState.FillColor = Color.Transparent;
			ziL.HoverState.ForeColor = Color.White;
			ziL.Image = Resources.shield_24px2;
			ziL.ImageAlign = HorizontalAlignment.Left;
			ziL.ImageOffset = new Point(10, 0);
			ziL.ImageSize = new Size(24, 24);
			((Control)ziL).Location = new Point(13, 188);
			((Control)ziL).Name = "gotoCodeEnc";
			ziL.PressedDepth = 0;
			((Control)ziL).Size = new Size(264, 40);
			((Control)ziL).TabIndex = 14;
			((Control)ziL).Text = "CODE ENCRYPTION";
			ziL.TextAlign = HorizontalAlignment.Left;
			ziL.TextOffset = new Point(14, 0);
			((Control)ziL).Click += it1;
			yiy.Animated = true;
			yiy.AnimatedGIF = true;
			((Control)yiy).Cursor = Cursors.Hand;
			yiy.DisabledState.BorderColor = Color.DarkGray;
			yiy.DisabledState.CustomBorderColor = Color.DarkGray;
			yiy.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			yiy.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			yiy.FillColor = Color.Transparent;
			((Control)yiy).Font = new Font("Bahnschrift", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)yiy).ForeColor = Color.FromArgb(90, 90, 90);
			yiy.HoverState.FillColor = Color.Transparent;
			yiy.HoverState.ForeColor = Color.White;
			yiy.Image = Resources.translation_24px2;
			yiy.ImageAlign = HorizontalAlignment.Left;
			yiy.ImageOffset = new Point(10, 0);
			yiy.ImageSize = new Size(24, 24);
			((Control)yiy).Location = new Point(13, 145);
			((Control)yiy).Name = "gotoRenamer";
			yiy.PressedDepth = 0;
			((Control)yiy).Size = new Size(264, 40);
			((Control)yiy).TabIndex = 13;
			((Control)yiy).Text = "RENAMER";
			yiy.TextAlign = HorizontalAlignment.Left;
			yiy.TextOffset = new Point(14, 0);
			((Control)yiy).Click += ntP;
			ii3.Animated = true;
			ii3.AnimatedGIF = true;
			((Control)ii3).Cursor = Cursors.Hand;
			ii3.DisabledState.BorderColor = Color.DarkGray;
			ii3.DisabledState.CustomBorderColor = Color.DarkGray;
			ii3.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			ii3.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			ii3.FillColor = Color.Transparent;
			((Control)ii3).Font = new Font("Bahnschrift", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)ii3).ForeColor = Color.FromArgb(90, 90, 90);
			ii3.HoverState.FillColor = Color.Transparent;
			ii3.HoverState.ForeColor = Color.White;
			ii3.Image = Resources.security_configuration_24px2;
			ii3.ImageAlign = HorizontalAlignment.Left;
			ii3.ImageOffset = new Point(10, 0);
			ii3.ImageSize = new Size(24, 24);
			((Control)ii3).Location = new Point(13, 102);
			((Control)ii3).Name = "gotoProtections";
			ii3.PressedDepth = 0;
			((Control)ii3).Size = new Size(264, 40);
			((Control)ii3).TabIndex = 9;
			((Control)ii3).Text = "PROTECTIONS";
			ii3.TextAlign = HorizontalAlignment.Left;
			ii3.TextOffset = new Point(14, 0);
			((Control)ii3).Click += stN;
			qiW.FillColor = Color.FromArgb(41, 230, 124);
			qiW.FillThickness = 2;
			((Control)qiW).Location = new Point(-2, 59);
			((Control)qiW).Name = "pagesSeparator";
			((Control)qiW).Size = new Size(6, 40);
			((Control)qiW).TabIndex = 8;
			bij.Animated = true;
			bij.AnimatedGIF = true;
			((Control)bij).Cursor = Cursors.Hand;
			bij.DisabledState.BorderColor = Color.DarkGray;
			bij.DisabledState.CustomBorderColor = Color.DarkGray;
			bij.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			bij.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			bij.FillColor = Color.Transparent;
			((Control)bij).Font = new Font("Bahnschrift", 9f);
			((Control)bij).ForeColor = Color.White;
			bij.HoverState.FillColor = Color.Transparent;
			bij.HoverState.ForeColor = Color.White;
			bij.Image = Resources.file_24px;
			bij.ImageAlign = HorizontalAlignment.Left;
			bij.ImageOffset = new Point(10, 0);
			bij.ImageSize = new Size(24, 24);
			((Control)bij).Location = new Point(13, 59);
			((Control)bij).Name = "gotoAssembly";
			bij.PressedDepth = 0;
			((Control)bij).Size = new Size(264, 40);
			((Control)bij).TabIndex = 8;
			((Control)bij).Text = "ASSEMBLY";
			bij.TextAlign = HorizontalAlignment.Left;
			bij.TextOffset = new Point(14, 0);
			((Control)bij).Click += Cti;
			((PictureBox)YiR).Image = (Image)componentResourceManager.GetObject("guna2PictureBox1.Image");
			YiR.ImageRotate = 0f;
			((Control)YiR).Location = new Point(245, 25);
			((Control)YiR).Name = "guna2PictureBox1";
			((Control)YiR).Size = new Size(18, 18);
			((PictureBox)YiR).SizeMode = PictureBoxSizeMode.AutoSize;
			((PictureBox)YiR).TabIndex = 8;
			((PictureBox)YiR).TabStop = false;
			((Control)siY).BackColor = Color.Transparent;
			((Control)siY).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)siY).ForeColor = Color.White;
			siY.IsContextMenuEnabled = false;
			siY.IsSelectionEnabled = false;
			((Control)siY).Location = new Point(18, 25);
			((Control)siY).Name = "guna2HtmlLabel5";
			((Control)siY).Size = new Size(54, 18);
			((Control)siY).TabIndex = 5;
			((Control)siY).Text = "FEATURES";
			qib.BackColor = Color.FromArgb(16, 16, 16);
			qib.Controls.Add(iiU);
			qib.Controls.Add(Pia);
			qib.Controls.Add(Xip);
			qib.Location = new Point(0, 424);
			qib.Name = "panel3";
			qib.Size = new Size(280, 57);
			qib.TabIndex = 6;
			((Control)iiU).AutoSize = false;
			((Control)iiU).BackColor = Color.Transparent;
			((Control)iiU).Font = new Font("Bahnschrift SemiCondensed", 8f);
			((Control)iiU).ForeColor = Color.White;
			iiU.IsContextMenuEnabled = false;
			iiU.IsSelectionEnabled = false;
			((Control)iiU).Location = new Point(52, 28);
			((Control)iiU).Name = "duration";
			((Control)iiU).Size = new Size(151, 15);
			((Control)iiU).TabIndex = 9;
			((Control)iiU).Text = "DURATION";
			((Control)Pia).AutoSize = false;
			((Control)Pia).BackColor = Color.Transparent;
			((Control)Pia).Font = new Font("Bahnschrift SemiCondensed", 8f);
			((Control)Pia).ForeColor = Color.FromArgb(41, 230, 124);
			Pia.IsContextMenuEnabled = false;
			Pia.IsSelectionEnabled = false;
			((Control)Pia).Location = new Point(52, 14);
			((Control)Pia).Name = "userName";
			((Control)Pia).Size = new Size(151, 15);
			((Control)Pia).TabIndex = 5;
			((Control)Pia).Text = "Raymond-Kenny";
			((PictureBox)Xip).Image = Resources.fingerprint_30px;
			Xip.ImageRotate = 0f;
			((Control)Xip).Location = new Point(14, 13);
			((Control)Xip).Name = "guna2CirclePictureBox1";
			Xip.ShadowDecoration.Mode = ShadowMode.Circle;
			((Control)Xip).Size = new Size(30, 30);
			((PictureBox)Xip).TabIndex = 8;
			((PictureBox)Xip).TabStop = false;
			aik.BackColor = Color.FromArgb(20, 20, 20);
			aik.Controls.Add(X4A);
			aik.Controls.Add(J4j);
			aik.Controls.Add(C43);
			aik.Controls.Add(s4E);
			aik.Controls.Add(b4R);
			aik.Controls.Add(P4m);
			aik.Controls.Add(L41);
			aik.Controls.Add(d4C);
			aik.Controls.Add(c17);
			aik.Controls.Add(oic);
			aik.Controls.Add(Ni7);
			aik.Controls.Add(gi5);
			aik.Controls.Add(nis);
			aik.Controls.Add(qiG);
			aik.Controls.Add(miS);
			aik.Location = new Point(279, 39);
			aik.Name = "assemblyPage";
			aik.Size = new Size(721, 481);
			aik.TabIndex = 8;
			X4A.BackColor = Color.FromArgb(26, 26, 26);
			X4A.Controls.Add(U4k);
			X4A.Controls.Add(U4G);
			X4A.Controls.Add(H4S);
			X4A.Location = new Point(42, 255);
			X4A.Name = "panel8";
			X4A.Size = new Size(427, 40);
			X4A.TabIndex = 16;
			U4k.Animated = true;
			((Control)U4k).BackColor = Color.Transparent;
			U4k.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			U4k.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			U4k.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			U4k.CheckedState.InnerColor = Color.White;
			((Control)U4k).Cursor = Cursors.Hand;
			((Control)U4k).Location = new Point(381, 10);
			((Control)U4k).Name = "changeAttributes";
			((Control)U4k).Size = new Size(35, 20);
			((Control)U4k).TabIndex = 10;
			U4k.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			U4k.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			U4k.UncheckedState.InnerBorderColor = Color.White;
			U4k.UncheckedState.InnerColor = Color.White;
			U4k.CheckedChanged += mgh;
			((Control)U4G).BackColor = Color.Transparent;
			((Control)U4G).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)U4G).ForeColor = Color.White;
			U4G.IsContextMenuEnabled = false;
			U4G.IsSelectionEnabled = false;
			((Control)U4G).Location = new Point(13, 11);
			((Control)U4G).Name = "guna2HtmlLabel9";
			((Control)U4G).Size = new Size(145, 18);
			((Control)U4G).TabIndex = 8;
			((Control)U4G).Text = "Change assembly attributes";
			H4S.FillColor = Color.FromArgb(41, 230, 124);
			H4S.FillThickness = 3;
			((Control)H4S).Location = new Point(-2, 10);
			((Control)H4S).Name = "guna2VSeparator37";
			((Control)H4S).Size = new Size(3, 20);
			((Control)H4S).TabIndex = 9;
			J4j.Animated = true;
			((Control)J4j).BackColor = Color.Transparent;
			J4j.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			J4j.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			J4j.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			J4j.CheckedState.InnerColor = Color.White;
			((Control)J4j).Cursor = Cursors.Hand;
			((Control)J4j).Location = new Point(433, 19);
			((Control)J4j).Name = "samelocSwitch";
			((Control)J4j).Size = new Size(35, 20);
			((Control)J4j).TabIndex = 18;
			J4j.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			J4j.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			J4j.UncheckedState.InnerBorderColor = Color.White;
			J4j.UncheckedState.InnerColor = Color.White;
			J4j.CheckedChanged += igz;
			((Control)C43).BackColor = Color.Transparent;
			((Control)C43).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)C43).ForeColor = Color.White;
			C43.IsContextMenuEnabled = false;
			C43.IsSelectionEnabled = false;
			((Control)C43).Location = new Point(317, 20);
			((Control)C43).Name = "guna2HtmlLabel73";
			((Control)C43).Size = new Size(114, 18);
			((Control)C43).TabIndex = 17;
			((Control)C43).Text = "Save in same location";
			((Control)s4E).BackColor = Color.Transparent;
			((Control)s4E).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)s4E).ForeColor = Color.White;
			s4E.IsContextMenuEnabled = false;
			s4E.IsSelectionEnabled = false;
			((Control)s4E).Location = new Point(42, 302);
			((Control)s4E).Name = "guna2HtmlLabel72";
			((Control)s4E).Size = new Size(102, 18);
			((Control)s4E).TabIndex = 16;
			((Control)s4E).Text = "CODE OPTIMIZATION";
			b4R.BackColor = Color.FromArgb(26, 26, 26);
			b4R.Controls.Add(w4Y);
			b4R.Controls.Add(n4U);
			b4R.Controls.Add(m4a);
			b4R.Location = new Point(42, 209);
			b4R.Name = "dynamicctorPanel";
			b4R.Size = new Size(427, 40);
			b4R.TabIndex = 15;
			b4R.MouseDown += ytU;
			w4Y.Animated = true;
			((Control)w4Y).BackColor = Color.Transparent;
			w4Y.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			w4Y.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			w4Y.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			w4Y.CheckedState.InnerColor = Color.White;
			((Control)w4Y).Cursor = Cursors.Hand;
			((Control)w4Y).Location = new Point(381, 10);
			((Control)w4Y).Name = "dynamicctorSwitch";
			((Control)w4Y).Size = new Size(35, 20);
			((Control)w4Y).TabIndex = 10;
			w4Y.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			w4Y.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			w4Y.UncheckedState.InnerBorderColor = Color.White;
			w4Y.UncheckedState.InnerColor = Color.White;
			w4Y.CheckedChanged += egt;
			((Control)n4U).BackColor = Color.Transparent;
			((Control)n4U).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)n4U).ForeColor = Color.White;
			n4U.IsContextMenuEnabled = false;
			n4U.IsSelectionEnabled = false;
			((Control)n4U).Location = new Point(13, 11);
			((Control)n4U).Name = "guna2HtmlLabel71";
			((Control)n4U).Size = new Size(71, 18);
			((Control)n4U).TabIndex = 8;
			((Control)n4U).Text = "Dynamic ctor";
			m4a.FillColor = Color.FromArgb(41, 230, 124);
			m4a.FillThickness = 3;
			((Control)m4a).Location = new Point(-2, 10);
			((Control)m4a).Name = "guna2VSeparator40";
			((Control)m4a).Size = new Size(3, 20);
			((Control)m4a).TabIndex = 9;
			P4m.BorderColor = Color.FromArgb(44, 44, 44);
			P4m.BorderRadius = 6;
			((Control)P4m).Cursor = Cursors.IBeam;
			P4m.DefaultText = "";
			P4m.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			P4m.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			P4m.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			P4m.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			P4m.FillColor = Color.FromArgb(26, 26, 26);
			P4m.FocusedState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)P4m).Font = new Font("Bahnschrift SemiCondensed", 9f);
			((Control)P4m).ForeColor = Color.White;
			P4m.HoverState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)P4m).Location = new Point(511, 48);
			P4m.Multiline = true;
			((Control)P4m).Name = "assemblyInfo";
			P4m.PasswordChar = '\0';
			P4m.PlaceholderForeColor = Color.FromArgb(120, 120, 120);
			P4m.PlaceholderText = "ASSEMBLY INFO";
			P4m.ReadOnly = true;
			P4m.SelectedText = "";
			((Control)P4m).Size = new Size(179, 200);
			((Control)P4m).TabIndex = 14;
			P4m.TextOffset = new Point(0, 2);
			L41.BackColor = Color.FromArgb(26, 26, 26);
			L41.Controls.Add(p4K);
			L41.Controls.Add(L4l);
			L41.Controls.Add(f4X);
			L41.Controls.Add(S4Z);
			L41.Location = new Point(42, 163);
			L41.Name = "amsiPanel";
			L41.Size = new Size(427, 40);
			L41.TabIndex = 13;
			L41.MouseDown += CtR;
			((Control)p4K).BackColor = Color.Transparent;
			((PictureBox)p4K).Image = Resources.warning_shield_24px;
			p4K.ImageRotate = 0f;
			((Control)p4K).Location = new Point(12, 10);
			((Control)p4K).Name = "guna2PictureBox4";
			((Control)p4K).Size = new Size(20, 20);
			((PictureBox)p4K).SizeMode = PictureBoxSizeMode.Zoom;
			((PictureBox)p4K).TabIndex = 15;
			((PictureBox)p4K).TabStop = false;
			p4K.UseTransparentBackground = true;
			L4l.Animated = true;
			((Control)L4l).BackColor = Color.Transparent;
			L4l.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			L4l.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			L4l.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			L4l.CheckedState.InnerColor = Color.White;
			((Control)L4l).Cursor = Cursors.Hand;
			((Control)L4l).Location = new Point(382, 10);
			((Control)L4l).Name = "amsiCBox";
			((Control)L4l).Size = new Size(35, 20);
			((Control)L4l).TabIndex = 12;
			L4l.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			L4l.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			L4l.UncheckedState.InnerBorderColor = Color.White;
			L4l.UncheckedState.InnerColor = Color.White;
			L4l.CheckedChanged += Stz;
			((Control)f4X).BackColor = Color.Transparent;
			((Control)f4X).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)f4X).ForeColor = Color.White;
			f4X.IsContextMenuEnabled = false;
			f4X.IsSelectionEnabled = false;
			((Control)f4X).Location = new Point(38, 11);
			((Control)f4X).Name = "guna2HtmlLabel76";
			((Control)f4X).Size = new Size(69, 18);
			((Control)f4X).TabIndex = 11;
			((Control)f4X).Text = "AMSI Bypass";
			S4Z.FillColor = Color.FromArgb(41, 230, 124);
			S4Z.FillThickness = 3;
			((Control)S4Z).Location = new Point(-2, 10);
			((Control)S4Z).Name = "guna2VSeparator29";
			((Control)S4Z).Size = new Size(3, 20);
			((Control)S4Z).TabIndex = 9;
			d4C.BackColor = Color.FromArgb(26, 26, 26);
			d4C.Controls.Add(U44);
			d4C.Controls.Add(m4T);
			d4C.Controls.Add(S42);
			d4C.Controls.Add(J4x);
			d4C.Controls.Add(G4O);
			d4C.Location = new Point(42, 373);
			d4C.Name = "simplePanel";
			d4C.Size = new Size(427, 40);
			d4C.TabIndex = 13;
			d4C.MouseDown += Gtn;
			U44.Animated = true;
			((Control)U44).BackColor = Color.Transparent;
			U44.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			U44.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			U44.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			U44.CheckedState.InnerColor = Color.White;
			((Control)U44).Cursor = Cursors.Hand;
			((Control)U44).Location = new Point(381, 10);
			((Control)U44).Name = "optimizierSwitch";
			((Control)U44).Size = new Size(35, 20);
			((Control)U44).TabIndex = 10;
			U44.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			U44.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			U44.UncheckedState.InnerBorderColor = Color.White;
			U44.UncheckedState.InnerColor = Color.White;
			U44.CheckedChanged += pg1;
			m4T.Animated = true;
			((Control)m4T).BackColor = Color.Transparent;
			m4T.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			m4T.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			m4T.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			m4T.CheckedState.InnerColor = Color.White;
			((Control)m4T).Cursor = Cursors.Hand;
			((Control)m4T).Location = new Point(116, 10);
			((Control)m4T).Name = "simpilifierSwitch";
			((Control)m4T).Size = new Size(35, 20);
			((Control)m4T).TabIndex = 10;
			m4T.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			m4T.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			m4T.UncheckedState.InnerBorderColor = Color.White;
			m4T.UncheckedState.InnerColor = Color.White;
			m4T.CheckedChanged += AgP;
			((Control)S42).BackColor = Color.Transparent;
			((Control)S42).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)S42).ForeColor = Color.White;
			S42.IsContextMenuEnabled = false;
			S42.IsSelectionEnabled = false;
			((Control)S42).Location = new Point(275, 11);
			((Control)S42).Name = "guna2HtmlLabel59";
			((Control)S42).Size = new Size(100, 18);
			((Control)S42).TabIndex = 8;
			((Control)S42).Text = "Optimize assembly";
			((Control)J4x).BackColor = Color.Transparent;
			((Control)J4x).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)J4x).ForeColor = Color.White;
			J4x.IsContextMenuEnabled = false;
			J4x.IsSelectionEnabled = false;
			((Control)J4x).Location = new Point(13, 11);
			((Control)J4x).Name = "guna2HtmlLabel58";
			((Control)J4x).Size = new Size(97, 18);
			((Control)J4x).TabIndex = 8;
			((Control)J4x).Text = "Simplify assembly";
			G4O.FillColor = Color.FromArgb(41, 230, 124);
			G4O.FillThickness = 3;
			((Control)G4O).Location = new Point(-2, 10);
			((Control)G4O).Name = "guna2VSeparator28";
			((Control)G4O).Size = new Size(3, 20);
			((Control)G4O).TabIndex = 9;
			c17.BackColor = Color.FromArgb(26, 26, 26);
			c17.Controls.Add(K1X);
			c17.Controls.Add(F1K);
			c17.Controls.Add(W16);
			c17.Location = new Point(42, 328);
			c17.Name = "UnverifiableCodeAttributePanel";
			c17.Size = new Size(427, 40);
			c17.TabIndex = 12;
			c17.MouseDown += ptp;
			K1X.Animated = true;
			((Control)K1X).BackColor = Color.Transparent;
			K1X.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			K1X.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			K1X.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			K1X.CheckedState.InnerColor = Color.White;
			((Control)K1X).Cursor = Cursors.Hand;
			((Control)K1X).Location = new Point(381, 10);
			((Control)K1X).Name = "UnverifiableCodeAttributeSwitch";
			((Control)K1X).Size = new Size(35, 20);
			((Control)K1X).TabIndex = 10;
			K1X.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			K1X.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			K1X.UncheckedState.InnerBorderColor = Color.White;
			K1X.UncheckedState.InnerColor = Color.White;
			K1X.CheckedChanged += CgN;
			((Control)F1K).BackColor = Color.Transparent;
			((Control)F1K).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)F1K).ForeColor = Color.White;
			F1K.IsContextMenuEnabled = false;
			F1K.IsSelectionEnabled = false;
			((Control)F1K).Location = new Point(13, 11);
			((Control)F1K).Name = "guna2HtmlLabel64";
			((Control)F1K).Size = new Size(134, 18);
			((Control)F1K).TabIndex = 8;
			((Control)F1K).Text = "UnverifiableCodeAttribute";
			W16.FillColor = Color.FromArgb(41, 230, 124);
			W16.FillThickness = 3;
			((Control)W16).Location = new Point(-2, 10);
			((Control)W16).Name = "guna2VSeparator31";
			((Control)W16).Size = new Size(3, 20);
			((Control)W16).TabIndex = 9;
			oic.AnimatedGIF = true;
			((Control)oic).BackColor = Color.Transparent;
			oic.CheckedState.ImageSize = new Size(64, 64);
			((Control)oic).Cursor = Cursors.Hand;
			oic.HoverState.ImageSize = new Size(19, 19);
			oic.Image = Resources.folder_20px1;
			oic.ImageOffset = new Point(0, 0);
			oic.ImageRotate = 0f;
			oic.ImageSize = new Size(20, 20);
			((Control)oic).Location = new Point(475, 121);
			((Control)oic).Name = "changeDestination";
			oic.PressedState.ImageSize = new Size(18, 18);
			((Control)oic).Size = new Size(30, 30);
			((Control)oic).TabIndex = 7;
			oic.UseTransparentBackground = true;
			((Control)oic).Click += etu;
			Ni7.AnimatedGIF = true;
			((Control)Ni7).BackColor = Color.Transparent;
			Ni7.CheckedState.ImageSize = new Size(64, 64);
			((Control)Ni7).Cursor = Cursors.Hand;
			Ni7.HoverState.ImageSize = new Size(19, 19);
			Ni7.Image = Resources.add_20px1;
			Ni7.ImageOffset = new Point(0, 0);
			Ni7.ImageRotate = 0f;
			Ni7.ImageSize = new Size(20, 20);
			((Control)Ni7).Location = new Point(475, 52);
			((Control)Ni7).Name = "addAssembly";
			Ni7.PressedState.ImageSize = new Size(18, 18);
			((Control)Ni7).Size = new Size(30, 30);
			((Control)Ni7).TabIndex = 6;
			Ni7.UseTransparentBackground = true;
			((Control)Ni7).Click += stv;
			((Control)gi5).BackColor = Color.Transparent;
			((Control)gi5).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)gi5).ForeColor = Color.White;
			gi5.IsContextMenuEnabled = false;
			gi5.IsSelectionEnabled = false;
			((Control)gi5).Location = new Point(42, 93);
			((Control)gi5).Name = "guna2HtmlLabel8";
			((Control)gi5).Size = new Size(67, 18);
			((Control)gi5).TabIndex = 5;
			((Control)gi5).Text = "DESTINATION";
			nis.BorderColor = Color.FromArgb(44, 44, 44);
			nis.BorderRadius = 6;
			((Control)nis).Cursor = Cursors.IBeam;
			nis.DefaultText = "";
			nis.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			nis.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			nis.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			nis.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			nis.FillColor = Color.FromArgb(26, 26, 26);
			nis.FocusedState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)nis).Font = new Font("Bahnschrift SemiCondensed", 9f);
			((Control)nis).ForeColor = Color.White;
			nis.HoverState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)nis).Location = new Point(42, 117);
			((Control)nis).Name = "destinationBox";
			nis.PasswordChar = '\0';
			nis.PlaceholderForeColor = Color.FromArgb(120, 120, 120);
			nis.PlaceholderText = "OBFUSCATED ASSEMBLY WILL BE SAVED HERE";
			nis.SelectedText = "";
			((Control)nis).Size = new Size(427, 38);
			((Control)nis).TabIndex = 4;
			((Control)qiG).BackColor = Color.Transparent;
			((Control)qiG).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)qiG).ForeColor = Color.White;
			qiG.IsContextMenuEnabled = false;
			qiG.IsSelectionEnabled = false;
			((Control)qiG).Location = new Point(42, 24);
			((Control)qiG).Name = "guna2HtmlLabel7";
			((Control)qiG).Size = new Size(87, 18);
			((Control)qiG).TabIndex = 3;
			((Control)qiG).Text = "ASSEMBLY PATH";
			((Control)miS).AllowDrop = true;
			miS.BorderColor = Color.FromArgb(44, 44, 44);
			miS.BorderRadius = 6;
			((Control)miS).Cursor = Cursors.IBeam;
			miS.DefaultText = "";
			miS.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			miS.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			miS.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			miS.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			miS.FillColor = Color.FromArgb(26, 26, 26);
			miS.FocusedState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)miS).Font = new Font("Bahnschrift SemiCondensed", 9f);
			((Control)miS).ForeColor = Color.White;
			miS.HoverState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)miS).Location = new Point(42, 48);
			((Control)miS).Name = "assemblyBox";
			miS.PasswordChar = '\0';
			miS.PlaceholderForeColor = Color.FromArgb(120, 120, 120);
			miS.PlaceholderText = "DRAG N DROP ASSEMBLY HERE";
			miS.SelectedText = "";
			((Control)miS).Size = new Size(427, 38);
			((Control)miS).TabIndex = 0;
			((Control)miS).DragDrop += qto;
			((Control)miS).DragEnter += xtB;
			Til.AutoScroll = true;
			Til.AutoScrollMargin = new Size(0, 16);
			Til.BackColor = Color.FromArgb(20, 20, 20);
			Til.Controls.Add(V4W);
			Til.Controls.Add(y4w);
			Til.Controls.Add(i4g);
			Til.Controls.Add(S1z);
			Til.Controls.Add(RNj);
			Til.Controls.Add(PiH);
			Til.Controls.Add(FNq);
			Til.Controls.Add(jNN);
			Til.Controls.Add(lN2);
			Til.Controls.Add(sNx);
			Til.Controls.Add(ENe);
			Til.Controls.Add(RNF);
			Til.Controls.Add(DN8);
			Til.Controls.Add(KNu);
			Til.Controls.Add(ANY);
			Til.Controls.Add(tiX);
			Til.Location = new Point(279, 39);
			Til.Name = "protectionsPage";
			Til.Size = new Size(721, 481);
			Til.TabIndex = 9;
			V4W.BackColor = Color.FromArgb(26, 26, 26);
			V4W.Controls.Add(R4y);
			V4W.Controls.Add(H4L);
			V4W.Controls.Add(i4J);
			V4W.Location = new Point(14, 246);
			V4W.Name = "antiformskipPanel";
			V4W.Size = new Size(667, 40);
			V4W.TabIndex = 13;
			V4W.MouseDown += CtY;
			R4y.Animated = true;
			R4y.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			R4y.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			R4y.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			R4y.CheckedState.InnerColor = Color.White;
			((Control)R4y).Cursor = Cursors.Hand;
			((Control)R4y).Location = new Point(620, 10);
			((Control)R4y).Name = "antiformskipSwitch";
			((Control)R4y).Size = new Size(35, 20);
			((Control)R4y).TabIndex = 10;
			R4y.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			R4y.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			R4y.UncheckedState.InnerBorderColor = Color.White;
			R4y.UncheckedState.InnerColor = Color.White;
			R4y.CheckedChanged += Ugq;
			((Control)H4L).BackColor = Color.Transparent;
			((Control)H4L).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)H4L).ForeColor = Color.White;
			H4L.IsContextMenuEnabled = false;
			H4L.IsSelectionEnabled = false;
			((Control)H4L).Location = new Point(13, 11);
			((Control)H4L).Name = "guna2HtmlLabel74";
			((Control)H4L).Size = new Size(230, 18);
			((Control)H4L).TabIndex = 8;
			((Control)H4L).Text = "ANTI FORM SKIPPING [ Working with C# only ]";
			i4J.FillColor = Color.FromArgb(41, 230, 124);
			i4J.FillThickness = 3;
			((Control)i4J).Location = new Point(-2, 10);
			((Control)i4J).Name = "guna2VSeparator41";
			((Control)i4J).Size = new Size(3, 20);
			((Control)i4J).TabIndex = 9;
			y4w.BackColor = Color.FromArgb(26, 26, 26);
			y4w.Controls.Add(d4f);
			y4w.Controls.Add(B4d);
			y4w.Controls.Add(Y4e);
			y4w.Location = new Point(14, 200);
			y4w.Name = "antiEmulatePanel";
			y4w.Size = new Size(667, 40);
			y4w.TabIndex = 12;
			y4w.MouseDown += tta;
			d4f.Animated = true;
			d4f.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			d4f.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			d4f.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			d4f.CheckedState.InnerColor = Color.White;
			((Control)d4f).Cursor = Cursors.Hand;
			((Control)d4f).Location = new Point(620, 10);
			((Control)d4f).Name = "antikauthEmulateSwitch";
			((Control)d4f).Size = new Size(35, 20);
			((Control)d4f).TabIndex = 10;
			d4f.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			d4f.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			d4f.UncheckedState.InnerBorderColor = Color.White;
			d4f.UncheckedState.InnerColor = Color.White;
			d4f.CheckedChanged += wgi;
			((Control)B4d).BackColor = Color.Transparent;
			((Control)B4d).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)B4d).ForeColor = Color.White;
			B4d.IsContextMenuEnabled = false;
			B4d.IsSelectionEnabled = false;
			((Control)B4d).Location = new Point(13, 11);
			((Control)B4d).Name = "guna2HtmlLabel69";
			((Control)B4d).Size = new Size(133, 18);
			((Control)B4d).TabIndex = 8;
			((Control)B4d).Text = "ANTI KEYAUTH EMULATING";
			Y4e.FillColor = Color.FromArgb(41, 230, 124);
			Y4e.FillThickness = 3;
			((Control)Y4e).Location = new Point(-2, 10);
			((Control)Y4e).Name = "guna2VSeparator36";
			((Control)Y4e).Size = new Size(3, 20);
			((Control)Y4e).TabIndex = 9;
			i4g.BackColor = Color.FromArgb(26, 26, 26);
			i4g.Controls.Add(r4i);
			i4g.Controls.Add(n4N);
			i4g.Controls.Add(F4P);
			i4g.Location = new Point(14, 292);
			i4g.Name = "antitamperPanel";
			i4g.Size = new Size(667, 40);
			i4g.TabIndex = 13;
			i4g.MouseDown += Atr;
			r4i.Animated = true;
			r4i.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			r4i.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			r4i.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			r4i.CheckedState.InnerColor = Color.White;
			((Control)r4i).Cursor = Cursors.Hand;
			((Control)r4i).Location = new Point(620, 10);
			((Control)r4i).Name = "antiTamperSwitch";
			((Control)r4i).Size = new Size(35, 20);
			((Control)r4i).TabIndex = 10;
			r4i.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			r4i.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			r4i.UncheckedState.InnerBorderColor = Color.White;
			r4i.UncheckedState.InnerColor = Color.White;
			r4i.CheckedChanged += igE;
			((Control)n4N).BackColor = Color.Transparent;
			((Control)n4N).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)n4N).ForeColor = Color.White;
			n4N.IsContextMenuEnabled = false;
			n4N.IsSelectionEnabled = false;
			((Control)n4N).Location = new Point(13, 11);
			((Control)n4N).Name = "guna2HtmlLabel67";
			((Control)n4N).Size = new Size(69, 18);
			((Control)n4N).TabIndex = 8;
			((Control)n4N).Text = "ANTI TAMPER";
			F4P.FillColor = Color.FromArgb(41, 230, 124);
			F4P.FillThickness = 3;
			((Control)F4P).Location = new Point(-2, 10);
			((Control)F4P).Name = "guna2VSeparator34";
			((Control)F4P).Size = new Size(3, 20);
			((Control)F4P).TabIndex = 9;
			S1z.BackColor = Color.FromArgb(26, 26, 26);
			S1z.Controls.Add(m4h);
			S1z.Controls.Add(S4q);
			S1z.Controls.Add(W4t);
			S1z.Location = new Point(14, 476);
			S1z.Name = "intencodingPanel";
			S1z.Size = new Size(667, 40);
			S1z.TabIndex = 14;
			S1z.MouseDown += Dt6;
			m4h.Animated = true;
			m4h.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			m4h.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			m4h.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			m4h.CheckedState.InnerColor = Color.White;
			((Control)m4h).Cursor = Cursors.Hand;
			((Control)m4h).Location = new Point(620, 10);
			((Control)m4h).Name = "intencodeSwitch";
			((Control)m4h).Size = new Size(35, 20);
			((Control)m4h).TabIndex = 10;
			m4h.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			m4h.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			m4h.UncheckedState.InnerBorderColor = Color.White;
			m4h.UncheckedState.InnerColor = Color.White;
			m4h.CheckedChanged += lg8;
			((Control)S4q).BackColor = Color.Transparent;
			((Control)S4q).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)S4q).ForeColor = Color.White;
			S4q.IsContextMenuEnabled = false;
			S4q.IsSelectionEnabled = false;
			((Control)S4q).Location = new Point(13, 11);
			((Control)S4q).Name = "guna2HtmlLabel66";
			((Control)S4q).Size = new Size(105, 18);
			((Control)S4q).TabIndex = 8;
			((Control)S4q).Text = "INTEGERS ENCODING";
			W4t.FillColor = Color.FromArgb(41, 230, 124);
			W4t.FillThickness = 3;
			((Control)W4t).Location = new Point(-2, 10);
			((Control)W4t).Name = "guna2VSeparator33";
			((Control)W4t).Size = new Size(3, 20);
			((Control)W4t).TabIndex = 9;
			RNj.BackColor = Color.FromArgb(26, 26, 26);
			RNj.Controls.Add(TN3);
			RNj.Controls.Add(VNW);
			RNj.Controls.Add(zNy);
			RNj.Location = new Point(14, 706);
			RNj.Name = "integrityPanel";
			RNj.Size = new Size(667, 40);
			RNj.TabIndex = 13;
			RNj.MouseDown += Cts;
			TN3.Animated = true;
			TN3.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			TN3.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			TN3.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			TN3.CheckedState.InnerColor = Color.White;
			((Control)TN3).Cursor = Cursors.Hand;
			((Control)TN3).Location = new Point(620, 10);
			((Control)TN3).Name = "integritycheckSwitch";
			((Control)TN3).Size = new Size(35, 20);
			((Control)TN3).TabIndex = 10;
			TN3.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			TN3.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			TN3.UncheckedState.InnerBorderColor = Color.White;
			TN3.UncheckedState.InnerColor = Color.White;
			TN3.CheckedChanged += lgI;
			((Control)VNW).BackColor = Color.Transparent;
			((Control)VNW).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)VNW).ForeColor = Color.White;
			VNW.IsContextMenuEnabled = false;
			VNW.IsSelectionEnabled = false;
			((Control)VNW).Location = new Point(13, 11);
			((Control)VNW).Name = "guna2HtmlLabel24";
			((Control)VNW).Size = new Size(89, 18);
			((Control)VNW).TabIndex = 8;
			((Control)VNW).Text = "INTEGRITY CHECK";
			zNy.FillColor = Color.FromArgb(41, 230, 124);
			zNy.FillThickness = 3;
			((Control)zNy).Location = new Point(-2, 10);
			((Control)zNy).Name = "guna2VSeparator14";
			((Control)zNy).Size = new Size(3, 20);
			((Control)zNy).TabIndex = 9;
			PiH.BackColor = Color.FromArgb(26, 26, 26);
			PiH.Controls.Add(KiV);
			PiH.Controls.Add(Riz);
			PiH.Controls.Add(DNh);
			PiH.Location = new Point(14, 660);
			PiH.Name = "l2fPanel";
			PiH.Size = new Size(667, 40);
			PiH.TabIndex = 12;
			PiH.MouseDown += At5;
			KiV.Animated = true;
			KiV.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			KiV.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			KiV.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			KiV.CheckedState.InnerColor = Color.White;
			((Control)KiV).Cursor = Cursors.Hand;
			((Control)KiV).Location = new Point(620, 10);
			((Control)KiV).Name = "localtofieldSwitch";
			((Control)KiV).Size = new Size(35, 20);
			((Control)KiV).TabIndex = 10;
			KiV.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			KiV.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			KiV.UncheckedState.InnerBorderColor = Color.White;
			KiV.UncheckedState.InnerColor = Color.White;
			KiV.CheckedChanged += Tg0;
			((Control)Riz).BackColor = Color.Transparent;
			((Control)Riz).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)Riz).ForeColor = Color.White;
			Riz.IsContextMenuEnabled = false;
			Riz.IsSelectionEnabled = false;
			((Control)Riz).Location = new Point(13, 11);
			((Control)Riz).Name = "guna2HtmlLabel23";
			((Control)Riz).Size = new Size(82, 18);
			((Control)Riz).TabIndex = 8;
			((Control)Riz).Text = "LOCAL TO FIELD";
			DNh.FillColor = Color.FromArgb(41, 230, 124);
			DNh.FillThickness = 3;
			((Control)DNh).Location = new Point(-2, 10);
			((Control)DNh).Name = "guna2VSeparator13";
			((Control)DNh).Size = new Size(3, 20);
			((Control)DNh).TabIndex = 9;
			FNq.BackColor = Color.FromArgb(26, 26, 26);
			FNq.Controls.Add(O4M);
			FNq.Controls.Add(p4D);
			FNq.Controls.Add(wNt);
			FNq.Controls.Add(tNg);
			FNq.Controls.Add(mNi);
			FNq.Location = new Point(14, 614);
			FNq.Name = "refproxyPanel";
			FNq.Size = new Size(667, 40);
			FNq.TabIndex = 11;
			FNq.MouseDown += PtS;
			O4M.Animated = true;
			O4M.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			O4M.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			O4M.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			O4M.CheckedState.InnerColor = Color.White;
			((Control)O4M).Cursor = Cursors.Hand;
			((Control)O4M).Location = new Point(579, 10);
			((Control)O4M).Name = "delegateRef";
			((Control)O4M).Size = new Size(35, 20);
			((Control)O4M).TabIndex = 12;
			O4M.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			O4M.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			O4M.UncheckedState.InnerBorderColor = Color.White;
			O4M.UncheckedState.InnerColor = Color.White;
			O4M.CheckedChanged += agg;
			((Control)p4D).BackColor = Color.Transparent;
			((Control)p4D).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)p4D).ForeColor = Color.White;
			p4D.IsContextMenuEnabled = false;
			p4D.IsSelectionEnabled = false;
			((Control)p4D).Location = new Point(496, 11);
			((Control)p4D).Name = "guna2HtmlLabel10";
			((Control)p4D).Size = new Size(78, 18);
			((Control)p4D).TabIndex = 11;
			((Control)p4D).Text = "Delegate mode";
			wNt.Animated = true;
			wNt.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			wNt.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			wNt.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			wNt.CheckedState.InnerColor = Color.White;
			((Control)wNt).Cursor = Cursors.Hand;
			((Control)wNt).Location = new Point(620, 10);
			((Control)wNt).Name = "referenceproxySwitch";
			((Control)wNt).Size = new Size(35, 20);
			((Control)wNt).TabIndex = 10;
			wNt.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			wNt.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			wNt.UncheckedState.InnerBorderColor = Color.White;
			wNt.UncheckedState.InnerColor = Color.White;
			wNt.CheckedChanged += Bg9;
			((Control)tNg).BackColor = Color.Transparent;
			((Control)tNg).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)tNg).ForeColor = Color.White;
			tNg.IsContextMenuEnabled = false;
			tNg.IsSelectionEnabled = false;
			((Control)tNg).Location = new Point(13, 11);
			((Control)tNg).Name = "guna2HtmlLabel22";
			((Control)tNg).Size = new Size(97, 18);
			((Control)tNg).TabIndex = 8;
			((Control)tNg).Text = "REFERENCE PROXY";
			mNi.FillColor = Color.FromArgb(41, 230, 124);
			mNi.FillThickness = 3;
			((Control)mNi).Location = new Point(-2, 10);
			((Control)mNi).Name = "guna2VSeparator12";
			((Control)mNi).Size = new Size(3, 20);
			((Control)mNi).TabIndex = 9;
			jNN.BackColor = Color.FromArgb(26, 26, 26);
			jNN.Controls.Add(pNP);
			jNN.Controls.Add(cN1);
			jNN.Controls.Add(hN4);
			jNN.Location = new Point(14, 568);
			jNN.Name = "resourcesPanel";
			jNN.Size = new Size(667, 40);
			jNN.TabIndex = 11;
			jNN.MouseDown += gtG;
			pNP.Animated = true;
			pNP.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			pNP.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			pNP.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			pNP.CheckedState.InnerColor = Color.White;
			((Control)pNP).Cursor = Cursors.Hand;
			((Control)pNP).Location = new Point(620, 10);
			((Control)pNP).Name = "encoderesourcesSwitch";
			((Control)pNP).Size = new Size(35, 20);
			((Control)pNP).TabIndex = 10;
			pNP.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			pNP.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			pNP.UncheckedState.InnerBorderColor = Color.White;
			pNP.UncheckedState.InnerColor = Color.White;
			pNP.CheckedChanged += tge;
			((Control)cN1).BackColor = Color.Transparent;
			((Control)cN1).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)cN1).ForeColor = Color.White;
			cN1.IsContextMenuEnabled = false;
			cN1.IsSelectionEnabled = false;
			((Control)cN1).Location = new Point(13, 11);
			((Control)cN1).Name = "guna2HtmlLabel21";
			((Control)cN1).Size = new Size(182, 18);
			((Control)cN1).TabIndex = 8;
			((Control)cN1).Text = "ENCRYPT & COMPRESS RESOURCES";
			hN4.FillColor = Color.FromArgb(41, 230, 124);
			hN4.FillThickness = 3;
			((Control)hN4).Location = new Point(-2, 10);
			((Control)hN4).Name = "guna2VSeparator11";
			((Control)hN4).Size = new Size(3, 20);
			((Control)hN4).TabIndex = 9;
			lN2.BackColor = Color.FromArgb(26, 26, 26);
			lN2.Controls.Add(qNZ);
			lN2.Controls.Add(ONC);
			lN2.Controls.Add(dNT);
			lN2.Location = new Point(14, 522);
			lN2.Name = "stringsPanel";
			lN2.Size = new Size(667, 40);
			lN2.TabIndex = 11;
			lN2.MouseDown += ktk;
			qNZ.Animated = true;
			qNZ.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			qNZ.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			qNZ.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			qNZ.CheckedState.InnerColor = Color.White;
			((Control)qNZ).Cursor = Cursors.Hand;
			((Control)qNZ).Location = new Point(620, 10);
			((Control)qNZ).Name = "encodestringsSwitch";
			((Control)qNZ).Size = new Size(35, 20);
			((Control)qNZ).TabIndex = 10;
			qNZ.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			qNZ.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			qNZ.UncheckedState.InnerBorderColor = Color.White;
			qNZ.UncheckedState.InnerColor = Color.White;
			qNZ.CheckedChanged += Egd;
			((Control)ONC).BackColor = Color.Transparent;
			((Control)ONC).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)ONC).ForeColor = Color.White;
			ONC.IsContextMenuEnabled = false;
			ONC.IsSelectionEnabled = false;
			((Control)ONC).Location = new Point(13, 11);
			((Control)ONC).Name = "guna2HtmlLabel20";
			((Control)ONC).Size = new Size(204, 18);
			((Control)ONC).TabIndex = 8;
			((Control)ONC).Text = "ENCRYPT, COMPRESS & CACHE STRINGS";
			dNT.FillColor = Color.FromArgb(41, 230, 124);
			dNT.FillThickness = 3;
			((Control)dNT).Location = new Point(-2, 10);
			((Control)dNT).Name = "guna2VSeparator10";
			((Control)dNT).Size = new Size(3, 20);
			((Control)dNT).TabIndex = 9;
			sNx.BackColor = Color.FromArgb(26, 26, 26);
			sNx.Controls.Add(bNO);
			sNx.Controls.Add(SNw);
			sNx.Controls.Add(sNf);
			sNx.Controls.Add(ENd);
			sNx.Location = new Point(14, 430);
			sNx.Name = "codemutPanel";
			sNx.Size = new Size(667, 40);
			sNx.TabIndex = 11;
			sNx.MouseDown += JtA;
			((Control)bNO).BackColor = Color.Transparent;
			bNO.CheckedState.ImageSize = new Size(64, 64);
			((Control)bNO).Cursor = Cursors.Hand;
			bNO.HoverState.ImageSize = new Size(19, 19);
			bNO.Image = (Image)componentResourceManager.GetObject("codemutationSettings.Image");
			bNO.ImageOffset = new Point(0, 0);
			bNO.ImageRotate = 0f;
			bNO.ImageSize = new Size(20, 20);
			((Control)bNO).Location = new Point(590, 8);
			((Control)bNO).Name = "codemutationSettings";
			bNO.PressedState.ImageSize = new Size(18, 18);
			((Control)bNO).Size = new Size(24, 24);
			((Control)bNO).TabIndex = 10;
			((Control)bNO).Click += Dtf;
			SNw.Animated = true;
			SNw.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			SNw.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			SNw.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			SNw.CheckedState.InnerColor = Color.White;
			((Control)SNw).Cursor = Cursors.Hand;
			((Control)SNw).Location = new Point(620, 10);
			((Control)SNw).Name = "codemutationSwitch";
			((Control)SNw).Size = new Size(35, 20);
			((Control)SNw).TabIndex = 10;
			SNw.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			SNw.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			SNw.UncheckedState.InnerBorderColor = Color.White;
			SNw.UncheckedState.InnerColor = Color.White;
			SNw.CheckedChanged += Xgo;
			((Control)sNf).BackColor = Color.Transparent;
			((Control)sNf).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)sNf).ForeColor = Color.White;
			sNf.IsContextMenuEnabled = false;
			sNf.IsSelectionEnabled = false;
			((Control)sNf).Location = new Point(13, 11);
			((Control)sNf).Name = "guna2HtmlLabel19";
			((Control)sNf).Size = new Size(83, 18);
			((Control)sNf).TabIndex = 8;
			((Control)sNf).Text = "CODE MUTATION";
			ENd.FillColor = Color.FromArgb(41, 230, 124);
			ENd.FillThickness = 3;
			((Control)ENd).Location = new Point(-2, 10);
			((Control)ENd).Name = "guna2VSeparator9";
			((Control)ENd).Size = new Size(3, 20);
			((Control)ENd).TabIndex = 9;
			ENe.BackColor = Color.FromArgb(26, 26, 26);
			ENe.Controls.Add(aN9);
			ENe.Controls.Add(NN0);
			ENe.Controls.Add(BNI);
			ENe.Controls.Add(NNQ);
			ENe.Location = new Point(14, 384);
			ENe.Name = "cflowPanel";
			ENe.Size = new Size(667, 40);
			ENe.TabIndex = 11;
			ENe.MouseDown += htJ;
			((Control)aN9).BackColor = Color.Transparent;
			aN9.CheckedState.ImageSize = new Size(64, 64);
			((Control)aN9).Cursor = Cursors.Hand;
			aN9.HoverState.ImageSize = new Size(19, 19);
			aN9.Image = (Image)componentResourceManager.GetObject("controlflowSettings.Image");
			aN9.ImageOffset = new Point(0, 0);
			aN9.ImageRotate = 0f;
			aN9.ImageSize = new Size(20, 20);
			((Control)aN9).Location = new Point(590, 8);
			((Control)aN9).Name = "controlflowSettings";
			aN9.PressedState.ImageSize = new Size(18, 18);
			((Control)aN9).Size = new Size(24, 24);
			((Control)aN9).TabIndex = 10;
			((Control)aN9).Click += dtw;
			NN0.Animated = true;
			NN0.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			NN0.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			NN0.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			NN0.CheckedState.InnerColor = Color.White;
			((Control)NN0).Cursor = Cursors.Hand;
			((Control)NN0).Location = new Point(620, 10);
			((Control)NN0).Name = "controlflowSwitch";
			((Control)NN0).Size = new Size(35, 20);
			((Control)NN0).TabIndex = 10;
			NN0.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			NN0.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			NN0.UncheckedState.InnerBorderColor = Color.White;
			NN0.UncheckedState.InnerColor = Color.White;
			NN0.CheckedChanged += Cgx;
			((Control)BNI).BackColor = Color.Transparent;
			((Control)BNI).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)BNI).ForeColor = Color.White;
			BNI.IsContextMenuEnabled = false;
			BNI.IsSelectionEnabled = false;
			((Control)BNI).Location = new Point(13, 11);
			((Control)BNI).Name = "guna2HtmlLabel18";
			((Control)BNI).Size = new Size(80, 18);
			((Control)BNI).TabIndex = 8;
			((Control)BNI).Text = "CONTROL FLOW";
			NNQ.FillColor = Color.FromArgb(41, 230, 124);
			NNQ.FillThickness = 3;
			((Control)NNQ).Location = new Point(-2, 10);
			((Control)NNQ).Name = "guna2VSeparator8";
			((Control)NNQ).Size = new Size(3, 20);
			((Control)NNQ).TabIndex = 9;
			RNF.BackColor = Color.FromArgb(26, 26, 26);
			RNF.Controls.Add(aNm);
			RNF.Controls.Add(kNM);
			RNF.Controls.Add(SND);
			RNF.Location = new Point(14, 338);
			RNF.Name = "antivirtPanel";
			RNF.Size = new Size(667, 40);
			RNF.TabIndex = 11;
			RNF.MouseDown += YtL;
			aNm.Animated = true;
			aNm.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			aNm.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			aNm.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			aNm.CheckedState.InnerColor = Color.White;
			((Control)aNm).Cursor = Cursors.Hand;
			((Control)aNm).Location = new Point(620, 10);
			((Control)aNm).Name = "antivirtualmachineSwitch";
			((Control)aNm).Size = new Size(35, 20);
			((Control)aNm).TabIndex = 10;
			aNm.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			aNm.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			aNm.UncheckedState.InnerBorderColor = Color.White;
			aNm.UncheckedState.InnerColor = Color.White;
			aNm.CheckedChanged += ngT;
			((Control)kNM).BackColor = Color.Transparent;
			((Control)kNM).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)kNM).ForeColor = Color.White;
			kNM.IsContextMenuEnabled = false;
			kNM.IsSelectionEnabled = false;
			((Control)kNM).Location = new Point(13, 11);
			((Control)kNM).Name = "guna2HtmlLabel17";
			((Control)kNM).Size = new Size(118, 18);
			((Control)kNM).TabIndex = 8;
			((Control)kNM).Text = "ANTI VIRTUAL MACHINE";
			SND.FillColor = Color.FromArgb(41, 230, 124);
			SND.FillThickness = 3;
			((Control)SND).Location = new Point(-2, 10);
			((Control)SND).Name = "guna2VSeparator7";
			((Control)SND).Size = new Size(3, 20);
			((Control)SND).TabIndex = 9;
			DN8.BackColor = Color.FromArgb(26, 26, 26);
			DN8.Controls.Add(ENo);
			DN8.Controls.Add(UNB);
			DN8.Controls.Add(xNv);
			DN8.Location = new Point(14, 154);
			DN8.Name = "antidumpPanel";
			DN8.Size = new Size(667, 40);
			DN8.TabIndex = 11;
			DN8.MouseDown += Rty;
			ENo.Animated = true;
			ENo.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			ENo.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			ENo.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			ENo.CheckedState.InnerColor = Color.White;
			((Control)ENo).Cursor = Cursors.Hand;
			((Control)ENo).Location = new Point(620, 10);
			((Control)ENo).Name = "antidumpSwitch";
			((Control)ENo).Size = new Size(35, 20);
			((Control)ENo).TabIndex = 10;
			ENo.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			ENo.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			ENo.UncheckedState.InnerBorderColor = Color.White;
			ENo.UncheckedState.InnerColor = Color.White;
			ENo.CheckedChanged += tgC;
			((Control)UNB).BackColor = Color.Transparent;
			((Control)UNB).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)UNB).ForeColor = Color.White;
			UNB.IsContextMenuEnabled = false;
			UNB.IsSelectionEnabled = false;
			((Control)UNB).Location = new Point(13, 11);
			((Control)UNB).Name = "guna2HtmlLabel16";
			((Control)UNB).Size = new Size(58, 18);
			((Control)UNB).TabIndex = 8;
			((Control)UNB).Text = "ANTI DUMP";
			xNv.FillColor = Color.FromArgb(41, 230, 124);
			xNv.FillThickness = 3;
			((Control)xNv).Location = new Point(-2, 10);
			((Control)xNv).Name = "guna2VSeparator6";
			((Control)xNv).Size = new Size(3, 20);
			((Control)xNv).TabIndex = 9;
			KNu.BackColor = Color.FromArgb(26, 26, 26);
			KNu.Controls.Add(nNb);
			KNu.Controls.Add(PNE);
			KNu.Controls.Add(pNR);
			KNu.Location = new Point(14, 108);
			KNu.Name = "antidebugPanel";
			KNu.Size = new Size(667, 40);
			KNu.TabIndex = 12;
			KNu.MouseDown += otW;
			nNb.Animated = true;
			nNb.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			nNb.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			nNb.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			nNb.CheckedState.InnerColor = Color.White;
			((Control)nNb).Cursor = Cursors.Hand;
			((Control)nNb).Location = new Point(620, 10);
			((Control)nNb).Name = "antidebugSwitch";
			((Control)nNb).Size = new Size(35, 20);
			((Control)nNb).TabIndex = 10;
			nNb.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			nNb.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			nNb.UncheckedState.InnerBorderColor = Color.White;
			nNb.UncheckedState.InnerColor = Color.White;
			nNb.CheckedChanged += PgZ;
			((Control)PNE).BackColor = Color.Transparent;
			((Control)PNE).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)PNE).ForeColor = Color.White;
			PNE.IsContextMenuEnabled = false;
			PNE.IsSelectionEnabled = false;
			((Control)PNE).Location = new Point(13, 11);
			((Control)PNE).Name = "guna2HtmlLabel15";
			((Control)PNE).Size = new Size(62, 18);
			((Control)PNE).TabIndex = 8;
			((Control)PNE).Text = "ANTI DEBUG";
			pNR.FillColor = Color.FromArgb(41, 230, 124);
			pNR.FillThickness = 3;
			((Control)pNR).Location = new Point(-2, 10);
			((Control)pNR).Name = "guna2VSeparator5";
			((Control)pNR).Size = new Size(3, 20);
			((Control)pNR).TabIndex = 9;
			ANY.BackColor = Color.FromArgb(26, 26, 26);
			ANY.Controls.Add(lNU);
			ANY.Controls.Add(yNa);
			ANY.Controls.Add(fNp);
			ANY.Location = new Point(14, 62);
			ANY.Name = "antidecPanel";
			ANY.Size = new Size(667, 40);
			ANY.TabIndex = 11;
			ANY.MouseDown += ut3;
			lNU.Animated = true;
			lNU.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			lNU.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			lNU.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			lNU.CheckedState.InnerColor = Color.White;
			((Control)lNU).Cursor = Cursors.Hand;
			((Control)lNU).Location = new Point(620, 10);
			((Control)lNU).Name = "antidecompilerSwitch";
			((Control)lNU).Size = new Size(35, 20);
			((Control)lNU).TabIndex = 10;
			lNU.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			lNU.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			lNU.UncheckedState.InnerBorderColor = Color.White;
			lNU.UncheckedState.InnerColor = Color.White;
			lNU.CheckedChanged += fg2;
			((Control)yNa).BackColor = Color.Transparent;
			((Control)yNa).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)yNa).ForeColor = Color.White;
			yNa.IsContextMenuEnabled = false;
			yNa.IsSelectionEnabled = false;
			((Control)yNa).Location = new Point(13, 11);
			((Control)yNa).Name = "guna2HtmlLabel14";
			((Control)yNa).Size = new Size(93, 18);
			((Control)yNa).TabIndex = 8;
			((Control)yNa).Text = "ANTI DECOMPILER";
			fNp.FillColor = Color.FromArgb(41, 230, 124);
			fNp.FillThickness = 3;
			((Control)fNp).Location = new Point(-2, 10);
			((Control)fNp).Name = "guna2VSeparator4";
			((Control)fNp).Size = new Size(3, 20);
			((Control)fNp).TabIndex = 9;
			tiX.BackColor = Color.FromArgb(26, 26, 26);
			tiX.Controls.Add(xir);
			tiX.Controls.Add(Pin);
			tiX.Controls.Add(ciK);
			tiX.Controls.Add(ti6);
			tiX.Location = new Point(14, 16);
			tiX.Name = "anticrackPanel";
			tiX.Size = new Size(667, 40);
			tiX.TabIndex = 7;
			tiX.MouseDown += wtj;
			((Control)xir).BackColor = Color.Transparent;
			xir.CheckedState.ImageSize = new Size(64, 64);
			((Control)xir).Cursor = Cursors.Hand;
			xir.HoverState.ImageSize = new Size(19, 19);
			xir.Image = (Image)componentResourceManager.GetObject("anticrackSettings.Image");
			xir.ImageOffset = new Point(0, 0);
			xir.ImageRotate = 0f;
			xir.ImageSize = new Size(20, 20);
			((Control)xir).Location = new Point(590, 8);
			((Control)xir).Name = "anticrackSettings";
			xir.PressedState.ImageSize = new Size(18, 18);
			((Control)xir).Size = new Size(24, 24);
			((Control)xir).TabIndex = 10;
			((Control)xir).Click += JtO;
			Pin.Animated = true;
			((Control)Pin).BackColor = Color.Transparent;
			Pin.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			Pin.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			Pin.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			Pin.CheckedState.InnerColor = Color.White;
			((Control)Pin).Cursor = Cursors.Hand;
			((Control)Pin).Location = new Point(620, 10);
			((Control)Pin).Name = "anticrackSwitch";
			((Control)Pin).Size = new Size(35, 20);
			((Control)Pin).TabIndex = 10;
			Pin.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			Pin.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			Pin.UncheckedState.InnerBorderColor = Color.White;
			Pin.UncheckedState.InnerColor = Color.White;
			Pin.CheckedChanged += ug4;
			((Control)ciK).BackColor = Color.Transparent;
			((Control)ciK).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)ciK).ForeColor = Color.White;
			ciK.IsContextMenuEnabled = false;
			ciK.IsSelectionEnabled = false;
			((Control)ciK).Location = new Point(13, 11);
			((Control)ciK).Name = "guna2HtmlLabel13";
			((Control)ciK).Size = new Size(63, 18);
			((Control)ciK).TabIndex = 8;
			((Control)ciK).Text = "ANTI CRACK";
			ti6.FillColor = Color.FromArgb(41, 230, 124);
			ti6.FillThickness = 3;
			((Control)ti6).Location = new Point(-2, 10);
			((Control)ti6).Name = "guna2VSeparator3";
			((Control)ti6).Size = new Size(3, 20);
			((Control)ti6).TabIndex = 9;
			ONA.BackColor = Color.FromArgb(20, 20, 20);
			ONA.Controls.Add(l4Q);
			ONA.Controls.Add(N1m);
			ONA.Controls.Add(K10);
			ONA.Controls.Add(gPV);
			ONA.Controls.Add(mNV);
			ONA.Controls.Add(lNz);
			ONA.Controls.Add(GNk);
			ONA.Controls.Add(ANs);
			ONA.Controls.Add(WNX);
			ONA.Controls.Add(xNn);
			ONA.Controls.Add(iNH);
			ONA.Location = new Point(279, 39);
			ONA.Name = "anticrackPage";
			ONA.Size = new Size(721, 481);
			ONA.TabIndex = 10;
			l4Q.BorderColor = Color.FromArgb(44, 44, 44);
			l4Q.BorderRadius = 6;
			l4Q.BorderThickness = 1;
			((Control)l4Q).Cursor = Cursors.Hand;
			l4Q.DisabledState.BorderColor = Color.DarkGray;
			l4Q.DisabledState.CustomBorderColor = Color.DarkGray;
			l4Q.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			l4Q.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			l4Q.FillColor = Color.FromArgb(26, 26, 26);
			((Control)l4Q).Font = new Font("Bahnschrift SemiCondensed", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)l4Q).ForeColor = Color.White;
			l4Q.HoverState.FillColor = Color.FromArgb(40, 40, 40);
			l4Q.HoverState.ForeColor = Color.White;
			l4Q.Image = Resources.edit_file_24px;
			l4Q.ImageAlign = HorizontalAlignment.Left;
			l4Q.ImageOffset = new Point(10, 0);
			l4Q.ImageSize = new Size(24, 24);
			((Control)l4Q).Location = new Point(42, 402);
			((Control)l4Q).Name = "editProcList";
			((Control)l4Q).Size = new Size(206, 44);
			((Control)l4Q).TabIndex = 17;
			((Control)l4Q).Text = "EDIT PROCESSES LIST";
			l4Q.TextAlign = HorizontalAlignment.Left;
			l4Q.TextOffset = new Point(14, 0);
			((Control)l4Q).Click += EgR;
			((Control)N1m).AllowDrop = true;
			N1m.BorderColor = Color.FromArgb(44, 44, 44);
			N1m.BorderRadius = 6;
			((Control)N1m).Cursor = Cursors.IBeam;
			N1m.DefaultText = "";
			N1m.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			N1m.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			N1m.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			N1m.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			N1m.FillColor = Color.FromArgb(26, 26, 26);
			N1m.FocusedState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)N1m).Font = new Font("Bahnschrift SemiCondensed", 9f);
			N1m.HoverState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)N1m).Location = new Point(42, 356);
			((Control)N1m).Name = "customMsg";
			N1m.PasswordChar = '\0';
			N1m.PlaceholderForeColor = Color.FromArgb(110, 110, 110);
			N1m.PlaceholderText = "CUSTOM MESSAGE";
			N1m.SelectedText = "";
			((Control)N1m).Size = new Size(410, 38);
			((Control)N1m).TabIndex = 16;
			N1m.TextChanged += GgW;
			K10.BackColor = Color.FromArgb(26, 26, 26);
			K10.Controls.Add(C1I);
			K10.Controls.Add(E1Q);
			K10.Controls.Add(H1F);
			K10.Location = new Point(42, 166);
			K10.Name = "panel1";
			K10.Size = new Size(627, 40);
			K10.TabIndex = 12;
			C1I.Animated = true;
			((Control)C1I).BackColor = Color.Transparent;
			C1I.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			C1I.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			C1I.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			C1I.CheckedState.InnerColor = Color.White;
			((Control)C1I).Cursor = Cursors.Hand;
			((Control)C1I).Location = new Point(581, 10);
			((Control)C1I).Name = "bsodSwitch";
			((Control)C1I).Size = new Size(35, 20);
			((Control)C1I).TabIndex = 10;
			C1I.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			C1I.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			C1I.UncheckedState.InnerBorderColor = Color.White;
			C1I.UncheckedState.InnerColor = Color.White;
			C1I.CheckedChanged += Qgp;
			((Control)E1Q).BackColor = Color.Transparent;
			((Control)E1Q).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)E1Q).ForeColor = Color.White;
			E1Q.IsContextMenuEnabled = false;
			E1Q.IsSelectionEnabled = false;
			((Control)E1Q).Location = new Point(13, 11);
			((Control)E1Q).Name = "guna2HtmlLabel52";
			((Control)E1Q).Size = new Size(123, 18);
			((Control)E1Q).TabIndex = 8;
			((Control)E1Q).Text = "BLUE SCREEN OF DEATH";
			H1F.FillColor = Color.FromArgb(41, 230, 124);
			H1F.FillThickness = 3;
			((Control)H1F).Location = new Point(-2, 10);
			((Control)H1F).Name = "guna2VSeparator1";
			((Control)H1F).Size = new Size(3, 20);
			((Control)H1F).TabIndex = 9;
			((Control)gPV).BackColor = Color.Transparent;
			gPV.CheckedState.ImageSize = new Size(64, 64);
			((Control)gPV).Cursor = Cursors.Hand;
			gPV.HoverState.ImageSize = new Size(63, 63);
			gPV.Image = Resources.back_to_64px;
			gPV.ImageOffset = new Point(0, 0);
			gPV.ImageRotate = 0f;
			((Control)gPV).Location = new Point(635, 395);
			((Control)gPV).Name = "backfromACrack";
			gPV.PressedState.ImageSize = new Size(62, 62);
			((Control)gPV).Size = new Size(64, 64);
			((Control)gPV).TabIndex = 15;
			((Control)gPV).Click += ptx;
			((Control)mNV).AllowDrop = true;
			mNV.BorderColor = Color.FromArgb(44, 44, 44);
			mNV.BorderRadius = 6;
			((Control)mNV).Cursor = Cursors.IBeam;
			mNV.DefaultText = "";
			mNV.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			mNV.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			mNV.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			mNV.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			mNV.FillColor = Color.FromArgb(26, 26, 26);
			mNV.FocusedState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)mNV).Font = new Font("Bahnschrift SemiCondensed", 9f);
			mNV.HoverState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)mNV).Location = new Point(42, 310);
			((Control)mNV).Name = "excludeBox";
			mNV.PasswordChar = '\0';
			mNV.PlaceholderForeColor = Color.FromArgb(110, 110, 110);
			mNV.PlaceholderText = "EXCLUDE PROCESS BY NAME";
			mNV.SelectedText = "";
			((Control)mNV).Size = new Size(410, 38);
			((Control)mNV).TabIndex = 14;
			mNV.TextChanged += ig3;
			((Control)lNz).AllowDrop = true;
			lNz.BorderColor = Color.FromArgb(44, 44, 44);
			lNz.BorderRadius = 6;
			((Control)lNz).Cursor = Cursors.IBeam;
			lNz.DefaultText = "";
			lNz.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			lNz.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			lNz.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			lNz.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			lNz.FillColor = Color.FromArgb(26, 26, 26);
			lNz.FocusedState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)lNz).Font = new Font("Bahnschrift SemiCondensed", 9f);
			lNz.HoverState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)lNz).Location = new Point(42, 264);
			((Control)lNz).Name = "webhookBox";
			lNz.PasswordChar = '\0';
			lNz.PlaceholderForeColor = Color.FromArgb(110, 110, 110);
			lNz.PlaceholderText = "DISCORD WEBHOOK TO RECIEVE CRACKER DATA";
			lNz.SelectedText = "";
			((Control)lNz).Size = new Size(410, 38);
			((Control)lNz).TabIndex = 13;
			lNz.TextChanged += Vgj;
			GNk.BackColor = Color.FromArgb(26, 26, 26);
			GNk.Controls.Add(ENG);
			GNk.Controls.Add(FNS);
			GNk.Controls.Add(HN5);
			GNk.Location = new Point(42, 212);
			GNk.Name = "panel6";
			GNk.Size = new Size(627, 40);
			GNk.TabIndex = 12;
			ENG.Animated = true;
			((Control)ENG).BackColor = Color.Transparent;
			ENG.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			ENG.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			ENG.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			ENG.CheckedState.InnerColor = Color.White;
			((Control)ENG).Cursor = Cursors.Hand;
			((Control)ENG).Location = new Point(581, 10);
			((Control)ENG).Name = "anticrackExclude";
			((Control)ENG).Size = new Size(35, 20);
			((Control)ENG).TabIndex = 10;
			ENG.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			ENG.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			ENG.UncheckedState.InnerBorderColor = Color.White;
			ENG.UncheckedState.InnerColor = Color.White;
			ENG.CheckedChanged += Gga;
			((Control)FNS).BackColor = Color.Transparent;
			((Control)FNS).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)FNS).ForeColor = Color.White;
			FNS.IsContextMenuEnabled = false;
			FNS.IsSelectionEnabled = false;
			((Control)FNS).Location = new Point(13, 11);
			((Control)FNS).Name = "guna2HtmlLabel26";
			((Control)FNS).Size = new Size(99, 18);
			((Control)FNS).TabIndex = 8;
			((Control)FNS).Text = "EXCLUDE PROCESS";
			HN5.FillColor = Color.FromArgb(41, 230, 124);
			HN5.FillThickness = 3;
			((Control)HN5).Location = new Point(-2, 10);
			((Control)HN5).Name = "guna2VSeparator17";
			((Control)HN5).Size = new Size(3, 20);
			((Control)HN5).TabIndex = 9;
			ANs.BackColor = Color.FromArgb(26, 26, 26);
			ANs.Controls.Add(tNc);
			ANs.Controls.Add(mN7);
			ANs.Controls.Add(CNl);
			ANs.Location = new Point(42, 120);
			ANs.Name = "panel5";
			ANs.Size = new Size(627, 40);
			ANs.TabIndex = 11;
			tNc.Animated = true;
			((Control)tNc).BackColor = Color.Transparent;
			tNc.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			tNc.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			tNc.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			tNc.CheckedState.InnerColor = Color.White;
			((Control)tNc).Cursor = Cursors.Hand;
			((Control)tNc).Location = new Point(581, 10);
			((Control)tNc).Name = "anticrackSilentMsg";
			((Control)tNc).Size = new Size(35, 20);
			((Control)tNc).TabIndex = 10;
			tNc.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			tNc.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			tNc.UncheckedState.InnerBorderColor = Color.White;
			tNc.UncheckedState.InnerColor = Color.White;
			tNc.CheckedChanged += ggU;
			((Control)mN7).BackColor = Color.Transparent;
			((Control)mN7).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)mN7).ForeColor = Color.White;
			mN7.IsContextMenuEnabled = false;
			mN7.IsSelectionEnabled = false;
			((Control)mN7).Location = new Point(13, 11);
			((Control)mN7).Name = "guna2HtmlLabel25";
			((Control)mN7).Size = new Size(183, 18);
			((Control)mN7).TabIndex = 8;
			((Control)mN7).Text = "SILENTLY CLOSE WITHOUT MESSAGE";
			CNl.FillColor = Color.FromArgb(41, 230, 124);
			CNl.FillThickness = 3;
			((Control)CNl).Location = new Point(-2, 10);
			((Control)CNl).Name = "guna2VSeparator16";
			((Control)CNl).Size = new Size(3, 20);
			((Control)CNl).TabIndex = 9;
			WNX.BackColor = Color.FromArgb(26, 26, 26);
			WNX.Controls.Add(UNK);
			WNX.Controls.Add(pN6);
			WNX.Controls.Add(lNr);
			WNX.Location = new Point(42, 74);
			WNX.Name = "panel4";
			WNX.Size = new Size(627, 40);
			WNX.TabIndex = 8;
			UNK.Animated = true;
			((Control)UNK).BackColor = Color.Transparent;
			UNK.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			UNK.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			UNK.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			UNK.CheckedState.InnerColor = Color.White;
			((Control)UNK).Cursor = Cursors.Hand;
			((Control)UNK).Location = new Point(581, 10);
			((Control)UNK).Name = "anticrackNormalMode";
			((Control)UNK).Size = new Size(35, 20);
			((Control)UNK).TabIndex = 10;
			UNK.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			UNK.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			UNK.UncheckedState.InnerBorderColor = Color.White;
			UNK.UncheckedState.InnerColor = Color.White;
			UNK.CheckedChanged += WgY;
			((Control)pN6).BackColor = Color.Transparent;
			((Control)pN6).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)pN6).ForeColor = Color.White;
			pN6.IsContextMenuEnabled = false;
			pN6.IsSelectionEnabled = false;
			((Control)pN6).Location = new Point(13, 11);
			((Control)pN6).Name = "guna2HtmlLabel12";
			((Control)pN6).Size = new Size(78, 18);
			((Control)pN6).TabIndex = 8;
			((Control)pN6).Text = "NORMAL MODE";
			lNr.FillColor = Color.FromArgb(41, 230, 124);
			lNr.FillThickness = 3;
			((Control)lNr).Location = new Point(-2, 10);
			((Control)lNr).Name = "guna2VSeparator15";
			((Control)lNr).Size = new Size(3, 20);
			((Control)lNr).TabIndex = 9;
			((Control)xNn).BackColor = Color.Transparent;
			((Control)xNn).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)xNn).ForeColor = Color.White;
			xNn.IsContextMenuEnabled = false;
			xNn.IsSelectionEnabled = false;
			((Control)xNn).Location = new Point(104, 38);
			((Control)xNn).Name = "guna2HtmlLabel11";
			((Control)xNn).Size = new Size(50, 18);
			((Control)xNn).TabIndex = 4;
			((Control)xNn).Text = "SETTINGS";
			((Control)iNH).BackColor = Color.Transparent;
			((Control)iNH).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)iNH).ForeColor = Color.White;
			iNH.IsContextMenuEnabled = false;
			iNH.IsSelectionEnabled = false;
			((Control)iNH).Location = new Point(42, 38);
			((Control)iNH).Name = "guna2HtmlLabel28";
			((Control)iNH).Size = new Size(63, 18);
			((Control)iNH).TabIndex = 3;
			((Control)iNH).Text = "ANTI CRACK";
			KPh.BackColor = Color.FromArgb(20, 20, 20);
			KPh.Controls.Add(u48);
			KPh.Controls.Add(vPH);
			KPh.Controls.Add(iPq);
			KPh.Controls.Add(aPN);
			KPh.Controls.Add(BP2);
			KPh.Controls.Add(EPZ);
			KPh.Location = new Point(279, 39);
			KPh.Name = "controlflowPage";
			KPh.Size = new Size(721, 481);
			KPh.TabIndex = 11;
			u48.BackColor = Color.FromArgb(26, 26, 26);
			u48.Controls.Add(Q4o);
			u48.Controls.Add(L4B);
			u48.Controls.Add(T4v);
			u48.Location = new Point(42, 166);
			u48.Name = "panel7";
			u48.Size = new Size(627, 40);
			u48.TabIndex = 12;
			Q4o.Animated = true;
			((Control)Q4o).BackColor = Color.Transparent;
			Q4o.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			Q4o.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			Q4o.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			Q4o.CheckedState.InnerColor = Color.White;
			((Control)Q4o).Cursor = Cursors.Hand;
			((Control)Q4o).Enabled = false;
			((Control)Q4o).Location = new Point(581, 10);
			((Control)Q4o).Name = "ultraPerfCflowSwitch";
			((Control)Q4o).Size = new Size(35, 20);
			((Control)Q4o).TabIndex = 10;
			Q4o.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			Q4o.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			Q4o.UncheckedState.InnerBorderColor = Color.White;
			Q4o.UncheckedState.InnerColor = Color.White;
			Q4o.CheckedChanged += Bgf;
			((Control)L4B).BackColor = Color.Transparent;
			((Control)L4B).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)L4B).ForeColor = Color.White;
			L4B.IsContextMenuEnabled = false;
			L4B.IsSelectionEnabled = false;
			((Control)L4B).Location = new Point(13, 11);
			((Control)L4B).Name = "guna2HtmlLabel70";
			((Control)L4B).Size = new Size(330, 18);
			((Control)L4B).TabIndex = 8;
			((Control)L4B).Text = "ULTRA PERFORMANCE MODE ( NOT SECURE LIKE OTHER MODES ) !";
			T4v.FillColor = Color.FromArgb(41, 230, 124);
			T4v.FillThickness = 3;
			((Control)T4v).Location = new Point(-2, 10);
			((Control)T4v).Name = "guna2VSeparator38";
			((Control)T4v).Size = new Size(3, 20);
			((Control)T4v).TabIndex = 9;
			((Control)vPH).BackColor = Color.Transparent;
			vPH.CheckedState.ImageSize = new Size(64, 64);
			((Control)vPH).Cursor = Cursors.Hand;
			vPH.HoverState.ImageSize = new Size(63, 63);
			vPH.Image = Resources.back_to_64px;
			vPH.ImageOffset = new Point(0, 0);
			vPH.ImageRotate = 0f;
			((Control)vPH).Location = new Point(635, 395);
			((Control)vPH).Name = "backfromCflow";
			vPH.PressedState.ImageSize = new Size(62, 62);
			((Control)vPH).Size = new Size(64, 64);
			((Control)vPH).TabIndex = 13;
			((Control)vPH).Click += TtT;
			iPq.BackColor = Color.FromArgb(26, 26, 26);
			iPq.Controls.Add(PPt);
			iPq.Controls.Add(gPg);
			iPq.Controls.Add(bPi);
			iPq.Location = new Point(42, 120);
			iPq.Name = "panel9";
			iPq.Size = new Size(627, 40);
			iPq.TabIndex = 11;
			PPt.Animated = true;
			((Control)PPt).BackColor = Color.Transparent;
			PPt.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			PPt.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			PPt.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			PPt.CheckedState.InnerColor = Color.White;
			((Control)PPt).Cursor = Cursors.Hand;
			((Control)PPt).Enabled = false;
			((Control)PPt).Location = new Point(581, 10);
			((Control)PPt).Name = "performancecflowMode";
			((Control)PPt).Size = new Size(35, 20);
			((Control)PPt).TabIndex = 10;
			PPt.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			PPt.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			PPt.UncheckedState.InnerBorderColor = Color.White;
			PPt.UncheckedState.InnerColor = Color.White;
			PPt.CheckedChanged += ngw;
			((Control)gPg).BackColor = Color.Transparent;
			((Control)gPg).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)gPg).ForeColor = Color.White;
			gPg.IsContextMenuEnabled = false;
			gPg.IsSelectionEnabled = false;
			((Control)gPg).Location = new Point(13, 11);
			((Control)gPg).Name = "guna2HtmlLabel29";
			((Control)gPg).Size = new Size(111, 18);
			((Control)gPg).TabIndex = 8;
			((Control)gPg).Text = "PERFORMANCE MODE";
			bPi.FillColor = Color.FromArgb(41, 230, 124);
			bPi.FillThickness = 3;
			((Control)bPi).Location = new Point(-2, 10);
			((Control)bPi).Name = "guna2VSeparator19";
			((Control)bPi).Size = new Size(3, 20);
			((Control)bPi).TabIndex = 9;
			aPN.BackColor = Color.FromArgb(26, 26, 26);
			aPN.Controls.Add(wPP);
			aPN.Controls.Add(BP1);
			aPN.Controls.Add(CP4);
			aPN.Location = new Point(42, 74);
			aPN.Name = "panel10";
			aPN.Size = new Size(627, 40);
			aPN.TabIndex = 8;
			wPP.Animated = true;
			((Control)wPP).BackColor = Color.Transparent;
			wPP.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			wPP.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			wPP.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			wPP.CheckedState.InnerColor = Color.White;
			((Control)wPP).Cursor = Cursors.Hand;
			((Control)wPP).Enabled = false;
			((Control)wPP).Location = new Point(581, 10);
			((Control)wPP).Name = "strongcflowMode";
			((Control)wPP).Size = new Size(35, 20);
			((Control)wPP).TabIndex = 10;
			wPP.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			wPP.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			wPP.UncheckedState.InnerBorderColor = Color.White;
			wPP.UncheckedState.InnerColor = Color.White;
			wPP.CheckedChanged += igO;
			((Control)BP1).BackColor = Color.Transparent;
			((Control)BP1).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)BP1).ForeColor = Color.White;
			BP1.IsContextMenuEnabled = false;
			BP1.IsSelectionEnabled = false;
			((Control)BP1).Location = new Point(13, 11);
			((Control)BP1).Name = "guna2HtmlLabel30";
			((Control)BP1).Size = new Size(75, 18);
			((Control)BP1).TabIndex = 8;
			((Control)BP1).Text = "STRONG MODE";
			CP4.FillColor = Color.FromArgb(41, 230, 124);
			CP4.FillThickness = 3;
			((Control)CP4).Location = new Point(-2, 10);
			((Control)CP4).Name = "guna2VSeparator20";
			((Control)CP4).Size = new Size(3, 20);
			((Control)CP4).TabIndex = 9;
			((Control)BP2).BackColor = Color.Transparent;
			((Control)BP2).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)BP2).ForeColor = Color.White;
			BP2.IsContextMenuEnabled = false;
			BP2.IsSelectionEnabled = false;
			((Control)BP2).Location = new Point(122, 38);
			((Control)BP2).Name = "guna2HtmlLabel31";
			((Control)BP2).Size = new Size(50, 18);
			((Control)BP2).TabIndex = 4;
			((Control)BP2).Text = "SETTINGS";
			((Control)EPZ).BackColor = Color.Transparent;
			((Control)EPZ).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)EPZ).ForeColor = Color.White;
			EPZ.IsContextMenuEnabled = false;
			EPZ.IsSelectionEnabled = false;
			((Control)EPZ).Location = new Point(42, 38);
			((Control)EPZ).Name = "guna2HtmlLabel32";
			((Control)EPZ).Size = new Size(80, 18);
			((Control)EPZ).TabIndex = 3;
			((Control)EPZ).Text = "CONTROL FLOW";
			ePC.BackColor = Color.FromArgb(20, 20, 20);
			ePC.Controls.Add(H45);
			ePC.Controls.Add(wPn);
			ePC.Controls.Add(OPT);
			ePC.Controls.Add(iPf);
			ePC.Controls.Add(DPr);
			ePC.Controls.Add(YP0);
			ePC.Location = new Point(279, 39);
			ePC.Name = "codemutationPage";
			ePC.Size = new Size(721, 481);
			ePC.TabIndex = 12;
			H45.BackColor = Color.FromArgb(26, 26, 26);
			H45.Controls.Add(w4s);
			H45.Controls.Add(R4c);
			H45.Controls.Add(e47);
			H45.Location = new Point(42, 166);
			H45.Name = "panel13";
			H45.Size = new Size(627, 40);
			H45.TabIndex = 12;
			w4s.Animated = true;
			((Control)w4s).BackColor = Color.Transparent;
			w4s.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			w4s.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			w4s.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			w4s.CheckedState.InnerColor = Color.White;
			((Control)w4s).Cursor = Cursors.Hand;
			((Control)w4s).Enabled = false;
			((Control)w4s).Location = new Point(581, 10);
			((Control)w4s).Name = "aggressiveMutationMode";
			((Control)w4s).Size = new Size(35, 20);
			((Control)w4s).TabIndex = 10;
			w4s.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			w4s.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			w4s.UncheckedState.InnerBorderColor = Color.White;
			w4s.UncheckedState.InnerColor = Color.White;
			w4s.CheckedChanged += dgB;
			((Control)R4c).BackColor = Color.Transparent;
			((Control)R4c).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)R4c).ForeColor = Color.White;
			R4c.IsContextMenuEnabled = false;
			R4c.IsSelectionEnabled = false;
			((Control)R4c).Location = new Point(13, 11);
			((Control)R4c).Name = "guna2HtmlLabel75";
			((Control)R4c).Size = new Size(98, 18);
			((Control)R4c).TabIndex = 8;
			((Control)R4c).Text = "AGGRESSIVE MODE";
			e47.FillColor = Color.FromArgb(41, 230, 124);
			e47.FillThickness = 3;
			((Control)e47).Location = new Point(-2, 10);
			((Control)e47).Name = "guna2VSeparator42";
			((Control)e47).Size = new Size(3, 20);
			((Control)e47).TabIndex = 9;
			((Control)wPn).BackColor = Color.Transparent;
			wPn.CheckedState.ImageSize = new Size(64, 64);
			((Control)wPn).Cursor = Cursors.Hand;
			wPn.HoverState.ImageSize = new Size(63, 63);
			wPn.Image = Resources.back_to_64px;
			wPn.ImageOffset = new Point(0, 0);
			wPn.ImageRotate = 0f;
			((Control)wPn).Location = new Point(635, 395);
			((Control)wPn).Name = "backfromMutation";
			wPn.PressedState.ImageSize = new Size(62, 62);
			((Control)wPn).Size = new Size(64, 64);
			((Control)wPn).TabIndex = 12;
			((Control)wPn).Click += QtC;
			OPT.BackColor = Color.FromArgb(26, 26, 26);
			OPT.Controls.Add(IPx);
			OPT.Controls.Add(NPO);
			OPT.Controls.Add(APw);
			OPT.Location = new Point(42, 74);
			OPT.Name = "panel11";
			OPT.Size = new Size(627, 40);
			OPT.TabIndex = 11;
			IPx.Animated = true;
			((Control)IPx).BackColor = Color.Transparent;
			IPx.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			IPx.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			IPx.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			IPx.CheckedState.InnerColor = Color.White;
			((Control)IPx).Cursor = Cursors.Hand;
			((Control)IPx).Enabled = false;
			((Control)IPx).Location = new Point(581, 10);
			((Control)IPx).Name = "performancemutationMode";
			((Control)IPx).Size = new Size(35, 20);
			((Control)IPx).TabIndex = 10;
			IPx.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			IPx.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			IPx.UncheckedState.InnerBorderColor = Color.White;
			IPx.UncheckedState.InnerColor = Color.White;
			IPx.CheckedChanged += Rgu;
			((Control)NPO).BackColor = Color.Transparent;
			((Control)NPO).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)NPO).ForeColor = Color.White;
			NPO.IsContextMenuEnabled = false;
			NPO.IsSelectionEnabled = false;
			((Control)NPO).Location = new Point(13, 11);
			((Control)NPO).Name = "guna2HtmlLabel27";
			((Control)NPO).Size = new Size(111, 18);
			((Control)NPO).TabIndex = 8;
			((Control)NPO).Text = "PERFORMANCE MODE";
			APw.FillColor = Color.FromArgb(41, 230, 124);
			APw.FillThickness = 3;
			((Control)APw).Location = new Point(-2, 10);
			((Control)APw).Name = "guna2VSeparator18";
			((Control)APw).Size = new Size(3, 20);
			((Control)APw).TabIndex = 9;
			iPf.BackColor = Color.FromArgb(26, 26, 26);
			iPf.Controls.Add(KPd);
			iPf.Controls.Add(lPe);
			iPf.Controls.Add(rP9);
			iPf.Location = new Point(42, 120);
			iPf.Name = "panel12";
			iPf.Size = new Size(627, 40);
			iPf.TabIndex = 8;
			KPd.Animated = true;
			((Control)KPd).BackColor = Color.Transparent;
			KPd.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			KPd.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			KPd.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			KPd.CheckedState.InnerColor = Color.White;
			((Control)KPd).Cursor = Cursors.Hand;
			((Control)KPd).Enabled = false;
			((Control)KPd).Location = new Point(581, 10);
			((Control)KPd).Name = "strongmutationMode";
			((Control)KPd).Size = new Size(35, 20);
			((Control)KPd).TabIndex = 10;
			KPd.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			KPd.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			KPd.UncheckedState.InnerBorderColor = Color.White;
			KPd.UncheckedState.InnerColor = Color.White;
			KPd.CheckedChanged += bgv;
			((Control)lPe).BackColor = Color.Transparent;
			((Control)lPe).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)lPe).ForeColor = Color.White;
			lPe.IsContextMenuEnabled = false;
			lPe.IsSelectionEnabled = false;
			((Control)lPe).Location = new Point(13, 11);
			((Control)lPe).Name = "guna2HtmlLabel33";
			((Control)lPe).Size = new Size(75, 18);
			((Control)lPe).TabIndex = 8;
			((Control)lPe).Text = "STRONG MODE";
			rP9.FillColor = Color.FromArgb(41, 230, 124);
			rP9.FillThickness = 3;
			((Control)rP9).Location = new Point(-2, 10);
			((Control)rP9).Name = "guna2VSeparator21";
			((Control)rP9).Size = new Size(3, 20);
			((Control)rP9).TabIndex = 9;
			((Control)DPr).BackColor = Color.Transparent;
			((Control)DPr).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)DPr).ForeColor = Color.White;
			DPr.IsContextMenuEnabled = false;
			DPr.IsSelectionEnabled = false;
			((Control)DPr).Location = new Point(125, 38);
			((Control)DPr).Name = "guna2HtmlLabel34";
			((Control)DPr).Size = new Size(50, 18);
			((Control)DPr).TabIndex = 4;
			((Control)DPr).Text = "SETTINGS";
			((Control)YP0).BackColor = Color.Transparent;
			((Control)YP0).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)YP0).ForeColor = Color.White;
			YP0.IsContextMenuEnabled = false;
			YP0.IsSelectionEnabled = false;
			((Control)YP0).Location = new Point(42, 38);
			((Control)YP0).Name = "guna2HtmlLabel35";
			((Control)YP0).Size = new Size(83, 18);
			((Control)YP0).TabIndex = 3;
			((Control)YP0).Text = "CODE MUTATION";
			RPI.BackColor = Color.FromArgb(20, 20, 20);
			RPI.Controls.Add(xPQ);
			RPI.Controls.Add(BP6);
			RPI.Controls.Add(XPD);
			RPI.Location = new Point(279, 39);
			RPI.Name = "codeencPage";
			RPI.Size = new Size(721, 481);
			RPI.TabIndex = 13;
			xPQ.BackColor = Color.FromArgb(26, 26, 26);
			xPQ.Controls.Add(MPF);
			xPQ.Controls.Add(yPm);
			xPQ.Controls.Add(rPM);
			xPQ.Location = new Point(42, 74);
			xPQ.Name = "codeencPanel";
			xPQ.Size = new Size(627, 40);
			xPQ.TabIndex = 8;
			xPQ.MouseDown += dtK;
			MPF.Animated = true;
			((Control)MPF).BackColor = Color.Transparent;
			MPF.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			MPF.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			MPF.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			MPF.CheckedState.InnerColor = Color.White;
			((Control)MPF).Cursor = Cursors.Hand;
			((Control)MPF).Location = new Point(581, 10);
			((Control)MPF).Name = "codeencSwitch";
			((Control)MPF).Size = new Size(35, 20);
			((Control)MPF).TabIndex = 10;
			MPF.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			MPF.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			MPF.UncheckedState.InnerBorderColor = Color.White;
			MPF.UncheckedState.InnerColor = Color.White;
			MPF.CheckedChanged += HgD;
			((Control)yPm).BackColor = Color.Transparent;
			((Control)yPm).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)yPm).ForeColor = Color.White;
			yPm.IsContextMenuEnabled = false;
			yPm.IsSelectionEnabled = false;
			((Control)yPm).Location = new Point(13, 11);
			((Control)yPm).Name = "guna2HtmlLabel37";
			((Control)yPm).Size = new Size(144, 18);
			((Control)yPm).TabIndex = 8;
			((Control)yPm).Text = "ENCRYPT & STORE METHODS";
			rPM.FillColor = Color.FromArgb(41, 230, 124);
			rPM.FillThickness = 3;
			((Control)rPM).Location = new Point(-2, 10);
			((Control)rPM).Name = "guna2VSeparator23";
			((Control)rPM).Size = new Size(3, 20);
			((Control)rPM).TabIndex = 9;
			((Control)BP6).BackColor = Color.Transparent;
			((Control)BP6).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)BP6).ForeColor = Color.White;
			BP6.IsContextMenuEnabled = false;
			BP6.IsSelectionEnabled = false;
			((Control)BP6).Location = new Point(137, 38);
			((Control)BP6).Name = "guna2HtmlLabel38";
			((Control)BP6).Size = new Size(50, 18);
			((Control)BP6).TabIndex = 4;
			((Control)BP6).Text = "SETTINGS";
			((Control)XPD).BackColor = Color.Transparent;
			((Control)XPD).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)XPD).ForeColor = Color.White;
			XPD.IsContextMenuEnabled = false;
			XPD.IsSelectionEnabled = false;
			((Control)XPD).Location = new Point(42, 38);
			((Control)XPD).Name = "guna2HtmlLabel39";
			((Control)XPD).Size = new Size(95, 18);
			((Control)XPD).TabIndex = 3;
			((Control)XPD).Text = "CODE ENCRYPTION";
			IP8.BackColor = Color.FromArgb(20, 20, 20);
			IP8.Controls.Add(w1r);
			IP8.Controls.Add(oPE);
			IP8.Controls.Add(TPR);
			IP8.Controls.Add(NPY);
			IP8.Controls.Add(APU);
			IP8.Controls.Add(vPa);
			IP8.Controls.Add(CPo);
			IP8.Controls.Add(KPK);
			IP8.Controls.Add(BPb);
			IP8.Location = new Point(279, 39);
			IP8.Name = "renamerPage";
			IP8.Size = new Size(721, 481);
			IP8.TabIndex = 14;
			w1r.BackColor = Color.FromArgb(26, 26, 26);
			w1r.Controls.Add(s1n);
			w1r.Controls.Add(Y1H);
			w1r.Controls.Add(q1V);
			w1r.Location = new Point(42, 74);
			w1r.Name = "cfexPanel";
			w1r.Size = new Size(627, 40);
			w1r.TabIndex = 16;
			w1r.MouseDown += atl;
			s1n.Animated = true;
			((Control)s1n).BackColor = Color.Transparent;
			s1n.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			s1n.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			s1n.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			s1n.CheckedState.InnerColor = Color.White;
			((Control)s1n).Cursor = Cursors.Hand;
			((Control)s1n).Location = new Point(581, 10);
			((Control)s1n).Name = "cfexRenamerSwitch";
			((Control)s1n).Size = new Size(35, 20);
			((Control)s1n).TabIndex = 10;
			s1n.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			s1n.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			s1n.UncheckedState.InnerBorderColor = Color.White;
			s1n.UncheckedState.InnerColor = Color.White;
			s1n.CheckedChanged += ogM;
			((Control)Y1H).BackColor = Color.Transparent;
			((Control)Y1H).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)Y1H).ForeColor = Color.White;
			Y1H.IsContextMenuEnabled = false;
			Y1H.IsSelectionEnabled = false;
			((Control)Y1H).Location = new Point(13, 11);
			((Control)Y1H).Name = "guna2HtmlLabel65";
			((Control)Y1H).Size = new Size(559, 18);
			((Control)Y1H).TabIndex = 8;
			((Control)Y1H).Text = "CONFUSEREX RENAMER, MAKE SURE DLLS WITH EXE IN SAME PATH TO RESOLVE!, NOT WORKING WITH CODE VIRT";
			q1V.FillColor = Color.FromArgb(41, 230, 124);
			q1V.FillThickness = 3;
			((Control)q1V).Location = new Point(-2, 10);
			((Control)q1V).Name = "guna2VSeparator32";
			((Control)q1V).Size = new Size(3, 20);
			((Control)q1V).TabIndex = 9;
			oPE.Animated = true;
			((Control)oPE).BackColor = Color.Transparent;
			oPE.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			oPE.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			oPE.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			oPE.CheckedState.InnerColor = Color.White;
			((Control)oPE).Cursor = Cursors.Hand;
			((Control)oPE).Location = new Point(417, 338);
			((Control)oPE).Name = "customRenamer";
			((Control)oPE).Size = new Size(35, 20);
			((Control)oPE).TabIndex = 15;
			oPE.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			oPE.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			oPE.UncheckedState.InnerBorderColor = Color.White;
			oPE.UncheckedState.InnerColor = Color.White;
			oPE.CheckedChanged += TgH;
			((Control)TPR).AllowDrop = true;
			TPR.BorderColor = Color.FromArgb(44, 44, 44);
			TPR.BorderRadius = 6;
			((Control)TPR).Cursor = Cursors.IBeam;
			TPR.DefaultText = "";
			TPR.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			TPR.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			TPR.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			TPR.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			TPR.FillColor = Color.FromArgb(26, 26, 26);
			TPR.FocusedState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)TPR).Font = new Font("Bahnschrift SemiCondensed", 9f);
			((Control)TPR).ForeColor = Color.White;
			TPR.HoverState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)TPR).Location = new Point(42, 366);
			((Control)TPR).Name = "customBox";
			TPR.PasswordChar = '\0';
			TPR.PlaceholderForeColor = Color.FromArgb(110, 110, 110);
			TPR.PlaceholderText = "ADD SIGNATURE HERE";
			TPR.SelectedText = "";
			((Control)TPR).Size = new Size(410, 34);
			((Control)TPR).TabIndex = 14;
			TPR.TextChanged += ugV;
			((Control)NPY).BackColor = Color.Transparent;
			((Control)NPY).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)NPY).ForeColor = Color.White;
			NPY.IsContextMenuEnabled = false;
			NPY.IsSelectionEnabled = false;
			((Control)NPY).Location = new Point(42, 342);
			((Control)NPY).Name = "guna2HtmlLabel43";
			((Control)NPY).Size = new Size(101, 18);
			((Control)NPY).TabIndex = 11;
			((Control)NPY).Text = "CUSTOM RENAMING";
			APU.BackColor = Color.FromArgb(20, 20, 20);
			APU.BorderStyle = BorderStyle.None;
			APU.CheckOnClick = true;
			APU.Font = new Font("Bahnschrift SemiCondensed", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			APU.ForeColor = Color.White;
			APU.FormattingEnabled = true;
			APU.Items.AddRange(new object[6] { "EVENTS", "FIELDS", "METHODS", "PARAMETERS", "PROPERTIES", "TYPES" });
			APU.Location = new Point(42, 213);
			APU.Name = "renamingOptions";
			APU.Size = new Size(206, 119);
			APU.TabIndex = 10;
			APU.ItemCheck += Jgn;
			((Control)vPa).BackColor = Color.Transparent;
			((Control)vPa).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)vPa).ForeColor = Color.White;
			vPa.IsContextMenuEnabled = false;
			vPa.IsSelectionEnabled = false;
			((Control)vPa).Location = new Point(42, 183);
			((Control)vPa).Name = "guna2HtmlLabel42";
			((Control)vPa).Size = new Size(46, 18);
			((Control)vPa).TabIndex = 9;
			((Control)vPa).Text = "OPTIONS";
			CPo.BackColor = Color.FromArgb(26, 26, 26);
			CPo.Controls.Add(NPB);
			CPo.Controls.Add(qPv);
			CPo.Controls.Add(WPu);
			CPo.Location = new Point(42, 120);
			CPo.Name = "renamePanel";
			CPo.Size = new Size(627, 40);
			CPo.TabIndex = 8;
			CPo.MouseDown += Tt7;
			NPB.Animated = true;
			((Control)NPB).BackColor = Color.Transparent;
			NPB.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			NPB.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			NPB.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			NPB.CheckedState.InnerColor = Color.White;
			((Control)NPB).Cursor = Cursors.Hand;
			((Control)NPB).Location = new Point(581, 10);
			((Control)NPB).Name = "renamerSwitch";
			((Control)NPB).Size = new Size(35, 20);
			((Control)NPB).TabIndex = 10;
			NPB.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			NPB.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			NPB.UncheckedState.InnerBorderColor = Color.White;
			NPB.UncheckedState.InnerColor = Color.White;
			NPB.CheckedChanged += Ygm;
			((Control)qPv).BackColor = Color.Transparent;
			((Control)qPv).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)qPv).ForeColor = Color.White;
			qPv.IsContextMenuEnabled = false;
			qPv.IsSelectionEnabled = false;
			((Control)qPv).Location = new Point(13, 11);
			((Control)qPv).Name = "guna2HtmlLabel36";
			((Control)qPv).Size = new Size(129, 18);
			((Control)qPv).TabIndex = 8;
			((Control)qPv).Text = "RENAMING OBFUSCATION";
			WPu.FillColor = Color.FromArgb(41, 230, 124);
			WPu.FillThickness = 3;
			((Control)WPu).Location = new Point(-2, 10);
			((Control)WPu).Name = "guna2VSeparator22";
			((Control)WPu).Size = new Size(3, 20);
			((Control)WPu).TabIndex = 9;
			((Control)KPK).BackColor = Color.Transparent;
			((Control)KPK).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)KPK).ForeColor = Color.White;
			KPK.IsContextMenuEnabled = false;
			KPK.IsSelectionEnabled = false;
			((Control)KPK).Location = new Point(95, 38);
			((Control)KPK).Name = "guna2HtmlLabel40";
			((Control)KPK).Size = new Size(50, 18);
			((Control)KPK).TabIndex = 4;
			((Control)KPK).Text = "SETTINGS";
			((Control)BPb).BackColor = Color.Transparent;
			((Control)BPb).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)BPb).ForeColor = Color.White;
			BPb.IsContextMenuEnabled = false;
			BPb.IsSelectionEnabled = false;
			((Control)BPb).Location = new Point(42, 38);
			((Control)BPb).Name = "guna2HtmlLabel41";
			((Control)BPb).Size = new Size(52, 18);
			((Control)BPb).TabIndex = 3;
			((Control)BPb).Text = "RENAMER";
			yPp.BackColor = Color.FromArgb(20, 20, 20);
			yPp.Controls.Add(Q2i);
			yPp.Controls.Add(m2q);
			yPp.Controls.Add(f2t);
			yPp.Controls.Add(q1c);
			yPp.Controls.Add(sPk);
			yPp.Controls.Add(pPj);
			yPp.Controls.Add(aP3);
			yPp.Controls.Add(rPW);
			yPp.Controls.Add(rPX);
			yPp.Controls.Add(GPA);
			yPp.Location = new Point(279, 39);
			yPp.Name = "virtualizationPage";
			yPp.Size = new Size(721, 481);
			yPp.TabIndex = 15;
			Q2i.BackColor = Color.FromArgb(20, 20, 20);
			Q2i.BorderStyle = BorderStyle.None;
			Q2i.Font = new Font("Bahnschrift", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			Q2i.ForeColor = Color.White;
			Q2i.ImageIndex = 0;
			Q2i.ImageList = m2g;
			Q2i.LineColor = Color.FromArgb(41, 230, 124);
			Q2i.Location = new Point(42, 123);
			Q2i.Name = "treeView2";
			Q2i.SelectedImageIndex = 0;
			Q2i.Size = new Size(624, 263);
			Q2i.TabIndex = 20;
			Q2i.AfterCheck += lgs;
			Q2i.NodeMouseClick += Lg5;
			m2g.ImageStream = (ImageListStreamer)componentResourceManager.GetObject("imageList1.ImageStream");
			m2g.TransparentColor = Color.Transparent;
			m2g.Images.SetKeyName(0, "unchecked_checkbox_16px.png");
			m2g.Images.SetKeyName(1, "checked_checkbox_16px.png");
			((Control)m2q).BackColor = Color.Transparent;
			((Control)m2q).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)m2q).ForeColor = Color.White;
			m2q.IsContextMenuEnabled = false;
			m2q.IsSelectionEnabled = false;
			((Control)m2q).Location = new Point(50, 394);
			((Control)m2q).Name = "guna2HtmlLabel77";
			((Control)m2q).Size = new Size(79, 18);
			((Control)m2q).TabIndex = 19;
			((Control)m2q).Text = "RUNTIME NAME";
			((Control)f2t).AllowDrop = true;
			f2t.BorderColor = Color.FromArgb(44, 44, 44);
			f2t.BorderRadius = 6;
			((Control)f2t).Cursor = Cursors.IBeam;
			f2t.DefaultText = "XVM.Runtime.dll";
			f2t.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			f2t.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			f2t.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			f2t.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			f2t.FillColor = Color.FromArgb(26, 26, 26);
			f2t.FocusedState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)f2t).Font = new Font("Bahnschrift SemiCondensed", 9f);
			((Control)f2t).ForeColor = Color.White;
			f2t.HoverState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)f2t).Location = new Point(50, 418);
			((Control)f2t).Name = "vmRtName";
			f2t.PasswordChar = '\0';
			f2t.PlaceholderForeColor = Color.FromArgb(110, 110, 110);
			f2t.PlaceholderText = "";
			f2t.SelectedText = "";
			((Control)f2t).Size = new Size(207, 34);
			((Control)f2t).TabIndex = 18;
			f2t.TextChanged += JgG;
			((Control)q1c).BackColor = Color.Transparent;
			q1c.CheckedState.ImageSize = new Size(64, 64);
			((Control)q1c).Cursor = Cursors.Hand;
			q1c.HoverState.ImageSize = new Size(17, 17);
			q1c.Image = Resources.uncheck_all_18px;
			q1c.ImageOffset = new Point(0, 0);
			q1c.ImageRotate = 0f;
			q1c.ImageSize = new Size(18, 18);
			((Control)q1c).Location = new Point(639, 393);
			((Control)q1c).Name = "addAllMethods";
			q1c.PressedState.ImageSize = new Size(16, 16);
			((Control)q1c).Size = new Size(30, 40);
			((Control)q1c).TabIndex = 17;
			((Control)q1c).Visible = false;
			((Control)q1c).Click += Ngr;
			((Control)sPk).BackColor = Color.Transparent;
			sPk.CheckedState.ImageSize = new Size(64, 64);
			((Control)sPk).Cursor = Cursors.Hand;
			sPk.HoverState.ImageSize = new Size(23, 23);
			sPk.Image = Resources.google_web_search_24px;
			sPk.ImageOffset = new Point(0, 0);
			sPk.ImageRotate = 0f;
			sPk.ImageSize = new Size(24, 24);
			((Control)sPk).Location = new Point(629, 34);
			((Control)sPk).Name = "searchMethod";
			sPk.PressedState.ImageSize = new Size(22, 22);
			((Control)sPk).Size = new Size(30, 33);
			((Control)sPk).TabIndex = 15;
			((Control)sPk).Visible = false;
			((Control)sPk).Click += ogX;
			((Control)pPj).AllowDrop = true;
			pPj.BorderColor = Color.FromArgb(44, 44, 44);
			pPj.BorderRadius = 6;
			((Control)pPj).Cursor = Cursors.IBeam;
			pPj.DefaultText = "";
			pPj.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			pPj.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			pPj.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			pPj.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			pPj.FillColor = Color.FromArgb(26, 26, 26);
			pPj.FocusedState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)pPj).Font = new Font("Bahnschrift SemiCondensed", 9f);
			((Control)pPj).ForeColor = Color.White;
			pPj.HoverState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)pPj).Location = new Point(354, 34);
			((Control)pPj).Name = "methodBox";
			pPj.PasswordChar = '\0';
			pPj.PlaceholderForeColor = Color.FromArgb(110, 110, 110);
			pPj.PlaceholderText = "EXAMPLE: MAIN";
			pPj.SelectedText = "";
			((Control)pPj).Size = new Size(269, 34);
			((Control)pPj).TabIndex = 14;
			((Control)pPj).Visible = false;
			((Control)aP3).BackColor = Color.Transparent;
			((Control)aP3).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)aP3).ForeColor = Color.White;
			aP3.IsContextMenuEnabled = false;
			aP3.IsSelectionEnabled = false;
			((Control)aP3).Location = new Point(354, 10);
			((Control)aP3).Name = "guna2HtmlLabel44";
			((Control)aP3).Size = new Size(111, 18);
			((Control)aP3).TabIndex = 11;
			((Control)aP3).Text = "SEARCH FOR METHOD";
			((Control)aP3).Visible = false;
			rPW.BackColor = Color.FromArgb(26, 26, 26);
			rPW.Controls.Add(OPy);
			rPW.Controls.Add(aPL);
			rPW.Controls.Add(yPJ);
			rPW.Location = new Point(42, 74);
			rPW.Name = "virtPanel";
			rPW.Size = new Size(627, 40);
			rPW.TabIndex = 8;
			rPW.MouseDown += ktc;
			OPy.Animated = true;
			((Control)OPy).BackColor = Color.Transparent;
			OPy.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			OPy.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			OPy.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			OPy.CheckedState.InnerColor = Color.White;
			((Control)OPy).Cursor = Cursors.Hand;
			((Control)OPy).Location = new Point(581, 10);
			((Control)OPy).Name = "virtSwitch";
			((Control)OPy).Size = new Size(35, 20);
			((Control)OPy).TabIndex = 10;
			OPy.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			OPy.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			OPy.UncheckedState.InnerBorderColor = Color.White;
			OPy.UncheckedState.InnerColor = Color.White;
			OPy.CheckedChanged += kgQ;
			((Control)aPL).BackColor = Color.Transparent;
			((Control)aPL).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)aPL).ForeColor = Color.White;
			aPL.IsContextMenuEnabled = false;
			aPL.IsSelectionEnabled = false;
			((Control)aPL).Location = new Point(13, 11);
			((Control)aPL).Name = "guna2HtmlLabel46";
			((Control)aPL).Size = new Size(110, 18);
			((Control)aPL).TabIndex = 8;
			((Control)aPL).Text = "VIRTUALIZE METHODS";
			yPJ.FillColor = Color.FromArgb(41, 230, 124);
			yPJ.FillThickness = 3;
			((Control)yPJ).Location = new Point(-2, 10);
			((Control)yPJ).Name = "guna2VSeparator24";
			((Control)yPJ).Size = new Size(3, 20);
			((Control)yPJ).TabIndex = 9;
			((Control)rPX).BackColor = Color.Transparent;
			((Control)rPX).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)rPX).ForeColor = Color.White;
			rPX.IsContextMenuEnabled = false;
			rPX.IsSelectionEnabled = false;
			((Control)rPX).Location = new Point(154, 38);
			((Control)rPX).Name = "guna2HtmlLabel47";
			((Control)rPX).Size = new Size(50, 18);
			((Control)rPX).TabIndex = 4;
			((Control)rPX).Text = "SETTINGS";
			((Control)GPA).BackColor = Color.Transparent;
			((Control)GPA).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)GPA).ForeColor = Color.White;
			GPA.IsContextMenuEnabled = false;
			GPA.IsSelectionEnabled = false;
			((Control)GPA).Location = new Point(42, 38);
			((Control)GPA).Name = "guna2HtmlLabel48";
			((Control)GPA).Size = new Size(112, 18);
			((Control)GPA).TabIndex = 3;
			((Control)GPA).Text = "CODE VIRTUALIZATION";
			KPG.BackColor = Color.FromArgb(20, 20, 20);
			KPG.Controls.Add(y1U);
			KPG.Controls.Add(kPs);
			KPG.Controls.Add(qPl);
			KPG.Controls.Add(nPS);
			KPG.Controls.Add(iP5);
			KPG.Location = new Point(279, 39);
			KPG.Name = "projectPage";
			KPG.Size = new Size(721, 481);
			KPG.TabIndex = 16;
			((Control)y1U).BackColor = Color.Transparent;
			y1U.CheckedState.ImageSize = new Size(64, 64);
			((Control)y1U).Cursor = Cursors.Hand;
			y1U.HoverState.ImageSize = new Size(63, 63);
			y1U.Image = Resources.back_to_64px;
			y1U.ImageOffset = new Point(0, 0);
			y1U.ImageRotate = 0f;
			((Control)y1U).Location = new Point(635, 395);
			((Control)y1U).Name = "backfromProject";
			y1U.PressedState.ImageSize = new Size(62, 62);
			((Control)y1U).Size = new Size(64, 64);
			((Control)y1U).TabIndex = 13;
			((Control)y1U).Click += EtI;
			kPs.BorderColor = Color.FromArgb(44, 44, 44);
			kPs.BorderRadius = 6;
			kPs.BorderThickness = 1;
			((Control)kPs).Cursor = Cursors.Hand;
			kPs.DisabledState.BorderColor = Color.DarkGray;
			kPs.DisabledState.CustomBorderColor = Color.DarkGray;
			kPs.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			kPs.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			kPs.FillColor = Color.FromArgb(26, 26, 26);
			((Control)kPs).Font = new Font("Bahnschrift SemiCondensed", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)kPs).ForeColor = Color.White;
			kPs.HoverState.FillColor = Color.FromArgb(40, 40, 40);
			kPs.HoverState.ForeColor = Color.White;
			kPs.Image = Resources.import_file_24px;
			kPs.ImageAlign = HorizontalAlignment.Left;
			kPs.ImageOffset = new Point(10, 0);
			kPs.ImageSize = new Size(24, 24);
			((Control)kPs).Location = new Point(42, 123);
			((Control)kPs).Name = "loadProject";
			((Control)kPs).Size = new Size(206, 44);
			((Control)kPs).TabIndex = 9;
			((Control)kPs).Text = "LOAD PROJECT";
			kPs.TextAlign = HorizontalAlignment.Left;
			kPs.TextOffset = new Point(14, 0);
			((Control)kPs).Click += mih;
			((Control)qPl).BackColor = Color.Transparent;
			((Control)qPl).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)qPl).ForeColor = Color.White;
			qPl.IsContextMenuEnabled = false;
			qPl.IsSelectionEnabled = false;
			((Control)qPl).Location = new Point(91, 38);
			((Control)qPl).Name = "guna2HtmlLabel50";
			((Control)qPl).Size = new Size(50, 18);
			((Control)qPl).TabIndex = 4;
			((Control)qPl).Text = "SETTINGS";
			((Control)nPS).BackColor = Color.Transparent;
			((Control)nPS).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)nPS).ForeColor = Color.White;
			nPS.IsContextMenuEnabled = false;
			nPS.IsSelectionEnabled = false;
			((Control)nPS).Location = new Point(42, 38);
			((Control)nPS).Name = "guna2HtmlLabel51";
			((Control)nPS).Size = new Size(48, 18);
			((Control)nPS).TabIndex = 3;
			((Control)nPS).Text = "PROJECT";
			iP5.BorderColor = Color.FromArgb(44, 44, 44);
			iP5.BorderRadius = 6;
			iP5.BorderThickness = 1;
			((Control)iP5).Cursor = Cursors.Hand;
			iP5.DisabledState.BorderColor = Color.DarkGray;
			iP5.DisabledState.CustomBorderColor = Color.DarkGray;
			iP5.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
			iP5.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
			iP5.FillColor = Color.FromArgb(26, 26, 26);
			((Control)iP5).Font = new Font("Bahnschrift SemiCondensed", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)iP5).ForeColor = Color.White;
			iP5.HoverState.FillColor = Color.FromArgb(40, 40, 40);
			iP5.HoverState.ForeColor = Color.White;
			iP5.Image = Resources.save_24px;
			iP5.ImageAlign = HorizontalAlignment.Left;
			iP5.ImageOffset = new Point(10, 0);
			iP5.ImageSize = new Size(24, 24);
			((Control)iP5).Location = new Point(42, 73);
			((Control)iP5).Name = "saveProject";
			((Control)iP5).Size = new Size(206, 44);
			((Control)iP5).TabIndex = 10;
			((Control)iP5).Text = "SAVE PROJECT";
			iP5.TextAlign = HorizontalAlignment.Left;
			iP5.TextOffset = new Point(14, 0);
			((Control)iP5).Click += ciq;
			iPc.BackColor = Color.FromArgb(20, 20, 20);
			iPc.Controls.Add(I19);
			iPc.Controls.Add(I1d);
			iPc.Controls.Add(g1O);
			iPc.Controls.Add(T1w);
			iPc.Controls.Add(M1f);
			iPc.Controls.Add(jP7);
			iPc.Location = new Point(279, 39);
			iPc.Name = "colorsPage";
			iPc.Size = new Size(721, 481);
			iPc.TabIndex = 17;
			((Control)I19).BackColor = Color.Transparent;
			I19.CheckedState.ImageSize = new Size(64, 64);
			((Control)I19).Cursor = Cursors.Hand;
			I19.HoverState.ImageSize = new Size(17, 17);
			I19.Image = Resources.shuffle_18px;
			I19.ImageOffset = new Point(0, 0);
			I19.ImageRotate = 0f;
			I19.ImageSize = new Size(18, 18);
			((Control)I19).Location = new Point(220, 70);
			((Control)I19).Name = "randomRGB";
			I19.PressedState.ImageSize = new Size(16, 16);
			((Control)I19).Size = new Size(30, 30);
			((Control)I19).TabIndex = 21;
			((Control)I19).Click += LtF;
			((Control)I1d).BackColor = Color.Transparent;
			I1d.CheckedState.ImageSize = new Size(64, 64);
			((Control)I1d).Cursor = Cursors.Hand;
			I1d.HoverState.ImageSize = new Size(17, 17);
			I1d.Image = Resources.fill_color_18px;
			I1d.ImageOffset = new Point(0, 0);
			I1d.ImageRotate = 0f;
			I1d.ImageSize = new Size(18, 18);
			((Control)I1d).Location = new Point(184, 70);
			((Control)I1d).Name = "setinRGB";
			I1d.PressedState.ImageSize = new Size(16, 16);
			((Control)I1d).Size = new Size(30, 30);
			((Control)I1d).TabIndex = 20;
			((Control)I1d).Click += Itm;
			((Control)g1O).AllowDrop = true;
			g1O.BorderColor = Color.FromArgb(44, 44, 44);
			((Control)g1O).Cursor = Cursors.IBeam;
			g1O.DefaultText = "124";
			g1O.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			g1O.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			g1O.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			g1O.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			g1O.FillColor = Color.FromArgb(20, 20, 20);
			g1O.FocusedState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)g1O).Font = new Font("Bahnschrift SemiCondensed", 9f);
			((Control)g1O).ForeColor = Color.White;
			g1O.HoverState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)g1O).Location = new Point(134, 62);
			((Control)g1O).Name = "bVal";
			g1O.PasswordChar = '\0';
			g1O.PlaceholderForeColor = Color.FromArgb(110, 110, 110);
			g1O.PlaceholderText = "B";
			g1O.SelectedText = "";
			((Control)g1O).Size = new Size(40, 34);
			g1O.Style = TextBoxStyle.Material;
			((Control)g1O).TabIndex = 17;
			g1O.TextAlign = HorizontalAlignment.Center;
			g1O.TextChanged += Ot8;
			((Control)T1w).AllowDrop = true;
			T1w.BorderColor = Color.FromArgb(44, 44, 44);
			((Control)T1w).Cursor = Cursors.IBeam;
			T1w.DefaultText = "230";
			T1w.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			T1w.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			T1w.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			T1w.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			T1w.FillColor = Color.FromArgb(20, 20, 20);
			T1w.FocusedState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)T1w).Font = new Font("Bahnschrift SemiCondensed", 9f);
			((Control)T1w).ForeColor = Color.White;
			T1w.HoverState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)T1w).Location = new Point(88, 62);
			((Control)T1w).Name = "gVal";
			T1w.PasswordChar = '\0';
			T1w.PlaceholderForeColor = Color.FromArgb(110, 110, 110);
			T1w.PlaceholderText = "G";
			T1w.SelectedText = "";
			((Control)T1w).Size = new Size(40, 34);
			T1w.Style = TextBoxStyle.Material;
			((Control)T1w).TabIndex = 16;
			T1w.TextAlign = HorizontalAlignment.Center;
			T1w.TextChanged += jtD;
			((Control)M1f).AllowDrop = true;
			M1f.BorderColor = Color.FromArgb(44, 44, 44);
			((Control)M1f).Cursor = Cursors.IBeam;
			M1f.DefaultText = "41";
			M1f.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			M1f.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			M1f.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			M1f.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
			M1f.FillColor = Color.FromArgb(20, 20, 20);
			M1f.FocusedState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)M1f).Font = new Font("Bahnschrift SemiCondensed", 9f);
			((Control)M1f).ForeColor = Color.White;
			M1f.HoverState.BorderColor = Color.FromArgb(41, 230, 124);
			((Control)M1f).Location = new Point(42, 62);
			((Control)M1f).Name = "rVal";
			M1f.PasswordChar = '\0';
			M1f.PlaceholderForeColor = Color.FromArgb(110, 110, 110);
			M1f.PlaceholderText = "R";
			M1f.SelectedText = "";
			((Control)M1f).Size = new Size(40, 34);
			M1f.Style = TextBoxStyle.Material;
			((Control)M1f).TabIndex = 15;
			M1f.TextAlign = HorizontalAlignment.Center;
			M1f.TextChanged += jtM;
			((Control)jP7).BackColor = Color.Transparent;
			((Control)jP7).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)jP7).ForeColor = Color.White;
			jP7.IsContextMenuEnabled = false;
			jP7.IsSelectionEnabled = false;
			((Control)jP7).Location = new Point(42, 38);
			((Control)jP7).Name = "guna2HtmlLabel2";
			((Control)jP7).Size = new Size(182, 18);
			((Control)jP7).TabIndex = 3;
			((Control)jP7).Text = "SET YOUR FAVOURITE COLOR IN RGB";
			((Control)n1Z).BackColor = Color.Transparent;
			((Control)n1Z).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)n1Z).ForeColor = Color.White;
			n1Z.IsContextMenuEnabled = false;
			n1Z.IsSelectionEnabled = false;
			((Control)n1Z).Location = new Point(13, 11);
			((Control)n1Z).Name = "guna2HtmlLabel49";
			((Control)n1Z).Size = new Size(78, 18);
			((Control)n1Z).TabIndex = 8;
			((Control)n1Z).Text = "NORMAL MODE";
			((Control)D1C).BackColor = Color.Transparent;
			((Control)D1C).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)D1C).ForeColor = Color.White;
			D1C.IsContextMenuEnabled = false;
			D1C.IsSelectionEnabled = false;
			((Control)D1C).Location = new Point(13, 11);
			((Control)D1C).Name = "guna2HtmlLabel45";
			((Control)D1C).Size = new Size(85, 18);
			((Control)D1C).TabIndex = 8;
			((Control)D1C).Text = "SILENTLY CLOSE";
			((Control)K1T).BackColor = Color.Transparent;
			((Control)K1T).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)K1T).ForeColor = Color.White;
			K1T.IsContextMenuEnabled = false;
			K1T.IsSelectionEnabled = false;
			((Control)K1T).Location = new Point(13, 11);
			((Control)K1T).Name = "guna2HtmlLabel1";
			((Control)K1T).Size = new Size(99, 18);
			((Control)K1T).TabIndex = 8;
			((Control)K1T).Text = "EXCLUDE PROCESS";
			WPz.BackColor = Color.FromArgb(20, 20, 20);
			WPz.Controls.Add(i1x);
			WPz.Controls.Add(p1h);
			WPz.Controls.Add(u1i);
			WPz.Controls.Add(X14);
			WPz.Controls.Add(I12);
			WPz.Location = new Point(279, 39);
			WPz.Name = "settingsPage";
			WPz.Size = new Size(721, 481);
			WPz.TabIndex = 18;
			((Control)i1x).BackColor = Color.Transparent;
			i1x.CheckedState.ImageSize = new Size(64, 64);
			((Control)i1x).Cursor = Cursors.Hand;
			i1x.HoverState.ImageSize = new Size(63, 63);
			i1x.Image = Resources.back_to_64px;
			i1x.ImageOffset = new Point(0, 0);
			i1x.ImageRotate = 0f;
			((Control)i1x).Location = new Point(635, 395);
			((Control)i1x).Name = "backfromSettings";
			i1x.PressedState.ImageSize = new Size(62, 62);
			((Control)i1x).Size = new Size(64, 64);
			((Control)i1x).TabIndex = 16;
			((Control)i1x).Click += Qt0;
			p1h.BackColor = Color.FromArgb(26, 26, 26);
			p1h.Controls.Add(v1q);
			p1h.Controls.Add(B1t);
			p1h.Controls.Add(y1g);
			p1h.Location = new Point(42, 120);
			p1h.Name = "panel15";
			p1h.Size = new Size(627, 40);
			p1h.TabIndex = 11;
			v1q.Animated = true;
			((Control)v1q).BackColor = Color.Transparent;
			v1q.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			v1q.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			v1q.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			v1q.CheckedState.InnerColor = Color.White;
			((Control)v1q).Cursor = Cursors.Hand;
			((Control)v1q).Location = new Point(581, 10);
			((Control)v1q).Name = "autoDir";
			((Control)v1q).Size = new Size(35, 20);
			((Control)v1q).TabIndex = 10;
			v1q.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			v1q.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			v1q.UncheckedState.InnerBorderColor = Color.White;
			v1q.UncheckedState.InnerColor = Color.White;
			v1q.CheckedChanged += Mii;
			((Control)B1t).BackColor = Color.Transparent;
			((Control)B1t).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)B1t).ForeColor = Color.White;
			B1t.IsContextMenuEnabled = false;
			B1t.IsSelectionEnabled = false;
			((Control)B1t).Location = new Point(13, 11);
			((Control)B1t).Name = "guna2HtmlLabel53";
			((Control)B1t).Size = new Size(156, 18);
			((Control)B1t).TabIndex = 8;
			((Control)B1t).Text = "AUTO DIR AFTER OBFUSCATION";
			y1g.FillColor = Color.FromArgb(41, 230, 124);
			y1g.FillThickness = 3;
			((Control)y1g).Location = new Point(-2, 10);
			((Control)y1g).Name = "guna2VSeparator25";
			((Control)y1g).Size = new Size(3, 20);
			((Control)y1g).TabIndex = 9;
			u1i.BackColor = Color.FromArgb(26, 26, 26);
			u1i.Controls.Add(x1N);
			u1i.Controls.Add(R1P);
			u1i.Controls.Add(K11);
			u1i.Location = new Point(42, 74);
			u1i.Name = "panel16";
			u1i.Size = new Size(627, 40);
			u1i.TabIndex = 8;
			x1N.Animated = true;
			((Control)x1N).BackColor = Color.Transparent;
			x1N.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			x1N.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			x1N.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			x1N.CheckedState.InnerColor = Color.White;
			((Control)x1N).Cursor = Cursors.Hand;
			((Control)x1N).Location = new Point(581, 10);
			((Control)x1N).Name = "soundReminder";
			((Control)x1N).Size = new Size(35, 20);
			((Control)x1N).TabIndex = 10;
			x1N.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			x1N.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			x1N.UncheckedState.InnerBorderColor = Color.White;
			x1N.UncheckedState.InnerColor = Color.White;
			x1N.CheckedChanged += Kig;
			((Control)R1P).BackColor = Color.Transparent;
			((Control)R1P).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)R1P).ForeColor = Color.White;
			R1P.IsContextMenuEnabled = false;
			R1P.IsSelectionEnabled = false;
			((Control)R1P).Location = new Point(13, 11);
			((Control)R1P).Name = "guna2HtmlLabel54";
			((Control)R1P).Size = new Size(155, 18);
			((Control)R1P).TabIndex = 8;
			((Control)R1P).Text = "SOUND REMINDER WHEN DONE";
			K11.FillColor = Color.FromArgb(41, 230, 124);
			K11.FillThickness = 3;
			((Control)K11).Location = new Point(-2, 10);
			((Control)K11).Name = "guna2VSeparator26";
			((Control)K11).Size = new Size(3, 20);
			((Control)K11).TabIndex = 9;
			((Control)X14).BackColor = Color.Transparent;
			((Control)X14).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)X14).ForeColor = Color.White;
			X14.IsContextMenuEnabled = false;
			X14.IsSelectionEnabled = false;
			((Control)X14).Location = new Point(75, 38);
			((Control)X14).Name = "guna2HtmlLabel55";
			((Control)X14).Size = new Size(50, 18);
			((Control)X14).TabIndex = 4;
			((Control)X14).Text = "SETTINGS";
			((Control)I12).BackColor = Color.Transparent;
			((Control)I12).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)I12).ForeColor = Color.White;
			I12.IsContextMenuEnabled = false;
			I12.IsSelectionEnabled = false;
			((Control)I12).Location = new Point(42, 38);
			((Control)I12).Name = "guna2HtmlLabel56";
			((Control)I12).Size = new Size(32, 18);
			((Control)I12).TabIndex = 3;
			((Control)I12).Text = "XERIN";
			f1e.AllowLinksHandling = true;
			((ToolTip)f1e).AutomaticDelay = 400;
			((ToolTip)f1e).AutoPopDelay = 10000;
			f1e.BackColor = Color.FromArgb(36, 36, 36);
			f1e.BorderColor = Color.FromArgb(41, 230, 124);
			f1e.Font = new Font("Bahnschrift SemiCondensed", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			f1e.ForeColor = Color.FromArgb(167, 176, 187);
			((ToolTip)f1e).InitialDelay = 400;
			f1e.MaximumSize = new Size(0, 0);
			((ToolTip)f1e).ReshowDelay = 50;
			f1e.TitleFont = new Font("Bahnschrift SemiCondensed", 10f);
			f1e.TitleForeColor = Color.White;
			((ToolTip)f1e).ToolTipIcon = ToolTipIcon.Info;
			((ToolTip)f1e).ToolTipTitle = "ABOUT PROTECTION";
			T1D.BackColor = Color.FromArgb(20, 20, 20);
			T1D.Controls.Add(Q1a);
			T1D.Controls.Add(G1R);
			T1D.Controls.Add(v1Y);
			T1D.Controls.Add(i1o);
			T1D.Controls.Add(B1b);
			T1D.Controls.Add(t1E);
			T1D.Controls.Add(J18);
			T1D.Location = new Point(279, 39);
			T1D.Name = "embedPage";
			T1D.Size = new Size(721, 481);
			T1D.TabIndex = 19;
			((Control)Q1a).BackColor = Color.FromArgb(20, 20, 20);
			Q1a.CheckedState.ImageSize = new Size(64, 64);
			((Control)Q1a).Cursor = Cursors.Hand;
			Q1a.HoverState.ImageSize = new Size(19, 19);
			Q1a.Image = Resources.empty_trash_20px;
			Q1a.ImageOffset = new Point(0, 0);
			Q1a.ImageRotate = 0f;
			Q1a.ImageSize = new Size(20, 20);
			((Control)Q1a).Location = new Point(639, 193);
			((Control)Q1a).Name = "clearList";
			Q1a.PressedState.ImageSize = new Size(18, 18);
			((Control)Q1a).Size = new Size(30, 30);
			((Control)Q1a).TabIndex = 19;
			((Control)Q1a).Click += Ygk;
			((Control)G1R).BackColor = Color.FromArgb(20, 20, 20);
			G1R.CheckedState.ImageSize = new Size(64, 64);
			((Control)G1R).Cursor = Cursors.Hand;
			G1R.HoverState.ImageSize = new Size(19, 19);
			G1R.Image = Resources.cancel_20px;
			G1R.ImageOffset = new Point(0, 0);
			G1R.ImageRotate = 0f;
			G1R.ImageSize = new Size(20, 20);
			((Control)G1R).Location = new Point(639, 157);
			((Control)G1R).Name = "removeDll";
			G1R.PressedState.ImageSize = new Size(18, 18);
			((Control)G1R).Size = new Size(30, 30);
			((Control)G1R).TabIndex = 18;
			((Control)G1R).Click += mgA;
			((Control)v1Y).BackColor = Color.FromArgb(20, 20, 20);
			v1Y.CheckedState.ImageSize = new Size(64, 64);
			((Control)v1Y).Cursor = Cursors.Hand;
			v1Y.HoverState.ImageSize = new Size(19, 19);
			v1Y.Image = Resources.add_20px1;
			v1Y.ImageOffset = new Point(0, 0);
			v1Y.ImageRotate = 0f;
			v1Y.ImageSize = new Size(20, 20);
			((Control)v1Y).Location = new Point(639, 123);
			((Control)v1Y).Name = "addDlls";
			v1Y.PressedState.ImageSize = new Size(18, 18);
			((Control)v1Y).Size = new Size(30, 30);
			((Control)v1Y).TabIndex = 17;
			((Control)v1Y).Click += xgJ;
			i1o.BackColor = Color.FromArgb(26, 26, 26);
			i1o.Controls.Add(S1B);
			i1o.Controls.Add(P1v);
			i1o.Controls.Add(N1u);
			i1o.Location = new Point(42, 74);
			i1o.Name = "panel17";
			i1o.Size = new Size(627, 40);
			i1o.TabIndex = 8;
			S1B.Animated = true;
			((Control)S1B).BackColor = Color.Transparent;
			S1B.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			S1B.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			S1B.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			S1B.CheckedState.InnerColor = Color.White;
			((Control)S1B).Cursor = Cursors.Hand;
			((Control)S1B).Location = new Point(581, 10);
			((Control)S1B).Name = "embedderSwitch";
			((Control)S1B).Size = new Size(35, 20);
			((Control)S1B).TabIndex = 10;
			S1B.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			S1B.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			S1B.UncheckedState.InnerBorderColor = Color.White;
			S1B.UncheckedState.InnerColor = Color.White;
			S1B.CheckedChanged += Ygb;
			((Control)P1v).BackColor = Color.Transparent;
			((Control)P1v).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)P1v).ForeColor = Color.White;
			P1v.IsContextMenuEnabled = false;
			P1v.IsSelectionEnabled = false;
			((Control)P1v).Location = new Point(13, 11);
			((Control)P1v).Name = "guna2HtmlLabel60";
			((Control)P1v).Size = new Size(115, 18);
			((Control)P1v).TabIndex = 8;
			((Control)P1v).Text = "MERGE DLLS WITH EXE";
			N1u.FillColor = Color.FromArgb(41, 230, 124);
			N1u.FillThickness = 3;
			((Control)N1u).Location = new Point(-2, 10);
			((Control)N1u).Name = "guna2VSeparator30";
			((Control)N1u).Size = new Size(3, 20);
			((Control)N1u).TabIndex = 9;
			((Control)B1b).BackColor = Color.Transparent;
			((Control)B1b).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)B1b).ForeColor = Color.White;
			B1b.IsContextMenuEnabled = false;
			B1b.IsSelectionEnabled = false;
			((Control)B1b).Location = new Point(100, 38);
			((Control)B1b).Name = "guna2HtmlLabel61";
			((Control)B1b).Size = new Size(50, 18);
			((Control)B1b).TabIndex = 4;
			((Control)B1b).Text = "SETTINGS";
			((Control)t1E).BackColor = Color.Transparent;
			((Control)t1E).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)t1E).ForeColor = Color.White;
			t1E.IsContextMenuEnabled = false;
			t1E.IsSelectionEnabled = false;
			((Control)t1E).Location = new Point(42, 38);
			((Control)t1E).Name = "guna2HtmlLabel62";
			((Control)t1E).Size = new Size(58, 18);
			((Control)t1E).TabIndex = 3;
			((Control)t1E).Text = "EMBEDDER";
			J18.AllowDrop = true;
			J18.BackColor = Color.FromArgb(20, 20, 20);
			J18.BorderStyle = BorderStyle.None;
			J18.Font = new Font("Bahnschrift SemiCondensed", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			J18.ForeColor = Color.White;
			J18.FormattingEnabled = true;
			J18.ItemHeight = 14;
			J18.Location = new Point(42, 123);
			J18.Name = "dllsList";
			J18.Size = new Size(586, 280);
			J18.TabIndex = 16;
			J18.DragDrop += Tgy;
			J18.DragEnter += CgL;
			Y1y.BackColor = Color.FromArgb(20, 20, 20);
			Y1y.Controls.Add(D1s);
			Y1y.Controls.Add(S1k);
			Y1y.Controls.Add(U1G);
			Y1y.Controls.Add(c1S);
			Y1y.Controls.Add(A15);
			Y1y.Controls.Add(f1A);
			Y1y.Controls.Add(U1L);
			Y1y.Controls.Add(m1J);
			Y1y.Location = new Point(279, 39);
			Y1y.Name = "rightsPage";
			Y1y.Size = new Size(721, 481);
			Y1y.TabIndex = 20;
			((Control)D1s).BackColor = Color.Transparent;
			D1s.CheckedState.ImageSize = new Size(64, 64);
			((Control)D1s).Cursor = Cursors.Hand;
			D1s.HoverState.ImageSize = new Size(63, 63);
			D1s.Image = Resources.back_to_64px;
			D1s.ImageOffset = new Point(0, 0);
			D1s.ImageRotate = 0f;
			((Control)D1s).Location = new Point(635, 395);
			((Control)D1s).Name = "backfromRights";
			D1s.PressedState.ImageSize = new Size(62, 62);
			((Control)D1s).Size = new Size(64, 64);
			((Control)D1s).TabIndex = 15;
			((Control)D1s).Click += ctQ;
			((Control)S1k).BackColor = Color.Transparent;
			((Control)S1k).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)S1k).ForeColor = Color.White;
			S1k.IsContextMenuEnabled = false;
			S1k.IsSelectionEnabled = false;
			((Control)S1k).Location = new Point(80, 38);
			((Control)S1k).Name = "guna2HtmlLabel4";
			((Control)S1k).Size = new Size(39, 18);
			((Control)S1k).TabIndex = 14;
			((Control)S1k).Text = "RIGHTS";
			((Control)U1G).BackColor = Color.Transparent;
			((Control)U1G).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)U1G).ForeColor = Color.FromArgb(41, 230, 124);
			U1G.IsContextMenuEnabled = false;
			U1G.IsSelectionEnabled = false;
			((Control)U1G).Location = new Point(42, 38);
			((Control)U1G).Name = "guna2HtmlLabel57";
			((Control)U1G).Size = new Size(37, 18);
			((Control)U1G).TabIndex = 13;
			((Control)U1G).Text = "USAGE";
			c1S.AutoSize = true;
			c1S.Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			c1S.ForeColor = Color.White;
			c1S.Location = new Point(47, 158);
			c1S.Name = "label1";
			c1S.Size = new Size(647, 112);
			c1S.TabIndex = 12;
			c1S.Text = componentResourceManager.GetString("label1.Text");
			((Control)A15).BackColor = Color.Transparent;
			((Control)A15).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)A15).ForeColor = Color.White;
			A15.IsContextMenuEnabled = false;
			A15.IsSelectionEnabled = false;
			((Control)A15).Location = new Point(115, 100);
			((Control)A15).Name = "appVersion";
			((Control)A15).Size = new Size(46, 18);
			((Control)A15).TabIndex = 11;
			((Control)A15).Text = "VERSION";
			((Control)f1A).BackColor = Color.Transparent;
			((PictureBox)f1A).Image = Resources.shield_64px;
			f1A.ImageRotate = 0f;
			((Control)f1A).Location = new Point(42, 76);
			((Control)f1A).Name = "guna2CirclePictureBox2";
			f1A.ShadowDecoration.Mode = ShadowMode.Circle;
			((Control)f1A).Size = new Size(64, 64);
			((PictureBox)f1A).SizeMode = PictureBoxSizeMode.AutoSize;
			((PictureBox)f1A).TabIndex = 10;
			((PictureBox)f1A).TabStop = false;
			f1A.UseTransparentBackground = true;
			((Control)U1L).BackColor = Color.Transparent;
			((Control)U1L).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)U1L).ForeColor = Color.White;
			U1L.IsContextMenuEnabled = false;
			U1L.IsSelectionEnabled = false;
			((Control)U1L).Location = new Point(115, 117);
			((Control)U1L).Name = "guna2HtmlLabel3";
			((Control)U1L).Size = new Size(72, 18);
			((Control)U1L).TabIndex = 4;
			((Control)U1L).Text = "INX COMPANY";
			((Control)m1J).BackColor = Color.Transparent;
			((Control)m1J).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)m1J).ForeColor = Color.White;
			m1J.IsContextMenuEnabled = false;
			m1J.IsSelectionEnabled = false;
			((Control)m1J).Location = new Point(115, 83);
			((Control)m1J).Name = "guna2HtmlLabel63";
			((Control)m1J).Size = new Size(85, 18);
			((Control)m1J).TabIndex = 3;
			((Control)m1J).Text = "XERINFUSACTOR";
			Y4r.BackColor = Color.FromArgb(20, 20, 20);
			Y4r.Controls.Add(l4n);
			Y4r.Controls.Add(X2h);
			Y4r.Location = new Point(279, 39);
			Y4r.Name = "packerPage";
			Y4r.Size = new Size(721, 481);
			Y4r.TabIndex = 21;
			l4n.BackColor = Color.FromArgb(26, 26, 26);
			l4n.Controls.Add(C4H);
			l4n.Controls.Add(v4V);
			l4n.Controls.Add(r4z);
			l4n.Location = new Point(42, 74);
			l4n.Name = "packerPanel";
			l4n.Size = new Size(627, 40);
			l4n.TabIndex = 8;
			l4n.MouseDown += rtE;
			C4H.Animated = true;
			((Control)C4H).BackColor = Color.Transparent;
			C4H.CheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			C4H.CheckedState.FillColor = Color.FromArgb(41, 230, 124);
			C4H.CheckedState.InnerBorderColor = Color.FromArgb(40, 40, 40);
			C4H.CheckedState.InnerColor = Color.White;
			((Control)C4H).Cursor = Cursors.Hand;
			((Control)C4H).Location = new Point(581, 10);
			((Control)C4H).Name = "packerSwitch";
			((Control)C4H).Size = new Size(35, 20);
			((Control)C4H).TabIndex = 10;
			C4H.UncheckedState.BorderColor = Color.FromArgb(40, 40, 40);
			C4H.UncheckedState.FillColor = Color.FromArgb(66, 66, 66);
			C4H.UncheckedState.InnerBorderColor = Color.White;
			C4H.UncheckedState.InnerColor = Color.White;
			C4H.CheckedChanged += KtV;
			((Control)v4V).BackColor = Color.Transparent;
			((Control)v4V).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)v4V).ForeColor = Color.White;
			v4V.IsContextMenuEnabled = false;
			v4V.IsSelectionEnabled = false;
			((Control)v4V).Location = new Point(13, 11);
			((Control)v4V).Name = "guna2HtmlLabel6";
			((Control)v4V).Size = new Size(86, 18);
			((Control)v4V).TabIndex = 8;
			((Control)v4V).Text = "ENABLE PACKER";
			r4z.FillColor = Color.FromArgb(41, 230, 124);
			r4z.FillThickness = 3;
			((Control)r4z).Location = new Point(-2, 10);
			((Control)r4z).Name = "guna2VSeparator43";
			((Control)r4z).Size = new Size(3, 20);
			((Control)r4z).TabIndex = 9;
			((Control)X2h).BackColor = Color.Transparent;
			((Control)X2h).Font = new Font("Bahnschrift SemiCondensed", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			((Control)X2h).ForeColor = Color.White;
			X2h.IsContextMenuEnabled = false;
			X2h.IsSelectionEnabled = false;
			((Control)X2h).Location = new Point(42, 38);
			((Control)X2h).Name = "guna2HtmlLabel78";
			((Control)X2h).Size = new Size(190, 18);
			((Control)X2h).TabIndex = 3;
			((Control)X2h).Text = "NATIVE .NET PACKER ( STILL IN BETA )";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1000, 520);
			base.Controls.Add(rio);
			base.Controls.Add(Wiu);
			base.Controls.Add(aik);
			base.Controls.Add(Til);
			base.Controls.Add(iPc);
			base.Controls.Add(KPG);
			base.Controls.Add(yPp);
			base.Controls.Add(IP8);
			base.Controls.Add(Y4r);
			base.Controls.Add(RPI);
			base.Controls.Add(ePC);
			base.Controls.Add(KPh);
			base.Controls.Add(WPz);
			base.Controls.Add(T1D);
			base.Controls.Add(ONA);
			base.Controls.Add(Y1y);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			MaximumSize = new Size(1000, 520);
			base.Name = "XGui";
			base.StartPosition = FormStartPosition.CenterScreen;
			Text = "XerinFuscator GUI";
			base.Load += PqH;
			base.Shown += LqV;
			rio.ResumeLayout(false);
			rio.PerformLayout();
			Wiu.ResumeLayout(false);
			Wiu.PerformLayout();
			((ISupportInitialize)YiR).EndInit();
			qib.ResumeLayout(false);
			((ISupportInitialize)Xip).EndInit();
			aik.ResumeLayout(false);
			aik.PerformLayout();
			X4A.ResumeLayout(false);
			X4A.PerformLayout();
			b4R.ResumeLayout(false);
			b4R.PerformLayout();
			L41.ResumeLayout(false);
			L41.PerformLayout();
			((ISupportInitialize)p4K).EndInit();
			d4C.ResumeLayout(false);
			d4C.PerformLayout();
			c17.ResumeLayout(false);
			c17.PerformLayout();
			Til.ResumeLayout(false);
			V4W.ResumeLayout(false);
			V4W.PerformLayout();
			y4w.ResumeLayout(false);
			y4w.PerformLayout();
			i4g.ResumeLayout(false);
			i4g.PerformLayout();
			S1z.ResumeLayout(false);
			S1z.PerformLayout();
			RNj.ResumeLayout(false);
			RNj.PerformLayout();
			PiH.ResumeLayout(false);
			PiH.PerformLayout();
			FNq.ResumeLayout(false);
			FNq.PerformLayout();
			jNN.ResumeLayout(false);
			jNN.PerformLayout();
			lN2.ResumeLayout(false);
			lN2.PerformLayout();
			sNx.ResumeLayout(false);
			sNx.PerformLayout();
			ENe.ResumeLayout(false);
			ENe.PerformLayout();
			RNF.ResumeLayout(false);
			RNF.PerformLayout();
			DN8.ResumeLayout(false);
			DN8.PerformLayout();
			KNu.ResumeLayout(false);
			KNu.PerformLayout();
			ANY.ResumeLayout(false);
			ANY.PerformLayout();
			tiX.ResumeLayout(false);
			tiX.PerformLayout();
			ONA.ResumeLayout(false);
			ONA.PerformLayout();
			K10.ResumeLayout(false);
			K10.PerformLayout();
			GNk.ResumeLayout(false);
			GNk.PerformLayout();
			ANs.ResumeLayout(false);
			ANs.PerformLayout();
			WNX.ResumeLayout(false);
			WNX.PerformLayout();
			KPh.ResumeLayout(false);
			KPh.PerformLayout();
			u48.ResumeLayout(false);
			u48.PerformLayout();
			iPq.ResumeLayout(false);
			iPq.PerformLayout();
			aPN.ResumeLayout(false);
			aPN.PerformLayout();
			ePC.ResumeLayout(false);
			ePC.PerformLayout();
			H45.ResumeLayout(false);
			H45.PerformLayout();
			OPT.ResumeLayout(false);
			OPT.PerformLayout();
			iPf.ResumeLayout(false);
			iPf.PerformLayout();
			RPI.ResumeLayout(false);
			RPI.PerformLayout();
			xPQ.ResumeLayout(false);
			xPQ.PerformLayout();
			IP8.ResumeLayout(false);
			IP8.PerformLayout();
			w1r.ResumeLayout(false);
			w1r.PerformLayout();
			CPo.ResumeLayout(false);
			CPo.PerformLayout();
			yPp.ResumeLayout(false);
			yPp.PerformLayout();
			rPW.ResumeLayout(false);
			rPW.PerformLayout();
			KPG.ResumeLayout(false);
			KPG.PerformLayout();
			iPc.ResumeLayout(false);
			iPc.PerformLayout();
			WPz.ResumeLayout(false);
			WPz.PerformLayout();
			p1h.ResumeLayout(false);
			p1h.PerformLayout();
			u1i.ResumeLayout(false);
			u1i.PerformLayout();
			T1D.ResumeLayout(false);
			T1D.PerformLayout();
			i1o.ResumeLayout(false);
			i1o.PerformLayout();
			Y1y.ResumeLayout(false);
			Y1y.PerformLayout();
			((ISupportInitialize)f1A).EndInit();
			Y4r.ResumeLayout(false);
			Y4r.PerformLayout();
			l4n.ResumeLayout(false);
			l4n.PerformLayout();
			ResumeLayout(false);
		}

		static Rql()
		{
			Jid = null;
			Iie = new ProtectionManager();
			xi0 = null;
			QiI = "XVM.Runtime.dll";
			jiQ = false;
		}

		[CompilerGenerated]
		private IEnumerable<Control> Wi4(Control P_0)
		{
			return tiN(P_0);
		}
	}
}
