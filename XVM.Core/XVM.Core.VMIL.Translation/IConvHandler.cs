#define DEBUG
using System;
using System.Diagnostics;
using XVM.Core.AST;
using XVM.Core.AST.IL;
using XVM.Core.AST.IR;
using XVM.Core.VMIR;

namespace XVM.Core.VMIL.Translation
{
	public class IConvHandler : GInterface1
	{
		public IROpCode IRCode => IROpCode.ICONV;

		public void Translate(IRInstruction irinstruction_0, ILTranslator iltranslator_0)
		{
			iltranslator_0.PushOperand(irinstruction_0.Operand2);
			Debug.Assert(irinstruction_0.Operand1.Type == ASTType.I8);
			switch (irinstruction_0.Operand2.Type)
			{
			case ASTType.R4:
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.FCONV_R32_R64));
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.ICONV_R64));
				break;
			case ASTType.R8:
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.ICONV_R64));
				break;
			default:
				throw new NotSupportedException();
			case ASTType.Ptr:
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.ICONV_PTR));
				break;
			}
			iltranslator_0.PopOperand(irinstruction_0.Operand1);
		}
	}
}
