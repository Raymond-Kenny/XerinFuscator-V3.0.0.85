using System;
using dnlib.DotNet;

namespace XVM.Core.AST
{
	public static class TypeInference
	{
		public static ASTType smethod_0(TypeSig typeSig_0)
		{
			switch (typeSig_0.ElementType)
			{
			case ElementType.Boolean:
			case ElementType.Char:
			case ElementType.I1:
			case ElementType.U1:
			case ElementType.I2:
			case ElementType.U2:
			case ElementType.I4:
			case ElementType.U4:
				return ASTType.I4;
			case ElementType.I8:
			case ElementType.U8:
				return ASTType.I8;
			case ElementType.R4:
				return ASTType.R4;
			case ElementType.R8:
				return ASTType.R8;
			case ElementType.ByRef:
				return ASTType.ByRef;
			case ElementType.ValueType:
			{
				TypeDef typeDef = typeSig_0.ScopeType.ResolveTypeDef();
				if (typeDef != null && typeDef.IsEnum)
				{
					return smethod_0(typeDef.GetEnumUnderlyingType());
				}
				return ASTType.O;
			}
			default:
				return ASTType.O;
			case ElementType.Ptr:
			case ElementType.I:
			case ElementType.U:
			case ElementType.FnPtr:
				return ASTType.Ptr;
			}
		}

		public static ASTType InferBinaryOp(ASTType asttype_0, ASTType asttype_1)
		{
			if (asttype_0 != asttype_1 || (asttype_0 != ASTType.I4 && asttype_0 != ASTType.I8 && asttype_0 != ASTType.R4 && asttype_0 != ASTType.R8))
			{
				if ((asttype_0 == ASTType.Ptr && (asttype_1 == ASTType.I4 || asttype_1 == ASTType.I8 || asttype_1 == ASTType.Ptr)) || (asttype_1 == ASTType.Ptr && (asttype_0 == ASTType.I4 || asttype_1 == ASTType.I4 || asttype_0 == ASTType.Ptr)))
				{
					return ASTType.Ptr;
				}
				if ((asttype_0 == ASTType.ByRef && (asttype_1 == ASTType.I4 || asttype_1 == ASTType.Ptr)) || (asttype_1 == ASTType.ByRef && (asttype_0 == ASTType.I4 || asttype_0 == ASTType.Ptr)))
				{
					return ASTType.ByRef;
				}
				if (asttype_0 == ASTType.ByRef && asttype_1 == ASTType.ByRef)
				{
					return ASTType.Ptr;
				}
				throw new ArgumentException("Invalid Binary Op Operand Types.");
			}
			return asttype_0;
		}

		public static ASTType InferIntegerOp(ASTType asttype_0, ASTType asttype_1)
		{
			if (asttype_0 == asttype_1 && (asttype_0 == ASTType.I4 || asttype_0 == ASTType.I8 || asttype_0 == ASTType.R4 || asttype_0 == ASTType.R8))
			{
				return asttype_0;
			}
			if ((asttype_0 == ASTType.Ptr && (asttype_1 == ASTType.I4 || asttype_1 == ASTType.I8 || asttype_1 == ASTType.Ptr)) || (asttype_1 == ASTType.Ptr && (asttype_0 == ASTType.I4 || asttype_1 == ASTType.I8 || asttype_0 == ASTType.Ptr)))
			{
				return ASTType.Ptr;
			}
			throw new ArgumentException("Invalid Integer Op Operand Types.");
		}

		public static ASTType InferShiftOp(ASTType asttype_0, ASTType asttype_1)
		{
			if ((asttype_1 != ASTType.Ptr && asttype_1 != ASTType.I4) || (asttype_0 != ASTType.I4 && asttype_1 != ASTType.I4 && asttype_0 != ASTType.Ptr))
			{
				throw new ArgumentException("Invalid Shift Op Operand Types.");
			}
			return asttype_0;
		}
	}
}
