#define DEBUG
using System;
using System.Diagnostics;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class GClass6 : GInterface0
	{
		public Code ILCode => Code.Conv_Ovf_I1_Un;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 1);
			IIROperand iIROperand = irtranslator_0.Qqg(ilastexpression_0.Arguments[0]);
			ASTType type = iIROperand.Type;
			IRVariable iRVariable = irtranslator_0.Context.AllocateVRegister(ASTType.I4);
			IRVariable iRVariable2 = irtranslator_0.Context.AllocateVRegister(ASTType.I4);
			iRVariable.RawType = irtranslator_0.Context.Method.Module.CorLibTypes.SByte;
			int rANGECHK = irtranslator_0.VM.Runtime.VMCall.RANGECHK;
			int cKOVERFLOW = irtranslator_0.VM.Runtime.VMCall.CKOVERFLOW;
			switch (type)
			{
			case ASTType.R4:
			case ASTType.R8:
			{
				IRVariable iRVariable3 = irtranslator_0.Context.AllocateVRegister(ASTType.I8);
				IRVariable iRVariable4 = irtranslator_0.Context.AllocateVRegister(ASTType.I4);
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__SETF)
				{
					Operand1 = IRConstant.FromI4(1 << irtranslator_0.Arch.Flags.UNSIGNED)
				});
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.ICONV, iRVariable3, iIROperand));
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.__GETF)
				{
					Operand1 = iRVariable4,
					Operand2 = IRConstant.FromI4(1 << irtranslator_0.Arch.Flags.OVERFLOW)
				});
				irtranslator_0.JqX().Add(new IRInstruction(IROpCode.VCALL, IRConstant.FromI4(cKOVERFLOW), iRVariable4));
				iIROperand = iRVariable3;
				break;
			}
			default:
				throw new NotSupportedException();
			case ASTType.I4:
			case ASTType.I8:
			case ASTType.Ptr:
				break;
			}
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.PUSH, IRConstant.FromI8(0L)));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.PUSH, IRConstant.FromI8(127L)));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.VCALL, IRConstant.FromI4(rANGECHK), iIROperand));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.VCALL, IRConstant.FromI4(cKOVERFLOW)));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.MOV, iRVariable, iIROperand));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.SX, iRVariable2, iRVariable));
			return iRVariable2;
		}
	}
}
