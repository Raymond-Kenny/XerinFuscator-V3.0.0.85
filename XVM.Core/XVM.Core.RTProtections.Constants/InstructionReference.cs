using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XVM.Core.RTProtections.Constants
{
	public class InstructionReference
	{
		[CompilerGenerated]
		private MethodDef K1F;

		[CompilerGenerated]
		private Instruction G1v;

		public MethodDef Method
		{
			[CompilerGenerated]
			get
			{
				return K1F;
			}
			[CompilerGenerated]
			set
			{
				K1F = value;
			}
		}

		public Instruction Instruction
		{
			[CompilerGenerated]
			get
			{
				return G1v;
			}
			[CompilerGenerated]
			set
			{
				G1v = value;
			}
		}
	}
}
