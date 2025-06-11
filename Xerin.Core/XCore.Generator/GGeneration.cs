using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace XCore.Generator
{
	public class GGeneration
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class L77
		{
			public static readonly L77 F70;

			public static Func<string, char> I7R;

			static L77()
			{
				F70 = new L77();
			}

			internal char f76(string string_0)
			{
				return string_0[IYj.Next(string_0.Length)];
			}
		}

		[CompilerGenerated]
		private static string eYv;

		[CompilerGenerated]
		private static bool TYx;

		public static HashSet<string> stored;

		private static Random IYj;

		public static string Custom
		{
			[CompilerGenerated]
			get
			{
				return eYv;
			}
			[CompilerGenerated]
			set
			{
				eYv = value;
			}
		}

		public static bool CustomRN
		{
			[CompilerGenerated]
			get
			{
				return TYx;
			}
			[CompilerGenerated]
			set
			{
				TYx = value;
			}
		}

		public static string RandomString(int int_0)
		{
			return new string((from string_0 in Enumerable.Repeat("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", int_0)
				select string_0[IYj.Next(string_0.Length)]).ToArray());
		}

		private static string yYd()
		{
			int num = IYj.Next();
			string text = (num * 1664525 + 63369013).ToString("X");
			if (char.IsDigit(text[0]))
			{
				text = jY1() + text.Substring(1);
			}
			return text;
		}

		private static char jY1()
		{
			int num = IYj.Next(6);
			return (char)(65 + num);
		}

		public static string GenerateGuidStartingWithLetter()
		{
			string text;
			do
			{
				text = (CustomRN ? string.Concat(Custom, "." + yYd()) : yYd());
			}
			while (!stored.Add(text));
			return text;
		}

		static GGeneration()
		{
			stored = new HashSet<string>();
			IYj = new Random();
		}
	}
}
