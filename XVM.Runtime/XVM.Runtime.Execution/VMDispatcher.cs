using System;
using System.Runtime.CompilerServices;
using XVM.Runtime.XVM.Runtime.Data;

namespace XVM.Runtime.XVM.Runtime.Execution
{
	internal static class VMDispatcher
	{
		public static ExecutionState Invoke(VMContext ctx)
		{
			ExecutionState state = ExecutionState.Next;
			bool flag = true;
			do
			{
				try
				{
					state = RunInternal(ctx);
					switch (state)
					{
					case ExecutionState.Throw:
					{
						uint u2 = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
						VMSlot vMSlot2 = ctx.Stack[u2--];
						ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u2;
						DoThrow(ctx, vMSlot2.O);
						break;
					}
					case ExecutionState.Rethrow:
					{
						uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
						VMSlot vMSlot = ctx.Stack[u--];
						ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
						HandleRethrow(ctx, vMSlot.O);
						return state;
					}
					}
					flag = false;
				}
				catch (Exception ex)
				{
					SetupEHState(ctx, ex);
					flag = false;
				}
				finally
				{
					if (flag)
					{
						HandleAbnormalExit(ctx);
						state = ExecutionState.Exit;
					}
					else if (ctx.EHStates.Count > 0)
					{
						do
						{
							HandleEH(ctx, ref state);
						}
						while (state == ExecutionState.Rethrow);
					}
				}
			}
			while (state != ExecutionState.Exit);
			return state;
		}

		private static Exception Throw(object obj)
		{
			return null;
		}

		private static ExecutionState RunInternal(VMContext ctx)
		{
			ExecutionState state;
			do
			{
				byte code = ctx.ReadByte();
				byte b = ctx.ReadByte();
				OpCodeMap.Lookup(code).Run(ctx, out state);
				if (ctx.Registers[ctx.Data.Constants.REG_IP].U8 == 1)
				{
					state = ExecutionState.Exit;
				}
			}
			while (state == ExecutionState.Next);
			return state;
		}

		private static void SetupEHState(VMContext ctx, object ex)
		{
			EHState eHState;
			if (ctx.EHStates.Count != 0)
			{
				eHState = ctx.EHStates[ctx.EHStates.Count - 1];
				if (eHState.CurrentFrame.HasValue)
				{
					if (eHState.CurrentProcess == EHState.EHProcess.Searching)
					{
						ctx.Registers[ctx.Data.Constants.REG_R1].U1 = 0;
					}
					else if (eHState.CurrentProcess == EHState.EHProcess.Unwinding)
					{
						eHState.ExceptionObj = ex;
					}
					return;
				}
			}
			eHState = new EHState
			{
				OldBP = ctx.Registers[ctx.Data.Constants.REG_BP],
				OldSP = ctx.Registers[ctx.Data.Constants.REG_SP],
				ExceptionObj = ex,
				CurrentProcess = EHState.EHProcess.Searching,
				CurrentFrame = null,
				HandlerFrame = null
			};
			ctx.EHStates.Add(eHState);
		}

		private static void HandleRethrow(VMContext ctx, object ex)
		{
			if (ctx.EHStates.Count > 0)
			{
				SetupEHState(ctx, ex);
			}
			else
			{
				DoThrow(ctx, ex);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void DoThrow(VMContext ctx, object ex)
		{
			Exception ex2 = ex as Exception;
			if (ex2 != null)
			{
				throw ex2;
			}
			throw Throw(ex);
		}

		private static void HandleEH(VMContext ctx, ref ExecutionState state)
		{
			EHState eHState = ctx.EHStates[ctx.EHStates.Count - 1];
			EHState.EHProcess currentProcess = eHState.CurrentProcess;
			EHState.EHProcess eHProcess = currentProcess;
			if (eHProcess != EHState.EHProcess.Searching)
			{
				if (eHProcess != EHState.EHProcess.Unwinding)
				{
					throw new ExecutionEngineException();
				}
			}
			else
			{
				if (eHState.CurrentFrame.HasValue)
				{
					if (ctx.Registers[ctx.Data.Constants.REG_R1].U1 != 0)
					{
						eHState.CurrentProcess = EHState.EHProcess.Unwinding;
						eHState.HandlerFrame = eHState.CurrentFrame;
						eHState.CurrentFrame = ctx.EHStack.Count;
						state = ExecutionState.Next;
						goto IL_0378;
					}
					eHState.CurrentFrame--;
				}
				else
				{
					eHState.CurrentFrame = ctx.EHStack.Count - 1;
				}
				Type type = eHState.ExceptionObj.GetType();
				while (true)
				{
					if (eHState.CurrentFrame >= 0 && !eHState.HandlerFrame.HasValue)
					{
						EHFrame eHFrame = ctx.EHStack[eHState.CurrentFrame.Value];
						if (eHFrame.EHType != ctx.Instance.Data.Constants.EH_FILTER)
						{
							if (eHFrame.EHType == ctx.Instance.Data.Constants.EH_CATCH && eHFrame.CatchType.IsAssignableFrom(type))
							{
								break;
							}
							eHState.CurrentFrame--;
							continue;
						}
						uint u = eHState.OldSP.U4;
						ctx.Stack.SetTopPosition(++u);
						ctx.Stack[u] = new VMSlot
						{
							O = eHState.ExceptionObj
						};
						ctx.Registers[ctx.Data.Constants.REG_K1].U1 = 0;
						ctx.Registers[ctx.Data.Constants.REG_SP].U4 = u;
						ctx.Registers[ctx.Data.Constants.REG_BP] = eHFrame.BP;
						ctx.Registers[ctx.Data.Constants.REG_IP].U8 = eHFrame.FilterAddr;
					}
					if (eHState.CurrentFrame == -1 && !eHState.HandlerFrame.HasValue)
					{
						ctx.EHStates.RemoveAt(ctx.EHStates.Count - 1);
						state = ExecutionState.Rethrow;
						if (ctx.EHStates.Count == 0)
						{
							HandleRethrow(ctx, eHState.ExceptionObj);
						}
					}
					else
					{
						state = ExecutionState.Next;
					}
					return;
				}
				eHState.CurrentProcess = EHState.EHProcess.Unwinding;
				eHState.HandlerFrame = eHState.CurrentFrame;
				eHState.CurrentFrame = ctx.EHStack.Count;
			}
			goto IL_0378;
			IL_0378:
			eHState.CurrentFrame--;
			int num;
			for (num = eHState.CurrentFrame.Value; num > eHState.HandlerFrame.Value; num--)
			{
				EHFrame frame = ctx.EHStack[num];
				ctx.EHStack.RemoveAt(num);
				if (frame.EHType == ctx.Instance.Data.Constants.EH_FAULT || frame.EHType == ctx.Instance.Data.Constants.EH_FINALLY)
				{
					SetupFinallyFrame(ctx, frame);
					break;
				}
			}
			eHState.CurrentFrame = num;
			if (eHState.CurrentFrame == eHState.HandlerFrame)
			{
				EHFrame eHFrame2 = ctx.EHStack[eHState.HandlerFrame.Value];
				ctx.EHStack.RemoveAt(eHState.HandlerFrame.Value);
				eHFrame2.SP.U4++;
				ctx.Stack.SetTopPosition(eHFrame2.SP.U4);
				ctx.Stack[eHFrame2.SP.U4] = new VMSlot
				{
					O = eHState.ExceptionObj
				};
				ctx.Registers[ctx.Data.Constants.REG_K1].U1 = 0;
				ctx.Registers[ctx.Data.Constants.REG_SP] = eHFrame2.SP;
				ctx.Registers[ctx.Data.Constants.REG_BP] = eHFrame2.BP;
				ctx.Registers[ctx.Data.Constants.REG_IP].U8 = eHFrame2.HandlerAddr;
				ctx.EHStates.RemoveAt(ctx.EHStates.Count - 1);
			}
			state = ExecutionState.Next;
		}

		private static void HandleAbnormalExit(VMContext ctx)
		{
			VMSlot vMSlot = ctx.Registers[ctx.Data.Constants.REG_BP];
			VMSlot vMSlot2 = ctx.Registers[ctx.Data.Constants.REG_SP];
			for (int num = ctx.EHStack.Count - 1; num >= 0; num--)
			{
				EHFrame frame = ctx.EHStack[num];
				if (frame.EHType == ctx.Instance.Data.Constants.EH_FAULT || frame.EHType == ctx.Instance.Data.Constants.EH_FINALLY)
				{
					SetupFinallyFrame(ctx, frame);
					Invoke(ctx);
				}
			}
			ctx.EHStack.Clear();
		}

		private static void SetupFinallyFrame(VMContext ctx, EHFrame frame)
		{
			frame.SP.U4++;
			ctx.Registers[ctx.Data.Constants.REG_K1].U1 = 0;
			ctx.Registers[ctx.Data.Constants.REG_SP] = frame.SP;
			ctx.Registers[ctx.Data.Constants.REG_BP] = frame.BP;
			ctx.Registers[ctx.Data.Constants.REG_IP].U8 = frame.HandlerAddr;
			ctx.Stack[frame.SP.U4] = new VMSlot
			{
				U8 = 1uL
			};
		}
	}
}
