using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.MD;
using dnlib.DotNet.Writer;
using XCore.Compression;
using XCore.Context;
using XCore.Decompression;
using XCore.Injection;
using XCore.Mutation;
using XCore.Protections;
using XCore.Utils;
using XRuntime;

namespace XProtections
{
	public class ResourcesEncoder : Protection
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class aRh
		{
			public static readonly aRh dRP;

			public static Func<IDnlibDef, bool> pRU;

			public static Func<Instruction, bool> RRk;

			static aRh()
			{
				dRP = new aRh();
			}

			internal bool fR5(IDnlibDef idnlibDef_0)
			{
				return idnlibDef_0.Name == "Initialize";
			}

			internal bool bRN(Instruction instruction_0)
			{
				return instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("decompress");
			}
		}

		public override string name => "Resources Encoding";

		public override int number => 16;

		public override void Execute(XContext xcontext_0)
		{
			string text = Utils.MethodsRenamig();
			int num = Utils.RandomTinyInt32();
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(ResRuntime).Module);
			TypeDef typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(ResRuntime).MetadataToken));
			IEnumerable<IDnlibDef> enumerable = InjectHelper.Inject(typeDef, xcontext_0.Module.GlobalType, xcontext_0.Module);
			MethodDef methodDef = (MethodDef)enumerable.Single((IDnlibDef idnlibDef_0) => idnlibDef_0.Name == "Initialize");
			MethodDef methodDef2 = xcontext_0.Module.GlobalType.FindOrCreateStaticConstructor();
			XMutationHelper xMutationHelper = new XMutationHelper("XMutationClass");
			xMutationHelper.InjectKey(methodDef, 6, text);
			xMutationHelper.InjectKey(methodDef, 5, num);
			foreach (Instruction item in methodDef.Body.Instructions.Where((Instruction instruction_0) => instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("decompress")))
			{
				item.Operand = XCore.Decompression.QuickLZ.QLZDecompression;
			}
			methodDef2.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(methodDef));
			foreach (IDnlibDef item2 in enumerable)
			{
				if (!(item2 is MethodDef methodDef3) || (!methodDef3.HasImplMap && !methodDef3.DeclaringType.IsDelegate))
				{
					Utils.MethodsRenamig(item2);
				}
			}
			string text2 = Utils.MethodsRenamig();
			AssemblyDefUser assemblyDefUser = new AssemblyDefUser(text2, new Version(0, 0));
			assemblyDefUser.Modules.Add(new ModuleDefUser(text2));
			ModuleDef manifestModule = assemblyDefUser.ManifestModule;
			assemblyDefUser.ManifestModule.Kind = ModuleKind.Dll;
			AssemblyRefUser asmRef = new AssemblyRefUser(manifestModule.Assembly);
			for (int num2 = 0; num2 < xcontext_0.Module.Resources.Count; num2++)
			{
				if (xcontext_0.Module.Resources[num2] is EmbeddedResource)
				{
					xcontext_0.Module.Resources[num2].Attributes = ManifestResourceAttributes.Private;
					manifestModule.Resources.Add(xcontext_0.Module.Resources[num2] as EmbeddedResource);
					xcontext_0.Module.Resources.Add(new AssemblyLinkedResource(xcontext_0.Module.Resources[num2].Name, asmRef, xcontext_0.Module.Resources[num2].Attributes));
					xcontext_0.Module.Resources.RemoveAt(num2);
					num2--;
				}
			}
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				ModuleWriterOptions moduleWriterOptions = new ModuleWriterOptions(manifestModule);
				moduleWriterOptions.MetadataOptions.Flags = MetadataFlags.PreserveAll;
				moduleWriterOptions.Cor20HeaderOptions.Flags = ComImageFlags.ILOnly;
				moduleWriterOptions.ModuleKind = ModuleKind.Dll;
				manifestModule.Write(memoryStream, moduleWriterOptions);
				byte[] byte_ = XCore.Compression.QuickLZ.CompressBytes(memoryStream.ToArray());
				data = z8r(byte_, num);
			}
			xcontext_0.Module.Resources.Add(new EmbeddedResource(text, data));
			new HashSet<MethodDef>().Add(methodDef);
			SpamResources.Execute(xcontext_0);
		}

		private static byte[] z8r(byte[] byte_0, int int_0)
		{
			Rijndael rijndael = Rijndael.Create();
			rijndael.Key = SHA256.Create().ComputeHash(BitConverter.GetBytes(int_0));
			rijndael.IV = new byte[16];
			rijndael.Mode = CipherMode.CBC;
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(byte_0, 0, byte_0.Length);
			cryptoStream.FlushFinalBlock();
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return result;
		}
	}
}
