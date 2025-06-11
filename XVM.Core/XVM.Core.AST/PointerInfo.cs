using System.Runtime.CompilerServices;
using dnlib.DotNet;

namespace XVM.Core.AST
{
	public class PointerInfo : InstrAnnotation
	{
		[CompilerGenerated]
		private ITypeDefOrRef otX;

		public ITypeDefOrRef PointerType
		{
			[CompilerGenerated]
			get
			{
				return otX;
			}
			[CompilerGenerated]
			set
			{
				otX = value;
			}
		}

		public PointerInfo(string string_0, ITypeDefOrRef itypeDefOrRef_0)
			: base(string_0)
		{
			PointerType = itypeDefOrRef_0;
		}
	}
}
