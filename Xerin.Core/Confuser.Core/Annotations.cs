using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Confuser.Core
{
	public class Annotations
	{
		private class I00 : IEqualityComparer<object>
		{
			public static readonly I00 Q0R;

			private I00()
			{
			}

			public new bool Equals(object x, object y)
			{
				if (y is i0o && !(x is WeakReference))
				{
					return Equals(y, x);
				}
				i0o i0o = x as i0o;
				i0o i0o2 = y as i0o;
				if (i0o != null && i0o2 != null)
				{
					return i0o.IsAlive && i0o2.IsAlive && i0o.Target == i0o2.Target;
				}
				if (i0o != null && i0o2 == null)
				{
					return i0o.IsAlive && i0o.Target == y;
				}
				if (i0o == null && i0o2 == null)
				{
					return i0o.IsAlive && i0o.Target == y;
				}
				throw new Exception();
			}

			public int GetHashCode(object obj)
			{
				if (obj is i0o)
				{
					return ((i0o)obj).W0D();
				}
				return obj.GetHashCode();
			}

			static I00()
			{
				Q0R = new I00();
			}
		}

		private class i0o : WeakReference
		{
			[CompilerGenerated]
			private int x0v;

			public i0o(object object_0)
				: base(object_0)
			{
				j0d(object_0.GetHashCode());
			}

			[SpecialName]
			[CompilerGenerated]
			public int W0D()
			{
				return x0v;
			}

			[SpecialName]
			[CompilerGenerated]
			private void j0d(int int_0)
			{
				x0v = int_0;
			}
		}

		[Serializable]
		[CompilerGenerated]
		private sealed class K0x
		{
			public static readonly K0x K04;

			public static Func<KeyValuePair<object, ListDictionary>, bool> H0n;

			public static Func<KeyValuePair<object, ListDictionary>, object> p0h;

			static K0x()
			{
				K04 = new K0x();
			}

			internal bool A0j(KeyValuePair<object, ListDictionary> keyValuePair_0)
			{
				return !((i0o)keyValuePair_0.Key).IsAlive;
			}

			internal object Y0K(KeyValuePair<object, ListDictionary> keyValuePair_0)
			{
				return keyValuePair_0.Key;
			}
		}

		private readonly Dictionary<object, ListDictionary> GeM = new Dictionary<object, ListDictionary>(I00.Q0R);

		public TValue Get<TValue>(object object_0, object object_1, TValue re5 = default(TValue))
		{
			if (object_0 == null)
			{
				throw new ArgumentNullException("obj");
			}
			if (object_1 == null)
			{
				throw new ArgumentNullException("key");
			}
			ListDictionary value;
			if (!GeM.TryGetValue(object_0, out value))
			{
				return re5;
			}
			if (!value.Contains(object_1))
			{
				return re5;
			}
			Type typeFromHandle = typeof(TValue);
			if (typeFromHandle.IsValueType)
			{
				return (TValue)Convert.ChangeType(value[object_1], typeof(TValue));
			}
			return (TValue)value[object_1];
		}

		public TValue GetLazy<TValue>(object object_0, object object_1, Func<object, TValue> func_0)
		{
			if (object_0 == null)
			{
				throw new ArgumentNullException("obj");
			}
			if (object_1 == null)
			{
				throw new ArgumentNullException("key");
			}
			ListDictionary value;
			if (!GeM.TryGetValue(object_0, out value))
			{
				return func_0(object_1);
			}
			if (!value.Contains(object_1))
			{
				return func_0(object_1);
			}
			Type typeFromHandle = typeof(TValue);
			if (typeFromHandle.IsValueType)
			{
				return (TValue)Convert.ChangeType(value[object_1], typeof(TValue));
			}
			return (TValue)value[object_1];
		}

		public TValue GetOrCreate<TValue>(object object_0, object object_1, Func<object, TValue> func_0)
		{
			if (object_0 == null)
			{
				throw new ArgumentNullException("obj");
			}
			if (object_1 == null)
			{
				throw new ArgumentNullException("key");
			}
			ListDictionary value;
			if (!GeM.TryGetValue(object_0, out value))
			{
				ListDictionary listDictionary = (GeM[new i0o(object_0)] = new ListDictionary());
				value = listDictionary;
			}
			if (value.Contains(object_1))
			{
				Type typeFromHandle = typeof(TValue);
				if (typeFromHandle.IsValueType)
				{
					return (TValue)Convert.ChangeType(value[object_1], typeof(TValue));
				}
				return (TValue)value[object_1];
			}
			TValue result;
			value[object_1] = (result = func_0(object_1));
			return result;
		}

		public void Set<TValue>(object object_0, object object_1, TValue NeH)
		{
			if (object_0 == null)
			{
				throw new ArgumentNullException("obj");
			}
			if (object_1 == null)
			{
				throw new ArgumentNullException("key");
			}
			ListDictionary value;
			if (!GeM.TryGetValue(object_0, out value))
			{
				ListDictionary listDictionary = (GeM[new i0o(object_0)] = new ListDictionary());
				value = listDictionary;
			}
			value[object_1] = NeH;
		}

		public void Trim()
		{
			foreach (object item in from keyValuePair_0 in GeM
				where !((i0o)keyValuePair_0.Key).IsAlive
				select keyValuePair_0.Key)
			{
				GeM.Remove(item);
			}
		}
	}
}
