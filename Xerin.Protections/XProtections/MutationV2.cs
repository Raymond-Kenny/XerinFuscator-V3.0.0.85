using XCore.Context;
using XCore.Protections;
using XProtections.Mutation;

namespace XProtections
{
	public class MutationV2 : Protection
	{
		public override string name => "Aggressive mutation stage";

		public override int number => 3;

		public override void Execute(XContext xcontext_0)
		{
			new ThirdMutationStage().Execute(xcontext_0);
			new SecondMutationStage().Execute(xcontext_0);
		}
	}
}
