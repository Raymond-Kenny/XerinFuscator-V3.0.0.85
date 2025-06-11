using System.Runtime.CompilerServices;

namespace XVM.DynCipher.Generation
{
	public class GClass1 : Ix86Operand
	{
		[CompilerGenerated]
		private int yuV;

		public int Immediate
		{
			[CompilerGenerated]
			get
			{
				return yuV;
			}
			[CompilerGenerated]
			set
			{
				yuV = value;
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
