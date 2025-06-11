using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;

namespace XVM.Core.ILAST.Transformation
{
	public class IndirectTransform : ITransformationHandler
	{
		public void Initialize(ILASTTransformer ilasttransformer_0)
		{
		}

		public void Transform(ILASTTransformer ilasttransformer_0)
		{
			ilasttransformer_0.aja().TraverseTree(LjQ, ilasttransformer_0.Method.Module);
		}

		private static void LjQ(ILASTExpression ilastexpression_0, ModuleDef moduleDef_0)
		{
			switch (ilastexpression_0.ILCode)
			{
			case Code.Stind_I:
				ilastexpression_0.ILCode = Code.Stobj;
				ilastexpression_0.Operand = moduleDef_0.CorLibTypes.IntPtr.ToTypeDefOrRef();
				break;
			case Code.Ldind_I1:
				ilastexpression_0.ILCode = Code.Ldobj;
				ilastexpression_0.Operand = moduleDef_0.CorLibTypes.SByte.ToTypeDefOrRef();
				ilastexpression_0.Arguments = new IILASTNode[1] { ilastexpression_0.Clone() };
				ilastexpression_0.ILCode = Code.Conv_I1;
				break;
			case Code.Ldind_U1:
				ilastexpression_0.ILCode = Code.Ldobj;
				ilastexpression_0.Operand = moduleDef_0.CorLibTypes.Byte.ToTypeDefOrRef();
				break;
			case Code.Ldind_I2:
				ilastexpression_0.ILCode = Code.Ldobj;
				ilastexpression_0.Operand = moduleDef_0.CorLibTypes.Int16.ToTypeDefOrRef();
				ilastexpression_0.Arguments = new IILASTNode[1] { ilastexpression_0.Clone() };
				ilastexpression_0.ILCode = Code.Conv_I2;
				break;
			case Code.Ldind_U2:
				ilastexpression_0.ILCode = Code.Ldobj;
				ilastexpression_0.Operand = moduleDef_0.CorLibTypes.UInt16.ToTypeDefOrRef();
				break;
			case Code.Ldind_I4:
				ilastexpression_0.ILCode = Code.Ldobj;
				ilastexpression_0.Operand = moduleDef_0.CorLibTypes.Int32.ToTypeDefOrRef();
				break;
			case Code.Ldind_U4:
				ilastexpression_0.ILCode = Code.Ldobj;
				ilastexpression_0.Operand = moduleDef_0.CorLibTypes.UInt32.ToTypeDefOrRef();
				break;
			case Code.Ldind_I8:
				ilastexpression_0.ILCode = Code.Ldobj;
				ilastexpression_0.Operand = moduleDef_0.CorLibTypes.UInt64.ToTypeDefOrRef();
				break;
			case Code.Ldind_I:
				ilastexpression_0.ILCode = Code.Ldobj;
				ilastexpression_0.Operand = moduleDef_0.CorLibTypes.IntPtr.ToTypeDefOrRef();
				break;
			case Code.Ldind_R4:
				ilastexpression_0.ILCode = Code.Ldobj;
				ilastexpression_0.Operand = moduleDef_0.CorLibTypes.Single.ToTypeDefOrRef();
				break;
			case Code.Ldind_R8:
				ilastexpression_0.ILCode = Code.Ldobj;
				ilastexpression_0.Operand = moduleDef_0.CorLibTypes.Double.ToTypeDefOrRef();
				break;
			case Code.Ldind_Ref:
				ilastexpression_0.ILCode = Code.Ldobj;
				ilastexpression_0.Operand = moduleDef_0.CorLibTypes.Object.ToTypeDefOrRef();
				break;
			case Code.Stind_Ref:
				ilastexpression_0.ILCode = Code.Stobj;
				ilastexpression_0.Operand = moduleDef_0.CorLibTypes.Object.ToTypeDefOrRef();
				break;
			case Code.Stind_I1:
				ilastexpression_0.ILCode = Code.Stobj;
				ilastexpression_0.Operand = moduleDef_0.CorLibTypes.SByte.ToTypeDefOrRef();
				break;
			case Code.Stind_I2:
				ilastexpression_0.ILCode = Code.Stobj;
				ilastexpression_0.Operand = moduleDef_0.CorLibTypes.Int16.ToTypeDefOrRef();
				break;
			case Code.Stind_I4:
				ilastexpression_0.ILCode = Code.Stobj;
				ilastexpression_0.Operand = moduleDef_0.CorLibTypes.Int32.ToTypeDefOrRef();
				break;
			case Code.Stind_I8:
				ilastexpression_0.ILCode = Code.Stobj;
				ilastexpression_0.Operand = moduleDef_0.CorLibTypes.UInt64.ToTypeDefOrRef();
				break;
			case Code.Stind_R4:
				ilastexpression_0.ILCode = Code.Stobj;
				ilastexpression_0.Operand = moduleDef_0.CorLibTypes.Single.ToTypeDefOrRef();
				break;
			case Code.Stind_R8:
				ilastexpression_0.ILCode = Code.Stobj;
				ilastexpression_0.Operand = moduleDef_0.CorLibTypes.Double.ToTypeDefOrRef();
				break;
			}
		}
	}
}
