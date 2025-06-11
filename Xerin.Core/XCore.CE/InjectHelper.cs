using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XCore.CE
{
	public static class InjectHelper
	{
		private class l7G : ImportMapper
		{
			public readonly Dictionary<IMemberRef, IMemberRef> k7a = new Dictionary<IMemberRef, IMemberRef>();

			public readonly ModuleDef O7X;

			public readonly ModuleDef c7m;

			[CompilerGenerated]
			private readonly Importer D7A;

			public l7G(ModuleDef moduleDef_0, ModuleDef moduleDef_1)
			{
				O7X = moduleDef_0;
				c7m = moduleDef_1;
				D7A = new Importer(moduleDef_1, ImporterOptions.TryToUseTypeDefs, default(GenericParamContext), this);
			}

			[SpecialName]
			[CompilerGenerated]
			public Importer t78()
			{
				return D7A;
			}

			public override ITypeDefOrRef Map(ITypeDefOrRef source)
			{
				IMemberRef value;
				if (!k7a.TryGetValue(source, out value))
				{
					TypeRef typeRef = source as TypeRef;
					if (typeRef != null)
					{
						AssemblyRef assemblyRef = c7m.GetAssemblyRef(typeRef.DefinitionAssembly.Name);
						if (assemblyRef != null && !string.Equals(assemblyRef.FullName, source.DefinitionAssembly.FullName, StringComparison.Ordinal))
						{
							TypeRefUser type = new TypeRefUser(typeRef.Module, typeRef.Namespace, typeRef.Name, assemblyRef);
							return t78().Import(type);
						}
					}
					return null;
				}
				return value as ITypeDefOrRef;
			}

			public override IMethod Map(MethodDef source)
			{
				IMemberRef value;
				if (k7a.TryGetValue(source, out value))
				{
					return value as IMethod;
				}
				return null;
			}

			public override IField Map(FieldDef source)
			{
				IMemberRef value;
				if (!k7a.TryGetValue(source, out value))
				{
					return null;
				}
				return value as IField;
			}

			public override MemberRef Map(MemberRef source)
			{
				IMemberRef value;
				if (!k7a.TryGetValue(source, out value))
				{
					return null;
				}
				return value as MemberRef;
			}
		}

		[CompilerGenerated]
		private sealed class Q79
		{
			public Dictionary<object, object> b7f;

			public Func<Instruction, Instruction> J7T;

			internal Instruction o7P(Instruction instruction_0)
			{
				return (Instruction)b7f[instruction_0];
			}
		}

		private static TypeDefUser BQb(TypeDef typeDef_0)
		{
			TypeDefUser typeDefUser = new TypeDefUser(typeDef_0.Namespace, typeDef_0.Name);
			typeDefUser.Attributes = typeDef_0.Attributes;
			if (typeDef_0.ClassLayout != null)
			{
				typeDefUser.ClassLayout = new ClassLayoutUser(typeDef_0.ClassLayout.PackingSize, typeDef_0.ClassSize);
			}
			foreach (GenericParam genericParameter in typeDef_0.GenericParameters)
			{
				typeDefUser.GenericParameters.Add(new GenericParamUser(genericParameter.Number, genericParameter.Flags, "-"));
			}
			return typeDefUser;
		}

		private static MethodDefUser CQk(MethodDef methodDef_0)
		{
			MethodDefUser methodDefUser = new MethodDefUser(methodDef_0.Name, null, methodDef_0.ImplAttributes, methodDef_0.Attributes);
			foreach (GenericParam genericParameter in methodDef_0.GenericParameters)
			{
				methodDefUser.GenericParameters.Add(new GenericParamUser(genericParameter.Number, genericParameter.Flags, "-"));
			}
			return methodDefUser;
		}

		private static FieldDefUser mQu(FieldDef fieldDef_0)
		{
			return new FieldDefUser(fieldDef_0.Name, null, fieldDef_0.Attributes);
		}

		private static TypeDef jQ3(object object_0, object object_1)
		{
			TypeDef typeDef = ((ImportMapper)object_1).Map((ITypeDefOrRef)object_0)?.ResolveTypeDef();
			if (typeDef == null)
			{
				typeDef = BQb((TypeDef)object_0);
				((l7G)object_1).k7a[(IMemberRef)object_0] = typeDef;
			}
			foreach (TypeDef nestedType in ((TypeDef)object_0).NestedTypes)
			{
				typeDef.NestedTypes.Add(jQ3(nestedType, object_1));
			}
			foreach (MethodDef method in ((TypeDef)object_0).Methods)
			{
				IList<MethodDef> methods = typeDef.Methods;
				IMemberRef memberRef = (((l7G)object_1).k7a[method] = CQk(method));
				methods.Add((MethodDef)memberRef);
			}
			foreach (FieldDef field in ((TypeDef)object_0).Fields)
			{
				IList<FieldDef> fields = typeDef.Fields;
				IMemberRef memberRef = (((l7G)object_1).k7a[field] = mQu(field));
				fields.Add((FieldDef)memberRef);
			}
			return typeDef;
		}

		private static void qQ5(object object_0, object object_1)
		{
			TypeDef typeDef = ((ImportMapper)object_1).Map((ITypeDefOrRef)object_0)?.ResolveTypeDefThrow();
			typeDef.BaseType = ((l7G)object_1).t78().Import(((TypeDef)object_0).BaseType);
			foreach (InterfaceImpl @interface in ((TypeDef)object_0).Interfaces)
			{
				typeDef.Interfaces.Add(new InterfaceImplUser(((l7G)object_1).t78().Import(@interface.Interface)));
			}
		}

		private static void nQH(MethodDef methodDef_0, object object_0)
		{
			MethodDef methodDef = ((ImportMapper)object_0).Map(methodDef_0)?.ResolveMethodDefThrow();
			methodDef.Signature = ((l7G)object_0).t78().Import(methodDef_0.Signature);
			methodDef.Parameters.UpdateParameterTypes();
			foreach (ParamDef paramDef in methodDef_0.ParamDefs)
			{
				methodDef.ParamDefs.Add(new ParamDefUser(paramDef.Name, paramDef.Sequence, paramDef.Attributes));
			}
			if (methodDef_0.ImplMap != null)
			{
				methodDef.ImplMap = new ImplMapUser(new ModuleRefUser(((l7G)object_0).c7m, methodDef_0.ImplMap.Module.Name), methodDef_0.ImplMap.Name, methodDef_0.ImplMap.Attributes);
			}
			foreach (CustomAttribute customAttribute in methodDef_0.CustomAttributes)
			{
				methodDef.CustomAttributes.Add(new CustomAttribute((ICustomAttributeType)((l7G)object_0).t78().Import(customAttribute.Constructor)));
			}
			if (methodDef_0.HasBody)
			{
				gQM(methodDef_0, (l7G)object_0, methodDef);
			}
		}

		private static void gQM(MethodDef methodDef_0, l7G l7G_0, MethodDef methodDef_1)
		{
			methodDef_1.Body = new CilBody(methodDef_0.Body.InitLocals, new List<Instruction>(), new List<ExceptionHandler>(), new List<Local>())
			{
				MaxStack = methodDef_0.Body.MaxStack
			};
			Dictionary<object, object> b7f = new Dictionary<object, object>();
			foreach (Local variable in methodDef_0.Body.Variables)
			{
				Local local = new Local(l7G_0.t78().Import(variable.Type));
				methodDef_1.Body.Variables.Add(local);
				local.Name = variable.Name;
				b7f[variable] = local;
			}
			foreach (Instruction instruction2 in methodDef_0.Body.Instructions)
			{
				Instruction instruction = new Instruction(instruction2.OpCode, instruction2.Operand)
				{
					SequencePoint = instruction2.SequencePoint
				};
				object operand = instruction.Operand;
				object obj = operand;
				IType type = obj as IType;
				if (type == null)
				{
					IMethod method = obj as IMethod;
					if (method != null)
					{
						instruction.Operand = l7G_0.t78().Import(method);
					}
					else
					{
						IField field = obj as IField;
						if (field != null)
						{
							instruction.Operand = l7G_0.t78().Import(field);
						}
					}
				}
				else
				{
					instruction.Operand = l7G_0.t78().Import(type);
				}
				methodDef_1.Body.Instructions.Add(instruction);
				b7f[instruction2] = instruction;
			}
			foreach (Instruction instruction3 in methodDef_1.Body.Instructions)
			{
				if (instruction3.Operand == null || !b7f.ContainsKey(instruction3.Operand))
				{
					Instruction[] array = instruction3.Operand as Instruction[];
					if (array != null)
					{
						instruction3.Operand = array.Select((Instruction instruction_0) => (Instruction)b7f[instruction_0]).ToArray();
					}
				}
				else
				{
					instruction3.Operand = b7f[instruction3.Operand];
				}
			}
			foreach (ExceptionHandler exceptionHandler in methodDef_0.Body.ExceptionHandlers)
			{
				methodDef_1.Body.ExceptionHandlers.Add(new ExceptionHandler(exceptionHandler.HandlerType)
				{
					CatchType = ((exceptionHandler.CatchType == null) ? null : l7G_0.t78().Import(exceptionHandler.CatchType)),
					TryStart = (Instruction)b7f[exceptionHandler.TryStart],
					TryEnd = (Instruction)b7f[exceptionHandler.TryEnd],
					HandlerStart = (Instruction)b7f[exceptionHandler.HandlerStart],
					HandlerEnd = (Instruction)b7f[exceptionHandler.HandlerEnd],
					FilterStart = ((exceptionHandler.FilterStart == null) ? null : ((Instruction)b7f[exceptionHandler.FilterStart]))
				});
			}
			methodDef_1.Body.SimplifyMacros(methodDef_1.Parameters);
		}

		private static void YQL(FieldDef fieldDef_0, object object_0)
		{
			FieldDef fieldDef = ((ImportMapper)object_0).Map(fieldDef_0).ResolveFieldDefThrow();
			fieldDef.Signature = ((l7G)object_0).t78().Import(fieldDef_0.Signature);
		}

		private static void lQV(TypeDef typeDef_0, object object_0, bool bool_0)
		{
			if (bool_0)
			{
				qQ5(typeDef_0, object_0);
			}
			foreach (TypeDef nestedType in typeDef_0.NestedTypes)
			{
				lQV(nestedType, object_0, true);
			}
			foreach (MethodDef method in typeDef_0.Methods)
			{
				nQH(method, object_0);
			}
			foreach (FieldDef field in typeDef_0.Fields)
			{
				YQL(field, object_0);
			}
		}

		public static TypeDef Inject(TypeDef typeDef_0, ModuleDef moduleDef_0)
		{
			l7G l7G = new l7G(typeDef_0.Module, moduleDef_0);
			TypeDef result = jQ3(typeDef_0, l7G);
			lQV(typeDef_0, l7G, true);
			return result;
		}

		public static MethodDef Inject(MethodDef methodDef_0, ModuleDef moduleDef_0)
		{
			l7G l7G = new l7G(methodDef_0.Module, moduleDef_0);
			MethodDef result = (MethodDef)(l7G.k7a[methodDef_0] = CQk(methodDef_0));
			nQH(methodDef_0, l7G);
			return result;
		}

		public static IEnumerable<IDnlibDef> Inject(TypeDef typeDef_0, TypeDef typeDef_1, ModuleDef moduleDef_0)
		{
			l7G l7G = new l7G(typeDef_0.Module, moduleDef_0);
			l7G.k7a[typeDef_0] = typeDef_1;
			jQ3(typeDef_0, l7G);
			lQV(typeDef_0, l7G, false);
			return l7G.k7a.Values.Except(new TypeDef[1] { typeDef_1 }).OfType<IDnlibDef>();
		}
	}
}
