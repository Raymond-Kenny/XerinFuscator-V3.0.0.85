#define DEBUG
using System;
using System.Diagnostics;

namespace XVM.Runtime.XVM.Runtime.Execution.Internal
{
	internal struct ValueTypeBox<T> : IValueTypeBox
	{
		private T value;

		public ValueTypeBox(T value)
		{
			this.value = value;
		}

		public object GetValue()
		{
			return value;
		}

		public Type GetValueType()
		{
			return typeof(T);
		}

		public IValueTypeBox Clone()
		{
			return new ValueTypeBox<T>(value);
		}
	}
	internal static class ValueTypeBox
	{
		public static IValueTypeBox Box(object vt, Type vtType)
		{
			Debug.Assert(vtType.IsValueType);
			Type type = typeof(ValueTypeBox<>).MakeGenericType(vtType);
			return (IValueTypeBox)Activator.CreateInstance(type, vt);
		}

		public static object Unbox(object box)
		{
			if (box is IValueTypeBox)
			{
				return ((IValueTypeBox)box).GetValue();
			}
			return box;
		}
	}
}
