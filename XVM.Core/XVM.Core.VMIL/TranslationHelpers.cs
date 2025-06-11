using System;
using dnlib.DotNet;
using XVM.Core.AST;
using XVM.Core.AST.IL;
using XVM.Core.AST.IR;
using XVM.Core.CFG;
using XVM.Core.RT;

namespace XVM.Core.VMIL
{
	public static class TranslationHelpers
	{
		public static ILOpCode GetLIND(ASTType asttype_0, TypeSig typeSig_0)
		{
			if (typeSig_0 == null)
			{
				switch (asttype_0)
				{
				case ASTType.I4:
				case ASTType.R4:
					return ILOpCode.LIND_DWORD;
				case ASTType.I8:
				case ASTType.R8:
					return ILOpCode.LIND_QWORD;
				default:
					return ILOpCode.LIND_OBJECT;
				case ASTType.Ptr:
					return ILOpCode.LIND_PTR;
				}
			}
			switch (typeSig_0.ElementType)
			{
			case ElementType.Boolean:
			case ElementType.I1:
			case ElementType.U1:
				return ILOpCode.LIND_BYTE;
			case ElementType.Char:
			case ElementType.I2:
			case ElementType.U2:
				return ILOpCode.LIND_WORD;
			case ElementType.I4:
			case ElementType.U4:
			case ElementType.R4:
				return ILOpCode.LIND_DWORD;
			case ElementType.I8:
			case ElementType.U8:
			case ElementType.R8:
				return ILOpCode.LIND_QWORD;
			default:
				return ILOpCode.LIND_OBJECT;
			case ElementType.Ptr:
			case ElementType.I:
			case ElementType.U:
				return ILOpCode.LIND_PTR;
			}
		}

		public static ILOpCode GetLIND(this IRRegister irregister_0)
		{
			return GetLIND(irregister_0.Type, (irregister_0.SourceVariable == null) ? null : irregister_0.SourceVariable.RawType);
		}

		public static ILOpCode GetLIND(this IRPointer irpointer_0)
		{
			return GetLIND(irpointer_0.Type, (irpointer_0.SourceVariable == null) ? null : irpointer_0.SourceVariable.RawType);
		}

		public static ILOpCode GetSIND(ASTType asttype_0, TypeSig typeSig_0)
		{
			if (typeSig_0 == null)
			{
				switch (asttype_0)
				{
				case ASTType.I4:
				case ASTType.R4:
					return ILOpCode.SIND_DWORD;
				case ASTType.I8:
				case ASTType.R8:
					return ILOpCode.SIND_QWORD;
				default:
					return ILOpCode.SIND_OBJECT;
				case ASTType.Ptr:
					return ILOpCode.SIND_PTR;
				}
			}
			switch (typeSig_0.ElementType)
			{
			case ElementType.Boolean:
			case ElementType.I1:
			case ElementType.U1:
				return ILOpCode.SIND_BYTE;
			case ElementType.Char:
			case ElementType.I2:
			case ElementType.U2:
				return ILOpCode.SIND_WORD;
			case ElementType.I4:
			case ElementType.U4:
			case ElementType.R4:
				return ILOpCode.SIND_DWORD;
			case ElementType.I8:
			case ElementType.U8:
			case ElementType.R8:
				return ILOpCode.SIND_QWORD;
			default:
				return ILOpCode.SIND_OBJECT;
			case ElementType.Ptr:
			case ElementType.I:
			case ElementType.U:
				return ILOpCode.SIND_PTR;
			}
		}

		public static ILOpCode GetSIND(this IRRegister irregister_0)
		{
			return GetSIND(irregister_0.Type, (irregister_0.SourceVariable != null) ? irregister_0.SourceVariable.RawType : null);
		}

		public static ILOpCode GetSIND(this IRPointer irpointer_0)
		{
			return GetSIND(irpointer_0.Type, (irpointer_0.SourceVariable == null) ? null : irpointer_0.SourceVariable.RawType);
		}

		public static ILOpCode GetPUSHR(ASTType asttype_0, TypeSig typeSig_0)
		{
			if (typeSig_0 == null)
			{
				switch (asttype_0)
				{
				case ASTType.I4:
				case ASTType.R4:
					return ILOpCode.PUSHR_DWORD;
				default:
					return ILOpCode.PUSHR_OBJECT;
				case ASTType.I8:
				case ASTType.R8:
				case ASTType.Ptr:
					return ILOpCode.PUSHR_QWORD;
				}
			}
			switch (typeSig_0.ElementType)
			{
			case ElementType.Boolean:
			case ElementType.I1:
			case ElementType.U1:
				return ILOpCode.PUSHR_BYTE;
			case ElementType.Char:
			case ElementType.I2:
			case ElementType.U2:
				return ILOpCode.PUSHR_WORD;
			case ElementType.I4:
			case ElementType.U4:
			case ElementType.R4:
				return ILOpCode.PUSHR_DWORD;
			default:
				return ILOpCode.PUSHR_OBJECT;
			case ElementType.I8:
			case ElementType.U8:
			case ElementType.R8:
			case ElementType.Ptr:
				return ILOpCode.PUSHR_QWORD;
			}
		}

		public static ILOpCode GetPUSHR(this IRRegister irregister_0)
		{
			return GetPUSHR(irregister_0.Type, (irregister_0.SourceVariable != null) ? irregister_0.SourceVariable.RawType : null);
		}

		public static ILOpCode GetPUSHR(this IRPointer irpointer_0)
		{
			return GetPUSHR(irpointer_0.Type, (irpointer_0.SourceVariable == null) ? null : irpointer_0.SourceVariable.RawType);
		}

		public static ILOpCode GetPUSHI(this ASTType asttype_0)
		{
			switch (asttype_0)
			{
			case ASTType.I4:
			case ASTType.R4:
				return ILOpCode.PUSHI_DWORD;
			default:
				throw new NotSupportedException();
			case ASTType.I8:
			case ASTType.R8:
			case ASTType.Ptr:
				return ILOpCode.PUSHI_QWORD;
			}
		}

		public static void PushOperand(this ILTranslator iltranslator_0, IIROperand iiroperand_0)
		{
			if (!(iiroperand_0 is IRRegister))
			{
				if (!(iiroperand_0 is IRPointer))
				{
					if (!(iiroperand_0 is IRConstant))
					{
						if (iiroperand_0 is IRMetaTarget)
						{
							MethodDef methodDef_ = (MethodDef)((IRMetaTarget)iiroperand_0).MetadataItem;
							iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.PUSHI_DWORD, new ILMethodTarget(methodDef_)));
							return;
						}
						if (iiroperand_0 is IRBlockTarget)
						{
							IBasicBlock target = ((IRBlockTarget)iiroperand_0).Target;
							iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.PUSHI_DWORD, new ILBlockTarget(target)));
							return;
						}
						if (iiroperand_0 is IRJumpTable)
						{
							IBasicBlock[] targets = ((IRJumpTable)iiroperand_0).Targets;
							iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.PUSHI_DWORD, new ILJumpTable(targets)));
							return;
						}
						if (!(iiroperand_0 is IRDataTarget))
						{
							throw new NotSupportedException();
						}
						BinaryChunk target2 = ((IRDataTarget)iiroperand_0).Target;
						iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.PUSHI_DWORD, new ILDataTarget(target2)));
					}
					else
					{
						IRConstant iRConstant = (IRConstant)iiroperand_0;
						if (iRConstant.Value == null)
						{
							iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.PUSHI_DWORD, ILImmediate.Create(0, ASTType.O)));
						}
						else
						{
							iltranslator_0.wAE().Add(new ILInstruction(iRConstant.Type.Value.GetPUSHI(), ILImmediate.Create(iRConstant.Value, iRConstant.Type.Value)));
						}
					}
					return;
				}
				IRPointer iRPointer = (IRPointer)iiroperand_0;
				ILRegister iiloperand_ = ILRegister.LookupRegister(iRPointer.Register.Register);
				iltranslator_0.wAE().Add(new ILInstruction(iRPointer.Register.GetPUSHR(), iiloperand_));
				if (iRPointer.Offset != 0)
				{
					iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.PUSHI_DWORD, ILImmediate.Create(iRPointer.Offset, ASTType.I4)));
					if (iRPointer.Register.Type != ASTType.I4)
					{
						iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.ADD_QWORD));
					}
					else
					{
						iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.ADD_DWORD));
					}
				}
				iltranslator_0.wAE().Add(new ILInstruction(iRPointer.GetLIND()));
			}
			else
			{
				ILRegister iiloperand_2 = ILRegister.LookupRegister(((IRRegister)iiroperand_0).Register);
				iltranslator_0.wAE().Add(new ILInstruction(((IRRegister)iiroperand_0).GetPUSHR(), iiloperand_2));
			}
		}

		public static void PopOperand(this ILTranslator iltranslator_0, IIROperand iiroperand_0)
		{
			if (!(iiroperand_0 is IRRegister))
			{
				if (!(iiroperand_0 is IRPointer))
				{
					throw new NotSupportedException();
				}
				IRPointer iRPointer = (IRPointer)iiroperand_0;
				ILRegister iiloperand_ = ILRegister.LookupRegister(iRPointer.Register.Register);
				iltranslator_0.wAE().Add(new ILInstruction(iRPointer.Register.GetPUSHR(), iiloperand_));
				if (iRPointer.Offset != 0)
				{
					iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.PUSHI_DWORD, ILImmediate.Create(iRPointer.Offset, ASTType.I4)));
					if (iRPointer.Register.Type == ASTType.I4)
					{
						iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.ADD_DWORD));
					}
					else
					{
						iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.ADD_QWORD));
					}
				}
				iltranslator_0.wAE().Add(new ILInstruction(iRPointer.GetSIND()));
			}
			else
			{
				ILRegister iiloperand_2 = ILRegister.LookupRegister(((IRRegister)iiroperand_0).Register);
				iltranslator_0.wAE().Add(new ILInstruction(ILOpCode.POP, iiloperand_2));
			}
		}
	}
}
