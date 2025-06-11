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
	public class AntiEmulate : Protection
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class lRv
		{
			public static readonly lRv iRV;

			public static Func<Instruction, bool> LR4;

			public static Func<Instruction, bool> yRs;

			static lRv()
			{
				iRV = new lRv();
			}

			internal bool YRO(Instruction instruction_0)
			{
				return instruction_0.OpCode == OpCodes.Ldstr;
			}

			internal bool vRu(Instruction instruction_0)
			{
				return instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill");
			}
		}

		private static newInjector W8Z;

		private static MethodDef l8F;

		public override string name => "Anti Emulate";

		public override int number => 11;

		public override void Execute(XContext xcontext_0)
		{
			W8Z = new newInjector(xcontext_0.Module, typeof(AntiEmulating));
			l8F = W8Z.FindMember("Initialize") as MethodDef;
			MethodDef methodDef = xcontext_0.Module.GlobalType.FindOrCreateStaticConstructor();
			methodDef.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(l8F));
			foreach (Instruction item in l8F.Body.Instructions.Where((Instruction instruction_0) => instruction_0.OpCode == OpCodes.Ldstr))
			{
				if (item.Operand.ToString() == "you are gay :)")
				{
					item.Operand = "keyauth.win";
				}
			}
			foreach (Instruction item2 in l8F.Body.Instructions.Where((Instruction instruction_0) => instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill")))
			{
				item2.Operand = Terminate.Kill;
			}
			W8Z.Rename();
			MethodDef[] array = new MethodDef[1] { l8F };
			stillWorkingOn2.EncodeFor(xcontext_0, array);
			MethodDef[] array2 = array;
			foreach (MethodDef methodDef_ in array2)
			{
				new ThirdMutationStage().ExecuteFor(xcontext_0, methodDef_);
			}
		}
	}
}
