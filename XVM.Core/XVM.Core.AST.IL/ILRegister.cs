using System.Collections.Generic;
using System.Runtime.CompilerServices;
using XVM.Core.VM;

namespace XVM.Core.AST.IL
{
	public class ILRegister : IILOperand
	{
		private static readonly Dictionary<VMRegisters, ILRegister> kcl;

		[CompilerGenerated]
		private VMRegisters ucZ;

		public static readonly ILRegister R0;

		public static readonly ILRegister R1;

		public static readonly ILRegister R2;

		public static readonly ILRegister R3;

		public static readonly ILRegister R4;

		public static readonly ILRegister R5;

		public static readonly ILRegister R6;

		public static readonly ILRegister R7;

		public static readonly ILRegister BP;

		public static readonly ILRegister SP;

		public static readonly ILRegister IP;

		public static readonly ILRegister FL;

		public static readonly ILRegister K1;

		public VMRegisters Register
		{
			[CompilerGenerated]
			get
			{
				return ucZ;
			}
			[CompilerGenerated]
			set
			{
				ucZ = value;
			}
		}

		private ILRegister(VMRegisters vmregisters_0)
		{
			Register = vmregisters_0;
			kcl.Add(vmregisters_0, this);
		}

		public override string ToString()
		{
			return Register.ToString();
		}

		public static ILRegister LookupRegister(VMRegisters vmregisters_0)
		{
			return kcl[vmregisters_0];
		}

		static ILRegister()
		{
			kcl = new Dictionary<VMRegisters, ILRegister>();
			R0 = new ILRegister(VMRegisters.R0);
			R1 = new ILRegister(VMRegisters.R1);
			R2 = new ILRegister(VMRegisters.R2);
			R3 = new ILRegister(VMRegisters.R3);
			R4 = new ILRegister(VMRegisters.R4);
			R5 = new ILRegister(VMRegisters.R5);
			R6 = new ILRegister(VMRegisters.R6);
			R7 = new ILRegister(VMRegisters.R7);
			BP = new ILRegister(VMRegisters.BP);
			SP = new ILRegister(VMRegisters.SP);
			IP = new ILRegister(VMRegisters.IP);
			FL = new ILRegister(VMRegisters.FL);
			K1 = new ILRegister(VMRegisters.K1);
		}
	}
}
