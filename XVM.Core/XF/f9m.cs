using System.Runtime.CompilerServices;
using XVM.Core.Services;
using XVM.DynCipher;
using XVM.DynCipher.AST;

namespace XF
{
	internal class f9m : A94
	{
		[CompilerGenerated]
		private uint f9P;

		[CompilerGenerated]
		private uint i9F;

		[CompilerGenerated]
		private XuQ S9v;

		public f9m()
			: base(1)
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public uint t95()
		{
			return f9P;
		}

		[SpecialName]
		[CompilerGenerated]
		private void y9o(uint uint_0)
		{
			f9P = uint_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public uint S9Z()
		{
			return i9F;
		}

		[SpecialName]
		[CompilerGenerated]
		private void E9T(uint uint_0)
		{
			i9F = uint_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public XuQ e9a()
		{
			return S9v;
		}

		[SpecialName]
		[CompilerGenerated]
		private void A9U(XuQ xuQ_0)
		{
			S9v = xuQ_0;
		}

		public override void Initialize(RandomGenerator randomGenerator_0)
		{
			A9U((XuQ)randomGenerator_0.method_1(4));
			switch (e9a())
			{
			case (XuQ)1:
				y9o(randomGenerator_0.method_3() | 1);
				E9T(MathsUtils.modInv(t95()));
				break;
			case (XuQ)0:
			case (XuQ)2:
			{
				uint uint_;
				E9T(uint_ = randomGenerator_0.method_3());
				y9o(uint_);
				break;
			}
			case (XuQ)3:
				y9o(randomGenerator_0.method_3());
				E9T(~t95());
				break;
			}
		}

		public override void dUo(Gu4 gu4_0)
		{
			Expression expression = gu4_0.Eue(P9G()[0]);
			switch (e9a())
			{
			case (XuQ)0:
				gu4_0.gu9(new AssignmentStatement
				{
					Value = expression + (LiteralExpression)t95(),
					Target = expression
				});
				break;
			case (XuQ)1:
				gu4_0.gu9(new AssignmentStatement
				{
					Value = expression * (LiteralExpression)t95(),
					Target = expression
				});
				break;
			case (XuQ)2:
				gu4_0.gu9(new AssignmentStatement
				{
					Value = (expression ^ (LiteralExpression)t95()),
					Target = expression
				});
				break;
			case (XuQ)3:
				gu4_0.gu9(new AssignmentStatement
				{
					Value = ~(expression ^ (LiteralExpression)t95()),
					Target = expression
				});
				break;
			}
		}

		public override void DUl(Gu4 gu4_0)
		{
			Expression expression = gu4_0.Eue(P9G()[0]);
			switch (e9a())
			{
			case (XuQ)0:
				gu4_0.gu9(new AssignmentStatement
				{
					Value = expression - (LiteralExpression)S9Z(),
					Target = expression
				});
				break;
			case (XuQ)1:
				gu4_0.gu9(new AssignmentStatement
				{
					Value = expression * (LiteralExpression)S9Z(),
					Target = expression
				});
				break;
			case (XuQ)2:
				gu4_0.gu9(new AssignmentStatement
				{
					Value = (expression ^ (LiteralExpression)S9Z()),
					Target = expression
				});
				break;
			case (XuQ)3:
				gu4_0.gu9(new AssignmentStatement
				{
					Value = (expression ^ (LiteralExpression)S9Z()),
					Target = expression
				});
				break;
			}
		}
	}
}
