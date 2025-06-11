#define DEBUG
using System.Diagnostics;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Translation
{
	public class UnboxAnyHandler : GInterface0
	{
		public Code ILCode => Code.Unbox_Any;

		public IIROperand Translate(ILASTExpression ilastexpression_0, IRTranslator irtranslator_0)
		{
			Debug.Assert(ilastexpression_0.Arguments.Length == 1);
			IIROperand iIROperand = irtranslator_0.Qqg(ilastexpression_0.Arguments[0]);
			TypeSig typeSig = ((ITypeDefOrRef)ilastexpression_0.Operand).ToTypeSig();
			if (!typeSig.GetElementType().IsPrimitive() && typeSig.ElementType != ElementType.Object && !typeSig.ToTypeDefOrRef().ResolveTypeDefThrow().IsEnum)
			{
				return iIROperand;
			}
			IRVariable iRVariable = irtranslator_0.Context.AllocateVRegister(ilastexpression_0.Type.Value);
			int id = (int)irtranslator_0.VM.Data.GetId((ITypeDefOrRef)ilastexpression_0.Operand);
			int uNBOX = irtranslator_0.VM.Runtime.VMCall.UNBOX;
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.PUSH, iIROperand));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.VCALL, IRConstant.FromI4(uNBOX), IRConstant.FromI4(id)));
			irtranslator_0.JqX().Add(new IRInstruction(IROpCode.POP, iRVariable));
			return iRVariable;
		}
	}
}
