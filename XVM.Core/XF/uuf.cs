using System.Runtime.CompilerServices;
using XVM.Core.Services;
using XVM.DynCipher.AST;

namespace XF
{
	internal class uuf : A94
	{
		[CompilerGenerated]
		private XuQ Euz;

		public uuf()
			: base(2)
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public XuQ rui()
		{
			return Euz;
		}

		[SpecialName]
		[CompilerGenerated]
		private void huJ(XuQ xuQ_0)
		{
			Euz = xuQ_0;
		}

		public override void Initialize(RandomGenerator randomGenerator_0)
		{
			huJ((XuQ)randomGenerator_0.method_1(3));
		}

		public override void dUo(Gu4 gu4_0)
		{
			Expression expression = gu4_0.Eue(P9G()[0]);
			Expression expression2 = gu4_0.Eue(P9G()[1]);
			switch (rui())
			{
			case (XuQ)0:
				gu4_0.gu9(new AssignmentStatement
				{
					Value = expression + expression2,
					Target = expression
				});
				break;
			case (XuQ)1:
				gu4_0.gu9(new AssignmentStatement
				{
					Value = (expression ^ expression2),
					Target = expression
				});
				break;
			case (XuQ)2:
				gu4_0.gu9(new AssignmentStatement
				{
					Value = ~(expression ^ expression2),
					Target = expression
				});
				break;
			}
		}

		public override void DUl(Gu4 gu4_0)
		{
			Expression expression = gu4_0.Eue(P9G()[0]);
			Expression expression2 = gu4_0.Eue(P9G()[1]);
			switch (rui())
			{
			case (XuQ)0:
				gu4_0.gu9(new AssignmentStatement
				{
					Value = expression - expression2,
					Target = expression
				});
				break;
			case (XuQ)1:
				gu4_0.gu9(new AssignmentStatement
				{
					Value = (expression ^ expression2),
					Target = expression
				});
				break;
			case (XuQ)2:
				gu4_0.gu9(new AssignmentStatement
				{
					Value = (expression ^ ~expression2),
					Target = expression
				});
				break;
			}
		}
	}
}
