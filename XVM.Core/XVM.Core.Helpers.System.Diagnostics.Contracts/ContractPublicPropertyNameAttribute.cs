using System;
using System.Diagnostics;

namespace XVM.Core.Helpers.System.Diagnostics.Contracts
{
	[Conditional("CONTRACTS_FULL")]
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class ContractPublicPropertyNameAttribute : Attribute
	{
		private string wOX;

		public string Name => wOX;

		public ContractPublicPropertyNameAttribute(string string_0)
		{
			wOX = string_0;
		}
	}
}
