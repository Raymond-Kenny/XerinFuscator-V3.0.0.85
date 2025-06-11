using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Junk;

namespace XCore.Shuffler
{
	public static class Shuffler
	{
		private static readonly Random qUM;

		private static readonly OpCode[] sUL;

		public static void confuse(MethodDef methodDef_0, ref int int_0)
		{
			int num = qUM.Next(0, sUL.Length);
			methodDef_0.Body.Instructions.Insert(++int_0, Instruction.CreateLdcI4(0));
			methodDef_0.Body.Instructions.Insert(++int_0, Instruction.Create(sUL[num]));
		}

		public static void cflowShuffle(MethodDef methodDef_0, ref int int_0)
		{
			int num = qUM.Next(0, sUL.Length);
			for (int i = 0; i < 10; i++)
			{
				int value = qUM.Next();
				methodDef_0.Body.Instructions.Insert(++int_0, Instruction.CreateLdcI4(value));
				methodDef_0.Body.Instructions.Insert(++int_0, Instruction.CreateLdcI4(value));
				methodDef_0.Body.Instructions.Insert(++int_0, Instruction.Create(OpCodes.Sub));
			}
			methodDef_0.Body.Instructions.Insert(++int_0, Instruction.Create(sUL[num]));
			methodDef_0.Body.Instructions.Insert(++int_0, Instruction.Create(OpCodes.Call, JunkFlow.JunkMethod));
		}

		public static void safeShuffle(List<Instruction> list_0)
		{
			int num = qUM.Next(0, sUL.Length);
			list_0.Add(Instruction.CreateLdcI4(0));
			list_0.Add(Instruction.Create(sUL[num]));
		}

		public static void cflowShuffle(List<Instruction> list_0)
		{
			int num = qUM.Next(0, sUL.Length);
			for (int i = 0; i < 10; i++)
			{
				int value = qUM.Next();
				list_0.Add(Instruction.CreateLdcI4(value));
				list_0.Add(Instruction.CreateLdcI4(value));
				list_0.Add(Instruction.Create(OpCodes.Sub));
			}
			list_0.Add(Instruction.Create(sUL[num]));
			list_0.Add(Instruction.Create(OpCodes.Call, JunkFlow.JunkMethod));
		}

		static Shuffler()
		{
			qUM = new Random();
			sUL = new OpCode[5]
			{
				OpCodes.Sub_Ovf_Un,
				OpCodes.Add_Ovf_Un,
				OpCodes.Xor,
				OpCodes.Shr_Un,
				OpCodes.Shl
			};
		}
	}
}
