using System;
using System.Collections.Generic;

namespace XVM.Core.Helpers.System.Runtime.CompilerServices
{
	[CLSCompliant(false)]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
	public sealed class TupleElementNamesAttribute : Attribute
	{
		private readonly string[] OOY;

		public IList<string> TransformNames => OOY;

		public TupleElementNamesAttribute(string[] string_0)
		{
			if (string_0 == null)
			{
				throw new ArgumentNullException("transformNames");
			}
			OOY = string_0;
		}
	}
}
