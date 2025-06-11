using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace XVM.Core.CFG
{
	public class BasicBlock<TContent> : IBasicBlock
	{
		[CompilerGenerated]
		private int Otw;

		[CompilerGenerated]
		private TContent BtW;

		[CompilerGenerated]
		private BlockFlags UtE;

		[CompilerGenerated]
		private IList<BasicBlock<TContent>> rtN;

		[CompilerGenerated]
		private IList<BasicBlock<TContent>> Wt2;

		internal static object gero;

		public int Id
		{
			[CompilerGenerated]
			get
			{
				return Otw;
			}
			[CompilerGenerated]
			set
			{
				Otw = value;
			}
		}

		public TContent Content
		{
			[CompilerGenerated]
			get
			{
				return BtW;
			}
			[CompilerGenerated]
			set
			{
				BtW = value;
			}
		}

		public BlockFlags Flags
		{
			[CompilerGenerated]
			get
			{
				return UtE;
			}
			[CompilerGenerated]
			set
			{
				UtE = value;
			}
		}

		public IList<BasicBlock<TContent>> Sources
		{
			[CompilerGenerated]
			get
			{
				return rtN;
			}
			[CompilerGenerated]
			private set
			{
				rtN = value;
			}
		}

		public IList<BasicBlock<TContent>> Targets
		{
			[CompilerGenerated]
			get
			{
				return Wt2;
			}
			[CompilerGenerated]
			private set
			{
				Wt2 = value;
			}
		}

		object IBasicBlock.Content => Content;

		IEnumerable<IBasicBlock> IBasicBlock.Sources => Sources;

		IEnumerable<IBasicBlock> IBasicBlock.Targets => Targets;

		public BasicBlock(int int_0, TContent VtM)
		{
			Id = int_0;
			Content = VtM;
			Sources = new List<BasicBlock<TContent>>();
			Targets = new List<BasicBlock<TContent>>();
		}

		public void LinkTo(BasicBlock<TContent> basicBlock_0)
		{
			Targets.Add(basicBlock_0);
			basicBlock_0.Sources.Add(this);
		}

		public override string ToString()
		{
			return $"Block_{Id:x2}:{Environment.NewLine}{Content}";
		}

		internal static bool aerZ()
		{
			return gero == null;
		}

		internal static object KerT()
		{
			return gero;
		}
	}
}
