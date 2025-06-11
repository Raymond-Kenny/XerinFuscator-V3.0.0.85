using System.Runtime.CompilerServices;
using dnlib.DotNet.Emit;

namespace XVM.Core.AST.ILAST
{
	public class ILASTExpression : ASTExpression, IILASTNode, IILASTStatement
	{
		[CompilerGenerated]
		private Code Kch;

		[CompilerGenerated]
		private Instruction vcP;

		[CompilerGenerated]
		private object hcF;

		[CompilerGenerated]
		private IILASTNode[] xcv;

		[CompilerGenerated]
		private Instruction[] Kcd;

		public Code ILCode
		{
			[CompilerGenerated]
			get
			{
				return Kch;
			}
			[CompilerGenerated]
			set
			{
				Kch = value;
			}
		}

		public Instruction CILInstr
		{
			[CompilerGenerated]
			get
			{
				return vcP;
			}
			[CompilerGenerated]
			set
			{
				vcP = value;
			}
		}

		public object Operand
		{
			[CompilerGenerated]
			get
			{
				return hcF;
			}
			[CompilerGenerated]
			set
			{
				hcF = value;
			}
		}

		public IILASTNode[] Arguments
		{
			[CompilerGenerated]
			get
			{
				return xcv;
			}
			[CompilerGenerated]
			set
			{
				xcv = value;
			}
		}

		public Instruction[] Prefixes
		{
			[CompilerGenerated]
			get
			{
				return Kcd;
			}
			[CompilerGenerated]
			set
			{
				Kcd = value;
			}
		}

		public ILASTExpression Clone()
		{
			return (ILASTExpression)MemberwiseClone();
		}
	}
}
