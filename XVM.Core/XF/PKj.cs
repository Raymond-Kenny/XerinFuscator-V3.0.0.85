using System;
using System.Collections.Generic;
using System.Reflection;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.RT;

namespace XF
{
	internal class PKj : IDisposable
	{
		public object KKc = ModuleDefMD.Load(typeof(Module).Module);

		private VMRuntime tKL;

		private ModuleDef VKk;

		public TypeDef QKH;

		public TypeDef EKC;

		public MethodDef SKm;

		public MethodDef TK5;

		public TypeDef HKo;

		public MethodDef DKl;

		public MethodDef yKZ;

		public TypeDef eKT;

		public MethodDef kKS;

		public FieldDef oKa;

		public TypeDef KKU;

		public MethodDef tKh;

		public MethodDef nKP;

		public TypeDef DKF;

		public MethodDef NKv;

		public TypeDef TKd;

		public MethodDef PKB;

		public TypeDef OK7;

		public MethodDef EKD;

		public TypeDef lKy;

		public MethodDef GKY;

		public MethodDef VKg;

		public List<object> IKV = JKb;

		public static List<object> JKb;

		public TypeDef WKp;

		public MethodDef xKr;

		public PKj(ModuleDef moduleDef_0, VMRuntime vmruntime_0)
		{
			VKk = moduleDef_0;
			tKL = vmruntime_0;
		}

		public PKj dKO()
		{
			QKH = ((ModuleDef)KKc).Find(TNd.rNB, isReflectionName: true);
			EKC = ((ModuleDef)KKc).Find(TNd.qN7, isReflectionName: true);
			TK5 = EKC.FindMethod(TNd.rNy);
			foreach (MethodDef item in EKC.FindMethods(TNd.MND))
			{
				if (item.Parameters.Count == 1)
				{
					SKm = item;
				}
			}
			HKo = VKk.Find(TNd.ONY, isReflectionName: true);
			DKl = HKo.FindMethod(TNd.nNV);
			yKZ = HKo.FindMethod(TNd.ONb);
			eKT = VKk.Find(TNd.BNX, isReflectionName: true);
			kKS = eKT.FindMethod(TNd.LNn);
			oKa = eKT.FindField(TNd.FN6);
			lKy = VKk.Find(TNd.vNp, isReflectionName: true);
			VKg = lKy.FindMethod(TNd.mNr);
			foreach (MethodDef item2 in lKy.FindMethods(TNd.Y2R))
			{
				GKY = item2;
			}
			RKt(VKk, eKT, kKS, oKa);
			DKF = VKk.Find(TNd.PNi, isReflectionName: true);
			foreach (MethodDef item3 in DKF.FindMethods(TNd.Y2R))
			{
				NKv = item3;
			}
			TKd = VKk.Find(TNd.yNs, isReflectionName: true);
			foreach (MethodDef item4 in TKd.FindMethods(TNd.Y2R))
			{
				PKB = item4;
			}
			OK7 = VKk.Find(TNd.ENJ, isReflectionName: true);
			foreach (MethodDef item5 in OK7.FindMethods(TNd.Y2R))
			{
				EKD = item5;
			}
			KKU = VKk.Find(TNd.HNQ, isReflectionName: true);
			nKP = KKU.FindMethod(TNd.wNf);
			foreach (MethodDef item6 in KKU.FindMethods(TNd.Y2R))
			{
				tKh = item6;
			}
			WKp = VKk.Find(TNd.t2e, isReflectionName: true);
			xKr = WKp.FindMethod(TNd.i2u);
			return this;
		}

		private static void RKt(ModuleDef moduleDef_0, object object_0, object object_1, IField ifield_0)
		{
			if (JKb == null || JKb.Count == 0)
			{
				JKb = new List<object>();
				TypeDefUser typeDefUser = new TypeDefUser(UTF8String.Empty, "proxy_delegate_", moduleDef_0.CorLibTypes.GetTypeRef("System", "MulticastDelegate"))
				{
					Attributes = (dnlib.DotNet.TypeAttributes.Public | dnlib.DotNet.TypeAttributes.Sealed)
				};
				MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(moduleDef_0.CorLibTypes.Void, moduleDef_0.CorLibTypes.Object, moduleDef_0.CorLibTypes.IntPtr))
				{
					Attributes = (dnlib.DotNet.MethodAttributes.Public | dnlib.DotNet.MethodAttributes.HideBySig | dnlib.DotNet.MethodAttributes.SpecialName | dnlib.DotNet.MethodAttributes.RTSpecialName),
					ImplAttributes = dnlib.DotNet.MethodImplAttributes.CodeTypeMask
				};
				typeDefUser.Methods.Add(methodDefUser);
				MethodDefUser item = new MethodDefUser("Invoke", ((MethodDef)object_1).MethodSig.Clone())
				{
					MethodSig = 
					{
						HasThis = true
					},
					Attributes = (dnlib.DotNet.MethodAttributes.Public | dnlib.DotNet.MethodAttributes.Virtual | dnlib.DotNet.MethodAttributes.HideBySig | dnlib.DotNet.MethodAttributes.VtableLayoutMask),
					ImplAttributes = dnlib.DotNet.MethodImplAttributes.CodeTypeMask
				};
				typeDefUser.Methods.Add(item);
				FieldDefUser fieldDefUser = new FieldDefUser("proxy_delegate_field", new FieldSig(typeDefUser.ToTypeSig()), dnlib.DotNet.FieldAttributes.Public | dnlib.DotNet.FieldAttributes.Static);
				typeDefUser.Fields.Add(fieldDefUser);
				moduleDef_0.Types.Add(typeDefUser);
				MethodDef methodDef = typeDefUser.FindOrCreateStaticConstructor();
				methodDef.Body = new CilBody();
				methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldsfld, fieldDefUser));
				methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldsfld, ifield_0));
				methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldftn, (IMethod)object_1));
				methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Newobj, methodDefUser));
				methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Stsfld, fieldDefUser));
				methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
				methodDef.Body.Instructions.Insert(methodDef.Body.Instructions.Count - 5, OpCodes.Brtrue_S.ToInstruction(methodDef.Body.Instructions[methodDef.Body.Instructions.Count - 1]));
				JKb.Add(typeDefUser);
				JKb.Add(methodDefUser);
				JKb.Add(methodDef);
				JKb.Add(item);
				JKb.Add(fieldDefUser);
			}
		}

		public void Dispose()
		{
			((ModuleDef)KKc).Dispose();
			IKV.Clear();
			JKb.Clear();
		}
	}
}
