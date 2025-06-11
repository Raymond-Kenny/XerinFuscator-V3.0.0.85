using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;

namespace XVM.Core.ILAST.Transformation
{
	public class StringTransform : ITransformationHandler
	{
		public void Initialize(ILASTTransformer ilasttransformer_0)
		{
		}

		public void Transform(ILASTTransformer ilasttransformer_0)
		{
			ilasttransformer_0.aja().TraverseTree(xji, ilasttransformer_0);
		}

		private static void xji(ILASTExpression ilastexpression_0, ILASTTransformer ilasttransformer_0)
		{
			if (ilastexpression_0.ILCode == Code.Ldstr)
			{
				string s = (string)ilastexpression_0.Operand;
				ilastexpression_0.ILCode = Code.Box;
				ilastexpression_0.Operand = ilasttransformer_0.Method.Module.CorLibTypes.String.ToTypeDefOrRef();
				ilastexpression_0.Arguments = new IILASTNode[1]
				{
					new ILASTExpression
					{
						ILCode = Code.Ldc_I4,
						Operand = (int)ilasttransformer_0.VM.Data.GetId(Encoding.Unicode.GetBytes(s)),
						Arguments = new IILASTNode[0]
					}
				};
			}
		}
	}
}
