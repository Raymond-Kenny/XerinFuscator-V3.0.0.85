using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XVM.Core.Helpers.Injection
{
	public static class InjectHelper
	{
		private class hZO : ImportMapper
		{
			public readonly Dictionary<IDnlibDef, IDnlibDef> CZL = new Dictionary<IDnlibDef, IDnlibDef>();

			public readonly ModuleDef YZk;

			public readonly ModuleDef NZH;

			private readonly Importer PZC;

			public hZO(ModuleDef moduleDef_0, ModuleDef moduleDef_1)
			{
				YZk = moduleDef_0;
				NZH = moduleDef_1;
				PZC = new Importer(moduleDef_1, ImporterOptions.TryToUseTypeDefs, default(GenericParamContext), this);
			}

			[SpecialName]
			public Importer qZt()
			{
				return PZC;
			}

			public override ITypeDefOrRef Map(ITypeDefOrRef source)
			{
				if (source is TypeDef key && CZL.ContainsKey(key))
				{
					return (TypeDef)CZL[key];
				}
				return null;
			}

			public override IMethod Map(MethodDef source)
			{
				if (CZL.ContainsKey(source))
				{
					return (MethodDef)CZL[source];
				}
				return null;
			}

			public override IField Map(FieldDef source)
			{
				if (!CZL.ContainsKey(source))
				{
					return null;
				}
				return (FieldDef)CZL[source];
			}
		}

		[CompilerGenerated]
		private sealed class NZm
		{
			public Dictionary<object, object> AZo;

			public Func<Instruction, Instruction> WZl;

			internal Instruction uZ5(Instruction instruction_0)
			{
				return (Instruction)AZo[instruction_0];
			}
		}

		private static TypeDefUser rOf(TypeDef typeDef_0)
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

		private static MethodDefUser YOi(MethodDef methodDef_0)
		{
			MethodDefUser methodDefUser = new MethodDefUser(methodDef_0.Name, null, methodDef_0.ImplAttributes, methodDef_0.Attributes);
			foreach (GenericParam genericParameter in methodDef_0.GenericParameters)
			{
				methodDefUser.GenericParameters.Add(new GenericParamUser(genericParameter.Number, genericParameter.Flags, "-"));
			}
			return methodDefUser;
		}

		private static FieldDefUser GOJ(FieldDef fieldDef_0)
		{
			return new FieldDefUser(fieldDef_0.Name, null, fieldDef_0.Attributes);
		}

		private static TypeDef EO8(TypeDef typeDef_0, Dictionary<IDnlibDef, IDnlibDef> dictionary_0)
		{
			TypeDef typeDef;
			if (((hZO)(object)dictionary_0).CZL.TryGetValue(typeDef_0, out var value))
			{
				typeDef = (TypeDef)value;
			}
			else
			{
				typeDef = rOf(typeDef_0);
				((hZO)(object)dictionary_0).CZL[typeDef_0] = typeDef;
			}
			foreach (TypeDef nestedType in typeDef_0.NestedTypes)
			{
				typeDef.NestedTypes.Add(EO8(nestedType, dictionary_0));
			}
			foreach (MethodDef method in typeDef_0.Methods)
			{
				IList<MethodDef> methods = typeDef.Methods;
				IDnlibDef dnlibDef = (((hZO)(object)dictionary_0).CZL[method] = YOi(method));
				methods.Add((MethodDef)dnlibDef);
			}
			foreach (FieldDef field in typeDef_0.Fields)
			{
				IList<FieldDef> fields = typeDef.Fields;
				IDnlibDef dnlibDef = (((hZO)(object)dictionary_0).CZL[field] = GOJ(field));
				fields.Add((FieldDef)dnlibDef);
			}
			return typeDef;
		}

		private static void BOz(TypeDef typeDef_0, object object_0)
		{
			TypeDef typeDef = (TypeDef)((hZO)object_0).CZL[typeDef_0];
			typeDef.BaseType = ((hZO)object_0).qZt().Import(typeDef_0.BaseType);
			foreach (InterfaceImpl @interface in typeDef_0.Interfaces)
			{
				typeDef.Interfaces.Add(new InterfaceImplUser(((hZO)object_0).qZt().Import(@interface.Interface)));
			}
		}

		private static void Mt4(MethodDef methodDef_0, object object_0)
		{
			MethodDef methodDef = (MethodDef)((hZO)object_0).CZL[methodDef_0];
			methodDef.Signature = ((hZO)object_0).qZt().Import(methodDef_0.Signature);
			methodDef.Parameters.UpdateParameterTypes();
			if (methodDef_0.ImplMap != null)
			{
				methodDef.ImplMap = new ImplMapUser(new ModuleRefUser(((hZO)object_0).NZH, methodDef_0.ImplMap.Module.Name), methodDef_0.ImplMap.Name, methodDef_0.ImplMap.Attributes);
			}
			foreach (CustomAttribute customAttribute in methodDef_0.CustomAttributes)
			{
				methodDef.CustomAttributes.Add(new CustomAttribute((ICustomAttributeType)((hZO)object_0).qZt().Import(customAttribute.Constructor)));
			}
			if (!methodDef_0.HasBody)
			{
				return;
			}
			methodDef.Body = new CilBody(methodDef_0.Body.InitLocals, new List<Instruction>(), new List<ExceptionHandler>(), new List<Local>());
			methodDef.Body.MaxStack = methodDef_0.Body.MaxStack;
			Dictionary<object, object> AZo = new Dictionary<object, object>();
			foreach (Local variable in methodDef_0.Body.Variables)
			{
				Local local = new Local(((hZO)object_0).qZt().Import(variable.Type));
				methodDef.Body.Variables.Add(local);
				local.Name = variable.Name;
				AZo[variable] = local;
			}
			foreach (Instruction instruction2 in methodDef_0.Body.Instructions)
			{
				Instruction instruction = new Instruction(instruction2.OpCode, instruction2.Operand);
				instruction.SequencePoint = instruction2.SequencePoint;
				if (instruction.Operand is IType)
				{
					instruction.Operand = ((hZO)object_0).qZt().Import((IType)instruction.Operand);
				}
				else if (!(instruction.Operand is IMethod))
				{
					if (instruction.Operand is IField)
					{
						instruction.Operand = ((hZO)object_0).qZt().Import((IField)instruction.Operand);
					}
				}
				else
				{
					instruction.Operand = ((hZO)object_0).qZt().Import((IMethod)instruction.Operand);
				}
				methodDef.Body.Instructions.Add(instruction);
				AZo[instruction2] = instruction;
			}
			foreach (Instruction instruction3 in methodDef.Body.Instructions)
			{
				if (instruction3.Operand == null || !AZo.ContainsKey(instruction3.Operand))
				{
					if (instruction3.Operand is Instruction[])
					{
						instruction3.Operand = ((Instruction[])instruction3.Operand).Select((Instruction instruction_0) => (Instruction)AZo[instruction_0]).ToArray();
					}
				}
				else
				{
					instruction3.Operand = AZo[instruction3.Operand];
				}
			}
			foreach (ExceptionHandler exceptionHandler in methodDef_0.Body.ExceptionHandlers)
			{
				methodDef.Body.ExceptionHandlers.Add(new ExceptionHandler(exceptionHandler.HandlerType)
				{
					CatchType = ((exceptionHandler.CatchType == null) ? null : ((hZO)object_0).qZt().Import(exceptionHandler.CatchType)),
					TryStart = (Instruction)AZo[exceptionHandler.TryStart],
					TryEnd = (Instruction)AZo[exceptionHandler.TryEnd],
					HandlerStart = (Instruction)AZo[exceptionHandler.HandlerStart],
					HandlerEnd = (Instruction)AZo[exceptionHandler.HandlerEnd],
					FilterStart = ((exceptionHandler.FilterStart == null) ? null : ((Instruction)AZo[exceptionHandler.FilterStart]))
				});
			}
			methodDef.Body.SimplifyMacros(methodDef.Parameters);
		}

		private static void nte(FieldDef fieldDef_0, object object_0)
		{
			FieldDef fieldDef = (FieldDef)((hZO)object_0).CZL[fieldDef_0];
			fieldDef.Signature = ((hZO)object_0).qZt().Import(fieldDef_0.Signature);
		}

		private static void Otu(TypeDef typeDef_0, object object_0, bool bool_0)
		{
			if (bool_0)
			{
				BOz(typeDef_0, object_0);
			}
			foreach (TypeDef nestedType in typeDef_0.NestedTypes)
			{
				Otu(nestedType, object_0, bool_0: true);
			}
			foreach (MethodDef method in typeDef_0.Methods)
			{
				Mt4(method, object_0);
			}
			foreach (FieldDef field in typeDef_0.Fields)
			{
				nte(field, object_0);
			}
		}

		public static TypeDef Inject(TypeDef typeDef_0, ModuleDef moduleDef_0)
		{
			hZO hZO = new hZO(typeDef_0.Module, moduleDef_0);
			EO8(typeDef_0, (Dictionary<IDnlibDef, IDnlibDef>)(object)hZO);
			Otu(typeDef_0, hZO, bool_0: true);
			return (TypeDef)hZO.CZL[typeDef_0];
		}

		public static MethodDef Inject(MethodDef methodDef_0, ModuleDef moduleDef_0)
		{
			hZO hZO = new hZO(methodDef_0.Module, moduleDef_0);
			hZO.CZL[methodDef_0] = YOi(methodDef_0);
			Mt4(methodDef_0, hZO);
			return (MethodDef)hZO.CZL[methodDef_0];
		}

		public static IEnumerable<IDnlibDef> Inject(TypeDef typeDef_0, TypeDef typeDef_1, ModuleDef moduleDef_0)
		{
			hZO hZO = new hZO(typeDef_0.Module, moduleDef_0);
			hZO.CZL[typeDef_0] = typeDef_1;
			EO8(typeDef_0, (Dictionary<IDnlibDef, IDnlibDef>)(object)hZO);
			Otu(typeDef_0, hZO, bool_0: false);
			return hZO.CZL.Values.Except(new TypeDef[1] { typeDef_1 });
		}
	}
}
