using Confuser.DynCipher;
using Confuser.DynCipher.AST;
using Confuser.DynCipher.Generation;
using XCore.Generator;

namespace XF
{
	internal class XQO : IDynCipherService
	{
		public void GenerateCipherPair(RandomGenerator randomGenerator_0, out StatementBlock statementBlock_0, out StatementBlock statementBlock_1)
		{
			CipherGenerator.GeneratePair(randomGenerator_0, out statementBlock_0, out statementBlock_1);
		}

		public void GenerateExpressionPair(RandomGenerator randomGenerator_0, Expression expression_0, Expression expression_1, int int_0, out Expression expression_2, out Expression expression_3)
		{
			ExpressionGenerator.GeneratePair(randomGenerator_0, expression_0, expression_1, int_0, out expression_2, out expression_3);
		}
	}
}
