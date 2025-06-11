using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using dnlib.DotNet;
using dnlib.PE;
using Ressy;
using XF;

namespace XProtections.Packer
{
	public class Pack
	{
		private static string Lxv(bool bool_0)
		{
			try
			{
				string text = Mxs(Application.ExecutablePath);
				string text2 = Path.Combine(Path.GetDirectoryName(text), "x86_64-win32-tcc.exe");
				if (bool_0)
				{
					text = text2;
				}
				return text;
			}
			catch
			{
				throw new Exception("Error Extracting Compiler, Please disable your antivirus.");
			}
		}

		private static byte[] QxO(int int_0 = 32)
		{
			byte[] array = new byte[int_0];
			using (RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider())
			{
				rNGCryptoServiceProvider.GetBytes(array);
			}
			return array;
		}

		private static byte[] Axu(object object_0, object object_1)
		{
			byte[] array = new byte[((Array)object_0).Length];
			for (int i = 0; i < ((Array)object_0).Length; i++)
			{
				array[i] = (byte)(((byte[])object_0)[i] ^ ((byte[])object_1)[i % ((Array)object_1).Length]);
			}
			return array;
		}

		private static string IxV(object object_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("#include <windows.h>");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("void xorDecrypt(unsigned char* data, DWORD size, const unsigned char* key, DWORD keyLength) {");
			stringBuilder.AppendLine("    for (DWORD i = 0; i < size; i++) {");
			stringBuilder.AppendLine("        data[i] ^= key[i % keyLength];");
			stringBuilder.AppendLine("    }");
			stringBuilder.AppendLine("}");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("void ObfuscatePEHeader() {");
			stringBuilder.AppendLine("    HMODULE hModule = GetModuleHandle(NULL);");
			stringBuilder.AppendLine("    if (hModule == NULL) return;");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("    BYTE* pBaseAddr = (BYTE*)hModule;");
			stringBuilder.AppendLine("    DWORD oldProtect;");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("    if (!VirtualProtect(pBaseAddr, 4096, PAGE_READWRITE, &oldProtect))");
			stringBuilder.AppendLine("        return;");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("    PIMAGE_DOS_HEADER dosHeader = (PIMAGE_DOS_HEADER)pBaseAddr;");
			stringBuilder.AppendLine("    if (dosHeader->e_magic != IMAGE_DOS_SIGNATURE) {");
			stringBuilder.AppendLine("        VirtualProtect(pBaseAddr, 4096, oldProtect, &oldProtect);");
			stringBuilder.AppendLine("        return;");
			stringBuilder.AppendLine("    }");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("    PIMAGE_NT_HEADERS ntHeaders = (PIMAGE_NT_HEADERS)(pBaseAddr + dosHeader->e_lfanew);");
			stringBuilder.AppendLine("    if (ntHeaders->Signature != IMAGE_NT_SIGNATURE) {");
			stringBuilder.AppendLine("        VirtualProtect(pBaseAddr, 4096, oldProtect, &oldProtect);");
			stringBuilder.AppendLine("        return;");
			stringBuilder.AppendLine("    }");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("    ntHeaders->FileHeader.NumberOfSections ^= 0xDEAD;");
			stringBuilder.AppendLine("    ntHeaders->OptionalHeader.CheckSum ^= 0xBEEF;");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("    VirtualProtect(pBaseAddr, 4096, oldProtect, &oldProtect);");
			stringBuilder.AppendLine("}");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("void* loadEmbeddedResource(int resourceId, DWORD* size) {");
			stringBuilder.AppendLine("    HRSRC hResource = FindResource(NULL, MAKEINTRESOURCE(resourceId), RT_RCDATA);");
			stringBuilder.AppendLine("    if (hResource == NULL) { return NULL; }");
			stringBuilder.AppendLine("    HGLOBAL hMemory = LoadResource(NULL, hResource);");
			stringBuilder.AppendLine("    if (hMemory == NULL) { return NULL; }");
			stringBuilder.AppendLine("    *size = SizeofResource(NULL, hResource);");
			stringBuilder.AppendLine("    return LockResource(hMemory);");
			stringBuilder.AppendLine("}");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("const unsigned char XOR_KEY[] = {");
			for (int i = 0; i < ((Array)object_0).Length; i++)
			{
				stringBuilder.Append($"0x{((byte[])object_0)[i]:X2}");
				if (i < ((Array)object_0).Length - 1)
				{
					stringBuilder.Append(", ");
				}
				if ((i + 1) % 12 == 0)
				{
					stringBuilder.AppendLine();
				}
			}
			stringBuilder.AppendLine("};");
			stringBuilder.AppendLine($"const DWORD KEY_LENGTH = {((Array)object_0).Length};");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("void RunPayload() {");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("    DWORD encryptedSize;");
			stringBuilder.AppendLine("    unsigned char* encryptedData = (unsigned char*)loadEmbeddedResource(1, &encryptedSize);");
			stringBuilder.AppendLine("    if (encryptedData == NULL) return;");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("    // Allocate memory for execution");
			stringBuilder.AppendLine("    void* exec = VirtualAlloc(0, encryptedSize, MEM_COMMIT, PAGE_EXECUTE_READWRITE);");
			stringBuilder.AppendLine("    if (exec == NULL) return;");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("    // Copy encrypted data to executable memory");
			stringBuilder.AppendLine("    memcpy(exec, encryptedData, encryptedSize);");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("    // Decrypt the shellcode in-memory");
			stringBuilder.AppendLine("    xorDecrypt((unsigned char*)exec, encryptedSize, XOR_KEY, KEY_LENGTH);");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("    // Execute the decrypted shellcode");
			stringBuilder.AppendLine("    ((void(*)())exec)();");
			stringBuilder.AppendLine("}");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("#ifdef CONSOLE_APP");
			stringBuilder.AppendLine("int main() {");
			stringBuilder.AppendLine("    RunPayload();");
			stringBuilder.AppendLine("    ObfuscatePEHeader();");
			stringBuilder.AppendLine("    return 0;");
			stringBuilder.AppendLine("}");
			stringBuilder.AppendLine("#else");
			stringBuilder.AppendLine("int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow) {");
			stringBuilder.AppendLine("    RunPayload();");
			stringBuilder.AppendLine("    ObfuscatePEHeader();");
			stringBuilder.AppendLine("    return 0;");
			stringBuilder.AppendLine("}");
			stringBuilder.AppendLine("#endif");
			return stringBuilder.ToString();
		}

		private static bool ix4(string string_0)
		{
			try
			{
				using (ModuleDefMD moduleDefMD = ModuleDefMD.Load(string_0))
				{
					return moduleDefMD.Kind == ModuleKind.Console;
				}
			}
			catch
			{
				return false;
			}
		}

		private static string Mxs(string string_0)
		{
			bool flag = false;
			string text = Path.Combine(Path.GetDirectoryName(string_0), "TCC");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
				flag = true;
			}
			string text2 = Path.Combine(text, "tcc.exe");
			if (!File.Exists(text2))
			{
				flag = true;
			}
			string text3 = Path.Combine(Path.GetTempPath(), "Tcc.zip");
			try
			{
				if (flag)
				{
					if (File.Exists(text3))
					{
						File.Delete(text3);
					}
					File.WriteAllBytes(text3, r6.dZ());
					ZipFile.ExtractToDirectory(text3, text);
				}
			}
			finally
			{
				if (File.Exists(text3))
				{
					File.Delete(text3);
				}
			}
			return text2;
		}

		public static byte[] AssemblyToShellCode(string string_0, MethodDef methodDef_0, string string_1 = "")
		{
			string text = Path.Combine(Path.GetTempPath(), "donut.exe");
			string path = Path.Combine(Path.GetTempPath(), "loader.b64");
			string text2 = Path.Combine(Path.GetTempPath(), "tempASMShell.exe");
			try
			{
				if (!File.Exists(text))
				{
					File.WriteAllBytes(text, r6.RD());
				}
				if (File.Exists(text2))
				{
					File.Delete(text2);
				}
				File.Copy(string_0, text2);
				Thread.Sleep(100);
				TypeDef declaringType = methodDef_0.DeclaringType;
				string text3 = string.Format("-f 2 -c {0} -m {1} --input:{2}", string.Concat(declaringType.Namespace, ".", declaringType.Name), methodDef_0.Name, text2);
				if (!string.IsNullOrEmpty(string_1))
				{
					text3 = text3 + " -d " + string_1;
				}
				RunRemoteHost(text, text3);
				if (File.Exists(path))
				{
					string s = File.ReadAllText(path);
					return Convert.FromBase64String(s);
				}
				return null;
			}
			finally
			{
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				if (File.Exists(path))
				{
					File.Delete(path);
				}
				if (File.Exists(text2))
				{
					File.Delete(text2);
				}
			}
		}

		public static string RunRemoteHost(string string_0, string string_1 = "", bool bool_0 = true)
		{
			try
			{
				using (Process process = new Process())
				{
					process.StartInfo = new ProcessStartInfo(string_0, string_1);
					ProcessStartInfo startInfo = process.StartInfo;
					if (bool_0)
					{
						startInfo.CreateNoWindow = true;
						startInfo.UseShellExecute = false;
						startInfo.RedirectStandardOutput = true;
						startInfo.RedirectStandardError = true;
					}
					startInfo.WindowStyle = ProcessWindowStyle.Hidden;
					startInfo.WorkingDirectory = Path.GetDirectoryName(string_0);
					process.Start();
					process.WaitForExit();
					if (bool_0)
					{
						string text = process.StandardOutput.ReadToEnd().ToString() + Environment.NewLine + process.StandardError.ReadToEnd().ToString();
						return text.ToString();
					}
					return "";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public static string GetCustomAttribute(ModuleDefMD moduleDefMD_0, string string_0)
		{
			foreach (CustomAttribute customAttribute in moduleDefMD_0.Assembly.CustomAttributes)
			{
				if (customAttribute.TypeFullName.Contains(string_0))
				{
					return customAttribute.ConstructorArguments[0].Value.ToString();
				}
			}
			return null;
		}

		public void PackAsm(string string_0)
		{
			ModuleDefMD moduleDefMD = null;
			StreamWriter streamWriter = null;
			try
			{
				moduleDefMD = ModuleDefMD.Load(string_0);
				string text = Path.Combine(Path.GetDirectoryName(string_0), Path.GetFileNameWithoutExtension(string_0) + "_Packed.exe");
				Console.WriteLine($"Assembly: {moduleDefMD.Name}");
				Console.WriteLine($"Entry Point: {moduleDefMD.EntryPoint}");
				Console.WriteLine(".NET Runtime: " + moduleDefMD.RuntimeVersion);
				Machine machine = moduleDefMD.Metadata.PEImage.ImageNTHeaders.FileHeader.Machine;
				bool flag = machine == Machine.AMD64 || machine == Machine.IA64;
				Console.WriteLine($"Is 64-bit: {flag}");
				string text2 = Lxv(flag);
				Console.WriteLine("Tiny C Compiler: " + text2);
				byte[] array = AssemblyToShellCode(string_0, moduleDefMD.EntryPoint) ?? throw new Exception("Shellcode generation failed!");
				byte[] array2 = QxO();
				Console.WriteLine($"Generated {array2.Length}-byte XOR encryption key");
				byte[] array3 = Axu(array, array2);
				Console.WriteLine($"Encrypted {array.Length} bytes of shellcode");
				string value = IxV(array2);
				string text3 = Path.Combine(Path.GetTempPath(), "Temp.c");
				using (streamWriter = new StreamWriter(text3))
				{
					streamWriter.Write(value);
				}
				string text4 = "\"" + text3 + "\" -o \"" + text + "\" -luser32 -lkernel32";
				text4 = ((!ix4(string_0)) ? (text4 + " -mwindows") : (text4 + " -D CONSOLE_APP"));
				if (text.ToLower().EndsWith(".dll"))
				{
					text4 += " -shared";
				}
				string text5 = RunRemoteHost(text2, text4);
				if (File.Exists(text3))
				{
					File.Delete(text3);
				}
				if (string.IsNullOrEmpty(text5))
				{
					text5 = "Successful compilation.";
				}
				Console.WriteLine("Compiler Result: " + text5);
				PortableExecutable portableExecutable = new PortableExecutable(text);
				ResourceIdentifier identifier = new ResourceIdentifier(Ressy.ResourceType.FromCode(10), ResourceName.FromCode(1));
				portableExecutable.SetResource(identifier, array3);
				jxY(string_0, text);
				if (File.Exists(text))
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Packed assembly saved to: " + text);
					Console.WriteLine($"Shellcode encrypted with XOR ({array.Length} bytes → {array3.Length} bytes)");
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Failed to save packed assembly to: " + text);
				}
			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				MessageBox.Show("Error: " + ex.Message);
				Console.WriteLine("Stack Trace: " + ex.StackTrace);
			}
			finally
			{
				moduleDefMD?.Dispose();
				streamWriter?.Dispose();
			}
		}

		private void jxY(string string_0, string string_1)
		{
			PortableExecutable portableExecutable = null;
			PortableExecutable portableExecutable2 = null;
			try
			{
				Console.WriteLine("Transferring icons from original file...");
				portableExecutable = new PortableExecutable(string_0);
				portableExecutable2 = new PortableExecutable(string_1);
				Ressy.ResourceType.FromCode(3);
				Ressy.ResourceType.FromCode(14);
				IReadOnlyList<ResourceIdentifier> resourceIdentifiers = portableExecutable.GetResourceIdentifiers();
				foreach (ResourceIdentifier item in resourceIdentifiers)
				{
					if (item.Type.Code == 14)
					{
						try
						{
							Ressy.Resource resource = portableExecutable.GetResource(item);
							portableExecutable2.SetResource(item, resource.Data);
							Console.WriteLine($"Transferred icon group: {item.Name}");
						}
						catch (Exception ex)
						{
							Console.WriteLine($"Error transferring icon group {item.Name}: {ex.Message}");
						}
					}
				}
				foreach (ResourceIdentifier item2 in resourceIdentifiers)
				{
					if (item2.Type.Code == 3)
					{
						try
						{
							Ressy.Resource resource2 = portableExecutable.GetResource(item2);
							portableExecutable2.SetResource(item2, resource2.Data);
							Console.WriteLine($"Transferred icon: {item2.Name}");
						}
						catch (Exception ex2)
						{
							Console.WriteLine($"Error transferring icon {item2.Name}: {ex2.Message}");
						}
					}
				}
				Console.WriteLine("Icon transfer complete.");
			}
			catch (Exception ex3)
			{
				Console.WriteLine("Warning: Failed to transfer icons: " + ex3.Message);
			}
			finally
			{
			}
		}
	}
}
