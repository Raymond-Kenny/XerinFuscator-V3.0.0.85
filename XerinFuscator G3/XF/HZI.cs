using System;
using System.Reflection;

namespace XF
{
	internal class HZI
	{
		internal delegate void IZF(object o);

		internal static Module yZQ;

		internal static void q7C(int typemdt)
		{
			Type type = yZQ.ResolveType(33554432 + typemdt);
			FieldInfo[] fields = type.GetFields();
			FieldInfo[] array = fields;
			foreach (FieldInfo fieldInfo in array)
			{
				MethodInfo method = (MethodInfo)yZQ.ResolveMethod(fieldInfo.MetadataToken + 100663296);
				fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
			}
		}

		static HZI()
		{
			yZQ = typeof(HZI).Assembly.ManifestModule;
		}
	}
}
