namespace XVM.Core.VM
{
	public enum VMCalls
	{
		EXIT,
		BREAK,
		ECALL,
		CAST,
		CKFINITE,
		CKOVERFLOW,
		RANGECHK,
		INITOBJ,
		LDFLD,
		LDFTN,
		TOKEN,
		THROW,
		SIZEOF,
		STFLD,
		BOX,
		UNBOX,
		LOCALLOC,
		Max
	}
}
