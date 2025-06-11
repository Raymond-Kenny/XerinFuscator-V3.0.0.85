using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Generator;
using XCore.Utils;

namespace XF
{
	internal class jd : Y2q
	{
		private readonly Dictionary<Tuple<Code, TypeDef, IMethod>, MethodDef> H3 = new Dictionary<Tuple<Code, TypeDef, IMethod>, MethodDef>();

		private readonly Random KM = new Random();

		public override void TPk(x29 x29_0, int int_0)
		{
			Instruction instruction = x29_0.L2w.Instructions[int_0];
			IMethod method = (IMethod)instruction.Operand;
			if (method.DeclaringType.ResolveTypeDefThrow().IsValueType || (!method.ResolveThrow().IsPublic && !method.ResolveThrow().IsAssembly))
			{
				return;
			}
			Tuple<Code, TypeDef, IMethod> key = Tuple.Create(instruction.OpCode.Code, x29_0.K2k.DeclaringType, method);
			if (!H3.TryGetValue(key, out var value))
			{
				MethodSig methodSig = Y2q.q2l(x29_0, method, instruction.OpCode.Code == Code.Newobj);
				string text = GGeneration.GenerateGuidStartingWithLetter();
				value = new MethodDefUser(text, methodSig)
				{
					Attributes = (MethodAttributes.Public | MethodAttributes.Static),
					ImplAttributes = MethodImplAttributes.IL,
					DeclaringType = null
				};
				x29_0.K2k.DeclaringType.Methods.Add(value);
				if (instruction.OpCode.Code == Code.Call && method.ResolveThrow().IsVirtual)
				{
					value.IsStatic = false;
					methodSig.HasThis = true;
					methodSig.Params.RemoveAt(0);
				}
				value.Body = new CilBody();
				for (int i = 0; i < value.Parameters.Count; i++)
				{
					value.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg, value.Parameters[i]));
				}
				Local local = new Local(x29_0.u2Q.CorLibTypes.Int32);
				value.Body.Variables.Add(local);
				value.Body.Instructions.Add(Instruction.Create(OpCodes.Ldc_I4, KM.Next()));
				value.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
				value.Body.Instructions.Add(Instruction.Create(instruction.OpCode, method));
				if (value.ReturnType.ToString().ToLower().Contains("void"))
				{
					value.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
					value.Body.Instructions.Add(Instruction.Create(OpCodes.Pop));
				}
				else
				{
					Local local2 = new Local(value.ReturnType);
					value.Body.Variables.Add(local2);
					value.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local2));
					value.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
					value.Body.Instructions.Add(Instruction.Create(OpCodes.Pop));
					value.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local2));
				}
				value.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
				H3[key] = value;
			}
			instruction.OpCode = OpCodes.Call;
			if (x29_0.K2k.DeclaringType.HasGenericParameters)
			{
				GenericVar[] array = new GenericVar[x29_0.K2k.DeclaringType.GenericParameters.Count];
				for (int k = 0; k < array.Length; k++)
				{
					array[k] = new GenericVar(k);
				}
				ModuleDef u2Q = x29_0.u2Q;
				UTF8String name = value.Name;
				MethodSig methodSig2 = value.MethodSig;
				ClassOrValueTypeSig genericType = (ClassOrValueTypeSig)x29_0.K2k.DeclaringType.ToTypeSig();
				TypeSig[] genArgs = array;
				instruction.Operand = new MemberRefUser(u2Q, name, methodSig2, new GenericInstSig(genericType, genArgs).ToTypeDefOrRef());
			}
			else
			{
				instruction.Operand = value;
			}
			MethodDef methodDef = method.ResolveMethodDef();
			if (methodDef != null)
			{
				x29_0.B2m.Annotations.Set(methodDef, methodDef, methodDef);
			}
		}

		public override void Finalize(x29 x29_0)
		{
		}
	}
}
