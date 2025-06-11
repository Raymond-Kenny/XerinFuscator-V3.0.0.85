using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Pdb;
using XVM.Core.Services;
using XVM.DynCipher;

namespace XVM.Core.RTProtections.KroksCFlow
{
	public class KroksContext
	{
		[CompilerGenerated]
		private int B1G;

		[CompilerGenerated]
		private DynCipherService O1I;

		[CompilerGenerated]
		private double Q1q;

		[CompilerGenerated]
		private bool L1M;

		[CompilerGenerated]
		private MethodDef J1A;

		[CompilerGenerated]
		private Local B1R;

		[CompilerGenerated]
		private RandomGenerator n10;

		public int Depth
		{
			[CompilerGenerated]
			get
			{
				return B1G;
			}
			[CompilerGenerated]
			set
			{
				B1G = value;
			}
		}

		public DynCipherService DynCipher
		{
			[CompilerGenerated]
			get
			{
				return O1I;
			}
			[CompilerGenerated]
			set
			{
				O1I = value;
			}
		}

		public double Intensity
		{
			[CompilerGenerated]
			get
			{
				return Q1q;
			}
			[CompilerGenerated]
			set
			{
				Q1q = value;
			}
		}

		public bool JunkCode
		{
			[CompilerGenerated]
			get
			{
				return L1M;
			}
			[CompilerGenerated]
			set
			{
				L1M = value;
			}
		}

		public MethodDef Method
		{
			[CompilerGenerated]
			get
			{
				return J1A;
			}
			[CompilerGenerated]
			set
			{
				J1A = value;
			}
		}

		public Local StateVariable
		{
			[CompilerGenerated]
			get
			{
				return B1R;
			}
			[CompilerGenerated]
			set
			{
				B1R = value;
			}
		}

		public RandomGenerator Random
		{
			[CompilerGenerated]
			get
			{
				return n10;
			}
			[CompilerGenerated]
			set
			{
				n10 = value;
			}
		}

		public void ProcessMethod(CilBody cilBody_0, KroksContext kroksContext_0)
		{
			ScopeBlock scopeBlock = BlockParser.ParseBody(cilBody_0);
			new IfMangler().Mangle(cilBody_0, scopeBlock, kroksContext_0);
			cilBody_0.Instructions.Clear();
			scopeBlock.ToBody(cilBody_0);
			if (cilBody_0.PdbMethod != null)
			{
				cilBody_0.PdbMethod = new PdbMethod
				{
					Scope = new PdbScope
					{
						Start = cilBody_0.Instructions.First(),
						End = cilBody_0.Instructions.Last()
					}
				};
			}
			foreach (ExceptionHandler exceptionHandler in cilBody_0.ExceptionHandlers)
			{
				int num = cilBody_0.Instructions.IndexOf(exceptionHandler.TryEnd) + 1;
				exceptionHandler.TryEnd = ((num < cilBody_0.Instructions.Count) ? cilBody_0.Instructions[num] : null);
				num = cilBody_0.Instructions.IndexOf(exceptionHandler.HandlerEnd) + 1;
				exceptionHandler.HandlerEnd = ((num >= cilBody_0.Instructions.Count) ? null : cilBody_0.Instructions[num]);
			}
			cilBody_0.KeepOldMaxStack = true;
		}

		public void AddJump(IList<Instruction> ilist_0, Instruction instruction_0)
		{
			ilist_0.Add(Instruction.Create(OpCodes.Br, instruction_0));
		}

		public void AddJunk(IList<Instruction> ilist_0)
		{
			if (!Method.Module.IsClr40 && JunkCode)
			{
				switch (Random.method_1(6))
				{
				case 0:
					ilist_0.Add(Instruction.Create(OpCodes.Pop));
					break;
				case 1:
					ilist_0.Add(Instruction.Create(OpCodes.Dup));
					break;
				case 2:
					ilist_0.Add(Instruction.Create(OpCodes.Throw));
					break;
				case 3:
					ilist_0.Add(Instruction.Create(OpCodes.Ldarg, new Parameter(255)));
					break;
				case 4:
					ilist_0.Add(Instruction.Create(OpCodes.Ldloc, new Local(null, null, 255)));
					break;
				case 5:
					ilist_0.Add(Instruction.Create(OpCodes.Ldtoken, Method));
					break;
				}
			}
		}
	}
}
