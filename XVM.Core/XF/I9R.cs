using System;
using System.Runtime.CompilerServices;
using XVM.Core.Services;
using XVM.DynCipher.AST;

namespace XF
{
	internal class I9R : A94
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class Ekl
		{
			public static readonly Ekl QkT;

			public static Func<uint, LiteralExpression> rkS;

			static Ekl()
			{
				QkT = new Ekl();
			}

			internal LiteralExpression skZ(uint uint_0)
			{
				return uint_0;
			}
		}

		[CompilerGenerated]
		private sealed class Dka
		{
			public RandomGenerator GkP;

			internal uint Gkh()
			{
				return (uint)GkP.method_1(4);
			}
		}

		[CompilerGenerated]
		private uint[,] c9L;

		[CompilerGenerated]
		private uint[,] T9k;

		public I9R()
			: base(4)
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public uint[,] h9K()
		{
			return c9L;
		}

		[SpecialName]
		[CompilerGenerated]
		private void L91(uint[,] uint_0)
		{
			c9L = uint_0;
		}

		[SpecialName]
		[CompilerGenerated]
		public uint[,] p9O()
		{
			return T9k;
		}

		[SpecialName]
		[CompilerGenerated]
		private void d9t(uint[,] uint_0)
		{
			T9k = uint_0;
		}

		private static uint[,] n90(RandomGenerator randomGenerator_0)
		{
			Func<uint> func = () => (uint)randomGenerator_0.method_1(4);
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
			return T9w(object_, object_2);
		}

		private static uint[,] T9w(object object_0, object object_1)
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
				for (int j = 0; j < length2; j++)
				{
					array[i, j] = 0u;
					for (int k = 0; k < length3; k++)
					{
						array[i, j] += ((uint[,])object_0)[i, k] * ((uint[,])object_1)[k, j];
					}
				}
			}
			return array;
		}

		private static uint W9W(uint[,] uint_0, int int_0, int int_1)
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
						if (num3 != int_1)
						{
							array[num2, num4] = uint_0[num, num3];
						}
						else
						{
							num4--;
						}
						num3++;
						num4++;
					}
				}
				num++;
				num2++;
			}
			uint num5 = s9E(array);
			if ((int_0 + int_1) % 2 == 0)
			{
				return num5;
			}
			return (uint)(0uL - (ulong)num5);
		}

		private static uint s9E(uint[,] uint_0)
		{
			return uint_0[0, 0] * uint_0[1, 1] * uint_0[2, 2] + uint_0[0, 1] * uint_0[1, 2] * uint_0[2, 0] + uint_0[0, 2] * uint_0[1, 0] * uint_0[2, 1] - uint_0[0, 2] * uint_0[1, 1] * uint_0[2, 0] - uint_0[0, 1] * uint_0[1, 0] * uint_0[2, 2] - uint_0[0, 0] * uint_0[1, 2] * uint_0[2, 1];
		}

		private static uint[,] j9N(uint[,] uint_0)
		{
			uint[,] array = new uint[4, 4];
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					array[j, i] = uint_0[i, j];
				}
			}
			return array;
		}

		public override void Initialize(RandomGenerator randomGenerator_0)
		{
			d9t(T9w(j9N(n90(randomGenerator_0)), n90(randomGenerator_0)));
			uint[,] array = new uint[4, 4];
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					array[i, j] = W9W(p9O(), i, j);
				}
			}
			L91(j9N(array));
		}

		private void l92(Gu4 gu4_0, uint[,] uint_0)
		{
			Expression expression = gu4_0.Eue(P9G()[0]);
			Expression expression2 = gu4_0.Eue(P9G()[1]);
			Expression expression3 = gu4_0.Eue(P9G()[2]);
			Expression expression4 = gu4_0.Eue(P9G()[3]);
			Func<uint, LiteralExpression> func = (uint num) => num;
			VariableExpression variableExpression_;
			using (gu4_0.YuG(out variableExpression_))
			{
				VariableExpression variableExpression_2;
				using (gu4_0.YuG(out variableExpression_2))
				{
					VariableExpression variableExpression_3;
					using (gu4_0.YuG(out variableExpression_3))
					{
						VariableExpression variableExpression_4;
						using (gu4_0.YuG(out variableExpression_4))
						{
							gu4_0.gu9(new AssignmentStatement
							{
								Value = expression * func(uint_0[0, 0]) + expression2 * func(uint_0[0, 1]) + expression3 * func(uint_0[0, 2]) + expression4 * func(uint_0[0, 3]),
								Target = variableExpression_
							}).gu9(new AssignmentStatement
							{
								Value = expression * func(uint_0[1, 0]) + expression2 * func(uint_0[1, 1]) + expression3 * func(uint_0[1, 2]) + expression4 * func(uint_0[1, 3]),
								Target = variableExpression_2
							}).gu9(new AssignmentStatement
							{
								Value = expression * func(uint_0[2, 0]) + expression2 * func(uint_0[2, 1]) + expression3 * func(uint_0[2, 2]) + expression4 * func(uint_0[2, 3]),
								Target = variableExpression_3
							})
								.gu9(new AssignmentStatement
								{
									Value = expression * func(uint_0[3, 0]) + expression2 * func(uint_0[3, 1]) + expression3 * func(uint_0[3, 2]) + expression4 * func(uint_0[3, 3]),
									Target = variableExpression_4
								})
								.gu9(new AssignmentStatement
								{
									Value = variableExpression_,
									Target = expression
								})
								.gu9(new AssignmentStatement
								{
									Value = variableExpression_2,
									Target = expression2
								})
								.gu9(new AssignmentStatement
								{
									Value = variableExpression_3,
									Target = expression3
								})
								.gu9(new AssignmentStatement
								{
									Value = variableExpression_4,
									Target = expression4
								});
						}
					}
				}
			}
		}

		public override void dUo(Gu4 gu4_0)
		{
			l92(gu4_0, h9K());
		}

		public override void DUl(Gu4 gu4_0)
		{
			l92(gu4_0, p9O());
		}
	}
}
