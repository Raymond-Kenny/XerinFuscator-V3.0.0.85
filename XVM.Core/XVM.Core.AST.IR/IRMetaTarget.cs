using System.Runtime.CompilerServices;

namespace XVM.Core.AST.IR
{
	public class IRMetaTarget : IIROperand
	{
		[CompilerGenerated]
		private object oce;

		[CompilerGenerated]
		private bool Mcu;

		public object MetadataItem
		{
			[CompilerGenerated]
			get
			{
				return oce;
			}
			[CompilerGenerated]
			set
			{
				oce = value;
			}
		}

		public bool LateResolve
		{
			[CompilerGenerated]
			get
			{
				return Mcu;
			}
			[CompilerGenerated]
			set
			{
				Mcu = value;
			}
		}

		public ASTType Type => ASTType.Ptr;

		public IRMetaTarget(object object_0)
		{
			MetadataItem = object_0;
		}

		public override string ToString()
		{
			return MetadataItem.ToString();
		}
	}
}
