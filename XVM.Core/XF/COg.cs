using System;

namespace XF
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = true, Inherited = false)]
	internal sealed class COg : Attribute
	{
		private string AOV;

		public COg(string string_0)
		{
			if (string_0 == null)
			{
				throw new ArgumentNullException("typeName");
			}
			AOV = string_0;
		}
	}
}
