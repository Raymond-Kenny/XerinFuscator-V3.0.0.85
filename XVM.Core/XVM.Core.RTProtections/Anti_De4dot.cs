using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XVM.Core.RTProtections
{
	public class Anti_De4dot
	{
		private static ModuleDef hKX;

		private static void bK3(object object_0)
		{
			TypeRef typeRef = hKX.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser(string.Empty, "ZYXDNGuarder", typeRef);
			hKX.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(hKX.CorLibTypes.Void, hKX.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			methodDefUser.Body.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
			methodDefUser.Body.Instructions.Add(OpCodes.Call.ToInstruction(new MemberRefUser(hKX, ".ctor", MethodSig.CreateInstance(hKX.CorLibTypes.Void), typeRef)));
			methodDefUser.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
			typeDefUser.Methods.Add(methodDefUser);
		}

		public static void Execute(ModuleDef moduleDef_0, string string_0)
		{
			hKX = moduleDef_0;
			bK3(string_0);
		}
	}
}
