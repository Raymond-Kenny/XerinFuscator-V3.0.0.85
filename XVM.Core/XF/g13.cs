#define DEBUG
using System.Diagnostics;
using System.Runtime.CompilerServices;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;

namespace XF
{
	internal class g13 : MethodBodyWriterBase
	{
		private readonly CilBody U1z;

		private readonly bool Aj4;

		private readonly Metadata Rje;

		[CompilerGenerated]
		private byte[] fju;

		[CompilerGenerated]
		private uint Bj9;

		[CompilerGenerated]
		private uint HjG;

		[SpecialName]
		[CompilerGenerated]
		public byte[] v1n()
		{
			return fju;
		}

		[SpecialName]
		[CompilerGenerated]
		private void O16(byte[] byte_0)
		{
			fju = byte_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public uint a1s()
		{
			return Bj9;
		}

		[SpecialName]
		[CompilerGenerated]
		private void L1Q(uint uint_0)
		{
			Bj9 = uint_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public uint B1i()
		{
			return HjG;
		}

		[SpecialName]
		[CompilerGenerated]
		private void P1J(uint uint_0)
		{
			HjG = uint_0;
		}

		public g13(Metadata metadata_0, CilBody cilBody_0, bool bool_0)
			: base(cilBody_0.Instructions, cilBody_0.ExceptionHandlers)
		{
			U1z = cilBody_0;
			Aj4 = bool_0;
			Rje = metadata_0;
		}

		public void Q1X()
		{
			uint num = InitializeInstructionOffsets();
			P1J((!Aj4) ? GetMaxStack() : U1z.MaxStack);
			byte[] array = new byte[num];
			ArrayWriter writer = new ArrayWriter(array);
			uint num2 = WriteInstructions(ref writer);
			Debug.Assert(num == num2);
			O16(array);
			L1Q(num);
		}

		protected override void WriteInlineField(ref ArrayWriter writer, Instruction instr)
		{
			writer.WriteUInt32(Rje.GetToken(instr.Operand).Raw);
		}

		protected override void WriteInlineMethod(ref ArrayWriter writer, Instruction instr)
		{
			writer.WriteUInt32(Rje.GetToken(instr.Operand).Raw);
		}

		protected override void WriteInlineSig(ref ArrayWriter writer, Instruction instr)
		{
			writer.WriteUInt32(Rje.GetToken(instr.Operand).Raw);
		}

		protected override void WriteInlineString(ref ArrayWriter writer, Instruction instr)
		{
		}

		protected override void WriteInlineTok(ref ArrayWriter writer, Instruction instr)
		{
			writer.WriteUInt32(Rje.GetToken(instr.Operand).Raw);
		}

		protected override void WriteInlineType(ref ArrayWriter writer, Instruction instr)
		{
			writer.WriteUInt32(Rje.GetToken(instr.Operand).Raw);
		}
	}
}
