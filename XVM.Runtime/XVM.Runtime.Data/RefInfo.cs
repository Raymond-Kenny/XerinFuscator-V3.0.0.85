using System.Reflection;

namespace XVM.Runtime.XVM.Runtime.Data
{
	internal class RefInfo
	{
		private readonly double encryptKey;

		public int Token { get; private set; }

		public MemberInfo Resolved { get; private set; }

		public RefInfo(int token, double encryptKey)
		{
			Token = token;
			this.encryptKey = encryptKey;
		}

		public MemberInfo Member()
		{
			MemberInfo result;
			if ((object)(result = Resolved) == null)
			{
				MemberInfo memberInfo = Resolved = VMInstance.__ExecuteModule.ResolveMember(Utils.Decrypt(Token, encryptKey));
				result = memberInfo;
			}
			return result;
		}
	}
}
