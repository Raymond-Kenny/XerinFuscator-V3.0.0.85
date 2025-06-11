#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;
using XCore.CE;
using XCore.Generator;
using XCore.Injection;
using XCore.Mutation;
using XRuntime;

namespace XVM.CodeEncryption
{
	public class CodeEncryption
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class xZ6
		{
			public static readonly xZ6 MZQ;

			public static Func<TypeDef, IEnumerable<MethodDef>> uZf;

			public static Func<MethodDef, bool> RZi;

			static xZ6()
			{
				MZQ = new xZ6();
			}

			internal IEnumerable<MethodDef> sZx(TypeDef typeDef_0)
			{
				return typeDef_0.Methods;
			}

			internal bool zZs(MethodDef methodDef_0)
			{
				return methodDef_0.HasBody && methodDef_0.DeclaringType != methodDef_0.Module.GlobalType;
			}
		}

		private static IKeyDeriver Icn;

		private static List<MethodDef> ac6;

		private static uint Dcx;

		private static uint Bcs;

		private static XCore.Generator.RandomGenerator XcQ;

		private static readonly uint[] Qcf;

		private static readonly uint[] Eci;

		private static readonly uint[] ecJ;

		private static readonly uint[] Uc8;

		private static newInjector Tcz;

		private static MethodDef tL4;

		public void Execute(ModuleDefMD moduleDefMD_0)
		{
			XcQ = new XCore.Generator.RandomGenerator(GGeneration.GenerateGuidStartingWithLetter(), GGeneration.GenerateGuidStartingWithLetter());
			Uc8[0] = XcQ.NextUInt32();
			ecJ[0] = XcQ.NextUInt32();
			Qcf[0] = XcQ.NextUInt32();
			Eci[0] = XcQ.NextUInt32();
			Dcx = XcQ.NextUInt32() & 0x7F7F7F7F;
			Bcs = XcQ.NextUInt32() & 0x7F7F7F7F;
			Icn = new NormalDeriver();
			Icn.Init();
			ac6 = (from methodDef_0 in moduleDefMD_0.GetTypes().SelectMany((TypeDef typeDef_0) => typeDef_0.Methods).ToList()
				where methodDef_0.HasBody && methodDef_0.DeclaringType != methodDef_0.Module.GlobalType
				select methodDef_0).ToList();
			Tcz = new newInjector(moduleDefMD_0, typeof(CodeEncryptionRuntime));
			tL4 = Tcz.FindMember("Initialize") as MethodDef;
			tL4.Body.SimplifyMacros(tL4.Parameters);
			List<Instruction> list = tL4.Body.Instructions.ToList();
			for (int num = 0; num < list.Count; num++)
			{
				Instruction instruction = list[num];
				if (instruction.OpCode != OpCodes.Ldtoken)
				{
					if (instruction.OpCode == OpCodes.Call)
					{
						IMethod method = (IMethod)instruction.Operand;
						if (method.DeclaringType.Name == "XMutationClass" && method.Name == "Crypt")
						{
							Instruction instruction2 = list[num - 2];
							Instruction instruction3 = list[num - 1];
							Debug.Assert(instruction2.OpCode == OpCodes.Ldloc && instruction3.OpCode == OpCodes.Ldloc);
							list.RemoveAt(num);
							list.RemoveAt(num - 1);
							list.RemoveAt(num - 2);
							list.InsertRange(num - 2, Icn.EmitDerivation(tL4, (Local)instruction2.Operand, (Local)instruction3.Operand));
						}
					}
				}
				else
				{
					instruction.Operand = moduleDefMD_0.GlobalType;
				}
			}
			tL4.Body.Instructions.Clear();
			foreach (Instruction item in list)
			{
				tL4.Body.Instructions.Add(item);
			}
			XMutationHelper xMutationHelper = new XMutationHelper("XMutationClass");
			xMutationHelper.InjectKeys(tL4, new int[5] { 1, 2, 3, 4, 5 }, new int[5]
			{
				(int)(Dcx * Bcs),
				(int)Uc8[0],
				(int)ecJ[0],
				(int)Qcf[0],
				(int)Eci[0]
			});
			MethodDef methodDef = moduleDefMD_0.GlobalType.FindOrCreateStaticConstructor();
			methodDef.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(tL4));
			Tcz.Rename();
		}

		public void CreateSections(ModuleWriterBase moduleWriterBase_0)
		{
			byte[] bytes = new byte[8]
			{
				(byte)Dcx,
				(byte)(Dcx >> 8),
				(byte)(Dcx >> 16),
				(byte)(Dcx >> 24),
				(byte)Bcs,
				(byte)(Bcs >> 8),
				(byte)(Bcs >> 16),
				(byte)(Bcs >> 24)
			};
			PESection pESection = new PESection(Encoding.ASCII.GetString(bytes), 3758096448u);
			moduleWriterBase_0.Sections.Insert(0, pESection);
			uint value = moduleWriterBase_0.TextSection.Remove(moduleWriterBase_0.Metadata).Value;
			moduleWriterBase_0.TextSection.Add(moduleWriterBase_0.Metadata, value);
			value = moduleWriterBase_0.TextSection.Remove(moduleWriterBase_0.NetResources).Value;
			moduleWriterBase_0.TextSection.Add(moduleWriterBase_0.NetResources, value);
			value = moduleWriterBase_0.TextSection.Remove(moduleWriterBase_0.Constants).Value;
			pESection.Add(moduleWriterBase_0.Constants, value);
			PESection pESection2 = new PESection("", 1610612768u);
			bool flag = false;
			if (moduleWriterBase_0.StrongNameSignature != null)
			{
				value = moduleWriterBase_0.TextSection.Remove(moduleWriterBase_0.StrongNameSignature).Value;
				pESection2.Add(moduleWriterBase_0.StrongNameSignature, value);
				flag = true;
			}
			if (moduleWriterBase_0 is ModuleWriter moduleWriter)
			{
				if (moduleWriter.ImportAddressTable != null)
				{
					value = moduleWriterBase_0.TextSection.Remove(moduleWriter.ImportAddressTable).Value;
					pESection2.Add(moduleWriter.ImportAddressTable, value);
					flag = true;
				}
				if (moduleWriter.StartupStub != null)
				{
					value = moduleWriterBase_0.TextSection.Remove(moduleWriter.StartupStub).Value;
					pESection2.Add(moduleWriter.StartupStub, value);
					flag = true;
				}
			}
			if (flag)
			{
				moduleWriterBase_0.Sections.AddBeforeReloc(pESection2);
			}
			MethodBodyChunks methodBodyChunks = new MethodBodyChunks(moduleWriterBase_0.TheOptions.ShareMethodBodies);
			pESection.Add(methodBodyChunks, 4u);
			foreach (MethodDef item in ac6)
			{
				if (item.HasBody)
				{
					dnlib.DotNet.Writer.MethodBody methodBody = moduleWriterBase_0.Metadata.GetMethodBody(item);
					moduleWriterBase_0.MethodBodies.Remove(methodBody);
					methodBodyChunks.Add(methodBody);
				}
			}
			pESection.Add(new ByteArrayChunk(new byte[4]), 4u);
		}

		public void EncryptSection(ModuleWriterBase moduleWriterBase_0)
		{
			Stream destinationStream = moduleWriterBase_0.DestinationStream;
			BinaryReader binaryReader = new BinaryReader(moduleWriterBase_0.DestinationStream);
			destinationStream.Position = 60L;
			destinationStream.Position = binaryReader.ReadUInt32();
			destinationStream.Position += 6L;
			ushort num = binaryReader.ReadUInt16();
			destinationStream.Position += 12L;
			ushort num2 = binaryReader.ReadUInt16();
			destinationStream.Position += 2 + num2;
			uint num3 = 0u;
			uint num4 = 0u;
			int num5 = -1;
			if (moduleWriterBase_0 is NativeModuleWriter && moduleWriterBase_0.Module is ModuleDefMD)
			{
				num5 = ((ModuleDefMD)moduleWriterBase_0.Module).Metadata.PEImage.ImageSectionHeaders.Count;
			}
			for (int i = 0; i < num; i++)
			{
				uint num6;
				if (num5 > 0)
				{
					num5--;
					destinationStream.Write(new byte[8], 0, 8);
					num6 = 0u;
				}
				else
				{
					num6 = binaryReader.ReadUInt32() * binaryReader.ReadUInt32();
				}
				destinationStream.Position += 8L;
				if (num6 == Dcx * Bcs)
				{
					num4 = binaryReader.ReadUInt32();
					num3 = binaryReader.ReadUInt32();
				}
				else if (num6 != 0)
				{
					uint uint_ = binaryReader.ReadUInt32();
					uint uint_2 = binaryReader.ReadUInt32();
					Vc3(destinationStream, binaryReader, uint_2, uint_);
				}
				else
				{
					destinationStream.Position += 8L;
				}
				destinationStream.Position += 16L;
			}
			uint[] array = tcX();
			num4 >>= 2;
			destinationStream.Position = num3;
			uint[] array2 = new uint[num4];
			for (uint num7 = 0u; num7 < num4; num7++)
			{
				uint num8 = binaryReader.ReadUInt32();
				array2[num7] = num8 ^ array[num7 & 0xF];
				array[num7 & 0xF] = (array[num7 & 0xF] ^ num8) + 1035675673;
			}
			byte[] array3 = new byte[num4 << 2];
			Buffer.BlockCopy(array2, 0, array3, 0, array3.Length);
			destinationStream.Position = num3;
			destinationStream.Write(array3, 0, array3.Length);
		}

		private static void Vc3(Stream stream_0, BinaryReader binaryReader_0, uint uint_0, uint uint_1)
		{
			long position = stream_0.Position;
			stream_0.Position = uint_0;
			uint_1 >>= 2;
			for (uint num = 0u; num < uint_1; num++)
			{
				uint num2 = binaryReader_0.ReadUInt32();
				uint num3 = (Uc8[0] ^ num2) + ecJ[0] + Qcf[0] * Eci[0];
				Uc8[0] = ecJ[0];
				ecJ[0] = Qcf[0];
				ecJ[0] = Eci[0];
				Eci[0] = num3;
			}
			stream_0.Position = position;
		}

		private static uint[] tcX()
		{
			uint[] array = new uint[16];
			uint[] array2 = new uint[16];
			for (int i = 0; i < 16; i++)
			{
				array[i] = Eci[0];
				array2[i] = ecJ[0];
				Uc8[0] = (ecJ[0] >> 5) | (ecJ[0] << 27);
				ecJ[0] = (Qcf[0] >> 3) | (Qcf[0] << 29);
				Qcf[0] = (Eci[0] >> 7) | (Eci[0] << 25);
				Eci[0] = (Uc8[0] >> 11) | (Uc8[0] << 21);
			}
			return Icn.DeriveKey(array, array2);
		}

		static CodeEncryption()
		{
			Qcf = new uint[1];
			Eci = new uint[1];
			ecJ = new uint[1];
			Uc8 = new uint[1];
			Tcz = null;
			tL4 = null;
		}
	}
}
