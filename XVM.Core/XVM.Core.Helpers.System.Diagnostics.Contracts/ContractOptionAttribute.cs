using System;
using System.Diagnostics;

namespace XVM.Core.Helpers.System.Diagnostics.Contracts
{
	[Conditional("CONTRACTS_FULL")]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
	public sealed class ContractOptionAttribute : Attribute
	{
		private string tOn;

		private string BO6;

		private bool EOx;

		private string dOs;

		public string Category => tOn;

		public string Setting => BO6;

		public bool Enabled => EOx;

		public string Value => dOs;

		public ContractOptionAttribute(string string_0, string string_1, bool bool_0)
		{
			tOn = string_0;
			BO6 = string_1;
			EOx = bool_0;
		}

		public ContractOptionAttribute(string string_0, string string_1, string string_2)
		{
			tOn = string_0;
			BO6 = string_1;
			dOs = string_2;
		}
	}
}
