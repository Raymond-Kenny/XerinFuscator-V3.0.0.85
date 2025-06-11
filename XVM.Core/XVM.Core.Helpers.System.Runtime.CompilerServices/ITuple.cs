using System.Collections;
using System.Text;

namespace XVM.Core.Helpers.System.Runtime.CompilerServices
{
	public interface ITuple
	{
		int Size { get; }

		string ToString(StringBuilder stringBuilder_0);

		int GetHashCode(IEqualityComparer iequalityComparer_0);
	}
}
