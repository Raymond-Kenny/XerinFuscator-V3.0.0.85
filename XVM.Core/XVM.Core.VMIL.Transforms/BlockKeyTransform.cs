using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet.Emit;
using XVM.Core.AST.IL;
using XVM.Core.CFG;
using XVM.Core.RT;
using XVM.Core.VM;

namespace XVM.Core.VMIL.Transforms
{
	public class BlockKeyTransform : IPostTransform
	{
		private struct umh
		{
			public uint wmP;

			public uint rmF;
		}

		private class Jmv
		{
			public readonly HashSet<ILBlock> Wmd = new HashSet<ILBlock>();

			public readonly HashSet<ILBlock> HmB = new HashSet<ILBlock>();
		}

		private class hm7
		{
			public readonly Dictionary<ExceptionHandler, Jmv> JmD = new Dictionary<ExceptionHandler, Jmv>();

			public readonly HashSet<ILBlock> pmy = new HashSet<ILBlock>();
		}

		[Serializable]
		[CompilerGenerated]
		private sealed class WmY
		{
			public static readonly WmY Hmp;

			public static Func<ILBlock, ILBlock> Rmr;

			public static Func<ScopeBlock, bool> rm3;

			public static Func<ScopeBlock, IEnumerable<IBasicBlock>> VmX;

			static WmY()
			{
				Hmp = new WmY();
			}

			internal ILBlock Cmg(ILBlock ilblock_0)
			{
				return ilblock_0;
			}

			internal bool DmV(ScopeBlock scopeBlock_0)
			{
				return scopeBlock_0.Type == ScopeType.None;
			}

			internal IEnumerable<IBasicBlock> nmb(ScopeBlock scopeBlock_0)
			{
				return scopeBlock_0.GetBasicBlocks();
			}
		}

		[CompilerGenerated]
		private sealed class Rmn
		{
			public uint nmf;

			public BlockKeyTransform Hmi;

			public Func<BasicBlock<ILInstrList>, uint> AmJ;

			public Func<BasicBlock<ILInstrList>, uint> Mm8;

			internal umh Lm6(ILBlock ilblock_0)
			{
				return new umh
				{
					wmP = nmf++,
					rmF = nmf++
				};
			}

			internal uint ymx(BasicBlock<ILInstrList> basicBlock_0)
			{
				return Hmi.YAC[(ILBlock)basicBlock_0].rmF;
			}

			internal uint Fms(BasicBlock<ILInstrList> basicBlock_0)
			{
				return Hmi.YAC[(ILBlock)basicBlock_0].wmP;
			}
		}

		[CompilerGenerated]
		private sealed class kmz
		{
			public HashSet<IBasicBlock> y5e;

			public Func<BasicBlock<ILInstrList>, bool> O5u;

			internal bool I54(BasicBlock<ILInstrList> basicBlock_0)
			{
				return !y5e.Contains(basicBlock_0);
			}
		}

		private Dictionary<ILBlock, umh> YAC;

		private VMMethodInfo zAm;

		private VMRuntime AA5;

		public void Initialize(ILPostTransformer ilpostTransformer_0)
		{
			AA5 = ilpostTransformer_0.Runtime;
			zAm = ilpostTransformer_0.Runtime.Descriptor.Data.LookupInfo(ilpostTransformer_0.Method);
			zAO(ilpostTransformer_0.RootScope);
		}

		public void Transform(ILPostTransformer ilpostTransformer_0)
		{
			umh umh = YAC[ilpostTransformer_0.lM3()];
			zAm.BlockKeys[ilpostTransformer_0.lM3()] = new VMBlockKey
			{
				EntryKey = (byte)umh.wmP,
				ExitKey = (byte)umh.rmF
			};
		}

		private void zAO(ScopeBlock scopeBlock_0)
		{
			List<ILBlock> list = scopeBlock_0.GetBasicBlocks().OfType<ILBlock>().ToList();
			uint nmf = 1u;
			YAC = list.ToDictionary((ILBlock ilblock_0) => ilblock_0, (ILBlock ilblock_0) => new umh
			{
				wmP = nmf++,
				rmF = nmf++
			});
			hm7 hm7_ = RAt(scopeBlock_0);
			bool bool_;
			do
			{
				bool_ = false;
				umh value = YAC[list[0]];
				value.wmP = 4294967294u;
				YAC[list[0]] = value;
				value = YAC[list[list.Count - 1]];
				value.rmF = 4294967293u;
				YAC[list[list.Count - 1]] = value;
				foreach (ILBlock item in list)
				{
					value = YAC[item];
					if (item.Sources.Count > 0)
					{
						uint num = item.Sources.Select((BasicBlock<ILInstrList> basicBlock_0) => YAC[(ILBlock)basicBlock_0].rmF).Max();
						if (value.wmP != num)
						{
							value.wmP = num;
							bool_ = true;
						}
					}
					if (item.Targets.Count > 0)
					{
						uint num2 = item.Targets.Select((BasicBlock<ILInstrList> basicBlock_0) => YAC[(ILBlock)basicBlock_0].wmP).Max();
						if (value.rmF != num2)
						{
							value.rmF = num2;
							bool_ = true;
						}
					}
					YAC[item] = value;
				}
				aAL(hm7_, ref bool_);
			}
			while (bool_);
			Dictionary<uint, uint> dictionary = new Dictionary<uint, uint>();
			dictionary[uint.MaxValue] = 0u;
			dictionary[4294967294u] = zAm.EntryKey;
			dictionary[4294967293u] = zAm.ExitKey;
			foreach (ILBlock item2 in list)
			{
				umh value2 = YAC[item2];
				uint wmP = value2.wmP;
				if (!dictionary.TryGetValue(wmP, out value2.wmP))
				{
					uint wmP2 = (dictionary[wmP] = AA5.Descriptor.iqK().NextByte());
					value2.wmP = wmP2;
				}
				uint rmF = value2.rmF;
				if (!dictionary.TryGetValue(rmF, out value2.rmF))
				{
					uint wmP2 = (dictionary[rmF] = AA5.Descriptor.iqK().NextByte());
					value2.rmF = wmP2;
				}
				YAC[item2] = value2;
			}
		}

		private hm7 RAt(ScopeBlock scopeBlock_0)
		{
			hm7 hm = new hm7();
			eAc(scopeBlock_0, hm);
			return hm;
		}

		private void eAc(ScopeBlock scopeBlock_0, hm7 hm7_0)
		{
			if (scopeBlock_0.Type != ScopeType.Filter)
			{
				if (scopeBlock_0.Type != ScopeType.None)
				{
					if (scopeBlock_0.ExceptionHandler.HandlerType == ExceptionHandlerType.Finally)
					{
						if (!hm7_0.JmD.TryGetValue(scopeBlock_0.ExceptionHandler, out var value))
						{
							value = (hm7_0.JmD[scopeBlock_0.ExceptionHandler] = new Jmv());
						}
						if (scopeBlock_0.Type != ScopeType.Try)
						{
							if (scopeBlock_0.Type == ScopeType.Handler)
							{
								IEnumerable<IBasicBlock> enumerable = ((scopeBlock_0.Children.Count > 0) ? scopeBlock_0.Children.Where((ScopeBlock scopeBlock) => scopeBlock.Type == ScopeType.None).SelectMany((ScopeBlock scopeBlock) => scopeBlock.GetBasicBlocks()) : scopeBlock_0.Content);
								foreach (ILBlock item in enumerable)
								{
									if ((item.Flags & BlockFlags.ExitEHReturn) != BlockFlags.Normal && item.Targets.Count == 0)
									{
										value.Wmd.Add(item);
									}
								}
							}
						}
						else
						{
							HashSet<IBasicBlock> y5e = new HashSet<IBasicBlock>(scopeBlock_0.GetBasicBlocks());
							foreach (ILBlock item2 in y5e)
							{
								if ((item2.Flags & BlockFlags.flag_1) == 0 || (item2.Targets.Count != 0 && !item2.Targets.Any((BasicBlock<ILInstrList> basicBlock_0) => !y5e.Contains(basicBlock_0))))
								{
									continue;
								}
								foreach (BasicBlock<ILInstrList> target in item2.Targets)
								{
									value.HmB.Add((ILBlock)target);
								}
							}
						}
					}
					if (scopeBlock_0.Type == ScopeType.Handler)
					{
						hm7_0.pmy.Add((ILBlock)scopeBlock_0.GetBasicBlocks().First());
					}
				}
			}
			else
			{
				hm7_0.pmy.Add((ILBlock)scopeBlock_0.GetBasicBlocks().First());
			}
			foreach (ScopeBlock child in scopeBlock_0.Children)
			{
				eAc(child, hm7_0);
			}
		}

		private void aAL(hm7 hm7_0, ref bool bool_0)
		{
			foreach (ILBlock item in hm7_0.pmy)
			{
				umh value = YAC[item];
				if (value.wmP != uint.MaxValue)
				{
					value.wmP = uint.MaxValue;
					YAC[item] = value;
					bool_0 = true;
				}
			}
			foreach (Jmv value4 in hm7_0.JmD.Values)
			{
				uint val = value4.Wmd.Max((ILBlock ilblock_0) => YAC[ilblock_0].rmF);
				uint val2 = value4.HmB.Max((ILBlock ilblock_0) => YAC[ilblock_0].wmP);
				uint num = Math.Max(val, val2);
				foreach (ILBlock item2 in value4.Wmd)
				{
					umh value2 = YAC[item2];
					if (value2.rmF != num)
					{
						value2.rmF = num;
						YAC[item2] = value2;
						bool_0 = true;
					}
				}
				foreach (ILBlock item3 in value4.HmB)
				{
					umh value3 = YAC[item3];
					if (value3.wmP != num)
					{
						value3.wmP = num;
						YAC[item3] = value3;
						bool_0 = true;
					}
				}
			}
		}

		[CompilerGenerated]
		private uint OAk(ILBlock ilblock_0)
		{
			return YAC[ilblock_0].rmF;
		}

		[CompilerGenerated]
		private uint XAH(ILBlock ilblock_0)
		{
			return YAC[ilblock_0].wmP;
		}
	}
}
