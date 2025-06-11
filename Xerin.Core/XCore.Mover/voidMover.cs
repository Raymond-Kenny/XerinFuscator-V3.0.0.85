using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Context;
using XCore.Utils;

namespace XCore.Mover
{
	public static class voidMover
	{
		public static void Execute(XContext xcontext_0)
		{
			foreach (TypeDef type in xcontext_0.Module.GetTypes())
			{
				MethodDef[] array = type.Methods.ToArray();
				foreach (MethodDef methodDef in array)
				{
					if (methodDef == xcontext_0.Module.EntryPoint)
					{
						mover(xcontext_0.Module, methodDef);
					}
				}
			}
		}

		public static void mover(ModuleDefMD moduleDefMD_0, MethodDef methodDef_0)
		{
			MethodDef entryPoint = moduleDefMD_0.EntryPoint;
			if (entryPoint == null)
			{
				return;
			}
			MethodDef methodDef = XCore.Utils.Utils.CreateMethod(moduleDefMD_0);
			methodDef.DeclaringType = null;
			int index = moduleDefMD_0.EntryPoint.DeclaringType.Methods.IndexOf(entryPoint);
			entryPoint.DeclaringType.Methods.Insert(index, methodDef);
			MethodDef methodDef2 = moduleDefMD_0.GlobalType.FindStaticConstructor();
			MethodDef methodDef3 = null;
			foreach (TypeDef type in moduleDefMD_0.GetTypes())
			{
				foreach (MethodDef method2 in type.Methods)
				{
					if (method2 == methodDef_0)
					{
						methodDef3 = method2;
					}
				}
			}
			methodDef.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(methodDef3));
			Instruction instruction = null;
			for (int i = 0; i < methodDef2.Body.Instructions.Count; i++)
			{
				Instruction instruction2 = methodDef2.Body.Instructions[i];
				if (instruction2.OpCode == OpCodes.Call)
				{
					IMethod method = instruction2.Operand as IMethod;
					if (method != null && method == methodDef_0)
					{
						instruction = instruction2;
						break;
					}
				}
			}
			if (instruction != null)
			{
				methodDef2.Body.Instructions.Remove(instruction);
			}
			methodDef2.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(methodDef));
			methodDef3.Name = XCore.Utils.Utils.MethodsRenamig();
		}
	}
}
