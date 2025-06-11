#define DEBUG
using System.Diagnostics;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class LdobjHandler : GInterface0
	{
		public Code ILCode => Code.Ldobj;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 1);
			IIROperand iiroperand_ = irtranslator_0.Qqg(ilastexpression_0.Arguments[0]);
			IRVariable iRVariable = irtranslator_0.Context.AllocateVRegister(ilastexpression_0.Type.Value);
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__LDOBJ, iiroperand_, iRVariable)
			{
				Annotation = new PointerInfo("LDOBJ", (ITypeDefOrRef)ilastexpression_0.Operand)
			});
			return iRVariable;
		}
	}
}
