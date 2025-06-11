using System.Runtime.CompilerServices;
using dnlib.DotNet;
using XVM.Core.AST.IR;

namespace XVM.Core.AST
{
	public class InstrCallInfo : InstrAnnotation
	{
		[CompilerGenerated]
		private ITypeDefOrRef Qty;

		[CompilerGenerated]
		private IMethod xtY;

		[CompilerGenerated]
		private IIROperand[] atg;

		[CompilerGenerated]
		private IIROperand ftb;

		[CompilerGenerated]
		private IRRegister ctp;

		[CompilerGenerated]
		private IRPointer Ktr;

		[CompilerGenerated]
		private bool Tt3;

		public ITypeDefOrRef ConstrainType
		{
			[CompilerGenerated]
			get
			{
				return Qty;
			}
			[CompilerGenerated]
			set
			{
				Qty = value;
			}
		}

		public IMethod Method
		{
			[CompilerGenerated]
			get
			{
				return xtY;
			}
			[CompilerGenerated]
			set
			{
				xtY = value;
			}
		}

		public IIROperand[] Arguments
		{
			[CompilerGenerated]
			get
			{
				return atg;
			}
			[CompilerGenerated]
			set
			{
				atg = value;
			}
		}

		public IIROperand ReturnValue
		{
			[CompilerGenerated]
			get
			{
				return ftb;
			}
			[CompilerGenerated]
			set
			{
				ftb = value;
			}
		}

		public IRRegister ReturnRegister
		{
			[CompilerGenerated]
			get
			{
				return ctp;
			}
			[CompilerGenerated]
			set
			{
				ctp = value;
			}
		}

		public IRPointer ReturnSlot
		{
			[CompilerGenerated]
			get
			{
				return Ktr;
			}
			[CompilerGenerated]
			set
			{
				Ktr = value;
			}
		}

		public bool IsECall
		{
			[CompilerGenerated]
			get
			{
				return Tt3;
			}
			[CompilerGenerated]
			set
			{
				Tt3 = value;
			}
		}

		public InstrCallInfo(string string_0)
			: base(string_0)
		{
		}

		public override string ToString()
		{
			return base.ToString() + " " + Method;
		}
	}
}
