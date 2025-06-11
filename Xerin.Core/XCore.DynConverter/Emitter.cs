using System;
using System.Collections.Generic;
using System.IO;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XCore.DynConverter
{
	public static class Emitter
	{
		public static void EmitNone(this BinaryWriter binaryWriter_0)
		{
			binaryWriter_0.Write(0);
		}

		public static void EmitString(this BinaryWriter binaryWriter_0, Instruction instruction_0)
		{
			binaryWriter_0.Write(1);
			binaryWriter_0.Write(instruction_0.Operand.ToString());
		}

		public static void EmitR(this BinaryWriter binaryWriter_0, Instruction instruction_0)
		{
			binaryWriter_0.Write(2);
			binaryWriter_0.Write((double)instruction_0.Operand);
		}

		public static void EmitI8(this BinaryWriter binaryWriter_0, Instruction instruction_0)
		{
			binaryWriter_0.Write(3);
			binaryWriter_0.Write((long)instruction_0.Operand);
		}

		public static void EmitI(this BinaryWriter binaryWriter_0, Instruction instruction_0)
		{
			binaryWriter_0.Write(4);
			binaryWriter_0.Write(instruction_0.GetLdcI4Value());
		}

		public static void EmitShortR(this BinaryWriter binaryWriter_0, Instruction instruction_0)
		{
			binaryWriter_0.Write(5);
			binaryWriter_0.Write((float)instruction_0.Operand);
		}

		public static void EmitShortI(this BinaryWriter binaryWriter_0, Instruction instruction_0)
		{
			binaryWriter_0.Write(6);
			binaryWriter_0.Write((byte)instruction_0.GetLdcI4Value());
		}

		public static void EmitType(this BinaryWriter binaryWriter_0, Instruction instruction_0)
		{
			binaryWriter_0.Write(7);
			ITypeDefOrRef typeDefOrRef = instruction_0.Operand as ITypeDefOrRef;
			binaryWriter_0.Write(typeDefOrRef.MDToken.ToInt32());
		}

		public static void EmitField(this BinaryWriter binaryWriter_0, Instruction instruction_0)
		{
			binaryWriter_0.Write(8);
			IField field = instruction_0.Operand as IField;
			binaryWriter_0.Write(field.MDToken.ToInt32());
		}

		public static void EmitMethod(this BinaryWriter binaryWriter_0, Instruction instruction_0)
		{
			binaryWriter_0.Write(9);
			MethodSpec methodSpec = instruction_0.Operand as MethodSpec;
			if (methodSpec != null)
			{
				binaryWriter_0.Write(methodSpec.MDToken.ToInt32());
				return;
			}
			IMethodDefOrRef methodDefOrRef = instruction_0.Operand as IMethodDefOrRef;
			binaryWriter_0.Write(methodDefOrRef.MDToken.ToInt32());
		}

		public static void EmitTok(this BinaryWriter binaryWriter_0, Instruction instruction_0)
		{
			binaryWriter_0.Write(10);
			object operand = instruction_0.Operand;
			IField field = operand as IField;
			if (field != null)
			{
				binaryWriter_0.Write(field.MDToken.ToInt32());
				binaryWriter_0.Write(0);
				return;
			}
			ITypeDefOrRef typeDefOrRef = operand as ITypeDefOrRef;
			if (typeDefOrRef != null)
			{
				binaryWriter_0.Write(typeDefOrRef.MDToken.ToInt32());
				binaryWriter_0.Write(1);
			}
			else
			{
				binaryWriter_0.Write((operand as IMethodDefOrRef).MDToken.ToInt32());
				binaryWriter_0.Write(2);
			}
		}

		public static void EmitBr(this BinaryWriter binaryWriter_0, int int_0)
		{
			binaryWriter_0.Write(11);
			binaryWriter_0.Write(int_0);
		}

		public static void EmitVar(this BinaryWriter binaryWriter_0, Instruction instruction_0)
		{
			binaryWriter_0.Write(12);
			Local local = instruction_0.Operand as Local;
			if (local != null)
			{
				binaryWriter_0.Write(local.Index);
				binaryWriter_0.Write(0);
				return;
			}
			Parameter parameter = instruction_0.Operand as Parameter;
			if (parameter != null)
			{
				binaryWriter_0.Write(parameter.Index);
				binaryWriter_0.Write(1);
				return;
			}
			throw new NotSupportedException();
		}

		public static void EmitSwitch(this BinaryWriter binaryWriter_0, List<Instruction> list_0, Instruction instruction_0)
		{
			binaryWriter_0.Write(13);
			Instruction[] array = instruction_0.Operand as Instruction[];
			binaryWriter_0.Write(array.Length);
			Instruction[] array2 = array;
			foreach (Instruction item in array2)
			{
				int value = list_0.IndexOf(item);
				binaryWriter_0.Write(value);
			}
		}
	}
}
