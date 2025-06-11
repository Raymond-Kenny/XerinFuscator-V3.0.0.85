#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Confuser.DynCipher;
using Confuser.DynCipher.AST;
using Confuser.DynCipher.Generation;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;
using XCore.Context;
using XCore.Generator;
using XCore.Injection;
using XCore.Mutation;
using XCore.Utils;
using XRuntime;

namespace XF
{
    internal class hV : Y2q
    {
        private class P9Y : CILCodeGen
        {
            private readonly Instruction[] Q9B;

            public P9Y(Instruction[] instruction_0, MethodDef methodDef_0, IList<Instruction> ilist_0)
                : base(methodDef_0, ilist_0)
            {
                Q9B = instruction_0;
            }

            protected override void LoadVar(Variable variable_0)
            {
                if (variable_0.Name == "{RESULT}")
                {
                    Instruction[] q9B = Q9B;
                    foreach (Instruction instruction_ in q9B)
                    {
                        Emit(instruction_);
                    }
                }
                else
                {
                    base.LoadVar(variable_0);
                }
            }
        }

        private class w9p
        {
            public FieldDef A9X;

            public D9K g9y;

            public object B9g;

            public Code i9o;

            public byte J9n;
        }

        private class D9K
        {
            public EH N9G;

            public object r9j;

            public int j91;

            public Array H9S;

            public int[] r9b;
        }

        [Serializable]
        [CompilerGenerated]
        private sealed class E9E
        {
            public static readonly E9E v93;

            public static Func<int, int> H9M;

            public static Func<Tuple<TypeDef, Func<int, int>>, bool> n9e;

            public static Func<Tuple<TypeDef, Func<int, int>>, TypeDef> B9C;

            public static Func<Tuple<TypeDef, Func<int, int>>, Func<int, int>> t9z;

            static E9E()
            {
                v93 = new E9E();
            }

            internal int P9f(int int_0)
            {
                return int_0 * 8;
            }

            internal bool C9W(Tuple<TypeDef, Func<int, int>> tuple_0)
            {
                return tuple_0 != null;
            }

            internal TypeDef M9H(Tuple<TypeDef, Func<int, int>> tuple_0)
            {
                return tuple_0.Item1;
            }

            internal Func<int, int> o9d(Tuple<TypeDef, Func<int, int>> tuple_0)
            {
                return tuple_0.Item2;
            }
        }

        [CompilerGenerated]
        private sealed class Mwc
        {
            public MethodDef mw8;

            public Expression Dwx;

            internal Instruction[] Ww2(Instruction[] instruction_0)
            {
                List<Instruction> list = new List<Instruction>();
                ((CILCodeGen)new P9Y(instruction_0, mw8, list)).method_0(Dwx);
                return list.ToArray();
            }
        }

        [CompilerGenerated]
        private sealed class cw9
        {
            public EH tww;

            public x29 AwR;
        }

        [CompilerGenerated]
        private sealed class Kwm
        {
            public MethodDef Lw7;

            public cw9 xwh;

            internal Instruction[] SwL(Instruction[] instruction_0)
            {
                return xwh.tww.sP0(Lw7, xwh.AwR, instruction_0);
            }
        }

        private readonly List<w9p> Pn = new List<w9p>();

        private readonly Dictionary<Tuple<Code, IMethod, EH>, Tuple<FieldDef, MethodDef>> pK = new Dictionary<Tuple<Code, IMethod, EH>, Tuple<FieldDef, MethodDef>>();

        private readonly Dictionary<EH, D9K[]> XG = new Dictionary<EH, D9K[]>();

        private x29 Pj;

        private object w1;

        private static int? R4(object object_0, int int_0, int int_1)
        {
            if (((x29)object_0).m2R.Contains(((x29)object_0).L2w.Instructions[int_0]))
            {
                return null;
            }
            int num = int_1;
            int num2 = int_0;
            Instruction instruction;
            do
            {
                if (num > 0)
                {
                    num2--;
                    instruction = ((x29)object_0).L2w.Instructions[num2];
                    if (instruction.OpCode != OpCodes.Pop && instruction.OpCode != OpCodes.Dup)
                    {
                        FlowControl flowControl = instruction.OpCode.FlowControl;
                        FlowControl flowControl2 = flowControl;
                        if ((uint)(flowControl2 - 1) <= 1u || (uint)(flowControl2 - 4) <= 1u)
                        {
                            int pushes;
                            int pops;
                            instruction.CalculateStackUsage(out pushes, out pops);
                            num += pops;
                            num -= pushes;
                            continue;
                        }
                        return null;
                    }
                    return null;
                }
                if (num < 0)
                {
                    return null;
                }
                return num2;
            }
            while (!((x29)object_0).m2R.Contains(instruction) || num == 0);
            return null;
        }

        public override void TPk(x29 x29_0, int int_0)
        {
            Instruction instruction = x29_0.L2w.Instructions[int_0];
            TypeDef typeDef = ((IMethod)instruction.Operand).DeclaringType.ResolveTypeDefThrow();
            if (typeDef.Module.IsILOnly && !typeDef.IsGlobalModuleType)
            {
                int pushes;
                int pops;
                instruction.CalculateStackUsage(out pushes, out pops);
                int? num = R4(x29_0, int_0, pops);
                if (num.HasValue)
                {
                    xY(x29_0, int_0, num.Value);
                }
                else
                {
                    Os(x29_0, int_0);
                }
            }
        }

        private void Os(x29 x29_0, int int_0)
        {
            Instruction instruction = x29_0.L2w.Instructions[int_0];
            IMethod method = (IMethod)instruction.Operand;
            TypeDef typeDef = method.DeclaringType.ResolveTypeDefThrow();
            if (typeDef.Module.IsILOnly && !typeDef.IsGlobalModuleType)
            {
                Tuple<Code, IMethod, EH> key = Tuple.Create(instruction.OpCode.Code, method, (EH)x29_0.r2N);
                Tuple<FieldDef, MethodDef> value;
                if (!pK.TryGetValue(key, out value))
                {
                    value = new Tuple<FieldDef, MethodDef>(null, null);
                }
                else if (value.Item2 != null)
                {
                    instruction.OpCode = OpCodes.Call;
                    instruction.Operand = value.Item2;
                    return;
                }
                MethodSig methodSig_ = Y2q.q2l(x29_0, method, instruction.OpCode.Code == Code.Newobj);
                TypeDef typeDef_ = Y2q.U2I(x29_0, methodSig_);
                if (value.Item1 == null)
                {
                    value = new Tuple<FieldDef, MethodDef>(xp(x29_0, typeDef_), value.Item2);
                }
                Debug.Assert(value.Item2 == null);
                value = new Tuple<FieldDef, MethodDef>(value.Item1, UB(x29_0, typeDef_, value.Item1, methodSig_));
                pK[key] = value;
                instruction.OpCode = OpCodes.Call;
                instruction.Operand = value.Item2;
                MethodDef methodDef = method.ResolveMethodDef();
                if (methodDef != null)
                {
                    x29_0.B2m.Annotations.Set(methodDef, methodDef, methodDef);
                }
            }
        }

        private void xY(x29 x29_0, int int_0, int int_1)
        {
            Instruction instruction = x29_0.L2w.Instructions[int_0];
            IMethod method = (IMethod)instruction.Operand;
            MethodSig methodSig_ = Y2q.q2l(x29_0, method, instruction.OpCode.Code == Code.Newobj);
            TypeDef typeDef = Y2q.U2I(x29_0, methodSig_);
            Tuple<Code, IMethod, EH> key = Tuple.Create(instruction.OpCode.Code, method, (EH)x29_0.r2N);
            Tuple<FieldDef, MethodDef> value;
            if (!pK.TryGetValue(key, out value))
            {
                value = new Tuple<FieldDef, MethodDef>(xp(x29_0, typeDef), null);
                pK[key] = value;
            }
            if (int_1 == int_0)
            {
                x29_0.L2w.Instructions.Insert(int_0 + 1, new Instruction(OpCodes.Call, typeDef.FindMethod("Invoke")));
                instruction.OpCode = OpCodes.Ldsfld;
                instruction.Operand = value.Item1;
            }
            else
            {
                Instruction instruction2 = x29_0.L2w.Instructions[int_1];
                x29_0.L2w.Instructions.Insert(int_1 + 1, new Instruction(instruction2.OpCode, instruction2.Operand));
                instruction2.OpCode = OpCodes.Ldsfld;
                instruction2.Operand = value.Item1;
                instruction.OpCode = OpCodes.Call;
                instruction.Operand = typeDef.FindMethod("Invoke");
            }
            MethodDef methodDef = method.ResolveMethodDef();
            if (methodDef != null)
            {
                x29_0.B2m.Annotations.Set(methodDef, methodDef, methodDef);
            }
        }

        protected static MethodDef UB(object object_0, TypeDef typeDef_0, IField ifield_0, MethodSig methodSig_0)
        {
            MethodDefUser methodDefUser = new MethodDefUser(GGeneration.GenerateGuidStartingWithLetter(), methodSig_0)
            {
                Attributes = (MethodAttributes.Public | MethodAttributes.Static),
                ImplAttributes = MethodImplAttributes.IL,
                Body = new CilBody()
            };
            methodDefUser.Body.Instructions.Add(Instruction.Create(OpCodes.Ldsfld, ifield_0));
            for (int i = 0; i < methodDefUser.Parameters.Count; i++)
            {
                methodDefUser.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg, methodDefUser.Parameters[i]));
            }
            MethodDef methodDef = typeDef_0.FindMethod("Invoke");
            if (methodDef == null)
            {
                throw new Exception("Invoke method not found in delegate type " + typeDef_0.FullName);
            }
            methodDefUser.Body.Instructions.Add(Instruction.Create(OpCodes.Callvirt, methodDef));
            methodDefUser.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
            typeDef_0.Methods.Add(methodDefUser);
            return methodDefUser;
        }

        private FieldDef xp(x29 x29_0, TypeDef typeDef_0)
        {
            TypeDef typeDef;
            do
            {
                typeDef = x29_0.u2Q.Types[x29_0.d2r.NextInt32(x29_0.u2Q.Types.Count)];
            }
            while (typeDef.HasGenericParameters || typeDef.IsGlobalModuleType || typeDef.IsDelegate());
            TypeSig type = new CModOptSig(typeDef, typeDef_0.ToTypeSig());
            FieldDefUser fieldDefUser = new FieldDefUser(GGeneration.GenerateGuidStartingWithLetter(), new FieldSig(type), FieldAttributes.Public | FieldAttributes.Static);
            fieldDefUser.CustomAttributes.Add(new CustomAttribute(ry(x29_0).FindInstanceConstructors().First()));
            typeDef_0.Fields.Add(fieldDefUser);
            return fieldDefUser;
        }

        public void AX(RandomGenerator randomGenerator_0, Expression expression_0, Expression expression_1, int int_0, out Expression expression_2, out Expression expression_3)
        {
            ExpressionGenerator.GeneratePair(randomGenerator_0, expression_0, expression_1, int_0, out expression_2, out expression_3);
        }

        private TypeDef ry(x29 x29_0)
        {
            if (w1 == null)
            {
                w1 = new Tuple<TypeDef, Func<int, int>>[16];
            }
            int num = x29_0.d2r.NextInt32(((Array)w1).Length);
            if (((object[])w1)[num] == null)
            {
                ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(RefProxyKey).Module);
                TypeDef typeDef_ = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(RefProxyKey).MetadataToken));
                TypeDef typeDef = InjectHelper.Inject(typeDef_, x29_0.u2Q);
                typeDef.Name = GGeneration.GenerateGuidStartingWithLetter();
                typeDef.Namespace = GGeneration.GenerateGuidStartingWithLetter();
                Variable variable = new Variable("{VAR}");
                Variable variable2 = new Variable("{RESULT}");
                Expression expression_;
                Expression Dwx;
                AX(x29_0.d2r, new VariableExpression
                {
                    Variable = variable
                }, new VariableExpression
                {
                    Variable = variable2
                }, x29_0.L27, out expression_, out Dwx);
                Func<int, int> item = new DMCodeGen(typeof(int), new Tuple<string, Type>[1] { Tuple.Create("{VAR}", typeof(int)) }).method_0(expression_).Compile<Func<int, int>>();
                MethodDef mw8 = typeDef.FindMethod(".ctor");
                MutationHelper.ReplacePlaceholder(mw8, delegate (Instruction[] instruction_0)
                {
                    List<Instruction> list = new List<Instruction>();
                    ((CILCodeGen)new P9Y(instruction_0, mw8, list)).method_0(Dwx);
                    return list.ToArray();
                });
                mw8.excludeMethod(x29_0.u2Q);
                ((object[])w1)[num] = Tuple.Create(typeDef, item);
                x29_0.u2Q.AddAsNonNestedType(typeDef);
                foreach (IDnlibDef item2 in typeDef.FindDefinitions())
                {
                    if (item2.Name == "GetHashCode")
                    {
                        ((MethodDef)item2).Access = MethodAttributes.Public;
                    }
                }
            }
            return ((Tuple<TypeDef, Func<int, int>>)((object[])w1)[num]).Item1;
        }

        private D9K tg(x29 x29_0, EH eh_0)
        {
            D9K[] value;
            if (!XG.TryGetValue(eh_0, out value))
            {
                value = (XG[eh_0] = new D9K[x29_0.A2P]);
            }
            int num = x29_0.d2r.NextInt32(value.Length);
            if (value[num] == null)
            {
                newInjector newInjector = new newInjector((ModuleDefMD)x29_0.u2Q, typeof(RefProxyStrong));
                MethodDef Lw7 = newInjector.FindMember("Initialize") as MethodDef;
                Lw7.DeclaringType = null;
                Lw7.Access = MethodAttributes.PrivateScope;
                x29_0.u2Q.GlobalType.Methods.Add(Lw7);
                D9K d9K = new D9K
                {
                    r9j = Lw7
                };
                int[] array2 = Enumerable.Range(0, 5).ToArray();
                x29_0.d2r.Shuffle(array2);
                d9K.j91 = array2[4];
                d9K.r9b = new int[4];
                Array.Copy(array2, 0, d9K.r9b, 0, 4);
                d9K.H9S = (from int_0 in Enumerable.Range(0, 4)
                           select int_0 * 8).ToArray();
                x29_0.d2r.Shuffle((IList<int>)d9K.H9S);
                int[] array3 = new int[9];
                Array.Copy(d9K.r9b, 0, array3, 0, 4);
                Array.Copy(d9K.H9S, 0, array3, 4, 4);
                array3[8] = d9K.j91;
                MutationHelper.InjectKeys(Lw7, Enumerable.Range(0, 9).ToArray(), array3);
                MutationHelper.ReplacePlaceholder(Lw7, (Instruction[] instruction_0) => {
                    try
                    {
                        Instruction[] result = eh_0.sP0(Lw7, x29_0, instruction_0);

                        // --- DEBUGGING ---
                        if (result == null || result.Length == 0)
                        {
                            // Set a breakpoint here. This will hit if sP0 is failing to produce code.
                            Debug.WriteLine("Warning: eh_0.sP0 returned no instructions.");
                        }
                        // --- END DEBUGGING ---

                        return result;
                    }
                    catch (Exception ex)
                    {
                        // Set a breakpoint here. This will tell you if sP0 is throwing an exception.
                        Debug.WriteLine($"Error inside eh_0.sP0: {ex}");
                        throw; // Re-throw to see the original crash
                    }
                }); d9K.N9G = eh_0;
                value[num] = d9K;
                newInjector.Rename();
            }
            return value[num];
        }

        public override void Finalize(x29 x29_0)
        {
            foreach (KeyValuePair<Tuple<Code, IMethod, EH>, Tuple<FieldDef, MethodDef>> item in pK)
            {
                D9K d9K = tg(x29_0, item.Key.Item3);
                byte b;
                do
                {
                    b = x29_0.d2r.NextByte();
                }
                while (b == (byte)item.Key.Item1);
                TypeDef declaringType = item.Value.Item1.DeclaringType;
                MethodDef methodDef = declaringType.FindOrCreateStaticConstructor();
                methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, (IMethod)d9K.r9j));
                methodDef.Body.Instructions.Insert(0, Instruction.CreateLdcI4(b));
                methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Ldtoken, item.Value.Item1));
                Pn.Add(new w9p
                {
                    A9X = item.Value.Item1,
                    i9o = item.Key.Item1,
                    B9g = item.Key.Item2,
                    J9n = b,
                    g9y = d9K
                });
            }
            foreach (TypeDef value in x29_0.t2L.Values)
            {
                value.FindOrCreateStaticConstructor();
            }
            XContext.ModOpts.MetadataOptions.Flags |= MetadataFlags.PreserveExtraSignatureData;
            XContext.ModOpts.WriterEvent += ho;
            Pj = x29_0;
        }

        private void ho(object sender, ModuleWriterEventArgs e)
        {
            ModuleWriterBase moduleWriterBase = (ModuleWriterBase)sender;
            if (e.Event != ModuleWriterEvent.MDMemberDefRidsAllocated || w1 == null)
            {
                return;
            }
            Dictionary<TypeDef, Func<int, int>> dictionary = ((IEnumerable<Tuple<TypeDef, Func<int, int>>>)w1).Where((Tuple<TypeDef, Func<int, int>> tuple_0) => tuple_0 != null).ToDictionary((Tuple<TypeDef, Func<int, int>> tuple_0) => tuple_0.Item1, (Tuple<TypeDef, Func<int, int>> tuple_0) => tuple_0.Item2);
            foreach (w9p item in Pn)
            {
                uint raw = moduleWriterBase.Metadata.GetToken(item.B9g).Raw;
                uint num = Pj.d2r.NextUInt32() | 1;
                CustomAttribute customAttribute = item.A9X.CustomAttributes[0];
                int num2 = dictionary[(TypeDef)customAttribute.AttributeType]((int)MathsUtils.modInv(num));
                customAttribute.ConstructorArguments.Add(new CAArgument(Pj.u2Q.CorLibTypes.Int32, num2));
                raw *= num;
                raw = (uint)item.g9y.N9G.xPQ((MethodDef)item.g9y.r9j, Pj, (int)raw);
                char[] array = new char[5];
                array[item.g9y.j91] = (char)((byte)item.i9o ^ item.J9n);
                byte[] array2 = Pj.d2r.NextBytes(4);
                uint num3 = 0u;
                for (int num4 = 0; num4 < 4; num4++)
                {
                    while (array2[num4] == 0)
                    {
                        array2[num4] = Pj.d2r.NextByte();
                    }
                    array[item.g9y.r9b[num4]] = (char)array2[num4];
                    num3 |= (uint)(array2[num4] << ((int[])item.g9y.H9S)[num4]);
                }
                item.A9X.Name = new string(array);
                FieldSig fieldSig = item.A9X.FieldSig;
                uint num5 = (raw - moduleWriterBase.Metadata.GetToken(((CModOptSig)fieldSig.Type).Modifier).Raw) ^ num3;
                fieldSig.ExtraData = new byte[8]
                {
                192,
                0,
                0,
                (byte)(num5 >> ((int[])item.g9y.H9S)[3]),
                192,
                (byte)(num5 >> ((int[])item.g9y.H9S)[2]),
                (byte)(num5 >> ((int[])item.g9y.H9S)[1]),
                (byte)(num5 >> ((int[])item.g9y.H9S)[0])
                };
            }
        }
    }
}
