namespace XVM.Core.VMIL
{
	public interface IPostTransform
	{
		void Initialize(ILPostTransformer ilpostTransformer_0);

		void Transform(ILPostTransformer ilpostTransformer_0);
	}
}
