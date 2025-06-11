#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;
using XF;
using XVM.Core.AST;
using XVM.Core.AST.IL;
using XVM.Core.CFG;
using XVM.Core.JIT;
using XVM.Core.RTProtections;
using XVM.Core.RTProtections.Constants;
using XVM.Core.RTProtections.KroksCFlow;
using XVM.Core.Services;
using XVM.Core.VM;

namespace XVM.Core.RT
{
	public class VMRuntime
	{
		internal Dictionary<MethodDef, Tuple<XVM.Core.CFG.ScopeBlock, ILBlock>> z2P;

		private List<Tuple<MethodDef, ILBlock>> Q2F;

		private List<IChunk> m2v;

		private List<IChunk> f2d;

		private List<byte> d2B;

		[CompilerGenerated]
		private ModuleDefMD d27;

		[CompilerGenerated]
		private ModuleWriterOptions B2D;

		[CompilerGenerated]
		private CompressionService T2y;

		[CompilerGenerated]
		private Virtualizer v2Y;

		[CompilerGenerated]
		private List<JITEDMethodInfo> Q2g;

		[CompilerGenerated]
		private VMDescriptor e2V;

		[CompilerGenerated]
		private hNA N2b;

		[CompilerGenerated]
		private XKI x2p;

		[CompilerGenerated]
		private PKj Q2r;

		[CompilerGenerated]
		private c2f c23;

		[CompilerGenerated]
		private MemoryStream r2X;

		[CompilerGenerated]
		private double j2n;

		[CompilerGenerated]
		private ILVDynamicDeriver S26;

		public ModuleDefMD RTModule
		{
			[CompilerGenerated]
			get
			{
				return d27;
			}
			[CompilerGenerated]
			private set
			{
				d27 = value;
			}
		}

		public ModuleWriterOptions RTModuleWriterOptions
		{
			[CompilerGenerated]
			get
			{
				return B2D;
			}
			[CompilerGenerated]
			private set
			{
				B2D = value;
			}
		}

		public CompressionService CompressionService
		{
			[CompilerGenerated]
			get
			{
				return T2y;
			}
			[CompilerGenerated]
			private set
			{
				T2y = value;
			}
		}

		public Virtualizer Virtualizer
		{
			[CompilerGenerated]
			get
			{
				return v2Y;
			}
			[CompilerGenerated]
			private set
			{
				v2Y = value;
			}
		}

		public List<JITEDMethodInfo> JITMethods
		{
			[CompilerGenerated]
			get
			{
				return Q2g;
			}
			[CompilerGenerated]
			private set
			{
				Q2g = value;
			}
		}

		public VMDescriptor Descriptor
		{
			[CompilerGenerated]
			get
			{
				return e2V;
			}
			[CompilerGenerated]
			private set
			{
				e2V = value;
			}
		}

		public double EncryptionKey
		{
			[CompilerGenerated]
			get
			{
				return j2n;
			}
			[CompilerGenerated]
			private set
			{
				j2n = value;
			}
		}

		public ILVDynamicDeriver __ILVDATA_Deriver
		{
			[CompilerGenerated]
			get
			{
				return S26;
			}
			[CompilerGenerated]
			private set
			{
				S26 = value;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		internal hNA W2O()
		{
			return N2b;
		}

		[SpecialName]
		[CompilerGenerated]
		private void Q2t(hNA hNA_0)
		{
			N2b = hNA_0;
		}

		[SpecialName]
		[CompilerGenerated]
		internal XKI i2L()
		{
			return x2p;
		}

		[SpecialName]
		[CompilerGenerated]
		private void o2k(XKI xki_0)
		{
			x2p = xki_0;
		}

		[SpecialName]
		[CompilerGenerated]
		internal PKj f2C()
		{
			return Q2r;
		}

		[SpecialName]
		[CompilerGenerated]
		internal void n2m(PKj pkj_0)
		{
			Q2r = pkj_0;
		}

		[SpecialName]
		[CompilerGenerated]
		internal c2f o2o()
		{
			return c23;
		}

		[SpecialName]
		[CompilerGenerated]
		private void k2l(c2f c2f_0)
		{
			c23 = c2f_0;
		}

		[SpecialName]
		[CompilerGenerated]
		internal MemoryStream u2T()
		{
			return r2X;
		}

		[SpecialName]
		[CompilerGenerated]
		internal void Y2S(MemoryStream memoryStream_0)
		{
			r2X = memoryStream_0;
		}

		public VMRuntime(Virtualizer virtualizer_0, ModuleDef moduleDef_0)
		{
			z2P = new Dictionary<MethodDef, Tuple<XVM.Core.CFG.ScopeBlock, ILBlock>>();
			Q2F = new List<Tuple<MethodDef, ILBlock>>();
			m2v = new List<IChunk>();
			f2d = new List<IChunk>();
			d2B = new List<byte>();
			EncryptionKey = new RandomGenerator().NextDouble() / (double)new RandomGenerator().method_0();
			RTModule = (ModuleDefMD)moduleDef_0;
			Virtualizer = virtualizer_0;
			RTModuleWriterOptions = new ModuleWriterOptions(RTModule)
			{
				Logger = DummyLogger.NoThrowInstance,
				PdbOptions = PdbWriterOptions.None,
				WritePdb = false
			};
			CompressionService = new CompressionService();
			JITMethods = new List<JITEDMethodInfo>();
			Descriptor = new VMDescriptor(virtualizer_0);
			Q2t(new hNA(this));
			o2k(new XKI(this));
			n2m(new PKj(moduleDef_0, this).dKO());
			k2l(new c2f(moduleDef_0));
			__ILVDATA_Deriver = new ILVDynamicDeriver();
		}

		public void AddMethod(MethodDef methodDef_0, XVM.Core.CFG.ScopeBlock scopeBlock_0)
		{
			ILBlock iLBlock = null;
			foreach (ILBlock basicBlock in scopeBlock_0.GetBasicBlocks())
			{
				if (basicBlock.Id == 0)
				{
					iLBlock = basicBlock;
				}
				Q2F.Add(Tuple.Create(methodDef_0, basicBlock));
			}
			Debug.Assert(iLBlock != null);
			z2P[methodDef_0] = Tuple.Create(scopeBlock_0, iLBlock);
		}

		internal void b20(MethodDef methodDef_0, XVM.Core.CFG.ScopeBlock scopeBlock_0, ILBlock ilblock_0)
		{
			z2P[methodDef_0] = Tuple.Create(scopeBlock_0, ilblock_0);
		}

		public void AddBlock(MethodDef methodDef_0, ILBlock ilblock_0)
		{
			Q2F.Add(Tuple.Create(methodDef_0, ilblock_0));
		}

		public XVM.Core.CFG.ScopeBlock LookupMethod(MethodDef methodDef_0)
		{
			Tuple<XVM.Core.CFG.ScopeBlock, ILBlock> tuple = z2P[methodDef_0];
			return tuple.Item1;
		}

		public XVM.Core.CFG.ScopeBlock LookupMethod(MethodDef methodDef_0, out ILBlock ilblock_0)
		{
			Tuple<XVM.Core.CFG.ScopeBlock, ILBlock> tuple = z2P[methodDef_0];
			ilblock_0 = tuple.Item2;
			return tuple.Item1;
		}

		public void AddChunk(IChunk ichunk_0)
		{
			m2v.Add(ichunk_0);
		}

		public void ExportMethod(MethodDef methodDef_0, MDToken mdtoken_0)
		{
			Descriptor.Data.ReadExportMDToken(methodDef_0, mdtoken_0);
			d2s.G2Q((MethodDef)(object)f2C(), methodDef_0);
		}

		public void OnKoiRequested()
		{
			JNk jNk = new JNk(this);
			foreach (Tuple<MethodDef, ILBlock> item in Q2F)
			{
				f2d.Add(item.Item2.CreateChunk(this, item.Item1));
			}
			f2d.AddRange(m2v);
			Descriptor.iqK().Shuffle(f2d);
			f2d.Insert(0, jNk);
			v2w();
			H2W();
			jNk.xNm(this);
			List<byte> list = new List<byte>();
			foreach (IChunk item2 in f2d)
			{
				list.AddRange(item2.GetData());
			}
			__ILVDATA_Deriver.Initialize(this);
			byte[] array = __ILVDATA_Deriver.Encrypt(list.ToArray(), 0);
			for (int i = 0; i < array.Length; i++)
			{
				d2B.Add(array[i]);
			}
			byte[] bytes = BitConverter.GetBytes(EncryptionKey);
			XjJ.jOu(f2C().xKr, new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 }, new int[8]
			{
				bytes[0],
				bytes[1],
				bytes[2],
				bytes[3],
				bytes[4],
				bytes[5],
				bytes[6],
				bytes[7]
			});
			XjJ.jOu(f2C().NKv, new int[3] { 2, 3, 4 }, new int[3]
			{
				Descriptor.Data.NIz.Count,
				Descriptor.Data.EIJ.Count,
				Descriptor.Data.QI8.Count
			});
			TypeDefUser typeDefUser = new TypeDefUser(o2o().i2i(Descriptor.iqK().NextString()), RTModule.CorLibTypes.GetTypeRef("System", "ValueType"))
			{
				Layout = TypeAttributes.ExplicitLayout,
				Visibility = TypeAttributes.Sealed,
				IsSealed = true,
				ClassLayout = new ClassLayoutUser(0, (uint)d2B.Count)
			};
			RTModule.Types.Add(typeDefUser);
			FieldDefUser fieldDefUser = new FieldDefUser(o2o().i2i(Descriptor.iqK().NextString()), new FieldSig(typeDefUser.ToTypeSig()), FieldAttributes.Private | FieldAttributes.Static | FieldAttributes.HasFieldRVA)
			{
				HasFieldRVA = true,
				InitialValue = d2B.ToArray()
			};
			f2C().DKF.Fields.Add(fieldDefUser);
			XjJ.sj8(f2C().NKv, 0, d2B.Count / 4);
			XjJ.wOM(f2C().NKv, bool_0: true, out var int_);
			f2C().NKv.Body.Instructions.Insert(int_, Instruction.Create(OpCodes.Ldtoken, fieldDefUser));
			f2C().NKv.Body.Instructions.Insert(int_ + 1, Instruction.Create(OpCodes.Call, RTModule.Import(f2C().SKm)));
			f2C().NKv.Body.Instructions.Insert(int_ + 2, Instruction.Create(OpCodes.Callvirt, RTModule.Import(f2C().TK5)));
			XjJ.sj8(f2C().NKv, 1, __ILVDATA_Deriver.Seed);
			f2C().NKv.Body.SimplifyMacros(f2C().NKv.Parameters);
			List<Instruction> list2 = f2C().NKv.Body.Instructions.ToList();
			for (int j = 0; j < list2.Count; j++)
			{
				Instruction instruction = list2[j];
				IMethod method = instruction.Operand as IMethod;
				if (instruction.OpCode == OpCodes.Call && method.DeclaringType.Name == TNd.Q29 && method.Name == TNd.T2A)
				{
					Instruction instruction2 = list2[j - 2];
					Instruction instruction3 = list2[j - 1];
					list2.RemoveAt(j);
					list2.RemoveAt(j - 1);
					list2.RemoveAt(j - 2);
					list2.InsertRange(j - 2, __ILVDATA_Deriver.EmitDecrypt(f2C().NKv, (Local)instruction2.Operand, (Local)instruction3.Operand));
				}
			}
			f2C().NKv.Body.Instructions.Clear();
			foreach (Instruction item3 in list2)
			{
				f2C().NKv.Body.Instructions.Add(item3);
			}
			new ConstantsProtection().Execute(RTModule, this);
			foreach (TypeDef type in RTModule.GetTypes())
			{
				foreach (MethodDef method2 in type.Methods)
				{
					if (method2.HasBody && method2.Body.HasInstructions)
					{
						KroksControlFlow.Execute(method2);
					}
				}
			}
			Anti_De4dot.Execute(RTModule, "");
		}

		private void v2w()
		{
			uint num = 0u;
			foreach (IChunk item in f2d)
			{
				item.OnOffsetComputed(num);
				num += item.Length;
			}
		}

		private void H2W()
		{
			foreach (Tuple<MethodDef, ILBlock> item in Q2F)
			{
				foreach (ILInstruction item2 in item.Item2.Content)
				{
					if (item2.Operand is ILRelReference)
					{
						ILRelReference iLRelReference = (ILRelReference)item2.Operand;
						item2.Operand = ILImmediate.Create(iLRelReference.Resolve(this), ASTType.I4);
					}
				}
			}
		}

		public void ResetData()
		{
			z2P = new Dictionary<MethodDef, Tuple<XVM.Core.CFG.ScopeBlock, ILBlock>>();
			Q2F = new List<Tuple<MethodDef, ILBlock>>();
			m2v = new List<IChunk>();
			f2d = new List<IChunk>();
			Descriptor.ResetData();
		}
	}
}
