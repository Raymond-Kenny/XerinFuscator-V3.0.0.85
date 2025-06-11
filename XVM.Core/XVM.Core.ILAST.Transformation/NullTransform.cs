using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;

namespace XVM.Core.ILAST.Transformation
{
	public class NullTransform : ITransformationHandler
	{
		public void Initialize(ILASTTransformer ilasttransformer_0)
		{
		}

		public void Transform(ILASTTransformer ilasttransformer_0)
		{
			ilasttransformer_0.aja().TraverseTree(Sjf, ilasttransformer_0);
		}

		private static void Sjf(ILASTExpression ilastexpression_0, object object_0)
		{
			if (ilastexpression_0.ILCode == Code.Ldnull)
			{
				ilastexpression_0.ILCode = Code.Ldc_I4;
				ilastexpression_0.Operand = 0;
			}
		}
	}
}
