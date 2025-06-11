#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using dnlib.DotNet.Emit;

namespace XVM.Core.RTProtections.KroksCFlow
{
	public static class BlockParser
	{
		public static ScopeBlock ParseBody(CilBody cilBody_0)
		{
			Dictionary<ExceptionHandler, Tuple<ScopeBlock, ScopeBlock, ScopeBlock>> dictionary = new Dictionary<ExceptionHandler, Tuple<ScopeBlock, ScopeBlock, ScopeBlock>>();
			foreach (ExceptionHandler exceptionHandler in cilBody_0.ExceptionHandlers)
			{
				ScopeBlock item = new ScopeBlock(BlockType.Try, exceptionHandler);
				BlockType blockType_ = BlockType.Handler;
				if (exceptionHandler.HandlerType != ExceptionHandlerType.Finally)
				{
					if (exceptionHandler.HandlerType == ExceptionHandlerType.Fault)
					{
						blockType_ = BlockType.Fault;
					}
				}
				else
				{
					blockType_ = BlockType.Finally;
				}
				ScopeBlock item2 = new ScopeBlock(blockType_, exceptionHandler);
				if (exceptionHandler.FilterStart == null)
				{
					dictionary[exceptionHandler] = Tuple.Create<ScopeBlock, ScopeBlock, ScopeBlock>(item, item2, null);
					continue;
				}
				ScopeBlock item3 = new ScopeBlock(BlockType.Filter, exceptionHandler);
				dictionary[exceptionHandler] = Tuple.Create(item, item2, item3);
			}
			ScopeBlock scopeBlock = new ScopeBlock(BlockType.Normal, null);
			Stack<ScopeBlock> stack = new Stack<ScopeBlock>();
			stack.Push(scopeBlock);
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
						Debug.Assert(stack.Peek().Type == BlockType.Filter);
						stack.Pop();
					}
				}
				foreach (ExceptionHandler item4 in cilBody_0.ExceptionHandlers.Reverse())
				{
					Tuple<ScopeBlock, ScopeBlock, ScopeBlock> tuple = dictionary[item4];
					ScopeBlock scopeBlock2 = ((stack.Count > 0) ? stack.Peek() : null);
					if (instruction == item4.TryStart)
					{
						scopeBlock2?.Children.Add(tuple.Item1);
						stack.Push(tuple.Item1);
					}
					if (instruction == item4.HandlerStart)
					{
						scopeBlock2?.Children.Add(tuple.Item2);
						stack.Push(tuple.Item2);
					}
					if (instruction == item4.FilterStart)
					{
						scopeBlock2?.Children.Add(tuple.Item3);
						stack.Push(tuple.Item3);
					}
				}
				ScopeBlock scopeBlock3 = stack.Peek();
				InstrBlock instrBlock = scopeBlock3.Children.LastOrDefault() as InstrBlock;
				if (instrBlock == null)
				{
					scopeBlock3.Children.Add(instrBlock = new InstrBlock());
				}
				instrBlock.Instructions.Add(instruction);
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
			return scopeBlock;
		}
	}
}
