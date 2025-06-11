using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using XVM.Runtime.XVM.Runtime.Dynamic;
using XVM.Runtime.XVM.Runtime.Execution;

namespace XVM.Runtime.XVM.Runtime
{
	internal static class Utils
	{
		public static Constants ReadConstants(BinaryReader reader)
		{
			Constants constants = new Constants();
			constants.REG_R0 = (byte)Decrypt(reader.ReadInt32());
			constants.REG_R1 = (byte)Decrypt(reader.ReadInt32());
			constants.REG_R2 = (byte)Decrypt(reader.ReadInt32());
			constants.REG_R3 = (byte)Decrypt(reader.ReadInt32());
			constants.REG_R4 = (byte)Decrypt(reader.ReadInt32());
			constants.REG_R5 = (byte)Decrypt(reader.ReadInt32());
			constants.REG_R6 = (byte)Decrypt(reader.ReadInt32());
			constants.REG_R7 = (byte)Decrypt(reader.ReadInt32());
			constants.REG_BP = (byte)Decrypt(reader.ReadInt32());
			constants.REG_SP = (byte)Decrypt(reader.ReadInt32());
			constants.REG_IP = (byte)Decrypt(reader.ReadInt32());
			constants.REG_FL = (byte)Decrypt(reader.ReadInt32());
			constants.REG_K1 = (byte)Decrypt(reader.ReadInt32());
			constants.FL_OVERFLOW = (byte)Decrypt(reader.ReadInt32());
			constants.FL_CARRY = (byte)Decrypt(reader.ReadInt32());
			constants.FL_ZERO = (byte)Decrypt(reader.ReadInt32());
			constants.FL_SIGN = (byte)Decrypt(reader.ReadInt32());
			constants.FL_UNSIGNED = (byte)Decrypt(reader.ReadInt32());
			constants.OP_NOP = (byte)Decrypt(reader.ReadInt32());
			constants.OP_LIND_PTR = (byte)Decrypt(reader.ReadInt32());
			constants.OP_LIND_OBJECT = (byte)Decrypt(reader.ReadInt32());
			constants.OP_LIND_BYTE = (byte)Decrypt(reader.ReadInt32());
			constants.OP_LIND_WORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_LIND_DWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_LIND_QWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_SIND_PTR = (byte)Decrypt(reader.ReadInt32());
			constants.OP_SIND_OBJECT = (byte)Decrypt(reader.ReadInt32());
			constants.OP_SIND_BYTE = (byte)Decrypt(reader.ReadInt32());
			constants.OP_SIND_WORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_SIND_DWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_SIND_QWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_POP = (byte)Decrypt(reader.ReadInt32());
			constants.OP_PUSHR_OBJECT = (byte)Decrypt(reader.ReadInt32());
			constants.OP_PUSHR_BYTE = (byte)Decrypt(reader.ReadInt32());
			constants.OP_PUSHR_WORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_PUSHR_DWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_PUSHR_QWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_PUSHI_DWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_PUSHI_QWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_SX_BYTE = (byte)Decrypt(reader.ReadInt32());
			constants.OP_SX_WORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_SX_DWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_CALL = (byte)Decrypt(reader.ReadInt32());
			constants.OP_RET = (byte)Decrypt(reader.ReadInt32());
			constants.OP_NOR_DWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_NOR_QWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_CMP = (byte)Decrypt(reader.ReadInt32());
			constants.OP_CMP_DWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_CMP_QWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_CMP_R32 = (byte)Decrypt(reader.ReadInt32());
			constants.OP_CMP_R64 = (byte)Decrypt(reader.ReadInt32());
			constants.OP_JZ = (byte)Decrypt(reader.ReadInt32());
			constants.OP_JNZ = (byte)Decrypt(reader.ReadInt32());
			constants.OP_JMP = (byte)Decrypt(reader.ReadInt32());
			constants.OP_SWT = (byte)Decrypt(reader.ReadInt32());
			constants.OP_ADD_DWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_ADD_QWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_ADD_R32 = (byte)Decrypt(reader.ReadInt32());
			constants.OP_ADD_R64 = (byte)Decrypt(reader.ReadInt32());
			constants.OP_SUB_R32 = (byte)Decrypt(reader.ReadInt32());
			constants.OP_SUB_R64 = (byte)Decrypt(reader.ReadInt32());
			constants.OP_MUL_DWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_MUL_QWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_MUL_R32 = (byte)Decrypt(reader.ReadInt32());
			constants.OP_MUL_R64 = (byte)Decrypt(reader.ReadInt32());
			constants.OP_DIV_DWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_DIV_QWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_DIV_R32 = (byte)Decrypt(reader.ReadInt32());
			constants.OP_DIV_R64 = (byte)Decrypt(reader.ReadInt32());
			constants.OP_REM_DWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_REM_QWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_REM_R32 = (byte)Decrypt(reader.ReadInt32());
			constants.OP_REM_R64 = (byte)Decrypt(reader.ReadInt32());
			constants.OP_SHR_DWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_SHR_QWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_SHL_DWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_SHL_QWORD = (byte)Decrypt(reader.ReadInt32());
			constants.OP_FCONV_R32_R64 = (byte)Decrypt(reader.ReadInt32());
			constants.OP_FCONV_R64_R32 = (byte)Decrypt(reader.ReadInt32());
			constants.OP_FCONV_R32 = (byte)Decrypt(reader.ReadInt32());
			constants.OP_FCONV_R64 = (byte)Decrypt(reader.ReadInt32());
			constants.OP_ICONV_PTR = (byte)Decrypt(reader.ReadInt32());
			constants.OP_ICONV_R64 = (byte)Decrypt(reader.ReadInt32());
			constants.OP_VCALL = (byte)Decrypt(reader.ReadInt32());
			constants.OP_TRY = (byte)Decrypt(reader.ReadInt32());
			constants.OP_LEAVE = (byte)Decrypt(reader.ReadInt32());
			constants.VCALL_EXIT = (byte)Decrypt(reader.ReadInt32());
			constants.VCALL_BREAK = (byte)Decrypt(reader.ReadInt32());
			constants.VCALL_ECALL = (byte)Decrypt(reader.ReadInt32());
			constants.VCALL_CAST = (byte)Decrypt(reader.ReadInt32());
			constants.VCALL_CKFINITE = (byte)Decrypt(reader.ReadInt32());
			constants.VCALL_CKOVERFLOW = (byte)Decrypt(reader.ReadInt32());
			constants.VCALL_RANGECHK = (byte)Decrypt(reader.ReadInt32());
			constants.VCALL_INITOBJ = (byte)Decrypt(reader.ReadInt32());
			constants.VCALL_LDFLD = (byte)Decrypt(reader.ReadInt32());
			constants.VCALL_LDFTN = (byte)Decrypt(reader.ReadInt32());
			constants.VCALL_TOKEN = (byte)Decrypt(reader.ReadInt32());
			constants.VCALL_THROW = (byte)Decrypt(reader.ReadInt32());
			constants.VCALL_SIZEOF = (byte)Decrypt(reader.ReadInt32());
			constants.VCALL_STFLD = (byte)Decrypt(reader.ReadInt32());
			constants.VCALL_BOX = (byte)Decrypt(reader.ReadInt32());
			constants.VCALL_UNBOX = (byte)Decrypt(reader.ReadInt32());
			constants.VCALL_LOCALLOC = (byte)Decrypt(reader.ReadInt32());
			constants.ECALL_CALL = (byte)Decrypt(reader.ReadInt32());
			constants.ECALL_CALLVIRT = (byte)Decrypt(reader.ReadInt32());
			constants.ECALL_NEWOBJ = (byte)Decrypt(reader.ReadInt32());
			constants.ECALL_CALLVIRT_CONSTRAINED = (byte)Decrypt(reader.ReadInt32());
			constants.EH_CATCH = (byte)Decrypt(reader.ReadInt32());
			constants.EH_FILTER = (byte)Decrypt(reader.ReadInt32());
			constants.EH_FAULT = (byte)Decrypt(reader.ReadInt32());
			constants.EH_FINALLY = (byte)Decrypt(reader.ReadInt32());
			return constants;
		}

		public static int Decrypt(int input, double Key = 0.0)
		{
			byte[] array = new byte[8];
			if (Key == 0.0)
			{
				array[0] = (byte)Mutation.IntKey0;
				array[1] = (byte)Mutation.IntKey1;
				array[2] = (byte)Mutation.IntKey2;
				array[3] = (byte)Mutation.IntKey3;
				array[4] = (byte)Mutation.IntKey4;
				array[5] = (byte)Mutation.IntKey5;
				array[6] = (byte)Mutation.IntKey6;
				array[7] = (byte)Mutation.IntKey7;
			}
			else
			{
				array = BitConverter.GetBytes(Key);
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int[] array2 = new int[8];
			for (int i = 0; i < 8; i++)
			{
				array2[i] = array[i] % (i + 1) ^ input ^ i + 1 ^ input;
			}
			for (int j = 0; j < 8; j++)
			{
				int num5 = (int)Math.Log10(array2[j]);
				num ^= array2[j] ^ (array2[j] ^ num5) * j >> (int)(j * 0.25f);
				num2 += array2[j] >> ((array2[j] ^ num5) * j << (int)((short)j + 0.58f));
				num3 -= array2[j] << ((array2[j] ^ num5) * j >> (int)(j * 0.41f));
				num4 ^= array2[j] + ((array2[j] ^ num5) * j << (int)(j - 0.99f));
			}
			return num ^ input ^ num2 ^ input ^ num3 ^ input ^ num4;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Delegate GetDelegateForFunctionPointer(IntPtr ptr, Type type)
		{
			return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[2]
			{
				typeof(IntPtr),
				typeof(Type)
			}).Invoke(null, new object[2] { ptr, type });
		}

		public static void UpdateFL(VMContext ctx, ulong op1, ulong op2, ulong flResult, ulong result, ref byte fl, byte mask)
		{
			byte b = 0;
			if (result == 0)
			{
				b |= ctx.Data.Constants.FL_ZERO;
			}
			if ((result & 0x80000000u) != 0)
			{
				b |= ctx.Data.Constants.FL_SIGN;
			}
			if (((op1 ^ flResult) & (op2 ^ flResult) & 0x80000000u) != 0)
			{
				b |= ctx.Data.Constants.FL_OVERFLOW;
			}
			if (((op1 ^ (op1 ^ op2) & (op2 ^ flResult)) & 0x80000000u) != 0)
			{
				b |= ctx.Data.Constants.FL_CARRY;
			}
			fl = (byte)(fl & ~mask | b & mask);
		}
	}
}
