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
	public class AntiSkipping : Protection
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class YRI
		{
			public static readonly YRI aRZ;

			public static Func<Instruction, bool> JRF;

			public static Func<Instruction, bool> ERD;

			static YRI()
			{
				aRZ = new YRI();
			}

			internal bool IRT(Instruction instruction_0)
			{
				return instruction_0.OpCode == OpCodes.Ldstr;
			}

			internal bool VRi(Instruction instruction_0)
			{
				return instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill");
			}
		}

		public static bool isRenamer;

		public override string name => "Anti Form Skip";

		public override int number => 1;

		public override void Execute(XContext xcontext_0)
		{
			MethodDef methodDef = null;
			try
			{
				methodDef = xcontext_0.Module.EntryPoint;
			}
			catch
			{
			}
			if (methodDef == null)
			{
				return;
			}
			IMethod method = null;
			string operand = "";
			for (int i = 0; i < methodDef.Body.Instructions.Count - 1; i++)
			{
				Instruction instruction = methodDef.Body.Instructions[i];
				Instruction instruction2 = methodDef.Body.Instructions[i + 1];
				if (instruction.OpCode == OpCodes.Newobj && instruction2.OpCode == OpCodes.Call && instruction2.Operand is IMethod method2 && method2.FullName.Contains("System.Windows.Forms.Application::Run"))
				{
					method = instruction.Operand as IMethod;
					operand = method.DeclaringType.Name;
					break;
				}
			}
			if (method == null)
			{
				return;
			}
			newInjector newInjector = new newInjector(xcontext_0.Module, typeof(XRuntime.AntiSkipping));
			MethodDef methodDef2 = newInjector.FindMember("Initialize") as MethodDef;
			MethodDef methodDef3 = newInjector.FindMember("Btn_Click") as MethodDef;
			foreach (Instruction item in methodDef2.Body.Instructions.Where((Instruction instruction_0) => instruction_0.OpCode == OpCodes.Ldstr))
			{
				if (item.Operand.ToString() == "Name")
				{
					item.Operand = operand;
				}
			}
			foreach (Instruction item2 in methodDef2.Body.Instructions.Where((Instruction instruction_0) => instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill")))
			{
				item2.Operand = Terminate.Kill;
			}
			MethodDef[] array = new MethodDef[2] { methodDef2, methodDef3 };
			for (int num = 0; num < methodDef.Body.Instructions.Count - 1; num++)
			{
				Instruction instruction3 = methodDef.Body.Instructions[num];
				Instruction instruction4 = methodDef.Body.Instructions[num + 1];
				if (instruction3.OpCode == OpCodes.Newobj && instruction4.OpCode == OpCodes.Call && instruction4.Operand is IMethod method3 && method3.FullName.Contains("System.Windows.Forms.Application::Run"))
				{
					methodDef.Body.Instructions[num + 1] = OpCodes.Call.ToInstruction(methodDef2);
					num++;
				}
			}
			newInjector.Rename();
			stillWorkingOn2.EncodeFor(xcontext_0, array);
			MethodDef[] array2 = array;
			foreach (MethodDef methodDef_ in array2)
			{
				new ThirdMutationStage().ExecuteFor(xcontext_0, methodDef_);
			}
		}
	}
}
