using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Context;
using XCore.Injection;
using XCore.Mutation;
using XCore.Protections;
using XCore.Terminator;
using XCore.Utils;
using XProtections.AntiCrack.Globals;
using XProtections.Mutation;
using XRuntime;

namespace XProtections
{
	public class GClass0 : Protection
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class swH
		{
			public static readonly swH Gw3;

			public static Func<Instruction, bool> ewM;

			static swH()
			{
				Gw3 = new swH();
			}

			internal bool Xwd(Instruction instruction_0)
			{
				return instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill");
			}
		}

		private static newInjector c2E;

		private static MethodDef Y2t;

		private static MethodDef y2f;

		private static MethodDef O2W;

		private static MethodDef J2H;

		private static MethodDef X2d;

		private static MethodDef P23;

		private static MethodDef a2M;

		private static MethodDef g2e;

		private static MethodDef k2C;

		public override string name => "Anti Crack";

		public override int number => 8;

		public override void Execute(XContext xcontext_0)
		{
			c2E = new newInjector(xcontext_0.Module, typeof(AntiCrackingWithHook));
			Y2t = c2E.FindMember("Init") as MethodDef;
			y2f = c2E.FindMember("DoWork") as MethodDef;
			O2W = c2E.FindMember("SendMSG") as MethodDef;
			J2H = c2E.FindMember("Capture") as MethodDef;
			X2d = c2E.FindMember("CrossAppDomainSerializer") as MethodDef;
			P23 = c2E.FindMember("GetMotherBoardSerialNo") as MethodDef;
			a2M = c2E.FindMember("SendIMSG") as MethodDef;
			g2e = c2E.FindMember("CalculateMD5Hash") as MethodDef;
			k2C = c2E.FindMember("eBSOD") as MethodDef;
			XMutationHelper xMutationHelper = new XMutationHelper("XMutationClass");
			MethodDef methodDef = xcontext_0.Module.GlobalType.FindOrCreateStaticConstructor();
			methodDef.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(Y2t));
			foreach (Instruction item in y2f.Body.Instructions.Where((Instruction instruction_0) => instruction_0.OpCode == OpCodes.Call && instruction_0.Operand.ToString().Contains("Kill")))
			{
				item.Operand = Terminate.Kill;
			}
			xMutationHelper.InjectKey(y2f, 1, Utils.MethodsRenamig());
			if (!Global.Normal)
			{
				xMutationHelper.InjectKey(y2f, 2, "0");
			}
			else
			{
				xMutationHelper.InjectKey(y2f, 2, "1");
			}
			if (Global.Exclude)
			{
				xMutationHelper.InjectKey(y2f, 3, Global.excludeString);
			}
			else
			{
				xMutationHelper.InjectKey(y2f, 3, "Hi'I'm_Empty_String;')");
			}
			xMutationHelper.InjectKey(y2f, 4, Global.webhookLink);
			if (Global.Silent)
			{
				xMutationHelper.InjectKey(y2f, 5, "1");
			}
			else
			{
				xMutationHelper.InjectKey(y2f, 5, "0");
			}
			if (Global.Bsod)
			{
				xMutationHelper.InjectKey(y2f, 0, "1");
			}
			else
			{
				xMutationHelper.InjectKey(y2f, 0, "0");
			}
			if (!string.IsNullOrEmpty(Global.customMessage))
			{
				xMutationHelper.InjectKey(y2f, 7, Global.customMessage);
			}
			else
			{
				xMutationHelper.InjectKey(y2f, 7, "Detected cracking process or Cheat engine is detected!");
			}
			string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string path = Path.Combine(directoryName, "Config", "Processes list.ini");
			string[] uUp = File.ReadAllLines(path);
			xMutationHelper.InjectKey(y2f, 8, uUp);
			c2E.Rename();
			MethodDef[] array = new MethodDef[2] { y2f, a2M };
			stillWorkingOn2.EncodeFor(xcontext_0, array);
			MethodDef[] array2 = array;
			foreach (MethodDef methodDef_ in array2)
			{
				new ThirdMutationStage().ExecuteFor(xcontext_0, methodDef_);
			}
		}
	}
}
