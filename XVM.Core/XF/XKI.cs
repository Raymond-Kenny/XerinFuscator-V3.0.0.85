using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;
using XVM.Core.RT;
using XVM.Core.RT.Mutation;
using XVM.Core.VM;

namespace XF
{
	internal class XKI
	{
		private Metadata bKw;

		private VMRuntime YKW;

		internal RTConstants zKE;

		public XKI(VMRuntime vmruntime_0)
		{
			YKW = vmruntime_0;
			zKE = new RTConstants(vmruntime_0.EncryptionKey);
			zKE.ReadConstants(vmruntime_0.Descriptor);
		}

		public void KKq()
		{
			xKN.SK2(YKW.RTModule);
			zKE.ReadConstants(YKW.Descriptor);
			YKW.o2o().d28();
			TypeRef typeRef = YKW.RTModule.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "SuppressIldasmAttribute");
			MemberRefUser ctor = new MemberRefUser(YKW.RTModule, ".ctor", MethodSig.CreateInstance(YKW.RTModule.CorLibTypes.Void), typeRef);
			CustomAttribute item = new CustomAttribute(ctor);
			YKW.RTModule.Assembly.CustomAttributes.Add(item);
			YKW.RTModule.CustomAttributes.Add(item);
			TypeRef typeRef2 = YKW.RTModule.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "SuppressUnmanagedCodeSecurity");
			MemberRefUser ctor2 = new MemberRefUser(YKW.RTModule, ".ctor", MethodSig.CreateInstance(YKW.RTModule.CorLibTypes.Void), typeRef2);
			CustomAttribute item2 = new CustomAttribute(ctor2);
			YKW.RTModule.Assembly.CustomAttributes.Add(item2);
			YKW.RTModule.CustomAttributes.Add(item2);
			TypeRef typeRef3 = YKW.RTModule.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "UnsafeValueTypeAttribute");
			MemberRefUser ctor3 = new MemberRefUser(YKW.RTModule, ".ctor", MethodSig.CreateInstance(YKW.RTModule.CorLibTypes.Void), typeRef3);
			CustomAttribute item3 = new CustomAttribute(ctor3);
			YKW.RTModule.Assembly.CustomAttributes.Add(item3);
			YKW.RTModule.CustomAttributes.Add(item3);
			TypeRef typeRef4 = YKW.RTModule.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "RuntimeWrappedException");
			MemberRefUser ctor4 = new MemberRefUser(YKW.RTModule, ".ctor", MethodSig.CreateInstance(YKW.RTModule.CorLibTypes.Void), typeRef4);
			CustomAttribute item4 = new CustomAttribute(ctor4);
			YKW.RTModule.Assembly.CustomAttributes.Add(item4);
			YKW.RTModule.CustomAttributes.Add(item4);
		}

		public void JKM(ModuleDef moduleDef_0, Metadata metadata_0)
		{
			bKw = metadata_0;
			OKR(moduleDef_0);
			lK0();
			YKW.OnKoiRequested();
			YKW.ResetData();
		}

		public void yKA(ModuleDef moduleDef_0)
		{
			MethodDef methodDef = moduleDef_0.GlobalType.FindOrCreateStaticConstructor();
			MethodInfo method = typeof(Environment).GetMethod("get_Version", BindingFlags.Static | BindingFlags.Public);
			methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Ldftn, methodDef.Module.Import(method)));
			methodDef.Body.Instructions.Insert(1, Instruction.Create(OpCodes.Calli, methodDef.Module.Import(method).MethodSig));
			methodDef.Body.Instructions.Insert(2, Instruction.Create(OpCodes.Ldftn, moduleDef_0.Import(YKW.f2C().VKg)));
			methodDef.Body.Instructions.Insert(3, Instruction.Create(OpCodes.Calli, moduleDef_0.Import(YKW.f2C().VKg).MethodSig));
			methodDef.Body.Instructions.Insert(1, new Instruction(OpCodes.Br_S, methodDef.Body.Instructions[1]));
			methodDef.Body.Instructions.Insert(2, new Instruction(OpCodes.Unaligned, (byte)0));
		}

		private void OKR(ModuleDef moduleDef_0)
		{
			List<KeyValuePair<IMemberRef, uint>> list = YKW.Descriptor.Data.EIJ.ToList();
			YKW.Descriptor.Data.EIJ.Clear();
			foreach (KeyValuePair<IMemberRef, uint> item2 in list)
			{
				object obj = ((item2.Key is ITypeDefOrRef) ? ((object)moduleDef_0.Import((ITypeDefOrRef)item2.Key)) : ((object)((!(item2.Key is MemberRef)) ? ((item2.Key is MethodDef) ? moduleDef_0.Import((MethodDef)item2.Key) : ((item2.Key is MethodSpec) ? moduleDef_0.Import((MethodSpec)item2.Key) : ((item2.Key is FieldDef) ? moduleDef_0.Import((FieldDef)item2.Key) : item2.Key))) : moduleDef_0.Import((MemberRef)item2.Key))));
				YKW.Descriptor.Data.EIJ.Add((IMemberRef)obj, item2.Value);
			}
			foreach (wqe item3 in YKW.Descriptor.Data.QI8)
			{
				MethodSig lqG = item3.lqG;
				FuncSig gqq = item3.Gqq;
				if (lqG.HasThis)
				{
					gqq.Flags |= YKW.Descriptor.Runtime.RTFlags.INSTANCE;
				}
				List<ITypeDefOrRef> list2 = new List<ITypeDefOrRef>();
				if (lqG.HasThis && !lqG.ExplicitThis)
				{
					IType type = (((IType)item3.pqI).IsValueType ? moduleDef_0.Import(new ByRefSig(((ITypeDefOrRef)item3.pqI).ToTypeSig()).ToTypeDefOrRef()) : moduleDef_0.Import((IType)item3.pqI));
					list2.Add((ITypeDefOrRef)type);
				}
				foreach (TypeSig item4 in lqG.Params)
				{
					ITypeDefOrRef item = (ITypeDefOrRef)moduleDef_0.Import(item4.ToTypeDefOrRef());
					list2.Add(item);
				}
				gqq.ParamSigs = list2.ToArray();
				ITypeDefOrRef retType = (ITypeDefOrRef)moduleDef_0.Import(lqG.RetType.ToTypeDefOrRef());
				gqq.RetType = retType;
			}
		}

		private void lK0()
		{
			foreach (KeyValuePair<IMemberRef, uint> item in YKW.Descriptor.Data.EIJ)
			{
				item.Key.Rid = bKw.GetToken(item.Key).Rid;
			}
			foreach (wqe item2 in YKW.Descriptor.Data.QI8)
			{
				FuncSig gqq = item2.Gqq;
				ITypeDefOrRef[] paramSigs = gqq.ParamSigs;
				foreach (ITypeDefOrRef typeDefOrRef in paramSigs)
				{
					typeDefOrRef.Rid = bKw.GetToken(typeDefOrRef).Rid;
				}
				gqq.RetType.Rid = bKw.GetToken(gqq.RetType).Rid;
			}
		}
	}
}
