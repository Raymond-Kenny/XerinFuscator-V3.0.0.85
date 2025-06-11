#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using XCore.Generator;

namespace XF
{
	internal abstract class Y2q
	{
		[CompilerGenerated]
		private sealed class vws
		{
			public x29 Fwp;

			public IMethod MwX;

			public ModuleDef Mwy;

			internal TypeSig CwY(TypeSig typeSig_0)
			{
				if (!Fwp.M26 || !typeSig_0.IsClassSig || !MwX.MethodSig.HasThis)
				{
					return typeSig_0;
				}
				return Mwy.CorLibTypes.Object;
			}

			internal TypeSig LwB(TypeSig typeSig_0)
			{
				if (Fwp.M26 && typeSig_0.IsClassSig && MwX.MethodSig.HasThis)
				{
					return Mwy.CorLibTypes.Object;
				}
				return typeSig_0;
			}
		}

		public abstract void TPk(x29 x29_0, int int_0);

		public abstract void Finalize(x29 x29_0);

		private static ITypeDefOrRef E2A(ModuleDef moduleDef_0, TypeDef typeDef_0)
		{
			return new Importer(((x29)(object)moduleDef_0).u2Q, ImporterOptions.TryToUseTypeDefs).Import(typeDef_0);
		}

		protected static MethodSig q2l(x29 x29_0, IMethod imethod_0, bool bool_0)
		{
			ModuleDef Mwy = x29_0.u2Q;
			if (!bool_0)
			{
				IEnumerable<TypeSig> enumerable = imethod_0.MethodSig.Params.Select((TypeSig typeSig_0) => (x29_0.M26 && typeSig_0.IsClassSig && imethod_0.MethodSig.HasThis) ? Mwy.CorLibTypes.Object : typeSig_0);
				if (imethod_0.MethodSig.HasThis && !imethod_0.MethodSig.ExplicitThis)
				{
					TypeDef typeDef = imethod_0.DeclaringType.ResolveTypeDefThrow();
					enumerable = ((x29_0.M26 && !typeDef.IsValueType) ? new CorLibTypeSig[1] { Mwy.CorLibTypes.Object }.Concat(enumerable) : new TypeSig[1] { E2A((ModuleDef)(object)x29_0, typeDef).ToTypeSig() }.Concat(enumerable));
				}
				TypeSig typeSig = imethod_0.MethodSig.RetType;
				if (x29_0.M26 && typeSig.IsClassSig)
				{
					typeSig = Mwy.CorLibTypes.Object;
				}
				return MethodSig.CreateStatic(typeSig, enumerable.ToArray());
			}
			Debug.Assert(imethod_0.MethodSig.HasThis);
			Debug.Assert(imethod_0.Name == ".ctor");
			TypeSig[] argTypes = imethod_0.MethodSig.Params.Select((TypeSig typeSig_0) => (!x29_0.M26 || !typeSig_0.IsClassSig || !imethod_0.MethodSig.HasThis) ? typeSig_0 : Mwy.CorLibTypes.Object).ToArray();
			TypeSig retType;
			if (x29_0.M26)
			{
				retType = Mwy.CorLibTypes.Object;
			}
			else
			{
				TypeDef typeDef_ = imethod_0.DeclaringType.ResolveTypeDefThrow();
				retType = E2A((ModuleDef)(object)x29_0, typeDef_).ToTypeSig();
			}
			return MethodSig.CreateStatic(retType, argTypes);
		}

		protected static TypeDef U2I(object object_0, MethodSig methodSig_0)
		{
			if (((x29)object_0).t2L.TryGetValue(methodSig_0, out var value))
			{
				return value;
			}
			value = new TypeDefUser(GGeneration.GenerateGuidStartingWithLetter(), GGeneration.GenerateGuidStartingWithLetter(), ((x29)object_0).u2Q.CorLibTypes.GetTypeRef("System", "MulticastDelegate"))
			{
				Attributes = (TypeAttributes.Public | TypeAttributes.Sealed)
			};
			MethodDefUser item = new MethodDefUser(".ctor", MethodSig.CreateInstance(((x29)object_0).u2Q.CorLibTypes.Void, ((x29)object_0).u2Q.CorLibTypes.Object, ((x29)object_0).u2Q.CorLibTypes.IntPtr))
			{
				Attributes = (MethodAttributes.MemberAccessMask | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName),
				ImplAttributes = MethodImplAttributes.CodeTypeMask
			};
			value.Methods.Add(item);
			MethodDefUser methodDefUser = new MethodDefUser("Invoke", methodSig_0.Clone());
			methodDefUser.MethodSig.HasThis = true;
			methodDefUser.Attributes = MethodAttributes.Assembly | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.VtableLayoutMask;
			methodDefUser.ImplAttributes = MethodImplAttributes.CodeTypeMask;
			value.Methods.Add(methodDefUser);
			((x29)object_0).u2Q.Types.Add(value);
			((x29)object_0).t2L[methodSig_0] = value;
			return value;
		}
	}
}
