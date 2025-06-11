using System;
using dnlib.DotNet;
using XVM.Core.AST;
using XVM.Core.AST.IL;
using XVM.Core.AST.IR;
using XVM.Core.VMIR;

namespace XVM.Core.VMIL.Translation
{
	public class SxHandler : GInterface1
	{
		public IROpCode IRCode => IROpCode.SX;

		public void Translate(IRInstruction irinstruction_0, ILTranslator iltranslator_0)
		{
			iltranslator_0.PushOperand(irinstruction_0.Operand2);
			switch (irinstruction_0.Operand1.Type)
			{
			default:
				throw new NotSupportedException();
			case ASTType.I8:
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.SX_DWORD));
				break;
			case ASTType.I4:
				if (irinstruction_0.Operand1 is IRVariable)
				{
					ElementType elementType = ((IRVariable)irinstruction_0.Operand1).RawType.ElementType;
					if (elementType == ElementType.I2)
					{
						iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.SX_WORD));
					}
				}
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.SX_BYTE));
				break;
			}
			iltranslator_0.PopOperand(irinstruction_0.Operand1);
		}
	}
}
