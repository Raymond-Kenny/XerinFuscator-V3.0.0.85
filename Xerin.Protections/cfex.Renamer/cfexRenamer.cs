using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Confuser.Core;
using Confuser.Core.Project;
using dnlib.DotNet;
using XCore.Context;
using XCore.Protections;
using Protection = XCore.Protections.Protection;


namespace cfex.Renamer
{
	public class cfexRenamer : Protection
	{
		public static XContext context;

		public override string name => "cfex Renamer";

		public override int number => 0;

		public override void Execute(XContext xcontext_0)
		{
			string text = "";
			try
			{
				ConfuserProject val = new ConfuserProject
				{
					BaseDirectory = Path.GetDirectoryName(xcontext_0.Path)
				};
				val.OutputDirectory = Path.Combine(val.BaseDirectory, "tmp");
				text = val.OutputDirectory;
				ProjectModule item = new ProjectModule
				{
					Path = Path.GetFileName(xcontext_0.Path)
				};
				((List<ProjectModule>)(object)val).Add(item);
				Rule val2 = new Rule("true", (ProtectionPreset)0, false);
				SettingItem<Protection> item2 = new SettingItem<Protection>("rename", (SettingItemAction)0);
				((List<SettingItem<Protection>>)(object)val2).Add(item2);
				val.Rules.Add(val2);
				XmlDocument xmlDocument = val.Save();
				string text2 = Path.Combine(Directory.GetCurrentDirectory(), "Renamer", "temp.crproj");
				xmlDocument.Save(text2);
				Process process = new Process();
				process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				process.StartInfo.FileName = "Renamer\\Confuser.CLI.exe";
				process.StartInfo.Arguments = "-n Renamer\\temp.crproj";
				process.Start();
				process.WaitForExit();
				File.Delete(text2);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			string text3 = Path.Combine(text);
			string text4 = Path.Combine(text3, Path.GetFileName(xcontext_0.Path));
			xcontext_0.tmp = text3;
			if (File.Exists(text4))
			{
				xcontext_0.Module = ModuleDefMD.Load(text4);
			}
		}
	}
}
