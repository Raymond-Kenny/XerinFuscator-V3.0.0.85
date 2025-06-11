using System.Collections.Generic;
using System.Linq;
using XVM.Core.Services;
using XVM.DynCipher.AST;

namespace XF
{
	internal class HuN
	{
		private static void Ju2<suK>(RandomGenerator randomGenerator_0, IList<suK> ilist_0)
		{
			for (int i = 1; i < ilist_0.Count; i++)
			{
				int index = randomGenerator_0.method_1(i + 1);
				suK value = ilist_0[i];
				ilist_0[i] = ilist_0[index];
				ilist_0[index] = value;
			}
		}

		private static void ju1(StatementBlock statementBlock_0, RandomGenerator randomGenerator_0)
		{
			VeP.ieB(statementBlock_0);
			ce7.ceY(statementBlock_0);
			gea.ieh(statementBlock_0);
			ueg.Wen(statementBlock_0, randomGenerator_0);
			del.QeS(statementBlock_0);
		}

		public static void Cuj(RandomGenerator randomGenerator_0, out StatementBlock statementBlock_0, out StatementBlock statementBlock_1)
		{
			double num = 1.0 + (randomGenerator_0.NextDouble() * 2.0 - 1.0) * 0.2;
			int num2 = (int)((randomGenerator_0.NextDouble() + 1.0) * 35.0 * num);
			List<A94> list = new List<A94>();
			for (int i = 0; i < num2 * 4 / 35; i++)
			{
				list.Add(new I9R());
			}
			for (int j = 0; j < num2 * 10 / 35; j++)
			{
				list.Add(new f9m());
			}
			for (int k = 0; k < num2 * 6 / 35; k++)
			{
				list.Add(new J9r());
			}
			for (int l = 0; l < num2 * 9 / 35; l++)
			{
				list.Add(new uuf());
			}
			for (int m = 0; m < num2 * 6 / 35; m++)
			{
				list.Add(new L9d());
			}
			for (int n = 0; n < 16; n++)
			{
				list.Add(new ru3(n));
			}
			Ju2(randomGenerator_0, list);
			int[] array = Enumerable.Range(0, 16).ToArray();
			int num3 = 16;
			bool flag = false;
			foreach (A94 item in list)
			{
				item.Initialize(randomGenerator_0);
				for (int num4 = 0; num4 < item.B9e(); num4++)
				{
					if (num3 == 16)
					{
						flag = true;
						num3 = 0;
					}
					item.P9G()[num4] = array[num3++];
				}
				if (flag)
				{
					Ju2(randomGenerator_0, array);
					num3 = 0;
					flag = false;
				}
			}
			Gu4 gu = new Gu4(randomGenerator_0, 16);
			foreach (A94 item2 in list)
			{
				item2.dUo(gu);
			}
			statementBlock_0 = gu.WuI();
			ju1(statementBlock_0, randomGenerator_0);
			Gu4 gu2 = new Gu4(randomGenerator_0, 16);
			foreach (A94 item3 in Enumerable.Reverse(list))
			{
				item3.DUl(gu2);
			}
			statementBlock_1 = gu2.WuI();
			ju1(statementBlock_1, randomGenerator_0);
		}
	}
}
