using System.Runtime.CompilerServices;
using System.Text;
using XVM.Core.AST.ILAST;
using XVM.Core.VMIR;

namespace XVM.Core.AST.IR
{
	public class IRInstruction : ASTNode
	{
		[CompilerGenerated]
		private IROpCode dtf;

		[CompilerGenerated]
		private IILASTStatement uti;

		[CompilerGenerated]
		private IIROperand UtJ;

		[CompilerGenerated]
		private IIROperand lt8;

		[CompilerGenerated]
		private object Stz;

		public IROpCode OpCode
		{
			[CompilerGenerated]
			get
			{
				return dtf;
			}
			[CompilerGenerated]
			set
			{
				dtf = value;
			}
		}

		public IILASTStatement ILAST
		{
			[CompilerGenerated]
			get
			{
				return uti;
			}
			[CompilerGenerated]
			set
			{
				uti = value;
			}
		}

		public IIROperand Operand1
		{
			[CompilerGenerated]
			get
			{
				return UtJ;
			}
			[CompilerGenerated]
			set
			{
				UtJ = value;
			}
		}

		public IIROperand Operand2
		{
			[CompilerGenerated]
			get
			{
				return lt8;
			}
			[CompilerGenerated]
			set
			{
				lt8 = value;
			}
		}

		public object Annotation
		{
			[CompilerGenerated]
			get
			{
				return Stz;
			}
			[CompilerGenerated]
			set
			{
				Stz = value;
			}
		}

		public IRInstruction(IROpCode iropCode_0)
		{
			OpCode = iropCode_0;
		}

		public IRInstruction(IROpCode iropCode_0, IIROperand iiroperand_0)
		{
			OpCode = iropCode_0;
			Operand1 = iiroperand_0;
		}

		public IRInstruction(IROpCode iropCode_0, IIROperand iiroperand_0, IIROperand iiroperand_1)
		{
			OpCode = iropCode_0;
			Operand1 = iiroperand_0;
			Operand2 = iiroperand_1;
		}

		public IRInstruction(IROpCode iropCode_0, IIROperand iiroperand_0, IIROperand iiroperand_1, object object_0)
		{
			OpCode = iropCode_0;
			Operand1 = iiroperand_0;
			Operand2 = iiroperand_1;
			Annotation = object_0;
		}

		public IRInstruction(IROpCode iropCode_0, IIROperand iiroperand_0, IIROperand iiroperand_1, IRInstruction irinstruction_0)
		{
			OpCode = iropCode_0;
			Operand1 = iiroperand_0;
			Operand2 = iiroperand_1;
			Annotation = irinstruction_0.Annotation;
			ILAST = irinstruction_0.ILAST;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("{0}", OpCode.ToString().PadLeft(16));
			if (Operand1 != null)
			{
				stringBuilder.AppendFormat(" {0}", Operand1);
				if (Operand2 != null)
				{
					stringBuilder.AppendFormat(", {0}", Operand2);
				}
			}
			if (Annotation != null)
			{
				stringBuilder.AppendFormat("    ; {0}", Annotation);
			}
			return stringBuilder.ToString();
		}
	}
}
