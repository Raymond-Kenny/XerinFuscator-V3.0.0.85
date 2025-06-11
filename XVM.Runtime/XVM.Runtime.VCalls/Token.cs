using System;
using System.Reflection;
using XVM.Runtime.XVM.Runtime.Execution;
using XVM.Runtime.XVM.Runtime.Execution.Internal;

namespace XVM.Runtime.XVM.Runtime.VCalls
{
	internal class Token : IVCall
	{
		public byte Code => VMInstance.STATIC_Instance.Data.Constants.VCALL_TOKEN;

		public void Run(VMContext ctx, out ExecutionState state)
		{
			uint u = ctx.Registers[ctx.Data.Constants.REG_SP].U4;
			VMSlot value = ctx.Stack[u];
			MemberInfo memberInfo = ctx.Instance.Data.LookupReference(value.U4);
			if (memberInfo is Type)
			{
				value.O = ValueTypeBox.Box(((Type)memberInfo).TypeHandle, typeof(RuntimeTypeHandle));
			}
			else if (memberInfo is MethodBase)
			{
				value.O = ValueTypeBox.Box(((MethodBase)memberInfo).MethodHandle, typeof(RuntimeMethodHandle));
			}
			else if (memberInfo is FieldInfo)
			{
				value.O = ValueTypeBox.Box(((FieldInfo)memberInfo).FieldHandle, typeof(RuntimeFieldHandle));
			}
			ctx.Stack[u] = value;
			state = ExecutionState.Next;
		}
	}
}
