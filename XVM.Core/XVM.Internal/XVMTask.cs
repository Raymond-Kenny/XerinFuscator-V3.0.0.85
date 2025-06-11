using System.Collections.Generic;
using System.IO;
using dnlib.DotNet;
using XVM.CodeEncryption;

namespace XVM.Internal
{
	public class XVMTask
	{
		public void Execute(ModuleDefMD moduleDefMD_0, HashSet<MethodDef> hashSet_0, string string_0, string string_1, string string_2, string string_3)
		{
			InitializePhase initializePhase = null;
			try
			{
				initializePhase = new InitializePhase(moduleDefMD_0)
				{
					Methods = hashSet_0,
					RT_OUT_Directory = Path.GetDirectoryName(string_0),
					RTName = string_1,
					SNK_File = string_2,
					SNK_Password = string_3
				};
				initializePhase.Initialize();
				new XVM.CodeEncryption.CodeEncryption().Execute(moduleDefMD_0);
				initializePhase.GetProtectedFile(out var byte_);
				initializePhase.SaveRuntime();
				using (FileStream fileStream = new FileStream(string_0, FileMode.Create, FileAccess.Write))
				{
					fileStream.Write(byte_, 0, byte_.Length);
				}
			}
			finally
			{
				initializePhase?.Dispose();
				moduleDefMD_0.Dispose();
			}
		}
	}
}
