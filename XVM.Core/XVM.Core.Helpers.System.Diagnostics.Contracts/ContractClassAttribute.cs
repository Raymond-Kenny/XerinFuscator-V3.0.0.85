using System;
using System.Diagnostics;

namespace XVM.Core.Helpers.System.Diagnostics.Contracts
{
	[Conditional("CONTRACTS_FULL")]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
	[Conditional("DEBUG")]
	public sealed class ContractClassAttribute : Attribute
	{
		private Type fOb;

		public Type TypeContainingContracts => fOb;

		public ContractClassAttribute(Type type_0)
		{
			fOb = type_0;
		}
	}
}
