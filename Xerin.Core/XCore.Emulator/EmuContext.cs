using System;
using System.Collections.Generic;
using dnlib.DotNet.Emit;

namespace XCore.Emulator
{
	public class EmuContext
	{
		internal Stack<object> dQN;

		internal List<Instruction> KQU;

		internal int yQY = 0;

		public Dictionary<Local, object> _locals;

		public EmuContext(List<Instruction> list_0, List<Local> list_1)
		{
			dQN = new Stack<object>();
			KQU = list_0;
			_locals = new Dictionary<Local, object>();
			foreach (Local item in list_1)
			{
				_locals.Add(item, null);
			}
		}

		internal object GYB(Local local_0)
		{
			Type type = Type.GetType(local_0.Type.AssemblyQualifiedName);
			return Convert.ChangeType(_locals[local_0], type);
		}

		internal void sYz(Local local_0, object object_0)
		{
			_locals[local_0] = object_0;
		}
	}
}
