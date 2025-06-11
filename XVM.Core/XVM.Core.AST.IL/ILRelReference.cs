using System.Runtime.CompilerServices;
using XVM.Core.RT;

namespace XVM.Core.AST.IL
{
	public class ILRelReference : IILOperand
	{
		[CompilerGenerated]
		private IHasOffset zcT;

		[CompilerGenerated]
		private IHasOffset OcS;

		public IHasOffset Target
		{
			[CompilerGenerated]
			get
			{
				return zcT;
			}
			[CompilerGenerated]
			set
			{
				zcT = value;
			}
		}

		public IHasOffset Base
		{
			[CompilerGenerated]
			get
			{
				return OcS;
			}
			[CompilerGenerated]
			set
			{
				OcS = value;
			}
		}

		public ILRelReference(IHasOffset ihasOffset_0, IHasOffset ihasOffset_1)
		{
			Target = ihasOffset_0;
			Base = ihasOffset_1;
		}

		public virtual uint Resolve(VMRuntime vmruntime_0)
		{
			uint num = Base.Offset;
			if (Base is ILInstruction)
			{
				num += vmruntime_0.W2O().yN0((ILInstruction)Base);
			}
			return Target.Offset - num;
		}

		public override string ToString()
		{
			return $"[{Base.Offset:x8}:{Target.Offset:x8}]";
		}
	}
}
