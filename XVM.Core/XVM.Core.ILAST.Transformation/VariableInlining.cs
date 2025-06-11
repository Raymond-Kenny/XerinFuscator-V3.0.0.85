#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet.Emit;
using XVM.Core.AST.ILAST;

namespace XVM.Core.ILAST.Transformation
{
	public class VariableInlining : ITransformationHandler
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class oZM
		{
			public static readonly oZM PZ0;

			public static Func<KeyValuePair<ILASTVariable, int>, bool> QZw;

			public static Func<KeyValuePair<ILASTVariable, int>, ILASTVariable> IZW;

			static oZM()
			{
				PZ0 = new oZM();
			}

			internal bool eZA(KeyValuePair<ILASTVariable, int> keyValuePair_0)
			{
				return keyValuePair_0.Value == 1;
			}

			internal ILASTVariable aZR(KeyValuePair<ILASTVariable, int> keyValuePair_0)
			{
				return keyValuePair_0.Key;
			}
		}

		public void Initialize(ILASTTransformer ilasttransformer_0)
		{
		}

		public static ILASTExpression GetExpression(IILASTStatement iilaststatement_0)
		{
			if (iilaststatement_0 is ILASTExpression)
			{
				ILASTExpression iLASTExpression = (ILASTExpression)iilaststatement_0;
				if (iLASTExpression.ILCode == Code.Pop && iLASTExpression.Arguments[0] is ILASTExpression)
				{
					iLASTExpression = (ILASTExpression)iLASTExpression.Arguments[0];
				}
				return iLASTExpression;
			}
			if (!(iilaststatement_0 is ILASTAssignment))
			{
				return null;
			}
			return ((ILASTAssignment)iilaststatement_0).Value;
		}

		public void Transform(ILASTTransformer ilasttransformer_0)
		{
			Dictionary<ILASTVariable, int> dictionary = new Dictionary<ILASTVariable, int>();
			for (int i = 0; i < ilasttransformer_0.aja().Count; i++)
			{
				IILASTStatement iILASTStatement = ilasttransformer_0.aja()[i];
				ILASTExpression expression = GetExpression(iILASTStatement);
				if (expression == null)
				{
					continue;
				}
				if (!(iILASTStatement is ILASTExpression) || expression.ILCode != Code.Nop)
				{
					if (iILASTStatement is ILASTAssignment)
					{
						ILASTAssignment iLASTAssignment = (ILASTAssignment)iILASTStatement;
						if (Array.IndexOf(ilasttransformer_0.aja().StackRemains, iLASTAssignment.Variable) != -1)
						{
							continue;
						}
						Debug.Assert(iLASTAssignment.Variable.VariableType == ILASTVariableType.StackVar);
					}
					IILASTNode[] arguments = expression.Arguments;
					foreach (IILASTNode iILASTNode in arguments)
					{
						Debug.Assert(iILASTNode is ILASTVariable);
						ILASTVariable iLASTVariable = (ILASTVariable)iILASTNode;
						if (iLASTVariable.VariableType == ILASTVariableType.StackVar)
						{
							dictionary.Increment(iLASTVariable);
						}
					}
				}
				else
				{
					ilasttransformer_0.aja().RemoveAt(i);
					i--;
				}
			}
			ILASTVariable[] stackRemains = ilasttransformer_0.aja().StackRemains;
			foreach (ILASTVariable key in stackRemains)
			{
				dictionary.Remove(key);
			}
			HashSet<ILASTVariable> hashSet = new HashSet<ILASTVariable>(from keyValuePair_0 in dictionary
				where keyValuePair_0.Value == 1
				select keyValuePair_0.Key);
			bool flag;
			do
			{
				flag = false;
				for (int num = 0; num < ilasttransformer_0.aja().Count - 1; num++)
				{
					if (!(ilasttransformer_0.aja()[num] is ILASTAssignment iLASTAssignment2) || !hashSet.Contains(iLASTAssignment2.Variable))
					{
						continue;
					}
					ILASTExpression expression2 = GetExpression(ilasttransformer_0.aja()[num + 1]);
					if (expression2 == null || expression2.ILCode.ToOpCode().Name.StartsWith("stelem"))
					{
						continue;
					}
					for (int num2 = 0; num2 < expression2.Arguments.Length && expression2.Arguments[num2] is ILASTVariable iLASTVariable2; num2++)
					{
						if (iLASTVariable2 == iLASTAssignment2.Variable)
						{
							expression2.Arguments[num2] = iLASTAssignment2.Value;
							ilasttransformer_0.aja().RemoveAt(num);
							num--;
							flag = true;
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
			}
			while (flag);
		}
	}
}
