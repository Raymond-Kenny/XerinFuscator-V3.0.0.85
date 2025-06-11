using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.VCalls
{
	internal class Exit : IVCall
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.VCALL_EXIT;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			state = ExecutionState.Exit;
		}
	}
}
