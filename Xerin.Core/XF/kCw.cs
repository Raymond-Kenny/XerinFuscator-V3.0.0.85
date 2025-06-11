using System;
using System.Runtime.CompilerServices;
using Confuser.DynCipher.AST;
using XCore.Generator;

namespace XF
{
	internal class kCw : sCv
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class N0F
		{
			public static readonly N0F H0e;

			public static Func<uint, LiteralExpression> S0J;

			static N0F()
			{
				H0e = new N0F();
			}

			internal LiteralExpression L0C(uint uint_0)
			{
				return uint_0;
			}
		}

		[CompilerGenerated]
		private sealed class B0t
		{
			public RandomGenerator y06;

			internal uint z07()
			{
				return (uint)y06.NextInt32(4);
			}
		}

		[CompilerGenerated]
		private uint[,] pC8;

		[CompilerGenerated]
		private uint[,] NCZ;

		public kCw()
			: base(4)
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public uint[,] tCH()
		{
			return pC8;
		}

		[SpecialName]
		[CompilerGenerated]
		private void pCM(uint[,] uint_0)
		{
			pC8 = uint_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public uint[,] fCV()
		{
			return NCZ;
		}

		[SpecialName]
		[CompilerGenerated]
		private void oCW(uint[,] uint_0)
		{
			NCZ = uint_0;
		}

		private static uint[,] DCy(RandomGenerator randomGenerator_0)
		{
			Func<uint> func = () => (uint)randomGenerator_0.NextInt32(4);
			uint[,] obj = new uint[4, 4]
			{
				{ 1u, 0u, 0u, 0u },
				{ 0u, 1u, 0u, 0u },
				{ 0u, 0u, 1u, 0u },
				{ 0u, 0u, 0u, 1u }
			};
			obj[1, 0] = func();
			obj[2, 0] = func();
			obj[2, 1] = func();
			obj[3, 0] = func();
			obj[3, 1] = func();
			obj[3, 2] = func();
			uint[,] object_ = obj;
			uint[,] obj2 = new uint[4, 4]
			{
				{ 1u, 0u, 0u, 0u },
				{ 0u, 1u, 0u, 0u },
				{ 0u, 0u, 1u, 0u },
				{ 0u, 0u, 0u, 1u }
			};
			obj2[0, 1] = func();
			obj2[0, 2] = func();
			obj2[0, 3] = func();
			obj2[1, 2] = func();
			obj2[1, 3] = func();
			obj2[2, 3] = func();
			uint[,] object_2 = obj2;
			return BCb(object_, object_2);
		}

		private static uint[,] BCb(object object_0, object object_1)
		{
			int length = ((Array)object_0).GetLength(0);
			int length2 = ((Array)object_1).GetLength(1);
			int length3 = ((Array)object_0).GetLength(1);
			if (((Array)object_1).GetLength(0) != length3)
			{
				return null;
			}
			uint[,] array = new uint[length, length2];
			for (int i = 0; i < length; i++)
			{
				for (int k = 0; k < length2; k++)
				{
					array[i, k] = 0u;
					for (int l = 0; l < length3; l++)
					{
						array[i, k] += ((uint[,])object_0)[i, l] * ((uint[,])object_1)[l, k];
					}
				}
			}
			return array;
		}

		private static uint bCk(uint[,] uint_0, int int_0, int int_1)
		{
			uint[,] array = new uint[3, 3];
			int num = 0;
			int num2 = 0;
			while (num < 4)
			{
				if (num == int_0)
				{
					num2--;
				}
				else
				{
					int num3 = 0;
					int num4 = 0;
					while (num3 < 4)
					{
						if (num3 == int_1)
						{
							num4--;
						}
						else
						{
							array[num2, num4] = uint_0[num, num3];
						}
						num3++;
						num4++;
					}
				}
				num++;
				num2++;
			}
			uint num5 = OCu(array);
			if ((int_0 + int_1) % 2 == 0)
			{
				return num5;
			}
			return (uint)(0uL - (ulong)num5);
		}

		private static uint OCu(uint[,] uint_0)
		{
			return uint_0[0, 0] * uint_0[1, 1] * uint_0[2, 2] + uint_0[0, 1] * uint_0[1, 2] * uint_0[2, 0] + uint_0[0, 2] * uint_0[1, 0] * uint_0[2, 1] - uint_0[0, 2] * uint_0[1, 1] * uint_0[2, 0] - uint_0[0, 1] * uint_0[1, 0] * uint_0[2, 2] - uint_0[0, 0] * uint_0[1, 2] * uint_0[2, 1];
		}

		private static uint[,] lC3(uint[,] uint_0)
		{
			uint[,] array = new uint[4, 4];
			for (int i = 0; i < 4; i++)
			{
				for (int k = 0; k < 4; k++)
				{
					array[k, i] = uint_0[i, k];
				}
			}
			return array;
		}

		public override void nDV(RandomGenerator randomGenerator_0)
		{
			oCW(BCb(lC3(DCy(randomGenerator_0)), DCy(randomGenerator_0)));
			uint[,] array = new uint[4, 4];
			for (int i = 0; i < 4; i++)
			{
				for (int k = 0; k < 4; k++)
				{
					array[i, k] = bCk(fCV(), i, k);
				}
			}
			pCM(lC3(array));
		}

		private void zC5(BFr bfr_0, uint[,] uint_0)
		{
			Expression expression = bfr_0.LFc(uC4()[0]);
			Expression expression2 = bfr_0.LFc(uC4()[1]);
			Expression expression3 = bfr_0.LFc(uC4()[2]);
			Expression expression4 = bfr_0.LFc(uC4()[3]);
			Func<uint, LiteralExpression> func = (uint num) => num;
			VariableExpression variableExpression_;
			using (bfr_0.jFy(out variableExpression_))
			{
				VariableExpression variableExpression_2;
				using (bfr_0.jFy(out variableExpression_2))
				{
					VariableExpression variableExpression_3;
					using (bfr_0.jFy(out variableExpression_3))
					{
						VariableExpression variableExpression_4;
						using (bfr_0.jFy(out variableExpression_4))
						{
							bfr_0.EFq(new AssignmentStatement
							{
								Value = expression * func(uint_0[0, 0]) + expression2 * func(uint_0[0, 1]) + expression3 * func(uint_0[0, 2]) + expression4 * func(uint_0[0, 3]),
								Target = variableExpression_
							}).EFq(new AssignmentStatement
							{
								Value = expression * func(uint_0[1, 0]) + expression2 * func(uint_0[1, 1]) + expression3 * func(uint_0[1, 2]) + expression4 * func(uint_0[1, 3]),
								Target = variableExpression_2
							}).EFq(new AssignmentStatement
							{
								Value = expression * func(uint_0[2, 0]) + expression2 * func(uint_0[2, 1]) + expression3 * func(uint_0[2, 2]) + expression4 * func(uint_0[2, 3]),
								Target = variableExpression_3
							})
								.EFq(new AssignmentStatement
								{
									Value = expression * func(uint_0[3, 0]) + expression2 * func(uint_0[3, 1]) + expression3 * func(uint_0[3, 2]) + expression4 * func(uint_0[3, 3]),
									Target = variableExpression_4
								})
								.EFq(new AssignmentStatement
								{
									Value = variableExpression_,
									Target = expression
								})
								.EFq(new AssignmentStatement
								{
									Value = variableExpression_2,
									Target = expression2
								})
								.EFq(new AssignmentStatement
								{
									Value = variableExpression_3,
									Target = expression3
								})
								.EFq(new AssignmentStatement
								{
									Value = variableExpression_4,
									Target = expression4
								});
						}
					}
				}
			}
		}

		public override void ODW(BFr bfr_0)
		{
			zC5(bfr_0, tCH());
		}

		public override void fDG(BFr bfr_0)
		{
			zC5(bfr_0, fCV());
		}
	}
}
