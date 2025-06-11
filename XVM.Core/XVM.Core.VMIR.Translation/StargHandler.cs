#define DEBUG
using System.Diagnostics;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class StargHandler : GInterface0
	{
		public Code ILCode => Code.Starg;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 1);
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.MOV)
			{
				Operand1 = irtranslator_0.Context.ResolveParameter((Parameter)ilastexpression_0.Operand),
				Operand2 = irtranslator_0.Qqg(ilastexpression_0.Arguments[0])
			});
			return null;
		}
	}
}
