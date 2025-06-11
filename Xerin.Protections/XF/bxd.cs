#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using dnlib.DotNet.Emit;

namespace XF
{
	internal static class bxd
	{
		internal abstract class CLb
		{
			[CompilerGenerated]
			private gLH CLW;

			public CLb(gLH gLH_0)
			{
				HLt(gLH_0);
			}

			[SpecialName]
			[CompilerGenerated]
			public gLH JLE()
			{
				return CLW;
			}

			[SpecialName]
			[CompilerGenerated]
			private void HLt(gLH gLH_0)
			{
				CLW = gLH_0;
			}

			public abstract void OPu(CilBody cilBody_0);
		}

		internal enum gLH
		{

		}

		internal class tLd : CLb
		{
			[CompilerGenerated]
			private ExceptionHandler W7x;

			[CompilerGenerated]
			private List<CLb> I79;

			public tLd(gLH gLH_0, ExceptionHandler exceptionHandler_0)
				: base(gLH_0)
			{
				eLC(exceptionHandler_0);
				N72(new List<CLb>());
			}

			[SpecialName]
			[CompilerGenerated]
			public ExceptionHandler ELe()
			{
				return W7x;
			}

			[SpecialName]
			[CompilerGenerated]
			private void eLC(ExceptionHandler exceptionHandler_0)
			{
				W7x = exceptionHandler_0;
			}

			[SpecialName]
			[CompilerGenerated]
			public List<CLb> l7c()
			{
				return I79;
			}

			[SpecialName]
			[CompilerGenerated]
			public void N72(List<CLb> list_0)
			{
				I79 = list_0;
			}

			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (JLE() == (gLH)1)
				{
					stringBuilder.Append("try ");
				}
				else if (JLE() != (gLH)2)
				{
					if (JLE() == (gLH)3)
					{
						stringBuilder.Append("finally ");
					}
					else if (JLE() == (gLH)5)
					{
						stringBuilder.Append("fault ");
					}
				}
				else
				{
					stringBuilder.Append("handler ");
				}
				stringBuilder.AppendLine("{");
				foreach (CLb item in l7c())
				{
					stringBuilder.Append(item);
				}
				stringBuilder.AppendLine("}");
				return stringBuilder.ToString();
			}

			public Instruction rL3()
			{
				CLb cLb = l7c().First();
				if (cLb is tLd)
				{
					return ((tLd)cLb).rL3();
				}
				return ((y7w)cLb).w7R().First();
			}

			public Instruction WLM()
			{
				CLb cLb = l7c().Last();
				if (cLb is tLd)
				{
					return ((tLd)cLb).WLM();
				}
				return ((y7w)cLb).w7R().Last();
			}

			public override void OPu(CilBody cilBody_0)
			{
				if (JLE() != 0)
				{
					if (JLE() == (gLH)1)
					{
						ELe().TryStart = rL3();
						ELe().TryEnd = WLM();
					}
					else if (JLE() != (gLH)4)
					{
						ELe().HandlerStart = rL3();
						ELe().HandlerEnd = WLM();
					}
					else
					{
						ELe().FilterStart = rL3();
					}
				}
				foreach (CLb item in l7c())
				{
					item.OPu(cilBody_0);
				}
			}
		}

		internal class y7w : CLb
		{
			[CompilerGenerated]
			private List<Instruction> A77;

			public y7w()
				: base((gLH)0)
			{
				D7m(new List<Instruction>());
			}

			[SpecialName]
			[CompilerGenerated]
			public List<Instruction> w7R()
			{
				return A77;
			}

			[SpecialName]
			[CompilerGenerated]
			public void D7m(List<Instruction> list_0)
			{
				A77 = list_0;
			}

			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (Instruction item in w7R())
				{
					stringBuilder.AppendLine(item.ToString());
				}
				return stringBuilder.ToString();
			}

			public override void OPu(CilBody cilBody_0)
			{
				foreach (Instruction item in w7R())
				{
					cilBody_0.Instructions.Add(item);
				}
			}
		}

		public static tLd qx3(CilBody cilBody_0)
		{
			Dictionary<ExceptionHandler, Tuple<tLd, tLd, tLd>> dictionary = new Dictionary<ExceptionHandler, Tuple<tLd, tLd, tLd>>();
			foreach (ExceptionHandler exceptionHandler in cilBody_0.ExceptionHandlers)
			{
				tLd item = new tLd((gLH)1, exceptionHandler);
				gLH gLH_ = (gLH)2;
				if (exceptionHandler.HandlerType == ExceptionHandlerType.Finally)
				{
					gLH_ = (gLH)3;
				}
				else if (exceptionHandler.HandlerType == ExceptionHandlerType.Fault)
				{
					gLH_ = (gLH)5;
				}
				tLd item2 = new tLd(gLH_, exceptionHandler);
				if (exceptionHandler.FilterStart != null)
				{
					tLd item3 = new tLd((gLH)4, exceptionHandler);
					dictionary[exceptionHandler] = Tuple.Create(item, item2, item3);
				}
				else
				{
					dictionary[exceptionHandler] = Tuple.Create<tLd, tLd, tLd>(item, item2, null);
				}
			}
			tLd tLd = new tLd((gLH)0, null);
			Stack<tLd> stack = new Stack<tLd>();
			stack.Push(tLd);
			foreach (Instruction instruction in cilBody_0.Instructions)
			{
				foreach (ExceptionHandler exceptionHandler2 in cilBody_0.ExceptionHandlers)
				{
					_ = dictionary[exceptionHandler2];
					if (instruction == exceptionHandler2.TryEnd)
					{
						stack.Pop();
					}
					if (instruction == exceptionHandler2.HandlerEnd)
					{
						stack.Pop();
					}
					if (exceptionHandler2.FilterStart != null && instruction == exceptionHandler2.HandlerStart)
					{
						Debug.Assert(stack.Peek().JLE() == (gLH)4);
						stack.Pop();
					}
				}
				foreach (ExceptionHandler item4 in cilBody_0.ExceptionHandlers.Reverse())
				{
					Tuple<tLd, tLd, tLd> tuple = dictionary[item4];
					tLd tLd2 = ((stack.Count <= 0) ? null : stack.Peek());
					if (instruction == item4.TryStart)
					{
						tLd2?.l7c().Add(tuple.Item1);
						stack.Push(tuple.Item1);
					}
					if (instruction == item4.HandlerStart)
					{
						tLd2?.l7c().Add(tuple.Item2);
						stack.Push(tuple.Item2);
					}
					if (instruction == item4.FilterStart)
					{
						tLd2?.l7c().Add(tuple.Item3);
						stack.Push(tuple.Item3);
					}
				}
				tLd tLd3 = stack.Peek();
				y7w y7w = tLd3.l7c().LastOrDefault() as y7w;
				if (y7w == null)
				{
					tLd3.l7c().Add(y7w = new y7w());
				}
				y7w.w7R().Add(instruction);
			}
			foreach (ExceptionHandler exceptionHandler3 in cilBody_0.ExceptionHandlers)
			{
				if (exceptionHandler3.TryEnd == null)
				{
					stack.Pop();
				}
				if (exceptionHandler3.HandlerEnd == null)
				{
					stack.Pop();
				}
			}
			Debug.Assert(stack.Count == 1);
			return tLd;
		}
	}
}
