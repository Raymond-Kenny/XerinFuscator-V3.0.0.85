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
	public class AntiTamper : Protection
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class IRY
		{
			public static readonly IRY KRp;

			public static Func<Instruction, bool> ARX;

			static IRY()
			{
				KRp = new IRY();
			}

			internal bool zRB(Instruction instruction_0)
			{
				return instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill");
			}
		}

		private static newInjector g8D;

		private static MethodDef S8v;

		private static MethodDef E8O;

		private static MethodDef T8u;

		private static MethodDef t8V;

		public override string name => "Anti Tamper";

		public override int number => 12;

		public override void Execute(XContext xcontext_0)
		{
			g8D = new newInjector(xcontext_0.Module, typeof(XRuntime.AntiTamper));
			S8v = g8D.FindMember("Initialize") as MethodDef;
			E8O = g8D.FindMember("AnalyzeMethod") as MethodDef;
			T8u = g8D.FindMember("CheckDynamicCalls") as MethodDef;
			t8V = g8D.FindMember("DetectMethodModification") as MethodDef;
			MethodDef methodDef = xcontext_0.Module.GlobalType.FindOrCreateStaticConstructor();
			methodDef.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(S8v));
			foreach (Instruction item in S8v.Body.Instructions.Where((Instruction instruction_0) => instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill")))
			{
				item.Operand = Terminate.Kill;
			}
			g8D.Rename();
			MethodDef[] array = new MethodDef[1] { S8v };
			stillWorkingOn2.EncodeFor(xcontext_0, array);
			MethodDef[] array2 = array;
			foreach (MethodDef methodDef_ in array2)
			{
				new ThirdMutationStage().ExecuteFor(xcontext_0, methodDef_);
			}
		}
	}
}
