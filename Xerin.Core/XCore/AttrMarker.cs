using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Generator;

namespace XCore
{
	public class AttrMarker
	{
		[CompilerGenerated]
		private sealed class zez
		{
			public ModuleDefMD xJU;

			internal bool GJN(MethodDef methodDef_0)
			{
				return methodDef_0.Parameters.Count == 1 && methodDef_0.Parameters[0].Type == xJU.CorLibTypes.String;
			}
		}

		public static void setAttr(ModuleDefMD moduleDefMD_0)
		{
			TypeRef typeRef = moduleDefMD_0.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDef typeDef = moduleDefMD_0.FindNormal(GGeneration.GenerateGuidStartingWithLetter());
			if (typeDef == null)
			{
				typeDef = new TypeDefUser(string.Empty, GGeneration.GenerateGuidStartingWithLetter(), typeRef);
				moduleDefMD_0.Types.Add(typeDef);
			}
			MethodDef methodDef = typeDef.FindInstanceConstructors().FirstOrDefault((MethodDef methodDef_0) => methodDef_0.Parameters.Count == 1 && methodDef_0.Parameters[0].Type == moduleDefMD_0.CorLibTypes.String);
			if (methodDef == null)
			{
				methodDef = new MethodDefUser(".ctor", MethodSig.CreateInstance(moduleDefMD_0.CorLibTypes.Void, moduleDefMD_0.CorLibTypes.String), dnlib.DotNet.MethodImplAttributes.IL, dnlib.DotNet.MethodAttributes.Public | dnlib.DotNet.MethodAttributes.HideBySig | dnlib.DotNet.MethodAttributes.SpecialName | dnlib.DotNet.MethodAttributes.RTSpecialName)
				{
					Body = new CilBody
					{
						MaxStack = 1
					}
				};
				methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
				methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Call, new MemberRefUser(moduleDefMD_0, ".ctor", MethodSig.CreateInstance(moduleDefMD_0.CorLibTypes.Void), typeRef)));
				methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
				typeDef.Methods.Add(methodDef);
			}
			CustomAttribute customAttribute = new CustomAttribute(methodDef);
			Assembly entryAssembly = Assembly.GetEntryAssembly();
			Version version = entryAssembly.GetName().Version;
			customAttribute.ConstructorArguments.Add(new CAArgument(moduleDefMD_0.CorLibTypes.String, GGeneration.GenerateGuidStartingWithLetter()));
			moduleDefMD_0.CustomAttributes.Add(customAttribute);
			TypeDefUser typeDefUser = new TypeDefUser(GGeneration.GenerateGuidStartingWithLetter(), GGeneration.GenerateGuidStartingWithLetter(), typeRef);
			moduleDefMD_0.Types.Add(typeDefUser);
			moduleDefMD_0.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeRef typeRef2 = moduleDefMD_0.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeRef typeRef3 = moduleDefMD_0.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser item = new TypeDefUser("", "VMProtect", typeRef2);
			moduleDefMD_0.Types.Add(item);
			TypeDefUser item2 = new TypeDefUser("", "Reactor", typeRef3);
			moduleDefMD_0.Types.Add(item2);
			TypeRef typeRef4 = moduleDefMD_0.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser item3 = new TypeDefUser("", "BabelObfuscatorAttribute", typeRef4);
			moduleDefMD_0.Types.Add(item3);
			TypeRef typeRef5 = moduleDefMD_0.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser item4 = new TypeDefUser("", "CrytpoObfuscator", typeRef5);
			moduleDefMD_0.Types.Add(item4);
			TypeRef typeRef6 = moduleDefMD_0.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser item5 = new TypeDefUser("", "ObfuscatedByGoliath", typeRef6);
			moduleDefMD_0.Types.Add(item5);
			methodDef.DeclaringType = null;
			methodDef.Body = new CilBody
			{
				MaxStack = 1
			};
			methodDef.Body.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
			methodDef.Body.Instructions.Add(OpCodes.Call.ToInstruction(new MemberRefUser(moduleDefMD_0, ".ctor", MethodSig.CreateInstance(moduleDefMD_0.CorLibTypes.Void), typeRef)));
			methodDef.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
			typeDefUser.Methods.Add(methodDef);
			CustomAttribute item6 = new CustomAttribute(methodDef);
			customAttribute.ConstructorArguments.Add(new CAArgument(moduleDefMD_0.CorLibTypes.String, GGeneration.GenerateGuidStartingWithLetter()));
			moduleDefMD_0.CustomAttributes.Add(item6);
		}
	}
}
