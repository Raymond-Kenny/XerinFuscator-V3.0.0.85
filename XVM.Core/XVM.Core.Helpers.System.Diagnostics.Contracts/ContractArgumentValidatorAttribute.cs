using System;
using System.Diagnostics;

namespace XVM.Core.Helpers.System.Diagnostics.Contracts
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	[Conditional("CONTRACTS_FULL")]
	public sealed class ContractArgumentValidatorAttribute : Attribute
	{
	}
}
