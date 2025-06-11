using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XF
{
	internal static class XjJ
	{
		[CompilerGenerated]
		private sealed class lZE
		{
			public byte[] JZ2;

			internal Instruction[] eZN(Instruction[] instruction_0)
			{
				List<Instruction> list = new List<Instruction>();
				list.AddRange(instruction_0);
				for (int i = 0; i < JZ2.Length; i++)
				{
					list.Add(Instruction.Create(OpCodes.Dup));
					list.Add(Instruction.Create(OpCodes.Ldc_I4, i));
					list.Add(Instruction.Create(OpCodes.Ldc_I4, (int)JZ2[i]));
					list.Add(Instruction.Create(OpCodes.Stelem_Ref));
				}
				return list.ToArray();
			}
		}

		internal static Dictionary<string, int> BO0;

		internal static Dictionary<string, int> HOw;

		internal static Dictionary<string, int> vOW;

		internal static Dictionary<string, string> yOE;

		internal static readonly Dictionary<string, int> oON;

		internal static readonly Dictionary<string, int> WO2;

		internal static Dictionary<string, int> fOK;

		internal static readonly Dictionary<string, string> EO1;

		internal static void sj8(MethodDef methodDef_0, int int_0, int int_1)
		{
			foreach (Instruction instruction in methodDef_0.Body.Instructions)
			{
				if (instruction.OpCode == OpCodes.Ldsfld)
				{
					IField field = instruction.Operand as IField;
					if (field.DeclaringType.FullName == TNd.Q29 && BO0.TryGetValue(field.Name, out var value) && value == int_0)
					{
						instruction.OpCode = OpCodes.Ldc_I4;
						instruction.Operand = int_1;
					}
				}
			}
		}

		internal static void sjz(MethodDef methodDef_0, int int_0, long long_0)
		{
			foreach (Instruction instruction in methodDef_0.Body.Instructions)
			{
				if (instruction.OpCode == OpCodes.Ldsfld)
				{
					IField field = instruction.Operand as IField;
					if (field.DeclaringType.FullName == TNd.Q29 && HOw.TryGetValue(field.Name, out var value) && value == int_0)
					{
						instruction.OpCode = OpCodes.Ldc_I8;
						instruction.Operand = long_0;
					}
				}
			}
		}

		internal static void QO4(MethodDef methodDef_0, int int_0, ulong ulong_0)
		{
			foreach (Instruction instruction in methodDef_0.Body.Instructions)
			{
				if (instruction.OpCode == OpCodes.Ldsfld)
				{
					IField field = instruction.Operand as IField;
					if (field.DeclaringType.FullName == TNd.Q29 && vOW.TryGetValue(field.Name, out var value) && value == int_0)
					{
						instruction.OpCode = OpCodes.Ldc_I8;
						instruction.Operand = (long)ulong_0;
					}
				}
			}
		}

		internal static void bOe(MethodDef methodDef_0, int int_0, object object_0)
		{
			foreach (Instruction instruction in methodDef_0.Body.Instructions)
			{
				if (instruction.OpCode == OpCodes.Ldsfld)
				{
					IField field = instruction.Operand as IField;
					if (field.DeclaringType.FullName == TNd.Q29 && yOE.TryGetValue(field.Name, out var value) && value == int_0.ToString())
					{
						instruction.OpCode = OpCodes.Ldstr;
						instruction.Operand = object_0;
					}
				}
			}
		}

		internal static void jOu(MethodDef methodDef_0, object object_0, object object_1)
		{
			foreach (Instruction instruction in methodDef_0.Body.Instructions)
			{
				if (instruction.OpCode == OpCodes.Ldsfld)
				{
					IField field = instruction.Operand as IField;
					if (field.DeclaringType.FullName == TNd.Q29 && BO0.TryGetValue(field.Name, out var value) && (value = Array.IndexOf((int[])object_0, value)) != -1)
					{
						instruction.OpCode = OpCodes.Ldc_I4;
						instruction.Operand = ((int[])object_1)[value];
					}
				}
			}
		}

		internal static void VO9(MethodDef methodDef_0, object object_0, object object_1)
		{
			foreach (Instruction instruction in methodDef_0.Body.Instructions)
			{
				if (instruction.OpCode == OpCodes.Ldsfld)
				{
					IField field = instruction.Operand as IField;
					if (field.DeclaringType.FullName == TNd.Q29 && HOw.TryGetValue(field.Name, out var value) && (value = Array.IndexOf((int[])object_0, value)) != -1)
					{
						instruction.OpCode = OpCodes.Ldc_I8;
						instruction.Operand = ((long[])object_1)[value];
					}
				}
			}
		}

		internal static void bOG(MethodDef methodDef_0, object object_0, object object_1)
		{
			foreach (Instruction instruction in methodDef_0.Body.Instructions)
			{
				if (instruction.OpCode == OpCodes.Ldsfld)
				{
					IField field = instruction.Operand as IField;
					if (field.DeclaringType.FullName == TNd.Q29 && vOW.TryGetValue(field.Name, out var value) && (value = Array.IndexOf((int[])object_0, value)) != -1)
					{
						instruction.OpCode = OpCodes.Ldc_I8;
						instruction.Operand = ((long[])object_1)[value];
					}
				}
			}
		}

		internal static void NOI(MethodDef methodDef_0, object object_0, object object_1)
		{
			foreach (Instruction instruction in methodDef_0.Body.Instructions)
			{
				if (instruction.OpCode == OpCodes.Ldsfld)
				{
					IField field = instruction.Operand as IField;
					if (field.DeclaringType.FullName == TNd.Q29 && yOE.TryGetValue(field.Name, out var value) && Convert.ToInt32(value = Array.IndexOf((int[])object_0, int.Parse(value)).ToString()) != -1)
					{
						instruction.OpCode = OpCodes.Ldstr;
						instruction.Operand = ((object[])object_1)[int.Parse(value)];
					}
				}
			}
		}

		internal static void YOq(MethodDef methodDef_0, object object_0)
		{
			for (int i = 0; i < methodDef_0.Body.Instructions.Count; i++)
			{
				Instruction instruction = methodDef_0.Body.Instructions[i];
				IMethod method = instruction.Operand as IMethod;
				if (instruction.OpCode == OpCodes.Call && method.DeclaringType.Name == TNd.Q29 && method.Name == TNd.O2q)
				{
					methodDef_0.Body.Instructions[i] = (Instruction)object_0;
				}
			}
		}

		internal static void wOM(MethodDef methodDef_0, bool bool_0, out int int_0)
		{
			int num = -1;
			for (int i = 0; i < methodDef_0.Body.Instructions.Count; i++)
			{
				Instruction instruction = methodDef_0.Body.Instructions[i];
				IMethod method = instruction.Operand as IMethod;
				if (instruction.OpCode == OpCodes.Call && method.DeclaringType.Name == TNd.Q29 && method.Name == TNd.w2I)
				{
					num = i;
					if (bool_0)
					{
						methodDef_0.Body.Instructions.RemoveAt(i);
					}
				}
			}
			int_0 = num;
		}

		internal static void tOA(MethodDef methodDef_0, byte[] byte_0)
		{
			OOR(methodDef_0, delegate(Instruction[] instruction_0)
			{
				List<Instruction> list = new List<Instruction>();
				list.AddRange(instruction_0);
				for (int i = 0; i < byte_0.Length; i++)
				{
					list.Add(Instruction.Create(OpCodes.Dup));
					list.Add(Instruction.Create(OpCodes.Ldc_I4, i));
					list.Add(Instruction.Create(OpCodes.Ldc_I4, (int)byte_0[i]));
					list.Add(Instruction.Create(OpCodes.Stelem_Ref));
				}
				return list.ToArray();
			});
		}

		internal static void OOR(MethodDef methodDef_0, Func<Instruction[], Instruction[]> func_0)
		{
			EAP eAP = new EAP(methodDef_0).GAd();
			int num = 0;
			Instruction instruction;
			while (true)
			{
				if (num >= methodDef_0.Body.Instructions.Count)
				{
					return;
				}
				instruction = methodDef_0.Body.Instructions[num];
				if (instruction.OpCode == OpCodes.Call)
				{
					IMethod method = (IMethod)instruction.Operand;
					if (method.DeclaringType.FullName == TNd.Q29 && method.Name == TNd.Y2G)
					{
						break;
					}
				}
				num++;
			}
			int[] array = eAP.PAB(instruction);
			if (array == null)
			{
				throw new ArgumentException("Failed to trace placeholder argument.");
			}
			int num2 = array[0];
			Instruction[] array2 = methodDef_0.Body.Instructions.Skip(num2).Take(num - num2).ToArray();
			for (int i = 0; i < array2.Length; i++)
			{
				methodDef_0.Body.Instructions.RemoveAt(num2);
			}
			methodDef_0.Body.Instructions.RemoveAt(num2);
			array2 = func_0(array2);
			for (int num3 = array2.Length - 1; num3 >= 0; num3--)
			{
				methodDef_0.Body.Instructions.Insert(num2, array2[num3]);
			}
		}

		static XjJ()
		{
			BO0 = new Dictionary<string, int>
			{
				{ "IntKey0", 0 },
				{ "IntKey1", 1 },
				{ "IntKey2", 2 },
				{ "IntKey3", 3 },
				{ "IntKey4", 4 },
				{ "IntKey5", 5 },
				{ "IntKey6", 6 },
				{ "IntKey7", 7 },
				{ "IntKey8", 8 },
				{ "IntKey9", 9 },
				{ "IntKey10", 10 },
				{ "IntKey11", 11 },
				{ "IntKey12", 12 },
				{ "IntKey13", 13 },
				{ "IntKey14", 14 },
				{ "IntKey15", 15 },
				{ "IntKey16", 16 },
				{ "IntKey17", 17 },
				{ "IntKey18", 18 },
				{ "IntKey19", 19 },
				{ "IntKey20", 20 }
			};
			HOw = new Dictionary<string, int>
			{
				{ "LongKey0", 0 },
				{ "LongKey1", 1 },
				{ "LongKey2", 2 },
				{ "LongKey3", 3 },
				{ "LongKey4", 4 },
				{ "LongKey5", 5 },
				{ "LongKey6", 6 },
				{ "LongKey7", 7 },
				{ "LongKey8", 8 },
				{ "LongKey9", 9 },
				{ "LongKey10", 10 },
				{ "LongKey11", 11 },
				{ "LongKey12", 12 },
				{ "LongKey13", 13 },
				{ "LongKey14", 14 },
				{ "LongKey15", 15 },
				{ "LongKey16", 16 },
				{ "LongKey17", 17 },
				{ "LongKey18", 18 },
				{ "LongKey19", 19 },
				{ "LongKey20", 20 }
			};
			vOW = new Dictionary<string, int>
			{
				{ "ULongKey0", 0 },
				{ "ULongKey1", 1 },
				{ "ULongKey2", 2 },
				{ "ULongKey3", 3 },
				{ "ULongKey4", 4 },
				{ "ULongKey5", 5 },
				{ "ULongKey6", 6 },
				{ "ULongKey7", 7 },
				{ "ULongKey8", 8 },
				{ "ULongKey9", 9 },
				{ "ULongKey10", 10 },
				{ "ULongKey11", 11 },
				{ "ULongKey12", 12 },
				{ "ULongKey13", 13 },
				{ "ULongKey14", 14 },
				{ "ULongKey15", 15 },
				{ "ULongKey16", 16 },
				{ "ULongKey17", 17 },
				{ "ULongKey18", 18 },
				{ "ULongKey19", 19 },
				{ "ULongKey20", 20 }
			};
			yOE = new Dictionary<string, string>
			{
				{
					"LdstrKey0",
					Convert.ToString(0)
				},
				{
					"LdstrKey1",
					Convert.ToString(1)
				},
				{
					"LdstrKey2",
					Convert.ToString(2)
				},
				{
					"LdstrKey3",
					Convert.ToString(3)
				},
				{
					"LdstrKey4",
					Convert.ToString(4)
				},
				{
					"LdstrKey5",
					Convert.ToString(5)
				},
				{
					"LdstrKey6",
					Convert.ToString(6)
				},
				{
					"LdstrKey7",
					Convert.ToString(7)
				},
				{
					"LdstrKey8",
					Convert.ToString(8)
				},
				{
					"LdstrKey9",
					Convert.ToString(9)
				},
				{
					"LdstrKey10",
					Convert.ToString(10)
				},
				{
					"LdstrKey11",
					Convert.ToString(11)
				},
				{
					"LdstrKey12",
					Convert.ToString(12)
				},
				{
					"LdstrKey13",
					Convert.ToString(13)
				},
				{
					"LdstrKey14",
					Convert.ToString(14)
				},
				{
					"LdstrKey15",
					Convert.ToString(15)
				},
				{
					"LdstrKey16",
					Convert.ToString(16)
				},
				{
					"LdstrKey17",
					Convert.ToString(17)
				},
				{
					"LdstrKey18",
					Convert.ToString(18)
				},
				{
					"LdstrKey19",
					Convert.ToString(19)
				},
				{
					"LdstrKey20",
					Convert.ToString(20)
				}
			};
			oON = new Dictionary<string, int>
			{
				{ "IntKey0", 0 },
				{ "IntKey1", 1 },
				{ "IntKey2", 2 },
				{ "IntKey3", 3 },
				{ "IntKey4", 4 },
				{ "IntKey5", 5 },
				{ "IntKey6", 6 },
				{ "IntKey7", 7 },
				{ "IntKey8", 8 },
				{ "IntKey9", 9 },
				{ "IntKey10", 10 },
				{ "IntKey11", 11 },
				{ "IntKey12", 12 },
				{ "IntKey13", 13 },
				{ "IntKey14", 14 },
				{ "IntKey15", 15 },
				{ "IntKey16", 16 },
				{ "IntKey17", 17 },
				{ "IntKey18", 18 },
				{ "IntKey19", 19 },
				{ "IntKey20", 20 }
			};
			WO2 = new Dictionary<string, int>
			{
				{ "LongKey0", 0 },
				{ "LongKey1", 1 },
				{ "LongKey2", 2 },
				{ "LongKey3", 3 },
				{ "LongKey4", 4 },
				{ "LongKey5", 5 },
				{ "LongKey6", 6 },
				{ "LongKey7", 7 },
				{ "LongKey8", 8 },
				{ "LongKey9", 9 },
				{ "LongKey10", 10 },
				{ "LongKey11", 11 },
				{ "LongKey12", 12 },
				{ "LongKey13", 13 },
				{ "LongKey14", 14 },
				{ "LongKey15", 15 },
				{ "LongKey16", 16 },
				{ "LongKey17", 17 },
				{ "LongKey18", 18 },
				{ "LongKey19", 19 },
				{ "LongKey20", 20 }
			};
			fOK = new Dictionary<string, int>
			{
				{ "ULongKey0", 0 },
				{ "ULongKey1", 1 },
				{ "ULongKey2", 2 },
				{ "ULongKey3", 3 },
				{ "ULongKey4", 4 },
				{ "ULongKey5", 5 },
				{ "ULongKey6", 6 },
				{ "ULongKey7", 7 },
				{ "ULongKey8", 8 },
				{ "ULongKey9", 9 },
				{ "ULongKey10", 10 },
				{ "ULongKey11", 11 },
				{ "ULongKey12", 12 },
				{ "ULongKey13", 13 },
				{ "ULongKey14", 14 },
				{ "ULongKey15", 15 },
				{ "ULongKey16", 16 },
				{ "ULongKey17", 17 },
				{ "ULongKey18", 18 },
				{ "ULongKey19", 19 },
				{ "ULongKey20", 20 }
			};
			EO1 = new Dictionary<string, string>
			{
				{
					"LdstrKey0",
					Convert.ToString(0)
				},
				{
					"LdstrKey1",
					Convert.ToString(1)
				},
				{
					"LdstrKey2",
					Convert.ToString(2)
				},
				{
					"LdstrKey3",
					Convert.ToString(3)
				},
				{
					"LdstrKey4",
					Convert.ToString(4)
				},
				{
					"LdstrKey5",
					Convert.ToString(5)
				},
				{
					"LdstrKey6",
					Convert.ToString(6)
				},
				{
					"LdstrKey7",
					Convert.ToString(7)
				},
				{
					"LdstrKey8",
					Convert.ToString(8)
				},
				{
					"LdstrKey9",
					Convert.ToString(9)
				},
				{
					"LdstrKey10",
					Convert.ToString(10)
				},
				{
					"LdstrKey11",
					Convert.ToString(11)
				},
				{
					"LdstrKey12",
					Convert.ToString(12)
				},
				{
					"LdstrKey13",
					Convert.ToString(13)
				},
				{
					"LdstrKey14",
					Convert.ToString(14)
				},
				{
					"LdstrKey15",
					Convert.ToString(15)
				},
				{
					"LdstrKey16",
					Convert.ToString(16)
				},
				{
					"LdstrKey17",
					Convert.ToString(17)
				},
				{
					"LdstrKey18",
					Convert.ToString(18)
				},
				{
					"LdstrKey19",
					Convert.ToString(19)
				},
				{
					"LdstrKey20",
					Convert.ToString(20)
				}
			};
		}
	}
}
