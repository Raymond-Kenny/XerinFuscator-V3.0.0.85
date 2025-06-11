using dnlib.DotNet;

namespace XVM.Core.JIT
{
	public class JITEDMethodInfo
	{
		public MethodDef Method;

		public int MethodToken;

		public byte[] ILCode;

		public uint uint_0;

		public uint MaxStack;
	}
}
