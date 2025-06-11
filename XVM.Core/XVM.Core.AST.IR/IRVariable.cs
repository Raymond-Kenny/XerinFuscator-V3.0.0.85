using System.Runtime.CompilerServices;
using dnlib.DotNet;

namespace XVM.Core.AST.IR
{
	public class IRVariable : ASTVariable, IIROperand
	{
		[CompilerGenerated]
		private IRVariableType Sc0;

		[CompilerGenerated]
		private TypeSig Lcw;

		[CompilerGenerated]
		private int gcW;

		[CompilerGenerated]
		private object DcE;

		public IRVariableType VariableType
		{
			[CompilerGenerated]
			get
			{
				return Sc0;
			}
			[CompilerGenerated]
			set
			{
				Sc0 = value;
			}
		}

		public TypeSig RawType
		{
			[CompilerGenerated]
			get
			{
				return Lcw;
			}
			[CompilerGenerated]
			set
			{
				Lcw = value;
			}
		}

		public int Id
		{
			[CompilerGenerated]
			get
			{
				return gcW;
			}
			[CompilerGenerated]
			set
			{
				gcW = value;
			}
		}

		public object Annotation
		{
			[CompilerGenerated]
			get
			{
				return DcE;
			}
			[CompilerGenerated]
			set
			{
				DcE = value;
			}
		}

		public override string ToString()
		{
			return $"{base.Name}:{base.Type}";
		}
	}
}
