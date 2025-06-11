#define DEBUG
using System.Diagnostics;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class GClass10 : GInterface0
	{
		public Code ILCode => Code.Conv_Ovf_U8_Un;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 1);
			return irtranslator_0.Qqg(ilastexpression_0.Arguments[0]);
		}
	}
}
