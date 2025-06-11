using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Confuser.DynCipher;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Context;
using XCore.Generator;
using XCore.Protections;
using XCore.Utils;
using XF;

namespace Confuser.Protections.ReferenceProxy
{
	public class ReferenceProxyPhase : Protection
	{
		private class VwP
		{
			private class Lha : IEqualityComparer<MethodSig>
			{
				public bool Equals(MethodSig x, MethodSig y)
				{
					return default(SigComparer).Equals(x, y);
				}

				public int GetHashCode(MethodSig obj)
				{
					return default(SigComparer).GetHashCode(obj);
				}
			}

			public readonly Dictionary<MethodSig, TypeDef> wwU = new Dictionary<MethodSig, TypeDef>(new Lha());

			public QS Awk;

			public jd fwa;

			public Be Vw0;

			public RandomGenerator HwQ;

			public hV swr;
		}

		[Serializable]
		[CompilerGenerated]
		private sealed class ow6
		{
			public static readonly ow6 kwF;

			public static Func<Instruction, Instruction> JwD;

			public static Func<Instruction, bool> Dwv;

			public static Func<Instruction, IEnumerable<Instruction>> dwO;

			public static Func<Instruction, bool> Cwu;

			public static Func<TypeDef, bool> QwV;

			public static Func<MethodDef, bool> Vw4;

			static ow6()
			{
				kwF = new ow6();
			}

			internal Instruction zwq(Instruction instruction_0)
			{
				return instruction_0.Operand as Instruction;
			}

			internal bool AwA(Instruction instruction_0)
			{
				return instruction_0.Operand is Instruction[];
			}

			internal IEnumerable<Instruction> vwl(Instruction instruction_0)
			{
				return (Instruction[])instruction_0.Operand;
			}

			internal bool EwI(Instruction instruction_0)
			{
				return instruction_0 != null;
			}

			internal bool QwT(TypeDef typeDef_0)
			{
				return typeDef_0.HasMethods && !typeDef_0.IsGlobalModuleType && typeDef_0.Namespace != "Costura";
			}

			internal bool jwZ(MethodDef methodDef_0)
			{
				return methodDef_0.HasBody && methodDef_0.Body.HasInstructions;
			}
		}

		public static bool isDelegate;

		public override string name => "Mild Reference Proxy";

		public override int number => 6;

		private static x29 cz(MethodDef methodDef_0, XContext xcontext_0, object object_0)
		{
			x29 x = new x29
			{
				M2a = (q28)0,
				E25 = (q28)1,
				g2U = true,
				M26 = true,
				L27 = 0,
				u2Q = methodDef_0.Module,
				K2k = methodDef_0,
				L2w = methodDef_0.Body,
				m2R = new HashSet<Instruction>(from instruction_0 in methodDef_0.Body.Instructions.Select((Instruction instruction_0) => instruction_0.Operand as Instruction).Concat(methodDef_0.Body.Instructions.Where((Instruction instruction_0) => instruction_0.Operand is Instruction[]).SelectMany((Instruction instruction_0) => (Instruction[])instruction_0.Operand))
					where instruction_0 != null
					select instruction_0),
				d2r = ((VwP)object_0).HwQ,
				B2m = xcontext_0,
				O2h = xcontext_0.Registry.GetService<IDynCipherService>(),
				t2L = ((VwP)object_0).wwU
			};
			if (isDelegate)
			{
				x.M2a = (q28)1;
			}
			switch (x.M2a)
			{
			default:
				throw new Exception();
			case (q28)1:
				x.X20 = ((VwP)object_0).swr ?? (((VwP)object_0).swr = new hV());
				break;
			case (q28)0:
				x.X20 = ((VwP)object_0).fwa ?? (((VwP)object_0).fwa = new jd());
				break;
			}
			switch (x.E25)
			{
			default:
				throw new Exception();
			case (q28)1:
				x.r2N = ((VwP)object_0).Awk ?? (((VwP)object_0).Awk = new QS());
				break;
			case (q28)0:
				x.r2N = ((VwP)object_0).Vw0 ?? (((VwP)object_0).Vw0 = new Be());
				break;
			}
			return x;
		}

		private static x29 B2c(ModuleDef moduleDef_0, XContext xcontext_0, object object_0)
		{
			return new x29
			{
				L27 = 0,
				A2P = 1,
				d2r = ((VwP)object_0).HwQ,
				u2Q = moduleDef_0,
				B2m = xcontext_0,
				O2h = xcontext_0.Registry.GetService<IDynCipherService>(),
				t2L = ((VwP)object_0).wwU
			};
		}

		public override void Execute(XContext xcontext_0)
		{
			RandomGenerator hwQ = new RandomGenerator(GGeneration.GenerateGuidStartingWithLetter(), GGeneration.GenerateGuidStartingWithLetter());
			VwP vwP = new VwP
			{
				HwQ = hwQ
			};
			foreach (TypeDef item in from typeDef_0 in xcontext_0.Module.GetTypes().ToArray()
				where typeDef_0.HasMethods && !typeDef_0.IsGlobalModuleType && typeDef_0.Namespace != "Costura"
				select typeDef_0)
			{
				foreach (MethodDef item2 in from methodDef_0 in item.Methods.ToArray()
					where methodDef_0.HasBody && methodDef_0.Body.HasInstructions
					select methodDef_0)
				{
					if (item2.HasBody && item2.Body.Instructions.Count > 0)
					{
						X22(cz(item2, xcontext_0, vwP));
					}
				}
			}
			x29 x29_ = B2c(xcontext_0.Module, xcontext_0, vwP);
			vwP.fwa?.Finalize(x29_);
			vwP.swr?.Finalize(x29_);
		}

		private void X22(x29 x29_0)
		{
			if (x29_0.K2k == null || x29_0.K2k.MethodHasL2FAttribute())
			{
				return;
			}
			for (int i = 0; i < x29_0.L2w.Instructions.Count; i++)
			{
				Instruction instruction = x29_0.L2w.Instructions[i];
				if (instruction.OpCode.Code != Code.Call && instruction.OpCode.Code != Code.Callvirt && instruction.OpCode.Code != Code.Newobj)
				{
					continue;
				}
				IMethod method = (IMethod)instruction.Operand;
				MethodDef methodDef = method.ResolveMethodDef();
				if (methodDef == null)
				{
					break;
				}
				if ((instruction.OpCode.Code == Code.Newobj || !(method.Name == ".ctor")) && (!(method is MethodDef) || x29_0.g2U) && !(method is MethodSpec) && !(method.DeclaringType is TypeSpec) && (method.MethodSig.ParamsAfterSentinel == null || method.MethodSig.ParamsAfterSentinel.Count <= 0))
				{
					TypeDef typeDef = method.DeclaringType.ResolveTypeDefThrow();
					if (!typeDef.IsDelegate() && (!typeDef.IsValueType || !method.MethodSig.HasThis) && (i - 1 < 0 || x29_0.L2w.Instructions[i - 1].OpCode.OpCodeType != OpCodeType.Prefix))
					{
						((Y2q)x29_0.X20).TPk(x29_0, i);
					}
				}
			}
		}
	}
}
