using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace XF
{
	[DebuggerDisplay("\\{ number = {number}, name = {name} }", Type = "<Anonymous Type>")]
	[CompilerGenerated]
	internal sealed class jo<VD, wd>
	{
		private readonly VD ww;

		private readonly wd Fq;

		internal static object OAT;

		[SpecialName]
		public VD on()
		{
			return ww;
		}

		[SpecialName]
		public wd mr()
		{
			return Fq;
		}

		public jo(VD eK, wd q4)
		{
			ww = eK;
			Fq = q4;
		}

		public override bool Equals(object obj)
		{
			jo<VD, wd> jo2 = obj as jo<VD, wd>;
			return this == jo2 || (jo2 != null && EqualityComparer<VD>.Default.Equals(ww, jo2.ww) && EqualityComparer<wd>.Default.Equals(Fq, jo2.Fq));
		}

		public override int GetHashCode()
		{
			return (-1958435472 + EqualityComparer<VD>.Default.GetHashCode(ww)) * -1521134295 + EqualityComparer<wd>.Default.GetHashCode(Fq);
		}

		public override string ToString()
		{
			object[] array = new object[2];
			VD val = ww;
			array[0] = ((val != null) ? val.ToString() : null);
			wd val2 = Fq;
			array[1] = ((val2 == null) ? null : val2.ToString());
			return string.Format(null, "{{ number = {0}, name = {1} }}", array);
		}

		internal static bool YAi()
		{
			return OAT == null;
		}

		internal static object rAS()
		{
			return OAT;
		}
	}
}
