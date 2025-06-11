using System;
using System.Collections.Generic;
using XF;

namespace Confuser.Core
{
	public class ServiceRegistry : IServiceProvider
	{
		private readonly HashSet<string> YeL = new HashSet<string>();

		private readonly Dictionary<Type, object> zeV = new Dictionary<Type, object>();

		object IServiceProvider.GetService(Type serviceType)
		{
			return zeV.xYh(serviceType);
		}

		public T GetService<T>()
		{
			return (T)zeV.xYh(typeof(T));
		}

		public void RegisterService(string string_0, Type type_0, object object_0)
		{
			if (YeL.Add(string_0))
			{
				if (zeV.ContainsKey(type_0))
				{
					throw new ArgumentException("Service with type '" + object_0.GetType().Name + "' has already registered.", "service");
				}
				zeV.Add(type_0, object_0);
				return;
			}
			throw new ArgumentException("Service with ID '" + YeL?.ToString() + "' has already registered.", "serviceId");
		}

		public bool Contains(string string_0)
		{
			return YeL.Contains(string_0);
		}
	}
}
