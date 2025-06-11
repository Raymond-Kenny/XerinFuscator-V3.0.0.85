using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class Logger
{
    [CompilerGenerated]
    private sealed class Wt2
    {
        public RichTextBox ltE;

        public string Ntg;

        internal void zts()
        {
            Log(ltE, Ntg);
        }
    }

    public static void Log(RichTextBox richTextBox_0, string string_0)
    {
        if (richTextBox_0.InvokeRequired)
        {
            richTextBox_0.Invoke((MethodInvoker)delegate
            {
                Log(richTextBox_0, string_0);
            });
        }
        else
        {
            richTextBox_0.AppendText(string_0 + Environment.NewLine);
            richTextBox_0.ScrollToCaret();
        }
    }
}

