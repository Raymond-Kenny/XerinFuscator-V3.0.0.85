using System.Runtime.CompilerServices;
using Confuser.DynCipher.AST;
using XCore.Generator;

namespace XF
{
	internal class RCC : sCv
	{
		[CompilerGenerated]
		private int rC6;

		public RCC(int int_0)
			: base(0)
		{
			uCt(int_0);
		}

		[SpecialName]
		[CompilerGenerated]
		public int hCJ()
		{
			return rC6;
		}

		[SpecialName]
		[CompilerGenerated]
		private void uCt(int int_0)
		{
			rC6 = int_0;
		}

		public override void nDV(RandomGenerator randomGenerator_0)
		{
		}

		private void QCe(BFr bfr_0)
		{
			Expression expression = bfr_0.LFc(hCJ());
			bfr_0.EFq(new AssignmentStatement
			{
				Value = (expression ^ bfr_0.RFw(hCJ())),
				Target = expression
			});
		}

		public override void ODW(BFr bfr_0)
		{
			QCe(bfr_0);
		}

		public override void fDG(BFr bfr_0)
		{
			QCe(bfr_0);
		}
	}
}
