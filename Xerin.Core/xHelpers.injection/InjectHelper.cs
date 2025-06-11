using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace xHelpers.injection
{
	public static class InjectHelper
	{
		private class iei : ImportMapper
		{
			public readonly Dictionary<IDnlibDef, IDnlibDef> NeO = new Dictionary<IDnlibDef, IDnlibDef>();

			public readonly ModuleDef YeI;

			public readonly ModuleDef le2;

			private readonly Importer qes;

			public iei(ModuleDef moduleDef_0, ModuleDef moduleDef_1)
			{
				YeI = moduleDef_0;
				le2 = moduleDef_1;
				qes = new Importer(moduleDef_1, ImporterOptions.TryToUseTypeDefs, default(GenericParamContext), this);
			}

			[SpecialName]
			public Importer heS()
			{
				return qes;
			}

			public override ITypeDefOrRef Map(ITypeDefOrRef source)
			{
				TypeDef typeDef = source as TypeDef;
				if (typeDef != null && NeO.ContainsKey(typeDef))
				{
					return (TypeDef)NeO[typeDef];
				}
				return null;
			}

			public override IMethod Map(MethodDef source)
			{
				if (NeO.ContainsKey(source))
				{
					return (MethodDef)NeO[source];
				}
				return null;
			}

			public override IField Map(FieldDef source)
			{
				if (!NeO.ContainsKey(source))
				{
					return null;
				}
				return (FieldDef)NeO[source];
			}
		}

		[CompilerGenerated]
		private sealed class geE
		{
			public Dictionary<object, object> Vep;

			public Func<Instruction, Instruction> BeB;

			internal Instruction leg(Instruction instruction_0)
			{
				return (Instruction)Vep[instruction_0];
			}
		}

		private static TypeDefUser fk(TypeDef typeDef_0)
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

		private static MethodDefUser ou(MethodDef methodDef_0)
		{
			MethodDefUser methodDefUser = new MethodDefUser(methodDef_0.Name, null, methodDef_0.ImplAttributes, methodDef_0.Attributes);
			foreach (GenericParam genericParameter in methodDef_0.GenericParameters)
			{
				methodDefUser.GenericParameters.Add(new GenericParamUser(genericParameter.Number, genericParameter.Flags, "-"));
			}
			return methodDefUser;
		}

		private static FieldDefUser U3(FieldDef fieldDef_0)
		{
			return new FieldDefUser(fieldDef_0.Name, null, fieldDef_0.Attributes);
		}

		private static TypeDef H5(TypeDef typeDef_0, Dictionary<IDnlibDef, IDnlibDef> dictionary_0)
		{
			IDnlibDef value;
			TypeDef typeDef;
			if (((iei)(object)dictionary_0).NeO.TryGetValue(typeDef_0, out value))
			{
				typeDef = (TypeDef)value;
			}
			else
			{
				typeDef = fk(typeDef_0);
				((iei)(object)dictionary_0).NeO[typeDef_0] = typeDef;
			}
			foreach (TypeDef nestedType in typeDef_0.NestedTypes)
			{
				typeDef.NestedTypes.Add(H5(nestedType, dictionary_0));
			}
			foreach (MethodDef method in typeDef_0.Methods)
			{
				IList<MethodDef> methods = typeDef.Methods;
				IDnlibDef dnlibDef = (((iei)(object)dictionary_0).NeO[method] = ou(method));
				methods.Add((MethodDef)dnlibDef);
			}
			foreach (FieldDef field in typeDef_0.Fields)
			{
				IList<FieldDef> fields = typeDef.Fields;
				IDnlibDef dnlibDef = (((iei)(object)dictionary_0).NeO[field] = U3(field));
				fields.Add((FieldDef)dnlibDef);
			}
			return typeDef;
		}

		private static void jH(TypeDef typeDef_0, object object_0)
		{
			TypeDef typeDef = (TypeDef)((iei)object_0).NeO[typeDef_0];
			typeDef.BaseType = ((iei)object_0).heS().Import(typeDef_0.BaseType);
			foreach (InterfaceImpl @interface in typeDef_0.Interfaces)
			{
				typeDef.Interfaces.Add(new InterfaceImplUser(((iei)object_0).heS().Import(@interface.Interface)));
			}
		}

		private static void lM(MethodDef methodDef_0, object object_0)
		{
			MethodDef methodDef = (MethodDef)((iei)object_0).NeO[methodDef_0];
			methodDef.Signature = ((iei)object_0).heS().Import(methodDef_0.Signature);
			methodDef.Parameters.UpdateParameterTypes();
			if (methodDef_0.ImplMap != null)
			{
				methodDef.ImplMap = new ImplMapUser(new ModuleRefUser(((iei)object_0).le2, methodDef_0.ImplMap.Module.Name), methodDef_0.ImplMap.Name, methodDef_0.ImplMap.Attributes);
			}
			foreach (CustomAttribute customAttribute in methodDef_0.CustomAttributes)
			{
				methodDef.CustomAttributes.Add(new CustomAttribute((ICustomAttributeType)((iei)object_0).heS().Import(customAttribute.Constructor)));
			}
			if (!methodDef_0.HasBody)
			{
				return;
			}
			methodDef.Body = new CilBody(methodDef_0.Body.InitLocals, new List<Instruction>(), new List<ExceptionHandler>(), new List<Local>());
			methodDef.Body.MaxStack = methodDef_0.Body.MaxStack;
			Dictionary<object, object> Vep = new Dictionary<object, object>();
			foreach (Local variable in methodDef_0.Body.Variables)
			{
				Local local = new Local(((iei)object_0).heS().Import(variable.Type));
				methodDef.Body.Variables.Add(local);
				local.Name = variable.Name;
				Vep[variable] = local;
			}
			foreach (Instruction instruction2 in methodDef_0.Body.Instructions)
			{
				Instruction instruction = new Instruction(instruction2.OpCode, instruction2.Operand);
				instruction.SequencePoint = instruction2.SequencePoint;
				if (!(instruction.Operand is IType))
				{
					if (!(instruction.Operand is IMethod))
					{
						if (instruction.Operand is IField)
						{
							instruction.Operand = ((iei)object_0).heS().Import((IField)instruction.Operand);
						}
					}
					else
					{
						instruction.Operand = ((iei)object_0).heS().Import((IMethod)instruction.Operand);
					}
				}
				else
				{
					instruction.Operand = ((iei)object_0).heS().Import((IType)instruction.Operand);
				}
				methodDef.Body.Instructions.Add(instruction);
				Vep[instruction2] = instruction;
			}
			foreach (Instruction instruction3 in methodDef.Body.Instructions)
			{
				if (instruction3.Operand != null && Vep.ContainsKey(instruction3.Operand))
				{
					instruction3.Operand = Vep[instruction3.Operand];
				}
				else if (instruction3.Operand is Instruction[])
				{
					instruction3.Operand = ((Instruction[])instruction3.Operand).Select((Instruction instruction_0) => (Instruction)Vep[instruction_0]).ToArray();
				}
			}
			foreach (ExceptionHandler exceptionHandler in methodDef_0.Body.ExceptionHandlers)
			{
				methodDef.Body.ExceptionHandlers.Add(new ExceptionHandler(exceptionHandler.HandlerType)
				{
					CatchType = ((exceptionHandler.CatchType != null) ? ((iei)object_0).heS().Import(exceptionHandler.CatchType) : null),
					TryStart = (Instruction)Vep[exceptionHandler.TryStart],
					TryEnd = (Instruction)Vep[exceptionHandler.TryEnd],
					HandlerStart = (Instruction)Vep[exceptionHandler.HandlerStart],
					HandlerEnd = (Instruction)Vep[exceptionHandler.HandlerEnd],
					FilterStart = ((exceptionHandler.FilterStart != null) ? ((Instruction)Vep[exceptionHandler.FilterStart]) : null)
				});
			}
			methodDef.Body.SimplifyMacros(methodDef.Parameters);
		}

		private static void dL(FieldDef fieldDef_0, object object_0)
		{
			FieldDef fieldDef = (FieldDef)((iei)object_0).NeO[fieldDef_0];
			fieldDef.Signature = ((iei)object_0).heS().Import(fieldDef_0.Signature);
		}

		private static void dV(TypeDef typeDef_0, object object_0, bool bool_0)
		{
			if (bool_0)
			{
				jH(typeDef_0, object_0);
			}
			foreach (TypeDef nestedType in typeDef_0.NestedTypes)
			{
				dV(nestedType, object_0, true);
			}
			foreach (MethodDef method in typeDef_0.Methods)
			{
				lM(method, object_0);
			}
			foreach (FieldDef field in typeDef_0.Fields)
			{
				dL(field, object_0);
			}
		}

		public static TypeDef Inject(TypeDef typeDef_0, ModuleDef moduleDef_0)
		{
			iei iei = new iei(typeDef_0.Module, moduleDef_0);
			H5(typeDef_0, (Dictionary<IDnlibDef, IDnlibDef>)(object)iei);
			dV(typeDef_0, iei, true);
			return (TypeDef)iei.NeO[typeDef_0];
		}

		public static MethodDef Inject(MethodDef methodDef_0, ModuleDef moduleDef_0)
		{
			iei iei = new iei(methodDef_0.Module, moduleDef_0);
			iei.NeO[methodDef_0] = ou(methodDef_0);
			lM(methodDef_0, iei);
			return (MethodDef)iei.NeO[methodDef_0];
		}

		public static IEnumerable<IDnlibDef> Inject(TypeDef typeDef_0, TypeDef typeDef_1, ModuleDef moduleDef_0)
		{
			iei iei = new iei(typeDef_0.Module, moduleDef_0);
			iei.NeO[typeDef_0] = typeDef_1;
			H5(typeDef_0, (Dictionary<IDnlibDef, IDnlibDef>)(object)iei);
			dV(typeDef_0, iei, false);
			return iei.NeO.Values.Except(new TypeDef[1] { typeDef_1 });
		}
	}
}
