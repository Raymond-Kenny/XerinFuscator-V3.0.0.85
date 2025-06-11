using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Confuser.Core;
using dnlib.DotNet;
using dnlib.DotNet.MD;
using dnlib.DotNet.Writer;
using dnlib.PE;
using XCore.Generator;
using XCore.Optimizer;
using XCore.Resolver;
using XCore.Simplifier;
using XF;
using XProtections;
using XProtections.CodeEncryption;

namespace XCore.Context
{
	public class XContext : IDisposable
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class HJY
		{
			public static readonly HJY EJF;

			static HJY()
			{
				EJF = new HJY();
			}

			internal char iJQ(int int_0)
			{
				return (char)int_0;
			}
		}

		private readonly RandomGenerator Lf;

		public static readonly ServiceRegistry registry;

		private bool LT = false;

		[CompilerGenerated]
		private string ei;

		[CompilerGenerated]
		private readonly Annotations oS = new Annotations();

		public static ModuleWriterOptions ModOpts;

		[CompilerGenerated]
		private string vl;

		[CompilerGenerated]
		private string lO;

		[CompilerGenerated]
		private string U2;

		[CompilerGenerated]
		private static string Ms;

		[CompilerGenerated]
		private ModuleDefMD oE;

		[CompilerGenerated]
		private static bool ig;

		[CompilerGenerated]
		private static bool Qp;

		[CompilerGenerated]
		private static bool HB;

		[CompilerGenerated]
		private static bool bz;

		[CompilerGenerated]
		private static bool GUN;

		[CompilerGenerated]
		private static bool QUU;

		[CompilerGenerated]
		private static bool nUY;

		private static readonly char[] fUQ;

		[CompilerGenerated]
		private static bool iUF;

		[CompilerGenerated]
		private static bool KUC;

		public string tmp
		{
			[CompilerGenerated]
			get
			{
				return ei;
			}
			[CompilerGenerated]
			set
			{
				ei = value;
			}
		}

		public Annotations Annotations
		{
			[CompilerGenerated]
			get
			{
				return oS;
			}
		}

		public ServiceRegistry Registry => registry;

		public string Path
		{
			[CompilerGenerated]
			get
			{
				return vl;
			}
			[CompilerGenerated]
			set
			{
				vl = value;
			}
		}

		public string OutPutPath
		{
			[CompilerGenerated]
			get
			{
				return lO;
			}
			[CompilerGenerated]
			set
			{
				lO = value;
			}
		}

		public string DirPath
		{
			[CompilerGenerated]
			get
			{
				return U2;
			}
			[CompilerGenerated]
			set
			{
				U2 = value;
			}
		}

		public static string dirpath
		{
			[CompilerGenerated]
			get
			{
				return Ms;
			}
			[CompilerGenerated]
			set
			{
				Ms = value;
			}
		}

		public ModuleDefMD Module
		{
			[CompilerGenerated]
			get
			{
				return oE;
			}
			[CompilerGenerated]
			set
			{
				oE = value;
			}
		}

		public static bool Fake
		{
			[CompilerGenerated]
			get
			{
				return ig;
			}
			[CompilerGenerated]
			set
			{
				ig = value;
			}
		}

		public static bool AMSI
		{
			[CompilerGenerated]
			get
			{
				return Qp;
			}
			[CompilerGenerated]
			set
			{
				Qp = value;
			}
		}

		public static bool Pack
		{
			[CompilerGenerated]
			get
			{
				return HB;
			}
			[CompilerGenerated]
			set
			{
				HB = value;
			}
		}

		public static bool CE
		{
			[CompilerGenerated]
			get
			{
				return bz;
			}
			[CompilerGenerated]
			set
			{
				bz = value;
			}
		}

		public static bool ChanegAttr
		{
			[CompilerGenerated]
			get
			{
				return GUN;
			}
			[CompilerGenerated]
			set
			{
				GUN = value;
			}
		}

		public static bool AD
		{
			[CompilerGenerated]
			get
			{
				return QUU;
			}
			[CompilerGenerated]
			set
			{
				QUU = value;
			}
		}

		public static bool sameLocation
		{
			[CompilerGenerated]
			get
			{
				return nUY;
			}
			[CompilerGenerated]
			set
			{
				nUY = value;
			}
		}

		public static bool Simpilify
		{
			[CompilerGenerated]
			get
			{
				return iUF;
			}
			[CompilerGenerated]
			set
			{
				iUF = value;
			}
		}

		public static bool Optimize
		{
			[CompilerGenerated]
			get
			{
				return KUC;
			}
			[CompilerGenerated]
			set
			{
				KUC = value;
			}
		}

		public XContext(string string_0)
		{
			Lf = new RandomGenerator(GGeneration.GenerateGuidStartingWithLetter(), GGeneration.GenerateGuidStartingWithLetter());
			Path = string_0;
			ModuleContext context = ModuleDef.CreateModuleContext();
			Module = ModuleDefMD.Load(string_0, context);
			AssemblyResolve.LoadAssemblies(Module);
			ModOpts = new ModuleWriterOptions(Module)
			{
				MetadataLogger = DummyLogger.NoThrowInstance,
				ShareMethodBodies = false,
				AddCheckSum = false,
				AddMvidSection = false,
				WritePdb = false
			};
		}

		private void lW(object sender, ModuleWriterEventArgs e)
		{
			switch (e.Event)
			{
			case ModuleWriterEvent.BeginStrongNameSign:
				new CodeEncryption().EncryptSection(e.Writer);
				break;
			case ModuleWriterEvent.MDEndCreateTables:
				new CodeEncryption().CreateSections(e.Writer);
				break;
			}
		}

		private void SG<u8>(MDTable<u8> mdtable_0) where u8 : struct
		{
			Lf.Shuffle(mdtable_0);
		}

		private static void qZ(ModuleWriterBase moduleWriterBase_0)
		{
			Stream destinationStream = moduleWriterBase_0.DestinationStream;
			BinaryReader binaryReader = new BinaryReader(destinationStream);
			destinationStream.Position = 60L;
			int num = binaryReader.ReadInt32();
			destinationStream.Position = num + 24;
			ushort num2 = binaryReader.ReadUInt16();
			bool flag;
			ushort num3 = (ushort)((flag = num2 == 523) ? 96u : 32u);
			destinationStream.Position += num3;
			ushort num4 = binaryReader.ReadUInt16();
			int num5 = num + 248 + (flag ? 32 : 0);
			destinationStream.Position = num5;
			using (BinaryWriter binaryWriter = new BinaryWriter(destinationStream))
			{
				for (int i = 0; i < num4; i++)
				{
					long position = destinationStream.Position;
					byte[] array = binaryReader.ReadBytes(40);
					Array.Copy(BitConverter.GetBytes(0), 0, array, 12, 4);
					binaryWriter.Write(array);
					destinationStream.Position = position + 40L;
				}
			}
		}

		private void la(object sender, ModuleWriterEventArgs e)
		{
			ModuleWriterBase moduleWriterBase = (ModuleWriterBase)sender;
			switch (e.Event)
			{
			case ModuleWriterEvent.End:
				qZ(e.Writer);
				break;
			case ModuleWriterEvent.MDEndCreateTables:
				A9(e.Writer);
				Sm(e.Writer);
				break;
			case ModuleWriterEvent.MDOnAllTablesSorted:
				moduleWriterBase.Metadata.TablesHeap.DeclSecurityTable.Add(new RawDeclSecurityRow(short.MaxValue, 4294934527u, 4294934527u));
				moduleWriterBase.Metadata.TablesHeap.DeclSecurityTable.Add(new RawDeclSecurityRow(short.MaxValue, 4294934527u, 4294934527u));
				break;
			case ModuleWriterEvent.PESectionsCreated:
				kX(e.Writer);
				break;
			}
		}

		private void kX(ModuleWriterBase moduleWriterBase_0)
		{
			PESection pESection = new PESection(".Enigma", 3758096448u);
			foreach (PESection section in moduleWriterBase_0.Sections)
			{
				if (!section.Name.Contains("reloc"))
				{
					section.Name = "";
				}
			}
			foreach (TypeDef type in moduleWriterBase_0.Module.Types)
			{
				foreach (MethodDef method in type.Methods)
				{
					if (method.HasBody)
					{
						method.RVA = (RVA)0u;
					}
				}
			}
			moduleWriterBase_0.AddSection(pESection);
			pESection.Add(new ByteArrayChunk(new byte[10]), 4u);
		}

		private void Sm(ModuleWriterBase moduleWriterBase_0)
		{
			PESection pESection = new PESection(".UPX", 1073741888u);
			moduleWriterBase_0.AddSection(pESection);
			pESection.Add(new ByteArrayChunk(new byte[123]), 4u);
			pESection.Add(new ByteArrayChunk(new byte[10]), 4u);
			moduleWriterBase_0.Metadata.TablesHeap.ModuleTable.Add(new RawModuleRow(0, 2147450879u, 0u, 0u, 0u));
			moduleWriterBase_0.Metadata.TablesHeap.AssemblyTable.Add(new RawAssemblyRow(0u, 0, 0, 0, 0, 0u, 0u, 2147450879u, 0u));
			moduleWriterBase_0.TheOptions.MetadataOptions.TablesHeapOptions.ExtraData = Lf.NextUInt32();
			moduleWriterBase_0.TheOptions.MetadataOptions.TablesHeapOptions.UseENC = false;
			moduleWriterBase_0.TheOptions.MetadataOptions.MetadataHeaderOptions.VersionString += "\0\0\0\0";
			vA(moduleWriterBase_0);
			int num = Lf.NextInt32(8, 16);
			for (int i = 0; i < num; i++)
			{
				moduleWriterBase_0.Metadata.TablesHeap.ENCLogTable.Add(new RawENCLogRow(Lf.NextUInt32(), Lf.NextUInt32()));
			}
			num = Lf.NextInt32(8, 16);
			for (int j = 0; j < num; j++)
			{
				moduleWriterBase_0.Metadata.TablesHeap.ENCMapTable.Add(new RawENCMapRow(Lf.NextUInt32()));
			}
			SG(moduleWriterBase_0.Metadata.TablesHeap.ManifestResourceTable);
			moduleWriterBase_0.TheOptions.MetadataOptions.TablesHeapOptions.ExtraData = Lf.NextUInt32();
			moduleWriterBase_0.TheOptions.MetadataOptions.MetadataHeaderOptions.VersionString += "\0\0\0\0";
			byte[] bytes = Encoding.ASCII.GetBytes("DNG");
			moduleWriterBase_0.TheOptions.MetadataOptions.CustomHeaps.Add(new VUy("#Agile", bytes));
			pESection.Add(new ByteArrayChunk(bytes), 4u);
			moduleWriterBase_0.Metadata.TablesHeap.TypeSpecTable.Add(new RawTypeSpecRow((uint)(moduleWriterBase_0.Metadata.TablesHeap.TypeSpecTable.Rows + 1)));
			moduleWriterBase_0.TheOptions.MetadataOptions.CustomHeaps.Add(new VUy("#GUID", Guid.NewGuid().ToByteArray()));
			moduleWriterBase_0.TheOptions.MetadataOptions.CustomHeaps.Add(new VUy("#Strings", new byte[1]));
			moduleWriterBase_0.TheOptions.MetadataOptions.CustomHeaps.Add(new VUy("#Blob", new byte[1]));
			moduleWriterBase_0.TheOptions.MetadataOptions.CustomHeaps.Add(new VUy("#Schema", new byte[1]));
			moduleWriterBase_0.TheOptions.MetadataOptions.CustomHeaps.Add(new VUy("#GUID", Guid.NewGuid().ToByteArray()));
			moduleWriterBase_0.TheOptions.MetadataOptions.CustomHeaps.Add(new VUy("#<Module>", new byte[1]));
		}

		public static string EncodeString(byte[] byte_0, char[] char_0)
		{
			int num = byte_0[0];
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i < byte_0.Length; i++)
			{
				for (num = (num << 8) + byte_0[i]; num >= char_0.Length; num /= char_0.Length)
				{
					stringBuilder.Append(char_0[num % char_0.Length]);
				}
			}
			if (num != 0)
			{
				stringBuilder.Append(char_0[num % char_0.Length]);
			}
			return stringBuilder.ToString();
		}

		private void vA(ModuleWriterBase moduleWriterBase_0)
		{
			int num = Lf.NextInt32(8, 16);
			for (int i = 0; i < num; i++)
			{
				moduleWriterBase_0.Metadata.TablesHeap.ENCLogTable.Add(new RawENCLogRow(Lf.NextUInt32(), Lf.NextUInt32()));
			}
			num = Lf.NextInt32(8, 16);
			for (int j = 0; j < num; j++)
			{
				moduleWriterBase_0.Metadata.TablesHeap.ENCMapTable.Add(new RawENCMapRow(Lf.NextUInt32()));
			}
			SG(moduleWriterBase_0.Metadata.TablesHeap.ManifestResourceTable);
		}

		private void A9(ModuleWriterBase moduleWriterBase_0)
		{
			PESection pESection = new PESection(GGeneration.GenerateGuidStartingWithLetter(), 1073741888u);
			moduleWriterBase_0.AddSection(pESection);
			pESection.Add(new ByteArrayChunk(new byte[123]), 4u);
			pESection.Add(new ByteArrayChunk(new byte[10]), 4u);
			string text = ".EnigmaVB";
			string s = null;
			for (int i = 0; i < 80; i++)
			{
				text += GGeneration.GenerateGuidStartingWithLetter();
			}
			for (int j = 0; j < 80; j++)
			{
				byte[] bytes = Encoding.ASCII.GetBytes(text);
				s = EncodeString(bytes, fUQ);
			}
			byte[] bytes2 = Encoding.ASCII.GetBytes(s);
			moduleWriterBase_0.TheOptions.MetadataOptions.CustomHeaps.Add(new VUy("#Enigma VirtualBox", bytes2));
			pESection.Add(new ByteArrayChunk(bytes2), 4u);
		}

		public async Task Save()
		{
			if (ChanegAttr)
			{
				ChangeAttributes.Execute(Module);
			}
			if (UnverifiableCodeAttributeAttr.attr)
			{
				UnverifiableCodeAttributeAttr.setAttr(Module);
			}
			if (Simpilify)
			{
				Simplifying.Simplefy(Module);
			}
			if (Optimize)
			{
				Optimization.OptimizeAssembly(Module);
			}
			if (CE)
			{
				ModOpts.WriterEvent += lW;
			}
			if (AD)
			{
				ModOpts.WriterEvent += la;
			}
			if (sameLocation)
			{
				if (Path.Contains(".exe"))
				{
					OutPutPath = Path.Replace(".exe", "-Obfuscated.exe");
				}
				if (Path.Contains(".dll"))
				{
					OutPutPath = Path.Replace(".dll", "-Obfuscated.dll");
				}
			}
			else
			{
				if (!Directory.Exists(DirPath))
				{
					Directory.CreateDirectory(DirPath);
				}
				dirpath = DirPath;
			}
			await Task.Run(delegate
			{
				Module.Write(OutPutPath, ModOpts);
			});
			Dispose();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
			if (tmp != null)
			{
				try
				{
					Directory.Delete(tmp, true);
				}
				catch
				{
				}
			}
		}

		protected virtual void Dispose(bool bool_0)
		{
			if (!LT)
			{
				if (bool_0)
				{
					Module?.Dispose();
				}
				LT = true;
			}
		}

		~XContext()
		{
			Dispose(false);
		}

		static XContext()
		{
			registry = new ServiceRegistry();
			fUQ = (from int_0 in Enumerable.Range(32, 95)
				select (char)int_0).Except(new char[1] { '.' }).ToArray();
		}

		[CompilerGenerated]
		private void GP()
		{
			Module.Write(OutPutPath, ModOpts);
		}
	}
}
