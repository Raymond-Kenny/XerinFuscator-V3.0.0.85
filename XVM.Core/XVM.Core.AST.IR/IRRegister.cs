using System.Runtime.CompilerServices;
using XVM.Core.VM;

namespace XVM.Core.AST.IR
{
	public class IRRegister : IIROperand
	{
		[CompilerGenerated]
		private VMRegisters ucM;

		[CompilerGenerated]
		private IRVariable JcA;

		[CompilerGenerated]
		private ASTType EcR;

		public static readonly IRRegister BP;

		public static readonly IRRegister SP;

		public static readonly IRRegister IP;

		public static readonly IRRegister FL;

		public static readonly IRRegister K1;

		public VMRegisters Register
		{
			[CompilerGenerated]
			get
			{
				return ucM;
			}
			[CompilerGenerated]
			set
			{
				ucM = value;
			}
		}

		public IRVariable SourceVariable
		{
			[CompilerGenerated]
			get
			{
				return JcA;
			}
			[CompilerGenerated]
			set
			{
				JcA = value;
			}
		}

		public ASTType Type
		{
			[CompilerGenerated]
			get
			{
				return EcR;
			}
			[CompilerGenerated]
			set
			{
				EcR = value;
			}
		}

		public IRRegister(VMRegisters vmregisters_0)
		{
			Register = vmregisters_0;
			Type = ASTType.Ptr;
		}

		public IRRegister(VMRegisters vmregisters_0, ASTType asttype_0)
		{
			Register = vmregisters_0;
			Type = asttype_0;
		}

		public override string ToString()
		{
			return Register.ToString();
		}

		static IRRegister()
		{
			BP = new IRRegister(VMRegisters.BP, ASTType.I4);
			SP = new IRRegister(VMRegisters.SP, ASTType.I4);
			IP = new IRRegister(VMRegisters.IP);
			FL = new IRRegister(VMRegisters.FL, ASTType.I4);
			K1 = new IRRegister(VMRegisters.K1, ASTType.I4);
		}
	}
}
