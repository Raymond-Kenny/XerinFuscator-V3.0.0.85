using System;

namespace XVM.Runtime.Runtime.ExceptionServices
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	internal class HandleProcessCorruptedStateExceptionsAttribute : Attribute
	{
	}
}
