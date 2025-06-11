using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Context;
using XCore.Generator;
using XCore.Protections;
using XF;

namespace XProtections
{
	public class cctorHider : Protection
	{
		[CompilerGenerated]
		private static bool n2K;

		public override string name => "Cctor mover";

		public override int number => 19;

		public static bool isDynamc
		{
			[CompilerGenerated]
			get
			{
				return n2K;
			}
			[CompilerGenerated]
			set
			{
				n2K = value;
			}
		}

		public override void Execute(XContext xcontext_0)
		{
			if (isDynamc)
			{
				new x2T().z2i(xcontext_0.Module);
			}
			Random random = new Random();
			for (int i = 0; i < random.Next(25, 50); i++)
			{
				TypeDef globalType = xcontext_0.Module.GlobalType;
				TypeDefUser typeDefUser = new TypeDefUser(globalType.Name);
				globalType.Name = GGeneration.GenerateGuidStartingWithLetter();
				globalType.BaseType = xcontext_0.Module.CorLibTypes.GetTypeRef("System", "Object");
				xcontext_0.Module.Types.Insert(0, typeDefUser);
				MethodDef methodDef = globalType.FindOrCreateStaticConstructor();
				MethodDef methodDef2 = typeDefUser.FindOrCreateStaticConstructor();
				methodDef.Name = GGeneration.GenerateGuidStartingWithLetter();
				methodDef.IsRuntimeSpecialName = false;
				methodDef.IsSpecialName = false;
				methodDef.Access = MethodAttributes.PrivateScope;
				methodDef2.Body = new CilBody(initLocals: true, new List<Instruction>
				{
					Instruction.Create(OpCodes.Call, methodDef),
					Instruction.Create(OpCodes.Ret)
				}, new List<ExceptionHandler>(), new List<Local>());
				for (int j = 0; j < globalType.Methods.Count; j++)
				{
					MethodDef methodDef3 = globalType.Methods[j];
					if (methodDef3.IsNative)
					{
						MethodDefUser methodDefUser = new MethodDefUser(methodDef3.Name, methodDef3.MethodSig.Clone())
						{
							Attributes = (MethodAttributes.Assembly | MethodAttributes.Static),
							ImplAttributes = MethodImplAttributes.IL,
							Body = new CilBody()
						};
						methodDefUser.Body.Instructions.Add(new Instruction(OpCodes.Jmp, methodDef3));
						methodDefUser.Body.Instructions.Add(new Instruction(OpCodes.Ret));
						globalType.Methods[j] = methodDefUser;
						typeDefUser.Methods.Add(methodDef3);
					}
				}
			}
		}
	}
}
