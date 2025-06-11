using dnlib.DotNet;
using XF;
using XVM.Core.CFG;
using XVM.Core.RT;

namespace XVM.Core.AST.IL
{
	public class ILBlock : BasicBlock<ILInstrList>
	{
		public ILBlock(int int_0, ILInstrList ilinstrList_0)
			: base(int_0, ilinstrList_0)
		{
		}

		public virtual IChunk CreateChunk(VMRuntime vmruntime_0, MethodDef methodDef_0)
		{
			return new IEJ(vmruntime_0, methodDef_0, this);
		}
	}
}
