namespace XVM.Core.ILAST
{
	public interface ITransformationHandler
	{
		void Initialize(ILASTTransformer ilasttransformer_0);

		void Transform(ILASTTransformer ilasttransformer_0);
	}
}
