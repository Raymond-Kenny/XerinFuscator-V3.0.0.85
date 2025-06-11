using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;
using XCore.Generator;
using XVM.CodeEncryption;
using XVM.Core;
using XVM.Core.JIT;

namespace XVM.Internal
{
	public class InitializePhase
	{
		[CompilerGenerated]
		private sealed class aL1
		{
			public InitializePhase rLO;

			public JITContext ILt;

			internal void gLj(object sender, ModuleWriterEventArgs e)
			{
				ModuleWriterBase moduleWriterBase = (ModuleWriterBase)sender;
				if (e.Event != ModuleWriterEvent.MDBeginWriteMethodBodies)
				{
					return;
				}
				rLO.VR.ProcessMethods(moduleWriterBase);
				foreach (KeyValuePair<IMemberRef, IMemberRef> item in rLO.jec)
				{
					rLO.VR.Runtime.Descriptor.Data.ReplaceReference(item.Key, item.Value);
				}
				rLO.VR.CommitModule(moduleWriterBase.Metadata);
				foreach (MethodDef target in ILt.Targets)
				{
					JITContext.RealBodies.Add(target.Body);
					target.Body = JITWriter.NopBody(moduleWriterBase.Module);
				}
			}
		}

		private Dictionary<IMemberRef, IMemberRef> jec;

		[CompilerGenerated]
		private ModuleDefMD oeL;

		[CompilerGenerated]
		private HashSet<MethodDef> mek;

		[CompilerGenerated]
		private Virtualizer neH;

		[CompilerGenerated]
		private string KeC;

		[CompilerGenerated]
		private string eem;

		[CompilerGenerated]
		private string le5;

		[CompilerGenerated]
		private string seo;

		public static HashSet<MethodDef> temp;

		public ModuleDefMD DFModule
		{
			[CompilerGenerated]
			get
			{
				return oeL;
			}
			[CompilerGenerated]
			private set
			{
				oeL = value;
			}
		}

		public HashSet<MethodDef> Methods
		{
			[CompilerGenerated]
			get
			{
				return mek;
			}
			[CompilerGenerated]
			set
			{
				mek = value;
			}
		}

		public Virtualizer VR
		{
			[CompilerGenerated]
			get
			{
				return neH;
			}
			[CompilerGenerated]
			private set
			{
				neH = value;
			}
		}

		public string RT_OUT_Directory
		{
			[CompilerGenerated]
			get
			{
				return KeC;
			}
			[CompilerGenerated]
			set
			{
				KeC = value;
			}
		}

		public string RTName
		{
			[CompilerGenerated]
			get
			{
				return eem;
			}
			[CompilerGenerated]
			set
			{
				eem = value;
			}
		}

		public string SNK_File
		{
			[CompilerGenerated]
			get
			{
				return le5;
			}
			[CompilerGenerated]
			set
			{
				le5 = value;
			}
		}

		public string SNK_Password
		{
			[CompilerGenerated]
			get
			{
				return seo;
			}
			[CompilerGenerated]
			set
			{
				seo = value;
			}
		}

		public InitializePhase(ModuleDefMD moduleDefMD_0)
		{
			DFModule = moduleDefMD_0;
			Methods = new HashSet<MethodDef>();
			jec = new Dictionary<IMemberRef, IMemberRef>();
		}

		public void Initialize()
		{
			Methods = new HashSet<MethodDef>(Methods.Distinct().ToList());
			HashSet<MethodDef> hashSet = (Methods = new HashSet<MethodDef>(Methods.Distinct().ToList()));
			temp = hashSet;
			VR = new Virtualizer(DFModule, RTName);
			TypeDef globalType = DFModule.GlobalType;
			TypeDefUser typeDefUser = new TypeDefUser(globalType.Name);
			globalType.Name = GGeneration.GenerateGuidStartingWithLetter();
			globalType.BaseType = DFModule.CorLibTypes.GetTypeRef("System", "Object");
			DFModule.Types.Insert(0, typeDefUser);
			MethodDef methodDef = globalType.FindOrCreateStaticConstructor();
			MethodDef methodDef2 = typeDefUser.FindOrCreateStaticConstructor();
			methodDef.Name = GGeneration.GenerateGuidStartingWithLetter();
			methodDef.IsRuntimeSpecialName = false;
			methodDef.IsSpecialName = false;
			methodDef.Access = MethodAttributes.Assembly;
			methodDef2.Body = new CilBody(initLocals: true, new List<Instruction>
			{
				Instruction.Create(OpCodes.Jmp, methodDef),
				Instruction.Create(OpCodes.Ret)
			}, new List<ExceptionHandler>(), new List<Local>());
			VR.Runtime.i2L().yKA(DFModule);
			for (int i = 0; i < globalType.Methods.Count; i++)
			{
				MethodDef methodDef3 = globalType.Methods[i];
				if (methodDef3.IsNative)
				{
					MethodDefUser methodDefUser = new MethodDefUser(methodDef3.Name, methodDef3.MethodSig.Clone());
					methodDefUser.Attributes = MethodAttributes.Assembly | MethodAttributes.Static;
					methodDefUser.Body = new CilBody();
					methodDefUser.Body.Instructions.Add(new Instruction(OpCodes.Jmp, methodDef3));
					methodDefUser.Body.Instructions.Add(new Instruction(OpCodes.Ret));
					typeDefUser.Methods[i] = methodDefUser;
					typeDefUser.Methods.Add(methodDef3);
					jec[methodDef3] = methodDef3;
				}
			}
			Methods.Remove(methodDef2);
			Methods.Add(methodDef);
			foreach (MethodDef method in Methods)
			{
				VR.AddMethod(method);
			}
			Utils.ExecuteModuleWriterOptions = new ModuleWriterOptions(DFModule)
			{
				Logger = DummyLogger.NoThrowInstance,
				PdbOptions = PdbWriterOptions.None,
				WritePdb = false
			};
			if (!string.IsNullOrEmpty(SNK_File) && File.Exists(SNK_File))
			{
				StrongNameKey signatureKey = Utils.smethod_0(SNK_File, SNK_Password);
				Utils.ExecuteModuleWriterOptions.InitializeStrongNameSigning(DFModule, signatureKey);
			}
			VR.ResolveMethods();
			VR.JIT(DFModule, Utils.ExecuteModuleWriterOptions, out var ILt);
			Utils.ExecuteModuleWriterOptions.WriterEvent += delegate(object sender, ModuleWriterEventArgs e)
			{
				ModuleWriterBase moduleWriterBase = (ModuleWriterBase)sender;
				if (e.Event == ModuleWriterEvent.MDBeginWriteMethodBodies)
				{
					VR.ProcessMethods(moduleWriterBase);
					foreach (KeyValuePair<IMemberRef, IMemberRef> item in jec)
					{
						VR.Runtime.Descriptor.Data.ReplaceReference(item.Key, item.Value);
					}
					VR.CommitModule(moduleWriterBase.Metadata);
					foreach (MethodDef target in ILt.Targets)
					{
						JITContext.RealBodies.Add(target.Body);
						target.Body = JITWriter.NopBody(moduleWriterBase.Module);
					}
				}
			};
		}

		private static void Tej(object sender, ModuleWriterEventArgs e)
		{
			switch (e.Event)
			{
			case ModuleWriterEvent.BeginStrongNameSign:
				new XVM.CodeEncryption.CodeEncryption().EncryptSection(e.Writer);
				break;
			case ModuleWriterEvent.MDEndCreateTables:
				new XVM.CodeEncryption.CodeEncryption().CreateSections(e.Writer);
				break;
			}
		}

		public void GetProtectedFile(out byte[] byte_0)
		{
			MemoryStream memoryStream = new MemoryStream();
			Utils.ExecuteModuleWriterOptions.WriterEvent += Tej;
			DFModule.Write(memoryStream, Utils.ExecuteModuleWriterOptions);
			byte_0 = memoryStream.ToArray();
		}

		public void SaveRuntime()
		{
			MemoryStream memoryStream = new MemoryStream();
			VR.Runtime.RTModule.Write(memoryStream, VR.Runtime.RTModuleWriterOptions);
			if (Path.GetExtension(RTName) != ".dll")
			{
				RTName += ".dll";
			}
			string path = Path.Combine(RT_OUT_Directory, RTName);
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			File.WriteAllBytes(path, memoryStream.ToArray());
		}

		public void Dispose()
		{
			VR.Clear();
			Methods.Clear();
			DFModule = null;
		}

		static InitializePhase()
		{
			temp = new HashSet<MethodDef>();
		}
	}
}
