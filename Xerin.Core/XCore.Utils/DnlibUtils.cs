using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XCore.Utils
{
	public static class DnlibUtils
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class rJn
		{
			public static readonly rJn KJ3;

			public static Func<MethodDef, bool> kJ5;

			public static Func<MethodDef, bool> aJH;

			public static Func<MethodDef, bool> mJM;

			public static Func<MethodDef, bool> SJL;

			public static Func<Local, bool> fJV;

			public static Func<Parameter, int> MJW;

			public static Func<Parameter, Local> wJG;

			public static Func<Local, Local> OJ8;

			public static Func<Local, Local> sJZ;

			static rJn()
			{
				KJ3 = new rJn();
			}

			internal bool DJh(MethodDef methodDef_0)
			{
				return methodDef_0.IsPublic;
			}

			internal bool dJr(MethodDef methodDef_0)
			{
				return methodDef_0.IsPublic;
			}

			internal bool sJc(MethodDef methodDef_0)
			{
				return methodDef_0 != null;
			}

			internal bool eJw(MethodDef methodDef_0)
			{
				return methodDef_0 != null;
			}

			internal bool TJq(Local local_0)
			{
				return local_0.Type.IsPointer;
			}

			internal int FJy(Parameter parameter_0)
			{
				return parameter_0.Index;
			}

			internal Local UJb(Parameter parameter_0)
			{
				return new Local(parameter_0.Type);
			}

			internal Local jJk(Local local_0)
			{
				return local_0;
			}

			internal Local qJu(Local local_0)
			{
				return new Local(local_0.Type);
			}
		}

		[CompilerGenerated]
		private sealed class oJa
		{
			public string wJm;

			internal bool jJX(CustomAttribute customAttribute_0)
			{
				return customAttribute_0.TypeFullName == wJm;
			}
		}

		[CompilerGenerated]
		private sealed class VJA
		{
			public Dictionary<Instruction, Instruction> WJP;

			public Func<Instruction, Instruction> HJT;

			internal Instruction YJ9(Instruction instruction_0)
			{
				return WJP[instruction_0];
			}
		}

		public static bool CanObfuscate(IList<Instruction> ilist_0, int int_0)
		{
			try
			{
				if (ilist_0[int_0 + 1].GetOperand() != null && ilist_0[int_0 + 1].Operand.ToString().Contains("bool"))
				{
					return false;
				}
				if (ilist_0[int_0 + 1].GetOpCode() == dnlib.DotNet.Emit.OpCodes.Newobj)
				{
					return false;
				}
			}
			catch
			{
			}
			return true;
		}

		public static void excludeMethod(this MethodDef methodDef_0, ModuleDef moduleDef_0)
		{
			TypeRef typeRef = moduleDef_0.CorLibTypes.GetTypeRef("System", "ObsoleteAttribute");
			MemberRefUser ctor = new MemberRefUser(moduleDef_0, ".ctor", MethodSig.CreateInstance(moduleDef_0.CorLibTypes.Void, moduleDef_0.CorLibTypes.String), typeRef);
			CustomAttribute customAttribute = new CustomAttribute(ctor);
			customAttribute.ConstructorArguments.Add(new CAArgument(moduleDef_0.CorLibTypes.String, "Exclude"));
			methodDef_0.CustomAttributes.Add(customAttribute);
		}

		public static bool MethodHasL2FAttribute(this MethodDef methodDef_0)
		{
			foreach (CustomAttribute customAttribute in methodDef_0.CustomAttributes)
			{
				if (!(customAttribute.AttributeType.FullName == "System.ObsoleteAttribute"))
				{
					continue;
				}
				foreach (CAArgument constructorArgument in customAttribute.ConstructorArguments)
				{
					if (constructorArgument.Type.ElementType == ElementType.String && constructorArgument.Value.ToString() == "Exclude")
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool InheritsFrom(this TypeDef typeDef_0, string string_0)
		{
			if (typeDef_0.BaseType != null)
			{
				TypeDef typeDef = typeDef_0;
				do
				{
					typeDef = typeDef.BaseType.ResolveTypeDefThrow();
					if (typeDef.ReflectionFullName == string_0)
					{
						return true;
					}
				}
				while (typeDef.BaseType != null);
				return false;
			}
			return false;
		}

		public static bool InheritsFromCorlib(this TypeDef typeDef_0, string string_0)
		{
			if (typeDef_0.BaseType != null)
			{
				TypeDef typeDef = typeDef_0;
				do
				{
					typeDef = typeDef.BaseType.ResolveTypeDefThrow();
					if (typeDef.ReflectionFullName == string_0)
					{
						return true;
					}
				}
				while (typeDef.BaseType != null && typeDef.BaseType.DefinitionAssembly.IsCorLib());
				return false;
			}
			return false;
		}

		public static bool Implements(this TypeDef typeDef_0, string string_0)
		{
			foreach (InterfaceImpl @interface in typeDef_0.Interfaces)
			{
				if (@interface.Interface.ReflectionFullName == string_0)
				{
					return true;
				}
			}
			if (typeDef_0.BaseType == null)
			{
				return false;
			}
			return false;
		}

		public static bool IsPublic(this PropertyDef propertyDef_0)
		{
			return propertyDef_0.hUq().Any((MethodDef methodDef_0) => methodDef_0.IsPublic);
		}

		public static bool IsPublic(this EventDef eventDef_0)
		{
			return eventDef_0.kUw().Any((MethodDef methodDef_0) => methodDef_0.IsPublic);
		}

		private static IEnumerable<MethodDef> kUw(this EventDef eventDef_0)
		{
			return from methodDef_0 in new MethodDef[3] { eventDef_0.AddMethod, eventDef_0.RemoveMethod, eventDef_0.InvokeMethod }.Concat(eventDef_0.OtherMethods)
				where methodDef_0 != null
				select methodDef_0;
		}

		private static IEnumerable<MethodDef> hUq(this PropertyDef propertyDef_0)
		{
			return from methodDef_0 in new MethodDef[2] { propertyDef_0.GetMethod, propertyDef_0.SetMethod }.Concat(propertyDef_0.OtherMethods)
				where methodDef_0 != null
				select methodDef_0;
		}

		public static bool IsVisibleOutside(this TypeDef typeDef_0, bool bool_0 = true, bool bool_1 = true)
		{
			if (bool_0 && (typeDef_0.Module.Kind == ModuleKind.Windows || typeDef_0.Module.Kind == ModuleKind.Console))
			{
				return false;
			}
			if (typeDef_0.IsSerializable)
			{
				return true;
			}
			do
			{
				if (typeDef_0.DeclaringType != null)
				{
					if (bool_1)
					{
						if (!typeDef_0.IsNestedPublic && !typeDef_0.IsNestedFamily && !typeDef_0.IsNestedFamilyOrAssembly)
						{
							return false;
						}
					}
					else if ((typeDef_0.IsNotPublic || typeDef_0.IsNestedPrivate) && !typeDef_0.IsNestedPublic && !typeDef_0.IsNestedFamily && !typeDef_0.IsNestedFamilyOrAssembly)
					{
						return false;
					}
					typeDef_0 = typeDef_0.DeclaringType;
					continue;
				}
				return typeDef_0.IsPublic || !bool_1;
			}
			while (typeDef_0 != null);
			throw new Exception();
		}

		public static bool IsDelegate(this TypeDef typeDef_0)
		{
			if (typeDef_0.BaseType == null)
			{
				return false;
			}
			string fullName = typeDef_0.BaseType.FullName;
			return fullName == "System.Delegate" || fullName == "System.MulticastDelegate";
		}

		public static bool IsComImport(this TypeDef typeDef_0)
		{
			return typeDef_0.IsImport || typeDef_0.HasAttribute("System.Runtime.InteropServices.ComImportAttribute") || typeDef_0.HasAttribute("System.Runtime.InteropServices.TypeLibTypeAttribute");
		}

		public static bool HasAttribute(this IHasCustomAttribute ihasCustomAttribute_0, string string_0)
		{
			return ihasCustomAttribute_0.CustomAttributes.Any((CustomAttribute customAttribute_0) => customAttribute_0.TypeFullName == string_0);
		}

		public static byte[] GetILAsByteArray(this CilBody cilBody_0)
		{
			List<byte> list = new List<byte>();
			foreach (Instruction instruction in cilBody_0.Instructions)
			{
				byte[] bytes = BitConverter.GetBytes(instruction.GetOpCode().Value);
				byte[] array = bytes;
				byte[] array2 = array;
				foreach (byte item in array2)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}

		public static void EnsureNoInlining(MethodDef methodDef_0)
		{
			methodDef_0.ImplAttributes &= ~MethodImplAttributes.AggressiveInlining;
			methodDef_0.ImplAttributes |= MethodImplAttributes.NoInlining;
		}

		public static void HideMethods(MethodDef methodDef_0)
		{
			methodDef_0.Body.Instructions.Insert(1, new Instruction(dnlib.DotNet.Emit.OpCodes.Br_S, methodDef_0.Body.Instructions[1]));
			methodDef_0.Body.Instructions.Insert(2, new Instruction(dnlib.DotNet.Emit.OpCodes.Unaligned, 0));
		}

		public static void InsertInstructions(IList<Instruction> ilist_0, Dictionary<Instruction, int> dictionary_0)
		{
			foreach (KeyValuePair<Instruction, int> item in dictionary_0)
			{
				Instruction key = item.Key;
				int value = item.Value;
				ilist_0.Insert(value, key);
			}
		}

		public static MethodDef ResolveThrow(this IMethod imethod_0)
		{
			MethodDef methodDef = imethod_0 as MethodDef;
			if (methodDef != null)
			{
				return methodDef;
			}
			MethodSpec methodSpec = imethod_0 as MethodSpec;
			if (methodSpec != null)
			{
				return methodSpec.Method.ResolveThrow();
			}
			return ((MemberRef)imethod_0).ResolveMethodThrow();
		}

		public static bool hasExceptionHandlers(MethodDef methodDef_0)
		{
			if (methodDef_0.Body.HasExceptionHandlers)
			{
				return true;
			}
			return false;
		}

		public static bool HasUnsafeInstructions(MethodDef methodDef_0)
		{
			if (methodDef_0.HasBody && methodDef_0.Body.HasVariables)
			{
				return methodDef_0.Body.Variables.Any((Local local_0) => local_0.Type.IsPointer);
			}
			return false;
		}

		public static List<Instruction> Calc(int int_0)
		{
			List<Instruction> list = new List<Instruction>();
			Random random = new Random(Guid.NewGuid().GetHashCode());
			int num = random.Next(0, 100000);
			int num2 = random.Next(0, 100000);
			bool flag = Convert.ToBoolean(random.Next(0, 2));
			list.Add(Instruction.Create(dnlib.DotNet.Emit.OpCodes.Ldc_I4, int_0 - num + (flag ? (-num2) : num2)));
			list.Add(Instruction.Create(dnlib.DotNet.Emit.OpCodes.Ldc_I4, num));
			list.Add(Instruction.Create(dnlib.DotNet.Emit.OpCodes.Add));
			list.Add(Instruction.Create(dnlib.DotNet.Emit.OpCodes.Ldc_I4, num2));
			list.Add(Instruction.Create(flag ? dnlib.DotNet.Emit.OpCodes.Add : dnlib.DotNet.Emit.OpCodes.Sub));
			return list;
		}

		public static bool Simplify(MethodDef methodDef_0)
		{
			if (methodDef_0.Parameters == null)
			{
				return false;
			}
			methodDef_0.Body.SimplifyMacros(methodDef_0.Parameters);
			methodDef_0.Body.SimplifyBranches();
			return true;
		}

		public static bool Optimize(MethodDef methodDef_0)
		{
			if (methodDef_0.Body == null)
			{
				return false;
			}
			methodDef_0.Body.OptimizeMacros();
			methodDef_0.Body.OptimizeBranches();
			return true;
		}

		public static bool InGlobalModuleType(this MethodDef methodDef_0)
		{
			return methodDef_0.DeclaringType.IsGlobalModuleType || methodDef_0.DeclaringType2.IsGlobalModuleType || methodDef_0.FullName.Contains("My.");
		}

		public static bool InGlobalModuleType(this TypeDef typeDef_0)
		{
			return typeDef_0.IsGlobalModuleType || (typeDef_0.DeclaringType != null && typeDef_0.DeclaringType.IsGlobalModuleType) || (typeDef_0.DeclaringType2 != null && typeDef_0.DeclaringType2.IsGlobalModuleType);
		}

		public static void MergeCall(this CilBody cilBody_0, Instruction instruction_0)
		{
			MethodDef methodDef = instruction_0.Operand as MethodDef;
			if (methodDef != null)
			{
				if (methodDef.HasBody)
				{
					Dictionary<int, Local> dictionary = methodDef.Parameters.ToDictionary((Parameter parameter_0) => parameter_0.Index, (Parameter parameter_0) => new Local(parameter_0.Type));
					Dictionary<Local, Local> dictionary2 = methodDef.Body.Variables.ToDictionary((Local local_0) => local_0, (Local local_0) => new Local(local_0.Type));
					foreach (KeyValuePair<int, Local> item in dictionary)
					{
						cilBody_0.Variables.Add(item.Value);
					}
					foreach (KeyValuePair<Local, Local> item2 in dictionary2)
					{
						cilBody_0.Variables.Add(item2.Value);
					}
					int num = cilBody_0.Instructions.IndexOf(instruction_0) + 1;
					instruction_0.OpCode = dnlib.DotNet.Emit.OpCodes.Nop;
					instruction_0.Operand = null;
					Instruction operand = cilBody_0.Instructions[num];
					int num2 = 0;
					foreach (dnlib.DotNet.Emit.ExceptionHandler exceptionHandler in cilBody_0.ExceptionHandlers)
					{
						if (cilBody_0.Instructions.IndexOf(exceptionHandler.TryStart) < num)
						{
							num2 = cilBody_0.ExceptionHandlers.IndexOf(exceptionHandler);
						}
					}
					foreach (KeyValuePair<int, Local> item3 in dictionary.Reverse())
					{
						cilBody_0.Instructions.Insert(num++, new Instruction(dnlib.DotNet.Emit.OpCodes.Stloc, item3.Value));
					}
					Dictionary<Instruction, Instruction> WJP = new Dictionary<Instruction, Instruction>();
					List<Instruction> list = new List<Instruction>();
					foreach (Instruction instruction3 in methodDef.Body.Instructions)
					{
						Instruction instruction;
						if (instruction3.OpCode != dnlib.DotNet.Emit.OpCodes.Ret)
						{
							if (instruction3.IsLdarg())
							{
								Local value;
								dictionary.TryGetValue(instruction3.GetParameterIndex(), out value);
								instruction = new Instruction(dnlib.DotNet.Emit.OpCodes.Ldloc, value);
							}
							else if (!instruction3.IsStarg())
							{
								if (instruction3.IsLdloc())
								{
									Local value2;
									dictionary2.TryGetValue(instruction3.GetLocal(methodDef.Body.Variables), out value2);
									instruction = new Instruction(dnlib.DotNet.Emit.OpCodes.Ldloc, value2);
								}
								else if (instruction3.IsStloc())
								{
									Local value3;
									dictionary2.TryGetValue(instruction3.GetLocal(methodDef.Body.Variables), out value3);
									instruction = new Instruction(dnlib.DotNet.Emit.OpCodes.Stloc, value3);
								}
								else
								{
									instruction = new Instruction(instruction3.OpCode, instruction3.Operand);
								}
							}
							else
							{
								Local value4;
								dictionary.TryGetValue(instruction3.GetParameterIndex(), out value4);
								instruction = new Instruction(dnlib.DotNet.Emit.OpCodes.Stloc, value4);
							}
						}
						else
						{
							instruction = new Instruction(dnlib.DotNet.Emit.OpCodes.Br, operand);
						}
						list.Add(instruction);
						WJP[instruction3] = instruction;
					}
					using (List<Instruction>.Enumerator enumerator6 = list.GetEnumerator())
					{
						Instruction current6;
						for (; enumerator6.MoveNext(); cilBody_0.Instructions.Insert(num++, current6))
						{
							current6 = enumerator6.Current;
							if (current6.Operand != null)
							{
								Instruction instruction2 = current6.Operand as Instruction;
								if (instruction2 != null && WJP.ContainsKey(instruction2))
								{
									current6.Operand = WJP[instruction2];
									continue;
								}
							}
							Instruction[] array = current6.Operand as Instruction[];
							if (array != null)
							{
								current6.Operand = array.Select((Instruction key) => WJP[key]).ToArray();
							}
						}
					}
					{
						foreach (dnlib.DotNet.Emit.ExceptionHandler exceptionHandler2 in methodDef.Body.ExceptionHandlers)
						{
							cilBody_0.ExceptionHandlers.Insert(++num2, new dnlib.DotNet.Emit.ExceptionHandler(exceptionHandler2.HandlerType)
							{
								CatchType = exceptionHandler2.CatchType,
								TryStart = WJP[exceptionHandler2.TryStart],
								TryEnd = WJP[exceptionHandler2.TryEnd],
								HandlerStart = WJP[exceptionHandler2.HandlerStart],
								HandlerEnd = WJP[exceptionHandler2.HandlerEnd],
								FilterStart = ((exceptionHandler2.FilterStart == null) ? null : WJP[exceptionHandler2.FilterStart])
							});
						}
						return;
					}
				}
				throw new Exception("Method to merge has no body!");
			}
			throw new ArgumentException("Call instruction has invalid operand");
		}

		public static System.Reflection.Emit.OpCode ToReflectionOp(this dnlib.DotNet.Emit.OpCode opCode_0)
		{
			switch (opCode_0.Code)
			{
			case Code.Ldarg_0:
				return System.Reflection.Emit.OpCodes.Ldarg_0;
			case Code.Ldc_I4:
				return System.Reflection.Emit.OpCodes.Ldc_I4;
			case Code.Ret:
				return System.Reflection.Emit.OpCodes.Ret;
			case Code.Add:
				return System.Reflection.Emit.OpCodes.Add;
			case Code.Sub:
				return System.Reflection.Emit.OpCodes.Sub;
			case Code.Mul:
				return System.Reflection.Emit.OpCodes.Mul;
			default:
				throw new NotImplementedException();
			case Code.And:
				return System.Reflection.Emit.OpCodes.And;
			case Code.Or:
				return System.Reflection.Emit.OpCodes.Or;
			case Code.Xor:
				return System.Reflection.Emit.OpCodes.Xor;
			}
		}

		public static IEnumerable<IDnlibDef> FindDefinitions(this ModuleDef moduleDef_0)
		{
			yield return moduleDef_0;
			foreach (TypeDef type in moduleDef_0.GetTypes())
			{
				yield return type;
				foreach (MethodDef method in type.Methods)
				{
					yield return method;
				}
				foreach (FieldDef field in type.Fields)
				{
					yield return field;
				}
				foreach (PropertyDef property in type.Properties)
				{
					yield return property;
				}
				foreach (EventDef @event in type.Events)
				{
					yield return @event;
				}
			}
		}

		public static IEnumerable<IDnlibDef> FindDefinitions(this TypeDef typeDef_0)
		{
			yield return typeDef_0;
			foreach (TypeDef nestedType in typeDef_0.NestedTypes)
			{
				yield return nestedType;
			}
			foreach (MethodDef method in typeDef_0.Methods)
			{
				yield return method;
			}
			foreach (FieldDef field in typeDef_0.Fields)
			{
				yield return field;
			}
			foreach (PropertyDef property in typeDef_0.Properties)
			{
				yield return property;
			}
			foreach (EventDef @event in typeDef_0.Events)
			{
				yield return @event;
			}
		}

		public static bool IsTypePublic(this TypeDef typeDef_0)
		{
			do
			{
				if (typeDef_0.IsPublic || typeDef_0.IsNestedFamily || typeDef_0.IsNestedFamilyAndAssembly || typeDef_0.IsNestedFamilyOrAssembly || typeDef_0.IsNestedPublic || typeDef_0.IsPublic)
				{
					typeDef_0 = typeDef_0.DeclaringType;
					continue;
				}
				return false;
			}
			while (typeDef_0 != null);
			return true;
		}
	}
}
