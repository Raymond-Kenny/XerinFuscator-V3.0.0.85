#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet.Emit;
using XVM.Core.AST;
using XVM.Core.AST.ILAST;

namespace XVM.Core.ILAST.Transformation
{
	public class BranchTransform : ITransformationHandler
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class UZ9
		{
			public static readonly UZ9 DZI;

			public static Func<IILASTNode, bool> xZq;

			static UZ9()
			{
				DZI = new UZ9();
			}

			internal bool LZG(IILASTNode iilastnode_0)
			{
				return iilastnode_0.Type.Value == ASTType.R4 || iilastnode_0.Type.Value == ASTType.R8;
			}
		}

		private static readonly Dictionary<Code, Tuple<Code, Code, Code>> jjg;

		public void Initialize(ILASTTransformer ilasttransformer_0)
		{
		}

		public void Transform(ILASTTransformer ilasttransformer_0)
		{
			ilasttransformer_0.aja().TraverseTree(mjY, ilasttransformer_0.Method.Module);
		}

		private static void mjY(ILASTExpression ilastexpression_0, object object_0)
		{
			Code iLCode = ilastexpression_0.ILCode;
			Code code = iLCode;
			if (code - 59 <= Code.Ldloc_3)
			{
				Debug.Assert(ilastexpression_0.Arguments.Length == 2);
				Tuple<Code, Code, Code> tuple = jjg[ilastexpression_0.ILCode];
				Code iLCode2 = (ilastexpression_0.Arguments.Any((IILASTNode iilastnode_0) => iilastnode_0.Type.Value == ASTType.R4 || iilastnode_0.Type.Value == ASTType.R8) ? tuple.Item2 : tuple.Item1);
				ilastexpression_0.ILCode = tuple.Item3;
				ilastexpression_0.Arguments = new IILASTNode[1]
				{
					new ILASTExpression
					{
						ILCode = iLCode2,
						Arguments = ilastexpression_0.Arguments,
						Type = ASTType.I4
					}
				};
			}
		}

		static BranchTransform()
		{
			jjg = new Dictionary<Code, Tuple<Code, Code, Code>>
			{
				{
					Code.Beq,
					Tuple.Create(Code.Ceq, Code.Ceq, Code.Brtrue)
				},
				{
					Code.Bne_Un,
					Tuple.Create(Code.Ceq, Code.Ceq, Code.Brfalse)
				},
				{
					Code.Bge,
					Tuple.Create(Code.Clt, Code.Clt_Un, Code.Brfalse)
				},
				{
					Code.Bge_Un,
					Tuple.Create(Code.Clt_Un, Code.Clt, Code.Brfalse)
				},
				{
					Code.Ble,
					Tuple.Create(Code.Cgt, Code.Cgt_Un, Code.Brfalse)
				},
				{
					Code.Ble_Un,
					Tuple.Create(Code.Cgt_Un, Code.Cgt, Code.Brfalse)
				},
				{
					Code.Bgt,
					Tuple.Create(Code.Cgt, Code.Cgt, Code.Brtrue)
				},
				{
					Code.Bgt_Un,
					Tuple.Create(Code.Cgt_Un, Code.Cgt_Un, Code.Brtrue)
				},
				{
					Code.Blt,
					Tuple.Create(Code.Clt, Code.Clt, Code.Brtrue)
				},
				{
					Code.Blt_Un,
					Tuple.Create(Code.Clt_Un, Code.Clt_Un, Code.Brtrue)
				}
			};
		}
	}
}
