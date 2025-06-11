using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class NewobjHandler : GInterface0
	{
		public Code ILCode => Code.Newobj;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			InstrCallInfo instrCallInfo = new InstrCallInfo("NEWOBJ")
			{
				Method = (IMethod)ilastexpression_0.Operand
			};
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__BEGINCALL)
			{
				Annotation = instrCallInfo
			});
			IIROperand[] array = new IIROperand[ilastexpression_0.Arguments.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = irtranslator_0.Qqg(ilastexpression_0.Arguments[i]);
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.PUSH)
				{
					Operand1 = array[i],
					Annotation = instrCallInfo
				});
			}
			instrCallInfo.Arguments = array;
			IRVariable iRVariable = irtranslator_0.Context.AllocateVRegister(ilastexpression_0.Type.Value);
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__NEWOBJ)
			{
				Operand1 = new IRMetaTarget(instrCallInfo.Method),
				Operand2 = iRVariable,
				Annotation = instrCallInfo
			});
			instrCallInfo.ReturnValue = iRVariable;
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__ENDCALL)
			{
				Annotation = instrCallInfo
			});
			return iRVariable;
		}
	}
}
