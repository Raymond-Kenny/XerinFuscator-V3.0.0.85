using System;
using dnlib.DotNet;
using XCore.Context;
using XCore.Generator;
using XCore.Protections;

namespace XProtections
{
	public class AntiDecompiler : Protection
	{
		public override string name => "Anti Decompiler";

		public override int number => 17;

		public override void Execute(XContext xcontext_0)
		{
			ModuleDef manifestModule = xcontext_0.Module.Assembly.ManifestModule;
			TypeRef typeRef = manifestModule.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "SuppressIldasmAttribute");
			MemberRefUser ctor = new MemberRefUser(manifestModule, ".ctor", MethodSig.CreateInstance(manifestModule.CorLibTypes.Void), typeRef);
			CustomAttribute item = new CustomAttribute(ctor);
			manifestModule.CustomAttributes.Add(item);
			ModuleDefMD module = xcontext_0.Module;
			Random random = new Random();
			InterfaceImpl item2 = new InterfaceImplUser(module.GlobalType);
			TypeDef typeDef = new TypeDefUser(GGeneration.GenerateGuidStartingWithLetter(), GGeneration.GenerateGuidStartingWithLetter(), module.CorLibTypes.GetTypeRef("System", "Attribute"));
			InterfaceImpl item3 = new InterfaceImplUser(typeDef);
			module.Types.Add(typeDef);
			typeDef.Interfaces.Add(item3);
			typeDef.Interfaces.Add(item2);
			for (int i = 0; i < random.Next(4, 15); i++)
			{
				TypeDef typeDef2 = new TypeDefUser(GGeneration.GenerateGuidStartingWithLetter(), GGeneration.GenerateGuidStartingWithLetter(), module.CorLibTypes.GetTypeRef("System", "Attribute"));
				InterfaceImpl item4 = new InterfaceImplUser(typeDef2);
				module.Types.Add(typeDef2);
				typeDef2.Interfaces.Add(item4);
				typeDef2.Interfaces.Add(item2);
				typeDef2.Interfaces.Add(item3);
			}
		}
	}
}
