using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XCore.Simplifier
{
	public static class Simplifying
	{
		private static JU5 GU3<JU5>(IList<JU5> ilist_0, int int_0)
		{
			if (ilist_0 == null)
			{
				return default(JU5);
			}
			if ((uint)int_0 < (uint)ilist_0.Count)
			{
				return ilist_0[int_0];
			}
			return default(JU5);
		}

		private static void tUH(this IList<Instruction> ilist_0, IList<Local> ilist_1, IList<Parameter> ilist_2)
		{
			int count = ilist_0.Count;
			for (int i = 0; i < count; i++)
			{
				Instruction instruction = ilist_0[i];
				switch (instruction.OpCode.Code)
				{
				case Code.Leave_S:
					instruction.OpCode = OpCodes.Leave;
					break;
				case Code.Ldarg_0:
					instruction.OpCode = OpCodes.Ldarg;
					instruction.Operand = GU3(ilist_2, 0);
					break;
				case Code.Ldarg_1:
					instruction.OpCode = OpCodes.Ldarg;
					instruction.Operand = GU3(ilist_2, 1);
					break;
				case Code.Ldarg_2:
					instruction.OpCode = OpCodes.Ldarg;
					instruction.Operand = GU3(ilist_2, 2);
					break;
				case Code.Ldarg_3:
					instruction.OpCode = OpCodes.Ldarg;
					instruction.Operand = GU3(ilist_2, 3);
					break;
				case Code.Ldloc_0:
					instruction.OpCode = OpCodes.Ldloc;
					instruction.Operand = GU3(ilist_1, 0);
					break;
				case Code.Ldloc_1:
					instruction.OpCode = OpCodes.Ldloc;
					instruction.Operand = GU3(ilist_1, 1);
					break;
				case Code.Ldloc_2:
					instruction.OpCode = OpCodes.Ldloc;
					instruction.Operand = GU3(ilist_1, 2);
					break;
				case Code.Ldloc_3:
					instruction.OpCode = OpCodes.Ldloc;
					instruction.Operand = GU3(ilist_1, 3);
					break;
				case Code.Stloc_0:
					instruction.OpCode = OpCodes.Stloc;
					instruction.Operand = GU3(ilist_1, 0);
					break;
				case Code.Stloc_1:
					instruction.OpCode = OpCodes.Stloc;
					instruction.Operand = GU3(ilist_1, 1);
					break;
				case Code.Stloc_2:
					instruction.OpCode = OpCodes.Stloc;
					instruction.Operand = GU3(ilist_1, 2);
					break;
				case Code.Stloc_3:
					instruction.OpCode = OpCodes.Stloc;
					instruction.Operand = GU3(ilist_1, 3);
					break;
				case Code.Ldarg_S:
					instruction.OpCode = OpCodes.Ldarg;
					break;
				case Code.Ldarga_S:
					instruction.OpCode = OpCodes.Ldarga;
					break;
				case Code.Starg_S:
					instruction.OpCode = OpCodes.Starg;
					break;
				case Code.Ldloc_S:
					instruction.OpCode = OpCodes.Ldloc;
					break;
				case Code.Ldloca_S:
					instruction.OpCode = OpCodes.Ldloca;
					break;
				case Code.Stloc_S:
					instruction.OpCode = OpCodes.Stloc;
					break;
				case Code.Ldc_I4_M1:
					instruction.OpCode = OpCodes.Ldc_I4;
					instruction.Operand = -1;
					break;
				case Code.Ldc_I4_0:
					instruction.OpCode = OpCodes.Ldc_I4;
					instruction.Operand = 0;
					break;
				case Code.Ldc_I4_1:
					instruction.OpCode = OpCodes.Ldc_I4;
					instruction.Operand = 1;
					break;
				case Code.Ldc_I4_2:
					instruction.OpCode = OpCodes.Ldc_I4;
					instruction.Operand = 2;
					break;
				case Code.Ldc_I4_3:
					instruction.OpCode = OpCodes.Ldc_I4;
					instruction.Operand = 3;
					break;
				case Code.Ldc_I4_4:
					instruction.OpCode = OpCodes.Ldc_I4;
					instruction.Operand = 4;
					break;
				case Code.Ldc_I4_5:
					instruction.OpCode = OpCodes.Ldc_I4;
					instruction.Operand = 5;
					break;
				case Code.Ldc_I4_6:
					instruction.OpCode = OpCodes.Ldc_I4;
					instruction.Operand = 6;
					break;
				case Code.Ldc_I4_7:
					instruction.OpCode = OpCodes.Ldc_I4;
					instruction.Operand = 7;
					break;
				case Code.Ldc_I4_8:
					instruction.OpCode = OpCodes.Ldc_I4;
					instruction.Operand = 8;
					break;
				case Code.Ldc_I4_S:
					instruction.OpCode = OpCodes.Ldc_I4;
					instruction.Operand = (int)(sbyte)instruction.Operand;
					break;
				case Code.Br_S:
					instruction.OpCode = OpCodes.Br;
					break;
				case Code.Brfalse_S:
					instruction.OpCode = OpCodes.Brfalse;
					break;
				case Code.Brtrue_S:
					instruction.OpCode = OpCodes.Brtrue;
					break;
				case Code.Beq_S:
					instruction.OpCode = OpCodes.Beq;
					break;
				case Code.Bge_S:
					instruction.OpCode = OpCodes.Bge;
					break;
				case Code.Bgt_S:
					instruction.OpCode = OpCodes.Bgt;
					break;
				case Code.Ble_S:
					instruction.OpCode = OpCodes.Ble;
					break;
				case Code.Blt_S:
					instruction.OpCode = OpCodes.Blt;
					break;
				case Code.Bne_Un_S:
					instruction.OpCode = OpCodes.Bne_Un;
					break;
				case Code.Bge_Un_S:
					instruction.OpCode = OpCodes.Bge_Un;
					break;
				case Code.Bgt_Un_S:
					instruction.OpCode = OpCodes.Bgt_Un;
					break;
				case Code.Ble_Un_S:
					instruction.OpCode = OpCodes.Ble_Un;
					break;
				case Code.Blt_Un_S:
					instruction.OpCode = OpCodes.Blt_Un;
					break;
				}
			}
		}

		public static void Simplefy(ModuleDefMD moduleDefMD_0)
		{
			foreach (TypeDef type in moduleDefMD_0.GetTypes())
			{
				foreach (MethodDef method in type.Methods)
				{
					CilBody body = method.Body;
					if (body != null)
					{
						body.Instructions.tUH(method.Body.Variables, method.Parameters);
					}
					method.Body?.Instructions.SimplifyBranches();
				}
			}
		}
	}
}
