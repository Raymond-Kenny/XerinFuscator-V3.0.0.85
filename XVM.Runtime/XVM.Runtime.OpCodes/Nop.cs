using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime.OpCodes
{
	internal class Nop : IOpCode
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.OP_NOP;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			state = ExecutionState.Next;
		}
	}
}
