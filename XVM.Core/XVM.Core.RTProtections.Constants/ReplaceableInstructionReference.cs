using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XVM.Core.RTProtections.Constants
{
	public class ReplaceableInstructionReference
	{
		[CompilerGenerated]
		private IMethod d1Y;

		[CompilerGenerated]
		private Instruction U1g;

		[CompilerGenerated]
		private uint e1V;

		[CompilerGenerated]
		private uint N1b;

		public IMethod Decoder
		{
			[CompilerGenerated]
			get
			{
				return d1Y;
			}
			[CompilerGenerated]
			set
			{
				d1Y = value;
			}
		}

		public Instruction Target
		{
			[CompilerGenerated]
			get
			{
				return U1g;
			}
			[CompilerGenerated]
			set
			{
				U1g = value;
			}
		}

		public uint Id
		{
			[CompilerGenerated]
			get
			{
				return e1V;
			}
			[CompilerGenerated]
			set
			{
				e1V = value;
			}
		}

		public uint Key
		{
			[CompilerGenerated]
			get
			{
				return N1b;
			}
			[CompilerGenerated]
			set
			{
				N1b = value;
			}
		}
	}
}
