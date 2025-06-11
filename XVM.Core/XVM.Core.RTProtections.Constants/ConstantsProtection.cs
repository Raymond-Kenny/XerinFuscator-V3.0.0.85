#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XF;
using XVM.Core.RT;
using XVM.Core.Services;
using XVM.DynCipher;

namespace XVM.Core.RTProtections.Constants
{
	public class ConstantsProtection
	{
		private static CEContext a1l;

		public void Execute(ModuleDef moduleDef_0, VMRuntime vmruntime_0)
		{
			a1l = new CEContext();
			a1l.Random = new RandomGenerator(32);
			a1l.DynCipher = new DynCipherService();
			a1l.VMRuntime = vmruntime_0;
			a1l.Module = moduleDef_0;
			a1l.Options = vmruntime_0.RTModuleWriterOptions;
			a1l.DecoderCount = 1;
			a1l.ModeHandler = new DynamicMode();
			a1l.Compressor = vmruntime_0.CompressionService;
			K15(a1l);
			g1o(a1l);
			new EncodePhase().Execute(a1l);
			a1l.ReferenceRepl.Clear();
			a1l.EncodedBuffer.Clear();
			a1l.ReferenceRepl = new Dictionary<MethodDef, List<ReplaceableInstructionReference>>();
			a1l.EncodedBuffer = new List<uint>();
		}

		private void K15(CEContext cecontext_0)
		{
			cecontext_0.InitMethod = a1l.VMRuntime.f2C().DKl;
			cecontext_0.Decoders = new List<DecoderInfo>();
			for (int i = 0; i < cecontext_0.DecoderCount; i++)
			{
				MethodDef yKZ = a1l.VMRuntime.f2C().yKZ;
				for (int j = 0; j < yKZ.Body.Instructions.Count; j++)
				{
					Instruction instruction = yKZ.Body.Instructions[j];
					IMethod method = instruction.Operand as IMethod;
					if (instruction.OpCode == OpCodes.Call && method.DeclaringType.Name == TNd.Q29 && method.Name == TNd.O2q)
					{
						yKZ.Body.Instructions[j] = Instruction.Create(OpCodes.Sizeof, new GenericMVar(0).ToTypeDefOrRef());
					}
				}
				DecoderDesc decoderDesc = new DecoderDesc();
				decoderDesc.StringID = (byte)(cecontext_0.Random.NextByte() & 3);
				do
				{
					decoderDesc.NumberID = (byte)(cecontext_0.Random.NextByte() & 3);
				}
				while (decoderDesc.NumberID == decoderDesc.StringID);
				do
				{
					decoderDesc.InitializerID = (byte)(cecontext_0.Random.NextByte() & 3);
				}
				while (decoderDesc.InitializerID == decoderDesc.StringID || decoderDesc.InitializerID == decoderDesc.NumberID);
				XjJ.jOu(yKZ, new int[3] { 0, 1, 2 }, new int[3] { decoderDesc.StringID, decoderDesc.NumberID, decoderDesc.InitializerID });
				decoderDesc.Data = cecontext_0.ModeHandler.CreateDecoder(yKZ, cecontext_0);
				cecontext_0.Decoders.Add(new DecoderInfo
				{
					Method = yKZ,
					DecoderDesc = decoderDesc
				});
			}
		}

		private void g1o(CEContext cecontext_0)
		{
			cecontext_0.InitMethod.Body.SimplifyMacros(cecontext_0.InitMethod.Parameters);
			List<Instruction> list = cecontext_0.InitMethod.Body.Instructions.ToList();
			for (int i = 0; i < list.Count; i++)
			{
				Instruction instruction = list[i];
				IMethod method = instruction.Operand as IMethod;
				if (instruction.OpCode == OpCodes.Call && method.DeclaringType.Name == TNd.Q29 && method.Name == TNd.T2A)
				{
					Instruction instruction2 = list[i - 2];
					Instruction instruction3 = list[i - 1];
					Debug.Assert(instruction2.OpCode == OpCodes.Ldloc && instruction3.OpCode == OpCodes.Ldloc);
					list.RemoveAt(i);
					list.RemoveAt(i - 1);
					list.RemoveAt(i - 2);
					list.InsertRange(i - 2, cecontext_0.ModeHandler.EmitDecrypt(cecontext_0.InitMethod, cecontext_0, (Local)instruction2.Operand, (Local)instruction3.Operand));
				}
			}
			cecontext_0.InitMethod.Body.Instructions.Clear();
			foreach (Instruction item in list)
			{
				cecontext_0.InitMethod.Body.Instructions.Add(item);
			}
		}
	}
}
