using System;
using System.Diagnostics;

namespace XVM.Core.Helpers.System.Diagnostics.Contracts
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property)]
	[Conditional("CONTRACTS_FULL")]
	public sealed class ContractVerificationAttribute : Attribute
	{
		private bool iO3;

		public bool Value => iO3;

		public ContractVerificationAttribute(bool bool_0)
		{
			iO3 = bool_0;
		}
	}
}
