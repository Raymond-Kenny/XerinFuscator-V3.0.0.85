using dnlib.DotNet;

namespace XVM.Core.VM
{
	public class FuncSig
	{
		public byte Flags;

		public ITypeDefOrRef[] ParamSigs;

		public ITypeDefOrRef RetType;

		public override int GetHashCode()
		{
			SigComparer sigComparer = default(SigComparer);
			int num = Flags;
			ITypeDefOrRef[] paramSigs = ParamSigs;
			foreach (ITypeDefOrRef a in paramSigs)
			{
				num = num * 7 + sigComparer.GetHashCode(a);
			}
			return num * 7 + sigComparer.GetHashCode(RetType);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is FuncSig funcSig) || funcSig.Flags != Flags)
			{
				return false;
			}
			if (funcSig.ParamSigs.Length != ParamSigs.Length)
			{
				return false;
			}
			SigComparer sigComparer = default(SigComparer);
			int num = 0;
			while (true)
			{
				if (num < ParamSigs.Length)
				{
					if (!sigComparer.Equals(ParamSigs[num], funcSig.ParamSigs[num]))
					{
						break;
					}
					num++;
					continue;
				}
				if (sigComparer.Equals(RetType, funcSig.RetType))
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}
}
