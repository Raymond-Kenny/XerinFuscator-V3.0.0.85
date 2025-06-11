#define DEBUG
using System.Diagnostics;
using XVM.Core.AST;
using XVM.Core.AST.IL;
using XVM.Core.AST.IR;
using XVM.Core.VMIR;

namespace XVM.Core.VMIL.Translation
{
	public class SwtHandler : GInterface1
	{
		public IROpCode IRCode => IROpCode.SWT;

		public void Translate(IRInstruction irinstruction_0, ILTranslator iltranslator_0)
		{
			iltranslator_0.PushOperand(irinstruction_0.Operand2);
			iltranslator_0.PushOperand(irinstruction_0.Operand1);
			ILInstruction iLInstruction = iltranslator_0.wAE()[iltranslator_0.wAE().Count - 1];
			Debug.Assert(iLInstruction.OpCode == ILOpCode.PUSHI_DWORD && iLInstruction.Operand is ILJumpTable);
			ILInstruction iLInstruction2 = new ILInstruction(ILOpCode.SWT)
			{
				Annotation = InstrAnnotation.JUMP
			};
			iltranslator_0.wAE().Add(iLInstruction2);
			ILJumpTable iLJumpTable = (ILJumpTable)iLInstruction.Operand;
			iLJumpTable.Chunk.kNP = iltranslator_0.Runtime;
			iLJumpTable.RelativeBase = iLInstruction2;
			iltranslator_0.Runtime.AddChunk(iLJumpTable.Chunk);
		}
	}
}
