using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XF;

namespace XCore.Optimizer
{
	public static class Optimization
	{
		private static void oUT(this IEnumerable<Instruction> ienumerable_0, Dictionary<Instruction, Instruction> dictionary_0)
		{
			if (dictionary_0.Count == 0)
			{
				return;
			}
			foreach (Instruction item in ienumerable_0)
			{
				if (item.Operand is Instruction)
				{
					Instruction key = (Instruction)item.Operand;
					Instruction value;
					if (dictionary_0.TryGetValue(key, out value))
					{
						item.Operand = value;
					}
				}
				else
				{
					if (!(item.Operand is Instruction[]))
					{
						continue;
					}
					Instruction[] array = (Instruction[])item.Operand;
					Instruction[] array2 = new Instruction[array.Length];
					for (int i = 0; i < array.Length; i++)
					{
						Instruction value2;
						if (dictionary_0.TryGetValue(array[i], out value2))
						{
							array2[i] = value2;
						}
						else
						{
							array2[i] = array[i];
						}
					}
					item.Operand = array2;
				}
			}
		}

		private static void vUi(this CilBody cilBody_0, List<Instruction> list_0, Dictionary<Instruction, Instruction> dictionary_0)
		{
			List<ExceptionHandler> list = new List<ExceptionHandler>();
			foreach (ExceptionHandler exceptionHandler2 in cilBody_0.ExceptionHandlers)
			{
				ExceptionHandler exceptionHandler = new ExceptionHandler(exceptionHandler2.HandlerType);
				exceptionHandler.CatchType = exceptionHandler2.CatchType;
				if (exceptionHandler2.FilterStart != null)
				{
					exceptionHandler.FilterStart = dictionary_0[exceptionHandler2.FilterStart];
				}
				if (exceptionHandler2.HandlerEnd != null)
				{
					exceptionHandler.HandlerEnd = dictionary_0[exceptionHandler2.HandlerEnd];
				}
				if (exceptionHandler2.HandlerStart != null)
				{
					exceptionHandler.HandlerStart = dictionary_0[exceptionHandler2.HandlerStart];
				}
				if (exceptionHandler2.TryEnd != null)
				{
					exceptionHandler.TryEnd = dictionary_0[exceptionHandler2.TryEnd];
				}
				if (exceptionHandler2.TryStart != null)
				{
					exceptionHandler.TryStart = dictionary_0[exceptionHandler2.TryStart];
				}
				list.Add(exceptionHandler);
			}
			cilBody_0.ExceptionHandlers.Clear();
			foreach (ExceptionHandler item in list)
			{
				cilBody_0.ExceptionHandlers.Add(item);
			}
			list_0.oUT(dictionary_0);
			cilBody_0.Instructions.Clear();
			foreach (Instruction item2 in list_0)
			{
				cilBody_0.Instructions.Add(item2);
			}
		}

		private static Instruction YUS(this OpCode opCode_0, object object_0)
		{
			Instruction result = null;
			if (((Instruction)(object)opCode_0).OpCode == OpCodes.Ldloca)
			{
				result = new Instruction(OpCodes.Ldloc, (Local)((Instruction)(object)opCode_0).Operand);
			}
			else if (((Instruction)(object)opCode_0).OpCode == OpCodes.Ldarga)
			{
				result = new Instruction(OpCodes.Ldloc, (Local)((Instruction)(object)opCode_0).Operand);
			}
			return result;
		}

		private static void VUl(ModuleDef moduleDef_0)
		{
			try
			{
				foreach (TypeDef type in moduleDef_0.Types)
				{
					for (int i = 0; i < type.Fields.Count; i++)
					{
						FieldDef fieldDef = type.Fields[i];
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.Object))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.Array))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.String))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.Boolean))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.Char))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.Ptr))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.SZArray))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.Class))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.I))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.I1))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.I2))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.I4))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.I8))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.R))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.R4))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.R8))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.U))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.U1))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.U4))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.U8))
						{
							type.Fields.RemoveAt(i);
						}
					}
				}
			}
			catch
			{
			}
		}

		private static void aUO(ModuleDef moduleDef_0)
		{
			foreach (TypeDef type in moduleDef_0.Types)
			{
				foreach (MethodDef method in type.Methods)
				{
					if (!method.HasBody)
					{
						continue;
					}
					using (new gU8(method, true))
					{
						method.Body.MaxStack = ushort.MaxValue;
						IMethod imethod_ = method.Module.Import(typeof(IntPtr).GetConstructor(new Type[1] { typeof(int) }));
						IMethod imethod_2 = method.Module.Import(typeof(IntPtr).GetConstructor(new Type[1] { typeof(long) }));
						IMethod imethod_3 = method.Module.Import(typeof(IntPtr).GetMethod("ToInt32", Type.EmptyTypes));
						IMethod imethod_4 = method.Module.Import(typeof(IntPtr).GetMethod("ToInt64", Type.EmptyTypes));
						IMethod imethod_5 = method.Module.Import(typeof(UIntPtr).GetConstructor(new Type[1] { typeof(uint) }));
						IMethod imethod_6 = method.Module.Import(typeof(UIntPtr).GetConstructor(new Type[1] { typeof(ulong) }));
						IMethod imethod_7 = method.Module.Import(typeof(UIntPtr).GetMethod("ToUInt32", Type.EmptyTypes));
						IMethod imethod_8 = method.Module.Import(typeof(UIntPtr).GetMethod("ToUInt64", Type.EmptyTypes));
						List<Instruction> list = new List<Instruction>();
						Dictionary<Instruction, Instruction> dictionary = new Dictionary<Instruction, Instruction>();
						Instruction instruction = null;
						foreach (Instruction instruction4 in method.Body.Instructions)
						{
							Instruction instruction2 = null;
							Instruction instruction3 = null;
							if (instruction4.OpCode != OpCodes.Newobj)
							{
								if (instruction4.OpCode == OpCodes.Call)
								{
									IMethod imethod_9 = (IMethod)instruction4.Operand;
									if (WUX.HU9().eUm(imethod_9, imethod_4))
									{
										instruction3 = ((OpCode)(object)instruction).YUS(instruction4);
										if (instruction3 != null)
										{
											instruction2 = new Instruction(OpCodes.Conv_I8);
										}
									}
									else if (WUX.HU9().eUm(imethod_9, imethod_3))
									{
										instruction3 = ((OpCode)(object)instruction).YUS(instruction4);
										if (instruction3 != null)
										{
											instruction2 = new Instruction(OpCodes.Conv_I4);
										}
									}
									else if (WUX.HU9().eUm(imethod_9, imethod_8))
									{
										instruction3 = ((OpCode)(object)instruction).YUS(instruction4);
										if (instruction3 != null)
										{
											instruction2 = new Instruction(OpCodes.Conv_U8);
										}
									}
									else if (WUX.HU9().eUm(imethod_9, imethod_7))
									{
										instruction3 = ((OpCode)(object)instruction).YUS(instruction4);
										if (instruction3 != null)
										{
											instruction2 = new Instruction(OpCodes.Conv_U4);
										}
									}
								}
							}
							else
							{
								IMethod imethod_10 = (IMethod)instruction4.Operand;
								if (WUX.HU9().eUm(imethod_10, imethod_) || WUX.HU9().eUm(imethod_10, imethod_2))
								{
									instruction2 = new Instruction(OpCodes.Conv_I);
								}
								else if (WUX.HU9().eUm(imethod_10, imethod_5) || WUX.HU9().eUm(imethod_10, imethod_6))
								{
									instruction2 = new Instruction(OpCodes.Conv_U);
								}
							}
							if (instruction2 == null)
							{
								instruction2 = instruction4;
							}
							list.Add(instruction2);
							dictionary.Add(instruction4, instruction2);
							if (instruction3 != null)
							{
								list.Insert(list.IndexOf(instruction), instruction3);
								list.Remove(instruction);
								dictionary.Remove(instruction);
								dictionary.Add(instruction, instruction3);
							}
							instruction = instruction4;
						}
						method.Body.vUi(list, dictionary);
					}
				}
			}
		}

		private static void oUI(ModuleDef moduleDef_0)
		{
			foreach (TypeDef type in moduleDef_0.GetTypes())
			{
				foreach (MethodDef method in type.Methods)
				{
					method.Body?.Instructions.OptimizeMacros();
				}
			}
		}

		public static void OptimizeAssembly(ModuleDefMD moduleDefMD_0)
		{
			VUl(moduleDefMD_0);
			aUO(moduleDefMD_0);
			oUI(moduleDefMD_0);
		}
	}
}
