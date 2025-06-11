using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XCore.Injection
{
    public static class InjectHelper
    {
        private class EtB : ImportMapper
        {
            public readonly Dictionary<IDnlibDef, IDnlibDef> N7U = new Dictionary<IDnlibDef, IDnlibDef>();

            public readonly ModuleDef k7Y;

            public readonly ModuleDef q7Q;

            private readonly Importer u7F;

            public EtB(ModuleDef moduleDef_0, ModuleDef moduleDef_1)
            {
                k7Y = moduleDef_0;
                q7Q = moduleDef_1;
                u7F = new Importer(moduleDef_1, ImporterOptions.TryToUseTypeDefs, default(GenericParamContext), this);
            }

            public Importer stz()
            {
                return u7F;
            }

            public override ITypeDefOrRef Map(ITypeDefOrRef source)
            {
                TypeDef typeDef = source as TypeDef;
                if (typeDef != null && N7U.ContainsKey(typeDef))
                {
                    return (TypeDef)N7U[typeDef];
                }
                return null;
            }

            public override IMethod Map(MethodDef source)
            {
                if (!N7U.ContainsKey(source))
                {
                    return null;
                }
                return (MethodDef)N7U[source];
            }

            public override IField Map(FieldDef source)
            {
                if (N7U.ContainsKey(source))
                {
                    return (FieldDef)N7U[source];
                }
                return null;
            }
        }

        private sealed class b7C
        {
            public Dictionary<object, object> N7J;

            public Func<Instruction, Instruction> Q7t;

            internal Instruction f7e(Instruction instruction_0)
            {
                return (Instruction)N7J[instruction_0];
            }
        }

        private static TypeDefUser QUz(TypeDef typeDef_0)
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

        private static MethodDefUser CYN(MethodDef methodDef_0)
        {
            MethodDefUser methodDefUser = new MethodDefUser(methodDef_0.Name, null, methodDef_0.ImplAttributes, methodDef_0.Attributes);
            foreach (GenericParam genericParameter in methodDef_0.GenericParameters)
            {
                methodDefUser.GenericParameters.Add(new GenericParamUser(genericParameter.Number, genericParameter.Flags, "-"));
            }
            return methodDefUser;
        }

        private static FieldDefUser IYU(FieldDef fieldDef_0)
        {
            return new FieldDefUser(fieldDef_0.Name, null, fieldDef_0.Attributes);
        }

        private static TypeDef BYY(TypeDef typeDef_0, object object_0)
        {
            EtB etB = (EtB)object_0;
            IDnlibDef value;
            TypeDef typeDef;
            if (!etB.N7U.TryGetValue(typeDef_0, out value))
            {
                typeDef = QUz(typeDef_0);
                etB.N7U[typeDef_0] = typeDef;
            }
            else
            {
                typeDef = (TypeDef)value;
            }
            foreach (TypeDef nestedType in typeDef_0.NestedTypes)
            {
                typeDef.NestedTypes.Add(BYY(nestedType, etB));
            }
            foreach (MethodDef method in typeDef_0.Methods)
            {
                IList<MethodDef> methods = typeDef.Methods;
                IDnlibDef dnlibDef = (etB.N7U[method] = CYN(method));
                methods.Add((MethodDef)dnlibDef);
            }
            foreach (FieldDef field in typeDef_0.Fields)
            {
                IList<FieldDef> fields = typeDef.Fields;
                IDnlibDef dnlibDef = (etB.N7U[field] = IYU(field));
                fields.Add((FieldDef)dnlibDef);
            }
            return typeDef;
        }

        private static void eYQ(TypeDef typeDef_0, object object_0)
        {
            EtB etB = (EtB)object_0;
            TypeDef typeDef = (TypeDef)etB.N7U[typeDef_0];
            typeDef.BaseType = etB.stz().Import(typeDef_0.BaseType);
            foreach (InterfaceImpl @interface in typeDef_0.Interfaces)
            {
                typeDef.Interfaces.Add(new InterfaceImplUser(etB.stz().Import(@interface.Interface)));
            }
        }

        private static void KYF(MethodDef methodDef_0, object object_0)
        {
            EtB etB = (EtB)object_0;
            MethodDef methodDef = (MethodDef)etB.N7U[methodDef_0];
            methodDef.Signature = etB.stz().Import(methodDef_0.Signature);
            methodDef.Parameters.UpdateParameterTypes();
            if (methodDef_0.ImplMap != null)
            {
                methodDef.ImplMap = new ImplMapUser(new ModuleRefUser(etB.q7Q, methodDef_0.ImplMap.Module.Name), methodDef_0.ImplMap.Name, methodDef_0.ImplMap.Attributes);
            }
            foreach (CustomAttribute customAttribute in methodDef_0.CustomAttributes)
            {
                methodDef.CustomAttributes.Add(new CustomAttribute((ICustomAttributeType)etB.stz().Import(customAttribute.Constructor)));
            }
            if (!methodDef_0.HasBody)
            {
                return;
            }
            methodDef.Body = new CilBody(methodDef_0.Body.InitLocals, new List<Instruction>(), new List<ExceptionHandler>(), new List<Local>());
            methodDef.Body.MaxStack = methodDef_0.Body.MaxStack;
            Dictionary<object, object> N7J = new Dictionary<object, object>();
            foreach (Local variable in methodDef_0.Body.Variables)
            {
                Local local = new Local(etB.stz().Import(variable.Type));
                methodDef.Body.Variables.Add(local);
                local.Name = variable.Name;
                N7J[variable] = local;
            }
            foreach (Instruction instruction2 in methodDef_0.Body.Instructions)
            {
                Instruction instruction = new Instruction(instruction2.OpCode, instruction2.Operand);
                instruction.SequencePoint = instruction2.SequencePoint;
                if (instruction.Operand is IType)
                {
                    instruction.Operand = etB.stz().Import((IType)instruction.Operand);
                }
                else if (instruction.Operand is IMethod)
                {
                    instruction.Operand = etB.stz().Import((IMethod)instruction.Operand);
                }
                else if (instruction.Operand is IField)
                {
                    instruction.Operand = etB.stz().Import((IField)instruction.Operand);
                }
                methodDef.Body.Instructions.Add(instruction);
                N7J[instruction2] = instruction;
            }
            foreach (Instruction instruction3 in methodDef.Body.Instructions)
            {
                if (instruction3.Operand != null && N7J.ContainsKey(instruction3.Operand))
                {
                    instruction3.Operand = N7J[instruction3.Operand];
                }
                else if (instruction3.Operand is Instruction[])
                {
                    instruction3.Operand = ((Instruction[])instruction3.Operand).Select((Instruction instruction_0) => (Instruction)N7J[instruction_0]).ToArray();
                }
            }
            foreach (ExceptionHandler exceptionHandler in methodDef_0.Body.ExceptionHandlers)
            {
                methodDef.Body.ExceptionHandlers.Add(new ExceptionHandler(exceptionHandler.HandlerType)
                {
                    CatchType = ((exceptionHandler.CatchType != null) ? etB.stz().Import(exceptionHandler.CatchType) : null),
                    TryStart = (Instruction)N7J[exceptionHandler.TryStart],
                    TryEnd = (Instruction)N7J[exceptionHandler.TryEnd],
                    HandlerStart = (Instruction)N7J[exceptionHandler.HandlerStart],
                    HandlerEnd = (Instruction)N7J[exceptionHandler.HandlerEnd],
                    FilterStart = ((exceptionHandler.FilterStart == null) ? null : ((Instruction)N7J[exceptionHandler.FilterStart]))
                });
            }
            methodDef.Body.SimplifyMacros(methodDef.Parameters);
        }

        private static void SYC(FieldDef fieldDef_0, object object_0)
        {
            EtB etB = (EtB)object_0;
            FieldDef fieldDef = (FieldDef)etB.N7U[fieldDef_0];
            fieldDef.Signature = etB.stz().Import(fieldDef_0.Signature);
        }

        private static void oYe(TypeDef typeDef_0, object object_0, bool bool_0)
        {
            if (bool_0)
            {
                eYQ(typeDef_0, object_0);
            }
            foreach (TypeDef nestedType in typeDef_0.NestedTypes)
            {
                oYe(nestedType, object_0, true);
            }
            foreach (MethodDef method in typeDef_0.Methods)
            {
                KYF(method, object_0);
            }
            foreach (FieldDef field in typeDef_0.Fields)
            {
                SYC(field, object_0);
            }
        }

        public static TypeDef Inject(TypeDef typeDef_0, ModuleDef moduleDef_0)
        {
            EtB etB = new EtB(typeDef_0.Module, moduleDef_0);
            BYY(typeDef_0, etB);
            oYe(typeDef_0, etB, true);
            return (TypeDef)etB.N7U[typeDef_0];
        }

        public static MethodDef Inject(MethodDef methodDef_0, ModuleDef moduleDef_0)
        {
            EtB etB = new EtB(methodDef_0.Module, moduleDef_0);
            etB.N7U[methodDef_0] = CYN(methodDef_0);
            KYF(methodDef_0, etB);
            return (MethodDef)etB.N7U[methodDef_0];
        }

        public static IEnumerable<IDnlibDef> Inject(TypeDef typeDef_0, TypeDef typeDef_1, ModuleDef moduleDef_0)
        {
            EtB etB = new EtB(typeDef_0.Module, moduleDef_0);
            etB.N7U[typeDef_0] = typeDef_1;
            BYY(typeDef_0, etB);
            oYe(typeDef_0, etB, false);
            return etB.N7U.Values.Except(new TypeDef[1] { typeDef_1 });
        }
    }
}