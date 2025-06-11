#define DEBUG
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

namespace XF
{
	internal sealed class SU
	{
		private static SU xy;

		private ResourceManager iY;

		internal SU()
		{
			iY = new ResourceManager("System.Workflow.ComponentModel.StringResources", Assembly.GetExecutingAssembly());
		}

		private static SU UP()
		{
			if (xy == null)
			{
				xy = new SU();
			}
			return xy;
		}

		[SpecialName]
		private static CultureInfo X7()
		{
			return null;
		}

		internal static string wF(string string_0, params object[] args)
		{
			return kv(X7(), string_0, args);
		}

		internal static string kv(CultureInfo cultureInfo_0, string string_0, params object[] args)
		{
			SU sU = UP();
			if (sU == null)
			{
				return null;
			}
			string text = sU.iY.GetString(string_0, cultureInfo_0);
			Debug.Assert(text != null, string.Format(CultureInfo.CurrentCulture, "String resource {0} not found.", new object[1] { string_0 }));
			if (args != null && args.Length != 0)
			{
				return string.Format(CultureInfo.CurrentCulture, text, args);
			}
			return text;
		}

		internal static string Sd(string string_0)
		{
			return CB(X7(), string_0);
		}

		internal static string CB(CultureInfo cultureInfo_0, string string_0)
		{
			SU sU = UP();
			if (sU == null)
			{
				return null;
			}
			string text = sU.iY.GetString(string_0, cultureInfo_0);
			Debug.Assert(text != null, string.Format(CultureInfo.CurrentCulture, "String resource {0} not found.", new object[1] { string_0 }));
			return text;
		}
	}
}
