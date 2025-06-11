#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace XF
{
	[AttributeUsage(AttributeTargets.All)]
	internal sealed class UZ : DescriptionAttribute
	{
		public UZ(string string_0)
		{
			base.DescriptionValue = SU.Sd(string_0);
		}

		public UZ(string string_0, string string_1)
		{
			ResourceManager resourceManager = new ResourceManager(string_1, Assembly.GetExecutingAssembly());
			base.DescriptionValue = resourceManager.GetString(string_0);
			Debug.Assert(base.DescriptionValue != null, string.Format(CultureInfo.CurrentCulture, "String resource {0} not found.", new object[1] { string_0 }));
		}
	}
}
