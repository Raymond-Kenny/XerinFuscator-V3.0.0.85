using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using dnlib.DotNet;

namespace XCore.Resolver
{
	public static class AssemblyResolve
	{
		public static void LoadAssemblies(ModuleDefMD moduleDefMD_0)
		{
			AssemblyResolver assemblyResolver = new AssemblyResolver
			{
				EnableTypeDefCache = true
			};
			ModuleContext context = (assemblyResolver.DefaultModuleContext = new ModuleContext(assemblyResolver));
			if (Type.GetType("Mono.Runtime") != null)
			{
				try
				{
					string text = oUW();
					if (string.IsNullOrEmpty(text))
					{
						assemblyResolver.PostSearchPaths.Add("/usr/lib/mono/gac");
						assemblyResolver.PostSearchPaths.Add("/usr/local/lib/mono/gac");
					}
					else
					{
						assemblyResolver.PostSearchPaths.Add(Path.Combine(text, "gac"));
					}
				}
				catch
				{
				}
			}
			moduleDefMD_0.Context = context;
			List<AssemblyRef> list = moduleDefMD_0.GetAssemblyRefs().ToList();
			foreach (AssemblyRef item in list)
			{
				try
				{
					if (item != null)
					{
						AssemblyDef assemblyDef = assemblyResolver.Resolve(item.FullName, moduleDefMD_0);
						if (assemblyDef != null)
						{
							moduleDefMD_0.Context.AssemblyResolver.Resolve(assemblyDef, moduleDefMD_0);
						}
					}
				}
				catch
				{
				}
			}
		}

		private static string oUW()
		{
			try
			{
				Process process = new Process
				{
					StartInfo = new ProcessStartInfo
					{
						FileName = "mono",
						Arguments = "--version",
						RedirectStandardOutput = true,
						UseShellExecute = false,
						CreateNoWindow = true
					}
				};
				process.Start();
				string text = process.StandardOutput.ReadToEnd();
				process.WaitForExit();
				if (text.Contains("Mono"))
				{
					string text2 = "/usr/lib/mono";
					if (Directory.Exists(text2))
					{
						return text2;
					}
					text2 = "/usr/local/lib/mono";
					if (Directory.Exists(text2))
					{
						return text2;
					}
				}
			}
			catch
			{
			}
			return null;
		}
	}
}
