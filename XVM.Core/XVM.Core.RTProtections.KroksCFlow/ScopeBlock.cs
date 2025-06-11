using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using dnlib.DotNet.Emit;

namespace XVM.Core.RTProtections.KroksCFlow
{
	public class ScopeBlock : BlockBase
	{
		[CompilerGenerated]
		private ExceptionHandler S1E;

		[CompilerGenerated]
		private List<BlockBase> g1N;

		public ExceptionHandler Handler
		{
			[CompilerGenerated]
			get
			{
				return S1E;
			}
			[CompilerGenerated]
			private set
			{
				S1E = value;
			}
		}

		public List<BlockBase> Children
		{
			[CompilerGenerated]
			get
			{
				return g1N;
			}
			[CompilerGenerated]
			set
			{
				g1N = value;
			}
		}

		public ScopeBlock(BlockType blockType_0, ExceptionHandler exceptionHandler_0)
			: base(blockType_0)
		{
			Handler = exceptionHandler_0;
			Children = new List<BlockBase>();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (base.Type == BlockType.Try)
			{
				stringBuilder.Append("try ");
			}
			else if (base.Type == BlockType.Handler)
			{
				stringBuilder.Append("handler ");
			}
			else if (base.Type == BlockType.Finally)
			{
				stringBuilder.Append("finally ");
			}
			else if (base.Type == BlockType.Fault)
			{
				stringBuilder.Append("fault ");
			}
			stringBuilder.AppendLine("{");
			foreach (BlockBase child in Children)
			{
				stringBuilder.Append(child);
			}
			stringBuilder.AppendLine("}");
			return stringBuilder.ToString();
		}

		public Instruction GetFirstInstr()
		{
			BlockBase blockBase = Children.First();
			if (blockBase is ScopeBlock)
			{
				return ((ScopeBlock)blockBase).GetFirstInstr();
			}
			return ((InstrBlock)blockBase).Instructions.First();
		}

		public Instruction GetLastInstr()
		{
			BlockBase blockBase = Children.Last();
			if (blockBase is ScopeBlock)
			{
				return ((ScopeBlock)blockBase).GetLastInstr();
			}
			return ((InstrBlock)blockBase).Instructions.Last();
		}

		public override void ToBody(CilBody cilBody_0)
		{
			if (base.Type != BlockType.Normal)
			{
				if (base.Type != BlockType.Try)
				{
					if (base.Type == BlockType.Filter)
					{
						Handler.FilterStart = GetFirstInstr();
					}
					else
					{
						Handler.HandlerStart = GetFirstInstr();
						Handler.HandlerEnd = GetLastInstr();
					}
				}
				else
				{
					Handler.TryStart = GetFirstInstr();
					Handler.TryEnd = GetLastInstr();
				}
			}
			foreach (BlockBase child in Children)
			{
				child.ToBody(cilBody_0);
			}
		}
	}
}
