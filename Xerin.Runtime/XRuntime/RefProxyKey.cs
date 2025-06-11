using System;

namespace XRuntime
{
	public class RefProxyKey : Attribute
	{
		public readonly int key;

		public RefProxyKey(int key)
		{
			this.key = Mutation.Placeholder(key);
		}

		public override int GetHashCode()
		{
			return key;
		}
	}
}
