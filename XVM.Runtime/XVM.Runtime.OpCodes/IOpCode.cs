using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal interface IOpCode
	{
		byte Code { get; }

		void Run(VMContext ctx, out ExecutionState state);
	}
}
