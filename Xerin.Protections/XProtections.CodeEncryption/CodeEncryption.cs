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
using XCore.Context;
using XCore.Generator;
using XCore.Injection;
using XCore.Mutation;
using XCore.Protections;
using XRuntime;

namespace XProtections.CodeEncryption
{
	public class CodeEncryption : Protection
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class Dmt
		{
			public static readonly Dmt CmH;

			public static Func<TypeDef, IEnumerable<MethodDef>> nmd;

			public static Func<MethodDef, bool> im3;

			static Dmt()
			{
				CmH = new Dmt();
			}

			internal IEnumerable<MethodDef> Hmf(TypeDef typeDef_0)
			{
				return typeDef_0.Methods;
			}

			internal bool YmW(MethodDef methodDef_0)
			{
				return methodDef_0.HasBody && methodDef_0.DeclaringType != methodDef_0.Module.GlobalType;
			}
		}

		private static IKeyDeriver nxr;

		private static List<MethodDef> Ux6;

		private static uint zxq;

		private static uint RxA;

		private static XCore.Generator.RandomGenerator Ixl;

		private static readonly uint[] jxI;

		private static readonly uint[] FxT;

		private static readonly uint[] ixi;

		private static readonly uint[] sxZ;

		private static newInjector YxF;

		private static MethodDef zxD;

		public override string name => "Code Encryption";

		public override int number => 18;

		public override void Execute(XContext xcontext_0)
		{
			Ixl = new XCore.Generator.RandomGenerator(GGeneration.GenerateGuidStartingWithLetter(), GGeneration.GenerateGuidStartingWithLetter());
			sxZ[0] = Ixl.NextUInt32();
			ixi[0] = Ixl.NextUInt32();
			jxI[0] = Ixl.NextUInt32();
			FxT[0] = Ixl.NextUInt32();
			zxq = Ixl.NextUInt32() & 0x7F7F7F7F;
			RxA = Ixl.NextUInt32() & 0x7F7F7F7F;
			nxr = new NormalDeriver();
			nxr.Init();
			Ux6 = (from methodDef_0 in xcontext_0.Module.GetTypes().SelectMany((TypeDef typeDef_0) => typeDef_0.Methods).ToList()
				where methodDef_0.HasBody && methodDef_0.DeclaringType != methodDef_0.Module.GlobalType
				select methodDef_0).ToList();
			YxF = new newInjector(xcontext_0.Module, typeof(CodeEncryptionRuntime));
			zxD = YxF.FindMember("Initialize") as MethodDef;
			zxD.Body.SimplifyMacros(zxD.Parameters);
			List<Instruction> list = zxD.Body.Instructions.ToList();
			for (int num = 0; num < list.Count; num++)
			{
				Instruction instruction = list[num];
				if (instruction.OpCode == OpCodes.Ldtoken)
				{
					instruction.Operand = xcontext_0.Module.GlobalType;
				}
				else if (instruction.OpCode == OpCodes.Call)
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
						list.InsertRange(num - 2, nxr.EmitDerivation(zxD, (Local)instruction2.Operand, (Local)instruction3.Operand));
					}
				}
			}
			zxD.Body.Instructions.Clear();
			foreach (Instruction item in list)
			{
				zxD.Body.Instructions.Add(item);
			}
			XMutationHelper xMutationHelper = new XMutationHelper("XMutationClass");
			xMutationHelper.InjectKeys(zxD, new int[5] { 1, 2, 3, 4, 5 }, new int[5]
			{
				(int)(zxq * RxA),
				(int)sxZ[0],
				(int)ixi[0],
				(int)jxI[0],
				(int)FxT[0]
			});
			MethodDef methodDef = xcontext_0.Module.GlobalType.FindOrCreateStaticConstructor();
			methodDef.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(zxD));
			YxF.Rename();
		}

		public void CreateSections(ModuleWriterBase moduleWriterBase_0)
		{
			byte[] bytes = new byte[8]
			{
				(byte)zxq,
				(byte)(zxq >> 8),
				(byte)(zxq >> 16),
				(byte)(zxq >> 24),
				(byte)RxA,
				(byte)(RxA >> 8),
				(byte)(RxA >> 16),
				(byte)(RxA >> 24)
			};
			PESection pESection = new PESection(Encoding.ASCII.GetString(bytes), 3758096448u);
			moduleWriterBase_0.Sections.Insert(0, pESection);
			uint value = moduleWriterBase_0.TextSection.Remove(moduleWriterBase_0.Metadata).Value;
			moduleWriterBase_0.TextSection.Add(moduleWriterBase_0.Metadata, value);
			value = moduleWriterBase_0.TextSection.Remove(moduleWriterBase_0.NetResources).Value;
			moduleWriterBase_0.TextSection.Add(moduleWriterBase_0.NetResources, value);
			value = moduleWriterBase_0.TextSection.Remove(moduleWriterBase_0.Constants).Value;
			pESection.Add(moduleWriterBase_0.Constants, value);
			PESection pESection2 = new PESection("UPX", 1610612768u);
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
			else
			{
				moduleWriterBase_0.Sections.AddBeforeReloc(pESection2);
			}
			MethodBodyChunks methodBodyChunks = new MethodBodyChunks(moduleWriterBase_0.TheOptions.ShareMethodBodies);
			pESection.Add(methodBodyChunks, 4u);
			foreach (MethodDef item in Ux6)
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
			if (moduleWriterBase_0 is NativeModuleWriter && moduleWriterBase_0.Module is ModuleDefMD moduleDefMD)
			{
				num5 = moduleDefMD.Metadata.PEImage.ImageSectionHeaders.Count;
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
				if (num6 == zxq * RxA)
				{
					num4 = binaryReader.ReadUInt32();
					num3 = binaryReader.ReadUInt32();
				}
				else if (num6 == 0)
				{
					destinationStream.Position += 8L;
				}
				else
				{
					uint uint_ = binaryReader.ReadUInt32();
					uint uint_2 = binaryReader.ReadUInt32();
					Mx0(destinationStream, binaryReader, uint_2, uint_);
				}
				destinationStream.Position += 16L;
			}
			uint[] array = txQ();
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

		private static void Mx0(Stream stream_0, BinaryReader binaryReader_0, uint uint_0, uint uint_1)
		{
			long position = stream_0.Position;
			stream_0.Position = uint_0;
			uint_1 >>= 2;
			for (uint num = 0u; num < uint_1; num++)
			{
				uint num2 = binaryReader_0.ReadUInt32();
				uint num3 = (sxZ[0] ^ num2) + ixi[0] + jxI[0] * FxT[0];
				sxZ[0] = ixi[0];
				ixi[0] = jxI[0];
				ixi[0] = FxT[0];
				FxT[0] = num3;
			}
			stream_0.Position = position;
		}

		private static uint[] txQ()
		{
			uint[] array = new uint[16];
			uint[] array2 = new uint[16];
			for (int i = 0; i < 16; i++)
			{
				array[i] = FxT[0];
				array2[i] = ixi[0];
				sxZ[0] = (ixi[0] >> 5) | (ixi[0] << 27);
				ixi[0] = (jxI[0] >> 3) | (jxI[0] << 29);
				jxI[0] = (FxT[0] >> 7) | (FxT[0] << 25);
				FxT[0] = (sxZ[0] >> 11) | (sxZ[0] << 21);
			}
			return nxr.DeriveKey(array, array2);
		}

		static CodeEncryption()
		{
			jxI = new uint[1];
			FxT = new uint[1];
			ixi = new uint[1];
			sxZ = new uint[1];
			YxF = null;
			zxD = null;
		}
	}
}
