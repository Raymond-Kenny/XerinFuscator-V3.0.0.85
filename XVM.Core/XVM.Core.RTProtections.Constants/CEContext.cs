using System.Collections.Generic;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Writer;
using XVM.Core.RT;
using XVM.Core.Services;
using XVM.DynCipher;

namespace XVM.Core.RTProtections.Constants
{
	public class CEContext
	{
		[CompilerGenerated]
		private VMRuntime A12;

		[CompilerGenerated]
		private ModuleDef f1K;

		[CompilerGenerated]
		private ModuleWriterOptions x11;

		[CompilerGenerated]
		private MethodDef L1j;

		[CompilerGenerated]
		private int Q1O;

		[CompilerGenerated]
		private CompressionService w1t;

		[CompilerGenerated]
		private List<DecoderInfo> a1c;

		[CompilerGenerated]
		private List<uint> j1L;

		[CompilerGenerated]
		private DynamicMode e1k;

		[CompilerGenerated]
		private DynCipherService j1H;

		[CompilerGenerated]
		private RandomGenerator T1C;

		[CompilerGenerated]
		private Dictionary<MethodDef, List<ReplaceableInstructionReference>> z1m;

		public VMRuntime VMRuntime
		{
			[CompilerGenerated]
			get
			{
				return A12;
			}
			[CompilerGenerated]
			set
			{
				A12 = value;
			}
		}

		public ModuleDef Module
		{
			[CompilerGenerated]
			get
			{
				return f1K;
			}
			[CompilerGenerated]
			set
			{
				f1K = value;
			}
		}

		public ModuleWriterOptions Options
		{
			[CompilerGenerated]
			get
			{
				return x11;
			}
			[CompilerGenerated]
			set
			{
				x11 = value;
			}
		}

		public MethodDef InitMethod
		{
			[CompilerGenerated]
			get
			{
				return L1j;
			}
			[CompilerGenerated]
			set
			{
				L1j = value;
			}
		}

		public int DecoderCount
		{
			[CompilerGenerated]
			get
			{
				return Q1O;
			}
			[CompilerGenerated]
			set
			{
				Q1O = value;
			}
		}

		public CompressionService Compressor
		{
			[CompilerGenerated]
			get
			{
				return w1t;
			}
			[CompilerGenerated]
			set
			{
				w1t = value;
			}
		}

		public List<DecoderInfo> Decoders
		{
			[CompilerGenerated]
			get
			{
				return a1c;
			}
			[CompilerGenerated]
			set
			{
				a1c = value;
			}
		}

		public List<uint> EncodedBuffer
		{
			[CompilerGenerated]
			get
			{
				return j1L;
			}
			[CompilerGenerated]
			set
			{
				j1L = value;
			}
		}

		public DynamicMode ModeHandler
		{
			[CompilerGenerated]
			get
			{
				return e1k;
			}
			[CompilerGenerated]
			set
			{
				e1k = value;
			}
		}

		public DynCipherService DynCipher
		{
			[CompilerGenerated]
			get
			{
				return j1H;
			}
			[CompilerGenerated]
			set
			{
				j1H = value;
			}
		}

		public RandomGenerator Random
		{
			[CompilerGenerated]
			get
			{
				return T1C;
			}
			[CompilerGenerated]
			set
			{
				T1C = value;
			}
		}

		public Dictionary<MethodDef, List<ReplaceableInstructionReference>> ReferenceRepl
		{
			[CompilerGenerated]
			get
			{
				return z1m;
			}
			[CompilerGenerated]
			set
			{
				z1m = value;
			}
		}
	}
}
