using System;

namespace XVM.Runtime.XVM.Runtime.Execution.Internal
{
	internal interface IValueTypeBox
	{
		object GetValue();

		Type GetValueType();

		IValueTypeBox Clone();
	}
}
