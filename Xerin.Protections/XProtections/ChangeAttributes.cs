using System;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using XCore.Generator;

namespace XProtections
{
	public static class ChangeAttributes
	{
		[CompilerGenerated]
		private sealed class DRd
		{
			public string DRM;

			internal bool NR3(CustomAttribute customAttribute_0)
			{
				return customAttribute_0.AttributeType.FullName == DRM;
			}
		}

		[CompilerGenerated]
		private sealed class NRe
		{
			public string mRJ;

			internal bool oRC(CustomAttribute customAttribute_0)
			{
				return customAttribute_0.AttributeType.FullName == mRJ;
			}
		}

		private static readonly Random L8E;

		public static void Execute(ModuleDefMD moduleDefMD_0)
		{
			if (moduleDefMD_0?.Assembly != null)
			{
				AssemblyDef assembly = moduleDefMD_0.Assembly;
				string[] array = new string[6] { "System.Reflection.AssemblyTitleAttribute", "System.Reflection.AssemblyDescriptionAttribute", "System.Reflection.AssemblyCompanyAttribute", "System.Reflection.AssemblyProductAttribute", "System.Reflection.AssemblyCopyrightAttribute", "System.Reflection.AssemblyTrademarkAttribute" };
				string[] array2 = array;
				foreach (string string_ in array2)
				{
					t81(moduleDefMD_0, assembly, string_);
				}
				X8S(moduleDefMD_0, assembly);
			}
		}

		private static void t81(ModuleDef moduleDef_0, AssemblyDef assemblyDef_0, string string_0)
		{
			CustomAttribute customAttribute = assemblyDef_0.CustomAttributes.FirstOrDefault((CustomAttribute customAttribute_0) => customAttribute_0.AttributeType.FullName == string_0);
			if (customAttribute == null)
			{
				try
				{
					TypeRef typeRef = moduleDef_0.CorLibTypes.GetTypeRef("mscorlib", string_0);
					MemberRef ctor = moduleDef_0.Import(typeRef.ResolveTypeDefThrow().FindConstructors().FirstOrDefault());
					CustomAttribute customAttribute2 = new CustomAttribute(ctor);
					customAttribute2.ConstructorArguments.Add(new CAArgument(moduleDef_0.CorLibTypes.String, GGeneration.GenerateGuidStartingWithLetter()));
					assemblyDef_0.CustomAttributes.Add(customAttribute2);
					return;
				}
				catch
				{
					return;
				}
			}
			if (customAttribute.ConstructorArguments.Count > 0)
			{
				customAttribute.ConstructorArguments[0] = new CAArgument(moduleDef_0.CorLibTypes.String, GGeneration.GenerateGuidStartingWithLetter());
			}
		}

		private static void X8S(ModuleDef moduleDef_0, AssemblyDef assemblyDef_0)
		{
			string object_ = $"{L8E.Next(1, 10)}.{L8E.Next(0, 10)}.{L8E.Next(0, 10)}.{L8E.Next(0, 100)}";
			J8b(moduleDef_0, assemblyDef_0, "System.Reflection.AssemblyVersionAttribute", object_);
			J8b(moduleDef_0, assemblyDef_0, "System.Reflection.AssemblyFileVersionAttribute", object_);
		}

		private static void J8b(ModuleDef moduleDef_0, AssemblyDef assemblyDef_0, string string_0, object object_0)
		{
			CustomAttribute customAttribute = assemblyDef_0.CustomAttributes.FirstOrDefault((CustomAttribute customAttribute_0) => customAttribute_0.AttributeType.FullName == string_0);
			if (customAttribute == null)
			{
				try
				{
					TypeRef typeRef = moduleDef_0.CorLibTypes.GetTypeRef("mscorlib", string_0);
					MemberRef ctor = moduleDef_0.Import(typeRef.ResolveTypeDefThrow().FindConstructors().FirstOrDefault());
					CustomAttribute customAttribute2 = new CustomAttribute(ctor);
					customAttribute2.ConstructorArguments.Add(new CAArgument(moduleDef_0.CorLibTypes.String, object_0));
					assemblyDef_0.CustomAttributes.Add(customAttribute2);
					return;
				}
				catch
				{
					return;
				}
			}
			if (customAttribute.ConstructorArguments.Count > 0)
			{
				customAttribute.ConstructorArguments[0] = new CAArgument(moduleDef_0.CorLibTypes.String, object_0);
			}
		}

		static ChangeAttributes()
		{
			L8E = new Random();
		}
	}
}
