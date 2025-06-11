using System.Runtime.CompilerServices;
using dnlib.DotNet.Writer;

namespace XF
{
	internal class VUy : HeapBase
	{
		[CompilerGenerated]
		private readonly string aUb;

		private readonly byte[] mUk;

		public override string Name
		{
			[CompilerGenerated]
			get
			{
				return aUb;
			}
		}

		public VUy(string string_0, byte[] byte_0)
		{
			aUb = string_0;
			mUk = byte_0;
		}

		public override uint GetRawLength()
		{
			return (uint)mUk.Length;
		}

		protected override void WriteToImpl(DataWriter writer)
		{
			writer.WriteBytes(mUk);
		}
	}
}
