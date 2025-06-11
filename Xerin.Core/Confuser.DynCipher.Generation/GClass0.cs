using System.Runtime.CompilerServices;

namespace Confuser.DynCipher.Generation
{
	public class GClass0 : Ix86Operand
	{
		[CompilerGenerated]
		private x86Register UCU;

		public x86Register Register
		{
			[CompilerGenerated]
			get
			{
				return UCU;
			}
			[CompilerGenerated]
			set
			{
				UCU = value;
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
