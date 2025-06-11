using dnlib.DotNet;

namespace XCore.Optimizer
{
	public class UnverifiableCodeAttributeAttr
	{
		public static bool attr;

		public static void setAttr(ModuleDefMD moduleDefMD_0)
		{
			moduleDefMD_0.CustomAttributes.Add(new CustomAttribute(new MemberRefUser(moduleDefMD_0, ".ctor", MethodSig.CreateInstance(moduleDefMD_0.CorLibTypes.Void), moduleDefMD_0.CorLibTypes.GetTypeRef("System.Security", "UnverifiableCodeAttribute"))));
		}
	}
}
