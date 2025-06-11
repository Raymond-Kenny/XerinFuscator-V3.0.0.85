using System;
using System.Collections.Generic;
using dnlib.DotNet.Writer;

namespace XCore.CE
{
	public static class AntiTamperExtensions
	{
		public static void AddBeforeReloc(this List<PESection> list_0, PESection pesection_0)
		{
			if (list_0 == null)
			{
				throw new ArgumentNullException("sections");
			}
			list_0.InsertBeforeReloc(list_0.Count, pesection_0);
		}

		public static void AddAfterText(this List<PESection> list_0, PESection pesection_0)
		{
			if (list_0 == null)
			{
				throw new ArgumentNullException("sections");
			}
			list_0.InsertAfterText(list_0.Count, pesection_0);
		}

		public static void InsertBeforeReloc(this List<PESection> list_0, int int_0, PESection pesection_0)
		{
			if (list_0 == null)
			{
				throw new ArgumentNullException("sections");
			}
			if (int_0 < 0 || int_0 > list_0.Count)
			{
				throw new ArgumentOutOfRangeException("preferredIndex", int_0, "Preferred index is out of range.");
			}
			if (pesection_0 == null)
			{
				throw new ArgumentNullException("newSection");
			}
			int num = list_0.FindIndex(0, Math.Min(int_0 + new Random().Next(2, 4), list_0.Count), IsRelocSection);
			if (num == -1)
			{
				list_0.Insert(int_0, pesection_0);
			}
			else
			{
				list_0.Insert(num, pesection_0);
			}
		}

		public static void InsertAfterText(this List<PESection> list_0, int int_0, PESection pesection_0)
		{
			if (list_0 == null)
			{
				throw new ArgumentNullException("sections");
			}
			if (int_0 < 0 || int_0 > list_0.Count)
			{
				throw new ArgumentOutOfRangeException("preferredIndex", int_0, "Preferred index is out of range.");
			}
			if (pesection_0 == null)
			{
				throw new ArgumentNullException("newSection");
			}
			int num = list_0.FindIndex(0, Math.Min(int_0 + new Random().Next(2, 4), list_0.Count), IsTextSection);
			if (num == -1)
			{
				list_0.Insert(int_0, pesection_0);
			}
			else
			{
				list_0.Insert(num, pesection_0);
			}
		}

		public static bool IsRelocSection(PESection pesection_0)
		{
			return pesection_0.Name.Equals(".reloc", StringComparison.Ordinal);
		}

		public static bool IsTextSection(PESection pesection_0)
		{
			return pesection_0.Name.Equals(".text", StringComparison.Ordinal);
		}
	}
}
