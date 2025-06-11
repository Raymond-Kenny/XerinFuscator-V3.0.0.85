using System.Runtime.CompilerServices;
using dnlib.DotNet;

namespace XVM.Core.RTProtections.Constants
{
	public class DecoderInfo
	{
		[CompilerGenerated]
		private MethodDef b1Z;

		[CompilerGenerated]
		private DecoderDesc f1T;

		public MethodDef Method
		{
			[CompilerGenerated]
			get
			{
				return b1Z;
			}
			[CompilerGenerated]
			set
			{
				b1Z = value;
			}
		}

		public DecoderDesc DecoderDesc
		{
			[CompilerGenerated]
			get
			{
				return f1T;
			}
			[CompilerGenerated]
			set
			{
				f1T = value;
			}
		}
	}
}
