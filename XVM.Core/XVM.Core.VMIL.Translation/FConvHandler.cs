#define DEBUG
using System;
using System.Diagnostics;
using XVM.Core.AST;
using XVM.Core.AST.IL;
using XVM.Core.AST.IR;
using XVM.Core.VMIR;

namespace XVM.Core.VMIL.Translation
{
	public class FConvHandler : GInterface1
	{
		public IROpCode IRCode => IROpCode.FCONV;

		public void Translate(IRInstruction irinstruction_0, ILTranslator iltranslator_0)
		{
			iltranslator_0.PushOperand(irinstruction_0.Operand2);
			switch (irinstruction_0.Operand2.Type)
			{
			default:
				Debug.Assert(irinstruction_0.Operand2.Type == ASTType.I8);
				switch (irinstruction_0.Operand1.Type)
				{
				default:
					throw new NotSupportedException();
				case ASTType.R8:
					iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.FCONV_R64));
					break;
				case ASTType.R4:
					iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.FCONV_R32));
					break;
				}
				break;
			case ASTType.R8:
				Debug.Assert(irinstruction_0.Operand1.Type == ASTType.R4);
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.FCONV_R64_R32));
				break;
			case ASTType.R4:
				Debug.Assert(irinstruction_0.Operand1.Type == ASTType.R8);
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.FCONV_R32_R64));
				break;
			}
			iltranslator_0.PopOperand(irinstruction_0.Operand1);
		}
	}
}
