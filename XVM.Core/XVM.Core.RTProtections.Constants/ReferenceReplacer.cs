using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;
using XVM.Core.Helpers.System.Runtime.CompilerServices;

namespace XVM.Core.RTProtections.Constants
{
	public class ReferenceReplacer
	{
		[TupleElementNames(new string[] { "method", "indexInstruction", "ldci4Instruction" })]
		private static List<(MethodDef, Instruction, Instruction)> n1y;

		public static void ReplaceReference(CEContext cecontext_0)
		{
			cecontext_0.Options.WriterEvent += L1B;
			foreach (KeyValuePair<MethodDef, List<ReplaceableInstructionReference>> item in cecontext_0.ReferenceRepl)
			{
				Q1D(item.Key);
				P17(item.Key, item.Value, cecontext_0);
			}
		}

		private static int B1d(IList<Instruction> ilist_0, int int_0)
		{
			int num = 0;
			for (int i = 0; i < int_0; i++)
			{
				Instruction instruction = ilist_0[i];
				num += instruction.OpCode.Size;
				if (instruction.OpCode.OperandType != OperandType.InlineNone)
				{
					switch (instruction.OpCode.OperandType)
					{
					case OperandType.InlineI8:
					case OperandType.InlineR:
						num += 8;
						break;
					case OperandType.InlineSwitch:
						num += 4 + ((Instruction[])instruction.Operand).Length * 4;
						break;
					case OperandType.InlineVar:
						num += 2;
						break;
					case OperandType.InlineBrTarget:
					case OperandType.InlineField:
					case OperandType.InlineI:
					case OperandType.InlineMethod:
					case OperandType.InlineSig:
					case OperandType.InlineString:
					case OperandType.InlineTok:
					case OperandType.InlineType:
					case OperandType.ShortInlineR:
						num += 4;
						break;
					case OperandType.ShortInlineBrTarget:
					case OperandType.ShortInlineI:
					case OperandType.ShortInlineVar:
						num++;
						break;
					}
				}
			}
			return num;
		}

		private static void L1B(object sender, ModuleWriterEventArgs e)
		{
			if (e.Event != ModuleWriterEvent.Begin)
			{
				return;
			}
			foreach (var item in n1y)
			{
				IList<Instruction> instructions = item.Item1.Body.Instructions;
				int num = B1d(instructions, instructions.IndexOf(item.Item3));
				item.Item2.Operand = num + 1;
			}
		}

		private static void P17(object object_0, List<ReplaceableInstructionReference> list_0, object object_1)
		{
			foreach (ReplaceableInstructionReference item in list_0)
			{
				IList<Instruction> instructions = ((MethodDef)object_0).Body.Instructions;
				int num = instructions.IndexOf(item.Target);
				item.Target.OpCode = OpCodes.Ldc_I4;
				item.Target.Operand = (int)item.Id;
				Instruction instruction = Instruction.Create(OpCodes.Ldc_I4, 256);
				instructions.Insert(num + 1, instruction);
				instructions.Insert(num + 2, Instruction.Create(OpCodes.Ldtoken, (IMethod)object_0));
				instructions.Insert(num + 3, Instruction.Create(OpCodes.Call, item.Decoder));
				Instruction instruction2 = Instruction.CreateLdcI4((int)item.Key);
				instructions.Insert(0, instruction2);
				instructions.Insert(1, Instruction.Create(OpCodes.Pop));
				n1y.Add(((MethodDef)object_0, instruction, instruction2));
			}
		}

		private static void Q1D(MethodDef methodDef_0)
		{
			methodDef_0.ImplAttributes &= ~MethodImplAttributes.AggressiveInlining;
			methodDef_0.ImplAttributes |= MethodImplAttributes.NoInlining;
		}

		static ReferenceReplacer()
		{
			n1y = new List<(MethodDef, Instruction, Instruction)>();
		}
	}
}
