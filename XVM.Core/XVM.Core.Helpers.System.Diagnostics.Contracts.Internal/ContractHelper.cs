using System;
using System.Runtime.ConstrainedExecution;
using XVM.Core.Helpers.System.Runtime.CompilerServices;

namespace XVM.Core.Helpers.System.Diagnostics.Contracts.Internal
{
	[Obsolete("Use the ContractHelper class in the System.Runtime.CompilerServices namespace instead.")]
	public static class ContractHelper
	{
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static string RaiseContractFailedEvent(ContractFailureKind contractFailureKind_0, string string_0, string string_1, Exception exception_0)
		{
			return XVM.Core.Helpers.System.Runtime.CompilerServices.ContractHelper.RaiseContractFailedEvent(contractFailureKind_0, string_0, string_1, exception_0);
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static void TriggerFailure(ContractFailureKind contractFailureKind_0, string string_0, string string_1, string string_2, Exception exception_0)
		{
			XVM.Core.Helpers.System.Runtime.CompilerServices.ContractHelper.TriggerFailure(contractFailureKind_0, string_0, string_1, string_2, exception_0);
		}
	}
}
