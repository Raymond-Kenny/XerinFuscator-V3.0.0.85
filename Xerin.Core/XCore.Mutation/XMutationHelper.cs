using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XCore.Mutation
{
	public class XMutationHelper : IDisposable
	{
		private string yUB;

		public string MutationType
		{
			get
			{
				return yUB;
			}
			set
			{
				yUB = value;
			}
		}

		public XMutationHelper(string string_0)
		{
			yUB = string_0;
		}

		private static void LUs(Instruction instruction_0, Type type_0, object object_0)
		{
			instruction_0.OpCode = TUE(type_0);
			instruction_0.Operand = gUg(type_0, object_0);
		}

		private static OpCode TUE(Type type_0)
		{
			switch (Type.GetTypeCode(type_0))
			{
			case TypeCode.Boolean:
				return OpCodes.Ldc_I4;
			case TypeCode.SByte:
				return OpCodes.Ldc_I4_S;
			case TypeCode.Byte:
				return OpCodes.Ldc_I4;
			case TypeCode.Int32:
				return OpCodes.Ldc_I4;
			case TypeCode.UInt32:
				return OpCodes.Ldc_I4;
			case TypeCode.Int64:
				return OpCodes.Ldc_I8;
			case TypeCode.UInt64:
				return OpCodes.Ldc_I8;
			case TypeCode.Single:
				return OpCodes.Ldc_R4;
			case TypeCode.Double:
				return OpCodes.Ldc_R8;
			default:
				throw new SystemException("Unreachable code reached.");
			case TypeCode.String:
				return OpCodes.Ldstr;
			}
		}

		private static object gUg(Type type_0, object object_0)
		{
			if (type_0 == typeof(bool))
			{
				return ((bool)object_0) ? 1 : 0;
			}
			return object_0;
		}

		public void InjectKey<T>(MethodDef methodDef_0, int int_0, T UUp)
		{
			if (string.IsNullOrWhiteSpace(yUB))
			{
				throw new ArgumentException();
			}
			IList<Instruction> instructions = methodDef_0.Body.Instructions;
			for (int i = 0; i < instructions.Count; i++)
			{
				if (instructions[i].OpCode != OpCodes.Call)
				{
					continue;
				}
				IMethod method = instructions[i].Operand as IMethod;
				if (method == null || !(method.DeclaringType.FullName == yUB) || !(method.Name == "Key"))
				{
					continue;
				}
				int ldcI4Value = methodDef_0.Body.Instructions[i - 1].GetLdcI4Value();
				if (ldcI4Value != int_0)
				{
					continue;
				}
				if (typeof(T) == typeof(string[]))
				{
					methodDef_0.Body.Instructions.RemoveAt(i);
					string[] array = UUp as string[];
					if (array == null)
					{
						throw new ArgumentException("Key is not of type string[].");
					}
					instructions[i - 1].OpCode = OpCodes.Ldc_I4;
					instructions[i - 1].Operand = array.Length;
					instructions.Insert(i, new Instruction(OpCodes.Newarr, methodDef_0.Module.Import(typeof(string))));
					for (int j = 0; j < array.Length; j++)
					{
						instructions.Insert(i + 1 + j * 4, new Instruction(OpCodes.Dup));
						instructions.Insert(i + 2 + j * 4, new Instruction(OpCodes.Ldc_I4, j));
						instructions.Insert(i + 3 + j * 4, new Instruction(OpCodes.Ldstr, array[j]));
						instructions.Insert(i + 4 + j * 4, new Instruction(OpCodes.Stelem_Ref));
					}
				}
				else
				{
					if (!typeof(T).IsAssignableFrom(Type.GetType(method.FullName.Split(' ')[0])))
					{
						throw new ArgumentException("The specified type does not match the type to be injected.");
					}
					methodDef_0.Body.Instructions.RemoveAt(i);
					LUs(instructions[i - 1], typeof(T), UUp);
				}
			}
		}

		public void InjectKeys<T>(MethodDef methodDef_0, int[] int_0, T[] gparam_0)
		{
			if (string.IsNullOrWhiteSpace(yUB))
			{
				throw new ArgumentException();
			}
			IList<Instruction> instructions = methodDef_0.Body.Instructions;
			int num = 0;
			while (true)
			{
				if (num >= instructions.Count)
				{
					return;
				}
				if (instructions[num].OpCode == OpCodes.Call)
				{
					IMethod method = instructions[num].Operand as IMethod;
					if (method != null && method.DeclaringType.FullName == yUB && method.Name == "Key")
					{
						int ldcI4Value = methodDef_0.Body.Instructions[num - 1].GetLdcI4Value();
						if (ldcI4Value == 0 || Array.IndexOf(int_0, ldcI4Value) != -1)
						{
							if (!typeof(T).IsAssignableFrom(Type.GetType(method.FullName.Split(' ')[0])))
							{
								break;
							}
							methodDef_0.Body.Instructions.RemoveAt(num);
							LUs(instructions[num - 1], typeof(T), gparam_0[ldcI4Value]);
						}
					}
				}
				num++;
			}
			throw new ArgumentException("The specified type does not match the type to be injected.");
		}

		public bool GetInstrLocationIndex(MethodDef methodDef_0, bool bool_0, out int int_0)
		{
			if (!string.IsNullOrWhiteSpace(yUB))
			{
				int num = 0;
				while (true)
				{
					if (num < methodDef_0.Body.Instructions.Count)
					{
						Instruction instruction = methodDef_0.Body.Instructions[num];
						if (instruction.OpCode == OpCodes.Call)
						{
							IMethod method = instruction.Operand as IMethod;
							if (method.DeclaringType.FullName == yUB && method.Name == "LocationIndex")
							{
								break;
							}
						}
						num++;
						continue;
					}
					int_0 = -1;
					return false;
				}
				int_0 = num;
				if (bool_0)
				{
					methodDef_0.Body.Instructions.RemoveAt(num);
				}
				return true;
			}
			throw new ArgumentException();
		}

		public void Dispose()
		{
			yUB = null;
			GC.SuppressFinalize(this);
		}
	}
}
