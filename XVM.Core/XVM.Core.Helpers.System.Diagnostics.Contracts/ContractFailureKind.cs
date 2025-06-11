namespace XVM.Core.Helpers.System.Diagnostics.Contracts
{
	public enum ContractFailureKind
	{
		Precondition,
		Postcondition,
		PostconditionOnException,
		Invariant,
		Assert,
		Assume
	}
}
