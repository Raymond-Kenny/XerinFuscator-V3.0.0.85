#define DEBUG
using System;
using System.Diagnostics;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.ILAST;

namespace XVM.Core.ILAST.Transformation
{
	public class GClass11 : ITransformationHandler
	{
		public void Initialize(ILASTTransformer ilasttransformer_0)
		{
		}

		public void Transform(ILASTTransformer ilasttransformer_0)
		{
			foreach (IILASTStatement item in ilasttransformer_0.aja())
			{
				if (!(item is ILASTExpression))
				{
					if (!(item is ILASTAssignment))
					{
						if (item is ILASTPhi)
						{
							GjV((ILASTPhi)item);
						}
					}
					else
					{
						ILASTAssignment iLASTAssignment = (ILASTAssignment)item;
						iLASTAssignment.Variable.Type = tjb(iLASTAssignment.Value).Value;
					}
				}
				else
				{
					tjb((ILASTExpression)item);
				}
			}
		}

		private void GjV(ILASTPhi ilastphi_0)
		{
			ilastphi_0.Variable.Type = ilastphi_0.SourceVariables[0].Type;
		}

		private ASTType? tjb(ILASTExpression ilastexpression_0)
		{
			IILASTNode[] arguments = ilastexpression_0.Arguments;
			foreach (IILASTNode iILASTNode in arguments)
			{
				if (iILASTNode is ILASTExpression)
				{
					ILASTExpression iLASTExpression = (ILASTExpression)iILASTNode;
					iLASTExpression.Type = tjb(iLASTExpression).Value;
				}
			}
			ASTType? result = sjp(ilastexpression_0);
			if (result.HasValue)
			{
				ilastexpression_0.Type = result.Value;
			}
			return result;
		}

		private static ASTType? sjp(object object_0)
		{
			if (((ASTExpression)object_0).Type.HasValue)
			{
				return ((ASTExpression)object_0).Type;
			}
			OpCode opCode = ((ILASTExpression)object_0).ILCode.ToOpCode();
			switch (opCode.StackBehaviourPush)
			{
			case StackBehaviour.Push1:
				return xjr((ILASTExpression)object_0);
			case StackBehaviour.Push1_push1:
				Debug.Assert(((ILASTExpression)object_0).Arguments.Length == 1);
				return ((ILASTExpression)object_0).Arguments[0].Type;
			case StackBehaviour.Pushi:
				return pj3((ILASTExpression)object_0);
			case StackBehaviour.Pushi8:
				return ujX(object_0);
			case StackBehaviour.Pushr4:
				return djn(object_0);
			case StackBehaviour.Pushr8:
				return Nj6(object_0);
			case StackBehaviour.Pushref:
				return njx(object_0);
			default:
				return null;
			case StackBehaviour.Varpush:
				return njs((ILASTExpression)object_0);
			}
		}

		private static ASTType? xjr(ILASTExpression ilastexpression_0)
		{
			switch (ilastexpression_0.ILCode)
			{
			case Code.And:
			case Code.Or:
			case Code.Xor:
				Debug.Assert(ilastexpression_0.Arguments.Length == 2);
				Debug.Assert(ilastexpression_0.Arguments[0].Type.HasValue && ilastexpression_0.Arguments[1].Type.HasValue);
				return TypeInference.InferIntegerOp(ilastexpression_0.Arguments[0].Type.Value, ilastexpression_0.Arguments[1].Type.Value);
			case Code.Shl:
			case Code.Shr:
			case Code.Shr_Un:
				Debug.Assert(ilastexpression_0.Arguments.Length == 2);
				Debug.Assert(ilastexpression_0.Arguments[0].Type.HasValue && ilastexpression_0.Arguments[1].Type.HasValue);
				return TypeInference.InferShiftOp(ilastexpression_0.Arguments[0].Type.Value, ilastexpression_0.Arguments[1].Type.Value);
			case Code.Neg:
			{
				Debug.Assert(ilastexpression_0.Arguments.Length == 1 && ilastexpression_0.Arguments[0].Type.HasValue);
				ASTType? type = ilastexpression_0.Arguments[0].Type;
				if (!((type.GetValueOrDefault() == ASTType.I4) & type.HasValue) && ilastexpression_0.Arguments[0].Type != ASTType.I8 && ilastexpression_0.Arguments[0].Type != ASTType.R4 && ilastexpression_0.Arguments[0].Type != ASTType.R8 && ilastexpression_0.Arguments[0].Type != ASTType.Ptr)
				{
					throw new ArgumentException("Invalid Not Operand Types.");
				}
				return ilastexpression_0.Arguments[0].Type;
			}
			case Code.Not:
			{
				Debug.Assert(ilastexpression_0.Arguments.Length == 1 && ilastexpression_0.Arguments[0].Type.HasValue);
				ASTType? type = ilastexpression_0.Arguments[0].Type;
				if (!((type.GetValueOrDefault() == ASTType.I4) & type.HasValue) && ilastexpression_0.Arguments[0].Type != ASTType.I8 && ilastexpression_0.Arguments[0].Type != ASTType.Ptr)
				{
					throw new ArgumentException("Invalid Not Operand Types.");
				}
				return ilastexpression_0.Arguments[0].Type;
			}
			case Code.Ldfld:
			case Code.Ldsfld:
				return TypeInference.smethod_0(((IField)ilastexpression_0.Operand).FieldSig.Type);
			case Code.Mkrefany:
				return ASTType.O;
			case Code.Ldobj:
			case Code.Ldelem:
			case Code.Unbox_Any:
				return TypeInference.smethod_0(((ITypeDefOrRef)ilastexpression_0.Operand).ToTypeSig());
			default:
				throw new NotSupportedException(ilastexpression_0.ILCode.ToString());
			case Code.Ldloc:
				return TypeInference.smethod_0(((Local)ilastexpression_0.Operand).Type);
			case Code.Ldarg:
				return TypeInference.smethod_0(((Parameter)ilastexpression_0.Operand).Type);
			case Code.Add:
			case Code.Sub:
			case Code.Mul:
			case Code.Div:
			case Code.Div_Un:
			case Code.Rem:
			case Code.Rem_Un:
			case Code.Add_Ovf:
			case Code.Add_Ovf_Un:
			case Code.Mul_Ovf:
			case Code.Mul_Ovf_Un:
			case Code.Sub_Ovf:
			case Code.Sub_Ovf_Un:
				Debug.Assert(ilastexpression_0.Arguments.Length == 2);
				Debug.Assert(ilastexpression_0.Arguments[0].Type.HasValue && ilastexpression_0.Arguments[1].Type.HasValue);
				return TypeInference.InferBinaryOp(ilastexpression_0.Arguments[0].Type.Value, ilastexpression_0.Arguments[1].Type.Value);
			}
		}

		private static ASTType? pj3(ILASTExpression ilastexpression_0)
		{
			switch (ilastexpression_0.ILCode)
			{
			default:
				return ASTType.I4;
			case Code.Isinst:
			case Code.Unbox:
			case Code.Refanyval:
			case Code.Ldtoken:
			case Code.Arglist:
			case Code.Refanytype:
				return ASTType.O;
			case Code.Ldind_I:
			case Code.Conv_Ovf_I_Un:
			case Code.Conv_Ovf_U_Un:
			case Code.Ldelem_I:
			case Code.Conv_I:
			case Code.Conv_Ovf_I:
			case Code.Conv_Ovf_U:
			case Code.Conv_U:
			case Code.Ldftn:
			case Code.Ldvirtftn:
			case Code.Localloc:
				return ASTType.Ptr;
			case Code.Ldflda:
			case Code.Ldsflda:
			case Code.Ldelema:
			case Code.Ldarga:
			case Code.Ldloca:
				return ASTType.ByRef;
			}
		}

		private static ASTType? ujX(object object_0)
		{
			return ASTType.I8;
		}

		private static ASTType? djn(object object_0)
		{
			return ASTType.R4;
		}

		private static ASTType? Nj6(object object_0)
		{
			return ASTType.R8;
		}

		private static ASTType? njx(object object_0)
		{
			return ASTType.O;
		}

		private static ASTType? njs(ILASTExpression ilastexpression_0)
		{
			IMethod method = (IMethod)ilastexpression_0.Operand;
			if (method.MethodSig.RetType.ElementType == ElementType.Void)
			{
				return null;
			}
			GenericArguments genericArguments = new GenericArguments();
			if (method is MethodSpec)
			{
				genericArguments.PushMethodArgs(((MethodSpec)method).GenericInstMethodSig.GenericArguments);
			}
			if (method.DeclaringType.TryGetGenericInstSig() != null)
			{
				genericArguments.PushTypeArgs(method.DeclaringType.TryGetGenericInstSig().GenericArguments);
			}
			return TypeInference.smethod_0(genericArguments.ResolveType(method.MethodSig.RetType));
		}
	}
}
