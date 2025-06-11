using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

namespace XVM.Core.Helpers.System.Diagnostics.Contracts
{
	public static class Contract
	{
		[Conditional("CONTRACTS_FULL")]
		[Conditional("DEBUG")]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static void Assume(bool bool_0)
		{
			if (!bool_0)
			{
			}
		}

		[Conditional("CONTRACTS_FULL")]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[Conditional("DEBUG")]
		public static void Assume(bool bool_0, string string_0)
		{
			if (!bool_0)
			{
			}
		}

		[Conditional("DEBUG")]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[Conditional("CONTRACTS_FULL")]
		public static void Assert(bool bool_0)
		{
			if (bool_0)
			{
			}
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[Conditional("CONTRACTS_FULL")]
		[Conditional("DEBUG")]
		public static void Assert(bool bool_0, string string_0)
		{
			if (!bool_0)
			{
			}
		}

		[Conditional("CONTRACTS_FULL")]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static void Requires(bool bool_0)
		{
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[Conditional("CONTRACTS_FULL")]
		public static void Requires(bool bool_0, string string_0)
		{
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static void Requires<T>(bool bool_0) where T : Exception
		{
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static void Requires<T>(bool bool_0, string string_0) where T : Exception
		{
		}

		[Conditional("CONTRACTS_FULL")]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static void Ensures(bool bool_0)
		{
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[Conditional("CONTRACTS_FULL")]
		public static void Ensures(bool bool_0, string string_0)
		{
		}

		[Conditional("CONTRACTS_FULL")]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static void EnsuresOnThrow<T>(bool bool_0) where T : Exception
		{
		}

		[Conditional("CONTRACTS_FULL")]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static void EnsuresOnThrow<T>(bool bool_0, string string_0) where T : Exception
		{
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static T Result<T>()
		{
			return default(T);
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static T ValueAtReturn<T>(out T gparam_0)
		{
			gparam_0 = default(T);
			return gparam_0;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static T OldValue<T>(T MOQ)
		{
			return default(T);
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[Conditional("CONTRACTS_FULL")]
		public static void Invariant(bool bool_0)
		{
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[Conditional("CONTRACTS_FULL")]
		public static void Invariant(bool bool_0, string string_0)
		{
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static bool ForAll(int int_0, int int_1, Predicate<int> predicate_0)
		{
			if (int_0 > int_1)
			{
				throw new ArgumentException("fromInclusive must be less than or equal to toExclusive.");
			}
			if (predicate_0 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			int num = int_0;
			while (true)
			{
				if (num < int_1)
				{
					if (!predicate_0(num))
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static bool ForAll<T>(IEnumerable<T> ienumerable_0, Predicate<T> predicate_0)
		{
			if (ienumerable_0 == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (predicate_0 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			foreach (T item in ienumerable_0)
			{
				if (!predicate_0(item))
				{
					return false;
				}
			}
			return true;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static bool Exists(int int_0, int int_1, Predicate<int> predicate_0)
		{
			if (int_0 > int_1)
			{
				throw new ArgumentException("fromInclusive must be less than or equal to toExclusive.");
			}
			if (predicate_0 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			int num = int_0;
			while (true)
			{
				if (num < int_1)
				{
					if (predicate_0(num))
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static bool Exists<T>(IEnumerable<T> ienumerable_0, Predicate<T> predicate_0)
		{
			if (ienumerable_0 == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (predicate_0 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			foreach (T item in ienumerable_0)
			{
				if (predicate_0(item))
				{
					return true;
				}
			}
			return false;
		}

		[Conditional("CONTRACTS_FULL")]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static void EndContractBlock()
		{
		}
	}
}
