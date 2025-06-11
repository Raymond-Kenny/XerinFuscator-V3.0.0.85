using System.Collections.Generic;
using dnlib.DotNet;
using XVM.Core.AST;
using XVM.Core.AST.IR;
using XVM.Core.VM;

namespace XVM.Core.VMIR.Transforms
{
	public class InvokeTransform : ITransform
	{
		public void Initialize(IRTransformer irtransformer_0)
		{
		}

		public void Transform(IRTransformer irtransformer_0)
		{
			irtransformer_0.SqF().VisitInstrs(UMj, irtransformer_0);
		}

		private void UMj(IRInstrList irinstrList_0, IRInstruction irinstruction_0, ref int int_0, IRTransformer irtransformer_0)
		{
			if (irinstruction_0.OpCode == IROpCode.__CALL || irinstruction_0.OpCode == IROpCode.__CALLVIRT || irinstruction_0.OpCode == IROpCode.__NEWOBJ)
			{
				MethodDef methodDef = ((IMethod)((IRMetaTarget)irinstruction_0.Operand1).MetadataItem).ResolveMethodDef();
				InstrCallInfo instrCallInfo = (InstrCallInfo)irinstruction_0.Annotation;
				if (methodDef == null || methodDef.Module != irtransformer_0.Context.Method.Module || !irtransformer_0.VM.Settings.IsVirtualized(methodDef) || irinstruction_0.OpCode != IROpCode.__CALL)
				{
					instrCallInfo.IsECall = true;
					EMO(irinstrList_0, irinstruction_0, int_0, irtransformer_0);
				}
				else
				{
					instrCallInfo.IsECall = false;
					aMt(irinstrList_0, irinstruction_0, int_0, irtransformer_0, methodDef);
				}
			}
		}

		private void EMO(IRInstrList irinstrList_0, IRInstruction irinstruction_0, int int_0, IRTransformer irtransformer_0)
		{
			IMethod imemberRef_ = (IMethod)((IRMetaTarget)irinstruction_0.Operand1).MetadataItem;
			IRVariable iRVariable = (IRVariable)irinstruction_0.Operand2;
			uint num = 0u;
			ITypeDefOrRef constrainType = ((InstrCallInfo)irinstruction_0.Annotation).ConstrainType;
			if (irinstruction_0.OpCode == IROpCode.__CALL)
			{
				num = irtransformer_0.VM.Runtime.VCallOps.ECALL_CALL;
			}
			else if (irinstruction_0.OpCode == IROpCode.__CALLVIRT)
			{
				num = ((constrainType != null) ? irtransformer_0.VM.Runtime.VCallOps.ECALL_CALLVIRT_CONSTRAINED : irtransformer_0.VM.Runtime.VCallOps.ECALL_CALLVIRT);
			}
			else if (irinstruction_0.OpCode == IROpCode.__NEWOBJ)
			{
				num = irtransformer_0.VM.Runtime.VCallOps.ECALL_NEWOBJ;
			}
			int int_1 = (int)(irtransformer_0.VM.Data.GetId(imemberRef_) | (num << 30));
			int eCALL = irtransformer_0.VM.Runtime.VMCall.ECALL;
			List<IRInstruction> list = new List<IRInstruction>();
			if (constrainType != null)
			{
				list.Add(new IRInstruction(IROpCode.PUSH)
				{
					Operand1 = IRConstant.FromI4((int)irtransformer_0.VM.Data.GetId(constrainType)),
					Annotation = irinstruction_0.Annotation,
					ILAST = irinstruction_0.ILAST
				});
			}
			list.Add(new IRInstruction(IROpCode.VCALL)
			{
				Operand1 = IRConstant.FromI4(eCALL),
				Operand2 = IRConstant.FromI4(int_1),
				Annotation = irinstruction_0.Annotation,
				ILAST = irinstruction_0.ILAST
			});
			if (iRVariable != null)
			{
				list.Add(new IRInstruction(IROpCode.POP, iRVariable)
				{
					Annotation = irinstruction_0.Annotation,
					ILAST = irinstruction_0.ILAST
				});
			}
			irinstrList_0.Replace(int_0, list);
		}

		private void aMt(IRInstrList irinstrList_0, IRInstruction irinstruction_0, int int_0, IRTransformer irtransformer_0, MethodDef methodDef_0)
		{
			IRVariable iRVariable = (IRVariable)irinstruction_0.Operand2;
			InstrCallInfo instrCallInfo = (InstrCallInfo)irinstruction_0.Annotation;
			instrCallInfo.Method = methodDef_0;
			List<IRInstruction> list = new List<IRInstruction>();
			list.Add(new IRInstruction(IROpCode.CALL, new IRMetaTarget(methodDef_0)
			{
				LateResolve = true
			})
			{
				Annotation = irinstruction_0.Annotation,
				ILAST = irinstruction_0.ILAST
			});
			if (iRVariable != null)
			{
				list.Add(new IRInstruction(IROpCode.MOV, iRVariable, new IRRegister(VMRegisters.R0, iRVariable.Type))
				{
					Annotation = irinstruction_0.Annotation,
					ILAST = irinstruction_0.ILAST
				});
			}
			int int_1 = -instrCallInfo.Arguments.Length;
			list.Add(new IRInstruction(IROpCode.ADD, IRRegister.SP, IRConstant.FromI4(int_1))
			{
				Annotation = irinstruction_0.Annotation,
				ILAST = irinstruction_0.ILAST
			});
			irinstrList_0.Replace(int_0, list);
		}
	}
}
