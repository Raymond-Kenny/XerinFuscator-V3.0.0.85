using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using XCore.Utils;

namespace XCore.Injection
{
	public class newInjector
	{
		[CompilerGenerated]
		private List<IDnlibDef> IYo;

		[CompilerGenerated]
		private Type xYD;

		[SpecialName]
		[CompilerGenerated]
		private List<IDnlibDef> lYJ()
		{
			return IYo;
		}

		[SpecialName]
		[CompilerGenerated]
		private void fYt(List<IDnlibDef> list_0)
		{
			IYo = list_0;
		}

		[SpecialName]
		[CompilerGenerated]
		private Type JY6()
		{
			return xYD;
		}

		[SpecialName]
		[CompilerGenerated]
		private void MY0(Type type_0)
		{
			xYD = type_0;
		}

		public IDnlibDef FindMember(string string_0)
		{
			foreach (IDnlibDef item in lYJ())
			{
				if (item.Name == string_0)
				{
					return item;
				}
			}
			throw new Exception("Error to find member.");
		}

		public newInjector(ModuleDefMD moduleDefMD_0, Type type_0, bool bool_0 = true)
		{
			MY0(type_0);
			fYt(new List<IDnlibDef>());
			if (bool_0)
			{
				InjectType(moduleDefMD_0);
			}
		}

		public void InjectType(ModuleDefMD moduleDefMD_0)
		{
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(JY6().Module);
			TypeDef typeDef_ = moduleDefMD.ResolveTypeDef(MDToken.ToRID(JY6().MetadataToken));
			lYJ().AddRange(InjectHelper.Inject(typeDef_, moduleDefMD_0.GlobalType, moduleDefMD_0).ToList());
			foreach (IDnlibDef item in lYJ())
			{
				(item as MethodDef)?.excludeMethod(moduleDefMD_0);
			}
		}

		public void injectMethod(string string_0, string string_1, ModuleDefMD moduleDefMD_0, MethodDef methodDef_0)
		{
			TypeDef typeDef = new TypeDefUser(string_0, string_1, moduleDefMD_0.CorLibTypes.Object.TypeDefOrRef)
			{
				Attributes = TypeAttributes.Public
			};
			moduleDefMD_0.Types.Add(typeDef);
			methodDef_0.DeclaringType = null;
			typeDef.Methods.Add(methodDef_0);
		}

		public void injectMethods(string string_0, string string_1, ModuleDefMD moduleDefMD_0, MethodDef[] methodDef_0)
		{
			TypeDef typeDef = new TypeDefUser(string_0, string_1, moduleDefMD_0.CorLibTypes.Object.TypeDefOrRef)
			{
				Attributes = TypeAttributes.Public
			};
			moduleDefMD_0.Types.Add(typeDef);
			foreach (MethodDef methodDef in methodDef_0)
			{
				methodDef.DeclaringType = null;
				typeDef.Methods.Add(methodDef);
			}
		}

		public void Rename()
		{
			foreach (IDnlibDef item in lYJ())
			{
				MethodDef methodDef = item as MethodDef;
				if (methodDef == null || (!methodDef.HasImplMap && !methodDef.DeclaringType.IsDelegate))
				{
					XCore.Utils.Utils.MethodsRenamig(item);
				}
			}
		}
	}
}
