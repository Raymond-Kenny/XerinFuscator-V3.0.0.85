namespace XVM.Core.AST.IR
{
	public class IRConstant : ASTConstant, IIROperand
	{
		ASTType IIROperand.Type => base.Type.Value;

		public static IRConstant FromI4(int int_0)
		{
			return new IRConstant
			{
				Value = int_0,
				Type = ASTType.I4
			};
		}

		public static IRConstant FromI8(long long_0)
		{
			return new IRConstant
			{
				Value = long_0,
				Type = ASTType.I8
			};
		}

		public static IRConstant FromR4(float float_0)
		{
			return new IRConstant
			{
				Value = float_0,
				Type = ASTType.R4
			};
		}

		public static IRConstant FromR8(double double_0)
		{
			return new IRConstant
			{
				Value = double_0,
				Type = ASTType.R8
			};
		}

		public static IRConstant FromString(string string_0)
		{
			return new IRConstant
			{
				Value = string_0,
				Type = ASTType.O
			};
		}

		public static IRConstant Null()
		{
			return new IRConstant
			{
				Value = null,
				Type = ASTType.O
			};
		}
	}
}
