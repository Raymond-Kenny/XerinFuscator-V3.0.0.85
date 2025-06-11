using System;
using System.Reflection;

namespace XF
{
	internal class S0L
	{
		internal delegate void j0W(object o);

		internal static Module G0V;

		internal static void A2D(int typemdt)
		{
			Type type = G0V.ResolveType(33554432 + typemdt);
			FieldInfo[] fields = type.GetFields();
			foreach (FieldInfo fieldInfo in fields)
			{
				MethodInfo method = (MethodInfo)G0V.ResolveMethod(fieldInfo.MetadataToken + 100663296);
				fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
			}
		}

		static S0L()
		{
			G0V = typeof(S0L).Assembly.ManifestModule;
		}
	}
}
