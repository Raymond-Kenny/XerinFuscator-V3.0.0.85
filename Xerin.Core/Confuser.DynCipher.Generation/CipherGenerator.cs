using System.Collections.Generic;
using System.Linq;
using Confuser.DynCipher.AST;
using XCore.Generator;
using XF;

namespace Confuser.DynCipher.Generation
{
	public class CipherGenerator
	{
		private static void BFW<BFG>(RandomGenerator randomGenerator_0, IList<BFG> ilist_0)
		{
			for (int i = 1; i < ilist_0.Count; i++)
			{
				int index = randomGenerator_0.NextInt32(i + 1);
				BFG value = ilist_0[i];
				ilist_0[i] = ilist_0[index];
				ilist_0[index] = value;
			}
		}

		private static void uF8(StatementBlock statementBlock_0, RandomGenerator randomGenerator_0)
		{
			JQz.DFQ(statementBlock_0);
			cFF.uFJ(statementBlock_0);
			oQg.MQB(statementBlock_0);
			IFt.QFd(statementBlock_0, randomGenerator_0);
			xQI.BQE(statementBlock_0);
		}

		public static void GeneratePair(RandomGenerator randomGenerator_0, out StatementBlock statementBlock_0, out StatementBlock statementBlock_1)
		{
			double num = 1.0 + (randomGenerator_0.NextDouble() * 2.0 - 1.0) * 0.2;
			int num2 = (int)((randomGenerator_0.NextDouble() + 1.0) * 35.0 * num);
			List<sCv> list = new List<sCv>();
			for (int i = 0; i < num2 * 4 / 35; i++)
			{
				list.Add(new kCw());
			}
			for (int j = 0; j < num2 * 10 / 35; j++)
			{
				list.Add(new gCX());
			}
			for (int k = 0; k < num2 * 6 / 35; k++)
			{
				list.Add(new eeQ());
			}
			for (int l = 0; l < num2 * 9 / 35; l++)
			{
				list.Add(new aCR());
			}
			for (int m = 0; m < num2 * 6 / 35; m++)
			{
				list.Add(new NCs());
			}
			for (int n = 0; n < 16; n++)
			{
				list.Add(new RCC(n));
			}
			BFW(randomGenerator_0, list);
			int[] array = Enumerable.Range(0, 16).ToArray();
			int num3 = 16;
			bool flag = false;
			foreach (sCv item in list)
			{
				item.nDV(randomGenerator_0);
				for (int num4 = 0; num4 < item.fCx(); num4++)
				{
					if (num3 == 16)
					{
						flag = true;
						num3 = 0;
					}
					item.uC4()[num4] = array[num3++];
				}
				if (flag)
				{
					BFW(randomGenerator_0, array);
					num3 = 0;
					flag = false;
				}
			}
			BFr bFr = new BFr(randomGenerator_0, 16);
			foreach (sCv item2 in list)
			{
				item2.ODW(bFr);
			}
			statementBlock_0 = bFr.qFb();
			uF8(statementBlock_0, randomGenerator_0);
			BFr bFr2 = new BFr(randomGenerator_0, 16);
			foreach (sCv item3 in Enumerable.Reverse(list))
			{
				item3.fDG(bFr2);
			}
			statementBlock_1 = bFr2.qFb();
			uF8(statementBlock_1, randomGenerator_0);
		}
	}
}
