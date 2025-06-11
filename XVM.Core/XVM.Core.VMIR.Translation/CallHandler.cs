using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class CallHandler : GInterface0
	{
		public Code ILCode => Code.Call;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			InstrCallInfo instrCallInfo = new InstrCallInfo("CALL")
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
			IIROperand iIROperand = null;
			if (!ilastexpression_0.Type.HasValue)
			{
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__CALL)
				{
					Operand1 = new IRMetaTarget(instrCallInfo.Method),
					Annotation = instrCallInfo
				});
			}
			else
			{
				iIROperand = irtranslator_0.Context.AllocateVRegister(ilastexpression_0.Type.Value);
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__CALL)
				{
					Operand1 = new IRMetaTarget(instrCallInfo.Method),
					Operand2 = iIROperand,
					Annotation = instrCallInfo
				});
			}
			instrCallInfo.ReturnValue = iIROperand;
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__ENDCALL)
			{
				Annotation = instrCallInfo
			});
			return iIROperand;
		}
	}
}
