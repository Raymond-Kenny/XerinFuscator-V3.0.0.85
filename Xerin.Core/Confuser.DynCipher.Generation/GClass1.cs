using System.Runtime.CompilerServices;

namespace Confuser.DynCipher.Generation
{
	public class GClass1 : Ix86Operand
	{
		[CompilerGenerated]
		private int BCY;

		public int Immediate
		{
			[CompilerGenerated]
			get
			{
				return BCY;
			}
			[CompilerGenerated]
			set
			{
				BCY = value;
			}
		}

		public GClass1(int int_0)
		{
			Immediate = int_0;
		}

		public override string ToString()
		{
			return Immediate.ToString("X") + "h";
		}
	}
}
