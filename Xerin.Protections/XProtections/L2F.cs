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
	public class L2F : Protection
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class Vwe
		{
			public static readonly Vwe Hwz;

			public static Func<Instruction, bool> nRc;

			public static Func<Instruction, bool> qR2;

			static Vwe()
			{
				Hwz = new Vwe();
			}

			internal bool TwC(Instruction instruction_0)
			{
				return instruction_0.IsLdcI4();
			}

			internal bool xwJ(Instruction instruction_0)
			{
				return instruction_0.OpCode != OpCodes.Nop;
			}
		}

		public override string name => "Local to field";

		public override int number => 4;

		public override void Execute(XContext xcontext_0)
		{
			ModuleDefMD module = xcontext_0.Module;
			MethodDef methodDef = module.GlobalType.FindOrCreateStaticConstructor();
			MethodDefUser methodDefUser = Utils.CreateMethod(xcontext_0.Module);
			Dictionary<int, FieldDef> dictionary = new Dictionary<int, FieldDef>();
			foreach (TypeDef type in module.GetTypes())
			{
				if (type.IsGlobalModuleType)
				{
					continue;
				}
				foreach (MethodDef method in type.Methods)
				{
					if (!method.HasBody || !method.Body.HasInstructions || method.MethodHasL2FAttribute())
					{
						continue;
					}
					IList<Instruction> instructions = method.Body.Instructions;
					List<Instruction> list = instructions.Where((Instruction instruction_0) => instruction_0.IsLdcI4()).ToList();
					foreach (Instruction item in list)
					{
						int ldcI4Value = item.GetLdcI4Value();
						if (!dictionary.TryGetValue(ldcI4Value, out var value))
						{
							value = Utils.CreateField(new FieldSig(module.CorLibTypes.Int32));
							module.GlobalType.Fields.Add(value);
							dictionary[ldcI4Value] = value;
							if (methodDefUser.Body.Instructions.Count != 0)
							{
								Instruction instruction = methodDefUser.Body.Instructions.FirstOrDefault((Instruction instruction_0) => instruction_0.OpCode != OpCodes.Nop);
								if (instruction == null)
								{
									methodDefUser.Body.Instructions.Insert(0, OpCodes.Stsfld.ToInstruction(value));
									methodDefUser.Body.Instructions.Insert(0, OpCodes.Ldc_I4.ToInstruction(ldcI4Value));
								}
								else
								{
									int index = methodDefUser.Body.Instructions.IndexOf(instruction);
									methodDefUser.Body.Instructions.Insert(index, OpCodes.Stsfld.ToInstruction(value));
									methodDefUser.Body.Instructions.Insert(index, OpCodes.Ldc_I4.ToInstruction(ldcI4Value));
								}
							}
							else
							{
								methodDefUser.Body.Instructions.Insert(0, OpCodes.Stsfld.ToInstruction(value));
								methodDefUser.Body.Instructions.Insert(0, OpCodes.Ldc_I4.ToInstruction(ldcI4Value));
							}
						}
						item.OpCode = OpCodes.Ldsfld;
						item.Operand = value;
					}
				}
			}
			methodDef.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(methodDefUser));
		}
	}
}
