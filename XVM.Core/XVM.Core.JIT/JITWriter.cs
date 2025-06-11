using System.Collections.Generic;
using System.IO;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.MD;
using dnlib.DotNet.Writer;
using XF;

namespace XVM.Core.JIT
{
	public class JITWriter
	{
		private JITContext xjA;

		private ModuleDef HjR;

		private JITDynamicDeriver sj0;

		public JITWriter(JITContext jitcontext_0, ModuleDef moduleDef_0)
		{
			xjA = jitcontext_0;
			HjR = moduleDef_0;
			sj0 = new JITDynamicDeriver();
			JITContext.RealBodies = new List<CilBody>();
		}

		public void HandleRun(ModuleWriterOptions moduleWriterOptions_0)
		{
			if (xjA.Targets.Count == 0)
			{
				return;
			}
			xjA.Runtime.f2C().nKP.Body.SimplifyMacros(xjA.Runtime.f2C().nKP.Parameters);
			List<Instruction> list = xjA.Runtime.f2C().nKP.Body.Instructions.ToList();
			for (int i = 0; i < list.Count; i++)
			{
				Instruction instruction = list[i];
				IMethod method = instruction.Operand as IMethod;
				if (instruction.OpCode == OpCodes.Call && method.DeclaringType.Name == TNd.Q29 && method.Name == TNd.T2A)
				{
					Instruction instruction2 = list[i - 2];
					Instruction instruction3 = list[i - 1];
					list.RemoveAt(i);
					list.RemoveAt(i - 1);
					list.RemoveAt(i - 2);
					list.InsertRange(i - 2, sj0.EmitDecrypt(xjA.Runtime.f2C().nKP, xjA.Runtime, (Local)instruction2.Operand, (Local)instruction3.Operand));
				}
			}
			xjA.Runtime.f2C().nKP.Body.Instructions.Clear();
			foreach (Instruction item in list)
			{
				xjA.Runtime.f2C().nKP.Body.Instructions.Add(item);
			}
			moduleWriterOptions_0.WriterEvent += UjI;
		}

		public static CilBody NopBody(ModuleDef moduleDef_0)
		{
			CilBody cilBody = new CilBody();
			TypeRef typeRef = moduleDef_0.CorLibTypes.GetTypeRef("System", "Exception");
			MemberRefUser mr = new MemberRefUser(moduleDef_0, ".ctor", MethodSig.CreateInstance(moduleDef_0.CorLibTypes.Void, moduleDef_0.CorLibTypes.String), typeRef);
			cilBody.Instructions.Add(OpCodes.Ldstr.ToInstruction(""));
			cilBody.Instructions.Add(OpCodes.Newobj.ToInstruction(mr));
			cilBody.Instructions.Add(OpCodes.Throw.ToInstruction());
			return cilBody;
		}

		private void UjI(object sender, ModuleWriterEventArgs e)
		{
			ModuleWriterBase moduleWriterBase = (ModuleWriterBase)sender;
			if (e.Event != ModuleWriterEvent.MDEndWriteMethodBodies)
			{
				if (e.Event == ModuleWriterEvent.BeginStrongNameSign)
				{
					xjM();
				}
				return;
			}
			gjq(moduleWriterBase);
			foreach (TypeDef type in moduleWriterBase.Module.GetTypes())
			{
				foreach (MethodDef target in xjA.Targets)
				{
					if (type.Methods.Contains(target))
					{
						MDToken token = moduleWriterBase.Metadata.GetToken(target);
						RawMethodRow rawMethodRow = moduleWriterBase.Metadata.TablesHeap.MethodTable[token.Rid];
						moduleWriterBase.Metadata.TablesHeap.MethodTable[token.Rid] = new RawMethodRow(rawMethodRow.RVA, (ushort)(rawMethodRow.ImplFlags | 8), rawMethodRow.Flags, rawMethodRow.Name, rawMethodRow.Signature, rawMethodRow.ParamList);
					}
				}
			}
		}

		private void gjq(ModuleWriterBase moduleWriterBase_0)
		{
			for (int i = 0; i < JITContext.RealBodies.Count; i++)
			{
				MethodDef methodDef = xjA.Targets.ToArray()[i];
				g13 g = new g13(moduleWriterBase_0.Metadata, JITContext.RealBodies[i], moduleWriterBase_0.Metadata.KeepOldMaxStack || methodDef.Body.KeepOldMaxStack);
				g.Q1X();
				xjA.Runtime.JITMethods.Add(new JITEDMethodInfo
				{
					Method = xjA.Targets.ToArray()[i],
					MethodToken = moduleWriterBase_0.Metadata.GetToken(methodDef).ToInt32(),
					ILCode = g.v1n(),
					uint_0 = g.a1s(),
					MaxStack = g.B1i()
				});
			}
		}

		private void xjM()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(xjA.Runtime.JITMethods.Count);
			foreach (JITEDMethodInfo item in xjA.Runtime.JITMethods)
			{
				binaryWriter.Write(item.MethodToken);
				binaryWriter.Write(item.MaxStack);
				binaryWriter.Write(item.uint_0);
				binaryWriter.Write(item.ILCode);
			}
			memoryStream = new MemoryStream(sj0.Encrypt(memoryStream.ToArray()));
			TypeDefUser typeDefUser = new TypeDefUser(xjA.Runtime.o2o().i2i(xjA.Runtime.Descriptor.iqK().NextString()), xjA.Runtime.RTModule.CorLibTypes.GetTypeRef("System", "ValueType"))
			{
				Layout = TypeAttributes.ExplicitLayout,
				Visibility = TypeAttributes.Sealed,
				IsSealed = true,
				ClassLayout = new ClassLayoutUser(0, (uint)memoryStream.Length)
			};
			xjA.Runtime.RTModule.Types.Add(typeDefUser);
			FieldDefUser fieldDefUser = new FieldDefUser(xjA.Runtime.o2o().i2i(xjA.Runtime.Descriptor.iqK().NextString()), new FieldSig(typeDefUser.ToTypeSig()), FieldAttributes.Private | FieldAttributes.Static | FieldAttributes.HasFieldRVA)
			{
				HasFieldRVA = true,
				InitialValue = memoryStream.ToArray()
			};
			xjA.Runtime.f2C().KKU.Fields.Add(fieldDefUser);
			XjJ.sj8(xjA.Runtime.f2C().nKP, 0, (int)memoryStream.Length / 4);
			XjJ.sj8(xjA.Runtime.f2C().nKP, 1, sj0.Seed);
			XjJ.wOM(xjA.Runtime.f2C().nKP, bool_0: true, out var int_);
			xjA.Runtime.f2C().nKP.Body.Instructions.Insert(int_, Instruction.Create(OpCodes.Ldtoken, fieldDefUser));
			xjA.Runtime.f2C().nKP.Body.Instructions.Insert(int_ + 1, Instruction.Create(OpCodes.Call, xjA.Runtime.RTModule.Import(xjA.Runtime.f2C().SKm)));
			xjA.Runtime.f2C().nKP.Body.Instructions.Insert(int_ + 2, Instruction.Create(OpCodes.Callvirt, xjA.Runtime.RTModule.Import(xjA.Runtime.f2C().TK5)));
		}
	}
}
