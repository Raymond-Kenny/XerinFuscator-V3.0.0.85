using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace XF
{
	[CompilerGenerated]
	[DebuggerDisplay("\\{ Instr = {Instr}, Block = {Block} }", Type = "<Anonymous Type>")]
	internal sealed class zE<kN, P2>
	{
		private readonly kN Gm;

		private readonly P2 e5;

		internal static object aeZ8;

		[SpecialName]
		public kN nL()
		{
			return Gm;
		}

		[SpecialName]
		public P2 VH()
		{
			return e5;
		}

		public zE(kN Kt, P2 Fc)
		{
			Gm = Kt;
			e5 = Fc;
		}

		public override bool Equals(object obj)
		{
			zE<kN, P2> zE2 = obj as zE<kN, P2>;
			return this == zE2 || (zE2 != null && EqualityComparer<kN>.Default.Equals(Gm, zE2.Gm) && EqualityComparer<P2>.Default.Equals(e5, zE2.e5));
		}

		public override int GetHashCode()
		{
			return (1455532405 + EqualityComparer<kN>.Default.GetHashCode(Gm)) * -1521134295 + EqualityComparer<P2>.Default.GetHashCode(e5);
		}

		public override string ToString()
		{
			object[] array = new object[2];
			kN val = Gm;
			array[0] = ((val != null) ? val.ToString() : null);
			P2 val2 = e5;
			array[1] = ((val2 == null) ? null : val2.ToString());
			return string.Format(null, "{{ Instr = {0}, Block = {1} }}", array);
		}

		internal static bool LeZz()
		{
			return aeZ8 == null;
		}

		internal static object geT4()
		{
			return aeZ8;
		}
	}
}
