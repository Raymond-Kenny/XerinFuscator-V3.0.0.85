using System.IO;
using System.Reflection;
using dnlib.DotNet;

namespace XF
{
	internal class ERw
	{
		private static object dR1;

		public static TypeDef LRE(string string_0, string string_1)
		{
			if (dR1 == null)
			{
				UR2(string_0);
			}
			return ((ModuleDef)dR1).Find(string_1, isReflectionName: true);
		}

		public static TypeDef JRN(Module module_0, string string_0)
		{
			if (dR1 == null)
			{
				QRK(module_0);
			}
			return ((ModuleDef)dR1).Find(string_0, isReflectionName: true);
		}

		private static void UR2(string string_0)
		{
			Module manifestModule = typeof(ERw).Assembly.ManifestModule;
			string text = string_0;
			ModuleCreationOptions options = new ModuleCreationOptions
			{
				TryToLoadPdbFromDisk = true
			};
			if (manifestModule.FullyQualifiedName[0] != '<')
			{
				text = Path.Combine(Path.GetDirectoryName(manifestModule.FullyQualifiedName), text);
				if (File.Exists(text))
				{
					try
					{
						dR1 = ModuleDefMD.Load(text, options);
					}
					catch (IOException)
					{
					}
				}
				if (dR1 == null)
				{
					text = string_0;
				}
			}
			if (dR1 == null)
			{
				dR1 = ModuleDefMD.Load(text, options);
			}
			((ModuleDef)dR1).EnableTypeDefFindCache = true;
		}

		private static void QRK(Module module_0)
		{
			ModuleCreationOptions options = new ModuleCreationOptions
			{
				TryToLoadPdbFromDisk = true
			};
			if (dR1 == null)
			{
				try
				{
					dR1 = ModuleDefMD.Load(module_0, options);
				}
				catch (IOException)
				{
				}
			}
			((ModuleDef)dR1).EnableTypeDefFindCache = true;
		}
	}
}
