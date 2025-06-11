using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.ILAST;

namespace XVM.Core.ILAST.Transformation
{
	public class ArrayTransform : ITransformationHandler
	{
		public void Initialize(ILASTTransformer ilasttransformer_0)
		{
		}

		public void Transform(ILASTTransformer ilasttransformer_0)
		{
			ModuleDef module = ilasttransformer_0.Method.Module;
			ilasttransformer_0.aja().TraverseTree(Xj7, module);
			for (int i = 0; i < ilasttransformer_0.aja().Count; i++)
			{
				IILASTStatement iilaststatement_ = ilasttransformer_0.aja()[i];
				ILASTExpression expression = VariableInlining.GetExpression(iilaststatement_);
				if (expression != null)
				{
					switch (expression.ILCode)
					{
					case Code.Stelem_I:
						ojy(expression, module, module.CorLibTypes.IntPtr.ToTypeDefOrRef(), ilasttransformer_0.aja(), ref i);
						break;
					case Code.Stelem_I1:
						ojy(expression, module, module.CorLibTypes.SByte.ToTypeDefOrRef(), ilasttransformer_0.aja(), ref i);
						break;
					case Code.Stelem_I2:
						ojy(expression, module, module.CorLibTypes.Int16.ToTypeDefOrRef(), ilasttransformer_0.aja(), ref i);
						break;
					case Code.Stelem_I4:
						ojy(expression, module, module.CorLibTypes.Int32.ToTypeDefOrRef(), ilasttransformer_0.aja(), ref i);
						break;
					case Code.Stelem_I8:
						ojy(expression, module, module.CorLibTypes.Int64.ToTypeDefOrRef(), ilasttransformer_0.aja(), ref i);
						break;
					case Code.Stelem_R4:
						ojy(expression, module, module.CorLibTypes.Single.ToTypeDefOrRef(), ilasttransformer_0.aja(), ref i);
						break;
					case Code.Stelem_R8:
						ojy(expression, module, module.CorLibTypes.Double.ToTypeDefOrRef(), ilasttransformer_0.aja(), ref i);
						break;
					case Code.Stelem_Ref:
						ojy(expression, module, module.CorLibTypes.Object.ToTypeDefOrRef(), ilasttransformer_0.aja(), ref i);
						break;
					case Code.Stelem:
						ojy(expression, module, (ITypeDefOrRef)expression.Operand, ilasttransformer_0.aja(), ref i);
						break;
					}
				}
			}
		}

		private static void Xj7(ILASTExpression ilastexpression_0, ModuleDef moduleDef_0)
		{
			switch (ilastexpression_0.ILCode)
			{
			case Code.Newarr:
			{
				ilastexpression_0.ILCode = Code.Newobj;
				ITypeDefOrRef typeDefOrRef2 = new SZArraySig(((ITypeDefOrRef)ilastexpression_0.Operand).ToTypeSig()).ToTypeDefOrRef();
				MethodSig sig3 = MethodSig.CreateInstance(moduleDef_0.CorLibTypes.Void, moduleDef_0.CorLibTypes.Int32);
				MemberRefUser operand3 = new MemberRefUser(moduleDef_0, ".ctor", sig3, typeDefOrRef2);
				ilastexpression_0.Operand = operand3;
				break;
			}
			case Code.Ldlen:
			{
				ilastexpression_0.ILCode = Code.Call;
				TypeRef typeRef = moduleDef_0.CorLibTypes.GetTypeRef("System", "Array");
				MethodSig sig2 = MethodSig.CreateInstance(moduleDef_0.CorLibTypes.Int32);
				MemberRefUser operand2 = new MemberRefUser(moduleDef_0, "get_Length", sig2, typeRef);
				ilastexpression_0.Operand = operand2;
				break;
			}
			case Code.Ldelema:
			{
				ilastexpression_0.ILCode = Code.Call;
				TypeSig nextSig = ((ITypeDefOrRef)ilastexpression_0.Operand).ToTypeSig();
				ITypeDefOrRef typeDefOrRef = new SZArraySig(nextSig).ToTypeDefOrRef();
				MethodSig sig = MethodSig.CreateInstance(new ByRefSig(nextSig), moduleDef_0.CorLibTypes.Int32);
				MemberRefUser operand = new MemberRefUser(moduleDef_0, "Address", sig, typeDefOrRef);
				ilastexpression_0.Operand = operand;
				break;
			}
			case Code.Ldelem_I1:
				OjD(ilastexpression_0, moduleDef_0, moduleDef_0.CorLibTypes.SByte.ToTypeDefOrRef());
				break;
			case Code.Ldelem_U1:
				OjD(ilastexpression_0, moduleDef_0, moduleDef_0.CorLibTypes.Byte.ToTypeDefOrRef());
				break;
			case Code.Ldelem_I2:
				OjD(ilastexpression_0, moduleDef_0, moduleDef_0.CorLibTypes.Int16.ToTypeDefOrRef());
				break;
			case Code.Ldelem_U2:
				OjD(ilastexpression_0, moduleDef_0, moduleDef_0.CorLibTypes.UInt16.ToTypeDefOrRef());
				break;
			case Code.Ldelem_I4:
				OjD(ilastexpression_0, moduleDef_0, moduleDef_0.CorLibTypes.Int32.ToTypeDefOrRef());
				break;
			case Code.Ldelem_U4:
				OjD(ilastexpression_0, moduleDef_0, moduleDef_0.CorLibTypes.UInt32.ToTypeDefOrRef());
				break;
			case Code.Ldelem_I8:
				OjD(ilastexpression_0, moduleDef_0, moduleDef_0.CorLibTypes.Int64.ToTypeDefOrRef());
				break;
			case Code.Ldelem_I:
				OjD(ilastexpression_0, moduleDef_0, moduleDef_0.CorLibTypes.IntPtr.ToTypeDefOrRef());
				break;
			case Code.Ldelem_R4:
				OjD(ilastexpression_0, moduleDef_0, moduleDef_0.CorLibTypes.Single.ToTypeDefOrRef());
				break;
			case Code.Ldelem_R8:
				OjD(ilastexpression_0, moduleDef_0, moduleDef_0.CorLibTypes.Double.ToTypeDefOrRef());
				break;
			case Code.Ldelem_Ref:
				OjD(ilastexpression_0, moduleDef_0, moduleDef_0.CorLibTypes.Object.ToTypeDefOrRef());
				break;
			case Code.Ldelem:
				OjD(ilastexpression_0, moduleDef_0, (ITypeDefOrRef)ilastexpression_0.Operand);
				break;
			case Code.Stelem_I:
			case Code.Stelem_I1:
			case Code.Stelem_I2:
			case Code.Stelem_I4:
			case Code.Stelem_I8:
			case Code.Stelem_R4:
			case Code.Stelem_R8:
			case Code.Stelem_Ref:
				break;
			}
		}

		private static void OjD(object object_0, ModuleDef moduleDef_0, object object_1)
		{
			TypeRef typeRef = moduleDef_0.CorLibTypes.GetTypeRef("System", "Array");
			MethodSig sig = MethodSig.CreateInstance(moduleDef_0.CorLibTypes.Object, moduleDef_0.CorLibTypes.Int32);
			MemberRefUser operand = new MemberRefUser(moduleDef_0, "GetValue", sig, typeRef);
			ILASTExpression iLASTExpression = new ILASTExpression
			{
				ILCode = Code.Call,
				Operand = operand,
				Arguments = ((ILASTExpression)object_0).Arguments
			};
			((ILASTExpression)object_0).ILCode = Code.Unbox_Any;
			((ILASTExpression)object_0).Operand = ((!((IType)object_1).IsValueType) ? object_1 : moduleDef_0.CorLibTypes.Object.ToTypeDefOrRef());
			((ASTExpression)object_0).Type = TypeInference.smethod_0(((ITypeDefOrRef)object_1).ToTypeSig());
			((ILASTExpression)object_0).Arguments = new IILASTNode[1] { iLASTExpression };
		}

		private static void ojy(ILASTExpression ilastexpression_0, ModuleDef moduleDef_0, IType itype_0, List<IILASTStatement> list_0, ref int int_0)
		{
			TypeRef typeRef = moduleDef_0.CorLibTypes.GetTypeRef("System", "Array");
			MethodSig sig = MethodSig.CreateInstance(moduleDef_0.CorLibTypes.Void, moduleDef_0.CorLibTypes.Object, moduleDef_0.CorLibTypes.Int32);
			MemberRefUser operand = new MemberRefUser(moduleDef_0, "SetValue", sig, typeRef);
			ILASTVariable iLASTVariable;
			if (ilastexpression_0.Arguments[1] is ILASTVariable)
			{
				iLASTVariable = (ILASTVariable)ilastexpression_0.Arguments[1];
			}
			else
			{
				iLASTVariable = new ILASTVariable
				{
					Name = $"arr_{ilastexpression_0.CILInstr.Offset:x4}_1",
					VariableType = ILASTVariableType.StackVar
				};
				list_0.Insert(int_0++, new ILASTAssignment
				{
					Variable = iLASTVariable,
					Value = (ILASTExpression)ilastexpression_0.Arguments[1]
				});
			}
			ILASTVariable iLASTVariable2;
			if (!(ilastexpression_0.Arguments[2] is ILASTVariable))
			{
				iLASTVariable2 = new ILASTVariable
				{
					Name = $"arr_{ilastexpression_0.CILInstr.Offset:x4}_2",
					VariableType = ILASTVariableType.StackVar
				};
				list_0.Insert(int_0++, new ILASTAssignment
				{
					Variable = iLASTVariable2,
					Value = (ILASTExpression)ilastexpression_0.Arguments[2]
				});
			}
			else
			{
				iLASTVariable2 = (ILASTVariable)ilastexpression_0.Arguments[2];
			}
			if (itype_0.IsPrimitive)
			{
				ILASTExpression iLASTExpression = new ILASTExpression();
				iLASTExpression.ILCode = Code.Box;
				iLASTExpression.Operand = itype_0;
				IILASTNode[] arguments = new ILASTVariable[1] { iLASTVariable2 };
				iLASTExpression.Arguments = arguments;
				ILASTExpression iLASTExpression2 = iLASTExpression;
				ilastexpression_0.Arguments[2] = iLASTVariable;
				ilastexpression_0.Arguments[1] = iLASTExpression2;
			}
			else
			{
				ilastexpression_0.Arguments[2] = iLASTVariable;
				ilastexpression_0.Arguments[1] = iLASTVariable2;
			}
			ilastexpression_0.ILCode = Code.Call;
			ilastexpression_0.Operand = operand;
		}
	}
}
