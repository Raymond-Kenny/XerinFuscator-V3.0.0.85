using System;
using System.Reflection;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XF
{
	internal class d2s
	{
		public static void G2Q(MethodDef methodDef_0, object object_0)
		{
			CilBody cilBody = (((MethodDef)object_0).Body = new CilBody());
			cilBody.Instructions.Add(Instruction.Create(OpCodes.Ldsfld, ((MethodDef)object_0).Module.Import((FieldDef)((PKj)(object)methodDef_0).IKV[4])));
			if (((MethodDef)object_0).Parameters.Count == 0)
			{
				cilBody.Instructions.Add(Instruction.Create(OpCodes.Ldnull));
			}
			else
			{
				cilBody.Instructions.Add(Instruction.Create(OpCodes.Ldc_I4, ((MethodDef)object_0).Parameters.Count));
				cilBody.Instructions.Add(Instruction.Create(OpCodes.Newarr, ((MethodDef)object_0).Module.CorLibTypes.Object.ToTypeDefOrRef()));
				foreach (Parameter parameter in ((MethodDef)object_0).Parameters)
				{
					cilBody.Instructions.Add(Instruction.Create(OpCodes.Dup));
					cilBody.Instructions.Add(Instruction.Create(OpCodes.Ldc_I4, parameter.Index));
					cilBody.Instructions.Add(Instruction.Create(OpCodes.Ldarg, parameter));
					if (!parameter.Type.IsByRef)
					{
						if (!parameter.Type.IsPointer)
						{
							if (parameter.Type.IsValueType)
							{
								cilBody.Instructions.Add(Instruction.Create(OpCodes.Box, parameter.Type.ToTypeDefOrRef()));
							}
							else
							{
								cilBody.Instructions.Add(Instruction.Create(OpCodes.Box, parameter.Type.ToTypeDefOrRef()));
							}
						}
						else
						{
							cilBody.Instructions.Add(Instruction.Create(OpCodes.Ldtoken, parameter.Type.ToTypeDefOrRef()));
							cilBody.Instructions.Add(Instruction.Create(OpCodes.Call, ((MethodDef)object_0).Module.Import(typeof(Type).GetMethod("GetTypeFromHandle", BindingFlags.Static | BindingFlags.Public))));
							cilBody.Instructions.Add(Instruction.Create(OpCodes.Call, ((MethodDef)object_0).Module.Import(typeof(Pointer).GetMethod("Box", BindingFlags.Static | BindingFlags.Public))));
						}
					}
					else
					{
						cilBody.Instructions.Add(Instruction.Create(OpCodes.Mkrefany, parameter.Type.Next.ToTypeDefOrRef()));
						cilBody.Instructions.Add(Instruction.Create(OpCodes.Newobj, ((MethodDef)object_0).Module.Import(((PKj)(object)methodDef_0).EKD)));
					}
					cilBody.Instructions.Add(Instruction.Create(OpCodes.Stelem_Ref));
				}
			}
			cilBody.Instructions.Add(Instruction.Create(OpCodes.Ldtoken, (IMethod)object_0));
			cilBody.Instructions.Add(Instruction.Create(OpCodes.Ldftn, ((MethodDef)object_0).Module.Import((MethodDef)((PKj)(object)methodDef_0).IKV[3])));
			cilBody.Instructions.Add(Instruction.Create(OpCodes.Calli, ((MethodDef)object_0).Module.Import((MethodDef)((PKj)(object)methodDef_0).IKV[3]).MethodSig));
			TypeSig typeSig = null;
			typeSig = ((((MethodDef)object_0).ReturnType.Next != null) ? ((MethodDef)object_0).ReturnType.Next : ((MethodDef)object_0).ReturnType);
			if (((MethodDef)object_0).ReturnType.IsPointer || (typeSig.IsPointer && ((MethodDef)object_0).ReturnType.IsByRef))
			{
				cilBody.Instructions.Add(Instruction.Create(OpCodes.Call, ((MethodDef)object_0).Module.Import(typeof(Pointer).GetMethod("Unbox", BindingFlags.Static | BindingFlags.Public))));
				if (((MethodDef)object_0).ReturnType.IsByRef)
				{
					if (((MethodDef)object_0).ReturnType.Next.ToTypeDefOrRef().FullName == "System.Void*")
					{
						typeSig = null;
					}
				}
				else if (((MethodDef)object_0).ReturnType.ToTypeDefOrRef().FullName == "System.Void*")
				{
					typeSig = null;
				}
			}
			if (((MethodDef)object_0).ReturnType.ElementType != ElementType.Void)
			{
				if (!((MethodDef)object_0).ReturnType.IsValueType)
				{
					if (((MethodDef)object_0).ReturnType.ToTypeDefOrRef().FullName != "System.Object&" && typeSig != null)
					{
						if (!((MethodDef)object_0).ReturnType.IsByRef)
						{
							cilBody.Instructions.Add(Instruction.Create(OpCodes.Castclass, ((MethodDef)object_0).ReturnType.ToTypeDefOrRef()));
						}
						else
						{
							cilBody.Instructions.Add(Instruction.Create(OpCodes.Castclass, ((MethodDef)object_0).ReturnType.Next.ToTypeDefOrRef()));
						}
					}
				}
				else if (((MethodDef)object_0).ReturnType.ToTypeDefOrRef().FullName != "System.Object&" && typeSig != null)
				{
					if (!((MethodDef)object_0).ReturnType.IsByRef)
					{
						cilBody.Instructions.Add(Instruction.Create(OpCodes.Unbox_Any, ((MethodDef)object_0).ReturnType.ToTypeDefOrRef()));
					}
					else
					{
						cilBody.Instructions.Add(Instruction.Create(OpCodes.Unbox_Any, ((MethodDef)object_0).ReturnType.Next.ToTypeDefOrRef()));
					}
				}
			}
			else
			{
				cilBody.Instructions.Add(Instruction.Create(OpCodes.Pop));
			}
			if (((MethodDef)object_0).ReturnType.ElementType != ElementType.Void && ((MethodDef)object_0).ReturnType.IsByRef)
			{
				Local local = new Local(((MethodDef)object_0).ReturnType.Next);
				cilBody.Variables.Add(local);
				cilBody.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
				cilBody.Instructions.Add(Instruction.Create(OpCodes.Ldloca, local));
			}
			cilBody.Instructions.Add(Instruction.Create(OpCodes.Ret));
			cilBody.OptimizeMacros();
			cilBody.OptimizeBranches();
			cilBody.Instructions.Insert(1, new Instruction(OpCodes.Br_S, cilBody.Instructions[1]));
			cilBody.Instructions.Insert(2, new Instruction(OpCodes.Unaligned, (byte)0));
		}
	}
}
