using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using XCore.Context;
using XCore.Decompression;
using XCore.Embed;
using XCore.Junk;
using XCore.Terminator;
using XF;
using XProtections;

namespace XCore.Protections
{
    public class ProtectionManager
    {
        [Serializable]
        [CompilerGenerated]
        private sealed class atm
        {
            public static readonly atm Etf;

            public static Func<Protection, jo<int, string>> HtT;

            public static Func<IGrouping<jo<int, string>, Protection>, Protection> Kti;

            public static Comparison<Protection> TtS;

            static atm()
            {
                Etf = new atm();
            }

            internal jo<int, string> GtA(Protection protection_0)
            {
                return new jo<int, string>(protection_0.number, protection_0.name);
            }

            internal Protection ft9(IGrouping<jo<int, string>, Protection> igrouping_0)
            {
                return igrouping_0.First();
            }

            internal int DtP(Protection protection_0, Protection protection_1)
            {
                return protection_0.number.CompareTo(protection_1.number);
            }
        }

        [CompilerGenerated]
        private sealed class Htl
        {
            public Protection mtI;

            internal bool jtO(Protection protection_0)
            {
                return protection_0.name == mtI.name;
            }
        }

        public static List<Protection> Protections;

        public void AddProtection(Protection protection_0)
        {
            Protections.Add(protection_0);
        }

        public void RemoveProtection(Protection protection_0)
        {
            Protection protection = Protections.FirstOrDefault((Protection protection2) => protection2.name == protection_0.name);
            if (protection != null)
            {
                Protections.Remove(protection);
            }
        }

        public void ExecuteProtections(XContext xcontext_0, RichTextBox richTextBox_0)
        {
            DateTime now = DateTime.Now;
            cUG();
            if (!Protections.Contains(new cctorHider()))
            {
                AddProtection(new cctorHider());
            }
            RemoveDuplicatedProtections();
            Logger.Log(richTextBox_0, $"Obfuscation process has been started at: {now}");
            foreach (Protection protection in Protections)
            {
                if (protection.number >= 1 && SelfString.XorCipher == null && Terminate.Kill == null && QuickLZ.QLZDecompression == null)
                {
                    new QuickLZ().injectQuickLZ(xcontext_0);
                    new Terminate().injectKill(xcontext_0);
                    new SelfString().injectXorCipher(xcontext_0);
                    if (XContext.AMSI)
                    {
                        new AmsiBypass().Execute(xcontext_0);
                    }
                }
                Logger.Log(richTextBox_0, "Executing " + protection.name + "....");
                if (protection.number == 15 && Embeder.isEmptyList)
                {
                    Logger.Log(richTextBox_0, "Warning: dlls list is empty, so embed has been canceled!");
                    continue;
                }
                protection.Execute(xcontext_0);
                Logger.Log(richTextBox_0, "Execution of " + protection.name + " completed.");
            }
            Logger.Log(richTextBox_0, "All protections executed successfully.");
        }

        public void ExecuteProtectionsForCLI(XContext xcontext_0)
        {
            DateTime now = DateTime.Now;
            cUG();
            if (!Protections.Contains(new cctorHider()))
            {
                AddProtection(new cctorHider());
            }
            RemoveDuplicatedProtections();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"        => Obfuscation process has been started at: {now}");
            foreach (Protection protection in Protections)
            {
                if (protection.number >= 1 && SelfString.XorCipher == null && Terminate.Kill == null && QuickLZ.QLZDecompression == null)
                {
                    new QuickLZ().injectQuickLZ(xcontext_0);
                    new Terminate().injectKill(xcontext_0);
                    new SelfString().injectXorCipher(xcontext_0);
                    if (XContext.AMSI)
                    {
                        new AmsiBypass().Execute(xcontext_0);
                    }
                }
                if (protection.number != 15 || !Embeder.isEmptyList)
                {
                    protection.Execute(xcontext_0);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("        => Execution of " + protection.name + " completed.");
                }
                else
                {
                    Console.WriteLine("Warning: dlls list is empty, so embed has been canceled!");
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("        => All protections executed successfully.");
        }

        public static void RemoveDuplicatedProtections()
        {
            Protections = (from protection_0 in Protections
                           group protection_0 by new jo<int, string>(protection_0.number, protection_0.name) into igrouping_0
                           select igrouping_0.First()).ToList();
        }

        private void cUG()
        {
            Protections.Sort((Protection protection_0, Protection protection_1) => protection_0.number.CompareTo(protection_1.number));
        }

        public static void clearInjected()
        {
            QuickLZ.QLZDecompression = null;
            Terminate.Kill = null;
            SelfString.XorCipher = null;
            JunkFlow.JunkMethod = null;
        }

        static ProtectionManager()
        {
            Protections = new List<Protection>();
        }
    }
}
