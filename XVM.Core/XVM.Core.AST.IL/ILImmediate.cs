namespace XVM.Core.AST.IL
{
	public class ILImmediate : ASTConstant, IILOperand
	{
		public static ILImmediate Create(object object_0, ASTType asttype_0)
		{
			return new ILImmediate
			{
				Value = object_0,
				Type = asttype_0
			};
		}
	}
}
