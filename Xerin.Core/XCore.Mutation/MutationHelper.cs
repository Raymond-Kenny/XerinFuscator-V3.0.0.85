using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XCore.Mutation
{
	public static class MutationHelper
	{
		private static readonly Dictionary<string, int> jU2;

		public static void InjectKey(MethodDef methodDef_0, int int_0, int int_1)
		{
			foreach (Instruction instruction in methodDef_0.Body.Instructions)
			{
				if (instruction.OpCode == OpCodes.Ldsfld)
				{
					IField field = (IField)instruction.Operand;
					int value;
					if (field.DeclaringType.FullName == "Mutation" && jU2.TryGetValue(field.Name, out value) && value == int_0)
					{
						instruction.OpCode = OpCodes.Ldc_I4;
						instruction.Operand = int_1;
					}
				}
			}
		}

		public static void InjectKeys(MethodDef methodDef_0, int[] int_0, int[] int_1)
		{
			foreach (Instruction instruction in methodDef_0.Body.Instructions)
			{
				if (instruction.OpCode == OpCodes.Ldsfld)
				{
					IField field = (IField)instruction.Operand;
					int value;
					if (field.DeclaringType.FullName == "Mutation" && jU2.TryGetValue(field.Name, out value) && (value = Array.IndexOf(int_0, value)) != -1)
					{
						instruction.OpCode = OpCodes.Ldc_I4;
						instruction.Operand = int_1[value];
					}
				}
			}
		}

		public static void ReplacePlaceholder(MethodDef methodDef_0, Func<Instruction[], Instruction[]> func_0)
		{
			for (int i = 0; i < methodDef_0.Body.Instructions.Count; i++)
			{
				Instruction instruction = methodDef_0.Body.Instructions[i];
				if (instruction.OpCode != OpCodes.Call)
				{
					continue;
				}
				IMethod method = (IMethod)instruction.Operand;
				if (!(method.DeclaringType.FullName == "Mutation") || !(method.Name == "Placeholder"))
				{
					continue;
				}
				List<Instruction> list = new List<Instruction>();
				Queue<Instruction> queue = new Queue<Instruction>();
				queue.Enqueue(instruction);
				HashSet<Instruction> hashSet = new HashSet<Instruction>();
				while (true)
				{
					if (queue.Count > 0)
					{
						Instruction item = queue.Dequeue();
						if (hashSet.Contains(item))
						{
							continue;
						}
						hashSet.Add(item);
						int num = methodDef_0.Body.Instructions.IndexOf(item);
						if (num < 0)
						{
							break;
						}
						if (num > 0)
						{
							Instruction instruction2 = methodDef_0.Body.Instructions[num - 1];
							if (instruction2.OpCode == OpCodes.Ldarg || instruction2.OpCode == OpCodes.Ldloc)
							{
								list.Add(instruction2);
							}
						}
						for (int num2 = num - 1; num2 >= 0; num2--)
						{
							Instruction instruction3 = methodDef_0.Body.Instructions[num2];
							if (instruction3.OpCode != OpCodes.Ldarg && instruction3.OpCode != OpCodes.Ldloc)
							{
								break;
							}
							queue.Enqueue(instruction3);
						}
						continue;
					}
					int num3 = list.Select(methodDef_0.Body.Instructions.IndexOf).Min();
					Instruction[] array = methodDef_0.Body.Instructions.Skip(num3).Take(i - num3).ToArray();
					for (int j = 0; j < array.Length; j++)
					{
						methodDef_0.Body.Instructions.RemoveAt(num3);
					}
					methodDef_0.Body.Instructions.RemoveAt(num3);
					array = func_0(array);
					for (int num4 = array.Length - 1; num4 >= 0; num4--)
					{
						methodDef_0.Body.Instructions.Insert(num3, array[num4]);
					}
					return;
				}
				throw new ArgumentException("Failed to find instruction index.");
			}
		}

		static MutationHelper()
		{
			jU2 = new Dictionary<string, int>
			{
				{ "KeyI0", 0 },
				{ "KeyI1", 1 },
				{ "KeyI2", 2 },
				{ "KeyI3", 3 },
				{ "KeyI4", 4 },
				{ "KeyI5", 5 },
				{ "KeyI6", 6 },
				{ "KeyI7", 7 },
				{ "KeyI8", 8 },
				{ "KeyI9", 9 },
				{ "KeyI10", 10 },
				{ "KeyI11", 11 },
				{ "KeyI12", 12 },
				{ "KeyI13", 13 },
				{ "KeyI14", 14 },
				{ "KeyI15", 15 }
			};
		}
	}
}
