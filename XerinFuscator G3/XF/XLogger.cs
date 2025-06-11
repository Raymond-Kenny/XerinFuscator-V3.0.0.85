using dnlib.DotNet;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCore.Context;
using XCore.Embed;
using XCore.Generator;
using XCore.Protections;
using XCore.XVM.Helper;
using XerinFuscator_G3.Properties;
using XProtections.Packer;
using XVM.Internal;

namespace XF
{
    internal class XLogger : Form
    {
        public static bool PlaySoundOnFinish { get; set; }
        public static bool OpenDirectoryOnFinish { get; set; }
        public static string OutputDirectoryPath { get; set; }

        public static int ThemeColorR { get; set; }
        public static int ThemeColorG { get; set; }
        public static int ThemeColorB { get; set; }

        private static ModuleDefMD virtualizedModule;
        private bool isDragging = false;
        private Point dragStartPoint;
        private Point formStartPoint;

        private IContainer components = null;
        private Guna2Elipse guna2Elipse;
        private Panel headerPanel;
        private Guna2HtmlLabel headerTitleLabel;
        private Guna2ProgressBar progressBar;
        private RichTextBox logRichTextBox;
        private Guna2HtmlLabel loggerTitleLabel;
        private Guna2ShadowForm shadowForm;
        private Guna2ImageButton closeButton;

        public XLogger()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private async void XLogger_Load(object sender, EventArgs e)
        {
            shadowForm.SetShadowForm(this);
            Color themeColor = Color.FromArgb(ThemeColorR, ThemeColorG, ThemeColorB);
            headerTitleLabel.ForeColor = themeColor;
            progressBar.ProgressColor = themeColor;
            progressBar.ProgressColor2 = themeColor;

            logRichTextBox.Clear();
            closeButton.Enabled = false;

            try
            {
                if (Rql.Jid == null)
                {
                    Logger.Log(logRichTextBox, "Please load an assembly first!");
                    return;
                }
                string fileName = Path.GetFileNameWithoutExtension(Rql.Jid.Path);
                Process[] processes = Process.GetProcessesByName(fileName);
                if (processes.Length > 0)
                {
                    Logger.Log(
                        logRichTextBox,
                        "Assembly is running. Terminating process..."
                    );
                    processes[0].Kill();
                    await Task.Delay(100);
                }
                if (ProtectionManager.Protections.Count == 0)
                {
                    Logger.Log(logRichTextBox, "Please select at least one protection!");
                    return;
                }
                Embeder.isEmptyList = Embeder.dlls.Count == 0;
                this.Cursor = Cursors.WaitCursor;
                await Task.Run(async () =>
                {
                    Rql.Iie.ExecuteProtections(Rql.Jid, logRichTextBox);
                    await Rql.Jid.Save();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                });

                Logger.Log(
                    logRichTextBox,
                    $"Obfuscation process completed at: {DateTime.Now}. Saving assembly..."
                );
                if (MethodTreeLoader.IsVirt && File.Exists(Rql.Jid.OutPutPath))
                {
                    string vmOutputPath = Path.Combine(
                        XContext.sameLocation
                            ? Path.GetDirectoryName(Rql.Jid.Module.Location)
                            : XContext.dirpath,
                        $"{Path.GetFileNameWithoutExtension(Rql.Jid.Module.Location)}-Obfuscated-VM{Path.GetExtension(Rql.Jid.Module.Location)}"
                    );

                    await Task.Run(() =>
                    {
                        Logger.Log(logRichTextBox, "Executing Code Virtualization...");
                        List<MethodDef> methodsToVirtualize =
                            MethodTreeLoader.ResolveMethodsFromTokens(
                                Rql.Jid.Module,
                                Rql.xi0.GetSelectedMethodTokens()
                            );
                        HashSet<MethodDef> uniqueMethods =
                            new HashSet<MethodDef>(methodsToVirtualize);

                        virtualizedModule = ModuleDefMD.Load(Rql.Jid.OutPutPath);
                        new XVMTask()
                            .Execute(virtualizedModule, uniqueMethods, vmOutputPath, Rql.si2(), "", "");
                    });
                }
                if (XContext.Pack)
                {
                    await Task.Run(() =>
                    {
                        Logger.Log(logRichTextBox, "Executing Native Packer...");
                        new Pack().PackAsm(Rql.Jid.OutPutPath);
                        Logger.Log(
                            logRichTextBox,
                            "Execution of Native Packer completed."
                        );
                    });
                }

                Logger.Log(logRichTextBox, "Obfuscated assembly saved successfully!");
            }
            catch (Exception ex)
            {
                progressBar.Style = ProgressBarStyle.Blocks;
                Logger.Log(logRichTextBox, $"An error occurred: {ex.Message}");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                closeButton.Enabled = true;
                progressBar.Style = ProgressBarStyle.Blocks;

                if (PlaySoundOnFinish)
                {
                    try
                    {
                        using (var player = new SoundPlayer(Resources.sound))
                        {
                            player.Play();
                        }
                    }
                    catch
                    {
                    }
                }

                if (OpenDirectoryOnFinish && !string.IsNullOrEmpty(OutputDirectoryPath))
                {
                    Process.Start(OutputDirectoryPath);
                }
                ProtectionManager.clearInjected();
                GGeneration.stored.Clear();
                Rql.Jid?.Dispose();
                Rql.Jid = null;
                virtualizedModule?.Dispose();
            }
        }


        private void headerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            dragStartPoint = Cursor.Position;
            formStartPoint = this.Location;
        }

        private void headerPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Opacity = 0.96;
                Cursor = Cursors.Hand;
                Point diff = Point.Subtract(Cursor.Position, new Size(dragStartPoint));
                this.Location = Point.Add(formStartPoint, new Size(diff));
            }
        }

        private void headerPanel_MouseUp(object sender, MouseEventArgs e)
        {
            this.Opacity = 1.0;
            Cursor = Cursors.Default;
            isDragging = false;
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void XLogger_Shown(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources =
            new System.ComponentModel.ComponentResourceManager(typeof(XLogger));
            this.guna2Elipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.headerPanel = new System.Windows.Forms.Panel();
            this.closeButton = new Guna.UI2.WinForms.Guna2ImageButton();
            this.loggerTitleLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.headerTitleLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.logRichTextBox = new System.Windows.Forms.RichTextBox();
            this.progressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.shadowForm = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.headerPanel.SuspendLayout();
            base.SuspendLayout();
            //
            // guna2Elipse
            //
            this.guna2Elipse.BorderRadius = 10;
            this.guna2Elipse.TargetControl = this;
            //
            // headerPanel
            //
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(26, 26, 26);
            this.headerPanel.Controls.Add(this.closeButton);
            this.headerPanel.Controls.Add(this.loggerTitleLabel);
            this.headerPanel.Controls.Add(this.headerTitleLabel);
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(440, 40);
            this.headerPanel.TabIndex = 7;
            this.headerPanel.MouseDown +=
                new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseDown);
            this.headerPanel.MouseMove +=
                new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseMove);
            this.headerPanel.MouseUp +=
                new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseUp);
            //
            // closeButton
            //
            this.closeButton.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.HoverState.ImageSize = new System.Drawing.Size(14, 14);
            this.closeButton.Image =
                (System.Drawing.Image)resources.GetObject("closeForm.Image");
            this.closeButton.ImageOffset = new System.Drawing.Point(0, 0);
            this.closeButton.ImageRotate = 0f;
            this.closeButton.ImageSize = new System.Drawing.Size(15, 15);
            this.closeButton.Location = new System.Drawing.Point(410, 11);
            this.closeButton.Name = "closeButton";
            this.closeButton.PressedState.ImageSize = new System.Drawing.Size(13, 13);
            this.closeButton.Size = new System.Drawing.Size(18, 18);
            this.closeButton.TabIndex = 18;
            this.closeButton.Click +=
                new System.EventHandler(this.closeButton_Click);
            //
            // loggerTitleLabel
            //
            this.loggerTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.loggerTitleLabel.Font = new System.Drawing.Font(
                "Bahnschrift SemiCondensed",
                9.75f,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point,
                0
            );
            this.loggerTitleLabel.ForeColor = System.Drawing.Color.White;
            this.loggerTitleLabel.IsContextMenuEnabled = false;
            this.loggerTitleLabel.IsSelectionEnabled = false;
            this.loggerTitleLabel.Location = new System.Drawing.Point(43, 11);
            this.loggerTitleLabel.Name = "loggerTitleLabel";
            this.loggerTitleLabel.Size = new System.Drawing.Size(43, 18);
            this.loggerTitleLabel.TabIndex = 4;
            this.loggerTitleLabel.Text = "LOGGER";
            this.loggerTitleLabel.MouseDown +=
                new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseDown);
            this.loggerTitleLabel.MouseMove +=
                new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseMove);
            this.loggerTitleLabel.MouseUp +=
                new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseUp);
            //
            // headerTitleLabel
            //
            this.headerTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.headerTitleLabel.Font = new System.Drawing.Font(
                "Bahnschrift SemiCondensed",
                9.75f,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point,
                0
            );
            this.headerTitleLabel.ForeColor =
                System.Drawing.Color.FromArgb(222, 85, 85);
            this.headerTitleLabel.IsContextMenuEnabled = false;
            this.headerTitleLabel.IsSelectionEnabled = false;
            this.headerTitleLabel.Location = new System.Drawing.Point(10, 11);
            this.headerTitleLabel.Name = "headerTitleLabel";
            this.headerTitleLabel.Size = new System.Drawing.Size(32, 18);
            this.headerTitleLabel.TabIndex = 2;
            this.headerTitleLabel.Text = "XERIN";
            this.headerTitleLabel.MouseDown +=
                new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseDown);
            this.headerTitleLabel.MouseMove +=
                new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseMove);
            this.headerTitleLabel.MouseUp +=
                new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseUp);
            //
            // logRichTextBox
            //
            this.logRichTextBox.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.logRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logRichTextBox.Font = new System.Drawing.Font(
                "Bahnschrift SemiCondensed",
                9.75f,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point,
                0
            );
            this.logRichTextBox.ForeColor = System.Drawing.Color.White;
            this.logRichTextBox.Location = new System.Drawing.Point(12, 53);
            this.logRichTextBox.Name = "logRichTextBox";
            this.logRichTextBox.ReadOnly = true;
            this.logRichTextBox.Size = new System.Drawing.Size(416, 292);
            this.logRichTextBox.TabIndex = 8;
            this.logRichTextBox.Text = "";
            //
            // progressBar
            //
            this.progressBar.FillColor = System.Drawing.Color.FromArgb(36, 36, 36);
            this.progressBar.Location = new System.Drawing.Point(0, 357);
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressColor =
                System.Drawing.Color.FromArgb(222, 85, 85);
            this.progressBar.ProgressColor2 =
                System.Drawing.Color.FromArgb(222, 85, 85);
            this.progressBar.Size = new System.Drawing.Size(440, 2);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 9;
            this.progressBar.TextRenderingHint =
                System.Drawing.Text.TextRenderingHint.SystemDefault;
            //
            // shadowForm
            //
            this.shadowForm.BorderRadius = 0;
            this.shadowForm.TargetForm = this;
            //
            // XLogger
            //
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            base.ClientSize = new System.Drawing.Size(440, 360);
            base.Controls.Add(this.progressBar);
            base.Controls.Add(this.logRichTextBox);
            base.Controls.Add(this.headerPanel);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(440, 360);
            base.Name = "XLogger";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            base.Load += new System.EventHandler(this.XLogger_Load);
            base.Shown += new System.EventHandler(this.XLogger_Shown);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            base.ResumeLayout(false);
        }
    }
}