using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XF
{
	internal static class xKN
	{
		public static void SK2(ModuleDef moduleDef_0)
		{
			AKK(moduleDef_0);
		}

		private static void AKK(ModuleDef moduleDef_0)
		{
			TypeDef typeDef = moduleDef_0.Find(TNd.XN8, isReflectionName: true);
			MethodDef methodDef = typeDef.FindMethod(TNd.sN3);
			foreach (ExceptionHandler exceptionHandler in methodDef.Body.ExceptionHandlers)
			{
				if (exceptionHandler.HandlerType == ExceptionHandlerType.Catch)
				{
					exceptionHandler.CatchType = moduleDef_0.CorLibTypes.Object.ToTypeDefOrRef();
				}
			}
			SK1(typeDef.FindMethod(TNd.NNz).Body);
			typeDef.Methods.Remove(typeDef.FindMethod(TNd.Y24));
		}

		private static void SK1(CilBody cilBody_0)
		{
			for (int i = 0; i < cilBody_0.Instructions.Count; i++)
			{
				if (cilBody_0.Instructions[i].Operand is IMethod method && method.Name == TNd.Y24)
				{
					cilBody_0.Instructions.RemoveAt(i);
				}
			}
		}
	}
}
