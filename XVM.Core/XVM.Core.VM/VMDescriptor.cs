using System.Runtime.CompilerServices;
using XVM.Core.Services;

namespace XVM.Core.VM
{
	public class VMDescriptor
	{
		[CompilerGenerated]
		private readonly RandomGenerator mqO;

		[CompilerGenerated]
		private readonly IVMSettings Bqt;

		[CompilerGenerated]
		private readonly ArchDescriptor Pqc;

		[CompilerGenerated]
		private readonly RuntimeDescriptor bqL;

		[CompilerGenerated]
		private DataDescriptor qqk;

		public IVMSettings Settings
		{
			[CompilerGenerated]
			get
			{
				return Bqt;
			}
		}

		public ArchDescriptor Architecture
		{
			[CompilerGenerated]
			get
			{
				return Pqc;
			}
		}

		public RuntimeDescriptor Runtime
		{
			[CompilerGenerated]
			get
			{
				return bqL;
			}
		}

		public DataDescriptor Data
		{
			[CompilerGenerated]
			get
			{
				return qqk;
			}
			[CompilerGenerated]
			private set
			{
				qqk = value;
			}
		}

		public VMDescriptor(IVMSettings ivmsettings_0)
		{
			Bqt = ivmsettings_0;
			mqO = new RandomGenerator(32);
			Pqc = new ArchDescriptor(iqK());
			bqL = new RuntimeDescriptor(iqK());
			Data = new DataDescriptor((Virtualizer)ivmsettings_0, iqK());
		}

		[SpecialName]
		[CompilerGenerated]
		internal RandomGenerator iqK()
		{
			return mqO;
		}

		public void ResetData()
		{
			Data = new DataDescriptor((Virtualizer)Settings, iqK());
		}
	}
}
