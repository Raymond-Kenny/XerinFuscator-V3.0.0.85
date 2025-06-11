using System;
using System.Reflection;

namespace XF
{
	internal class JTm
	{
		internal delegate void wTl(object o);

		internal static Module IT5;

		internal static void Beio(int typemdt)
		{
			Type type = IT5.ResolveType(33554432 + typemdt);
			FieldInfo[] fields = type.GetFields();
			foreach (FieldInfo fieldInfo in fields)
			{
				MethodInfo method = (MethodInfo)IT5.ResolveMethod(fieldInfo.MetadataToken + 100663296);
				fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
			}
		}

		static JTm()
		{
			IT5 = typeof(JTm).Assembly.ManifestModule;
		}
	}
}
