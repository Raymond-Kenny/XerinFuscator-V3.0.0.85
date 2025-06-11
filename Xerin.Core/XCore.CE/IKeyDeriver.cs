using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XCore.CE
{
	public interface IKeyDeriver
	{
		void Init();

		uint[] DeriveKey(uint[] uint_0, uint[] uint_1);

		IEnumerable<Instruction> EmitDerivation(MethodDef methodDef_0, Local local_0, Local local_1);
	}
}
