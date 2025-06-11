using System.Runtime.CompilerServices;
using dnlib.DotNet.Emit;

namespace XVM.Core.AST
{
	public class EHInfo : InstrAnnotation
	{
		[CompilerGenerated]
		private ExceptionHandler Ltn;

		public ExceptionHandler ExceptionHandler
		{
			[CompilerGenerated]
			get
			{
				return Ltn;
			}
			[CompilerGenerated]
			set
			{
				Ltn = value;
			}
		}

		public EHInfo(ExceptionHandler exceptionHandler_0)
			: base("EH_" + exceptionHandler_0.GetHashCode())
		{
			ExceptionHandler = exceptionHandler_0;
		}
	}
}
