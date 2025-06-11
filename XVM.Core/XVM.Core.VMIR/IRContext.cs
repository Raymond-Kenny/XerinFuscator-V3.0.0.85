using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR
{
	public class IRContext
	{
		private readonly IRVariable[] fqH;

		private readonly Dictionary<ExceptionHandler, IRVariable> EqC;

		private readonly IRVariable[] bqm;

		private readonly Dictionary<ILASTVariable, IRVariable> tq5 = new Dictionary<ILASTVariable, IRVariable>();

		private readonly List<IRVariable> Qqo = new List<IRVariable>();

		[CompilerGenerated]
		private readonly MethodDef Dql;

		[CompilerGenerated]
		private bool sqZ;

		public MethodDef Method
		{
			[CompilerGenerated]
			get
			{
				return Dql;
			}
		}

		public bool IsRuntime
		{
			[CompilerGenerated]
			get
			{
				return sqZ;
			}
			[CompilerGenerated]
			set
			{
				sqZ = value;
			}
		}

		public IRContext(MethodDef methodDef_0, CilBody cilBody_0)
		{
			Dql = methodDef_0;
			IsRuntime = false;
			bqm = new IRVariable[cilBody_0.Variables.Count];
			for (int i = 0; i < bqm.Length; i++)
			{
				if (!cilBody_0.Variables[i].Type.IsPinned)
				{
					bqm[i] = new IRVariable
					{
						Id = i,
						Name = "local_" + i,
						Type = TypeInference.smethod_0(cilBody_0.Variables[i].Type),
						RawType = cilBody_0.Variables[i].Type,
						VariableType = IRVariableType.Local
					};
					continue;
				}
				throw new NotSupportedException("Pinned variables are not supported.");
			}
			fqH = new IRVariable[methodDef_0.Parameters.Count];
			for (int j = 0; j < fqH.Length; j++)
			{
				fqH[j] = new IRVariable
				{
					Id = j,
					Name = "arg_" + j,
					Type = TypeInference.smethod_0(methodDef_0.Parameters[j].Type),
					RawType = methodDef_0.Parameters[j].Type,
					VariableType = IRVariableType.Argument
				};
			}
			EqC = new Dictionary<ExceptionHandler, IRVariable>();
			int num = -1;
			foreach (ExceptionHandler exceptionHandler in cilBody_0.ExceptionHandlers)
			{
				num++;
				if (exceptionHandler.HandlerType != ExceptionHandlerType.Fault && exceptionHandler.HandlerType != ExceptionHandlerType.Finally)
				{
					TypeSig typeSig = exceptionHandler.CatchType.ToTypeSig();
					EqC.Add(exceptionHandler, new IRVariable
					{
						Id = num,
						Name = "ex_" + num,
						Type = TypeInference.smethod_0(typeSig),
						RawType = typeSig,
						VariableType = IRVariableType.VirtualRegister
					});
				}
			}
		}

		public IRVariable AllocateVRegister(ASTType asttype_0)
		{
			IRVariable iRVariable = new IRVariable
			{
				Id = Qqo.Count,
				Name = "vreg_" + Qqo.Count,
				Type = asttype_0,
				VariableType = IRVariableType.VirtualRegister
			};
			Qqo.Add(iRVariable);
			return iRVariable;
		}

		public IRVariable ResolveVRegister(ILASTVariable ilastvariable_0)
		{
			if (ilastvariable_0.VariableType != ILASTVariableType.ExceptionVar)
			{
				if (tq5.TryGetValue(ilastvariable_0, out var value))
				{
					return value;
				}
				value = AllocateVRegister(ilastvariable_0.Type);
				tq5[ilastvariable_0] = value;
				return value;
			}
			return ResolveExceptionVar((ExceptionHandler)ilastvariable_0.Annotation);
		}

		public IRVariable ResolveParameter(Parameter parameter_0)
		{
			return fqH[parameter_0.Index];
		}

		public IRVariable ResolveLocal(Local local_0)
		{
			return bqm[local_0.Index];
		}

		public IRVariable[] GetParameters()
		{
			return fqH;
		}

		public IRVariable ResolveExceptionVar(ExceptionHandler exceptionHandler_0)
		{
			return EqC[exceptionHandler_0];
		}
	}
}
