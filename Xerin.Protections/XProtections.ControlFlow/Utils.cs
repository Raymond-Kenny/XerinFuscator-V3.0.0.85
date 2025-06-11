using System;
using System.Collections.Generic;

namespace XProtections.ControlFlow
{
	public static class Utils
	{
		public static void AddListEntry<TKey, TValue>(this IDictionary<TKey, List<TValue>> idictionary_0, TKey F9O, TValue I9u)
		{
			if (F9O == null)
			{
				throw new ArgumentNullException("key");
			}
			if (!idictionary_0.TryGetValue(F9O, out var value))
			{
				List<TValue> list = (idictionary_0[F9O] = new List<TValue>());
				value = list;
			}
			value.Add(I9u);
		}

		public static IList<T> RemoveWhere<T>(this IList<T> ilist_0, Predicate<T> predicate_0)
		{
			for (int num = ilist_0.Count - 1; num >= 0; num--)
			{
				if (predicate_0(ilist_0[num]))
				{
					ilist_0.RemoveAt(num);
				}
			}
			return ilist_0;
		}
	}
}
