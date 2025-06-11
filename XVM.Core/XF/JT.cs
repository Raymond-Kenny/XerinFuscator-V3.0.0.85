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
	internal sealed class JT : CategoryAttribute
	{
		private string tS = string.Empty;

		public JT(string string_0)
			: base(string_0)
		{
		}

		public JT(string string_0, string string_1)
			: base(string_0)
		{
			tS = string_1;
		}

		protected override string GetLocalizedString(string value)
		{
			if (tS.Length <= 0)
			{
				return SU.Sd(value);
			}
			ResourceManager resourceManager = new ResourceManager(tS, Assembly.GetExecutingAssembly());
			string text = resourceManager.GetString(value);
			Debug.Assert(text != null, string.Format(CultureInfo.CurrentCulture, "String resource {0} not found.", new object[1] { value }));
			return text;
		}
	}
}
