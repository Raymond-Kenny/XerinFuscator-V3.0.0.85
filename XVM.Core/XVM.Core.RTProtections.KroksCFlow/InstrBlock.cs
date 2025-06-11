using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using dnlib.DotNet.Emit;

namespace XVM.Core.RTProtections.KroksCFlow
{
	public class InstrBlock : BlockBase
	{
		[CompilerGenerated]
		private List<Instruction> n19;

		public List<Instruction> Instructions
		{
			[CompilerGenerated]
			get
			{
				return n19;
			}
			[CompilerGenerated]
			set
			{
				n19 = value;
			}
		}

		public InstrBlock()
			: base(BlockType.Normal)
		{
			Instructions = new List<Instruction>();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Instruction instruction in Instructions)
			{
				stringBuilder.AppendLine(instruction.ToString());
			}
			return stringBuilder.ToString();
		}

		public override void ToBody(CilBody cilBody_0)
		{
			foreach (Instruction instruction in Instructions)
			{
				cilBody_0.Instructions.Add(instruction);
			}
		}
	}
}
