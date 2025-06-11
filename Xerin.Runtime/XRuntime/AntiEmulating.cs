using System.Diagnostics;
using System.Net;

namespace XRuntime
{
	public static class AntiEmulating
	{
		internal static void Initialize()
		{
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			IPAddress[] hostAddresses = Dns.GetHostAddresses("you are gay :)");
			IPAddress[] array = hostAddresses;
			foreach (IPAddress iPAddress in array)
			{
				if (iPAddress.Equals(IPAddress.Loopback) || iPAddress.Equals(IPAddress.IPv6Loopback))
				{
					Terminator.Kill((uint)Process.GetCurrentProcess().Id);
				}
			}
		}
	}
}
