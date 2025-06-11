using System;
using System.Diagnostics;

namespace XVM.Core.Helpers.System.Diagnostics.Contracts
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	[Conditional("CONTRACTS_FULL")]
	public sealed class ContractClassForAttribute : Attribute
	{
		private Type IOr;

		public Type TypeContractsAreFor => IOr;

		public ContractClassForAttribute(Type type_0)
		{
			IOr = type_0;
		}
	}
}
