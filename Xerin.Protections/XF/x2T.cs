using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Generator;
using XCore.Utils;

namespace XF
{
	internal class x2T
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class owg
		{
			public static readonly owg PwK;

			public static Func<Local, Local> PwG;

			public static Func<Local, Local> jwj;

			static owg()
			{
				PwK = new owg();
			}

			internal Local Bwo(Local local_0)
			{
				return local_0;
			}

			internal Local Dwn(Local local_0)
			{
				return local_0;
			}
		}

		private static Dictionary<int, int> e2u;

		private static int h2V;

		public void z2i(ModuleDefMD moduleDefMD_0)
		{
			TypeDef[] array = moduleDefMD_0.Types.ToArray();
			foreach (TypeDef typeDef in array)
			{
				MethodDef[] array2 = typeDef.Methods.ToArray();
				foreach (MethodDef methodDef in array2)
				{
					if (methodDef == moduleDefMD_0.GlobalType.FindOrCreateStaticConstructor())
					{
						DnlibUtils.Simplify(methodDef);
						X2Z(methodDef, moduleDefMD_0);
						DnlibUtils.Optimize(methodDef);
					}
				}
			}
		}

		public void X2Z(MethodDef methodDef_0, ModuleDef moduleDef_0)
		{
			try
			{
				AssemblyDef assembly = moduleDef_0.Assembly;
				a24.P2Y();
				g2X.i2g();
				TypeDef declaringType = methodDef_0.DeclaringType;
				Instruction[] instruction_ = methodDef_0.Body.Instructions.ToArray();
				Instruction[] array = null;
				Local local = new Local(assembly.ManifestModule.Import(typeof(List<Type>)).ToTypeSig());
				Local local2 = new Local(assembly.ManifestModule.Import(typeof(DynamicMethod)).ToTypeSig());
				Local local3 = new Local(assembly.ManifestModule.Import(typeof(ILGenerator)).ToTypeSig());
				Local local4 = new Local(assembly.ManifestModule.Import(typeof(Label[])).ToTypeSig());
				TypeSig returnType = methodDef_0.ReturnType;
				Local[] local_ = methodDef_0.Body.Variables.ToArray();
				List<Local> list_ = new List<Local>();
				array = ((!(methodDef_0.Name != ".ctor")) ? ((!methodDef_0.HasParamDefs) ? t2F(methodDef_0.Body.Instructions.ToArray(), declaringType, methodDef_0, null, methodDef_0.ReturnType.ToTypeDefOrRef(), methodDef_0.Parameters.ToArray(), declaringType, local, local2, local3, local4, local_, instruction_, assembly, bool_0: true, out list_, returnType) : t2F(methodDef_0.Body.Instructions.ToArray(), declaringType, methodDef_0, methodDef_0.ParamDefs[0].DeclaringMethod.MethodSig.Params, methodDef_0.ReturnType.ToTypeDefOrRef(), methodDef_0.Parameters.ToArray(), declaringType, local, local2, local3, local4, local_, instruction_, assembly, bool_0: true, out list_, returnType)) : ((!methodDef_0.HasParamDefs) ? t2F(methodDef_0.Body.Instructions.ToArray(), declaringType, methodDef_0, null, methodDef_0.ReturnType.ToTypeDefOrRef(), methodDef_0.Parameters.ToArray(), declaringType, local, local2, local3, local4, local_, instruction_, assembly, bool_0: false, out list_, returnType) : t2F(methodDef_0.Body.Instructions.ToArray(), declaringType, methodDef_0, methodDef_0.ParamDefs[0].DeclaringMethod.MethodSig.Params, methodDef_0.ReturnType.ToTypeDefOrRef(), methodDef_0.Parameters.ToArray(), declaringType, local, local2, local3, local4, local_, instruction_, assembly, bool_0: false, out list_, returnType)));
				methodDef_0.Body.Instructions.Clear();
				methodDef_0.Body.Variables.Add(local);
				methodDef_0.Body.Variables.Add(local2);
				methodDef_0.Body.Variables.Add(local3);
				methodDef_0.Body.Variables.Add(local4);
				foreach (Local item2 in list_)
				{
					methodDef_0.Body.Variables.Add(item2);
				}
				Instruction[] array2 = array;
				foreach (Instruction item in array2)
				{
					methodDef_0.Body.Instructions.Add(item);
				}
			}
			catch
			{
			}
		}

		public static Instruction[] t2F(object object_0, TypeDef typeDef_0, object object_1, IList<TypeSig> ilist_0, ITypeDefOrRef itypeDefOrRef_0, IList<Parameter> ilist_1, ITypeDefOrRef itypeDefOrRef_1, Local local_0, Local local_1, Local local_2, Local local_3, Local[] local_4, Instruction[] instruction_0, AssemblyDef assemblyDef_0, bool bool_0, out List<Local> list_0, TypeSig typeSig_0)
		{
			List<Instruction> list_1 = new List<Instruction>();
			List<Local> list_2 = new List<Local>();
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Nop.ToInstruction());
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(9999));
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Label))));
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Stloc_S.ToInstruction(local_3));
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Newobj.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(List<Type>).GetConstructor(new Type[0]))));
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Stloc_S.ToInstruction(local_0));
			if (ilist_1.ToArray().Count() != 0 && ilist_1[0] != null)
			{
				list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_0));
				list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(ilist_1[0].Type.ToTypeDefOrRef()));
				list_1.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[1] { typeof(RuntimeTypeHandle) }))));
				list_1.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(List<Type>).GetMethod("Add", new Type[1] { typeof(Type) }))));
			}
			if (ilist_0 != null)
			{
				foreach (TypeSig item in ilist_0)
				{
					list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_0));
					list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(item.ToTypeDefOrRef()));
					list_1.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[1] { typeof(RuntimeTypeHandle) }))));
					list_1.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(List<Type>).GetMethod("Add", new Type[1] { typeof(Type) }))));
				}
			}
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldstr.ToInstruction(GGeneration.GenerateGuidStartingWithLetter()));
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(itypeDefOrRef_0));
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[1] { typeof(RuntimeTypeHandle) }))));
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_0));
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(List<Type>).GetMethod("ToArray", new Type[0]))));
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(itypeDefOrRef_1));
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[1] { typeof(RuntimeTypeHandle) }))));
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("get_Module"))));
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4_1.ToInstruction());
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Newobj.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(DynamicMethod).GetConstructor(new Type[5]
			{
				typeof(string),
				typeof(Type),
				typeof(Type[]),
				typeof(Module),
				typeof(bool)
			}))));
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Stloc_S.ToInstruction(local_1));
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_1));
			list_1.Add(Instruction.Create(dnlib.DotNet.Emit.OpCodes.Callvirt, assemblyDef_0.ManifestModule.Import(typeof(DynamicMethod).GetMethod("GetILGenerator", new Type[0]))));
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Stloc_S.ToInstruction(local_2));
			if (bool_0)
			{
				B2O(new Local(assemblyDef_0.ManifestModule.Import(typeDef_0).ToTypeSig()), local_2, ref list_1, assemblyDef_0, ref list_2);
			}
			if (local_4.Count() != 0)
			{
				foreach (Local local_5 in local_4)
				{
					B2O(local_5, local_2, ref list_1, assemblyDef_0, ref list_2);
				}
			}
			List<Instruction> list = new List<Instruction>();
			foreach (Instruction instruction in instruction_0)
			{
				if (instruction.OpCode.OperandType == dnlib.DotNet.Emit.OperandType.InlineBrTarget || instruction.OpCode.OperandType == dnlib.DotNet.Emit.OperandType.ShortInlineBrTarget)
				{
					list.Add(instruction);
					list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_3));
					list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction((int)((Instruction)instruction.Operand).Offset));
					list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_2));
					list_1.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("DefineLabel", new Type[0]))));
					list_1.Add(dnlib.DotNet.Emit.OpCodes.Stelem.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Label))));
				}
			}
			h2V = 0;
			foreach (Instruction instruction2 in instruction_0)
			{
				if (instruction2.Operand != null)
				{
					U2D((dnlib.DotNet.Emit.OpCode)(object)instruction2, local_2, ref list_1, list_2, list, assemblyDef_0);
				}
				else
				{
					e2v((dnlib.DotNet.Emit.OpCode)(object)instruction2, local_2, ref list_1, assemblyDef_0);
				}
			}
			list_1.UpdateInstructionOffsets();
			List<Instruction> list2 = new List<Instruction>();
			List<Instruction> list3 = new List<Instruction>();
			List<int> list4 = new List<int>();
			List<int> list5 = new List<int>();
			foreach (Instruction item2 in list_1)
			{
				if (item2.OpCode == dnlib.DotNet.Emit.OpCodes.Ldsfld)
				{
					list2.Add(item2);
				}
			}
			foreach (Instruction instruction3 in instruction_0)
			{
				if (instruction3.OpCode.OperandType != dnlib.DotNet.Emit.OperandType.InlineBrTarget && instruction3.OpCode.OperandType != dnlib.DotNet.Emit.OperandType.ShortInlineBrTarget)
				{
					continue;
				}
				list3.Add(instruction3);
				Instruction instruction4 = (Instruction)instruction3.Operand;
				int num = 0;
				for (int n = 0; n < instruction_0.Count(); n++)
				{
					if (instruction_0[n].OpCode == instruction4.OpCode)
					{
						num++;
						if (instruction_0[n] == instruction4)
						{
							list4.Add(num);
							break;
						}
					}
				}
				instruction4 = instruction3;
				int num2 = 0;
				for (int num3 = 0; num3 < instruction_0.Count(); num3++)
				{
					if (instruction_0[num3].OpCode == instruction4.OpCode)
					{
						num2++;
						if (instruction_0[num3] == instruction4)
						{
							list5.Add(num2);
							break;
						}
					}
				}
			}
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			string text = "";
			int num7 = 0;
			for (int num8 = 0; num8 < list3.Count; num8++)
			{
				for (int num9 = 0; num9 < list_1.Count; num9++)
				{
					if (list_1[num9].OpCode != dnlib.DotNet.Emit.OpCodes.Ldsfld)
					{
						continue;
					}
					if (num5 != 0)
					{
						num5--;
						continue;
					}
					string text2 = ((Instruction)list3[num8].Operand).ToString().Substring(9).ToLower();
					string text3 = list_1[num9].ToString().Replace("System.Reflection.Emit.OpCode System.Reflection.Emit.OpCodes::", "").ToLower()
						.Replace("_", ".")
						.Substring(16);
					if (text2 == text3)
					{
						if (text != text2)
						{
							num7 = 0;
						}
						num7++;
						text = text2;
						if (num7 == list4[num4])
						{
							num7 = 0;
							num6++;
							num5 = num6;
							num4++;
							int num10 = num9;
							list_1.Insert(num10 - 1, dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_2));
							list_1.Insert(num10, dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_3));
							list_1.Insert(num10 + 1, dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction((int)((Instruction)list3[num8].Operand).Offset));
							list_1.Insert(num10 + 2, dnlib.DotNet.Emit.OpCodes.Ldelem.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Label))));
							list_1.Insert(num10 + 3, dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("MarkLabel", new Type[1] { typeof(Label) }))));
							num9 += 3;
						}
					}
					else
					{
						num5 = num6;
					}
				}
			}
			num4 = 0;
			num5 = 0;
			num6 = 0;
			text = "";
			num7 = 0;
			for (int num11 = 0; num11 < list3.Count; num11++)
			{
				for (int num12 = 0; num12 < list_1.Count; num12++)
				{
					if (list_1[num12].OpCode != dnlib.DotNet.Emit.OpCodes.Ldsfld)
					{
						continue;
					}
					if (num5 != 0)
					{
						num5--;
						continue;
					}
					string text4 = list3[num11].OpCode.ToString().ToLower();
					string text5 = list_1[num12].ToString().Replace("System.Reflection.Emit.OpCode System.Reflection.Emit.OpCodes::", "").ToLower()
						.Replace("_", ".")
						.Substring(16);
					if (text4 == text5)
					{
						if (text != text4)
						{
							num7 = 0;
						}
						num7++;
						text = text4;
						if (num7 == list5[num4])
						{
							num7 = 0;
							num6++;
							num5 = num6;
							num4++;
							int num13 = num12;
							list_1.Insert(num13 + 1, dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_3));
							list_1.Insert(num13 + 2, dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction((int)((Instruction)list3[num11].Operand).Offset));
							list_1.Insert(num13 + 3, dnlib.DotNet.Emit.OpCodes.Ldelem.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Label))));
							list_1.Insert(num13 + 4, dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[2]
							{
								typeof(System.Reflection.Emit.OpCode),
								typeof(Label)
							}))));
							num12 += 3;
						}
					}
					else
					{
						num5 = num6;
					}
				}
			}
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_1));
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction());
			if (ilist_0 != null)
			{
				list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(ilist_0.Count + 1));
			}
			else if (ilist_1.ToArray().Count() != 0)
			{
				list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(ilist_1.ToArray().Count()));
			}
			else
			{
				list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(0));
			}
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(object))));
			if (ilist_0 != null)
			{
				int num14 = 0;
				list_1.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
				foreach (Parameter item3 in ilist_1)
				{
					list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(num14));
					list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldarg_S.ToInstruction(item3));
					list_1.Add(dnlib.DotNet.Emit.OpCodes.Stelem_Ref.ToInstruction());
					list_1.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
					num14++;
				}
				list_1.RemoveAt(list_1.Count - 1);
			}
			else if (ilist_1.ToArray().Count() != 0)
			{
				int num15 = 0;
				list_1.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
				foreach (Parameter item4 in ilist_1)
				{
					list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(num15));
					list_1.Add(dnlib.DotNet.Emit.OpCodes.Ldarg_S.ToInstruction(item4));
					list_1.Add(dnlib.DotNet.Emit.OpCodes.Stelem_Ref.ToInstruction());
					list_1.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
					num15++;
				}
				list_1.RemoveAt(list_1.Count - 1);
			}
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(MethodBase).GetMethod("Invoke", new Type[2]
			{
				typeof(object),
				typeof(object[])
			}))));
			if (typeSig_0.TypeName != "Void")
			{
				list_1.Add(dnlib.DotNet.Emit.OpCodes.Unbox_Any.ToInstruction(typeSig_0.ToTypeDefOrRef()));
			}
			else
			{
				list_1.Add(dnlib.DotNet.Emit.OpCodes.Pop.ToInstruction());
			}
			list_1.Add(dnlib.DotNet.Emit.OpCodes.Ret.ToInstruction());
			list_0 = list_2;
			return list_1.ToArray();
		}

		public static void U2D(dnlib.DotNet.Emit.OpCode opCode_0, Local local_0, ref List<Instruction> list_0, List<Local> list_1, List<Instruction> list_2, AssemblyDef assemblyDef_0)
		{
			list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_0));
			char[] array = a24.k2s(((Instruction)(object)opCode_0).OpCode).Name.ToCharArray();
			array[0] = Convert.ToChar(array[0].ToString().Replace(array[0].ToString(), array[0].ToString().ToUpper()));
			string text = new string(array);
			string text2 = "";
			if (text.Contains("."))
			{
				text2 = text.Substring(text.IndexOf('.')).ToUpper();
				text = text.Replace(text2.ToLower(), text2);
			}
			FieldInfo field = typeof(System.Reflection.Emit.OpCodes).GetField(text.Replace(".", "_"), BindingFlags.Static | BindingFlags.Public);
			list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldsfld.ToInstruction(assemblyDef_0.ManifestModule.Import(field)));
			object operand = ((Instruction)(object)opCode_0).Operand;
			if (!(operand is ConstructorInfo))
			{
				if (operand is MethodDef)
				{
					if (operand.ToString().Contains(".ctor"))
					{
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(((MethodDef)operand).DeclaringType.ToTypeSig().ToTypeDefOrRef()));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[1] { typeof(RuntimeTypeHandle) }))));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(0));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type))));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetConstructor", new Type[1] { typeof(Type[]) }))));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[2]
						{
							typeof(System.Reflection.Emit.OpCode),
							typeof(ConstructorInfo)
						}))));
						return;
					}
					if (((Instruction)(object)opCode_0).OpCode == dnlib.DotNet.Emit.OpCodes.Ldftn)
					{
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(((MethodDef)operand).DeclaringType.ToTypeSig().ToTypeDefOrRef()));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[1] { typeof(RuntimeTypeHandle) }))));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldstr.ToInstruction(((MethodDef)operand).Name));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(17301375));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction());
						int num = 0;
						int num2 = 0;
						foreach (TypeSig item in ((MethodBaseSig)((MethodDef)operand).Signature).Params)
						{
							if (num == 0)
							{
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(((MethodBaseSig)((MethodDef)operand).Signature).Params.Count));
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type))));
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
								num++;
							}
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(num2));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(item.ToTypeDefOrRef()));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[1] { typeof(RuntimeTypeHandle) }))));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Stelem_Ref.ToInstruction());
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
							num2++;
						}
						list_0.RemoveAt(list_0.Count - 1);
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction());
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetMethod", new Type[5]
						{
							typeof(string),
							typeof(BindingFlags),
							typeof(Binder),
							typeof(Type[]),
							typeof(ParameterModifier[])
						}))));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[2]
						{
							typeof(System.Reflection.Emit.OpCode),
							typeof(MethodInfo)
						}))));
						return;
					}
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(((MethodDef)operand).DeclaringType.ToTypeSig().ToTypeDefOrRef()));
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[1] { typeof(RuntimeTypeHandle) }))));
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldstr.ToInstruction(((MethodDef)operand).Name));
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(17301375));
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction());
					int num3 = 0;
					int num4 = 0;
					if (((MethodBaseSig)((MethodDef)operand).Signature).Params.Count >= 1)
					{
						foreach (TypeSig item2 in ((MethodBaseSig)((MethodDef)operand).Signature).Params)
						{
							if (num3 == 0)
							{
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(((MethodBaseSig)((MethodDef)operand).Signature).Params.Count));
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type))));
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
								num3++;
							}
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(num4));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(item2.ToTypeDefOrRef()));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[1] { typeof(RuntimeTypeHandle) }))));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Stelem_Ref.ToInstruction());
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
							num4++;
						}
						list_0.RemoveAt(list_0.Count - 1);
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction());
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetMethod", new Type[5]
						{
							typeof(string),
							typeof(BindingFlags),
							typeof(Binder),
							typeof(Type[]),
							typeof(ParameterModifier[])
						}))));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[2]
						{
							typeof(System.Reflection.Emit.OpCode),
							typeof(MethodInfo)
						}))));
					}
					else
					{
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4_0.ToInstruction());
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type))));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction());
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetMethod", new Type[5]
						{
							typeof(string),
							typeof(BindingFlags),
							typeof(Binder),
							typeof(Type[]),
							typeof(ParameterModifier[])
						}))));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[2]
						{
							typeof(System.Reflection.Emit.OpCode),
							typeof(MethodInfo)
						}))));
					}
					return;
				}
				if (operand is string)
				{
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldstr.ToInstruction(operand.ToString()));
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[2]
					{
						typeof(System.Reflection.Emit.OpCode),
						typeof(string)
					}))));
					return;
				}
				if (operand is TypeDef)
				{
					return;
				}
				if (!(operand is ConstructorInfo))
				{
					if (operand is int)
					{
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(int.Parse(operand.ToString())));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[2]
						{
							typeof(System.Reflection.Emit.OpCode),
							typeof(int)
						}))));
						return;
					}
					if (((Instruction)(object)opCode_0).OpCode == dnlib.DotNet.Emit.OpCodes.Ldc_I4_S)
					{
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4_S.ToInstruction(sbyte.Parse(operand.ToString())));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[2]
						{
							typeof(System.Reflection.Emit.OpCode),
							typeof(sbyte)
						}))));
						return;
					}
					if (operand is double)
					{
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_R8.ToInstruction(double.Parse(operand.ToString().Replace(".", ","))));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[2]
						{
							typeof(System.Reflection.Emit.OpCode),
							typeof(double)
						}))));
						return;
					}
					if (operand is float)
					{
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_R4.ToInstruction(float.Parse(operand.ToString().Replace(".", ","))));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[2]
						{
							typeof(System.Reflection.Emit.OpCode),
							typeof(float)
						}))));
						return;
					}
					if (operand is MemberRef)
					{
						if (((Instruction)(object)opCode_0).OpCode == dnlib.DotNet.Emit.OpCodes.Ldftn)
						{
							return;
						}
						if (operand.ToString().Contains(".ctor"))
						{
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(((MemberRef)operand).DeclaringType.ToTypeSig().ToTypeDefOrRef()));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[1] { typeof(RuntimeTypeHandle) }))));
							int num5 = 0;
							int num6 = 0;
							if (((MethodBaseSig)((MemberRef)operand).Signature).Params.Count >= 1)
							{
								foreach (TypeSig item3 in ((MethodBaseSig)((MemberRef)operand).Signature).Params)
								{
									if (num5 == 0)
									{
										list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(((MethodBaseSig)((MemberRef)operand).Signature).Params.Count));
										list_0.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type))));
										list_0.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
										num5++;
									}
									list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(num6));
									list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(item3.ToTypeDefOrRef()));
									list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[1] { typeof(RuntimeTypeHandle) }))));
									list_0.Add(dnlib.DotNet.Emit.OpCodes.Stelem_Ref.ToInstruction());
									list_0.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
									num6++;
								}
								list_0.RemoveAt(list_0.Count - 1);
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetConstructor", new Type[1] { typeof(Type[]) }))));
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[2]
								{
									typeof(System.Reflection.Emit.OpCode),
									typeof(ConstructorInfo)
								}))));
							}
							else
							{
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(0));
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type))));
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetConstructor", new Type[1] { typeof(Type[]) }))));
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[2]
								{
									typeof(System.Reflection.Emit.OpCode),
									typeof(ConstructorInfo)
								}))));
							}
							return;
						}
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(((MemberRef)operand).DeclaringType.ToTypeSig().ToTypeDefOrRef()));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[1] { typeof(RuntimeTypeHandle) }))));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldstr.ToInstruction(((MemberRef)operand).Name));
						int num7 = 0;
						int num8 = 0;
						if (((MethodBaseSig)((MemberRef)operand).Signature).Params.Count >= 1)
						{
							foreach (TypeSig item4 in ((MethodBaseSig)((MemberRef)operand).Signature).Params)
							{
								if (num7 == 0)
								{
									list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(((MethodBaseSig)((MemberRef)operand).Signature).Params.Count));
									list_0.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type))));
									list_0.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
									num7++;
								}
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(num8));
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(item4.ToTypeDefOrRef()));
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[1] { typeof(RuntimeTypeHandle) }))));
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Stelem_Ref.ToInstruction());
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
								num8++;
							}
							list_0.RemoveAt(list_0.Count - 1);
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetMethod", new Type[2]
							{
								typeof(string),
								typeof(Type[])
							}))));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[2]
							{
								typeof(System.Reflection.Emit.OpCode),
								typeof(MethodInfo)
							}))));
						}
						else
						{
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(17301375));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction());
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4_0.ToInstruction());
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type))));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction());
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetMethod", new Type[5]
							{
								typeof(string),
								typeof(BindingFlags),
								typeof(Binder),
								typeof(Type[]),
								typeof(ParameterModifier[])
							}))));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[2]
							{
								typeof(System.Reflection.Emit.OpCode),
								typeof(MethodInfo)
							}))));
						}
						return;
					}
					if (operand is FieldDef)
					{
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(((FieldDef)operand).DeclaringType.ToTypeSig().ToTypeDefOrRef()));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[1] { typeof(RuntimeTypeHandle) }))));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldstr.ToInstruction(((FieldDef)operand).Name));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(17301375));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetField", new Type[2]
						{
							typeof(string),
							typeof(BindingFlags)
						}))));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[2]
						{
							typeof(System.Reflection.Emit.OpCode),
							typeof(FieldInfo)
						}))));
						return;
					}
					if (operand is TypeRef)
					{
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(((TypeRef)operand).ToTypeSig().ToTypeDefOrRef()));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[1] { typeof(RuntimeTypeHandle) }))));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[2]
						{
							typeof(System.Reflection.Emit.OpCode),
							typeof(Type)
						}))));
						return;
					}
					if (operand is Local)
					{
						try
						{
							Dictionary<Local, Local> dictionary = list_1.ToDictionary((Local result) => result, (Local result) => result);
							dictionary.TryGetValue(list_1[int.Parse(((Local)operand).ToString().Replace("V_", ""))], out var value);
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(value));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[2]
							{
								typeof(System.Reflection.Emit.OpCode),
								typeof(LocalBuilder)
							}))));
							return;
						}
						catch (Exception ex)
						{
							Console.WriteLine($"{((Instruction)(object)opCode_0).OpCode}::{operand} msg: {ex.Message}");
						}
					}
					else if (((Instruction)(object)opCode_0).OpCode.OperandType == dnlib.DotNet.Emit.OperandType.InlineBrTarget || ((Instruction)(object)opCode_0).OpCode.OperandType == dnlib.DotNet.Emit.OperandType.ShortInlineBrTarget || ((Instruction)(object)opCode_0).OpCode == dnlib.DotNet.Emit.OpCodes.Nop)
					{
						return;
					}
				}
			}
			list_0.RemoveAt(list_0.Count - 1);
			list_0.RemoveAt(list_0.Count - 1);
		}

		public static void e2v(dnlib.DotNet.Emit.OpCode opCode_0, Local local_0, ref List<Instruction> list_0, AssemblyDef assemblyDef_0)
		{
			list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_0));
			char[] array = a24.k2s(((Instruction)(object)opCode_0).OpCode).Name.ToCharArray();
			array[0] = Convert.ToChar(array[0].ToString().Replace(array[0].ToString(), array[0].ToString().ToUpper()));
			string text = new string(array);
			string text2 = "";
			if (text.Contains("."))
			{
				text2 = text.Substring(text.IndexOf('.')).ToUpper();
				text = text.Replace(text2.ToLower(), text2);
			}
			FieldInfo field = typeof(System.Reflection.Emit.OpCodes).GetField(text.Replace(".", "_"), BindingFlags.Static | BindingFlags.Public);
			if (field == null)
			{
				Console.WriteLine(text);
			}
			list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldsfld.ToInstruction(assemblyDef_0.ManifestModule.Import(field)));
			list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[1] { typeof(System.Reflection.Emit.OpCode) }))));
		}

		public static void B2O(Local local_0, Local local_1, ref List<Instruction> list_0, AssemblyDef assemblyDef_0, ref List<Local> list_1)
		{
			list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_1));
			list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(local_0.Type.ToTypeDefOrRef()));
			list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[1] { typeof(RuntimeTypeHandle) }))));
			list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("DeclareLocal", new Type[1] { typeof(Type) }))));
			list_1.Add(new Local(assemblyDef_0.ManifestModule.Import(typeof(LocalBuilder)).ToTypeSig()));
			list_0.Add(dnlib.DotNet.Emit.OpCodes.Stloc_S.ToInstruction(list_1[list_1.Count - 1]));
		}

		static x2T()
		{
			e2u = new Dictionary<int, int>();
			h2V = 0;
		}
	}
}
