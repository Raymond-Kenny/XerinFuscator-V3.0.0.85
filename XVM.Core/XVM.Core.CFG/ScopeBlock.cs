using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using dnlib.DotNet.Emit;

namespace XVM.Core.CFG
{
	public class ScopeBlock
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class sZ7
		{
			public static readonly sZ7 sZy;

			public static Func<ScopeBlock, IEnumerable<IBasicBlock>> bZY;

			static sZ7()
			{
				sZy = new sZ7();
			}

			internal IEnumerable<IBasicBlock> yZD(ScopeBlock scopeBlock_0)
			{
				return scopeBlock_0.GetBasicBlocks();
			}
		}

		[Serializable]
		[CompilerGenerated]
		private sealed class CZg<tZV, HZb>
		{
			public static readonly CZg<tZV, HZb> rZX;

			public static Func<int, HZb, BasicBlock<HZb>> XZn;

			internal static object feQo;

			static CZg()
			{
				rZX = new CZg<tZV, HZb>();
			}

			internal BasicBlock<HZb> eZr(int int_0, HZb YZ3)
			{
				return new BasicBlock<HZb>(int_0, YZ3);
			}

			internal static bool feQl()
			{
				return feQo == null;
			}

			internal static object ceQZ()
			{
				return feQo;
			}
		}

		[CompilerGenerated]
		private ScopeType dta;

		[CompilerGenerated]
		private ExceptionHandler CtU;

		[CompilerGenerated]
		private IList<ScopeBlock> rth;

		[CompilerGenerated]
		private IList<IBasicBlock> ttP;

		public ScopeType Type
		{
			[CompilerGenerated]
			get
			{
				return dta;
			}
			[CompilerGenerated]
			private set
			{
				dta = value;
			}
		}

		public ExceptionHandler ExceptionHandler
		{
			[CompilerGenerated]
			get
			{
				return CtU;
			}
			[CompilerGenerated]
			private set
			{
				CtU = value;
			}
		}

		public IList<ScopeBlock> Children
		{
			[CompilerGenerated]
			get
			{
				return rth;
			}
			[CompilerGenerated]
			private set
			{
				rth = value;
			}
		}

		public IList<IBasicBlock> Content
		{
			[CompilerGenerated]
			get
			{
				return ttP;
			}
			[CompilerGenerated]
			private set
			{
				ttP = value;
			}
		}

		public ScopeBlock()
		{
			Type = ScopeType.None;
			ExceptionHandler = null;
			Children = new List<ScopeBlock>();
			Content = new List<IBasicBlock>();
		}

		public ScopeBlock(ScopeType scopeType_0, ExceptionHandler exceptionHandler_0)
		{
			if (scopeType_0 == ScopeType.None)
			{
				throw new ArgumentException("type");
			}
			Type = scopeType_0;
			ExceptionHandler = exceptionHandler_0;
			Children = new List<ScopeBlock>();
			Content = new List<IBasicBlock>();
		}

		public IEnumerable<IBasicBlock> GetBasicBlocks()
		{
			Validate();
			if (Content.Count > 0)
			{
				return Content;
			}
			return Children.SelectMany((ScopeBlock scopeBlock_0) => scopeBlock_0.GetBasicBlocks());
		}

		public Dictionary<BasicBlock<TOld>, BasicBlock<TNew>> UpdateBasicBlocks<TOld, TNew>(Func<BasicBlock<TOld>, TNew> func_0)
		{
			return UpdateBasicBlocks(func_0, (int int_0, TNew YZ3) => new BasicBlock<TNew>(int_0, YZ3));
		}

		public Dictionary<BasicBlock<TOld>, BasicBlock<TNew>> UpdateBasicBlocks<TOld, TNew>(Func<BasicBlock<TOld>, TNew> func_0, Func<int, TNew, BasicBlock<TNew>> func_1)
		{
			Dictionary<BasicBlock<TOld>, BasicBlock<TNew>> dictionary = new Dictionary<BasicBlock<TOld>, BasicBlock<TNew>>();
			ltH(func_0, dictionary, func_1);
			foreach (KeyValuePair<BasicBlock<TOld>, BasicBlock<TNew>> item in dictionary)
			{
				foreach (BasicBlock<TOld> source in item.Key.Sources)
				{
					item.Value.Sources.Add(dictionary[source]);
				}
				foreach (BasicBlock<TOld> target in item.Key.Targets)
				{
					item.Value.Targets.Add(dictionary[target]);
				}
			}
			return dictionary;
		}

		private void ltH<OtC, Ttm>(Func<BasicBlock<OtC>, Ttm> func_0, Dictionary<BasicBlock<OtC>, BasicBlock<Ttm>> dictionary_0, Func<int, Ttm, BasicBlock<Ttm>> func_1)
		{
			Validate();
			if (Content.Count > 0)
			{
				for (int i = 0; i < Content.Count; i++)
				{
					BasicBlock<OtC> basicBlock = (BasicBlock<OtC>)Content[i];
					Ttm arg = func_0(basicBlock);
					BasicBlock<Ttm> basicBlock2 = func_1(basicBlock.Id, arg);
					basicBlock2.Flags = basicBlock.Flags;
					Content[i] = basicBlock2;
					dictionary_0[basicBlock] = basicBlock2;
				}
				return;
			}
			foreach (ScopeBlock child in Children)
			{
				child.ltH(func_0, dictionary_0, func_1);
			}
		}

		public void ProcessBasicBlocks<T>(Action<BasicBlock<T>> action_0)
		{
			Validate();
			if (Content.Count > 0)
			{
				foreach (IBasicBlock item in Content)
				{
					action_0((BasicBlock<T>)item);
				}
				return;
			}
			foreach (ScopeBlock child in Children)
			{
				child.ProcessBasicBlocks(action_0);
			}
		}

		public void Validate()
		{
			if (Children.Count != 0 && Content.Count != 0)
			{
				throw new InvalidOperationException("Children and Content cannot be set at the same time.");
			}
		}

		public ScopeBlock[] SearchBlock(IBasicBlock ibasicBlock_0)
		{
			Stack<ScopeBlock> stack = new Stack<ScopeBlock>();
			Gt5(this, ibasicBlock_0, stack);
			return stack.Reverse().ToArray();
		}

		private static bool Gt5(ScopeBlock scopeBlock_0, object object_0, Stack<ScopeBlock> stack_0)
		{
			if (scopeBlock_0.Content.Count > 0)
			{
				if (scopeBlock_0.Content.Contains((IBasicBlock)object_0))
				{
					stack_0.Push(scopeBlock_0);
					return true;
				}
				return false;
			}
			stack_0.Push(scopeBlock_0);
			foreach (ScopeBlock child in scopeBlock_0.Children)
			{
				if (Gt5(child, object_0, stack_0))
				{
					return true;
				}
			}
			stack_0.Pop();
			return false;
		}

		private static string qto(object object_0)
		{
			return $"{object_0.GetHashCode():x8}:{((ExceptionHandler)object_0).HandlerType}";
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (Type != ScopeType.Try)
			{
				if (Type == ScopeType.Handler)
				{
					stringBuilder.AppendLine("handler @ " + qto(ExceptionHandler) + " {");
				}
				else if (Type != ScopeType.Filter)
				{
					stringBuilder.AppendLine("{");
				}
				else
				{
					stringBuilder.AppendLine("filter @ " + qto(ExceptionHandler) + " {");
				}
			}
			else
			{
				stringBuilder.AppendLine("try @ " + qto(ExceptionHandler) + " {");
			}
			if (Children.Count <= 0)
			{
				foreach (IBasicBlock item in Content)
				{
					stringBuilder.AppendLine(item.ToString());
				}
			}
			else
			{
				foreach (ScopeBlock child in Children)
				{
					stringBuilder.AppendLine(child.ToString());
				}
			}
			stringBuilder.AppendLine("}");
			return stringBuilder.ToString();
		}
	}
}
