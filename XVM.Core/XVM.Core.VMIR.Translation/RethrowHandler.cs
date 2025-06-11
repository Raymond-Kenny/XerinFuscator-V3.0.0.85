#define DEBUG
using System;
using System.Diagnostics;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;
using XVM.Core.CFG;

namespace XVM.Core.VMIR.Translation
{
	public class RethrowHandler : GInterface0
	{
		public Code ILCode => Code.Rethrow;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 0);
			ScopeBlock[] array = irtranslator_0.RootScope.SearchBlock(irtranslator_0.gqp());
			ScopeBlock scopeBlock = array[array.Length - 1];
			if (scopeBlock.Type != ScopeType.Handler || scopeBlock.ExceptionHandler.HandlerType != ExceptionHandlerType.Catch)
			{
				throw new InvalidProgramException();
			}
			IRVariable iRVariable = irtranslator_0.Context.ResolveExceptionVar(scopeBlock.ExceptionHandler);
			Debug.Assert(iRVariable != null);
			int tHROW = irtranslator_0.VM.Runtime.VMCall.THROW;
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.PUSH, iRVariable));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.VCALL)
			{
				Operand1 = IRConstant.FromI4(tHROW),
				Operand2 = IRConstant.FromI4(1)
			});
			return null;
		}
	}
}
