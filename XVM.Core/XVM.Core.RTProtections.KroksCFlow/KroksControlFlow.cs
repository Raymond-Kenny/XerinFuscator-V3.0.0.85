using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.Services;
using XVM.DynCipher;

namespace XVM.Core.RTProtections.KroksCFlow
{
	public static class KroksControlFlow
	{
		private static readonly RandomGenerator U1w;

		public static void Execute(MethodDef methodDef_0)
		{
			KroksContext kroksContext = new KroksContext
			{
				Intensity = 0.0,
				Depth = 0,
				JunkCode = true,
				Method = methodDef_0,
				StateVariable = new Local(methodDef_0.Module.CorLibTypes.Int32)
			};
			methodDef_0.Body.Variables.Add(kroksContext.StateVariable);
			kroksContext.DynCipher = new DynCipherService();
			kroksContext.Random = new RandomGenerator(32);
			if (methodDef_0.HasBody && methodDef_0.Body.Instructions.Count > 0)
			{
				kroksContext.ProcessMethod(methodDef_0.Body, kroksContext);
				methodDef_0.Body.SimplifyBranches();
			}
		}

		static KroksControlFlow()
		{
			U1w = new RandomGenerator();
		}
	}
}
