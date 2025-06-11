#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XF;

namespace XVM.Core.RTProtections.Constants
{
	public class EncodePhase
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class PlZ
		{
			public static readonly PlZ hlS;

			public static Func<DecoderDesc, byte> bla;

			static PlZ()
			{
				hlS = new PlZ();
			}

			internal byte PlT(DecoderDesc decoderDesc_0)
			{
				return decoderDesc_0.StringID;
			}
		}

		public CEContext context;

		public void Execute(CEContext cecontext_0)
		{
			context = cecontext_0;
			if (context == null)
			{
				return;
			}
			Dictionary<object, List<InstructionReference>> dictionary = new Dictionary<object, List<InstructionReference>>();
			i1P(context, dictionary);
			context.ReferenceRepl = new Dictionary<MethodDef, List<ReplaceableInstructionReference>>();
			context.EncodedBuffer = new List<uint>();
			foreach (KeyValuePair<object, List<InstructionReference>> item in dictionary)
			{
				if (item.Key is string)
				{
					C1U(context, (string)item.Key, item.Value);
				}
			}
			ReferenceReplacer.ReplaceReference(context);
			byte[] array = new byte[context.EncodedBuffer.Count * 4];
			int num = 0;
			foreach (uint item2 in context.EncodedBuffer)
			{
				array[num++] = (byte)(item2 & 0xFF);
				array[num++] = (byte)((item2 >> 8) & 0xFF);
				array[num++] = (byte)((item2 >> 16) & 0xFF);
				array[num++] = (byte)((item2 >> 24) & 0xFF);
			}
			Debug.Assert(num == array.Length);
			array = context.Compressor.LZMA_Compress(array);
			uint num2 = (uint)(array.Length + 3) / 4u;
			num2 = (num2 + 15) & 0xFFFFFFF0u;
			uint[] array2 = new uint[num2];
			Buffer.BlockCopy(array, 0, array2, 0, array.Length);
			Debug.Assert(num2 % 16 == 0);
			uint int_ = 123456u;
			uint[] array3 = new uint[16];
			uint num3 = 123456u;
			for (int i = 0; i < 16; i++)
			{
				num3 ^= num3 >> 12;
				num3 ^= num3 << 25;
				num3 = (array3[i] = num3 ^ (num3 >> 27));
			}
			byte[] array4 = new byte[array2.Length * 4];
			for (num = 0; num < array2.Length; num += 16)
			{
				uint[] src = context.ModeHandler.Encrypt(array2, num, array3);
				for (int j = 0; j < 16; j++)
				{
					array3[j] ^= array2[num + j];
				}
				Buffer.BlockCopy(src, 0, array4, num * 4, 64);
			}
			Debug.Assert(num == array2.Length);
			TypeDefUser typeDefUser = new TypeDefUser(cecontext_0.VMRuntime.o2o().i2i(cecontext_0.VMRuntime.Descriptor.iqK().NextString()), cecontext_0.VMRuntime.RTModule.CorLibTypes.GetTypeRef("System", "ValueType"))
			{
				Layout = TypeAttributes.ExplicitLayout,
				Visibility = TypeAttributes.Sealed,
				IsSealed = true,
				ClassLayout = new ClassLayoutUser(0, (uint)array4.Length)
			};
			cecontext_0.VMRuntime.RTModule.Types.Add(typeDefUser);
			FieldDefUser fieldDefUser = new FieldDefUser(cecontext_0.VMRuntime.o2o().i2i(cecontext_0.VMRuntime.Descriptor.iqK().NextString()), new FieldSig(typeDefUser.ToTypeSig()), FieldAttributes.Private | FieldAttributes.Static | FieldAttributes.HasFieldRVA)
			{
				HasFieldRVA = true,
				InitialValue = array4
			};
			cecontext_0.VMRuntime.f2C().HKo.Fields.Add(fieldDefUser);
			XjJ.sj8(context.InitMethod, 0, array4.Length / 4);
			XjJ.sj8(context.InitMethod, 1, (int)int_);
			XjJ.wOM(context.InitMethod, bool_0: true, out var int_2);
			context.InitMethod.Body.Instructions.Insert(int_2, Instruction.Create(OpCodes.Ldtoken, fieldDefUser));
			context.InitMethod.Body.Instructions.Insert(int_2 + 1, Instruction.Create(OpCodes.Call, cecontext_0.VMRuntime.RTModule.Import(cecontext_0.VMRuntime.f2C().SKm)));
			context.InitMethod.Body.Instructions.Insert(int_2 + 2, Instruction.Create(OpCodes.Callvirt, cecontext_0.VMRuntime.RTModule.Import(cecontext_0.VMRuntime.f2C().TK5)));
		}

		private int N1a(CEContext cecontext_0, byte[] byte_0)
		{
			int count = cecontext_0.EncodedBuffer.Count;
			cecontext_0.EncodedBuffer.Add((uint)byte_0.Length);
			int num = byte_0.Length / 4;
			int num2 = byte_0.Length % 4;
			for (int i = 0; i < num; i++)
			{
				uint item = (uint)(byte_0[i * 4] | (byte_0[i * 4 + 1] << 8) | (byte_0[i * 4 + 2] << 16) | (byte_0[i * 4 + 3] << 24));
				cecontext_0.EncodedBuffer.Add(item);
			}
			if (num2 > 0)
			{
				int num3 = num * 4;
				uint num4 = 0u;
				for (int j = 0; j < num2; j++)
				{
					num4 |= (uint)(byte_0[num3 + j] << j * 8);
				}
				cecontext_0.EncodedBuffer.Add(num4);
			}
			return count;
		}

		private void C1U(CEContext cecontext_0, string string_0, List<InstructionReference> list_0)
		{
			int int_ = N1a(cecontext_0, Encoding.UTF8.GetBytes(string_0));
			p1h(cecontext_0, list_0, int_, (DecoderDesc decoderDesc_0) => decoderDesc_0.StringID);
		}

		private void p1h(CEContext cecontext_0, List<InstructionReference> list_0, int int_0, Func<DecoderDesc, byte> func_0)
		{
			foreach (InstructionReference item in list_0)
			{
				int index = cecontext_0.Random.method_2(0, cecontext_0.Decoders.Count - 1);
				DecoderInfo decoderInfo = cecontext_0.Decoders[index];
				DecoderDesc decoderDesc = decoderInfo.DecoderDesc;
				uint uint_ = (uint)(int_0 | (func_0(decoderDesc) << 30));
				uint_ = cecontext_0.ModeHandler.Encode(decoderDesc.Data, cecontext_0, uint_);
				uint num = cecontext_0.Random.method_3();
				uint_ ^= num;
				cecontext_0.ReferenceRepl.AddListEntry(item.Method, new ReplaceableInstructionReference
				{
					Target = item.Instruction,
					Id = uint_,
					Key = num,
					Decoder = decoderInfo.Method
				});
			}
		}

		private void i1P(CEContext cecontext_0, Dictionary<object, List<InstructionReference>> dictionary_0)
		{
			foreach (TypeDef type in cecontext_0.Module.Types)
			{
				if (type == cecontext_0.VMRuntime.f2C().HKo)
				{
					continue;
				}
				foreach (MethodDef method in type.Methods)
				{
					if (!method.HasBody)
					{
						continue;
					}
					foreach (Instruction instruction in method.Body.Instructions)
					{
						if (instruction.OpCode == OpCodes.Ldstr)
						{
							string text = (string)instruction.Operand;
							if (!string.IsNullOrEmpty(text))
							{
								dictionary_0.AddListEntry(text, new InstructionReference
								{
									Method = method,
									Instruction = instruction
								});
							}
						}
					}
				}
			}
		}
	}
}
