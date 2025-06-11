using System.Collections.Generic;
using dnlib.DotNet.Emit;

namespace XVM.Core.RTProtections.KroksCFlow
{
	public abstract class ManglerBase
	{
		protected static IEnumerable<InstrBlock> GetAllBlocks(ScopeBlock scopeBlock_0)
		{
			foreach (BlockBase child in scopeBlock_0.Children)
			{
				if (!(child is InstrBlock))
				{
					foreach (InstrBlock allBlock in GetAllBlocks((ScopeBlock)child))
					{
						yield return allBlock;
					}
				}
				else
				{
					yield return (InstrBlock)child;
				}
			}
		}

		public abstract void Mangle(CilBody cilBody_0, ScopeBlock scopeBlock_0, KroksContext kroksContext_0);
	}
}
