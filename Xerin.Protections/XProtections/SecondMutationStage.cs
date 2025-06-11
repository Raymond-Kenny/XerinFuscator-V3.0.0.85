using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Context;
using XCore.Protections;
using XCore.Utils;

namespace XProtections
{
	public class SecondMutationStage : Protection
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class VR8
		{
			public static readonly VR8 sR9;

			public static Func<MethodDef, bool> xRw;

			static VR8()
			{
				sR9 = new VR8();
			}

			internal bool BRx(MethodDef methodDef_0)
			{
				return methodDef_0.HasBody && methodDef_0.Body.HasInstructions;
			}
		}

		[CompilerGenerated]
		private sealed class XRR
		{
			public string zRL;

			public Func<TypeDef, bool> OR7;

			internal bool IRm(TypeDef typeDef_0)
			{
				return !typeDef_0.IsGlobalModuleType && typeDef_0.Namespace != zRL;
			}
		}

		public override string name => "Performance mutation stage";

		public override int number => 3;

		public static void executeFor(MethodDef methodDef_0)
		{
			if (methodDef_0.HasBody && methodDef_0.Body.HasInstructions)
			{
				DnlibUtils.Simplify(methodDef_0);
				IntsToMath intsToMath_ = new IntsToMath(methodDef_0);
				IList<Instruction> instructions = methodDef_0.Body.Instructions;
				P8a(methodDef_0, instructions, intsToMath_);
				DnlibUtils.Optimize(methodDef_0);
			}
		}

		private static void P8a(object object_0, IList<Instruction> ilist_0, IntsToMath intsToMath_0)
		{
			for (int i = 0; i < ilist_0.Count; i++)
			{
				if (ilist_0[i].IsLdcI4() && DnlibUtils.CanObfuscate(ilist_0, i) && ilist_0[i].GetLdcI4Value() < int.MaxValue)
				{
					intsToMath_0.Execute(ref i);
				}
			}
		}

		public override void Execute(XContext xcontext_0)
		{
			ModuleDefMD module = xcontext_0.Module;
			string zRL = "Costura";
			foreach (TypeDef item in from typeDef_0 in module.GetTypes()
				where !typeDef_0.IsGlobalModuleType && typeDef_0.Namespace != zRL
				select typeDef_0)
			{
				m80(item);
			}
		}

		private void m80(TypeDef typeDef_0)
		{
			foreach (MethodDef item in typeDef_0.Methods.Where((MethodDef methodDef_0) => methodDef_0.HasBody && methodDef_0.Body.HasInstructions))
			{
				if (!item.MethodHasL2FAttribute())
				{
					a8Q(item);
				}
			}
		}

		private void a8Q(MethodDef methodDef_0)
		{
			DnlibUtils.Simplify(methodDef_0);
			IntsToMath intsToMath = new IntsToMath(methodDef_0);
			IList<Instruction> instructions = methodDef_0.Body.Instructions;
			for (int i = 0; i < instructions.Count; i++)
			{
				if (instructions[i].IsLdcI4() && DnlibUtils.CanObfuscate(instructions, i) && instructions[i].GetLdcI4Value() < int.MaxValue)
				{
					intsToMath.Execute(ref i);
				}
			}
			DnlibUtils.Optimize(methodDef_0);
		}
	}
}
