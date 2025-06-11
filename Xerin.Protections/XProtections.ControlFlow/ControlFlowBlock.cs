using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet.Emit;

namespace XProtections.ControlFlow
{
	public class ControlFlowBlock
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class i7h
		{
			public static readonly i7h b7N;

			public static Func<ControlFlowBlock, string> w7P;

			static i7h()
			{
				b7N = new i7h();
			}

			internal string p75(ControlFlowBlock controlFlowBlock_0)
			{
				return controlFlowBlock_0.Id.ToString();
			}
		}

		public readonly Instruction Footer;

		public readonly Instruction Header;

		public readonly int Id;

		public readonly ControlFlowBlockType Type;

		[CompilerGenerated]
		private IList<ControlFlowBlock> D99;

		[CompilerGenerated]
		private IList<ControlFlowBlock> R9w;

		public IList<ControlFlowBlock> Sources
		{
			[CompilerGenerated]
			get
			{
				return D99;
			}
			[CompilerGenerated]
			private set
			{
				D99 = value;
			}
		}

		public IList<ControlFlowBlock> Targets
		{
			[CompilerGenerated]
			get
			{
				return R9w;
			}
			[CompilerGenerated]
			private set
			{
				R9w = value;
			}
		}

		internal ControlFlowBlock(int int_0, ControlFlowBlockType controlFlowBlockType_0, Instruction instruction_0, Instruction instruction_1)
		{
			Id = int_0;
			Type = controlFlowBlockType_0;
			Header = instruction_0;
			Footer = instruction_1;
			Sources = new List<ControlFlowBlock>();
			Targets = new List<ControlFlowBlock>();
		}

		public override string ToString()
		{
			return string.Format("Block {0} => {1} {2}", Id, Type, string.Join(", ", Targets.Select((ControlFlowBlock controlFlowBlock_0) => controlFlowBlock_0.Id.ToString()).ToArray()));
		}
	}
}
