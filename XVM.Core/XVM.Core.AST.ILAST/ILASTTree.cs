using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace XVM.Core.AST.ILAST
{
	public class ILASTTree : List<IILASTStatement>
	{
		[CompilerGenerated]
		private ILASTVariable[] Vcb;

		public ILASTVariable[] StackRemains
		{
			[CompilerGenerated]
			get
			{
				return Vcb;
			}
			[CompilerGenerated]
			set
			{
				Vcb = value;
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					IILASTStatement current = enumerator.Current;
					stringBuilder.AppendLine(current.ToString());
				}
			}
			stringBuilder.AppendLine();
			stringBuilder.Append("[");
			for (int i = 0; i < StackRemains.Length; i++)
			{
				if (i != 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(StackRemains[i]);
			}
			stringBuilder.AppendLine("]");
			return stringBuilder.ToString();
		}

		public void TraverseTree<T>(Action<ILASTExpression, T> action_0, T mcD)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					IILASTStatement current = enumerator.Current;
					if (current is ILASTExpression)
					{
						GcY((ILASTExpression)current, action_0, mcD);
					}
					else if (current is ILASTAssignment)
					{
						GcY(((ILASTAssignment)current).Value, action_0, mcD);
					}
				}
			}
		}

		private void GcY<Xcg>(ILASTExpression ilastexpression_0, Action<ILASTExpression, Xcg> action_0, Xcg AcV)
		{
			IILASTNode[] arguments = ilastexpression_0.Arguments;
			foreach (IILASTNode iILASTNode in arguments)
			{
				if (iILASTNode is ILASTExpression)
				{
					GcY((ILASTExpression)iILASTNode, action_0, AcV);
				}
			}
			action_0(ilastexpression_0, AcV);
		}
	}
}
