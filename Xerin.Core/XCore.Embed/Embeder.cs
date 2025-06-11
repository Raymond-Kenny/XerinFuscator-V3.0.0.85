using System.Collections.Generic;
using System.IO;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Compression;
using XCore.Context;
using XCore.Injection;
using XCore.Protections;
using XRuntime;

namespace XCore.Embed
{
	public class Embeder : Protection
	{
		public static bool isEmbed;

		public static bool isEmptyList;

		public static List<string> dlls;

		private newInjector FQ1 = null;

		public override string name => "Embed dlls";

		public override int number => 15;

		public override void Execute(XContext xcontext_0)
		{
			if (isEmptyList)
			{
				return;
			}
			FQ1 = new newInjector(xcontext_0.Module, typeof(embedRuntime));
			MethodDef method = FQ1.FindMember("AppStart") as MethodDef;
			MethodDef methodDef = xcontext_0.Module.GlobalType.FindOrCreateStaticConstructor();
			methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, method));
			foreach (string dll in dlls)
			{
				byte[] byte_ = File.ReadAllBytes(dll);
				xcontext_0.Module.Resources.Add(new EmbeddedResource(Path.GetFileNameWithoutExtension(dll), QuickLZ.CompressBytes2(byte_)));
			}
			FQ1.Rename();
		}

		static Embeder()
		{
			isEmbed = false;
			isEmptyList = false;
			dlls = new List<string>();
		}
	}
}
