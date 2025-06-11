using System;
using System.Text;
using dnlib.DotNet;
using XCore.Context;
using XCore.Generator;

namespace XProtections
{
	public class SpamResources
	{
		private static Random z86;

		public static void Execute(XContext xcontext_0)
		{
			for (int i = 0; i < z86.Next(25, 50); i++)
			{
				string s = GGeneration.GenerateGuidStartingWithLetter();
				byte[] bytes = Encoding.ASCII.GetBytes(s);
				string s2 = Convert.ToBase64String(bytes);
				byte[] bytes2 = Encoding.ASCII.GetBytes(s2);
				EmbeddedResource item = new EmbeddedResource(new UTF8String(GGeneration.GenerateGuidStartingWithLetter()), bytes2);
				xcontext_0.Module.Resources.Add(item);
			}
		}

		static SpamResources()
		{
			z86 = new Random();
		}
	}
}
