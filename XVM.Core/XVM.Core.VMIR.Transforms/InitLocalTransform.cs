using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.IR;

namespace XVM.Core.VMIR.Transforms
{
	public class InitLocalTransform : ITransform
	{
		private bool gM1;

		public void Initialize(IRTransformer irtransformer_0)
		{
		}

		public void Transform(IRTransformer irtransformer_0)
		{
			if (irtransformer_0.Context.Method.Body.InitLocals)
			{
				irtransformer_0.SqF().VisitInstrs(EMK, irtransformer_0);
			}
		}

		private void EMK(IRInstrList irinstrList_0, IRInstruction irinstruction_0, ref int int_0, IRTransformer irtransformer_0)
		{
			if (irinstruction_0.OpCode != IROpCode.__ENTRY || gM1)
			{
				return;
			}
			List<IRInstruction> list = new List<IRInstruction>();
			list.Add(irinstruction_0);
			foreach (Local variable in irtransformer_0.Context.Method.Body.Variables)
			{
				if (variable.Type.IsValueType && !variable.Type.IsPrimitive)
				{
					IRVariable iiroperand_ = irtransformer_0.Context.AllocateVRegister(ASTType.ByRef);
					list.Add(new IRInstruction(IROpCode.__LEA, iiroperand_, irtransformer_0.Context.ResolveLocal(variable)));
					int id = (int)irtransformer_0.VM.Data.GetId(variable.Type.RemovePinnedAndModifiers().ToTypeDefOrRef());
					int iNITOBJ = irtransformer_0.VM.Runtime.VMCall.INITOBJ;
					list.Add(new IRInstruction(IROpCode.PUSH, iiroperand_));
					list.Add(new IRInstruction(IROpCode.VCALL, IRConstant.FromI4(iNITOBJ), IRConstant.FromI4(id)));
				}
			}
			irinstrList_0.Replace(int_0, list);
			gM1 = true;
		}
	}
}
