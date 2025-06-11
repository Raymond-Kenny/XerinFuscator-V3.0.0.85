using System;
using System.Runtime.ConstrainedExecution;
using XVM.Core.Helpers.System.Diagnostics.Contracts;

namespace XVM.Core.Helpers.System.Runtime.CompilerServices
{
	public static class ContractHelper
	{
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static string RaiseContractFailedEvent(ContractFailureKind contractFailureKind_0, string string_0, string string_1, Exception exception_0)
		{
			return "Contract failed";
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static void TriggerFailure(ContractFailureKind contractFailureKind_0, string string_0, string string_1, string string_2, Exception exception_0)
		{
		}
	}
}
