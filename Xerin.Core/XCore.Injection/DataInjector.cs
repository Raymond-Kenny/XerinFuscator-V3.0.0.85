using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XCore.Injection
{
	public static class DataInjector
	{
		public static void InjectByteArr(byte[] byte_0, MethodDef methodDef_0, FieldDef fieldDef_0, int int_0 = 0)
		{
			ModuleDef module = methodDef_0.Module;
			IList<Instruction> instructions = methodDef_0.Body.Instructions;
			int num = 2;
			instructions.Insert(int_0, OpCodes.Ldc_I4.ToInstruction(byte_0.Length));
			instructions.Insert(int_0 + 1, OpCodes.Newarr.ToInstruction(module.CorLibTypes.Byte));
			instructions.Insert(int_0 + 2, OpCodes.Dup.ToInstruction());
			for (int i = 0; i < byte_0.Length; i++)
			{
				int value = Convert.ToInt32(byte_0[i]);
				instructions.Insert(int_0 + ++num, OpCodes.Ldc_I4.ToInstruction(i));
				instructions.Insert(int_0 + ++num, OpCodes.Ldc_I4.ToInstruction(value));
				instructions.Insert(int_0 + ++num, OpCodes.Stelem_I1.ToInstruction());
				instructions.Insert(int_0 + ++num, OpCodes.Dup.ToInstruction());
			}
			instructions.Insert(int_0 + ++num, OpCodes.Pop.ToInstruction());
			instructions.Insert(int_0 + num, OpCodes.Stsfld.ToInstruction(fieldDef_0));
		}
	}
}
