using System.Runtime.CompilerServices;
using dnlib.DotNet;
using XVM.Core.RT;

namespace XVM.Core.AST.IL
{
	public class ILMethodTarget : IILOperand, IHasOffset
	{
		private ILBlock pc5;

		[CompilerGenerated]
		private MethodDef sco;

		public MethodDef Target
		{
			[CompilerGenerated]
			get
			{
				return sco;
			}
			[CompilerGenerated]
			set
			{
				sco = value;
			}
		}

		public uint Offset => (pc5 != null) ? pc5.Content[0].Offset : 0u;

		public ILMethodTarget(MethodDef methodDef_0)
		{
			Target = methodDef_0;
		}

		public void Resolve(VMRuntime vmruntime_0)
		{
			vmruntime_0.LookupMethod(Target, out pc5);
		}

		public override string ToString()
		{
			return Target.ToString();
		}
	}
}
