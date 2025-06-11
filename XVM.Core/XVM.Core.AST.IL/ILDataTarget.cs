using System.Runtime.CompilerServices;
using XVM.Core.RT;

namespace XVM.Core.AST.IL
{
	public class ILDataTarget : IILOperand, IHasOffset
	{
		[CompilerGenerated]
		private BinaryChunk FcN;

		[CompilerGenerated]
		private string hc2;

		public BinaryChunk Target
		{
			[CompilerGenerated]
			get
			{
				return FcN;
			}
			[CompilerGenerated]
			set
			{
				FcN = value;
			}
		}

		public string Name
		{
			[CompilerGenerated]
			get
			{
				return hc2;
			}
			[CompilerGenerated]
			set
			{
				hc2 = value;
			}
		}

		public uint Offset => Target.Offset;

		public ILDataTarget(BinaryChunk binaryChunk_0)
		{
			Target = binaryChunk_0;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
