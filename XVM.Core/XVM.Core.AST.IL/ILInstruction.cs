using System.Runtime.CompilerServices;
using System.Text;
using XVM.Core.AST.IR;
using XVM.Core.VMIL;

namespace XVM.Core.AST.IL
{
	public class ILInstruction : ASTNode, IHasOffset
	{
		[CompilerGenerated]
		private uint Nc1;

		[CompilerGenerated]
		private IRInstruction bcj;

		[CompilerGenerated]
		private ILOpCode FcO;

		[CompilerGenerated]
		private IILOperand Vct;

		[CompilerGenerated]
		private object occ;

		public uint Offset
		{
			[CompilerGenerated]
			get
			{
				return Nc1;
			}
			[CompilerGenerated]
			set
			{
				Nc1 = value;
			}
		}

		public IRInstruction IR
		{
			[CompilerGenerated]
			get
			{
				return bcj;
			}
			[CompilerGenerated]
			set
			{
				bcj = value;
			}
		}

		public ILOpCode OpCode
		{
			[CompilerGenerated]
			get
			{
				return FcO;
			}
			[CompilerGenerated]
			set
			{
				FcO = value;
			}
		}

		public IILOperand Operand
		{
			[CompilerGenerated]
			get
			{
				return Vct;
			}
			[CompilerGenerated]
			set
			{
				Vct = value;
			}
		}

		public object Annotation
		{
			[CompilerGenerated]
			get
			{
				return occ;
			}
			[CompilerGenerated]
			set
			{
				occ = value;
			}
		}

		public ILInstruction(ILOpCode ilopCode_0)
		{
			OpCode = ilopCode_0;
		}

		public ILInstruction(ILOpCode ilopCode_0, IILOperand iiloperand_0)
		{
			OpCode = ilopCode_0;
			Operand = iiloperand_0;
		}

		public ILInstruction(ILOpCode ilopCode_0, IILOperand iiloperand_0, object object_0)
		{
			OpCode = ilopCode_0;
			Operand = iiloperand_0;
			Annotation = object_0;
		}

		public ILInstruction(ILOpCode ilopCode_0, IILOperand iiloperand_0, ILInstruction ilinstruction_0)
		{
			OpCode = ilopCode_0;
			Operand = iiloperand_0;
			Annotation = ilinstruction_0.Annotation;
			IR = ilinstruction_0.IR;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("{0}", OpCode.ToString().PadLeft(16));
			if (Operand != null)
			{
				stringBuilder.AppendFormat(" {0}", Operand);
			}
			if (Annotation != null)
			{
				stringBuilder.AppendFormat("    ; {0}", Annotation);
			}
			return stringBuilder.ToString();
		}
	}
}
