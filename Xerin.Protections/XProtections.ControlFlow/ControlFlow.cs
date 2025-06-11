using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Pdb;
using XCore.Context;
using XCore.Generator;
using XCore.Junk;
using XCore.Protections;
using XCore.Shuffler;
using XCore.Utils;
using XF;

namespace XProtections.ControlFlow
{
	public class ControlFlow : Protection
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class ILn
		{
			public static readonly ILn LLj;

			public static Predicate<PdbCustomDebugInfo> KL1;

			public static Predicate<PdbCustomDebugInfo> WLS;

			static ILn()
			{
				LLj = new ILn();
			}

			internal bool XLK(PdbCustomDebugInfo pdbCustomDebugInfo_0)
			{
				return pdbCustomDebugInfo_0 is PdbStateMachineHoistedLocalScopesCustomDebugInfo;
			}

			internal bool KLG(PdbCustomDebugInfo pdbCustomDebugInfo_0)
			{
				return pdbCustomDebugInfo_0 is PdbStateMachineHoistedLocalScopesCustomDebugInfo;
			}
		}

		public static bool isPerformance;

		public static bool isStrong;

		public static bool ultraPerformance;

		private static readonly Random fxW;

		private static readonly OpCode[] DxH;

		public override string name => "Control Flow";

		public override int number => 5;

		public override void Execute(XContext xcontext_0)
		{
			MethodDef methodDef = xcontext_0.Module.GlobalType.FindOrCreateStaticConstructor();
			foreach (TypeDef type in xcontext_0.Module.GetTypes())
			{
				if (type.Namespace == "Costura")
				{
					continue;
				}
				MethodDef[] array = type.Methods.ToArray();
				foreach (MethodDef methodDef2 in array)
				{
					if (!methodDef2.HasBody || !methodDef2.Body.HasInstructions || methodDef2.ReturnType == null || methodDef2.MethodHasL2FAttribute() || methodDef == methodDef2)
					{
						continue;
					}
					IMethod operand = xcontext_0.Module.Import(typeof(Debug).GetMethod("Close"));
					methodDef2.Body.Instructions.Insert(0, new Instruction(OpCodes.Call, operand));
					if (isStrong)
					{
						PhaseControlFlow(methodDef2, xcontext_0);
					}
					else if (!isPerformance)
					{
						if (ultraPerformance)
						{
							PerformanceMethod(xcontext_0, methodDef2);
						}
					}
					else
					{
						PhasePerfControlFlow(methodDef2, xcontext_0);
					}
				}
			}
		}

		public static void PhasePerfControlFlow(MethodDef methodDef_0, XContext xcontext_0)
		{
			CilBody body = methodDef_0.Body;
			DnlibUtils.Simplify(methodDef_0);
			bxd.tLd tLd = bxd.qx3(body);
			new mxB().txg(body, tLd, xcontext_0, methodDef_0, methodDef_0.ReturnType);
			body.Instructions.Clear();
			tLd.OPu(body);
			if (body.PdbMethod != null)
			{
				body.PdbMethod = new PdbMethod
				{
					Scope = new PdbScope
					{
						Start = body.Instructions.First(),
						End = body.Instructions.Last()
					}
				};
			}
			methodDef_0.CustomDebugInfos.RemoveWhere((PdbCustomDebugInfo pdbCustomDebugInfo_0) => pdbCustomDebugInfo_0 is PdbStateMachineHoistedLocalScopesCustomDebugInfo);
			foreach (ExceptionHandler exceptionHandler in body.ExceptionHandlers)
			{
				int num = body.Instructions.IndexOf(exceptionHandler.TryEnd) + 1;
				exceptionHandler.TryEnd = ((num >= body.Instructions.Count) ? null : body.Instructions[num]);
				num = body.Instructions.IndexOf(exceptionHandler.HandlerEnd) + 1;
				exceptionHandler.HandlerEnd = ((num < body.Instructions.Count) ? body.Instructions[num] : null);
			}
			DnlibUtils.Optimize(methodDef_0);
		}

		public static void PhaseControlFlow(MethodDef methodDef_0, XContext xcontext_0)
		{
			CilBody body = methodDef_0.Body;
			DnlibUtils.Simplify(methodDef_0);
			bxd.tLd tLd = bxd.qx3(body);
			new H9P().N9a(body, tLd, xcontext_0, methodDef_0, methodDef_0.ReturnType);
			body.Instructions.Clear();
			tLd.OPu(body);
			if (body.PdbMethod != null)
			{
				body.PdbMethod = new PdbMethod
				{
					Scope = new PdbScope
					{
						Start = body.Instructions.First(),
						End = body.Instructions.Last()
					}
				};
			}
			methodDef_0.CustomDebugInfos.RemoveWhere((PdbCustomDebugInfo pdbCustomDebugInfo_0) => pdbCustomDebugInfo_0 is PdbStateMachineHoistedLocalScopesCustomDebugInfo);
			foreach (ExceptionHandler exceptionHandler in body.ExceptionHandlers)
			{
				int num = body.Instructions.IndexOf(exceptionHandler.TryEnd) + 1;
				exceptionHandler.TryEnd = ((num < body.Instructions.Count) ? body.Instructions[num] : null);
				num = body.Instructions.IndexOf(exceptionHandler.HandlerEnd) + 1;
				exceptionHandler.HandlerEnd = ((num < body.Instructions.Count) ? body.Instructions[num] : null);
			}
			DnlibUtils.Optimize(methodDef_0);
		}

		public static void PerformanceMethod(XContext xcontext_0, MethodDef methodDef_0)
		{
			if (JunkFlow.JunkMethod == null)
			{
				new JunkFlow().injectCFJunk(xcontext_0);
			}
			methodDef_0.Body.MaxStack += 2;
			Local local = new Local(methodDef_0.Module.ImportAsTypeSig(typeof(string)));
			methodDef_0.Body.Variables.Add(local);
			Local local2 = new Local(methodDef_0.Module.ImportAsTypeSig(typeof(int)));
			methodDef_0.Body.Variables.Add(local2);
			RandomGenerator randomGenerator = new RandomGenerator(GGeneration.GenerateGuidStartingWithLetter(), GGeneration.GenerateGuidStartingWithLetter());
			if (!methodDef_0.HasBody || !methodDef_0.Body.HasInstructions)
			{
				return;
			}
			DnlibUtils.Simplify(methodDef_0);
			for (int i = 0; i < methodDef_0.Body.Instructions.Count; i++)
			{
				if (methodDef_0.Body.Instructions[i].IsLdcI4())
				{
					int num = new Random(Guid.NewGuid().GetHashCode()).Next();
					int num2 = new Random(Guid.NewGuid().GetHashCode()).Next();
					int value = num ^ num2;
					Instruction instruction = new Instruction(OpCodes.Nop);
					methodDef_0.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldstr, GGeneration.GenerateGuidStartingWithLetter()));
					methodDef_0.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Stloc, local));
					methodDef_0.Body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Ldloc, local));
					methodDef_0.Body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Ldstr, ""));
					methodDef_0.Body.Instructions.Insert(i + 5, Instruction.Create(OpCodes.Call, methodDef_0.Module.Import(typeof(string).GetMethod("op_Inequality"))));
					methodDef_0.Body.Instructions.Insert(i + 6, Instruction.Create(OpCodes.Brtrue, instruction));
					methodDef_0.Body.Instructions.Insert(i + 7, OpCodes.Stloc.ToInstruction(local2));
					methodDef_0.Body.Instructions.Insert(i + 8, Instruction.Create(OpCodes.Ldc_I4, methodDef_0.Body.Instructions[i].GetLdcI4Value() - 4));
					methodDef_0.Body.Instructions.Insert(i + 9, Instruction.Create(OpCodes.Ldc_I4, value));
					methodDef_0.Body.Instructions.Insert(i + 10, Instruction.Create(OpCodes.Ldc_I4, num2));
					Shuffler.confuse(methodDef_0, ref i);
					methodDef_0.Body.Instructions.Insert(i + 11, Instruction.Create(OpCodes.Xor));
					Shuffler.confuse(methodDef_0, ref i);
					Shuffler.cflowShuffle(methodDef_0, ref i);
					methodDef_0.Body.Instructions.Insert(i + 12, Instruction.CreateLdcI4(0));
					methodDef_0.Body.Instructions.Insert(i + 13, Instruction.Create(DxH[fxW.Next(0, DxH.Length)]));
					methodDef_0.Body.Instructions.Insert(i + 14, Instruction.Create(OpCodes.Ldc_I4, num));
					methodDef_0.Body.Instructions.Insert(i + 15, Instruction.Create(OpCodes.Bne_Un, instruction));
					methodDef_0.Body.Instructions.Insert(i + 16, Instruction.Create(OpCodes.Ldc_I4, randomGenerator.NextInt32()));
					methodDef_0.Body.Instructions.Insert(i + 17, OpCodes.Stloc.ToInstruction(local2));
					methodDef_0.Body.Instructions.Insert(i + 18, Instruction.Create(OpCodes.Sizeof, methodDef_0.Module.Import(typeof(float))));
					methodDef_0.Body.Instructions.Insert(i + 19, Instruction.Create(OpCodes.Add));
					methodDef_0.Body.Instructions.Insert(i + 20, instruction);
					i += 20;
				}
			}
			DnlibUtils.Optimize(methodDef_0);
		}

		static ControlFlow()
		{
			isPerformance = false;
			isStrong = false;
			ultraPerformance = false;
			fxW = new Random();
			DxH = new OpCode[5]
			{
				OpCodes.Add,
				OpCodes.Sub,
				OpCodes.Xor,
				OpCodes.Shr,
				OpCodes.Shl
			};
		}
	}
}
