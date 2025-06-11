#define DEBUG
using System.Diagnostics;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class StobjHandler : GInterface0
	{
		public Code ILCode => Code.Stobj;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 2);
			IIROperand iiroperand_ = irtranslator_0.Qqg(ilastexpression_0.Arguments[0]);
			IIROperand iiroperand_2 = irtranslator_0.Qqg(ilastexpression_0.Arguments[1]);
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__STOBJ, iiroperand_, iiroperand_2)
			{
				Annotation = new PointerInfo("STOBJ", (ITypeDefOrRef)ilastexpression_0.Operand)
			});
			return null;
		}
	}
}
