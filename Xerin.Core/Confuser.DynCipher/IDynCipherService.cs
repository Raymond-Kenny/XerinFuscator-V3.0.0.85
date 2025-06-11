using Confuser.DynCipher.AST;
using XCore.Generator;

namespace Confuser.DynCipher
{
	public interface IDynCipherService
	{
		void GenerateCipherPair(RandomGenerator randomGenerator_0, out StatementBlock statementBlock_0, out StatementBlock statementBlock_1);

		void GenerateExpressionPair(RandomGenerator randomGenerator_0, Expression expression_0, Expression expression_1, int int_0, out Expression expression_2, out Expression expression_3);
	}
}
