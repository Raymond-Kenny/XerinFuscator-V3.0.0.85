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
	public class AntiDebug : Protection
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class YRy
		{
			public static readonly YRy DRn;

			public static Func<Instruction, bool> CRK;

			public static Func<Instruction, bool> ERG;

			static YRy()
			{
				DRn = new YRy();
			}

			internal bool VRg(Instruction instruction_0)
			{
				return instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill");
			}

			internal bool CRo(Instruction instruction_0)
			{
				return instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill");
			}
		}

		private static newInjector X84;

		private static MethodDef N8s;

		private static MethodDef L8Y;

		public override string name => "Anti Debug";

		public override int number => 10;

		public override void Execute(XContext xcontext_0)
		{
			AntiHook.Execute(xcontext_0);
			X84 = new newInjector(xcontext_0.Module, typeof(AntiDebugRuntime));
			N8s = X84.FindMember("Initialize") as MethodDef;
			L8Y = X84.FindMember("Detector") as MethodDef;
			MethodDef methodDef = xcontext_0.Module.GlobalType.FindOrCreateStaticConstructor();
			methodDef.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(N8s));
			foreach (Instruction item in N8s.Body.Instructions.Where((Instruction instruction_0) => instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill")))
			{
				item.Operand = Terminate.Kill;
			}
			foreach (Instruction item2 in L8Y.Body.Instructions.Where((Instruction instruction_0) => instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill")))
			{
				item2.Operand = Terminate.Kill;
			}
			X84.Rename();
			MethodDef[] methodDef_ = new MethodDef[2] { N8s, L8Y };
			stillWorkingOn2.EncodeFor(xcontext_0, methodDef_);
			new ThirdMutationStage().ExecuteFor(xcontext_0, N8s);
			new ThirdMutationStage().ExecuteFor(xcontext_0, L8Y);
		}
	}
}
