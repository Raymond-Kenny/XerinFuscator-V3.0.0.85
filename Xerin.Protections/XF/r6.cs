using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace XF
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class r6
	{
		private static ResourceManager pO;

		private static CultureInfo Gu;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager sA
		{
			get
			{
				if (pO == null)
				{
					ResourceManager resourceManager = new ResourceManager("Xerin.Protections.Properties.Resources", typeof(r6).Assembly);
					pO = resourceManager;
				}
				return pO;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo rT
		{
			get
			{
				return Gu;
			}
			set
			{
				Gu = value;
			}
		}

		internal r6()
		{
		}

		[SpecialName]
		internal static byte[] dZ()
		{
			object obj = sA.GetObject("Bin", Gu);
			return (byte[])obj;
		}

		[SpecialName]
		internal static byte[] RD()
		{
			object obj = sA.GetObject("pHelper", Gu);
			return (byte[])obj;
		}
	}
}
