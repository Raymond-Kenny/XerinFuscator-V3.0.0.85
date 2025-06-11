using System.Runtime.CompilerServices;

namespace XVM.DynCipher.Generation
{
	public class GClass0 : Ix86Operand
	{
		[CompilerGenerated]
		private x86Register Dug;

		public x86Register Register
		{
			[CompilerGenerated]
			get
			{
				return Dug;
			}
			[CompilerGenerated]
			set
			{
				Dug = value;
			}
		}

		public GClass0(x86Register x86Register_0)
		{
			Register = x86Register_0;
		}

		public override string ToString()
		{
			return Register.ToString();
		}
	}
}
