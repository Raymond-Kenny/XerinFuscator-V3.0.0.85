using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class LdlocHandler : GInterface0
	{
		public Code ILCode => Code.Ldloc;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			IRVariable iRVariable = irtranslator_0.Context.ResolveLocal((Local)ilastexpression_0.Operand);
			IRVariable iRVariable2 = irtranslator_0.Context.AllocateVRegister(iRVariable.Type);
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.MOV, iRVariable2, iRVariable));
			if (iRVariable.RawType.ElementType == ElementType.I1 || iRVariable.RawType.ElementType == ElementType.I2)
			{
				iRVariable2.RawType = iRVariable.RawType;
				IRVariable iRVariable3 = irtranslator_0.Context.AllocateVRegister(iRVariable.Type);
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.SX, iRVariable3, iRVariable2));
				iRVariable2 = iRVariable3;
			}
			return iRVariable2;
		}
	}
}
