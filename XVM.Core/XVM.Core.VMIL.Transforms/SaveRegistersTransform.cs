using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using XVM.Core.AST;
using XVM.Core.AST.IL;
using XVM.Core.AST.IR;
using XVM.Core.VM;

namespace XVM.Core.VMIL.Transforms
{
	public class SaveRegistersTransform : IPostTransform
	{
		[CompilerGenerated]
		private sealed class i59
		{
			public ILInstruction A5q;

			internal ILInstruction X5G(VMRegisters vmregisters_0)
			{
				return new ILInstruction(ILOpCode.PUSHR_OBJECT, ILRegister.LookupRegister(vmregisters_0), A5q);
			}

			internal ILInstruction q5I(VMRegisters vmregisters_0)
			{
				return new ILInstruction(ILOpCode.POP, ILRegister.LookupRegister(vmregisters_0), A5q);
			}
		}

		private HashSet<VMRegisters> zAh;

		public void Initialize(ILPostTransformer ilpostTransformer_0)
		{
			zAh = ilpostTransformer_0.Runtime.Descriptor.Data.LookupInfo(ilpostTransformer_0.Method).UsedRegister;
		}

		public void Transform(ILPostTransformer ilpostTransformer_0)
		{
			ilpostTransformer_0.fM6().VisitInstrs(bAU, ilpostTransformer_0);
		}

		private void bAU(ILInstrList ilinstrList_0, ILInstruction ilinstruction_0, ref int int_0, ILPostTransformer ilpostTransformer_0)
		{
			if (ilinstruction_0.OpCode != ILOpCode.__BEGINCALL && ilinstruction_0.OpCode != ILOpCode.__ENDCALL)
			{
				return;
			}
			InstrCallInfo instrCallInfo = (InstrCallInfo)ilinstruction_0.Annotation;
			if (instrCallInfo.IsECall)
			{
				ilinstrList_0.RemoveAt(int_0);
				int_0--;
				return;
			}
			HashSet<VMRegisters> hashSet = new HashSet<VMRegisters>(zAh);
			IRVariable iRVariable = (IRVariable)instrCallInfo.ReturnValue;
			if (iRVariable == null)
			{
				hashSet.Add(VMRegisters.R0);
			}
			else if (instrCallInfo.ReturnSlot != null)
			{
				hashSet.Add(VMRegisters.R0);
			}
			else
			{
				VMRegisters register = instrCallInfo.ReturnRegister.Register;
				hashSet.Remove(register);
				if (register != VMRegisters.R0)
				{
					hashSet.Add(VMRegisters.R0);
				}
			}
			if (ilinstruction_0.OpCode == ILOpCode.__BEGINCALL)
			{
				ilinstrList_0.Replace(int_0, hashSet.Select((VMRegisters vmregisters_0) => new ILInstruction(ILOpCode.PUSHR_OBJECT, ILRegister.LookupRegister(vmregisters_0), ilinstruction_0)));
			}
			else
			{
				ilinstrList_0.Replace(int_0, hashSet.Select((VMRegisters vmregisters_0) => new ILInstruction(ILOpCode.POP, ILRegister.LookupRegister(vmregisters_0), ilinstruction_0)).Reverse());
			}
			int_0--;
		}
	}
}
