using System;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Context;
using XCore.Injection;
using XCore.Terminator;
using XProtections.Mutation;
using XRuntime;

namespace XProtections
{
	public class AntiHook
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class LRa
		{
			public static readonly LRa yR6;

			public static Func<Instruction, bool> URq;

			public static Func<Instruction, bool> pRA;

			public static Func<Instruction, bool> fRl;

			static LRa()
			{
				yR6 = new LRa();
			}

			internal bool UR0(Instruction instruction_0)
			{
				return instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill");
			}

			internal bool jRQ(Instruction instruction_0)
			{
				return instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill");
			}

			internal bool WRr(Instruction instruction_0)
			{
				return instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill");
			}
		}

		private static newInjector a8l;

		private static MethodDef j8I;

		private static MethodDef i8T;

		private static MethodDef m8i;

		public static void Execute(XContext xcontext_0)
		{
			a8l = new newInjector(xcontext_0.Module, typeof(XRuntime.AntiHook));
			j8I = a8l.FindMember("Initialize") as MethodDef;
			i8T = a8l.FindMember("Detector") as MethodDef;
			m8i = a8l.FindMember("DetectHooksForDebugAndCrack") as MethodDef;
			MethodDef methodDef = xcontext_0.Module.GlobalType.FindOrCreateStaticConstructor();
			methodDef.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(j8I));
			foreach (Instruction item in j8I.Body.Instructions.Where((Instruction instruction_0) => instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill")))
			{
				item.Operand = Terminate.Kill;
			}
			foreach (Instruction item2 in i8T.Body.Instructions.Where((Instruction instruction_0) => instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill")))
			{
				item2.Operand = Terminate.Kill;
			}
			foreach (Instruction item3 in m8i.Body.Instructions.Where((Instruction instruction_0) => instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill")))
			{
				item3.Operand = Terminate.Kill;
			}
			a8l.Rename();
			MethodDef[] methodDef_ = new MethodDef[2] { j8I, i8T };
			stillWorkingOn2.EncodeFor(xcontext_0, methodDef_);
			new ThirdMutationStage().ExecuteFor(xcontext_0, j8I);
			new ThirdMutationStage().ExecuteFor(xcontext_0, i8T);
		}
	}
}
