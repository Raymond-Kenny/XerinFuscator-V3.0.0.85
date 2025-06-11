using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;
using XCore.Context;
using XCore.Injection;
using XCore.Protections;
using XCore.Terminator;
using XProtections.Mutation;
using XRuntime;

namespace XProtections
{
	public class IntegrityCheck : Protection
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class RRt
		{
			public static readonly RRt oRW;

			public static Func<Instruction, bool> URH;

			static RRt()
			{
				oRW = new RRt();
			}

			internal bool ARf(Instruction instruction_0)
			{
				return instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill");
			}
		}

		private static newInjector X8K;

		private static MethodDef u8G;

		private static MethodDef E8j;

		public override string name => "Integrity Check";

		public override int number => 14;

		private static string z8n(byte[] byte_0)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] array = mD5CryptoServiceProvider.ComputeHash(byte_0);
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array2 = array;
			foreach (byte b in array2)
			{
				stringBuilder.Append(b.ToString("x2").ToLower());
			}
			return stringBuilder.ToString();
		}

		public static void HashFile(object sender, ModuleWriterEventArgs e)
		{
			if (e.Event == ModuleWriterEvent.End)
			{
				StreamReader streamReader = new StreamReader(e.Writer.DestinationStream);
				BinaryReader binaryReader = new BinaryReader(streamReader.BaseStream);
				binaryReader.BaseStream.Position = 0L;
				byte[] byte_ = binaryReader.ReadBytes((int)streamReader.BaseStream.Length);
				string s = z8n(byte_);
				byte[] bytes = Encoding.ASCII.GetBytes(s);
				e.Writer.DestinationStream.Position = e.Writer.DestinationStream.Length;
				e.Writer.DestinationStream.Write(bytes, 0, bytes.Length);
			}
		}

		public override void Execute(XContext xcontext_0)
		{
			XContext.ModOpts.WriterEvent += HashFile;
			X8K = new newInjector(xcontext_0.Module, typeof(IntegrityCheckRuntime));
			u8G = X8K.FindMember("Initialize") as MethodDef;
			E8j = X8K.FindMember("MD5") as MethodDef;
			MethodDef methodDef = xcontext_0.Module.GlobalType.FindOrCreateStaticConstructor();
			methodDef.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(u8G));
			foreach (Instruction item in u8G.Body.Instructions.Where((Instruction instruction_0) => instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill")))
			{
				item.Operand = Terminate.Kill;
			}
			X8K.Rename();
			MethodDef[] methodDef_ = new MethodDef[2] { u8G, E8j };
			stillWorkingOn2.EncodeFor(xcontext_0, methodDef_);
			new ThirdMutationStage().ExecuteFor(xcontext_0, u8G);
			new ThirdMutationStage().ExecuteFor(xcontext_0, E8j);
		}
	}
}
