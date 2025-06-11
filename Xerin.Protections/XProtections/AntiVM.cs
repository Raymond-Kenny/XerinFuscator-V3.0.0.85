using System;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Context;
using XCore.Injection;
using XCore.Protections;
using XCore.Terminator;
using XProtections.Mutation;
using XRuntime;

namespace XProtections
{
	public class AntiVM : Protection
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class hRj
		{
			public static readonly hRj oRS;

			public static Func<Instruction, bool> kRE;

			static hRj()
			{
				oRS = new hRj();
			}

			internal bool mR1(Instruction instruction_0)
			{
				return instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill");
			}
		}

		private static newInjector E8X;

		private static MethodDef a8y;

		private static MethodDef w8g;

		public override string name => "Anti VM";

		public override int number => 13;

		public override void Execute(XContext xcontext_0)
		{
			E8X = new newInjector(xcontext_0.Module, typeof(AntiVMRuntime));
			a8y = E8X.FindMember("Initialize") as MethodDef;
			w8g = E8X.FindMember("CspParameters") as MethodDef;
			MethodDef methodDef = xcontext_0.Module.GlobalType.FindOrCreateStaticConstructor();
			methodDef.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(a8y));
			foreach (Instruction item in a8y.Body.Instructions.Where((Instruction instruction_0) => instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill")))
			{
				item.Operand = Terminate.Kill;
			}
			E8X.Rename();
			MethodDef[] array = new MethodDef[2] { a8y, w8g };
			stillWorkingOn2.EncodeFor(xcontext_0, array);
			MethodDef[] array2 = array;
			foreach (MethodDef methodDef_ in array2)
			{
				new ThirdMutationStage().ExecuteFor(xcontext_0, methodDef_);
			}
		}
	}
}
