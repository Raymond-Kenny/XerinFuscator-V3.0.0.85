using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet.Emit;
using XF;

namespace XCore.Emulator
{
	public class XEmulator
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class S7o
		{
			public static readonly S7o D71;

			public static Func<Type, bool> R7v;

			public static Func<Type, uQQ> J7x;

			static S7o()
			{
				D71 = new S7o();
			}

			internal bool p7D(Type type_0)
			{
				return type_0.IsSubclassOf(typeof(uQQ)) && !type_0.IsAbstract;
			}

			internal uQQ e7d(Type type_0)
			{
				return (uQQ)Activator.CreateInstance(type_0);
			}
		}

		public EmuContext _context;

		private Dictionary<OpCode, uQQ> kQC;

		public XEmulator(List<Instruction> list_0, List<Local> list_1)
		{
			_context = new EmuContext(list_0, list_1);
			kQC = new Dictionary<OpCode, uQQ>();
			List<uQQ> list = (from type_0 in typeof(uQQ).Assembly.GetTypes()
				where type_0.IsSubclassOf(typeof(uQQ)) && !type_0.IsAbstract
				select (uQQ)Activator.CreateInstance(type_0)).ToList();
			foreach (uQQ item in list)
			{
				kQC.Add(item.QD5(), item);
			}
		}

		internal int OQF()
		{
			for (int i = _context.yQY; i < _context.KQU.Count; i++)
			{
				Instruction instruction = _context.KQU[i];
				if (instruction.OpCode == OpCodes.Stloc)
				{
					break;
				}
				if (instruction.OpCode != OpCodes.Nop)
				{
					kQC[instruction.OpCode].BDH(_context, instruction);
				}
			}
			return (int)_context.dQN.Pop();
		}
	}
}
