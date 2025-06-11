namespace XVM.Runtime.XVM.Runtime.Execution
{
	internal class EHState
	{
		public enum EHProcess
		{
			Searching,
			Unwinding
		}

		public EHProcess CurrentProcess;

		public object ExceptionObj;

		public VMSlot OldBP;

		public VMSlot OldSP;

		public int? CurrentFrame;

		public int? HandlerFrame;
	}
}
