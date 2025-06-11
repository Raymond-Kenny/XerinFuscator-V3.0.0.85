using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class SizeofHandler : GInterface0
	{
		public Code ILCode => Code.Sizeof;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			int id = (int)irtranslator_0.Runtime.Descriptor.Data.GetId((ITypeDefOrRef)ilastexpression_0.Operand);
			IRVariable iRVariable = irtranslator_0.Context.AllocateVRegister(ilastexpression_0.Type.Value);
			int sIZEOF = irtranslator_0.VM.Runtime.VMCall.SIZEOF;
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.VCALL, IRConstant.FromI4(sIZEOF), IRConstant.FromI4(id)));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.POP, iRVariable));
			return iRVariable;
		}
	}
}
