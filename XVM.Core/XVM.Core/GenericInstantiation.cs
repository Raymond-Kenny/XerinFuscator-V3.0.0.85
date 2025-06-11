using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XVM.Core
{
	public class GenericInstantiation
	{
		private readonly Dictionary<MethodSpec, MethodDef> gIL = new Dictionary<MethodSpec, MethodDef>(MethodEqualityComparer.CompareDeclaringTypes);

		[CompilerGenerated]
		private Func<MethodSpec, bool> TIk;

		public event Func<MethodSpec, bool> ShouldInstantiate
		{
			[CompilerGenerated]
			add
			{
				Func<MethodSpec, bool> func = TIk;
				Func<MethodSpec, bool> func2;
				do
				{
					func2 = func;
					Func<MethodSpec, bool> value2 = (Func<MethodSpec, bool>)Delegate.Combine(func2, value);
					func = Interlocked.CompareExchange(ref TIk, value2, func2);
				}
				while ((object)func != func2);
			}
			[CompilerGenerated]
			remove
			{
				Func<MethodSpec, bool> func = TIk;
				Func<MethodSpec, bool> func2;
				do
				{
					func2 = func;
					Func<MethodSpec, bool> value2 = (Func<MethodSpec, bool>)Delegate.Remove(func2, value);
					func = Interlocked.CompareExchange(ref TIk, value2, func2);
				}
				while ((object)func != func2);
			}
		}

		public void EnsureInstantiation(MethodDef methodDef_0, Action<MethodSpec, MethodDef> action_0)
		{
			foreach (Instruction instruction in methodDef_0.Body.Instructions)
			{
				if (!(instruction.Operand is MethodSpec))
				{
					continue;
				}
				MethodSpec methodSpec = (MethodSpec)instruction.Operand;
				if (TIk == null || TIk(methodSpec))
				{
					if (!Instantiate(methodSpec, out var methodDef_1))
					{
						action_0(methodSpec, methodDef_1);
					}
					instruction.Operand = methodDef_1;
				}
			}
		}

		public bool Instantiate(MethodSpec methodSpec_0, out MethodDef methodDef_0)
		{
			if (gIL.TryGetValue(methodSpec_0, out methodDef_0))
			{
				return true;
			}
			GenericArguments genericArguments = new GenericArguments();
			genericArguments.PushMethodArgs(methodSpec_0.GenericInstMethodSig.GenericArguments);
			MethodDef methodDef = methodSpec_0.Method.ResolveMethodDefThrow();
			MethodSig methodSig = iIt(methodDef.MethodSig, genericArguments);
			methodSig.Generic = false;
			methodSig.GenParamCount = 0u;
			string text = methodDef.Name;
			foreach (TypeSig genericArgument in methodSpec_0.GenericInstMethodSig.GenericArguments)
			{
				text = text + ";" + genericArgument.TypeName;
			}
			methodDef_0 = new MethodDefUser(text, methodSig, methodDef.ImplAttributes, methodDef.Attributes);
			TypeSig typeSig = ((!methodDef.HasThis) ? null : methodDef.Parameters[0].Type);
			methodDef_0.DeclaringType2 = methodDef.DeclaringType2;
			if (typeSig != null)
			{
				methodDef_0.Parameters[0].Type = typeSig;
			}
			foreach (DeclSecurity declSecurity in methodDef.DeclSecurities)
			{
				methodDef_0.DeclSecurities.Add(declSecurity);
			}
			methodDef_0.ImplMap = methodDef.ImplMap;
			foreach (MethodOverride @override in methodDef.Overrides)
			{
				methodDef_0.Overrides.Add(@override);
			}
			methodDef_0.Body = new CilBody();
			methodDef_0.Body.InitLocals = methodDef.Body.InitLocals;
			methodDef_0.Body.MaxStack = methodDef.Body.MaxStack;
			foreach (Local variable in methodDef.Body.Variables)
			{
				Local local = new Local(variable.Type);
				methodDef_0.Body.Variables.Add(local);
			}
			Dictionary<Instruction, Instruction> dictionary = new Dictionary<Instruction, Instruction>();
			foreach (Instruction instruction2 in methodDef.Body.Instructions)
			{
				Instruction instruction = new Instruction(instruction2.OpCode, RIc(instruction2.Operand, genericArguments));
				methodDef_0.Body.Instructions.Add(instruction);
				dictionary[instruction2] = instruction;
			}
			foreach (Instruction instruction3 in methodDef_0.Body.Instructions)
			{
				if (!(instruction3.Operand is Instruction))
				{
					if (instruction3.Operand is Instruction[])
					{
						Instruction[] array = (Instruction[])((Instruction[])instruction3.Operand).Clone();
						for (int i = 0; i < array.Length; i++)
						{
							array[i] = dictionary[array[i]];
						}
						instruction3.Operand = array;
					}
				}
				else
				{
					instruction3.Operand = dictionary[(Instruction)instruction3.Operand];
				}
			}
			methodDef_0.Body.UpdateInstructionOffsets();
			foreach (ExceptionHandler exceptionHandler2 in methodDef.Body.ExceptionHandlers)
			{
				ExceptionHandler exceptionHandler = new ExceptionHandler(exceptionHandler2.HandlerType);
				exceptionHandler.TryStart = dictionary[exceptionHandler2.TryStart];
				exceptionHandler.HandlerStart = dictionary[exceptionHandler2.HandlerStart];
				if (exceptionHandler2.TryEnd != null)
				{
					exceptionHandler.TryEnd = dictionary[exceptionHandler2.TryEnd];
				}
				if (exceptionHandler2.HandlerEnd != null)
				{
					exceptionHandler.HandlerEnd = dictionary[exceptionHandler2.HandlerEnd];
				}
				if (exceptionHandler2.CatchType == null)
				{
					if (exceptionHandler2.FilterStart != null)
					{
						exceptionHandler.FilterStart = dictionary[exceptionHandler2.FilterStart];
					}
				}
				else
				{
					exceptionHandler.CatchType = genericArguments.Resolve(exceptionHandler.CatchType.ToTypeSig()).ToTypeDefOrRef();
				}
				methodDef_0.Body.ExceptionHandlers.Add(exceptionHandler);
			}
			gIL[methodSpec_0] = methodDef_0;
			return false;
		}

		private FieldSig yIj(FieldSig fieldSig_0, GenericArguments genericArguments_0)
		{
			FieldSig fieldSig = fieldSig_0.Clone();
			fieldSig.Type = genericArguments_0.ResolveType(fieldSig.Type);
			return fieldSig;
		}

		private GenericInstMethodSig QIO(GenericInstMethodSig genericInstMethodSig_0, GenericArguments genericArguments_0)
		{
			GenericInstMethodSig genericInstMethodSig = genericInstMethodSig_0.Clone();
			for (int i = 0; i < genericInstMethodSig.GenericArguments.Count; i++)
			{
				genericInstMethodSig.GenericArguments[i] = genericArguments_0.ResolveType(genericInstMethodSig.GenericArguments[i]);
			}
			return genericInstMethodSig;
		}

		private MethodSig iIt(MethodSig methodSig_0, GenericArguments genericArguments_0)
		{
			MethodSig methodSig = methodSig_0.Clone();
			for (int i = 0; i < methodSig.Params.Count; i++)
			{
				methodSig.Params[i] = genericArguments_0.ResolveType(methodSig.Params[i]);
			}
			if (methodSig.ParamsAfterSentinel != null)
			{
				for (int j = 0; j < methodSig.ParamsAfterSentinel.Count; j++)
				{
					methodSig.ParamsAfterSentinel[j] = genericArguments_0.ResolveType(methodSig.ParamsAfterSentinel[j]);
				}
			}
			methodSig.RetType = genericArguments_0.ResolveType(methodSig.RetType);
			return methodSig;
		}

		private object RIc(object object_0, GenericArguments genericArguments_0)
		{
			if (object_0 is MemberRef)
			{
				MemberRef memberRef = (MemberRef)object_0;
				if (memberRef.IsFieldRef)
				{
					FieldSig sig = yIj(memberRef.FieldSig, genericArguments_0);
					memberRef = new MemberRefUser(memberRef.Module, memberRef.Name, sig, memberRef.Class);
				}
				else
				{
					MethodSig sig2 = iIt(memberRef.MethodSig, genericArguments_0);
					memberRef = new MemberRefUser(memberRef.Module, memberRef.Name, sig2, memberRef.Class);
				}
				return memberRef;
			}
			if (object_0 is TypeSpec)
			{
				TypeSig typeSig = ((TypeSpec)object_0).TypeSig;
				return genericArguments_0.ResolveType(typeSig).ToTypeDefOrRef();
			}
			if (object_0 is MethodSpec)
			{
				MethodSpec methodSpec = (MethodSpec)object_0;
				return new MethodSpecUser(methodSpec.Method, QIO(methodSpec.GenericInstMethodSig, genericArguments_0));
			}
			return object_0;
		}
	}
}
