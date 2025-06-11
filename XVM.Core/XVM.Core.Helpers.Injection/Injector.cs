using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using XVM.Core.Services;

namespace XVM.Core.Helpers.Injection
{
	public class Injector
	{
		[CompilerGenerated]
		private readonly ModuleDef Lt9;

		[CompilerGenerated]
		private readonly Type jtG;

		[CompilerGenerated]
		private readonly List<IDnlibDef> stI;

		public ModuleDef TargetModule
		{
			[CompilerGenerated]
			get
			{
				return Lt9;
			}
		}

		public Type RuntimeType
		{
			[CompilerGenerated]
			get
			{
				return jtG;
			}
		}

		public List<IDnlibDef> Members
		{
			[CompilerGenerated]
			get
			{
				return stI;
			}
		}

		public Injector(ModuleDef moduleDef_0, Type type_0, bool bool_0 = true)
		{
			Lt9 = moduleDef_0;
			jtG = type_0;
			stI = new List<IDnlibDef>();
			if (bool_0)
			{
				InjectType();
			}
		}

		public void InjectType()
		{
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(RuntimeType.Module);
			TypeDef typeDef_ = moduleDefMD.ResolveTypeDef(MDToken.ToRID(RuntimeType.MetadataToken));
			Members.AddRange(InjectHelper.Inject(typeDef_, TargetModule.GlobalType, TargetModule).ToList());
		}

		public IDnlibDef FindMember(string string_0)
		{
			foreach (IDnlibDef member in Members)
			{
				if (member.Name == string_0)
				{
					return member;
				}
			}
			throw new Exception("Error to find member.");
		}

		public void Rename()
		{
			foreach (IDnlibDef member in Members)
			{
				if (!(member is MethodDef methodDef) || (!methodDef.HasImplMap && !methodDef.DeclaringType.IsDelegate))
				{
					member.Name = new RandomGenerator().NextHexString(bool_0: true);
				}
			}
		}
	}
}
