using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XCore.DynConverter
{
	public class ExceptionMapper
	{
		[CompilerGenerated]
		private readonly IList<ExceptionHandler> MQj;

		[SpecialName]
		[CompilerGenerated]
		private IList<ExceptionHandler> bQv()
		{
			return MQj;
		}

		public ExceptionMapper(MethodDef methodDef_0)
		{
			MQj = methodDef_0.Body.ExceptionHandlers;
		}

		public void MapAndWrite(BinaryWriter binaryWriter_0, Instruction instruction_0)
		{
			int num = 0;
			List<int> list = new List<int>();
			foreach (ExceptionHandler item in bQv())
			{
				if (item.TryStart != instruction_0)
				{
					if (item.HandlerEnd != instruction_0)
					{
						if (item.HandlerType == ExceptionHandlerType.Filter && item.FilterStart == instruction_0)
						{
							list.Add(1);
							num++;
						}
						else
						{
							if (item.HandlerStart != instruction_0)
							{
								continue;
							}
							switch (item.HandlerType)
							{
							case ExceptionHandlerType.Catch:
								list.Add(2);
								if (item.CatchType != null)
								{
									list.Add(item.CatchType.MDToken.ToInt32());
								}
								else
								{
									list.Add(-1);
								}
								break;
							case ExceptionHandlerType.Finally:
								list.Add(3);
								break;
							case ExceptionHandlerType.Fault:
								list.Add(4);
								break;
							}
							num++;
						}
					}
					else
					{
						list.Add(5);
						num++;
					}
				}
				else
				{
					list.Add(0);
					num++;
				}
			}
			binaryWriter_0.Write(num);
			foreach (int item2 in list)
			{
				binaryWriter_0.Write(item2);
			}
		}
	}
}
