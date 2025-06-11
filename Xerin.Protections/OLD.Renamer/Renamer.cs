using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Context;
using XCore.Generator;
using XCore.Protections;
using XF;

namespace OLD.Renamer
{
	public class Renamer : Protection
	{
		public override string name => "Renamer";

		public override int number => 0;

		public override void Execute(XContext xcontext_0)
		{
			foreach (TypeDef type in xcontext_0.Module.Types)
			{
				if (Globals.props)
				{
					foreach (PropertyDef property in type.Properties)
					{
						if (tP.Ka(type, property))
						{
							property.Name = GGeneration.GenerateGuidStartingWithLetter();
						}
					}
				}
				if (Globals.flds)
				{
					foreach (FieldDef field in type.Fields)
					{
						if (tP.t0(type, field))
						{
							field.Name = GGeneration.GenerateGuidStartingWithLetter();
						}
					}
				}
				if (Globals.events)
				{
					foreach (EventDef @event in type.Events)
					{
						if (tP.Lk(@event))
						{
							@event.Name = GGeneration.GenerateGuidStartingWithLetter();
						}
					}
				}
				if (Globals.methods)
				{
					foreach (MethodDef method in type.Methods)
					{
						if (tP.XQ(method, type))
						{
							method.Name = GGeneration.GenerateGuidStartingWithLetter();
						}
					}
				}
				if (Globals.parameters)
				{
					foreach (MethodDef method2 in type.Methods)
					{
						foreach (Parameter parameter in method2.Parameters)
						{
							if (tP.cr(type, parameter))
							{
								parameter.Name = GGeneration.GenerateGuidStartingWithLetter();
							}
						}
					}
				}
				if (!Globals.types || !tP.VU(type))
				{
					continue;
				}
				string text = GGeneration.GenerateGuidStartingWithLetter();
				string text2 = GGeneration.GenerateGuidStartingWithLetter();
				foreach (MethodDef method3 in type.Methods)
				{
					if (type.BaseType != null && type.BaseType.FullName.ToLower().Contains("form"))
					{
						foreach (Resource resource in xcontext_0.Module.Resources)
						{
							if (resource.Name.Contains(string.Concat(type.Name, ".resources")))
							{
								resource.Name = text + "." + text2 + ".resources";
							}
						}
					}
					type.Namespace = text;
					type.Name = text2;
					if (!method3.Name.Equals("InitializeComponent") || !method3.HasBody)
					{
						continue;
					}
					foreach (Instruction instruction in method3.Body.Instructions)
					{
						if (instruction.OpCode.Equals(OpCodes.Ldstr))
						{
							string text3 = (string)instruction.Operand;
							if (text3 == type.Name)
							{
								instruction.Operand = text2;
								break;
							}
						}
					}
				}
			}
		}
	}
}
