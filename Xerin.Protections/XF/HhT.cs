using System;
using System.Reflection;

namespace XF
{
	internal class HhT
	{
		internal delegate void BhZ(object o);

		internal static Module chi;

		internal static void HGA(int typemdt)
		{
			Type type = chi.ResolveType(33554432 + typemdt);
			FieldInfo[] fields = type.GetFields();
			foreach (FieldInfo fieldInfo in fields)
			{
				MethodInfo method = (MethodInfo)chi.ResolveMethod(fieldInfo.MetadataToken + 100663296);
				fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
			}
		}

		static HhT()
		{
			chi = typeof(HhT).Assembly.ManifestModule;
		}
	}
}
